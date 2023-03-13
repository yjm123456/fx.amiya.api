using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Order
{
    public class AddIntegralVirtualTradeDto
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        public AddIntegralVirtualOrderDto OrderInfo { get; set; }
    }
}
