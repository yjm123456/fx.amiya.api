using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Infrastructure.Utils;
using Fx.Amiya.Dto.WxAppConfig;
using Newtonsoft.Json;
using Fx.Amiya.Dto.HospitalBindCustomerService;
using Fx.Common;
using Fx.Amiya.Dto.HospitalCustomerInfo;

namespace Fx.Amiya.Service
{
    public class HospitalBindCustomerServiceService : IHospitalBindCustomerService
    {
        private IDalHospitalBindCustomerService dalHospitalBindCustomerService;
        private IDalHospitalEmployee dalHospitalEmployee;
        private IDalCustomerInfo dalCustomerInfo;
        private IDalConfig dalConfig;
        public HospitalBindCustomerServiceService(IDalHospitalBindCustomerService dalHospitalBindCustomerService,
            IDalHospitalEmployee dalHospitalEmployee,
            IDalCustomerInfo dalCustomerInfo,
            IDalConfig dalConfig)
        {
            this.dalHospitalBindCustomerService = dalHospitalBindCustomerService;
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalHospitalEmployee = dalHospitalEmployee;
            this.dalConfig = dalConfig;
        }



        /// <summary>
        /// 根据医院id和登陆账户获取“我来跟进”的医院客户
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SendHospitalCustomerInfoDto>> GetByHospitalEmployeeIdListWithPageAsync(string keyword,int hospitalEmployeeId, int pageNum, int pageSize)
        {
            try
            {
                var hospitalCustomerInfo = from d in dalHospitalBindCustomerService.GetAll()
                                           where (keyword == null || d.CustomerPhone.Contains(keyword))
                                           && (d.HospitalEmployeeId == hospitalEmployeeId)
                                           select new SendHospitalCustomerInfoDto
                                           {
                                               CustomerPhone = d.CustomerPhone,
                                               hospitalId=d.HospitalCustomerServiceHospitalEmployee.HospitalId
                                           };

                FxPageInfo<SendHospitalCustomerInfoDto> hospitalCustomerInfoPageInfo = new FxPageInfo<SendHospitalCustomerInfoDto>();
                hospitalCustomerInfoPageInfo.TotalCount = await hospitalCustomerInfo.CountAsync();
                hospitalCustomerInfoPageInfo.List = await hospitalCustomerInfo.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return hospitalCustomerInfoPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 机构接单
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task AddAsync(AddHospitalBindCustomerServiceDto addDto)
        {
            try
            {

                var bind = await dalHospitalBindCustomerService.GetAll()
                  .Include(e => e.HospitalCustomerServiceHospitalEmployee)
                  .FirstOrDefaultAsync(e => e.CustomerPhone == addDto.CustomerPhone);
                if (bind != null)
                {
                    if (bind.HospitalEmployeeId != addDto.HospitalEmployeeId)
                    {
                        var employee = await dalHospitalEmployee.GetAll().Include(e => e.HospitalPositionInfo).SingleOrDefaultAsync(e => e.Id == addDto.HospitalEmployeeId);
                        if (employee.HospitalPositionInfo.Id != 1)
                        {
                            throw new Exception("该客户已被" + bind.HospitalCustomerServiceHospitalEmployee.Name + "接单,请联系对应人员进行操作！");
                        }
                    }
                    else
                    {
                        bind.NewConsumptionDate = DateTime.Now;
                        bind.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                        bind.NewContentPlatForm = addDto. NewContentPlatformName;
                        await dalHospitalBindCustomerService.UpdateAsync(bind, true);
                    }
                }
                else
                {

                    HospitalBindCustomerService bindCustomerService = new HospitalBindCustomerService();
                    bindCustomerService.HospitalEmployeeId = addDto.HospitalEmployeeId;
                    bindCustomerService.CustomerPhone = addDto.CustomerPhone;
                    bindCustomerService.UserId = null;
                    bindCustomerService.CreateBy = addDto.HospitalEmployeeId;
                    bindCustomerService.CreateDate = DateTime.Now;
                    bindCustomerService.FirstProjectDemand = addDto.FirstProjectDemand;
                    bindCustomerService.FirstConsumptionDate = DateTime.Now;
                    bindCustomerService.NewConsumptionDate = DateTime.Now;
                    bindCustomerService.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                    bindCustomerService.NewContentPlatForm = addDto.NewContentPlatformName;
                    bindCustomerService.AllPrice = 0;
                    bindCustomerService.AllOrderCount = 0;
                    await dalHospitalBindCustomerService.AddAsync(bindCustomerService, true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HospitalBindCustomerServiceDto> GetEmployeeDetailsByPhoneAsync(string phone)
        {
            try
            {
                var hospitalBindCustomerServiceInfo = await dalHospitalBindCustomerService.GetAll().Include(x => x.HospitalCustomerServiceHospitalEmployee).FirstOrDefaultAsync(e => e.CustomerPhone == phone);
                HospitalBindCustomerServiceDto result = new HospitalBindCustomerServiceDto();
                result.Id = hospitalBindCustomerServiceInfo.Id;
                result.HospitalEmployeeId = hospitalBindCustomerServiceInfo.HospitalEmployeeId;
                result.HospitaEmployeeName = hospitalBindCustomerServiceInfo.HospitalCustomerServiceHospitalEmployee.Name;
                result.CustomerPhone = hospitalBindCustomerServiceInfo.CustomerPhone;
                result.UserId = hospitalBindCustomerServiceInfo.UserId;
                result.CreateBy = hospitalBindCustomerServiceInfo.CreateBy;
                result.CreateDate = hospitalBindCustomerServiceInfo.CreateDate;
                result.FirstProjectDemand = hospitalBindCustomerServiceInfo.FirstProjectDemand;
                result.FirstConsumptionDate = hospitalBindCustomerServiceInfo.FirstConsumptionDate;
                result.NewConsumptionDate = hospitalBindCustomerServiceInfo.NewConsumptionDate;
                result.NewConsumptionContentPlatform = hospitalBindCustomerServiceInfo.NewConsumptionContentPlatform;
                result.NewContentPlatForm = hospitalBindCustomerServiceInfo.NewContentPlatForm;
                result.AllPrice = hospitalBindCustomerServiceInfo.AllPrice;
                result.AllOrderCount = hospitalBindCustomerServiceInfo.AllOrderCount;
                return result;
            }
            catch (Exception err)
            { return new HospitalBindCustomerServiceDto(); }

        }

        public async Task<HospitalBindCustomerServiceDto> GetByIdAsync(int id)
        {
            try
            {
                var hospitalBindCustomerServiceInfo = await dalHospitalBindCustomerService.GetAll().Include(x => x.HospitalCustomerServiceHospitalEmployee).FirstOrDefaultAsync(e => e.Id == id);
                HospitalBindCustomerServiceDto result = new HospitalBindCustomerServiceDto();
                result.Id = hospitalBindCustomerServiceInfo.Id;
                result.HospitalEmployeeId = hospitalBindCustomerServiceInfo.HospitalEmployeeId;
                result.HospitaEmployeeName = hospitalBindCustomerServiceInfo.HospitalCustomerServiceHospitalEmployee.Name;
                result.CustomerPhone = hospitalBindCustomerServiceInfo.CustomerPhone;
                result.UserId = hospitalBindCustomerServiceInfo.UserId;
                result.CreateBy = hospitalBindCustomerServiceInfo.CreateBy;
                result.CreateDate = hospitalBindCustomerServiceInfo.CreateDate;
                result.FirstProjectDemand = hospitalBindCustomerServiceInfo.FirstProjectDemand;
                result.FirstConsumptionDate = hospitalBindCustomerServiceInfo.FirstConsumptionDate;
                result.NewConsumptionDate = hospitalBindCustomerServiceInfo.NewConsumptionDate;
                result.NewConsumptionContentPlatform = hospitalBindCustomerServiceInfo.NewConsumptionContentPlatform;
                result.NewContentPlatForm = hospitalBindCustomerServiceInfo.NewContentPlatForm;
                result.AllPrice = hospitalBindCustomerServiceInfo.AllPrice;
                result.AllOrderCount = hospitalBindCustomerServiceInfo.AllOrderCount;
                return result;
            }
            catch (Exception err)
            { return new HospitalBindCustomerServiceDto(); }

        }

        public async Task<int> GetEmployeeIdByPhone(string phone)
        {
            try
            {
                var hospitalBindCustomerServiceInfo = await dalHospitalBindCustomerService.GetAll().SingleOrDefaultAsync(e => e.CustomerPhone == phone);
                if (hospitalBindCustomerServiceInfo != null && hospitalBindCustomerServiceInfo.HospitalEmployeeId != 0)
                {
                    return hospitalBindCustomerServiceInfo.HospitalEmployeeId;
                }
                else { return 0; }
            }
            catch (Exception err)
            { return 0; }

        }
        public async Task<List<string>> GetEmployeePhoneByPhone(string phone)
        {
            try
            {
                var hospitalBindCustomerServiceInfo = await dalHospitalBindCustomerService.GetAll().Where(e => e.CustomerPhone.Contains(phone)).ToListAsync();

                return hospitalBindCustomerServiceInfo.Select(x => x.CustomerPhone).ToList();

            }
            catch (Exception err)
            {
                return new List<string>();
            }

        }

        /// <summary>
        /// 小程序绑定客户时修改绑定客服的userId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task UpdateBindUserIdAsync(string customerId)
        {
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
            if (customer != null)
            {
                var hospitalBindCustomerService = await dalHospitalBindCustomerService.GetAll().SingleOrDefaultAsync(e => e.CustomerPhone == customer.Phone);
                if (hospitalBindCustomerService != null)
                {
                    hospitalBindCustomerService.UserId = customer.UserId;
                    await dalHospitalBindCustomerService.UpdateAsync(hospitalBindCustomerService, true);
                }

            }
        }
        /// <summary>
        /// 新增累计消费金额
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task UpdateConsumePriceAsync(string phone, decimal Price, int Channel, int AllOrderCount)
        {
            var hospitalBindCustomerService = await dalHospitalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.CustomerPhone == phone);
            if (hospitalBindCustomerService != null)
            {
                if (hospitalBindCustomerService.AllPrice == null)
                {
                    hospitalBindCustomerService.AllPrice = Price;
                }
                else
                {
                    hospitalBindCustomerService.AllPrice += Price;
                }
                hospitalBindCustomerService.AllOrderCount += AllOrderCount;
                hospitalBindCustomerService.NewConsumptionContentPlatform = Channel;
                hospitalBindCustomerService.NewConsumptionDate = DateTime.Now;
                await dalHospitalBindCustomerService.UpdateAsync(hospitalBindCustomerService, true);
            }

        }

        /// <summary>
        /// 减少累计消费金额
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task ReduceConsumePriceAsync(string phone, decimal Price, int Channel)
        {
            var hospitalBindCustomerService = await dalHospitalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.CustomerPhone == phone);
            if (hospitalBindCustomerService != null)
            {
                hospitalBindCustomerService.AllPrice -= Price;

                hospitalBindCustomerService.AllOrderCount -= 1;
                await dalHospitalBindCustomerService.UpdateAsync(hospitalBindCustomerService, true);
            }

        }


        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }





        /// <summary>
        /// 修改绑定机构客服
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateHospitalBindCustomerServiceDto updateDto, int employeeId)
        {
            DateTime date = DateTime.Now;
            List<string> encryptPhoneList = updateDto.EncryptPhoneList.Distinct().ToList();
            var config = await GetCallCenterConfig();
            foreach (var encryptPhone in encryptPhoneList)
            {
                string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);
                var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Phone == phone);

                var hospitalBindCustomerServiceInfo = await dalHospitalBindCustomerService.GetAll().SingleOrDefaultAsync(e => e.CustomerPhone == phone);
                if (hospitalBindCustomerServiceInfo != null)
                {
                    hospitalBindCustomerServiceInfo.HospitalEmployeeId = updateDto.HospitalEmployeeId;
                    hospitalBindCustomerServiceInfo.UserId = customer?.UserId;
                    hospitalBindCustomerServiceInfo.CreateDate = date;
                    hospitalBindCustomerServiceInfo.CreateBy = employeeId;
                    await dalHospitalBindCustomerService.UpdateAsync(hospitalBindCustomerServiceInfo, true);
                }
                else
                {
                    HospitalBindCustomerService hospitalBindCustomerService = new HospitalBindCustomerService();
                    hospitalBindCustomerService.HospitalEmployeeId = updateDto.HospitalEmployeeId;
                    hospitalBindCustomerService.CustomerPhone = phone;
                    hospitalBindCustomerService.UserId = customer?.UserId;
                    hospitalBindCustomerService.CreateBy = employeeId;
                    hospitalBindCustomerService.CreateDate = date;
                    await dalHospitalBindCustomerService.AddAsync(hospitalBindCustomerService, true);
                }

            }

        }
    }
}
