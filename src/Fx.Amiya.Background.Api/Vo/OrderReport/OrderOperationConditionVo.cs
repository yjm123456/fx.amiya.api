using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 订单经营情况
    /// </summary>
    public class OrderOperationConditionVo
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 订单量
        /// </summary>
        public int OrderNum { get; set; }
    }
}
