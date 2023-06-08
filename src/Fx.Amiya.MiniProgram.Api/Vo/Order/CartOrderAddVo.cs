using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    public class CartOrderAddVo
    {
        /// <summary>
        /// 收货地址编号（用于实物商品发货）
        /// </summary>
        public int? AddressId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 抵用券id
        /// </summary>
        public string VoucherId { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public int ExchageType { get; set; }
        public List<OrderItem> OrderItemList { get; set; }
    }
    public class OrderItem
    {
        //商品id
        public string GoodsId { get; set; }
        //购买数量
        public int Quantity { get; set; }
        /// <summary>
        /// 规格id
        /// </summary>
        public string StandardId { get; set; }
    }
}
