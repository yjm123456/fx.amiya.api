using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    /// <summary>
    /// 订单归属主播
    /// </summary>
    public class LiveAnchorOrderVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public List<string> OrderId { get; set; }

        /// <summary>
        /// 主播id
        /// </summary>
        public int LiveAnchorId { get; set; }
    }
}
