﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class LiveAnchorMonthlyTargetAfterLivingDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月度
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 经营目标名称
        /// </summary>
        public string MonthlyTargetName { get; set; }

        /// <summary>
        /// 主播ID
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }

        /// <summary>
        /// 主播归属平台id
        /// </summary>
        public string ContentPlatFormId { get; set; }
        /// <summary>
        /// 目标加V量
        /// </summary>
        public int AddWechatTarget { get; set; }

        /// <summary>
        /// 月加V累计
        /// </summary>
        public int CumulativeAddWechat { get; set; }

        /// <summary>
        /// 加V完成率
        /// </summary>
        public decimal AddWechatCompleteRate { get; set; }

        /// <summary>
        /// 99消耗卡目标
        /// </summary>
        public int ConsultationCardConsumedTarget { get; set; }

        /// <summary>
        /// 99累计消耗卡
        /// </summary>
        public int CumulativeConsultationCardConsumed { get; set; }

        /// <summary>
        /// 99消耗卡完成率
        /// </summary>
        public decimal ConsultationCardConsumedCompleteRate { get; set; }


        /// <summary>
        /// 199消耗卡目标
        /// </summary>
        public int ConsultationCardConsumedTarget2 { get; set; }

        /// <summary>
        /// 199累计消耗卡
        /// </summary>
        public int CumulativeConsultationCardConsumed2 { get; set; }

        /// <summary>
        /// 199消耗卡完成率
        /// </summary>
        public decimal ConsultationCardConsumedCompleteRate2 { get; set; }

        /// <summary>
        /// 激活历史面诊数量目标
        /// </summary>
        public int ActivateHistoricalConsultationTarget { get; set; }

        /// <summary>
        /// 累计激活历史面诊数量
        /// </summary>
        public int CumulativeActivateHistoricalConsultation { get; set; }

        /// <summary>
        /// 激活历史面诊数量完成率
        /// </summary>
        public decimal ActivateHistoricalConsultationCompleteRate { get; set; }

        /// <summary>
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }

        /// <summary>
        /// 累计派单
        /// </summary>
        public int CumulativeSendOrder { get; set; }

        /// <summary>
        /// 派单完成率
        /// </summary>
        public decimal SendOrderCompleteRate { get; set; }



        /// <summary>
        /// 新客上门目标
        /// </summary>
        public int NewCustomerVisitTarget { get; set; }

        /// <summary>
        /// 累计新客上门数
        /// </summary>
        public int CumulativeNewCustomerVisit { get; set; }

        /// <summary>
        /// 新客上门完成率
        /// </summary>
        public decimal NewCustomerVisitCompleteRate { get; set; }

        /// <summary>
        /// 老客上门目标
        /// </summary>
        public int OldCustomerVisitTarget { get; set; }

        /// <summary>
        /// 累计老客上门数
        /// </summary>
        public int CumulativeOldCustomerVisit { get; set; }

        /// <summary>
        /// 老客上门完成率
        /// </summary>
        public decimal OldCustomerVisitCompleteRate { get; set; }


        /// <summary>
        /// 上门目标
        /// </summary>
        public int VisitTarget { get; set; }

        /// <summary>
        /// 累计上门数
        /// </summary>
        public int CumulativeVisit { get; set; }

        /// <summary>
        /// 上门完成率
        /// </summary>
        public decimal VisitCompleteRate { get; set; }


        /// <summary>
        /// 新诊成交人数目标
        /// </summary>
        public int NewCustomerDealTarget { get; set; }

        /// <summary>
        /// 累计新诊成交人数
        /// </summary>
        public int CumulativeNewCustomerDealTarget { get; set; }

        /// <summary>
        /// 新诊成交率
        /// </summary>
        public decimal NewCustomerDealRate { get; set; }

        /// <summary>
        /// 老客成交人数目标
        /// </summary>
        public int OldCustomerDealTarget { get; set; }

        /// <summary>
        /// 累计老客成交人数
        /// </summary>
        public int CumulativeOldCustomerDealTarget { get; set; }

        /// <summary>
        /// 老客成交率
        /// </summary>
        public decimal OldCustomerDealRate { get; set; }

        /// <summary>
        /// 成交人数目标
        /// </summary>
        public int DealTarget { get; set; }

        /// <summary>
        /// 累计成交人数
        /// </summary>
        public int CumulativeDealTarget { get; set; }

        /// <summary>
        /// 成交率
        /// </summary>
        public decimal DealRate { get; set; }
        /// <summary>
        /// 新诊业绩目标
        /// </summary>
        public decimal NewCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 月累计新诊业绩
        /// </summary>
        public decimal CumulativeNewCustomerPerformance { get; set; }
        /// <summary>
        /// 新诊业绩完成率
        /// </summary>
        public decimal NewCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 复诊业绩目标
        /// </summary>
        public decimal SubsequentPerformanceTarget { get; set; }
        /// <summary>
        /// 月累计复诊业绩
        /// </summary>
        public decimal CumulativeSubsequentPerformance { get; set; }
        /// <summary>
        /// 复诊业绩完成率
        /// </summary>
        public decimal SubsequentPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal OldCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 月累计老客业绩
        /// </summary>
        public decimal CumulativeOldCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩完成率
        /// </summary>
        public decimal OldCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 业绩目标（包含面诊卡定金）
        /// </summary>
        public decimal PerformanceTarget { get; set; }

        /// <summary>
        /// 月累计业绩金额
        /// </summary>
        public decimal CumulativePerformance { get; set; }

        /// <summary>
        /// 业绩完成率
        /// </summary>
        public decimal PerformanceCompleteRate { get; set; }

        /// <summary>
        /// 小黄车退单总量
        /// </summary>
        public int MinivanRefundTarget { get; set; }

        /// <summary>
        /// 月累计小黄车退单
        /// </summary>
        public int CumulativeMinivanRefund { get; set; }

        /// <summary>
        /// 小黄车退单率
        /// </summary>
        public decimal MinivanRefundCompleteRate { get; set; }

        /// <summary>
        /// 小黄车差评总量
        /// </summary>
        public int MiniVanBadReviewsTarget { get; set; }

        /// <summary>
        /// 月累计小黄车差评
        /// </summary>
        public int CumulativeMiniVanBadReviews { get; set; }

        /// <summary>
        /// 小黄车差评率
        /// </summary>
        public decimal MiniVanBadReviewsCompleteRate { get; set; }
        /// <summary>
        /// 有效业绩目标
        /// </summary>
        public decimal EffectivePerformanceTarget { get; set; }
        /// <summary>
        /// 累计有效业绩
        /// </summary>
        public decimal CumulativeEffectivePerformance { get; set; }
        /// <summary>
        /// 有效业绩完成率
        /// </summary>
        public decimal EffectivePerformanceCompleteRate { get; set; }
        /// <summary>
        /// 潜在业绩目标
        /// </summary>
        public decimal PotentialPerformanceTarget { get; set; }
        /// <summary>
        /// 累计潜在业绩
        /// </summary>
        public decimal CumulativePotentialPerformance { get; set; }
        /// <summary>
        /// 潜在业绩目标完成率
        /// </summary>
        public decimal PotentialPerformanceCompleteRate { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
