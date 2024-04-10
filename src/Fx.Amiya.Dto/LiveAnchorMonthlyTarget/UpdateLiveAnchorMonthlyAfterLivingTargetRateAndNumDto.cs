﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class UpdateLiveAnchorMonthlyAfterLivingTargetRateAndNumDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 当日加V
        /// </summary>
        public int CumulativeAddWechat { get; set; }
        /// <summary>
        /// 当日99消耗卡
        /// </summary>
        public int CumulativeConsultationCardConsumed { get; set; }
        /// <summary>
        /// 当日199消耗卡
        /// </summary>
        public int CumulativeConsultationCardConsumed2 { get; set; }
        /// <summary>
        /// 当日激活历史面诊
        /// </summary>
        public int CumulativeActivateHistoricalConsultation { get; set; }

        /// <summary>
        /// 当日派单
        /// </summary>
        public int CumulativeSendOrder { get; set; }

        /// <summary>
        /// 当日新客上门数
        /// </summary>
        public int CumulativeNewCustomerVisit { get; set; }

        /// <summary>
        /// 当日老客上门数
        /// </summary>
        public int CumulativeOldCustomerVisit { get; set; }

        /// <summary>
        /// 当日上门数
        /// </summary>
        public int CumulativeVisit { get; set; }

        /// <summary>
        /// 当日新客成交人数
        /// </summary>
        public int CumulativeNewCustomerDealTarget { get; set; }

        /// <summary>
        /// 当日老客成交人数
        /// </summary>
        public int CumulativeOldCustomerDealTarget { get; set; }

        /// <summary>
        /// 当日成交人数
        /// </summary>
        public int CumulativeDealTarget { get; set; }


        /// <summary>
        /// 当日新诊绩金额
        /// </summary>
        public decimal CumulativeNewCustomerPerformance { get; set; }

        /// <summary>
        /// 当日复诊业绩金额
        /// </summary>
        public decimal CumulativeSubsequentPerformance { get; set; }

        /// <summary>
        /// 当日老客业绩金额
        /// </summary>
        public decimal CumulativeOldCustomerPerformance { get; set; }

        /// <summary>
        /// 当日业绩金额
        /// </summary>
        public decimal CumulativePerformance { get; set; }

        /// <summary>
        /// 当日小黄车退单
        /// </summary>
        public int CumulativeMinivanRefund { get; set; }
        /// <summary>
        /// 当日小黄车差评
        /// </summary>
        public int CumulativeMiniVanBadReviews { get; set; }
        /// <summary>
        /// 今日有效业绩
        /// </summary>
        public decimal EffectivePerformance { get; set; }
        /// <summary>
        /// 今日潜在业绩
        /// </summary>
        public decimal PotentialPerformance { get; set; }
        /// <summary>
        /// 今日分诊量
        /// </summary>
        public int DistributeConsulation { get; set; }
    }
}
