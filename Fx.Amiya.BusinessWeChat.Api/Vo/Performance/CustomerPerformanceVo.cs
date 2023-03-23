using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.Performance
{
    /// <summary>
    /// 客服总体业绩数据
    /// </summary>
    public class CustomerPerformanceVo
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
        /// 上门率
        /// </summary>
        public decimal? VisitNumRatio { get; set; }
    }

    /// <summary>
    /// 客服详情业绩展示
    /// </summary>
    public class CustomerPerformanceDetailsVo
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
        /// 当月派单+历史派单当月上门率
        /// </summary>
        public decimal? VisitNumRatio { get; set; }
        /// <summary>
        /// 当月派单当月上门率
        /// </summary>
        public decimal? ThisMonthSendThisMonthVisitNumRatio { get; set; }
        /// <summary>
        /// 视频业绩
        /// </summary>
        public decimal VideoPerformance { get; set; }
        /// <summary>
        /// 照片业绩
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
