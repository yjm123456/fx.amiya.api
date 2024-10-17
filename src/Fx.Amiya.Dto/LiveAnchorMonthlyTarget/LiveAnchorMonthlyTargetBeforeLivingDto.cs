using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class LiveAnchorMonthlyTargetBeforeLivingDto
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
        /// 主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }

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
        /// 抖音橱窗收入目标
        /// </summary>
        public decimal TikTokShowcaseIncomeTarget { get; set; }

        /// <summary>
        /// 累计抖音橱窗收入
        /// </summary>

        public decimal CumulativeTikTokShowcaseIncome { get; set; }
        /// <summary>
        /// 抖音橱窗收入完成率
        /// </summary>
        public decimal TikTokShowcaseIncomeCompleteRate { get; set; }

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
        /// <summary>
        /// 主播归属平台id
        /// </summary>
        public string ContentPlatFormId { get; set; }
        /// <summary>
        /// 抖音涨粉目标
        /// </summary>

        public int TikTokIncreaseFansTarget { get; set; }
        /// <summary>
        /// 抖音涨粉累计
        /// </summary>

        public int CumulativeTikTokIncreaseFans { get; set; }
        /// <summary>
        /// 抖音涨粉目标完成率
        /// </summary>

        public decimal TikTokIncreaseFanseCompleteRate { get; set; }
        /// <summary>
        /// 抖音涨粉付费目标
        /// </summary>
        public decimal TikTokIncreaseFansFeesTarget { get; set; }
        /// <summary>
        /// 抖音涨粉付费累计
        /// </summary>

        public decimal CumulativeTikTokIncreaseFansFees { get; set; }
        /// <summary>
        /// 抖音涨粉付费目标完成率
        /// </summary>

        public decimal TikTokIncreaseFansFeesCompleteRate { get; set; }
        /// <summary>
        /// 抖音涨粉成本目标
        /// </summary>
        public decimal TikTokIncreaseFansFeesCostTarget
        {
            get
            {
                if (TikTokIncreaseFansFeesTarget == 0 || TikTokIncreaseFansTarget == 0)
                {
                    return 0;
                }
                return Math.Round(TikTokIncreaseFansFeesTarget / TikTokIncreaseFansTarget, 2);
            }
        }
        /// <summary>
        /// 抖音涨粉成本累计
        /// </summary>

        public decimal CumulativeTikTokIncreaseFansFeesCost
        {
            get
            {
                if (CumulativeTikTokIncreaseFans <= 0)
                {
                    return CumulativeTikTokIncreaseFansFees;
                }
                else
                {
                    return Math.Round(CumulativeTikTokIncreaseFansFees / CumulativeTikTokIncreaseFans, 2);
                }

            }
        }
        /// <summary>
        /// 抖音涨粉成本完成率
        /// </summary>

        public decimal TikTokIncreaseFansFeesCostCompleteRate
        {
            get
            {

                decimal cumulative = 0;
                if (CumulativeTikTokIncreaseFans <= 0)
                {
                    cumulative = CumulativeTikTokIncreaseFansFees;
                }
                else
                {
                    cumulative = Math.Round(CumulativeTikTokIncreaseFansFees / Convert.ToDecimal(CumulativeTikTokIncreaseFans), 2);
                }
                if (TikTokIncreaseFansFeesCostTarget == 0)
                {
                    return 0;
                }
                return Math.Round((cumulative / TikTokIncreaseFansFeesCostTarget) * 100, 2);
            }
        }
        /// <summary>
        /// 抖音线索量目标
        /// </summary>
        public decimal TikTokCluesTarget { get; set; }
        /// <summary>
        /// 抖音线索累计
        /// </summary>

        public int CumulativeTikTokClues { get; set; }
        /// <summary>
        /// 抖音线索目标完成率
        /// </summary>

        public decimal TikTokCluesCompleteRate { get; set; }
        /// <summary>
        /// 小红书涨粉目标
        /// </summary>

        public int XiaoHongShuIncreaseFansTarget { get; set; }
        /// <summary>
        /// 小红书涨粉累计
        /// </summary>

        public int CumulativeXiaoHongShuIncreaseFans { get; set; }
        /// <summary>
        /// 小红书涨粉目标完成率
        /// </summary>

        public decimal XiaoHongShuIncreaseFanseCompleteRate { get; set; }
        /// <summary>
        /// 小红书涨粉付费目标
        /// </summary>
        public decimal XiaoHongShuIncreaseFansFeesTarget { get; set; }
        /// <summary>
        /// 小红书涨粉付费累计
        /// </summary>

        public decimal CumulativeXiaoHongShuIncreaseFansFees { get; set; }
        /// <summary>
        /// 小红书涨粉付费目标完成率
        /// </summary>

        public decimal XiaoHongShuIncreaseFansFeesCompleteRate { get; set; }
        /// <summary>
        /// 小红书涨粉成本目标
        /// </summary>
        public decimal XiaoHongShuIncreaseFansFeesCostTarget
        {
            get
            {
                if (XiaoHongShuIncreaseFansFeesTarget == 0 || XiaoHongShuIncreaseFansTarget == 0)
                {
                    return 0;
                }
                return Math.Round(XiaoHongShuIncreaseFansFeesTarget / XiaoHongShuIncreaseFansTarget, 2);
            }
        }
        /// <summary>
        /// 小红书涨粉成本累计
        /// </summary>

        public decimal CumulativeXiaoHongShuIncreaseFansFeesCost
        {
            get
            {
                if (CumulativeXiaoHongShuIncreaseFans <= 0)
                {
                    return CumulativeXiaoHongShuIncreaseFansFees;
                }
                else
                {
                    return Math.Round(CumulativeXiaoHongShuIncreaseFansFees / CumulativeXiaoHongShuIncreaseFans, 2);
                }

            }
        }
        /// <summary>
        /// 小红书涨粉成本完成率
        /// </summary>

        public decimal XiaoHongShuIncreaseFansFeesCostCompleteRate
        {
            get
            {
                decimal cumulative = 0;
                if (CumulativeXiaoHongShuIncreaseFans <= 0)
                {
                    cumulative = CumulativeXiaoHongShuIncreaseFansFees;
                }
                else
                {
                    cumulative = Math.Round(CumulativeXiaoHongShuIncreaseFansFees / CumulativeXiaoHongShuIncreaseFans, 2);
                }
                if (XiaoHongShuIncreaseFansFeesCostTarget == 0)
                {
                    return 0;
                }
                return Math.Round((cumulative / XiaoHongShuIncreaseFansFeesCostTarget) * 100,2);
            }
        }
        /// <summary>
        /// 小红书线索量目标
        /// </summary>
        public decimal XiaoHongShuCluesTarget { get; set; }
        /// <summary>
        /// 小红书线索累计
        /// </summary>

        public int CumulativeXiaoHongShuClues { get; set; }
        /// <summary>
        /// 小红书线索目标完成率
        /// </summary>

        public decimal XiaoHongShuCluesCompleteRate { get; set; }
        /// <summary>
        /// 小红书橱窗收入目标
        /// </summary>
        public decimal XiaoHongShuShowcaseIncomeTarget { get; set; }
        /// <summary>
        /// 小红书橱窗收入累计
        /// </summary>

        public decimal CumulativeXiaoHongShuShowcaseIncome { get; set; }
        /// <summary>
        /// 小红书橱窗收入目标完成率
        /// </summary>

        public decimal XiaoHongShuShowcaseIncomeCompleteRate { get; set; }
        /// <summary>
        /// 视频号涨粉目标
        /// </summary>

        public int VideoIncreaseFansTarget { get; set; }
        /// <summary>
        /// 视频号涨粉累计
        /// </summary>

        public int CumulativeVideoIncreaseFans { get; set; }
        /// <summary>
        /// 视频号涨粉目标完成率
        /// </summary>

        public decimal VideoIncreaseFanseCompleteRate { get; set; }
        /// <summary>
        /// 视频号涨粉付费目标
        /// </summary>
        public decimal VideoIncreaseFansFeesTarget { get; set; }
        /// <summary>
        /// 视频号涨粉付费累计
        /// </summary>

        public decimal CumulativeVideoIncreaseFansFees { get; set; }
        /// <summary>
        /// 视频号涨粉付费目标完成率
        /// </summary>

        public decimal VideoIncreaseFansFeesCompleteRate { get; set; }
        /// <summary>
        /// 视频号涨粉成本目标
        /// </summary>
        public decimal VideoIncreaseFansFeesCostTarget
        {
            get
            {
                if (VideoIncreaseFansFeesTarget == 0 || VideoIncreaseFansTarget == 0)
                {
                    return 0;
                }
                return Math.Round(VideoIncreaseFansFeesTarget / VideoIncreaseFansTarget, 2);
            }
        }
        /// <summary>
        /// 视频号涨粉成本累计
        /// </summary>

        public decimal CumulativeVideoIncreaseFansFeesCost
        {
            get
            {
                if (CumulativeVideoIncreaseFans <= 0)
                {
                    return CumulativeVideoIncreaseFansFees;
                }
                else
                {
                    return Math.Round(CumulativeVideoIncreaseFansFees / CumulativeVideoIncreaseFans, 2);
                }

            }
        }
        /// <summary>
        /// 视频号涨粉成本完成率
        /// </summary>

        public decimal VideoIncreaseFansFeesCostCompleteRate
        {
            get
            {

                decimal cumulative = 0;
                if (CumulativeVideoIncreaseFans <= 0)
                {
                    cumulative = CumulativeVideoIncreaseFansFees;
                }
                else
                {
                    cumulative = Math.Round(CumulativeVideoIncreaseFansFees / Convert.ToDecimal(CumulativeVideoIncreaseFans), 2);
                }
                if (VideoIncreaseFansFeesCostTarget == 0)
                {
                    return 0;
                }
                return Math.Round((cumulative / VideoIncreaseFansFeesCostTarget) * 100, 2);
            }
        }
        /// <summary>
        /// 视频号线索量目标
        /// </summary>
        public decimal VideoCluesTarget { get; set; }
        /// <summary>
        /// 视频号线索累计
        /// </summary>

        public int CumulativeVideoClues { get; set; }
        /// <summary>
        /// 视频号线索目标完成率
        /// </summary>

        public decimal VideoCluesCompleteRate { get; set; }
        /// <summary>
        /// 视频号橱窗收入目标
        /// </summary>
        public decimal VideoShowcaseIncomeTarget { get; set; }
        /// <summary>
        /// 视频号橱窗收入累计
        /// </summary>

        public decimal CumulativeVideoShowcaseIncome { get; set; }
        /// <summary>
        /// 视频号橱窗收入目标完成率
        /// </summary>

        public decimal VideoShowcaseIncomeCompleteRate { get; set; }


        /// <summary>
        /// 抖音橱窗付费目标
        /// </summary>
        public decimal TikTokShowCaseFeeTarget { get; set; }
        /// <summary>
        /// 抖音橱窗付费累计
        /// </summary>

        public decimal CumulativeTikTokShowCaseFee { get; set; }
        /// <summary>
        /// 抖音橱窗付费目标完成率
        /// </summary>

        public decimal TikTokShowCaseFeeCompleteRate { get; set; }


        /// <summary>
        /// 小红书橱窗付费目标
        /// </summary>
        public decimal XiaoHongShuShowCaseFeeTarget { get; set; }
        /// <summary>
        /// 小红书橱窗付费累计
        /// </summary>

        public decimal CumulativeXiaoHongShuShowCaseFee { get; set; }
        /// <summary>
        /// 小红书橱窗付费目标完成率
        /// </summary>

        public decimal XiaoHongShuShowCaseFeeCompleteRate { get; set; }


        /// <summary>
        /// 视频号橱窗付费目标
        /// </summary>
        public decimal VideoShowCaseFeeTarget { get; set; }
        /// <summary>
        /// 视频号橱窗付费累计
        /// </summary>

        public decimal CumulativeVideoShowCaseFee { get; set; }
        /// <summary>
        /// 视频号橱窗付费目标完成率
        /// </summary>

        public decimal VideoShowCaseFeeCompleteRate { get; set; }
        /// <summary>
        /// 负责人id
        /// </summary>
        public int? OwnerId { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string OwnerName { get; set; }
    }
}
