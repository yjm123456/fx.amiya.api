using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class AdminCustomerServiceEffOrPotBrokenLineDataDto
    {
        /// <summary>
        /// 有效客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> Effective { get; set; }
        /// <summary>
        /// 潜在客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> Potential { get; set; }
       
        /// <summary>
        /// 总客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> Total { get; set; }
    }
}
