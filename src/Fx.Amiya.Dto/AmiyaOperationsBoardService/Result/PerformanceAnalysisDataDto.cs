using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class AssistantPerformanceAnalysisDataDto
    {
        /// <summary>
        /// 客资分类线索
        /// </summary>
        public CustomerTypePerformanceDataDto TypeCount { get; set; }
        /// <summary>
        /// 客资分类业绩
        /// </summary>
        public CustomerTypePerformanceDataDto TypePerformance { get; set; }
        /// <summary>
        /// 有效/潜在分诊数据
        /// </summary>
        public AssistantOperationBoardIsEffictiveDataDto DistributeConsulationData { get; set; }
        /// <summary>
        /// 有效/潜在业绩数据
        /// </summary>
        public AssistantOperationBoardGetIsEffictivePerformanceDto PerformanceEffictiveOrNoData { get; set; }
        /// <summary>
        /// 当月/历史派单数据
        /// </summary>
        public AssistantOperationBoardGetIsHistoryPerformanceDto SendOrderData { get; set; }
        /// <summary>
        /// 当月/历史业绩数据
        /// </summary>
        public AssistantOperationBoardGetIsHistoryPerformanceDto PerformanceHistoryOrNoData { get; set; }
        /// <summary>
        /// 新老客成交数据
        /// </summary>
        public AssistantOperationBoardGetNewOrOldCustomerCompareDataDetailsDto CustomerDealData { get; set; }
        /// <summary>
        /// 新老客业绩数据
        /// </summary>
        public AssistantOperationBoardGetNewOrOldCustomerCompareDataDetailsDto PerformanceNewCustonerOrNoData { get; set; }
        /// <summary>
        /// 面诊派单数据
        /// </summary>
        public CustomerTypePerformanceDataDto Consulation { get; set; }
        /// <summary>
        /// 面诊业绩数据
        /// </summary>
        public CustomerTypePerformanceDataDto ConsulationPerformance { get; set; }


    }
    public class CustomerTypePerformanceDataDto
    {
        /// <summary>
        /// 总计
        /// </summary>
        public decimal TotalCount { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public List<CustomerTypePerformanceDataItemDto> Data { get; set; }
    }
    public class CustomerTypePerformanceDataItemDto
    {
        public string Key { get; set; }
        public decimal Value { get; set; }
        public decimal Rate { get; set; }
    }
    /// <summary>
    /// 有效/潜在分诊数据
    /// </summary>
    public class AssistantOperationBoardIsEffictiveDataDto
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
    public class AssistantOperationBoardGetIsEffictivePerformanceDto
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
    public class AssistantOperationBoardGetIsHistoryPerformanceDto
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
    public class AssistantOperationBoardGetNewOrOldCustomerCompareDataDetailsDto
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
