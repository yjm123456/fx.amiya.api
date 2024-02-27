using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.NewBusinessDashboard
{
    public class BeforeLivingBrokenDataVo
    {
        /// <summary>
        /// 涨粉量趋势数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo>  IncreaseFansData{ get; set; }
        /// <summary>
        /// 橱窗收入趋势数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> ShowcaseIncomeData { get; set; }
        /// <summary>
        /// 涨粉付费趋势
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> IncreaseFansFeeData { get; set; }
        /// <summary>
        /// 橱窗付费趋势
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> ShowcaseFeeDta { get; set; }

    }
}
