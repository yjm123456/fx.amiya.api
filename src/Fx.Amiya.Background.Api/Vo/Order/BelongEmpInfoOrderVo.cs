using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    /// <summary>
    /// 订单归属主播
    /// </summary>
    public class BelongEmpInfoOrderVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public List<string> OrderId { get; set; }

        /// <summary>
        /// 客服id
        /// </summary>
        public int BelongEmpInfo { get; set; }
        /// <summary>
        /// 订单原本绑定的客服
        /// </summary>
        public string? OriginalCustomerServiceIds { get; set; }
    }
}
