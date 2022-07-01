using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerIntegralOrderRefund
{
    /// <summary>
    /// 审核小程序退款
    /// </summary>
    public class CustomerIntegralOrderRefundCheckVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckReason { get; set; }
        /// <summary>
        /// 审核状态id
        /// </summary>
        public int CheckState { get; set; }
    }
}
