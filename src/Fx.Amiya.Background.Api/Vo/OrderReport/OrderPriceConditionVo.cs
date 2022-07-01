using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 订单业绩情况
    /// </summary>
    public class OrderPriceConditionVo
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 订单业绩
        /// </summary>
        public decimal OrderPrice { get; set; }
    }
}
