using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class AdminCustomerServiceCustomerTypeBrokenLineDataDto
    {
        /// <summary>
        /// 一类客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> FirstType { get; set; }
        /// <summary>
        /// 二类客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> SencondType { get; set; }
        /// <summary>
        /// 三类客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> ThirdType { get; set; }
        /// <summary>
        /// 总客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> TotalType { get; set; }
    }
}
