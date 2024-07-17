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
using Fx.Amiya.BusinessWeChat.Api.Vo;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 小黄车登记列表接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ShoppingCartRegistrationController : ControllerBase
    {

        private IShoppingCartRegistrationService shoppingCartRegistrationService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="shoppingCartRegistrationService"></param>
        public ShoppingCartRegistrationController(IShoppingCartRegistrationService shoppingCartRegistrationService)
        {
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
        }

        /// <summary>
        /// 客户来源列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("customerSourceList")]
        public async Task<ResultData<List<BaseKeyAndValueVo<int>>>> GetCustomerSourceListAsync(string contentPlatFormId, int? channel)
        {
            var nameList = shoppingCartRegistrationService.GetCustomerSourceList(contentPlatFormId, channel);
            var result = nameList.Select(e => new BaseKeyAndValueVo<int>
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseKeyAndValueVo<int>>>.Success().AddData("sourceList", result);

        }
        /// <summary>
        /// 客户类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("customerTypeList")]
        public async Task<ResultData<List<BaseKeyAndValueVo<int>>>> GetCustomerTypeListAsync()
        {
            var nameList = shoppingCartRegistrationService.GetCustomerTypeList();
            var result = nameList.Select(e => new BaseKeyAndValueVo<int>
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseKeyAndValueVo<int>>>.Success().AddData("sourceList", result);

        }
        /// <summary>
        /// 获取归属部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("shoppingCartGetBelongChannelList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetBelongChannelListAsync()
        {
            var nameList = shoppingCartRegistrationService.GetBelongDepartmentList();
            var result = nameList.Select(e => new BaseIdAndNameVo<int>
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("belongChannelList", result);
        }

    }
}
