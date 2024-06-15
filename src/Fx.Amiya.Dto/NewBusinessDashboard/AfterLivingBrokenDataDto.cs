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
        public List<PerformanceBrokenLineListInfoDto> TotalPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> NewCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> OldCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 有效业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> EffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 潜在业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> PotentialPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客有效业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> NewCustomerEffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客潜在业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> NewCustomerPotentialPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客有效业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> OldCustomerEffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客潜在业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> OldCustomerPotentialPerformanceBrokenLineList { get; set; }

    }
}
