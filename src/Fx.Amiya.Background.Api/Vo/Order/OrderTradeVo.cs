using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class OrderTradeVo
    {
        public string TradeId { get; set; }
        public string CustomerId { get; set; }

        /// <summary>
        /// 下单人电话
        /// </summary>
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public decimal? TotalAmount { get; set; }
        public decimal? TotalIntegration { get; set; }
        public string Remark { get; set; }
        public string StatusCode { get; set; }
        public string StatusText { get; set; }

        public int? AddressId { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string ReceiveName { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string ReceivePhone { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        public string CourierNumber { get; set; }
        /// <summary>
        /// 物流公司id
        /// </summary>
        public string ExpressId { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        public string ExpressName { get; set; }

        public int? SendGoodsBy { get; set; }
        public string SendGoodsName { get; set; }
        public DateTime? SendGoodsDate { get; set; }
    }
}
