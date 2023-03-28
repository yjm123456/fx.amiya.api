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
using Fx.Amiya.BusinessWeChat.Api.Vo.BindCustomerService;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 绑定客服板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class BindCustomerServiceController : ControllerBase
    {
        private IBindCustomerServiceService bindCustomerService;
        private IHttpContextAccessor httpContextAccessor;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bindCustomerService"></param>
        /// <param name="httpContextAccessor"></param>
        public BindCustomerServiceController(IBindCustomerServiceService bindCustomerService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.bindCustomerService = bindCustomerService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 根据手机号筛选归属客服
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>查找成功返回名称，查找失败返回“未绑定”</returns>
        [HttpGet("getCustomerServiceNameByPhone")]

        public async Task<ResultData<string>> GetBindCustomerNameByPhoneAsync(string phone)
        {
            var result = await bindCustomerService.GetBindCustomerServiceNameByPhone(phone);
            return ResultData<string>.Success().AddData("CustomerServiceNameByPhone", result);
        }

        /// <summary>
        /// 获取我的客户（放在前端缓存中）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getMyCustomer")]
        public async Task<ResultData<MyCustomerInfoVo>> GetMyCustomerAsync()
        {

            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var customer = await bindCustomerService.GetCustomerCountByEmployeeIdAsync(employeeId);
            MyCustomerInfoVo myCustomerInfoVo = new MyCustomerInfoVo();
            myCustomerInfoVo.MyCustomerCount = customer.MyCustomerCount;
            myCustomerInfoVo.SevenDaysInsertCount = customer.SevenDaysInsertCount;
            myCustomerInfoVo.TodayInsertCount = customer.TodayInsertCount;
            return ResultData<MyCustomerInfoVo>.Success().AddData("myCustomer", myCustomerInfoVo);
        }


    }
}
