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
        public List<PerformanceBrokenLineListInfoDto> OrderGMVData { get; set; }
        /// <summary>
        /// 退单GMV
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> RefundGMVData { get; set; }
        /// <summary>
        /// 实际回款
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> ActualReturnBackMoneyData { get; set; }
        /// <summary>
        /// 直播付费
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> InvestFlowData { get; set; }
    }
}
