using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class BeforeLiveClueAndPerformanceBrokenDataVo
    {
        /// <summary>
        /// 线索数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> ClueData { get; set; }
        /// <summary>
        /// 业绩数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> PerformanceData { get; set; }
    }
}
