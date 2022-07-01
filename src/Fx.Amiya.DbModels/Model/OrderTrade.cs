using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class OrderTrade
    {
        public string TradeId { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? AddressId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalIntegration { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 是否管理员录单
        /// </summary>
        public bool IsAdminAdd { get; set; } = false;
        public string StatusCode { get; set; }
        public DateTime? UpdateDate { get; set; }

        public CustomerInfo CustomerInfo { get; set; }
        public Address Address { get; set; }
        public List<OrderInfo> OrderInfoList { get; set; }
        public SendGoodsRecord SendGoodsRecord { get; set; }
    }
}
