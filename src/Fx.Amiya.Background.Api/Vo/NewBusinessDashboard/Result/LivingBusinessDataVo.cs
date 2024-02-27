using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.NewBusinessDashboard
{
    public class LivingBusinessDataVo
    {
        /// <summary>
        /// 下单GMV
        /// </summary>
        public decimal OrderGMV { get; set; }
        /// <summary>
        /// 下单GMV对比时间进度
        /// </summary>
        public decimal OrderGMVToDateSchedule { get; set; }
        /// <summary>
        /// 下单GMV目标
        /// </summary>
        public decimal OrderGMVTarget { get; set; }
        /// <summary>
        /// 下单GMV目标达成率
        /// </summary>
        public decimal? OrderGMVTargetCompleteRate { get; set; }
        /// <summary>
        /// 下单GMV环比
        /// </summary>
        public decimal? OrderGMVChainRatio { get; set; }
        /// <summary>
        /// 下单GMV同比
        /// </summary>
        public decimal? OrderGMVYearOnYear { get; set; }
        /// <summary>
        /// 退款GMV
        /// </summary>
        public decimal RefundGMV { get; set; }
        /// <summary>
        /// 退款GMV对比时间进度
        /// </summary>
        public decimal RefundGMVToDateSchedule { get; set; }
        /// <summary>
        /// 退款GMV目标
        /// </summary>
        public decimal RefundGMVTarget { get; set; }
        /// <summary>
        /// 退款GMV目标达成率
        /// </summary>
        public decimal? RefundGMVTargetCompleteRate { get; set; }
        /// <summary>
        /// 退款GMV环比
        /// </summary>
        public decimal? RefundGMVChainRatio { get; set; }
        /// <summary>
        /// 退款GMV同比
        /// </summary>
        public decimal? RefundGMVYearOnYear { get; set; }
        /// <summary>
        /// 实际回款
        /// </summary>
        public decimal ActualReturnBackMoney { get; set; }
        /// <summary>
        /// 实际回款对比时间进度
        /// </summary>
        public decimal ActualReturnBackMoneyToDateSchedule { get; set; }
        /// <summary>
        /// 实际回款目标
        /// </summary>
        public decimal ActualReturnBackMoneyTarget { get; set; }
        /// <summary>
        /// 实际回款目标达成率
        /// </summary>
        public decimal? ActualReturnBackMoneyTargetCompleteRate { get; set; }
        /// <summary>
        /// 实际回款环比
        /// </summary>
        public decimal? ActualReturnBackMoneyChainRatio { get; set; }
        /// <summary>
        /// 实际回款同比
        /// </summary>
        public decimal? ActualReturnBackMoneyYearOnYear { get; set; }
        /// <summary>
        /// 直播付费
        /// </summary>
        public decimal InvestFlow { get; set; }
        /// <summary>
        /// 直播付费对比时间进度
        /// </summary>
        public decimal InvestFlowToDateSchedule { get; set; }
        /// <summary>
        /// 直播付费目标
        /// </summary>
        public decimal InvestFlowTarget { get; set; }
        /// <summary>
        /// 直播付费目标达成率
        /// </summary>
        public decimal? InvestFlowTargetCompleteRate { get; set; }
        /// <summary>
        /// 直播付费环比
        /// </summary>
        public decimal? InvestFlowChainRatio { get; set; }
        /// <summary>
        /// 直播付费同比
        /// </summary>
        public decimal? InvestFlowYearOnYear { get; set; }
    }
}
