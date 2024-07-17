using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class OperationTotalFlowRateDataDto
    {

        /// <summary>
        /// 总直播前线索
        /// </summary>
        public decimal TotalBeforeLivingClue { get; set; }
        /// <summary>
        /// 当日直播前线索
        /// </summary>
        public decimal? TodayBeforeLivingClue { get; set; }


        /// <summary>
        /// 直播前线索目标完成率
        /// </summary>
        public decimal? BeforeLivingClueCompleteRate { get; set; }

        /// <summary>
        /// 直播前线索同比
        /// </summary>
        public decimal? BeforeLivingClueYearOnYear { get; set; }

        /// <summary>
        /// 直播前线索环比
        /// </summary>
        public decimal? BeforeLivingClueChainRatio { get; set; }

        /// <summary>
        /// 总直播中线索
        /// </summary>
        public decimal TotalLivingClue { get; set; }
        /// <summary>
        /// 当日直播中线索
        /// </summary>
        public decimal? TodayLivingClue { get; set; }


        /// <summary>
        /// 直播中线索目标完成率
        /// </summary>
        public decimal? LivingClueCompleteRate { get; set; }

        /// <summary>
        /// 直播中线索同比
        /// </summary>
        public decimal? LivingClueYearOnYear { get; set; }

        /// <summary>
        /// 直播中线索环比
        /// </summary>
        public decimal? LivingClueChainRatio { get; set; }

        /// <summary>
        /// 总直播后线索
        /// </summary>
        public decimal TotalAfterLivingClue { get; set; }
        /// <summary>
        /// 当日总直播后线索
        /// </summary>
        public decimal? TodayTotalAfterLivingClue { get; set; }

        /// <summary>
        /// 总直播后线索目标完成率
        /// </summary>
        public decimal? TotalAfterLivingClueCompleteRate { get; set; }

        /// <summary>
        /// 总直播后线索同比
        /// </summary>
        public decimal? TotalAfterLivingClueYearOnYear { get; set; }

        /// <summary>
        /// 总直播后线索环比
        /// </summary>
        public decimal? TotalAfterLivingClueChainRatio { get; set; }

        /// <summary>
        /// 总线索
        /// </summary>
        public decimal TotalClue { get; set; }
        /// <summary>
        /// 当日线索
        /// </summary>
        public decimal? TodayClue { get; set; }


        /// <summary>
        /// 线索目标完成率
        /// </summary>
        public decimal? ClueCompleteRate { get; set; }

        /// <summary>
        /// 线索同比
        /// </summary>
        public decimal? ClueYearOnYear { get; set; }

        /// <summary>
        /// 线索环比
        /// </summary>
        public decimal? ClueChainRatio { get; set; }

        /// <summary>
        /// 直播前线索折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> BeforeLivingClueBrokenLineList { get; set; }
        /// <summary>
        /// 直播中线索折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> LivingClueBrokenLineList { get; set; }
        /// <summary>
        /// 直播后线索折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> AfterLivingClueBrokenLineList { get; set; }
    }
}
