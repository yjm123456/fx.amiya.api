using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
   public class LiveAnchorMonthTargetPerformanceDto
    {
        /// <summary>
        /// 业绩目标
        /// </summary>
        public decimal TotalPerformanceTarget { get; set; }
        /// <summary>
        /// 带货业绩目标
        /// </summary>
        public decimal CommercePerformanceTarget { get; set; }
        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal OldCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 新客业绩目标
        /// </summary>
        public decimal NewCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 带货完成业绩
        /// </summary>
        public decimal CommerceCompletePerformance { get; set; }
    }

    public class GroupPerformanceListDto
    {
        /// <summary>
        /// 分组业绩量
        /// </summary>
        public decimal GroupPerformance { get; set; }

        /// <summary>
        /// 分组业绩目标
        /// </summary>
        public decimal GroupTargetPerformance { get; set; }
    }
}
