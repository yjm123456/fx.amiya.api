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
        /// 有效客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> Effective { get; set; }
        /// <summary>
        /// 潜在客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> Potential { get; set; }

        /// <summary>
        /// 总客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> Total { get; set; }
    }
}
