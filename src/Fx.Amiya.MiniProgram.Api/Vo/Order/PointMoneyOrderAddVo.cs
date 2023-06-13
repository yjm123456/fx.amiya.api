using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    public class PointMoneyOrderAddVo
    {
        /// <summary>
        /// 收货地址
        /// </summary>
        public int? AddressId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 使用的抵用券id
        /// </summary>
        public string VoucherId { get; set; }
        
        /// <summary>
        /// 商品详情
        /// </summary>
        public List<PointMoneyOrderItem> OrderItemList { get; set; }
    }
    public class PointMoneyOrderItem
    {
        public string GoodsId { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }

    }
}
