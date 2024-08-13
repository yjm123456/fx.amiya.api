using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AssistantTargetCompleteVo
    {
        /// <summary>
        /// 排名
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 助理
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 新客目标
        /// </summary>
        public decimal NewCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 本月新客业绩
        /// </summary>
        public decimal CurrentMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 上月新客业绩
        /// </summary>
        public decimal HistoryMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 新客业绩达成率
        /// </summary>
        public decimal NewCustomerTargetComplete { get; set; }
        /// <summary>
        /// 新客环比
        /// </summary>
        public decimal NewCustomerChainRatio { get; set; }
        /// <summary>
        /// 老客目标
        /// </summary>
        public decimal OldCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 本月老客业绩
        /// </summary>
        public decimal CurrentMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 上月老客业绩
        /// </summary>
        public decimal HistoryMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩达成率
        /// </summary>
        public decimal OldCustomerTargetComplete { get; set; }
        /// <summary>
        /// 老客环比
        /// </summary>
        public decimal OldCustomerChainRatio { get; set; }
        /// <summary>
        /// 总业绩目标
        /// </summary>
        public decimal TotalCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 本月总业绩
        /// </summary>
        public decimal CurrentMonthTotalCustomerPerformance { get; set; }
        /// <summary>
        /// 上月总业绩
        /// </summary>
        public decimal HistoryMonthTotalCustomerPerformance { get; set; }
        /// <summary>
        /// 总业绩达成率
        /// </summary>
        public decimal TotalCustomerTargetComplete { get; set; }
        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal TotalCustomerChainRatio { get; set; }
        /// <summary>
        /// 业绩贡献
        /// </summary>
        public decimal PerformanceRate { get; set; }
        /// <summary>
        /// 新老客占比
        /// </summary>
        public string NewAndOldCustomerRate { get; set; }
    }
}
