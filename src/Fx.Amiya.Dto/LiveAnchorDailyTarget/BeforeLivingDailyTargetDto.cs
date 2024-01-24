using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorDailyTarget
{
    public class BeforeLivingDailyTargetDto : BaseDto
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public string LiveAnchor { get; set; }

        public int OperationEmpId { get; set; }

        public string OperationEmpName { get; set; }

        public decimal FlowInvestmentNum { get; set; }
        /// <summary>
        /// 投流费用目标
        /// </summary>
        public decimal FlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计投流费用
        /// </summary>

        public decimal CumulativeFlowinvestment { get; set; }
        /// <summary>
        /// 投流费用完成率
        /// </summary>
        public string FlowinvestmentCompleteRate { get; set; }

        /// <summary>
        /// 今日抖音橱窗收入
        /// </summary>
        public decimal TikTokShowcaseIncome { get; set; }
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

        public string TikTokShowcaseIncomeCompleteRate { get; set; }
        /// <summary>
        /// 运营渠道投流费用
        /// </summary>
        public decimal OperationFlowInvestmentNum { get; set; }
        /// <summary>
        /// 运营渠道投流费用目标
        /// </summary>
        public decimal OperationFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计运营渠道投流费用
        /// </summary>

        public decimal CumulativeOperationFlowinvestment { get; set; }
        /// <summary>
        /// 运营渠道投流费用完成率
        /// </summary>
        public string OperationFlowinvestmentCompleteRate { get; set; }

        public int SendNum { get; set; }


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
        public string ReleaseCompleteRate { get; set; }

        /// <summary>
        /// 今日总发布
        /// </summary>
        public int TodayAllSendNum { get; set; }
        /// <summary>
        /// 月总发布目标
        /// </summary>
        public int MonthlyAllSendTarget { get; set; }
        /// <summary>
        /// 累计总发布数
        /// </summary>
        public int CumulativeMonthlyAllSendNum { get; set; }
        /// <summary>
        /// 总发布完成率
        /// </summary>
        public string MonthlyAllSendNumCompleteRate { get; set; }

        /// <summary>
        /// 今日加V量
        /// </summary>
        public int AddWechatNum { get; set; }

        /// <summary>
        /// 派单量
        /// </summary>
        public int SendOrderNum { get; set; }

        /// <summary>
        /// 成交人数
        /// </summary>
        public int DealNum { get; set; }
        /// <summary>
        /// 今日业绩
        /// </summary>

        public decimal PerformanceNum { get; set; }

        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 今日涨粉
        /// </summary>
        public int IncreaseFans { get; set; }
        
        /// <summary>
        /// 抖音今日涨粉
        /// </summary>
        public int TikTokIncreaseFans { get; set; }
        /// <summary>
        /// 小红书今日涨粉
        /// </summary>
        public int XiaoHongShuIncreaseFans { get; set; }
        /// <summary>
        /// 视频号今日涨粉
        /// </summary>
        public int VideoIncreaseFans { get; set; }
        /// <summary>
        /// 今日涨粉费用
        /// </summary>
        public decimal IncreaseFansFees { get; set; }
        /// <summary>
        /// 抖音今日涨粉费用
        /// </summary>
        public decimal TikTokIncreaseFansFees { get; set; }
        /// <summary>
        /// 小红书今日涨粉费用
        /// </summary>
        public decimal XiaoHongShuIncreaseFansFees { get; set; }
        /// <summary>
        /// 视频号今日涨粉费用
        /// </summary>
        public decimal VideoIncreaseFansFees { get; set; }
        /// <summary>
        /// 今日线索量
        /// </summary>
        public int Clues { get; set; }
        /// <summary>
        /// 抖音今日线索量
        /// </summary>
        public int TikTokClues { get; set; }
        /// <summary>
        /// 小红书今日线索量
        /// </summary>
        public int XiaoHongShuClues { get; set; }
        /// <summary>
        /// 视频号今日线索量
        /// </summary>
        public int VideoClues { get; set; }
        /// <summary>
        /// 涨粉成本
        /// </summary>
        public decimal IncreaseFansFeesCost { get; set; }
        /// <summary>
        /// 抖音涨粉成本
        /// </summary>
        public decimal TikTokIncreaseFansFeesCost { get; set; }
        /// <summary>
        /// 小红书涨粉成本
        /// </summary>
        public decimal XiaoHongShuIncreaseFansFeesCost { get; set; }
        /// <summary>
        /// 视频号涨粉成本
        /// </summary>
        public decimal VideoIncreaseFansFeesCost { get; set; }
        /// <summary>
        /// 今日小红书橱窗收入
        /// </summary>
        public decimal XiaoHongShuShowcaseIncome { get; set; }
        /// <summary>
        /// 视频号橱窗收入
        /// </summary>
        public decimal VideoShowcaseIncome { get; set; }
        /// <summary>
        /// 今日橱窗付费
        /// </summary>
        public decimal ShowCaseFee { get; set; }
        /// <summary>
        /// 抖音今日橱窗付费
        /// </summary>
        public decimal TikTokShowCaseFee { get; set; }
        /// <summary>
        /// 视频号今日橱窗付费
        /// </summary>
        public decimal XiaoHongShuShowCaseFee { get; set; }
        /// <summary>
        /// 视频号今日橱窗付费
        /// </summary>
        public decimal VideoShowCaseFee { get; set; }

    }
}
