using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class BeforeLivingBusinessDataDto
    {
        /// <summary>
        /// 涨粉量
        /// </summary>
        public int IncreaseFans { get; set; }
        /// <summary>
        /// 涨粉量对比时间进度
        /// </summary>
        public decimal IncreaseFansToDateSchedule { get; set; }
        /// <summary>
        /// 涨粉量目标
        /// </summary>
        public int IncreaseFansTarget { get; set; }
        /// <summary>
        /// 涨粉量目标达成率
        /// </summary>
        public decimal? IncreaseFansTargetCompleteRate { get; set; }
        /// <summary>
        /// 涨粉量环比
        /// </summary>
        public decimal? IncreaseFansChainRatio { get; set; }
        /// <summary>
        /// 涨粉量同比
        /// </summary>
        public decimal? IncreaseFansYearOnYear { get; set; }
        /// <summary>
        /// 涨粉付费
        /// </summary>
        public decimal IncreaseFansFees { get; set; }
        /// <summary>
        /// 涨粉付费对比时间进度
        /// </summary>
        public decimal IncreaseFansFeesToDateSchedule { get; set; }
        /// <summary>
        /// 涨粉付费目标
        /// </summary>
        public decimal IncreaseFansFeesTarget { get; set; }
        /// <summary>
        /// 涨粉付费目标达成率
        /// </summary>
        public decimal? IncreaseFansFeesTargetCompleteRate { get; set; }
        /// <summary>
        /// 涨粉付费环比
        /// </summary>
        public decimal? IncreaseFansFeesChainRatio { get; set; }
        /// <summary>
        /// 涨粉付费同比
        /// </summary>
        public decimal? IncreaseFansFeesYearOnYear { get; set; }
        /// <summary>
        /// 涨粉成本
        /// </summary>
        public decimal IncreaseFansFeesCost
        {
            get
            {
                if (IncreaseFans <= 0)
                {
                    return IncreaseFansFees;
                }
                else
                {
                    return Math.Round(IncreaseFansFees / IncreaseFans, 2);
                }

            }
        }
        /// <summary>
        /// 涨粉成本对比时间进度
        /// </summary>
        public decimal IncreaseFansFeesCostToDateSchedule { get; set; }
        /// <summary>
        /// 涨粉成本目标
        /// </summary>
        public decimal IncreaseFansFeesCostTarget { get; set; }
        /// <summary>
        /// 涨粉成本目标达成率
        /// </summary>
        public decimal? IncreaseFansFeesCostTargetCompleteRate { get; set; }
        /// <summary>
        /// 涨粉成本环比
        /// </summary>
        public decimal? IncreaseFansFeesCostChainRatio { get; set; }
        /// <summary>
        /// 涨粉成本同比
        /// </summary>
        public decimal? IncreaseFansFeesCostYearOnYear { get; set; }
        /// <summary>
        /// 橱窗收入
        /// </summary>
        public decimal ShowcaseIncome { get; set; }
        /// <summary>
        /// 橱窗收入对比时间进度
        /// </summary>
        public decimal ShowcaseIncomeToDateSchedule { get; set; }
        /// <summary>
        /// 橱窗收入目标
        /// </summary>
        public decimal ShowcaseIncomeTarget { get; set; }
        /// <summary>
        /// 橱窗收入目标达成率
        /// </summary>
        public decimal? ShowcaseIncomeTargetCompleteRate { get; set; }
        /// <summary>
        /// 橱窗收入环比
        /// </summary>
        public decimal? ShowcaseIncomeChainRatio { get; set; }
        /// <summary>
        /// 橱窗收入同比
        /// </summary>
        public decimal? ShowcaseIncomeYearOnYear { get; set; }
        /// <summary>
        /// 橱窗付费
        /// </summary>
        public decimal ShowcaseFee { get; set; }
        /// <summary>
        /// 橱窗付费对比时间进度
        /// </summary>
        public decimal ShowcaseFeeToDateSchedule { get; set; }
        /// <summary>
        /// 橱窗付费目标
        /// </summary>
        public decimal ShowcaseFeeTarget { get; set; }
        /// <summary>
        /// 橱窗付费目标达成率
        /// </summary>
        public decimal? ShowcaseFeeTargetCompleteRate { get; set; }
        /// <summary>
        /// 橱窗付费环比
        /// </summary>
        public decimal? ShowcaseFeeChainRatio { get; set; }
        /// <summary>
        /// 橱窗付费同比
        /// </summary>
        public decimal? ShowcaseFeeYearOnYear { get; set; }
        /// <summary>
        /// 线索量
        /// </summary>
        public int Clues { get; set; }
        /// <summary>
        /// 线索量对比时间进度
        /// </summary>
        public decimal CluesToDateSchedule { get; set; }
        /// <summary>
        /// 线索量目标
        /// </summary>
        public int CluesTarget { get; set; }
        /// <summary>
        /// 线索量目标达成率
        /// </summary>
        public decimal? CluesTargetCompleteRate { get; set; }
        /// <summary>
        /// 线索量环比
        /// </summary>
        public decimal? CluesChainRatio { get; set; }
        /// <summary>
        /// 线索量同比
        /// </summary>
        public decimal? CluesYearOnYear { get; set; }
        /// <summary>
        /// 发布量
        /// </summary>

        public int SendNum { get; set; }
        /// <summary>
        /// 发布量对比时间进度
        /// </summary>
        public decimal SendNumToDateSchedule { get; set; }
        /// <summary>
        /// 发布量目标
        /// </summary>
        public int SendNumTarget { get; set; }
        /// <summary>
        /// 发布量目标达成率
        /// </summary>
        public decimal? SendNumTargetCompleteRate { get; set; }
        /// <summary>
        /// 发布量环比
        /// </summary>
        public decimal? SendNumChainRatio { get; set; }
        /// <summary>
        /// 发布量同比
        /// </summary>
        public decimal? SendNumYearOnYear { get; set; }
    }
}
