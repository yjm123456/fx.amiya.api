using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class AmiyaAchievementDetailDataDto
    {
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }

        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal NewCustomerPerformanceProportion { get; set; }

        /// <summary>
        /// 新客业绩目标完成率
        /// </summary>
        public decimal NewCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 新客业绩同比
        /// </summary>
        public decimal NewCustomerPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal NewCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 新客业绩对比时间进度
        /// </summary>
        public decimal NewCustomerPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 新客业绩偏差
        /// </summary>
        public decimal NewCustomerPerformanceDeviation { get; set; }

        /// <summary>
        /// 新客业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayNewCustomerPerformance { get; set; }


        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal OldCustomerPerformanceProportion { get; set; }

        /// <summary>
        /// 老客业绩目标完成率
        /// </summary>
        public decimal OldCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal OldCustomerPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal OldCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 老客业绩对比时间进度
        /// </summary>
        public decimal OldCustomerPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 老客业绩偏差
        /// </summary>
        public decimal OldCustomerPerformanceDeviation { get; set; }

        /// <summary>
        /// 老客业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayOldCustomerPerformance { get; set; }


        /// <summary>
        /// 有效业绩
        /// </summary>
        public decimal EffectivePerformance { get; set; }
        /// <summary>
        /// 有效业绩占比
        /// </summary>
        public decimal EffectivePerformanceProportion { get; set; }

        /// <summary>
        /// 有效业绩目标完成率
        /// </summary>
        public decimal EffectivePerformanceCompleteRate { get; set; }

        /// <summary>
        /// 有效业绩同比
        /// </summary>
        public decimal EffectivePerformanceYearOnYear { get; set; }

        /// <summary>
        /// 有效业绩环比
        /// </summary>
        public decimal EffectivePerformanceChainRatio { get; set; }

        /// <summary>
        /// 有效业绩对比时间进度
        /// </summary>
        public decimal EffectivePerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 有效业绩偏差
        /// </summary>
        public decimal EffectivePerformanceDeviation { get; set; }

        /// <summary>
        /// 有效业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayEffectivePerformance { get; set; }

        /// <summary>
        /// 潜在业绩
        /// </summary>
        public decimal PotentialPerformance { get; set; }
        /// <summary>
        /// 潜在业绩占比
        /// </summary>
        public decimal PotentialPerformanceProportion { get; set; }

        /// <summary>
        /// 潜在业绩目标完成率
        /// </summary>
        public decimal PotentialPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 潜在业绩同比
        /// </summary>
        public decimal PotentialPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 潜在业绩环比
        /// </summary>
        public decimal PotentialPerformanceChainRatio { get; set; }

        /// <summary>
        /// 潜在业绩对比时间进度
        /// </summary>
        public decimal PotentialPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 潜在业绩偏差
        /// </summary>
        public decimal PotentialPerformanceDeviation { get; set; }

        /// <summary>
        /// 潜在业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayPotentialPerformance { get; set; }

        /// <summary>
        /// 当月派单业绩
        /// </summary>
        public decimal ThisMonthSendOrderPerformance { get; set; }
        /// <summary>
        /// 当月派单业绩占比
        /// </summary>
        public decimal ThisMonthSendOrderPerformanceProportion { get; set; }


        /// <summary>
        /// 当月派单业绩同比
        /// </summary>
        public decimal ThisMonthSendOrderPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 当月派单业绩环比
        /// </summary>
        public decimal ThisMonthSendOrderPerformanceChainRatio { get; set; }


        /// <summary>
        /// 历史派单业绩
        /// </summary>
        public decimal HistorySendOrderPerformance { get; set; }
        /// <summary>
        /// 历史派单业绩占比
        /// </summary>
        public decimal HistorySendOrderPerformanceProportion { get; set; }



        /// <summary>
        /// 历史派单业绩同比
        /// </summary>
        public decimal HistorySendOrderPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 历史派单业绩环比
        /// </summary>
        public decimal HistorySendOrderPerformanceChainRatio { get; set; }




        /// <summary>
        /// 抖音业绩
        /// </summary>
        public decimal TikTokPerformance { get; set; }
        /// <summary>
        /// 抖音业绩占比
        /// </summary>
        public decimal TikTokPerformanceProportion { get; set; }


        /// <summary>
        /// 抖音业绩同比
        /// </summary>
        public decimal TikTokPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 抖音业绩环比
        /// </summary>
        public decimal TikTokPerformanceChainRatio { get; set; }



        /// <summary>
        /// 视频号业绩
        /// </summary>
        public decimal VideoPerformance { get; set; }
        /// <summary>
        /// 视频号业绩占比
        /// </summary>
        public decimal VideoPerformanceProportion { get; set; }


        /// <summary>
        /// 视频号业绩同比
        /// </summary>
        public decimal VideoPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 视频号业绩环比
        /// </summary>
        public decimal VideoPerformanceChainRatio { get; set; }


        /// <summary>
        /// 主播视频业绩
        /// </summary>
        public decimal LiveAnchorVideoPerformance { get; set; }
        /// <summary>
        /// 主播视频业绩占比
        /// </summary>
        public decimal LiveAnchorVideoPerformanceProportion { get; set; }


        /// <summary>
        /// 主播视频业绩同比
        /// </summary>
        public decimal LiveAnchorVideoPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 主播视频业绩环比
        /// </summary>
        public decimal LiveAnchorVideoPerformanceChainRatio { get; set; }




        /// <summary>
        /// 助理照片业绩
        /// </summary>
        public decimal AssistantPhotoPerformance { get; set; }
        /// <summary>
        /// 助理照片业绩占比
        /// </summary>
        public decimal AssistantPhotoPerformanceProportion { get; set; }


        /// <summary>
        /// 助理照片业绩同比
        /// </summary>
        public decimal AssistantPhotoPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 助理照片业绩环比
        /// </summary>
        public decimal AssistantPhotoPerformanceChainRatio { get; set; }



        /// <summary>
        /// 主播接诊业绩
        /// </summary>
        public decimal LiveAnchorReceptionPerformance { get; set; }
        /// <summary>
        /// 主播接诊业绩占比
        /// </summary>
        public decimal LiveAnchorReceptionPerformanceProportion { get; set; }

        /// <summary>
        /// 主播接诊业绩同比
        /// </summary>
        public decimal LiveAnchorReceptionPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 主播接诊业绩环比
        /// </summary>
        public decimal LiveAnchorReceptionPerformanceChainRatio { get; set; }



        /// <summary>
        /// 非主播接诊业绩
        /// </summary>
        public decimal NoLiveAnchorReceptionPerformance { get; set; }
        /// <summary>
        /// 非主播接诊业绩占比
        /// </summary>
        public decimal NoLiveAnchorReceptionPerformanceProportion { get; set; }


        /// <summary>
        /// 非主播接诊业绩同比
        /// </summary>
        public decimal NoLiveAnchorReceptionPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 非主播接诊业绩环比
        /// </summary>
        public decimal NoLiveAnchorReceptionPerformanceChainRatio { get; set; }
    }
}
