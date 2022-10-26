using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
   public class OrderInfoUpdateDto
    {
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string Phone { get; set; }
        public string AppointmentCity { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentHospital { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// 价格（商品正常价格）
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 应收款（优惠后实际价格，财务用）
        /// </summary>
        public decimal? AccountReceivable { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ThumbPicUrl { get; set; }
        public string BuyerNick { get; set; }
        public byte AppType { get; set; }
        public bool IsAppointment { get; set; }
        public byte OrderType { get; set; }
        public byte? OrderNature{ get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// 抵扣积分
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }

        /// <summary>
        /// 部位
        /// </summary>
        public string Part { get; set; }

        /// <summary>
        /// 交易类型：0=积分
        /// </summary>
        public byte? ExchangeType { get; set; }

        public string TradeId { get; set; }

    }
}
