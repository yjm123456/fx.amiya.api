using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 主播月度运营目标情况-直播前
    /// </summary>
    public class LiveAnchorMonthlyTargetBeforeLiving
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
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

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
        /// 月累计抖音发布条数
        /// </summary>
        public int CumulativeTikTokRelease { get; set; }

        /// <summary>
        /// 抖音发布目标完成率
        /// </summary>
        public decimal TikTokReleaseCompleteRate { get; set; }

        /// <summary>
        /// 抖音投流费用目标
        /// </summary>
        public decimal TikTokFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计抖音投流费用
        /// </summary>

        public decimal CumulativeTikTokFlowinvestment { get; set; }
        /// <summary>
        /// 抖音投流费用完成率
        /// </summary>
        public decimal TikTokFlowinvestmentCompleteRate { get; set; }

        /// <summary>
        /// 知乎发布目标
        /// </summary>
        public int ZhihuReleaseTarget { get; set; }

        /// <summary>
        /// 月累计知乎发布条数
        /// </summary>
        public int CumulativeZhihuRelease { get; set; }

        /// <summary>
        /// 知乎发布目标完成率
        /// </summary>
        public decimal ZhihuReleaseCompleteRate { get; set; }

        /// <summary>
        /// 知乎投流费用目标
        /// </summary>
        public decimal ZhihuFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计知乎投流费用
        /// </summary>

        public decimal CumulativeZhihuFlowinvestment { get; set; }
        /// <summary>
        /// 知乎投流费用完成率
        /// </summary>
        public decimal ZhihuFlowinvestmentCompleteRate { get; set; }


        /// <summary>
        /// 小红书发布目标
        /// </summary>
        public int XiaoHongShuReleaseTarget { get; set; }

        /// <summary>
        /// 月累计小红书发布条数
        /// </summary>
        public int CumulativeXiaoHongShuRelease { get; set; }

        /// <summary>
        /// 小红书发布目标完成率
        /// </summary>
        public decimal XiaoHongShuReleaseCompleteRate { get; set; }
        /// <summary>
        /// 小红书投流费用目标
        /// </summary>
        public decimal XiaoHongShuFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计小红书投流费用
        /// </summary>

        public decimal CumulativeXiaoHongShuFlowinvestment { get; set; }
        /// <summary>
        /// 小红书投流费用完成率
        /// </summary>
        public decimal XiaoHongShuFlowinvestmentCompleteRate { get; set; }


        /// <summary>
        /// 微博发布目标
        /// </summary>
        public int SinaWeiBoReleaseTarget { get; set; }

        /// <summary>
        /// 月累计微博发布条数
        /// </summary>
        public int CumulativeSinaWeiBoRelease { get; set; }

        /// <summary>
        /// 微博发布目标完成率
        /// </summary>
        public decimal SinaWeiBoReleaseCompleteRate { get; set; }
        /// <summary>
        /// 微博投流费用目标
        /// </summary>
        public decimal SinaWeiBoFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计微博投流费用
        /// </summary>

        public decimal CumulativeSinaWeiBoFlowinvestment { get; set; }
        /// <summary>
        /// 微博投流费用完成率
        /// </summary>
        public decimal SinaWeiBoFlowinvestmentCompleteRate { get; set; }



        /// <summary>
        /// 视频号发布目标
        /// </summary>
        public int VideoReleaseTarget { get; set; }

        /// <summary>
        /// 月累计视频号发布条数
        /// </summary>
        public int CumulativeVideoRelease { get; set; }

        /// <summary>
        /// 视频号发布目标完成率
        /// </summary>
        public decimal VideoReleaseCompleteRate { get; set; }
        /// <summary>
        /// 视频号投流费用目标
        /// </summary>
        public decimal VideoFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计视频号投流费用
        /// </summary>

        public decimal CumulativeVideoFlowinvestment { get; set; }
        /// <summary>
        /// 视频号投流费用完成率
        /// </summary>
        public decimal VideoFlowinvestmentCompleteRate { get; set; }

        /// <summary>
        /// 月发布目标
        /// </summary>
        public int ReleaseTarget { get; set; }

        /// <summary>
        /// 月累计发布条数
        /// </summary>
        public int CumulativeRelease { get; set; }

        /// <summary>
        /// 发布目标完成率
        /// </summary>
        public decimal ReleaseCompleteRate { get; set; }

        /// <summary>
        /// 运营渠道投流目标
        /// </summary>
        public decimal FlowInvestmentTarget { get; set; }

        /// <summary>
        /// 月累计运营渠道投流数量
        /// </summary>
        public decimal CumulativeFlowInvestment { get; set; }

        /// <summary>
        /// 投流完成率
        /// </summary>
        public decimal FlowInvestmentCompleteRate { get; set; }
        public LiveAnchor LiveAnchor { get; set; }

        public List<BeforeLivingTikTokDailyTarget> beforeLivingTikTokDailyTragets { get; set; }
        public List<BeforeLivingXiaoHongShuDailyTarget> beforeLivingXiaoHongShuDailyTraget { get; set; }
        public List<BeforeLivingZhiHuDailyTarget> beforeLivingZhiHuDailyTraget { get; set; }
        public List<BeforeLivingVideoDailyTarget> beforeLivingVideoDailyTarget { get; set; }
        public List<BeforeLivingSinaWeiBoDailyTarget> beforeLivingSinaWeiBoDailyTarget { get; set; }
    }
}
