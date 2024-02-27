using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class LivingBrokenDataDto
    {
        /// <summary>
        /// 下单GMV
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> OrderGMVData { get; set; }
        /// <summary>
        /// 退单GMV
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> RefundGMVData { get; set; }
        /// <summary>
        /// 实际回款
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> ActualReturnBackMoneyData { get; set; }
        /// <summary>
        /// 直播付费
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> InvestFlowData { get; set; }
    }
}
