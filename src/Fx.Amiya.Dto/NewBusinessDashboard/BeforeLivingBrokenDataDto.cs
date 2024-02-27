using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class BeforeLivingBrokenDataDto
    {
        /// <summary>
        /// 涨粉量趋势数据
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> IncreaseFansData { get; set; }
        /// <summary>
        /// 橱窗收入趋势数据
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> ShowcaseIncomeData { get; set; }
        /// <summary>
        /// 涨粉付费趋势
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> IncreaseFansFeeData { get; set; }
        /// <summary>
        /// 橱窗付费趋势
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> ShowcaseFeeDta { get; set; }
    }
}
