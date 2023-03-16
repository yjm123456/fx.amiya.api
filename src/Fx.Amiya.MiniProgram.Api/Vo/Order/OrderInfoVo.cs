using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    public class OrderInfoVo
    {
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        /// <summary>
        /// 下单医院
        /// </summary>
        public string AppointmentHospital { get; set; }
        public string ThumbPicUrl { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? SinglePrice { get; set; }
        public byte? OrderType { get; set; }
        public string OrderTypeText { get; set; }
        public int? Quantity { get; set; }
        /// <summary>
        /// 积分总价
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }

        /// <summary>
        /// 积分单价
        /// </summary>
        public decimal? SingleIntegrationQuantity { get; set; }
        public byte? ExchangeType { get; set; }
        public string ExchangeTypeText { get; set; }
        public string TradeId { get; set; }

        public string Standard { get; set; }
        public byte AppType { get; set; }
        public string AppTypeText { get; set; }
        public string StatusCode { get; set; }
        public string StatusCodeText { get; set; }
        /// <summary>
        /// 是否使用抵用券
        /// </summary>
        public bool IsUseCoupon { get; set; }
        /// <summary>
        /// 抵用券抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
    }
}
