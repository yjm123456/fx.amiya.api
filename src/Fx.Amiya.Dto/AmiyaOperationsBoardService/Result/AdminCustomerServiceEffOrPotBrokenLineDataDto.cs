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
        /// 直播前客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> BeforeLivingData { get; set; }
        /// <summary>
        /// 直播中客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> LivingData { get; set; }
        /// <summary>
        /// 直播后客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> AfterLivingData { get; set; }

        /// <summary>
        /// 总客资
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> Total { get; set; }
    }
}
