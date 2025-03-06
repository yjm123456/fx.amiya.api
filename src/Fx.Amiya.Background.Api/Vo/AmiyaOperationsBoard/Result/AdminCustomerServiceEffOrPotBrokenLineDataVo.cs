using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AdminCustomerServiceEffOrPotBrokenLineDataVo
    {
        /// <summary>
        /// 直播前客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> BeforeLivingData { get; set; }
        /// <summary>
        /// 直播中客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> LivingData { get; set; }
        /// <summary>
        /// 直播后客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> AfterLivingData { get; set; }

        /// <summary>
        /// 总客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> Total { get; set; }
    }
}
