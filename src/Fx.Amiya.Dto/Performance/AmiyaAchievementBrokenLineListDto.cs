using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class AmiyaAchievementBrokenLineListDto
    {
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> NewCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> OldCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 有效业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> EffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 潜在业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> PotentialPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 当月派单业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> ThisMonthSendOrderPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 历史派单业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> HistorySendOrderPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 抖音业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> TikTokPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 视频号业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> VideoPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 主播视频业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> LiveAnchorVideoPerformanceBrokenLineList { get; set; }

        /// <summary>
        /// 助理照片业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> AssistantPhotoPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 主播接诊业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> LiveAnchorReceptionPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 非主播接诊业绩
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> NoLiveAnchorReceptionPerformanceBrokenLineList { get; set; }
    }
    public class GroupByTimeBrokenLineListDto
    {
        /// <summary>
        /// 时间
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 有效业绩折线图
        /// </summary>
        public decimal EffectivePerformance { get; set; }
        /// <summary>
        /// 潜在业绩折线图
        /// </summary>
        public decimal PotentialPerformance { get; set; }
        /// <summary>
        /// 当月派单业绩折线图
        /// </summary>
        public decimal ThisMonthSendOrderPerformance { get; set; }
        /// <summary>
        /// 历史派单业绩折线图
        /// </summary>
        public decimal HistorySendOrderPerformance { get; set; }
        /// <summary>
        /// 抖音业绩折线图
        /// </summary>
        public decimal TikTokPerformance { get; set; }
        /// <summary>
        /// 视频号业绩折线图
        /// </summary>
        public decimal VideoPerformance { get; set; }
        /// <summary>
        /// 主播视频业绩折线图
        /// </summary>
        public decimal LiveAnchorVideoPerformance { get; set; }

        /// <summary>
        /// 助理照片业绩折线图
        /// </summary>
        public decimal AssistantPhotoPerformance { get; set; }
        /// <summary>
        /// 主播接诊业绩折线图
        /// </summary>
        public decimal LiveAnchorReceptionPerformance { get; set; }
        /// <summary>
        /// 非主播接诊业绩
        /// </summary>
        public decimal NoLiveAnchorReceptionPerformance { get; set; }
    }
}
