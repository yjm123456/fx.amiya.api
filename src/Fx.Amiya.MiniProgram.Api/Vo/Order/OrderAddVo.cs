using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    public class OrderAddVo
    {

        /// <summary>
        /// 收货地址编号（用于实物商品发货）
        /// </summary>
        public int? AddressId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public List<OrderItemVo> OrderItemList { get; set; }


    }
}
