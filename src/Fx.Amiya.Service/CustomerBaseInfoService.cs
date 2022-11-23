using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Amiya.Dto.WareHouse.InventoryList;
using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.InWareHouse;
using Fx.Amiya.Dto.CustomerBaseInfo;

namespace Fx.Amiya.Service
{
    public class CustomerBaseInfoService : ICustomerBaseInfoService
    {
        private IDalCustomerBaseInfo dalCustomerBaseInfo;
        private IMemberCardHandleService memberCardHandleService;
        private IDalCustomerInfo dalCustomerInfo;
        private IBindCustomerServiceService bindCustomerServiceService;
        private IWxAppConfigService _wxAppConfigService;
        private IUnitOfWork unitOfWork;
        private IUserService userService;
        private IConsumptionLevelService consumptionLevelService;

        public CustomerBaseInfoService(IDalCustomerBaseInfo dalCustomerBaseInfo,
            IDalCustomerInfo dalCustomerInfo,
            IConsumptionLevelService consumptionLevelService,
            IBindCustomerServiceService bindCustomerServiceService,
            IMemberCardHandleService memberCardHandleService,
            IUserService userService,
            IUnitOfWork unitofWork,
            IWxAppConfigService wxAppConfigService)
        {
            this.dalCustomerBaseInfo = dalCustomerBaseInfo;
            this.dalCustomerInfo = dalCustomerInfo;
            this.consumptionLevelService = consumptionLevelService;
            this.bindCustomerServiceService = bindCustomerServiceService;
            this.memberCardHandleService = memberCardHandleService;
            _wxAppConfigService = wxAppConfigService;
            this.unitOfWork = unitofWork;
            this.userService = userService;
        }


        public async Task<CustomerBaseInfoDto> GetByEncryptPhoneAsync(string encryptPhone)
        {
            try
            {
                var config = await _wxAppConfigService.GetWxAppCallCenterConfigAsync();
                string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);
                var customerBaseInfoService = await dalCustomerBaseInfo.GetAll().FirstOrDefaultAsync(e => e.Phone == phone);
                if (customerBaseInfoService == null)
                {
                    return new CustomerBaseInfoDto();
                }

                CustomerBaseInfoDto customerBaseInfoServiceDto = new CustomerBaseInfoDto();
                customerBaseInfoServiceDto.Id = customerBaseInfoService.Id;
                customerBaseInfoServiceDto.Name = customerBaseInfoService.Name;
                var customerInfo = await dalCustomerInfo.GetAll().Where(x => x.Phone == phone).FirstOrDefaultAsync();
                if (customerInfo != null)
                {
                    var memberCardHandle = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerInfo.Id);
                    if (memberCardHandle != null)
                    {
                        customerBaseInfoServiceDto.MemberCardNo = memberCardHandle.MemberCardNum;
                        customerBaseInfoServiceDto.MemberRankName = memberCardHandle.MemberRankName;
                    }
                    var userInfo = await userService.GetUserInfoByUserIdAsync(customerInfo.UserId);
                    if (userInfo != null)
                    {
                        customerBaseInfoServiceDto.Avatar = userInfo.Avatar;
                    }
                }
                customerBaseInfoServiceDto.PersonalWechat = customerBaseInfoService.PersonalWechat;
                customerBaseInfoServiceDto.BusinessWeChat = customerBaseInfoService.BusinessWeChat;
                customerBaseInfoServiceDto.WechatMiniProgram = customerBaseInfoService.WechatMiniProgram;
                customerBaseInfoServiceDto.OfficialAccounts = customerBaseInfoService.OfficialAccounts;
                var bindCustomerService = await bindCustomerServiceService.GetEmployeeDetailsByPhoneAsync(phone);
                customerBaseInfoServiceDto.BelongCustomerService = bindCustomerService.CustomerServiceName;
                customerBaseInfoServiceDto.FirstProjectDemand = bindCustomerService.FirstProjectDemand;
                customerBaseInfoServiceDto.NewContentPlatform = bindCustomerService.NewContentPlatForm;
                customerBaseInfoServiceDto.BindCustomerServiceId = bindCustomerService.Id;
                
