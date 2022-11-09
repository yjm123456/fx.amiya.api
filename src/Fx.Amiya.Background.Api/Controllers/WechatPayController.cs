using Fx.Amiya.Dto.OrderRefund;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.DataAccess.EFCore;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 微信退款
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WechatPayController : ControllerBase
    {
        private readonly IWxPayService wxPayService;
        private readonly IOrderRefundService orderRefundService;
        private readonly IUnitOfWork unitOfWork;

        public WechatPayController(IWxPayService wxPayService, IOrderRefundService orderRefundService, IUnitOfWork unitOfWork)
        {
            this.wxPayService = wxPayService;
            this.orderRefundService = orderRefundService;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("wechatRefund")]
        public async Task<ResultData> WechatRefund(string orderId)
        {

            var result = await wxPayService.WechatRefundAsync(orderId);
            if (result == "true")
            {
                //发起请求成功更新退款订单状态
                RefundStartUpdateDto refundStartUpdateDto = new RefundStartUpdateDto
                {
                    Id = orderId,
                    RefundStartDate = DateTime.Now,
                    RefundState = (byte)RefundState.Refunding
                };
                await orderRefundService.UpdateStartRefundStateAsync(refundStartUpdateDto);
                return ResultData.Success();
            }
            else
            {
                return ResultData.Fail("发起退款请求失败");
            }

        }
    }
}
