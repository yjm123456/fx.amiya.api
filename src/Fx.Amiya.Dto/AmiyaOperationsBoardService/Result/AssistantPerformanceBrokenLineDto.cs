using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class AssistantPerformanceBrokenLineDto
    {
        /// <summary>
        /// 新客业绩
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> OldCustomerPerformance { get; set; }
        /// <summary>
        /// 总业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> TotalPerformance { get; set; }
    }
}
