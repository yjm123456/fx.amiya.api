using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AssiatantPerformanceAnalysisDataVo
    {
        /// <summary>
        /// 有效/潜在分诊数据
        /// </summary>
        public AssistantOperationBoardIsEffictiveDataVo DistributeConsulationData { get; set; } = new();
        /// <summary>
        /// 有效/潜在业绩数据
        /// </summary>
        public AssistantOperationBoardGetIsEffictivePerformanceVo PerformanceEffictiveOrNoData { get; set; } = new();
        /// <summary>
        /// 当月/历史派单数据
        /// </summary>
        public AssistantOperationBoardGetIsHistoryPerformanceVo SendOrderData { get; set; } = new();
        /// <summary>
        /// 当月/历史业绩数据
        /// </summary>
        public AssistantOperationBoardGetIsHistoryPerformanceVo PerformanceHistoryOrNoData { get; set; } = new();
        /// <summary>
        /// 新/老客成交数据
        /// </summary>
        public AssistantOperationBoardGetNewOrOldCustomerCompareDataDetailsVo CustomerDealData { get; set; } = new();
        /// <summary>
        /// 新/老客业绩数据
        /// </summary>
        public AssistantOperationBoardGetNewOrOldCustomerCompareDataDetailsVo PerformanceNewCustonerOrNoData { get; set; } = new();
    }
    /// <summary>
    /// 有效/潜在分诊数据
    /// </summary>
    public class AssistantOperationBoardIsEffictiveDataVo
    {
        /// <summary>
        /// 有效（占比）
        /// </summary>
        public decimal? EffictiveRate { get; set; }
        /// <summary>
        /// 潜在（占比）
        /// </summary>
        public decimal? NotEffictiveRate { get; set; }
        /// <summary>
        /// 有效（数值）
        /// </summary>
        public decimal? EffictiveNumber { get; set; }
        /// <summary>
        /// 潜在（数值）
        /// </summary>
        public decimal? NotEffictiveNumber { get; set; }
        /// <summary>
        /// 总线索量
        /// </summary>
        public decimal? TotalFlowRateNumber { get; set; }
    }
    /// <summary>
    /// 有效/潜在业绩数据
    /// </summary>
    public class AssistantOperationBoardGetIsEffictivePerformanceVo
    {
        /// <summary>
        /// 有效数值
        /// </summary>
        public decimal? EffictivePerformanceNumber { get; set; }
        /// <summary>
        /// 有效占比
        /// </summary>
        public decimal? EffictivePerformanceRate { get; set; }

        /// <summary>
        /// 潜在数值
        /// </summary>
        public decimal? NotEffictivePerformanceNumber { get; set; }

        /// <summary>
        /// 潜在占比
        /// </summary>
        public decimal? NotEffictivePerformanceRate { get; set; }
        /// <summary>
        /// 总业绩数值
        /// </summary>
        public decimal? TotalPerformanceNumber { get; set; }
    }
    /// <summary>
    /// 当月/历史数据
    /// </summary>
    public class AssistantOperationBoardGetIsHistoryPerformanceVo
    {
        /// <summary>
        /// 当月数值
        /// </summary>
        public decimal? ThisMonthPerformanceNumber { get; set; }
        /// <summary>
        /// 当月占比
        /// </summary>
        public decimal? ThisMonthPerformanceRate { get; set; }

        /// <summary>
        /// 历史数值
        /// </summary>
        public decimal? HistoryPerformanceNumber { get; set; }

        /// <summary>
        /// 历史占比
        /// </summary>
        public decimal? HistoryPerformanceRate { get; set; }
        /// <summary>
        /// 总业绩数值
        /// </summary>
        public decimal? TotalPerformanceNumber { get; set; }
    }
    /// <summary>
    /// 新/老客数据
    /// </summary>
    public class AssistantOperationBoardGetNewOrOldCustomerCompareDataDetailsVo
    {
        /// <summary>
        /// 新客占比
        /// </summary>
        public decimal? TotalPerformanceNewCustomerRate { get; set; }

        /// <summary>
        /// 老客占比
        /// </summary>
        public decimal? TotalPerformanceOldCustomerRate { get; set; }

        /// <summary>
        /// 新客数值
        /// </summary>
        public decimal? TotalPerformanceNewCustomerNumber { get; set; }

        /// <summary>
        /// 老客数值
        /// </summary>
        public decimal? TotalPerformanceOldCustomerNumber { get; set; }

        /// <summary>
        /// 总业绩数值
        /// </summary>
        public decimal? TotalPerformanceNumber { get; set; }
    }
}
