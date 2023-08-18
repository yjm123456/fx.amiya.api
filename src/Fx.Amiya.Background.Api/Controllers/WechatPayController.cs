using Fx.Amiya.Dto.OrderRefund;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
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
    [FxInternalAuthorize]
    public class WechatPayController : ControllerBase
    {
        private readonly IWxPayService wxPayService;
        private readonly IOrderRefundService orderRefundService;
        private readonly IOrderService orderService;
        private readonly IUnitOfWork unitOfWork;

        public WechatPayController(IWxPayService wxPayService, IOrderRefundService orderRefundService, IUnitOfWork unitOfWork, IOrderService orderService)
        {
            this.wxPayService = wxPayService;
            this.orderRefundService = orderRefundService;
            this.unitOfWork = unitOfWork;
            this.orderService = orderService;
        }
        /// <summary>
        /// 发起退款
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("wechatRefund/{id}")]
        public async Task<ResultData> WechatRefund(string id)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var result = await wxPayService.WechatRefundAsync(id);
                if (result.Result)
                {
                    //发起请求成功更新退款订单状态
                    RefundStartUpdateDto refundStartUpdateDto = new RefundStartUpdateDto
                    {
                        Id = id,
                        RefundStartDate = DateTime.Now,
                        RefundState = (byte)RefundState.RefundSuccess,
                        RefundFailReason = "",
                        RefundTradeNo = result.TradeNo
                    };
                    //修改退款订单状态
                    await orderRefundService.UpdateStartRefundStateAsync(refundStartUpdateDto);
                    //修改订单状态                   
                    if (!result.IsPartial)
                    {
                        await orderService.UpdateStatusByTradeIdAsync(result.TardeId, OrderStatusCode.TRADE_CLOSED);
                    }
                    else
                    {
                        bool isAllRefund = true;
                        var orderList = await orderService.GetOrderListByTradeIdAsync(result.TardeId);
                        foreach (var item in orderList)
                        {
                            if (item.Id==result.OrderId) {
                                continue;
                            }
                            if (item.StatusCode != OrderStatusCode.TRADE_CLOSED)
                            {
                                isAllRefund = false;
                            }
                        }
                        if (isAllRefund)
                        {
                            await orderService.UpdateStatusByTradeIdAsync(result.TardeId, OrderStatusCode.TRADE_CLOSED);
                        }
                        else {
                            await orderService.UpdateOrderStatus(result.OrderId,OrderStatusCode.TRADE_CLOSED);
                        }
                    }

                    unitOfWork.Commit();
                    return ResultData.Success();
                }
                else
                {
                    RefundStartUpdateDto refundStartUpdateDto = new RefundStartUpdateDto
                    {
                        Id = id,
                        RefundStartDate = DateTime.Now,
                        RefundState = (byte)RefundState.RefundFail,
                        RefundFailReason = result.Msg
                    };
                    await orderRefundService.UpdateStartRefundStateAsync(refundStartUpdateDto);
                    unitOfWork.Commit();
                    return ResultData.Fail(result.Msg);
                }
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception("退款失败请稍后重试");
            }

        }
    }
}
