using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Order
{
    public class CartOrderAddDto
    {
        public string CustomerId { get; set; }
        /// <summary>
        /// 微信小程序openid
        /// </summary>
        public string OpenId { get; set; }
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
        /// 支付方式
        /// </summary>
        public int ExchageType { get; set; }
        /// <summary>
        /// 用户下达时使用的小程序appid
        /// </summary>
        public string AppId { get; set; }
        public List<OrderItem> OrderItemList { get; set; }
    }
    public class OrderItem {
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
