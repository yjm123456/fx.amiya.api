using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerIntegralOrderRefund
{
    public class CustomerIntegralOrderRefundsVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerId { get; set; }


        /// <summary>
        /// 退款原因
        /// </summary>
        public string RefundReasong { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 审核状态编号
        /// </summary>
        public int CheckState { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public string CheckStateText { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 审核人编号
        /// </summary>
        public int CheckBy { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string CheckByEmpName { get; set; }

        /// <summary>
        /// 审核原因
        /// </summary>
        public string CheckReason { get; set; }
    }
}