                customerBaseInfoServiceDto.CreateDate = bindCustomerService.CreateDate;
                customerBaseInfoServiceDto.AllPrice = bindCustomerService.AllPrice;
                customerBaseInfoServiceDto.Age = ServiceClass.GetAge(customerBaseInfoService.Birthday);
                customerBaseInfoServiceDto.RealName = customerBaseInfoService.RealName;
                customerBaseInfoServiceDto.Sex = customerBaseInfoService.Sex;
                customerBaseInfoServiceDto.Birthday = customerBaseInfoService.Birthday;
                customerBaseInfoServiceDto.City = customerBaseInfoService.City;
                customerBaseInfoServiceDto.Occupation = customerBaseInfoService.Occupation;
                customerBaseInfoServiceDto.Phone = customerBaseInfoService.Phone;
                customerBaseInfoServiceDto.OtherPhone = customerBaseInfoService.OtherPhone;
                customerBaseInfoServiceDto.DetailAddress = customerBaseInfoService.DetailAddress;
                customerBaseInfoServiceDto.IsCall = customerBaseInfoService.IsCall;
                customerBaseInfoServiceDto.IsSendNote = customerBaseInfoService.IsSendNote;
                customerBaseInfoServiceDto.IsSendWeChat = customerBaseInfoService.IsSendWeChat;
                customerBaseInfoServiceDto.UnTrackReason = customerBaseInfoService.UnTrackReason;
                customerBaseInfoServiceDto.CustomerState = customerBaseInfoService.CustomerState;
                customerBaseInfoServiceDto.CustomerRequirement = customerBaseInfoService.CustomerRequirement;
                customerBaseInfoServiceDto.WechatNumber = customerBaseInfoService.WechatNumber;
                customerBaseInfoServiceDto.Remark = customerBaseInfoService.Remark;
                customerBaseInfoServiceDto.NewConsumptionContentPlatform = bindCustomerService.NewConsumptionContentPlatform;
                var consumptionLevelInfo = await consumptionLevelService.GetListWithPageAsync(null, 1, 9999);
                foreach (var consumptionInfo in consumptionLevelInfo.List)
                {
                    if (bindCustomerService.AllPrice >= consumptionInfo.MinPrice && bindCustomerService.AllPrice <= consumptionInfo.MaxPrice)
                    {

                        customerBaseInfoServiceDto.ConsumptionLevel = consumptionInfo.Name;
                    }
                }
                return customerBaseInfoServiceDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task UpdateAsync(UpdateCustomerBaseInfoDto updateDto)
        {
            try
            {
                var customerBaseInfoService = await dalCustomerBaseInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (customerBaseInfoService == null)
                    throw new Exception("客户基础信息编号错误！");
                customerBaseInfoService.PersonalWechat = updateDto.PersonalWechat;
                customerBaseInfoService.BusinessWeChat = updateDto.BusinessWeChat;
                customerBaseInfoService.WechatMiniProgram = updateDto.WechatMiniProgram;
                customerBaseInfoService.OfficialAccounts = updateDto.OfficialAccounts;
                customerBaseInfoService.RealName = updateDto.RealName;
                customerBaseInfoService.WechatNumber = updateDto.WechatNumber;
                customerBaseInfoService.Sex = updateDto.Sex;
                customerBaseInfoService.Birthday = updateDto.Birthday;
                customerBaseInfoService.City = updateDto.City;
                customerBaseInfoService.Occupation = updateDto.Occupation;
                customerBaseInfoService.OtherPhone = updateDto.OtherPhone;
                customerBaseInfoService.DetailAddress = updateDto.DetailAddress;
                customerBaseInfoService.IsSendNote = updateDto.IsSendNote;
                customerBaseInfoService.IsCall = updateDto.IsCall;
                customerBaseInfoService.IsSendWeChat = updateDto.IsSendWeChat;
                customerBaseInfoService.UnTrackReason = updateDto.UnTrackReason;
                customerBaseInfoService.Remark = updateDto.Remark;
                await dalCustomerBaseInfo.UpdateAsync(customerBaseInfoService, true);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
