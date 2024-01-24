using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget.BeforeLiving
{
    /// <summary>
    /// 添加主播月度目标情况
    /// </summary>
    public class AddLiveAnchorMonthlyTargetBeforeLivingVo
    {
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
        /// 知乎发布目标
        /// </summary>
        public int ZhihuReleaseTarget { get; set; }

        /// <summary>
        /// 知乎投流费用目标
        /// </summary>
        public decimal ZhihuFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 视频号发布目标
        /// </summary>
        public int VideoReleaseTarget { get; set; }
        /// <summary>
        /// 视频号投流费用目标
        /// </summary>
        public decimal VideoFlowinvestmentTarget { get; set; }

        /// <summary>
        /// 抖音发布目标
        /// </summary>
        public int TikTokReleaseTarget { get; set; }
        /// <summary>
        /// 抖音橱窗收入目标
        /// </summary>
        public decimal TikTokShowcaseIncomeTarget { get; set; }

        /// <summary>
        /// 抖音投流费用目标
        /// </summary>
        public decimal TikTokFlowinvestmentTarget { get; set; }


        /// <summary>
        /// 小红书发布目标
        /// </summary>
        public int XiaoHongShuReleaseTarget { get; set; }
        /// <summary>
        /// 小红书投流费用目标
        /// </summary>
        public decimal XiaoHongShuFlowinvestmentTarget { get; set; }


        /// <summary>
        /// 微博发布目标
        /// </summary>
        public int SinaWeiBoReleaseTarget { get; set; }
        /// <summary>
        /// 微博投流费用目标
        /// </summary>
        public decimal SinaWeiBoFlowinvestmentTarget { get; set; }

        /// <summary>
        /// 月发布目标
        /// </summary>
        public int ReleaseTarget { get; set; }

        /// <summary>
        /// 月运营渠道投流目标
        /// </summary>
        public decimal FlowInvestmentTarget { get; set; }
        /// <summary>
        /// 抖音涨粉目标
        /// </summary>

        public int TikTokIncreaseFansTarget { get; set; }
        /// <summary>
        /// 抖音涨粉付费目标
        /// </summary>
        public decimal TikTokIncreaseFansFeesTarget { get; set; }

        /// <summary>
        /// 抖音涨粉成本目标
        /// </summary>
        public decimal TikTokIncreaseFansFeesCostTarget { get; set; }

        /// <summary>
        /// 抖音线索量目标
        /// </summary>
        public int TikTokCluesTarget { get; set; }
 
        /// <summary>
        /// 小红书涨粉目标
        /// </summary>

        public int XiaoHongShuIncreaseFansTarget { get; set; }
 
        /// <summary>
        /// 小红书涨粉付费目标
        /// </summary>
        public decimal XiaoHongShuIncreaseFansFeesTarget { get; set; }

        /// <summary>
        /// 小红书涨粉成本目标
        /// </summary>
        public decimal XiaoHongShuIncreaseFansFeesCostTarget { get; set; }
     
        /// <summary>
        /// 小红书线索量目标
        /// </summary>
        public int XiaoHongShuCluesTarget { get; set; }

        /// <summary>
        /// 小红书橱窗收入目标
        /// </summary>
        public decimal XiaoHongShuShowcaseIncomeTarget { get; set; }

        /// <summary>
        /// 视频号涨粉目标
        /// </summary>

        public int VideoIncreaseFansTarget { get; set; }
  
        /// <summary>
        /// 视频号涨粉付费目标
        /// </summary>
        public decimal VideoIncreaseFansFeesTarget { get; set; }
 
        /// <summary>
        /// 视频号涨粉成本目标
        /// </summary>
        public decimal VideoIncreaseFansFeesCostTarget { get; set; }
   
        /// <summary>
        /// 视频号线索量目标
        /// </summary>
        public int VideoCluesTarget { get; set; }
  
        /// <summary>
        /// 视频号橱窗收入目标
        /// </summary>
        public decimal VideoShowcaseIncomeTarget { get; set; }
        /// <summary>
        /// 小红书橱窗付费
        /// </summary>
        public decimal XiaoHongShuShowCaseFeeTarget { get; set; }
        /// <summary>
        /// 视频号橱窗付费
        /// </summary>
        public decimal VideoShowCaseFeeTarget { get; set; }
        /// <summary>
        /// 抖音橱窗付费
        /// </summary>
        public decimal TikTokShowCaseFeeTarget { get; set; }



    }
}
