using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
    public class OrderTradeDto
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
        /// 绑定订单号集合数据
        /// </summary>
        public List<string> OrderIdsList { get; set; }

        /// <summary>
        /// 绑定订单号
        /// </summary>
        public string OrderIds { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantities { get; set; } 

        /// <summary>
        /// 实付积分
        /// </summary>
        public decimal IntergrationAccounts { get; set; }


        /// <summary>
        /// 绑定商品集合数据
        /// </summary>
        public List<string> GoodsList { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        public string GoodsName { get; set; }

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
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }
    }
}
