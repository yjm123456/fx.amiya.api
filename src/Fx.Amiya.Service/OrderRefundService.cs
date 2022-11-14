using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.CustomerHospitalConsume;
using Fx.Amiya.Dto.OrderRefund;
using Fx.Amiya.Dto.TmallOrder;
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
    public class OrderRefundService : IOrderRefundService
    {
        private IDalOrderRefund dalOrderRefund;
        private IOrderService orderService;
        private IDalOrderTrade dalOrderTrade;
        private IDalOrderInfo dalOrderInfo;
        private IDalAmiyaEmployee dalAmiyaEmployee;

        public OrderRefundService(IDalOrderRefund dalOrderRefund, IOrderService orderService, IDalOrderTrade dalOrderTrade, IDalOrderInfo dalOrderInfo, IDalAmiyaEmployee dalAmiyaEmployee)
        {
            this.dalOrderRefund = dalOrderRefund;
            this.orderService = orderService;
            this.dalOrderTrade = dalOrderTrade;
            this.dalOrderInfo = dalOrderInfo;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
        }
        /// <summary>
        /// 退款订单审核
        /// </summary>
        /// <param name="orderRefundCheckDto"></param>
        /// <returns></returns>
        public async Task CheckAsync(OrderRefundCheckDto orderRefundCheckDto)
        {
            var refundOrder = await dalOrderRefund.GetAll().Where(e=>e.Id==orderRefundCheckDto.Id).SingleOrDefaultAsync();
            if (refundOrder == null) throw new Exception("退款订单编号错误");
            refundOrder.UncheckReason = orderRefundCheckDto.UnCheckReason;
            refundOrder.CheckBy = orderRefundCheckDto.CheckBy;
            refundOrder.CheckState = orderRefundCheckDto.CheckState;
            refundOrder.CheckDate = DateTime.Now;
            refundOrder.UpdateDate = DateTime.Now;
            await dalOrderRefund.UpdateAsync(refundOrder,true);
            if (orderRefundCheckDto.CheckState==(int)CheckState.CheckFail) {                
                await orderService.UpdateStatusByTradeIdAsync(refundOrder.TradeId, OrderStatusCode.CHECK_FAIL);
            }
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
            
            List<string> ids = new List<string>();
            foreach (var item in trade.OrderInfoList)
            {
                if (item.AppType != (byte)AppType.MiniProgram)
                {
                    throw new Exception("当前订单不属于小程序");
                }
                else {
                    ids.Add(item.Id);
                }
            }
            if (!string.IsNullOrEmpty(createRefundOrderDto.OrderId))
            {
                throw new Exception("暂不支持部分退款");
                /*var order = await dalOrderInfo.GetAll().Where(e => e.Id == createRefundOrderDto.OrderId && e.TradeId == createRefundOrderDto.TradeId).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("订单编号不存在");
                }
                if (!(order.StatusCode == OrderStatusCode.TRADE_BUYER_PAID || order.StatusCode == OrderStatusCode.TRADE_BUYER_SIGNED || order.StatusCode == OrderStatusCode.TRADE_FINISHED || order.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS || order.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS || order.StatusCode == OrderStatusCode.PARTIAL_REFUND))
                {
                    throw new Exception("当前订单状态不能退款");
                }   */
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
                string goodsName = string.Empty;
                var nameList = new List<string>();
                foreach (var item in trade.OrderInfoList)
                {
                    nameList.Add(item.GoodsName);
                    await orderService.UpdateOrderStatus(item.Id, OrderStatusCode.REFUNDING);
                }
                orderRefund.GoodsName = string.Join(",",nameList);
            }
            orderRefund.Id = Guid.NewGuid().ToString().Replace("-",""); ;
            orderRefund.CustomerId = createRefundOrderDto.CustomerId;
            orderRefund.OrderId = string.Join(",",ids);
            orderRefund.TradeId = createRefundOrderDto.TradeId;
            orderRefund.Remark = createRefundOrderDto.Remark;           
            orderRefund.CreateDate = DateTime.Now;
            orderRefund.RefundState = (byte)RefundState.RefundPending;
            orderRefund.Valid = true;
            await dalOrderRefund.AddAsync(orderRefund,true);
            return new CreateRefundOrderResult { Result=true,Msg="提交成功"};           
        }
        /// <summary>
        /// 获取退款订单列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="checkState"></param>
        /// <param name="refundState"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderRefundDto>> GetListAsync(string keywords, byte? checkState, byte? refundState,int pageNum,int pageSize)
        {
            
            var refundOrder = dalOrderRefund.GetAll().Where(e =>(string.IsNullOrEmpty(keywords)||e.OrderId.Contains(keywords))&& (checkState == null || e.CheckState == checkState) && (refundState == null || e.RefundState == refundState)).OrderByDescending(e => e.CreateDate).Select(e => new OrderRefundDto
            {
                Id=e.Id,
                OrderId=e.OrderId,
                TradeId = e.TradeId,
                Remark = e.Remark,
                GoodsName=e.GoodsName,
                CheckState = e.CheckState,
                CheckDate=e.CheckDate,
                CheckStateText = ServiceClass.GetOrderRefundCheckTypeText(e.CheckState),
                UncheckReason = e.UncheckReason,
                RefundState = e.RefundState,
                RefundStateText = ServiceClass.GetRefundStateText(e.RefundState),
                RefundStartDate=e.RefundStartDate,
                RefundFailReason = e.RefundFailReason,
                IsPartial = e.IsPartial,
                ExchangeType = e.ExchangeType,
                ExchageTypeText = ServiceClass.GetExchangeTypeText((byte)e.ExchangeType),
                RefundAmount = e.RefundAmount,
                ActualPayAmount = e.ActualPayAmount,
                PayDate = e.PayDate,
                CheckBy = e.CheckBy,
                CreateDate=e.CreateDate,
                UpdateDate=e.UpdateDate
            }); ; ;
            FxPageInfo<OrderRefundDto> fxPageInfo = new FxPageInfo<OrderRefundDto>();
            fxPageInfo.TotalCount =await refundOrder.CountAsync();
            fxPageInfo.List = refundOrder.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            foreach (var x in fxPageInfo.List)
            {
                if (x.CheckBy != 0)
                {
                    var employeeInfo =await dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.CheckBy);
                    if (employeeInfo != null)
                    {
                        x.CheckByName = employeeInfo.Name;
                    }
                    else
                    {
                        x.CheckByName = "";
                    }
                }
            }
            return fxPageInfo;
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
            refundOrder.RefundStartDate = refundUpdateDto.RefundStartDate;
            refundOrder.RefundState = refundUpdateDto.RefundState;
            refundOrder.UpdateDate = DateTime.Now;
            refundOrder.RefundFailReason = refundUpdateDto.RefundFailReason;
            refundOrder.RefundTradeNo = refundUpdateDto.RefundTradeNo;
            await dalOrderRefund.UpdateAsync(refundOrder,true);
        }
        /// <summary>
        /// 获取审核状态列表
        /// </summary>
        /// <returns></returns>
        public List<CheckStateTypeDto> GetCheckStateType()
        {
            var checkStateTypes = Enum.GetValues(typeof(CheckState));
            List<CheckStateTypeDto> orderAppTypeList = new List<CheckStateTypeDto>();
            foreach (var item in checkStateTypes)
            {
                CheckStateTypeDto orderAppType = new CheckStateTypeDto();
                orderAppType.Id = Convert.ToByte(item);
                orderAppType.Name = ServiceClass.GetOrderRefundCheckTypeText(Convert.ToByte(item));
                orderAppTypeList.Add(orderAppType);
            }
            return orderAppTypeList;
        }
        /// <summary>
        /// 获取退款状态列表
        /// </summary>
        /// <returns></returns>
        public List<CheckStateTypeDto> GetRefundStateType()
        {
            var checkStateTypes = Enum.GetValues(typeof(RefundState));
            List<CheckStateTypeDto> orderAppTypeList = new List<CheckStateTypeDto>();
            foreach (var item in checkStateTypes)
            {
                CheckStateTypeDto orderAppType = new CheckStateTypeDto();
                orderAppType.Id = Convert.ToByte(item);
                orderAppType.Name = ServiceClass.GetRefundStateText(Convert.ToByte(item));
                orderAppTypeList.Add(orderAppType);
            }
            return orderAppTypeList;
        }

        public async Task<OrderRefundDto> GetOrderRefundByOrderId(string orderId)
        {
            var refundOrder =await dalOrderRefund.GetAll().Where(e =>  e.OrderId.Contains(orderId)).Select(e => new OrderRefundDto
            {
                Id = e.Id,
                TradeId = e.TradeId,
                Remark = e.Remark,
                GoodsName = e.GoodsName,
                CheckState = e.CheckState,
                CheckDate = e.CheckDate,
                CheckStateText = ServiceClass.GetOrderRefundCheckTypeText(e.CheckState),
                UncheckReason = e.UncheckReason,
                RefundState = e.RefundState,
                RefundStateText = ServiceClass.GetRefundStateText(e.RefundState),
                RefundStartDate = e.RefundStartDate,
                RefundFailReason = e.RefundFailReason,
                IsPartial = e.IsPartial,
                ExchangeType = e.ExchangeType,
                ExchageTypeText = ServiceClass.GetExchangeTypeText((byte)e.ExchangeType),
                RefundAmount = e.RefundAmount,
                ActualPayAmount = e.ActualPayAmount,
                PayDate = e.PayDate,
                CheckBy = e.CheckBy,
                CreateDate = e.CreateDate,
                UpdateDate = e.UpdateDate
            }).FirstOrDefaultAsync();
            if (refundOrder == null) {
                return new OrderRefundDto();
            }
            else {
                return refundOrder;
            }
        }
    }
}
