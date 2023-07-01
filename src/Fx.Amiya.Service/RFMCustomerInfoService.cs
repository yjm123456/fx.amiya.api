using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.RFMCustomerInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
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

        public RFMCustomerInfoService(IDalHospitalInfo dalHospitalInfo, IDalAmiyaEmployee dalAmiyaEmployee, IDalRFMCustomerInfo dalRFMCustomerInfo)
        {
            this.dalHospitalInfo = dalHospitalInfo;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.dalRFMCustomerInfo = dalRFMCustomerInfo;
        }

        public async Task ImportRFMCustomerInfoAsync(List<ImportRfmCustomerDto> list)
        {
            var hospitalInfoList = dalHospitalInfo.GetAll().Select(e => new { Name = e.Name, Id = e.Id });
            var employeeInfoList = dalAmiyaEmployee.GetAll().Select(e => new { Name = e.Name, Id = e.Id });
            var RFMValue = GetRFMValueText();
            var RFMTagValue = GetRFMTagText();
            foreach (var item in list)
            {
                RMFCustomerInfo info = new RMFCustomerInfo();
                info.Id = Guid.NewGuid().ToString().Replace("-", "");
                info.CustomerServiceId = employeeInfoList.Where(e => e.Name == item.CustomerServiceName).FirstOrDefault()?.Id ?? null;
                info.Phone = item.Phone;
                info.LastDealDate = item.LastDealDate;
                info.HospitalId=hospitalInfoList.Where(e=>e.Name==item.HospitalName).FirstOrDefault()?.Id ?? null;
                info.DealPrice = item.DealPrice;
                info.TotalDealPrice = item.TotalDealPrice;
                info.ConsumptionFrequency = item.ConsumptionFrequency;
                info.RecentDealPrice = item.RecentDealPrice;
                info.Recency = Convert.ToInt32(RFMValue.Where(e => e.Value == item.Recency).FirstOrDefault()?.Key ?? "0");
                info.Frequency = Convert.ToInt32(RFMValue.Where(e => e.Value == item.Frequency).FirstOrDefault()?.Key ?? "0");
                info.Monetary = Convert.ToInt32(RFMValue.Where(e => e.Value == item.Monetary).FirstOrDefault()?.Key ?? "0");
                info.RFMTag = Convert.ToInt32(RFMTagValue.Where(e => e.Value == item.RFMTag).FirstOrDefault()?.Key ?? "0");
                info.LiveAnchorWechatNo = item.LiveAnchorWechatNo;
                info.Valid = true;
                info.CreateDate = DateTime.Now;
                await dalRFMCustomerInfo.AddAsync(info,true);
            }
        }

        public List<BaseKeyValueDto> GetRFMValueText() {
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

        public async Task<FxPageInfo<RFMCustomerInfoDto>> GetListByPageAsync(string keyword, int pageNum, int pageSize)
        {
            FxPageInfo<RFMCustomerInfoDto> fxPageInfo = new FxPageInfo<RFMCustomerInfoDto>();
            var infoList= dalRFMCustomerInfo.GetAll().Where(e => string.IsNullOrEmpty(keyword) || e.Phone.Contains(keyword)).Where(e=>e.Valid==true);
            fxPageInfo.TotalCount = infoList.Count();
            fxPageInfo.List = infoList.Skip((pageNum - 1) * pageSize).Take(pageSize).Select(e => new RFMCustomerInfoDto {
                Id = e.Id,
                Phone = e.Phone,
                CustomerServiceName = dalAmiyaEmployee.GetAll().Where(a => a.Id == e.CustomerServiceId).FirstOrDefault().Name,
                LastDealDate = e.LastDealDate,
                HospitalName = dalHospitalInfo.GetAll().Where(h => h.Id == e.HospitalId).FirstOrDefault().Name,
                DealPrice = e.DealPrice,
                TotalDealPrice = e.TotalDealPrice,
                ConsumptionFrequency=e.ConsumptionFrequency,
                RecentDealPrice=e.RecentDealPrice,
                Recency=ServiceClass.GetRFMText(e.Recency),
                Frequency= ServiceClass.GetRFMText(e.Frequency),
                Monetary = ServiceClass.GetRFMText(e.Monetary),
                RFMTag=((RFMTagLeave)e.RFMTag).ToString(),
                RFMTagText = ServiceClass.GetRFMTagText(e.RFMTag),
                LiveAnchorWechatNo=e.LiveAnchorWechatNo
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
            info.RecentDealPrice = addDto.RecentDealPrice;
            info.Recency = addDto.Recency;
            info.Frequency = addDto.Frequency;
            info.Monetary = addDto.Monetary;
            info.RFMTag = addDto.RFMTag;
            info.LiveAnchorWechatNo = addDto.LiveAnchorWechatNo;
            info.Valid = true;
            info.CreateDate = DateTime.Now;
        }

        public async Task<RFMCustomerInfoDto> GetByIdAsync(string id)
        {
            return dalRFMCustomerInfo.GetAll().Where(e => e.Id == id).Select(e => new RFMCustomerInfoDto {
                Id = e.Id,
                Phone = e.Phone,
                CustomerServiceName = dalAmiyaEmployee.GetAll().Where(a => a.Id == e.CustomerServiceId).FirstOrDefault().Name,
                LastDealDate = e.LastDealDate,
                HospitalName = dalHospitalInfo.GetAll().Where(h => h.Id == e.HospitalId).FirstOrDefault().Name,
                DealPrice = e.DealPrice,
                TotalDealPrice = e.TotalDealPrice,
                ConsumptionFrequency = e.ConsumptionFrequency,
                RecentDealPrice = e.RecentDealPrice,
                Recency = ServiceClass.GetRFMText(e.Recency),
                Frequency = ServiceClass.GetRFMText(e.Frequency),
                Monetary = ServiceClass.GetRFMText(e.Monetary),
                RFMTag = ((RFMTagLeave)e.RFMTag).ToString(),
                RFMTagText = ServiceClass.GetRFMTagText(e.RFMTag),
                LiveAnchorWechatNo = e.LiveAnchorWechatNo
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
            info.RecentDealPrice = updateDto.RecentDealPrice;
            info.Recency = updateDto.Recency;
            info.Frequency = updateDto.Frequency;
            info.Monetary = updateDto.Monetary;
            info.RFMTag = updateDto.RFMTag;
            info.LiveAnchorWechatNo = updateDto.LiveAnchorWechatNo;
            info.UpdateDate = DateTime.Now;
            await dalRFMCustomerInfo.UpdateAsync(info,true);
        }

        public async Task DeleteAsync(string id)
        {
            var info = dalRFMCustomerInfo.GetAll().Where(e => e.Id == id).FirstOrDefault();
            if (info == null) throw new Exception("编号错误");
            info.Valid = false;
            info.DeleteDate = DateTime.Now;
            await dalRFMCustomerInfo.UpdateAsync(info, true);
        }
    }
}
