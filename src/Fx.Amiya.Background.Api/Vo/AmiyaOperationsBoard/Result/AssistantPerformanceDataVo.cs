using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AssistantPerformanceDataVo
    {
        /// <summary>
        /// 助理名
        /// </summary>
        public string AssistantName { get; set; }
        #region 【新客业绩】
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal CurrentMonthNewCustomerPerformance { get; set; }

        /// <summary>
        /// 新客业绩目标
        /// </summary>
        public decimal? NewCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 新客业绩目标达成率
        /// </summary>
        public decimal? NewCustomerPerformanceTargetComplete { get; set; }
        #endregion

        #region【老客业绩】
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal CurrentMonthOldCustomerPerformance { get; set; }

        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal? OldCustomerTarget { get; set; }
        /// <summary>
        /// 老客业绩目标达成率
        /// </summary>
        public decimal? OldCustomerTargetComplete { get; set; }
        #endregion

        #region 总业绩
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 总业绩目标
        /// </summary>
        public decimal TotalPerformanceTarget { get; set; }
        /// <summary>
        /// 总业绩目标完成率
        /// </summary>
        public decimal TotalPerformanceTargetComplete { get; set; }
        #endregion
    }
}
