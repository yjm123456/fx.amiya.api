using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class BeforeLiveClueAndPerformanceBrokenDataDto
    {
        /// <summary>
        /// 线索数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> ClueData { get; set; }
        /// <summary>
        /// 总业绩数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> PerformanceData { get; set; }
        /// <summary>
        /// 新客业绩数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> NewCustomerPerformanceData { get; set; }
        /// <summary>
        /// 老客业绩数据
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> OldCustomerPerformanceData { get; set; }
    }
}
