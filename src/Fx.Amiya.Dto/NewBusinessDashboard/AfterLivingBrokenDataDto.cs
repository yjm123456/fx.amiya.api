using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class AfterLivingBrokenDataDto
    {
        /// <summary>
        /// 总业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> TotalPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> NewCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> OldCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 有效业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> EffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 潜在业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> PotentialPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客有效业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> NewCustomerEffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客潜在业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> NewCustomerPotentialPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客有效业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> OldCustomerEffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客潜在业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> OldCustomerPotentialPerformanceBrokenLineList { get; set; }

    }
}
