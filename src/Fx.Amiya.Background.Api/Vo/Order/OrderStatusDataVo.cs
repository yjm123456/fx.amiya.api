using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class OrderStatusDataVo
    {
        /// <summary>
        /// 订单状态文本
        /// </summary>
        public string StatusText { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int Quantity { get; set; }
    }
}
