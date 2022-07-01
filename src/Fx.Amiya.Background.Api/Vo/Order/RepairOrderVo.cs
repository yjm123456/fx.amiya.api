using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    /// <summary>
    /// 补单基础类
    /// </summary>
    public class RepairOrderVo
    {
        /// <summary>
        /// 下单平台
        /// </summary>
        public byte OrderAppType { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
    }
}
