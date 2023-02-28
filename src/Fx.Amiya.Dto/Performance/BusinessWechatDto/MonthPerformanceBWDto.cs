using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance.BusinessWechatDto
{
    /// <summary>
    /// 企业微信达人业绩输出类
    /// </summary>
    public class MonthPerformanceBWDto
    {
        #region【总业绩】
        /// <summary>
        /// 本月总业绩
        /// </summary>
        public decimal CueerntMonthTotalPerformance { get; set; }
        /// <summary>
        /// 总业绩同比增长
        /// </summary>
        public decimal? TotalPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 总业绩环比增长
        /// </summary>
        public decimal? TotalPerformanceChainratio { get; set; }
        /// <summary>
        /// 总业绩目标
        /// </summary>
        public decimal? TotalPerformanceTarget { get; set; }
        /// <summary>
        /// 总业绩目标达成率
        /// </summary>
        public decimal? TotalPerformanceTargetComplete { get; set; }
        #endregion

        #region 【新客业绩】
        /// <summary>
        /// 当前月新客业绩
        /// </summary>
        public decimal CurrentMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal? NewCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 新客业绩同比
        /// </summary>
        public decimal? NewCustomerPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal? NewCustomerPerformanceChainRatio { get; set; }
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
        /// 当前月老客业绩
        /// </summary>
        public decimal CurrentMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal? OldCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal? OldCustomerPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal? OldCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal? OldCustomerTarget { get; set; }
        /// <summary>
        /// 老客业绩目标达成率
        /// </summary>
        public decimal? OldCustomerTargetComplete { get; set; }
        #endregion

        #region 【照片/视频业绩】
        /// <summary>
        /// 照片面诊业绩
        /// </summary>
        public decimal? PictureConsultationPerformance { get; set; }
        /// <summary>
        /// 照片面诊业绩占比
        /// </summary>
        public decimal? PictureConsultationPerformancePerformanceRatio { get; set; }

        /// <summary>
        /// 照片面诊业绩同比
        /// </summary>
        public decimal? PictureConsultationPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 照片面诊业绩环比
        /// </summary>
        public decimal? PictureConsultationPerformanceChainRatio { get; set; }

        /// <summary>
        /// 视频面诊业绩
        /// </summary>
        public decimal? VideoConsultationPerformance { get; set; }
        /// <summary>
        /// 视频面诊业绩占比
        /// </summary>
        public decimal? VideoConsultationPerformancePerformanceRatio { get; set; }

        /// <summary>
        /// 视频面诊业绩同比
        /// </summary>
        public decimal? VideoConsultationPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 视频面诊业绩环比
        /// </summary>
        public decimal? VideoConsultationPerformanceChainRatio { get; set; }
        #endregion

        #region 【主播/非主播接诊业绩】
        /// <summary>
        /// 主播接诊业绩
        /// </summary>
        public decimal? AcompanyingPerformance { get; set; }
        /// <summary>
        /// 主播接诊业绩占比
        /// </summary>
        public decimal? AcompanyingPerformancePerformanceRatio { get; set; }

        /// <summary>
        /// 主播接诊业绩同比
        /// </summary>
        public decimal? AcompanyingPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 主播接诊业绩环比
        /// </summary>
        public decimal? AcompanyingPerformanceChainRatio { get; set; }

        /// <summary>
        /// 非主播接诊业绩
        /// </summary>
        public decimal? NotAcompanyingPerformance { get; set; }
        /// <summary>
        /// 非主播接诊业绩占比
        /// </summary>
        public decimal? NotAcompanyingPerformancePerformanceRatio { get; set; }

        /// <summary>
        /// 非主播接诊业绩同比
        /// </summary>
        public decimal? NotAcompanyingPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 非主播接诊业绩环比
        /// </summary>
        public decimal? NotAcompanyingPerformanceChainRatio { get; set; }
        #endregion

        #region 【0元/199元业绩】
        /// <summary>
        /// 0元业绩
        /// </summary>
        public decimal? ZeroPricePerformance { get; set; }
        /// <summary>
        /// 0元业绩占比
        /// </summary>
        public decimal? ZeroPricePerformancePerformanceRatio { get; set; }

        /// <summary>
        /// 0元业绩同比
        /// </summary>
        public decimal? ZeroPricePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 0元业绩环比
        /// </summary>
        public decimal? ZeroPricePerformanceChainRatio { get; set; }

        /// <summary>
        /// 199元业绩
        /// </summary>
        public decimal? ExistPricePerformance { get; set; }
        /// <summary>
        /// 199元业绩占比
        /// </summary>
        public decimal? ExistPricePerformancePerformanceRatio { get; set; }

        /// <summary>
        /// 199元业绩同比
        /// </summary>
        public decimal? ExistPricePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 199元业绩环比
        /// </summary>
        public decimal? ExistPricePerformanceChainRatio { get; set; }
        #endregion

        #region【当月/历史派单当月成交业绩】
        /// <summary>
        /// 历史派单当月成交
        /// </summary>
        public decimal? HistorySendDuringMonthDeal { get; set; }
        /// <summary>
        /// 历史派单当月成交业绩占比
        /// </summary>
        public decimal? HistorySendDuringMonthDealPerformanceRatio { get; set; }

        /// <summary>
        /// 历史派单当月成交同比
        /// </summary>
        public decimal? HistorySendDuringMonthDealYearOnYear { get; set; }
        /// <summary>
        /// 历史派单当月成交环比
        /// </summary>
        public decimal? HistorySendDuringMonthDealChainRatio { get; set; }

        /// <summary>
        /// 当月派单当月成交业绩占比
        /// </summary>
        public decimal? DuringMonthSendDuringMonthDealPerformanceRatio { get; set; }

        /// <summary>
        /// 当月派单当月成交同比
        /// </summary>
        public decimal? DuringMonthSendDuringMonthDealYearOnYear { get; set; }
        /// <summary>
        /// 当月派单当月成交环比
        /// </summary>
        public decimal? DuringMonthSendDuringMonthDealChainRatio { get; set; }
        #endregion
    }
}
