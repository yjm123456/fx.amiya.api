using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AdminCustomerServiceCustomerTypeBrokenLineDataVo
    {
        /// <summary>
        /// 一类客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> FirstType { get; set; }
        /// <summary>
        /// 二类客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> SencondType { get; set; }
        /// <summary>
        /// 三类客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> ThirdType { get; set; }
        /// <summary>
        /// 总客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> TotalType { get; set; }
    }
}
