using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.RFMCustomerInfo;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class RFMCustomerInfoService : IRFMCustomerInfoService
    {
        private readonly IDalHospitalInfo dalHospitalInfo;
        private readonly IDalAmiyaEmployee dalAmiyaEmployee;
        private readonly IDalRFMCustomerInfo dalRFMCustomerInfo;
        private IDalConfig _dalConfig;
        private IDalLiveAnchorWeChatInfo dalLiveAnchorWeChatInfo;
        private readonly IUnitOfWork unitOfWork;
        public RFMCustomerInfoService(IDalHospitalInfo dalHospitalInfo, IDalAmiyaEmployee dalAmiyaEmployee, IDalRFMCustomerInfo dalRFMCustomerInfo, IDalConfig dalConfig, IDalLiveAnchorWeChatInfo dalLiveAnchorWeChatInfo, IUnitOfWork unitOfWork)
        {
            this.dalHospitalInfo = dalHospitalInfo;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.dalRFMCustomerInfo = dalRFMCustomerInfo;
            _dalConfig = dalConfig;
            this.dalLiveAnchorWeChatInfo = dalLiveAnchorWeChatInfo;
            this.unitOfWork = unitOfWork;
        }

        public async Task ImportRFMCustomerInfoAsync(List<ImportRfmCustomerDto> list)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var hospitalInfoList = dalHospitalInfo.GetAll().Select(e => new { Name = e.Name, Id = e.Id });
                var employeeInfoList = dalAmiyaEmployee.GetAll().Select(e => new { Name = e.Name, Id = e.Id });
                var wechatNoInfoList = dalLiveAnchorWeChatInfo.GetAll().Select(e => new { Name = e.WeChatNo, Id = e.Id });
                var RFMValue = GetRFMValueText();
                var RFMTagValue = GetRFMTagText();
                foreach (var item in list)
                {
                    RMFCustomerInfo info = new RMFCustomerInfo();
                    info.Id = Guid.NewGuid().ToString().Replace("-", "");
                    info.CustomerServiceId = employeeInfoList.Where(e => e.Name == item.CustomerServiceName).FirstOrDefault()?.Id ?? null;
                    info.Phone = item.Phone;
                    info.LastDealDate = item.LastDealDate;
                    info.HospitalId = hospitalInfoList.Where(e => e.Name == item.HospitalName).FirstOrDefault()?.Id ?? null;
                    info.DealPrice = item.DealPrice;
                    info.TotalDealPrice = item.TotalDealPrice;
                    info.ConsumptionFrequency = item.ConsumptionFrequency;
                    info.RecencyDate = item.RecencyDate;
                    info.Recency = Convert.ToInt32(RFMValue.Where(e => e.Value == item.Recency).FirstOrDefault()?.Key ?? "0");
                    info.Frequency = Convert.ToInt32(RFMValue.Where(e => e.Value == item.Frequency).FirstOrDefault()?.Key ?? "0");
                    info.Monetary = Convert.ToInt32(RFMValue.Where(e => e.Value == item.Monetary).FirstOrDefault()?.Key ?? "0");
                    info.RFMTag = ServiceClass.GetRFMTagByName(item.RFMTag);
                    info.LiveAnchorWechatNo = wechatNoInfoList.Where(e => e.Name == item.LiveAnchorWechatNo).FirstOrDefault()?.Id ?? null; ;
                    info.Valid = true;
                    info.CreateDate = DateTime.Now;
                    await dalRFMCustomerInfo.AddAsync(info, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
            
        }

        public List<BaseKeyValueDto> GetRFMValueText()
        {
            var billReturnBackStateTexts = Enum.GetValues(typeof(RFM));

            List<BaseKeyValueDto> billReturnBackStateTextList = new List<BaseKeyValueDto>();
            foreach (var item in billReturnBackStateTexts)
            {
                BaseKeyValueDto baseKeyValueDto = new BaseKeyValueDto();
                baseKeyValueDto.Key = Convert.ToInt32(item).ToString();
                baseKeyValueDto.Value = ServiceClass.GetRFMText(Convert.ToInt32(item));
                billReturnBackStateTextList.Add(baseKeyValueDto);
            }
            return billReturnBackStateTextList;
        }
        public List<BaseKeyValueDto> GetRFMTagText()
        {
            var billReturnBackStateTexts = Enum.GetValues(typeof(RFMTagLevel));

            List<BaseKeyValueDto> billReturnBackStateTextList = new List<BaseKeyValueDto>();
            foreach (var item in billReturnBackStateTexts)
            {
                BaseKeyValueDto baseKeyValueDto = new BaseKeyValueDto();
                baseKeyValueDto.Key = Convert.ToInt32(item).ToString();
                baseKeyValueDto.Value = ServiceClass.GetRFMTagText(Convert.ToInt32(item));
                billReturnBackStateTextList.Add(baseKeyValueDto);
            }
            return billReturnBackStateTextList;
        }

        public async Task<FxPageInfo<RFMCustomerInfoDto>> GetListByPageAsync(int? employeeId,int? leave,string keyword, int pageNum, int pageSize)
        {
            var config = await GetCallCenterConfig();
            FxPageInfo<RFMCustomerInfoDto> fxPageInfo = new FxPageInfo<RFMCustomerInfoDto>();
            var infoList = dalRFMCustomerInfo.GetAll()
                .Where(e => string.IsNullOrEmpty(keyword) || e.Phone.Contains(keyword))
                .Where(e => e.Valid == true).Where(e => !employeeId.HasValue || e.CustomerServiceId == employeeId)
                .Where(e=>!leave.HasValue||e.RFMTag==leave)
                .OrderBy(e=>e.RFMTag)
                .ThenBy(e=>e.Phone)
                .ThenByDescending(e=>e.LastDealDate);
            fxPageInfo.TotalCount = infoList.Count();
            fxPageInfo.List = infoList.Skip((pageNum - 1) * pageSize).Take(pageSize).Select(e => new RFMCustomerInfoDto
            {
                Id = e.Id,
                Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(e.Phone) : e.Phone,
                EncryptPhone = ServiceClass.Encrypt(e.Phone, config.PhoneEncryptKey),
                CustomerServiceName = e.CustomerServiceId.HasValue ? dalAmiyaEmployee.GetAll().Where(a => a.Id == e.CustomerServiceId).FirstOrDefault().Name : "",
                LastDealDate = e.LastDealDate,
                HospitalName = e.HospitalId.HasValue ? dalHospitalInfo.GetAll().Where(h => h.Id == e.HospitalId).FirstOrDefault().Name : "",
                DealPrice = e.DealPrice,
                TotalDealPrice = e.TotalDealPrice,
                ConsumptionFrequency = e.ConsumptionFrequency,
                RecencyDate = e.RecencyDate,
                Recency = ServiceClass.GetRFMText(e.Recency),
                Frequency = ServiceClass.GetRFMText(e.Frequency),
                Monetary = ServiceClass.GetRFMText(e.Monetary),
                RFMTag = ((RFMTagLevel)e.RFMTag).ToString(),
                RFMTagText = ServiceClass.GetRFMTagText(e.RFMTag),
                LiveAnchorWechatNo = !string.IsNullOrEmpty(e.LiveAnchorWechatNo) ? dalLiveAnchorWeChatInfo.GetAll().Where(w => w.Id == e.LiveAnchorWechatNo).FirstOrDefault().WeChatNo : "",
            }).ToList();
            return fxPageInfo;
        }

        public async Task AddAsync(AddRFMCustomerInfoDto addDto)
        {
            RMFCustomerInfo info = new RMFCustomerInfo();
            info.Id = Guid.NewGuid().ToString().Replace("-", "");
            info.CustomerServiceId = addDto.CustomerServiceId;
            info.Phone = addDto.Phone;
            info.LastDealDate = addDto.LastDealDate;
            info.HospitalId = addDto.HospitalId;
            info.DealPrice = addDto.DealPrice;
            info.TotalDealPrice = addDto.TotalDealPrice;
            info.ConsumptionFrequency = addDto.ConsumptionFrequency;
            info.RecencyDate = addDto.RecencyDate;
            info.Recency = addDto.Recency;
            info.Frequency = addDto.Frequency;
            info.Monetary = addDto.Monetary;
            info.RFMTag = addDto.RFMTag;
            info.LiveAnchorWechatNo = addDto.LiveAnchorWechatNo;
            info.Valid = true;
            info.CreateDate = DateTime.Now;
            await dalRFMCustomerInfo.AddAsync(info, true);
        }

        public async Task<RFMCustomerInfoDto> GetByIdAsync(string id)
        {
            return dalRFMCustomerInfo.GetAll().Where(e => e.Id == id).Select(e => new RFMCustomerInfoDto
            {
                Id = e.Id,
                Phone = e.Phone,
                CustomerServiceId = e.CustomerServiceId,
                CustomerServiceName = e.CustomerServiceId.HasValue ? dalAmiyaEmployee.GetAll().Where(a => a.Id == e.CustomerServiceId).FirstOrDefault().Name : "未知客服",
                LastDealDate = e.LastDealDate,
                HospitalId = e.HospitalId,
                HospitalName = e.HospitalId.HasValue ? dalHospitalInfo.GetAll().Where(h => h.Id == e.HospitalId).FirstOrDefault().Name : "未知医院",
                DealPrice = e.DealPrice,
                TotalDealPrice = e.TotalDealPrice,
                ConsumptionFrequency = e.ConsumptionFrequency,
                RecencyDate = e.RecencyDate,
                RecencyLeave = e.Recency,
                Recency = ServiceClass.GetRFMText(e.Recency),
                FrequencyLeave = e.Frequency,
                Frequency = ServiceClass.GetRFMText(e.Frequency),
                MonetaryLeave = e.Monetary,
                Monetary = ServiceClass.GetRFMText(e.Monetary),
                RFMTagLeave = e.RFMTag,
                RFMTag = ((RFMTagLevel)e.RFMTag).ToString(),
                RFMTagText = ServiceClass.GetRFMTagText(e.RFMTag),
                LiveAnchorWechatNo = !string.IsNullOrEmpty(e.LiveAnchorWechatNo) ? dalLiveAnchorWeChatInfo.GetAll().Where(w => w.Id == e.LiveAnchorWechatNo).FirstOrDefault().WeChatNo : null,
                LiveAnchorWechatNoId = e.LiveAnchorWechatNo
            }).FirstOrDefault();
        }

        public async Task UpdateAsync(UpdateRFMCustomerInfoDto updateDto)
        {
            var info = dalRFMCustomerInfo.GetAll().Where(e => e.Id == updateDto.Id).FirstOrDefault();
            if (info == null) throw new Exception("编号错误");
            info.CustomerServiceId = updateDto.CustomerServiceId;
            info.Phone = updateDto.Phone;
            info.LastDealDate = updateDto.LastDealDate;
            info.HospitalId = updateDto.HospitalId;
            info.DealPrice = updateDto.DealPrice;
            info.TotalDealPrice = updateDto.TotalDealPrice;
            info.ConsumptionFrequency = updateDto.ConsumptionFrequency;
            info.RecencyDate = updateDto.RecencyDate;
            info.Recency = updateDto.Recency;
            info.Frequency = updateDto.Frequency;
            info.Monetary = updateDto.Monetary;
            info.RFMTag = updateDto.RFMTag;
            info.LiveAnchorWechatNo = updateDto.LiveAnchorWechatNo;
            info.UpdateDate = DateTime.Now;
            await dalRFMCustomerInfo.UpdateAsync(info, true);
        }
        public async Task DeleteAsync(string id)
        {
            var info = dalRFMCustomerInfo.GetAll().Where(e => e.Id == id).FirstOrDefault();
            if (info == null) throw new Exception("编号错误");
            info.Valid = false;
            info.DeleteDate = DateTime.Now;
            await dalRFMCustomerInfo.UpdateAsync(info, true);
        }
        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await _dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }
    }
}
