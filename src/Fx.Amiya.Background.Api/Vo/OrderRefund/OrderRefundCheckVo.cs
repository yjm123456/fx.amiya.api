using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderRefund
{
    public class OrderRefundCheckVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 审核未通过原因
        /// </summary>
        public string UnCheckReason { get; set; }
        /// <summary>
        /// 审核状态id
        /// </summary>
        public int CheckState { get; set; }
    }
}
