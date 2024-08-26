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
        public List<PerformanceBrokenLineListInfoDto> NewCustomerPerformance { get; set; }
        public List<PerformanceBrokenLineListInfoDto> OldCustomerPerformance { get; set; }
    }
}
