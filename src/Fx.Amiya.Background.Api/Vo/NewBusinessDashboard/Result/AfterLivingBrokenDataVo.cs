using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.NewBusinessDashboard.Result
{
    public class AfterLivingBrokenDataVo
    {
        /// <summary>
        /// 总业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> TotalPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> NewCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> OldCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 有效业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> EffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 潜在业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> PotentialPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客有效业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> NewCustomerEffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客潜在业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> NewCustomerPotentialPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客有效业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> OldCustomerEffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客潜在业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> OldCustomerPotentialPerformanceBrokenLineList { get; set; }
    }
}
