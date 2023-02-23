using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TmallOrder
{
    public class MiniprogramOrderExportDto
    {
        public string TradeId { get; set; }
        public string CustomerId { get; set; }

        /// <summary>
        /// 下单人电话
        /// </summary>
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
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
        /// 绑定订单号
        /// </summary>
        public string OrderIds { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantities { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        public decimal ActualPay { get; set; }

        /// <summary>
        /// 实付积分
        /// </summary>
        public decimal IntergrationAccounts { get; set; }

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
        /// <summary>
        /// 商品类别
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string ExchangeType { get; set; }
    }
}
