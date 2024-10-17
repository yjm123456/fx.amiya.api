using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class UpdateLiveAnchorMonthlyTargetBeforeLivingDto
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
        /// 抖音发布目标
        /// </summary>
        public int TikTokReleaseTarget { get; set; }

        /// <summary>
        /// 抖音投流费用目标
        /// </summary>
        public decimal TikTokFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 抖音橱窗收入目标
        /// </summary>
        public decimal TikTokShowcaseIncomeTarget { get; set; }

       

        /// <summary>
        /// 知乎发布目标
        /// </summary>
        public int ZhihuReleaseTarget { get; set; }

        /// <summary>
        /// 知乎投流费用目标
        /// </summary>
        public decimal ZhihuFlowinvestmentTarget { get; set; }

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
        /// 视频号发布目标
        /// </summary>
        public int VideoReleaseTarget { get; set; }
        /// <summary>
        /// 视频号投流费用目标
        /// </summary>
        public decimal VideoFlowinvestmentTarget { get; set; }

        /// <summary>
        /// 月发布目标
        /// </summary>
        public int ReleaseTarget { get; set; }

        /// <summary>
        /// 运营渠道投流目标
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
        /// 视频号线索量目标
        /// </summary>
        public int VideoCluesTarget { get; set; }

        /// <summary>
        /// 视频号橱窗收入目标
        /// </summary>
        public decimal VideoShowcaseIncomeTarget { get; set; }
        /// <summary>
        /// 视频号橱窗付费
        /// </summary>
        public decimal VideoShowcaseFeeTarget { get; set; }
        /// <summary>
        /// 小红书橱窗付费
        /// </summary>
        public decimal XiaoHongShuShowcaseFeeTarget { get; set; }
        /// <summary>
        /// 抖音橱窗付费
        /// </summary>
        public decimal TikTokShowcaseFeeTarget { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public int OwnerId { get; set; }
    }
}
