using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance.BusinessWechatDto
{
    /// <summary>
    /// 客服总业绩数据
    /// </summary>
    public class CustomerPerformanceBWDto
    {
        /// <summary>
        /// 客服id
        /// </summary>
        public int CustomerServiceId { get; set; }
        /// <summary>
        /// 客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal? TotalPerformance { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal? NewCustomerPerformance { get; set; }

        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal? OldCustomerPerformance { get; set; }

        /// <summary>
        /// 总上门
        /// </summary>
        public int TotalVisitCount { get; set; }
        /// <summary>
        /// 新客上门
        /// </summary>
        public int NewCustomerVisitCount { get; set; }
        /// <summary>
        /// 老客上门
        /// </summary>
        public int OldCustomerVisitCount { get; set; }

        /// <summary>
        /// 上门率
        /// </summary>
        public decimal? VisitNumRatio { get; set; }

        /// <summary>
        /// 成交率
        /// </summary>
        public decimal? DealNumRatio { get; set; }

        /// <summary>
        /// 复购率
        /// </summary>
        public decimal? BuyAgainNumRatio { get; set; }
        /// <summary>
        /// 上门率健康值
        /// </summary>
        public decimal? VisitNumHealthNumber { get; set; }

        /// <summary>
        /// 成交率健康值
        /// </summary>
        public decimal? DealNumHealthNumber { get; set; }

        /// <summary>
        /// 复购率健康值
        /// </summary>
        public decimal? BuyAgainNumHealthNumber { get; set; }
    }

    public class DetailCustomerPerformanceBWDto
    {
        public int CustomerServiceId { get; set; }
        public string CustomerServiceName { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal? TotalPerformance { get; set; }
        /// <summary>
        /// 辅助业绩
        /// </summary>
        public decimal? SupportPerformance { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal? NewCustomerPerformance { get; set; }

        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal? OldCustomerPerformance { get; set; }

        /// <summary>
        /// 当月派单+历史派单当月上门率
        /// </summary>
        public decimal? VisitNumRatio { get; set; }
        /// <summary>
        /// 当月派单当月上门率
        /// </summary>
        public decimal? ThisMonthSendThisMonthVisitNumRatio { get; set; }
        public decimal DealPrice { get; set; }
        public decimal TotalServicePrice { get; set; }
        public decimal NewCustomerPrice { get; set; }
        public decimal NewCustomerServicePrice { get; set; }
        public decimal OldCustomerPrice { get; set; }
        public decimal OldCustomerServicePrice { get; set; }
        /// <summary>
        /// 照片业绩
        /// </summary>
        public decimal VideoPerformance { get; set; }
        /// <summary>
        /// 视频业绩
        /// </summary>
        public decimal PicturePerformance { get; set; }

        /// <summary>
        /// 照片/视频业绩占比
        /// </summary>
        public string VideoAndPictureCompare { get; set; }

        /// <summary>
        /// 陪诊业绩
        /// </summary>
        public decimal AcompanyingPerformance { get; set; }
        /// <summary>
        /// 独立业绩
        /// </summary>
        public decimal NotAcompanyingPerformance { get; set; }

        /// <summary>
        /// 独立/陪诊业绩占比
        /// </summary>
        public string IsAcompanyingCompare { get; set; }
        /// <summary>
        /// 0元业绩
        /// </summary>
        public decimal ZeroPerformance { get; set; }
        /// <summary>
        /// 199业绩
        /// </summary>
        public decimal HavingPricePerformance { get; set; }

        /// <summary>
        /// 0元/199业绩占比
        /// </summary>
        public string ZeroAndHavingPriceCompare { get; set; }

        /// <summary>
        /// 历史派单当月成交业绩
        /// </summary>
        public decimal HistorySendThisMonthDealPerformance { get; set; }

        /// <summary>
        /// 当月派单当月成交业绩
        /// </summary>
        public decimal ThisMonthSendThisMonthDealPerformance { get; set; }
        /// <summary>
        /// 历史/当月派单当月成交业绩占比
        /// </summary>
        public string HistoryAndThisMonthCompare { get; set; }
    }
}
