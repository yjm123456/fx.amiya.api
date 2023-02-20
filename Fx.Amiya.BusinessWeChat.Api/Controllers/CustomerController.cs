using Fx.Amiya.BusinessWechat.Api.Vo.Login;
using Fx.Amiya.Common;
using Fx.Amiya.IService;
using Fx.Authentication.Jwt;
using Fx.Identity.Core;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fx.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Authorization.Attributes;
using Fx.Amiya.BusinessWeChat.Api.Vo.CustomerInfo;
using Fx.Amiya.BusinessWeChat.Api.Vo.Base;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CustomerController : ControllerBase
    {
        private ICustomerBaseInfoService customerBaseInfoService;
        public CustomerController(ICustomerBaseInfoService customerBaseInfoService)
        {
            this.customerBaseInfoService = customerBaseInfoService;
        }


        /// <summary>
        /// 根据加密电话查询客户资料
        /// </summary>
        /// <param name="encryptPhone">加密电话</param>
        /// <returns></returns>
        [HttpGet("getBaseAndBindCustomerInfoByEncryptPhone")]
        public async Task<ResultData<CustomerBaseDetailInfoVo>> GetBaseAndBindCustomerInfoByPhoneAsync(string encryptPhone)
        {
            var customer = await customerBaseInfoService.GetByEncryptPhoneAsync(encryptPhone);
            CustomerBaseDetailInfoVo customerSimpleInfoVo = new CustomerBaseDetailInfoVo();
            customerSimpleInfoVo.Id = customer.Id;
            customerSimpleInfoVo.BindCustomerServiceId = customer.BindCustomerServiceId;
            customerSimpleInfoVo.Avatar = customer.Avatar;
            customerSimpleInfoVo.Name = customer.Name;
            customerSimpleInfoVo.MemberCardNo = customer.MemberCardNo;
            customerSimpleInfoVo.MemberRankName = customer.MemberRankName;
            customerSimpleInfoVo.CreateDate = customer.CreateDate;
            customerSimpleInfoVo.AllPrice = customer.AllPrice;
            customerSimpleInfoVo.RealName = customer.RealName;
            customerSimpleInfoVo.Sex = customer.Sex;
            customerSimpleInfoVo.Phone = customer.Phone;
            customerSimpleInfoVo.Birthday = customer.Birthday;
            customerSimpleInfoVo.Age = customer.Age;
            customerSimpleInfoVo.Occupation = customer.Occupation;
            customerSimpleInfoVo.FirstProjectDemand = customer.FirstProjectDemand;
            customerSimpleInfoVo.NewConsumptionContentPlatform = customer.NewConsumptionContentPlatform;
            customerSimpleInfoVo.PersonalWechat = customer.PersonalWechat;
            customerSimpleInfoVo.BusinessWeChat = customer.BusinessWeChat;
            customerSimpleInfoVo.WechatMiniProgram = customer.WechatMiniProgram;
            customerSimpleInfoVo.OfficialAccounts = customer.OfficialAccounts;
            customerSimpleInfoVo.BelongCustomerService = customer.BelongCustomerService;
            customerSimpleInfoVo.NewContentPlatForm = customer.NewContentPlatform;
            customerSimpleInfoVo.OtherPhone = customer.OtherPhone;
            customerSimpleInfoVo.DetailAddress = customer.DetailAddress;
            customerSimpleInfoVo.IsSendNote = customer.IsSendNote;
            customerSimpleInfoVo.IsCall = customer.IsCall;
            customerSimpleInfoVo.IsSendWeChat = customer.IsSendWeChat;
            customerSimpleInfoVo.UnTrackReason = customer.UnTrackReason;
            customerSimpleInfoVo.ConsumptionLevel = customer.ConsumptionLevel;
            customerSimpleInfoVo.CustomerState = customer.CustomerState;
            customerSimpleInfoVo.CustomerRequirement = customer.CustomerRequirement;
            customerSimpleInfoVo.WechatNumber = customer.WechatNumber;
            customerSimpleInfoVo.City = customer.City;
            customerSimpleInfoVo.Remark = customer.Remark;
            customerSimpleInfoVo.TagList = customer.TagList.Select(e => new BaseKeyAndValueVo { Id = e.Id, Name = e.Name }).ToList();
            return ResultData<CustomerBaseDetailInfoVo>.Success().AddData("customer", customerSimpleInfoVo);
        }
    }
}
