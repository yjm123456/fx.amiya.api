using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderCheck
{
    /// <summary>
    /// 订单回款
    /// </summary>
    public class ReturnBackOrderVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        public decimal ReturnBackPrice { get; set; }

        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime ReturnBackDate { get; set; }

    }
}
