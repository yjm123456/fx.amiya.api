using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AssistantPerformanceVo
    {
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 今日新客业绩
        /// </summary>
        public decimal TodayNewCustomerPerformance { get; set; }
        /// <summary>
        /// 今日老客业绩
        /// </summary>
        public decimal TodayOldCustomerPerformance { get; set; }
        /// <summary>
        /// 今日总业绩
        /// </summary>
        public decimal TodayTotalPerformance { get; set; }
        /// <summary>
        /// 上期新客业绩
        /// </summary>
        public decimal LastMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 上期老客业绩
        /// </summary>
        public decimal LastMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 上期总业绩
        /// </summary>
        public decimal LastMonthTotalPerformance { get; set; }
        /// <summary>
        /// 同期新客业绩
        /// </summary>
        public decimal LastYearNewCustomerPerformance { get; set; }
        /// <summary>
        /// 同期老客业绩
        /// </summary>
        public decimal LastYearOldCustomerPerformance { get; set; }
        /// <summary>
        /// 同期总业绩
        /// </summary>
        public decimal LastYearTotalPerformance { get; set; }
        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal NewCustomerPerformanceChain { get; set; }
        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal OldCustomerPerformanceChain { get; set; }
        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal TotalPerformanceChain { get; set; }
        /// <summary>
        /// 新客业绩同比
        /// </summary>
        public decimal NewCustomerPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal OldCustomerPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 总业绩同比
        /// </summary>
        public decimal TotalPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 新客业绩目标
        /// </summary>
        public decimal NewCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 老客业绩目标 
        /// </summary>
        public decimal OldCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 总业绩目标
        /// </summary>
        public decimal TotalPerformanceTarget { get; set; }
        /// <summary>
        /// 新客业绩目标完成率
        /// </summary>
        public decimal NewCustomerPerformanceTargetCompleteRate { get; set; }
        /// <summary>
        /// 老客业绩目标完成率
        /// </summary>
        public decimal OldCustomerPerformanceTargetCompleteRate { get; set; }
        /// <summary>
        /// 总业绩目标完成率
        /// </summary>
        public decimal TotalPerformanceTargetCompleteRate { get; set; }
        /// <summary>
        /// 新客业绩完成进度
        /// </summary>
        public decimal NewCustomerPerformanceTargetSchedule { get; set; }
        /// <summary>
        /// 老客业绩完成进度
        /// </summary>
        public decimal OldCustomerPerformanceTargetSchedule { get; set; }
        /// <summary>
        /// 总业绩完成进度
        /// </summary>
        public decimal TotalPerformanceTargetSchedule { get; set; }
    }
}
