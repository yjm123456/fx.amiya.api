using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.OrderRefund;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class OrderRefundService : IOrderRefundService
    {
        private IDalOrderRefund dalOrderRefund;
        private IOrderService orderService;
        private IDalOrderTrade dalOrderTrade;
        private IDalOrderInfo dalOrderInfo;

        public OrderRefundService(IDalOrderRefund dalOrderRefund, IOrderService orderService, IDalOrderTrade dalOrderTrade, IDalOrderInfo dalOrderInfo)
        {
            this.dalOrderRefund = dalOrderRefund;
            this.orderService = orderService;
            this.dalOrderTrade = dalOrderTrade;
            this.dalOrderInfo = dalOrderInfo;
        }

        public async Task<CreateRefundOrderResult> CreateRefundOrderAsync(CreateRefundOrderDto createRefundOrderDto)
        {
            OrderRefund orderRefund = new OrderRefund();
            var refundOrder = dalOrderRefund.GetAll().Where(e=>e.TradeId==createRefundOrderDto.TradeId&&(createRefundOrderDto.OrderId==null||e.OrderId==createRefundOrderDto.OrderId)).FirstOrDefault();
            if (refundOrder!=null) {
                throw new Exception("请勿重复提交");
            }

            var trade = dalOrderTrade.GetAll().Where(e => e.TradeId == createRefundOrderDto.TradeId).Include(e=>e.OrderInfoList).SingleOrDefault();
            if (trade==null) {
                throw new Exception("交易编号不存在");
            }
            if (!(trade.StatusCode == OrderStatusCode.TRADE_BUYER_PAID || trade.StatusCode == OrderStatusCode.TRADE_BUYER_SIGNED || trade.StatusCode == OrderStatusCode.TRADE_FINISHED || trade.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS || trade.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS||trade.StatusCode==OrderStatusCode.PARTIAL_REFUND)) {
                throw new Exception("当前订单状态不能退款");
            }
            foreach (var item in trade.OrderInfoList)
            {
                if (item.AppType!=(byte)AppType.MiniProgram) {
                    throw new Exception("当前订单不属于小程序");
                }
            }
            if (!string.IsNullOrEmpty(createRefundOrderDto.OrderId))
            {
                var order = await dalOrderInfo.GetAll().Where(e => e.Id == createRefundOrderDto.OrderId && e.TradeId == createRefundOrderDto.TradeId).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("订单编号不存在");
                }
                if (!(order.StatusCode == OrderStatusCode.TRADE_BUYER_PAID || order.StatusCode == OrderStatusCode.TRADE_BUYER_SIGNED || order.StatusCode == OrderStatusCode.TRADE_FINISHED || order.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS || order.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS || order.StatusCode == OrderStatusCode.PARTIAL_REFUND))
                {
                    throw new Exception("当前订单状态不能退款");
                }               
            }
            else {
                orderRefund.CheckState = (byte)CheckState.CheckPending;
                orderRefund.IsPartial = false;
                orderRefund.ActualPayAmount = trade.TotalAmount.Value;
                orderRefund.RefundAmount = trade.TotalAmount.Value;
                orderRefund.PayDate = trade.CreateDate;
                orderRefund.ExchangeType = (trade.OrderInfoList.FirstOrDefault()?.ExchangeType).Value;
                trade.StatusCode = OrderStatusCode.REFUNDING;
                await dalOrderTrade.UpdateAsync(trade,true);                              
                foreach (var item in trade.OrderInfoList)
                {                    
                    await orderService.UpdateOrderStatus(item.Id, OrderStatusCode.REFUNDING);
                }                
            }

            orderRefund.Id = Guid.NewGuid().ToString();
            orderRefund.CustomerId = createRefundOrderDto.CustomerId;
            orderRefund.OrderId = createRefundOrderDto.OrderId;
            orderRefund.TradeId = createRefundOrderDto.TradeId;
            orderRefund.Remark = createRefundOrderDto.Remark;           
            orderRefund.CreateDate = DateTime.Now;
            orderRefund.RefundState = (byte)RefundState.RefundPending;
            orderRefund.Valid = true;
            await dalOrderRefund.AddAsync(orderRefund,true);

            return new CreateRefundOrderResult { Result=true,Msg="提交成功"};
            
        }
        /// <summary>
        /// 退款回调后更新退款订单状态
        /// </summary>
        /// <param name="refundAfterUpdateDto"></param>
        /// <returns></returns>
        public async Task UpdateAfterRefundStateAsync(RefundAfterUpdateDto refundAfterUpdateDto)
        {
            var refundOrder = await dalOrderRefund.GetAll().Where(e => e.Id == refundAfterUpdateDto.Id).SingleOrDefaultAsync();
            refundOrder.RefundState = refundAfterUpdateDto.RefundState;
            refundOrder.RefundTradeNo =refundAfterUpdateDto.RefundTradeNo;
            refundOrder.RefundFailReason = refundAfterUpdateDto.RefundFailReason;
            refundOrder.RefundResultDate = refundAfterUpdateDto.RefundResultDate;
            refundOrder.UpdateDate = DateTime.Now;
            await dalOrderRefund.UpdateAsync(refundOrder, true);
        }

        /// <summary>
        /// 退款发起更新订单退款状态
        /// </summary>
        /// <param name="refundUpdateDto"></param>
        /// <returns></returns>
        public async Task UpdateStartRefundStateAsync(RefundStartUpdateDto refundUpdateDto)
        {
            var refundOrder =await dalOrderRefund.GetAll().Where(e=>e.Id==refundUpdateDto.Id).SingleOrDefaultAsync();
            refundOrder.RefundState = refundUpdateDto.RefundState;
            refundOrder.UpdateDate = DateTime.Now;
            await dalOrderRefund.UpdateAsync(refundOrder,true);
        }
    }
}
