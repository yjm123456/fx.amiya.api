using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    public class OrderTradeVo
    {
        public string TradeId { get; set; }
        public string CustomerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? AddressId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalIntegration { get; set; }
        public string Remark { get; set; }
        public string StatusCode { get; set; }
        public string StatusText { get; set; }

        public List<OrderInfoVo> OrderInfoList { get; set; }
        /// <summary>
        /// 子订单是否包含退款订单
        /// </summary>
        public bool HasRefundOrder
        {
            get
            {
                return OrderInfoList.Any(e => e.StatusCode == OrderStatusCode.REFUNDING || e.StatusCode == OrderStatusCode.TRADE_CLOSED);
            }
        }
        /// <summary>
        /// 是否包含多个子订单
        /// </summary>
        public bool IsMultiOrder
        {
            get
            {
                return OrderInfoList.Count() > 1;
            }
        }
    }
}
