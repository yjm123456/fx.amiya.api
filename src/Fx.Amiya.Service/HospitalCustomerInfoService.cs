using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.HospitalCustomerInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HospitalCustomerInfoService : IHospitalCustomerInfoService
    {
        private IDalHospitalCustomerInfo dalHospitalCustomerInfo;
        private ICustomerBaseInfoService customerBaseInfoService;
        private IHospitalBindCustomerService hospitalBindCustomerService;
        private IWxAppConfigService wxAppConfigService;


        public HospitalCustomerInfoService(IDalHospitalCustomerInfo dalHospitalCustomerInfo,
            ICustomerBaseInfoService customerBaseInfoService,
            IWxAppConfigService wxAppConfigService,
            IHospitalBindCustomerService hospitalBindCustomerService)
        {
            this.dalHospitalCustomerInfo = dalHospitalCustomerInfo;
            this.customerBaseInfoService = customerBaseInfoService;
            this.hospitalBindCustomerService = hospitalBindCustomerService;
            this.wxAppConfigService = wxAppConfigService;
        }


        /// <summary>
        /// 根据医院id获取医院客户
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SendHospitalCustomerInfoDto>> GetListWithPageAsync(string keyword, int hospitalId,int employeeId, int pageNum, int pageSize)
        {
            try
            {
                var hospitalCustomerInfo = from d in dalHospitalCustomerInfo.GetAll()
                                           where (keyword == null || d.CustomerPhone.Contains(keyword))
                                           && (d.hospitalId == hospitalId)
                                           && d.Valid
                                           select new SendHospitalCustomerInfoDto
                                           {
                                               Id = d.Id,
                                               CustomerPhone = d.CustomerPhone,
                                               hospitalId = d.hospitalId,
                                               ConfirmOrderDate = d.ConfirmOrderDate,
                                               NewGoodsDemand = d.NewGoodsDemand,
                                               SendAmount = d.SendAmount,
                                               DealAmount = d.DealAmount,
                                               CreateDate = d.CreateDate,
                                               UpdateDate = d.UpdateDate,
                                               Valid = d.Valid,
                                               DeleteDate = d.DeleteDate
                                           };

                FxPageInfo<SendHospitalCustomerInfoDto> hospitalCustomerInfoPageInfo = new FxPageInfo<SendHospitalCustomerInfoDto>();
                hospitalCustomerInfoPageInfo.TotalCount = await hospitalCustomerInfo.CountAsync();
                hospitalCustomerInfoPageInfo.List = await hospitalCustomerInfo.OrderByDescending(x=>x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                foreach (var x in hospitalCustomerInfoPageInfo.List)
                {

                    var baseInfo = await customerBaseInfoService.GetByPhoneAsync(x.CustomerPhone);
                    x.CustomerName = baseInfo.Name;
                    x.City = baseInfo.City;
                    var bindHospitalEmpId = await hospitalBindCustomerService.GetEmployeeIdByPhone(x.CustomerPhone);
                    if (employeeId == bindHospitalEmpId)
                    {
                        x.IsMyFollow = true;
                    }
                    else { x.IsMyFollow = false; }
                    var config = await wxAppConfigService.GetCallCenterConfig();
                    string encryptPhone = ServiceClass.Encrypt(x.CustomerPhone, config.PhoneEncryptKey);
                    x.EncryptPhone = encryptPhone;
                }
                return hospitalCustomerInfoPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// 根据医院id和登陆账户获取“我来跟进”的医院客户
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SendHospitalCustomerInfoDto>> GetByHospitalEmployeeIdListWithPageAsync(string keyword, int hospitalEmployeeId, int pageNum, int pageSize)
        {
            try
            {
                var hospitalBindCustomerInfoList = await hospitalBindCustomerService.GetByHospitalEmployeeIdListWithPageAsync(keyword, hospitalEmployeeId, pageNum, pageSize);
                foreach (var x in hospitalBindCustomerInfoList.List)
                {
                    var baseInfo = await customerBaseInfoService.GetByPhoneAsync(x.CustomerPhone);
                    x.CustomerName = baseInfo.Name;
                    x.City = baseInfo.City;
                    var hospitalCustomerInfo = await this.GetByHospitalIdAndPhoneAsync(x.hospitalId, x.CustomerPhone);
                    x.NewGoodsDemand = hospitalCustomerInfo.NewGoodsDemand;
                    x.CreateDate = hospitalCustomerInfo.CreateDate;
                    x.UpdateDate = hospitalCustomerInfo.UpdateDate;
                    x.ConfirmOrderDate = hospitalCustomerInfo.ConfirmOrderDate;
                    x.SendAmount = hospitalCustomerInfo.SendAmount;
                    x.DealAmount = hospitalCustomerInfo.DealAmount;
                    x.IsMyFollow = true;
                    var config = await wxAppConfigService.GetCallCenterConfig();
                    string encryptPhone = ServiceClass.Encrypt(x.CustomerPhone, config.PhoneEncryptKey);
                    x.EncryptPhone = encryptPhone;
                }
                return hospitalBindCustomerInfoList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAsync(AddSendHospitalCustomerInfoDto addDto)
        {
            try
            {
                HospitalCustomerInfo hospitalCustomerInfo = new HospitalCustomerInfo();
                hospitalCustomerInfo.Id = Guid.NewGuid().ToString();
                hospitalCustomerInfo.CustomerPhone = addDto.CustomerPhone;
                hospitalCustomerInfo.hospitalId = addDto.hospitalId;
                hospitalCustomerInfo.NewGoodsDemand = addDto.NewGoodsDemand;
                hospitalCustomerInfo.SendAmount = addDto.SendAmount;
                hospitalCustomerInfo.DealAmount = addDto.DealAmount;
                hospitalCustomerInfo.CreateDate = DateTime.Now;
                hospitalCustomerInfo.UpdateDate = DateTime.Now;
                hospitalCustomerInfo.Valid = true;

                await dalHospitalCustomerInfo.AddAsync(hospitalCustomerInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<SendHospitalCustomerInfoDto> GetByIdAsync(string id)
        {
            try
            {
                var hospitalCustomerInfo = await dalHospitalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (hospitalCustomerInfo == null)
                {
                    return new SendHospitalCustomerInfoDto();
                }

                SendHospitalCustomerInfoDto hospitalCustomerInfoDto = new SendHospitalCustomerInfoDto();
                hospitalCustomerInfoDto.Id = hospitalCustomerInfo.Id;
                hospitalCustomerInfoDto.CustomerPhone = hospitalCustomerInfo.CustomerPhone;
                hospitalCustomerInfoDto.hospitalId = hospitalCustomerInfo.hospitalId;
                hospitalCustomerInfoDto.NewGoodsDemand = hospitalCustomerInfo.NewGoodsDemand;
                hospitalCustomerInfoDto.SendAmount = hospitalCustomerInfo.SendAmount;
                hospitalCustomerInfoDto.DealAmount = hospitalCustomerInfo.DealAmount;
                hospitalCustomerInfoDto.CreateDate = hospitalCustomerInfo.CreateDate;
                hospitalCustomerInfoDto.UpdateDate = hospitalCustomerInfo.UpdateDate;
                hospitalCustomerInfoDto.Valid = hospitalCustomerInfo.Valid;
                hospitalCustomerInfoDto.DeleteDate = hospitalCustomerInfo.DeleteDate;
                return hospitalCustomerInfoDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<SendHospitalCustomerInfoDto> GetByHospitalIdAndPhoneAsync(int hospitalId, string phone)
        {
            try
            {
                var hospitalCustomerInfo = await dalHospitalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.hospitalId == hospitalId && e.CustomerPhone == phone);
                if (hospitalCustomerInfo == null)
                {
                    return new SendHospitalCustomerInfoDto()
                    {
                        Id = ""
                    };
                }

                SendHospitalCustomerInfoDto hospitalCustomerInfoDto = new SendHospitalCustomerInfoDto();

                var baseInfo = await customerBaseInfoService.GetByPhoneAsync(hospitalCustomerInfo.CustomerPhone);
                hospitalCustomerInfoDto.Id = hospitalCustomerInfo.Id;
                hospitalCustomerInfoDto.CustomerName = baseInfo.Name;
                hospitalCustomerInfoDto.City = baseInfo.City;
                hospitalCustomerInfoDto.CustomerPhone = hospitalCustomerInfo.CustomerPhone;
                hospitalCustomerInfoDto.hospitalId = hospitalCustomerInfo.hospitalId;
                hospitalCustomerInfoDto.NewGoodsDemand = hospitalCustomerInfo.NewGoodsDemand;
                hospitalCustomerInfoDto.SendAmount = hospitalCustomerInfo.SendAmount;
                hospitalCustomerInfoDto.DealAmount = hospitalCustomerInfo.DealAmount;
                hospitalCustomerInfoDto.ConfirmOrderDate = hospitalCustomerInfo.ConfirmOrderDate;
                hospitalCustomerInfoDto.CreateDate = hospitalCustomerInfo.CreateDate;
                hospitalCustomerInfoDto.UpdateDate = hospitalCustomerInfo.UpdateDate;
                hospitalCustomerInfoDto.Valid = hospitalCustomerInfo.Valid;
                hospitalCustomerInfoDto.DeleteDate = hospitalCustomerInfo.DeleteDate;
                return hospitalCustomerInfoDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 更新顾客派单次数与项目需求
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateConfirmOrderDateAsync(UpdateSendHospitalCustomerInfoDto updateDto)
        {
            try
            {
                var hospitalCustomerInfo = await dalHospitalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalCustomerInfo == null)
                    throw new Exception("医院客户编号错误！");

                hospitalCustomerInfo.ConfirmOrderDate = DateTime.Now;
                await dalHospitalCustomerInfo.UpdateAsync(hospitalCustomerInfo, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新顾客派单次数与项目需求
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task InsertSendAmountAsync(UpdateSendHospitalCustomerInfoDto updateDto)
        {
            try
            {
                var hospitalCustomerInfo = await dalHospitalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalCustomerInfo == null)
                    throw new Exception("医院客户编号错误！");

                hospitalCustomerInfo.NewGoodsDemand = updateDto.NewGoodsDemand;
                hospitalCustomerInfo.SendAmount = updateDto.SendAmount;
                hospitalCustomerInfo.UpdateDate = DateTime.Now;
                await dalHospitalCustomerInfo.UpdateAsync(hospitalCustomerInfo, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新成交次数
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task InsertDealAmountAsync(UpdateSendHospitalCustomerInfoDto updateDto)
        {
            try
            {
                var hospitalCustomerInfo = await dalHospitalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (hospitalCustomerInfo == null)
                    throw new Exception("医院客户编号错误！");

                hospitalCustomerInfo.DealAmount = updateDto.DealAmount;

                await dalHospitalCustomerInfo.UpdateAsync(hospitalCustomerInfo, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var hospitalCustomerInfo = await dalHospitalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (hospitalCustomerInfo == null)
                    throw new Exception("医院客户编号错误");
                hospitalCustomerInfo.Valid = false;
                hospitalCustomerInfo.DeleteDate = DateTime.Now;
                await dalHospitalCustomerInfo.UpdateAsync(hospitalCustomerInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
