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
        /// 总业绩数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> PerformanceData { get; set; }
        /// <summary>
        /// 新客业绩数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> NewCustomerPerformanceData { get; set; }
        /// <summary>
        /// 老客业绩数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> OldCustomerPerformanceData { get; set; }
    }
}
