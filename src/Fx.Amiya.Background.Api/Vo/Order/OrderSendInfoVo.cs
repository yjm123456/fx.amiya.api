using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class OrderSendInfoVo
    {
        /// <summary>
        /// 快递公司id
        /// </summary>
        public string ExpressId { get; set; }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string CourierNumber { get; set; }
    }
}
