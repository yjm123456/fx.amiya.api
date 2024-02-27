using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.NewBusinessDashboard
{
    public class LivingBrokenDataVo
    {
        /// <summary>
        /// 下单GMV
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> OrderGMVData { get; set; }
        /// <summary>
        /// 退单GMV
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> RefundGMVData { get; set; }
        /// <summary>
        /// 实际回款
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> ActualReturnBackMoneyData { get; set; }
        /// <summary>
        /// 直播付费
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> InvestFlowData { get; set; }
    }
}
