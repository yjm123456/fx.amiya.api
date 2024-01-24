using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 当日抖音发布条数
        /// </summary>
        public int CumulativeTikTokRelease { get; set; }

        /// <summary>
        /// 当日抖音投流费用
        /// </summary>

        public decimal CumulativeTikTokFlowinvestment { get; set; }
        /// <summary>
        /// 当日抖音橱窗收入
        /// </summary>
        public decimal CumulativeTikTokShowcaseIncome { get; set; }

        /// <summary>
        /// 抖音涨粉累计
        /// </summary>

        public int CumulativeTikTokIncreaseFans { get; set; }
     
        /// <summary>
        /// 抖音涨粉付费累计
        /// </summary>

        public decimal CumulativeTikTokIncreaseFansFees { get; set; }
    
        
  
        /// <summary>
        /// 抖音线索累计
        /// </summary>

        public int CumulativeTikTokClues { get; set; }


        /// <summary>
        /// 当日小红书橱窗收入
        /// </summary>
        public decimal CumulativeXiaoHongShuShowcaseIncome { get; set; }

        /// <summary>
        /// 小红书涨粉累计
        /// </summary>

        public int CumulativeXiaoHongShuIncreaseFans { get; set; }

        /// <summary>
        /// 小红书涨粉付费累计
        /// </summary>

        public decimal CumulativeXiaoHongShuIncreaseFansFees { get; set; }



        /// <summary>
        /// 小红书线索累计
        /// </summary>

        public int CumulativeXiaoHongShuClues { get; set; }
        /// <summary>
        /// 当日视频号橱窗收入
        /// </summary>
        public decimal CumulativeVideoShowcaseIncome { get; set; }

        /// <summary>
        /// 视频号涨粉累计
        /// </summary>

        public int CumulativeVideoIncreaseFans { get; set; }

        /// <summary>
        /// 视频号涨粉付费累计
        /// </summary>

        public decimal CumulativeVideoIncreaseFansFees { get; set; }



        /// <summary>
        /// 视频号线索累计
        /// </summary>

        public int CumulativeVideoClues { get; set; }

        /// <summary>
        /// 当日视频号发布条数
        /// </summary>
        public int CumulativeVideoRelease { get; set; }
        /// <summary>
        /// 当日视频号投流费用
        /// </summary>

        public decimal CumulativeVideoFlowinvestment { get; set; }

        /// <summary>
        /// 当日知乎发布条数
        /// </summary>
        public int CumulativeZhihuRelease { get; set; }
        /// <summary>
        /// 当日知乎投流费用
        /// </summary>

        public decimal CumulativeZhihuFlowinvestment { get; set; }

        /// <summary>
        /// 当日小红书发布条数
        /// </summary>
        public int CumulativeXiaoHongShuRelease { get; set; }
        /// <summary>
        /// 当日小红书投流费用
        /// </summary>

        public decimal CumulativeXiaoHongShuFlowinvestment { get; set; }

        /// <summary>
        /// 当日微博发布条数
        /// </summary>
        public int CumulativeSinaWeiBoRelease { get; set; }
        /// <summary>
        /// 当日微博投流费用
        /// </summary>
        public decimal CumulativeSinaWeiBoFlowinvestment { get; set; }

        /// <summary>
        /// 当日发布条数
        /// </summary>
        public int CumulativeRelease { get; set; }
        /// <summary>
        /// 当日运营渠道投流数量
        /// </summary>
        public decimal CumulativeFlowInvestment { get; set; }
        /// <summary>
        /// 当日抖音橱窗付费
        /// </summary>
        public decimal CumulativeTikTokShowCaseFee { get; set; }
        /// <summary>
        /// 当日小红书橱窗付费
        /// </summary>
        public decimal CumulativeXiaoHongShuShowCaseFee { get; set; }
        /// <summary>
        /// 当日视频号橱窗付费
        /// </summary>
        public decimal CumulativeVideoShowCaseFee { get; set; }
    }
}
