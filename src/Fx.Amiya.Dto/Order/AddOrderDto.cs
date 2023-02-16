using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Order
{
    /// <summary>
    /// 商城订单添加类
    /// </summary>
    public class AddOrderDto
    {
        /// <summary>
        /// 使用的抵用券
        /// </summary>
        public string VoucerId { get; set; }
        /// <summary>
        /// 商品集合
        /// </summary>
        public List<AddOrderItemDto> OrderItems { get; set; }
    }
    public class AddOrderItemDto {
        public string GoodsId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Quantity { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }
    }
}
