﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.Performance
{
    /// <summary>
    /// 达人业绩输出
    /// </summary>

    public class LiveAnchorMonthAndDatePerformanceVo
    {
        /// <summary>
        /// 月数据
        /// </summary>
        public  LiveAnchorMonthPerformanceVo  MonthDataVo{ get;set; }
        /// <summary>
        /// 日数据
        /// </summary>
        public LiveAnchorMonthPerformanceVo CurrentDateDataVo { get; set; }
    }

    /// <summary>
    /// 达人业绩
    /// </summary>
    public class LiveAnchorMonthPerformanceVo
    {
        #region【总业绩】
        /// <summary>
        /// 总业绩
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
        /// 新客业绩
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
        /// 老客业绩
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

        #region 【0元/199元业绩】
        /// <summary>
        /// 0元业绩
        /// </summary>
        public decimal? ZeroPricePerformance { get; set; }
        /// <summary>
        /// 0元业绩占比
        /// </summary>
        public decimal? ZeroPricePerformanceRatio { get; set; }

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
        public decimal? ExistPricePerformanceRatio { get; set; }

        /// <summary>
        /// 199元业绩同比
        /// </summary>
        public decimal? ExistPricePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 199元业绩环比
        /// </summary>
        public decimal? ExistPricePerformanceChainRatio { get; set; }
        #endregion
    }
}
