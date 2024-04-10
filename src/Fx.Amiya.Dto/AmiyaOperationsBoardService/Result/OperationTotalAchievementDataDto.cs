using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService
{
    public class OperationTotalAchievementDataDto
    {
        /// <summary>
        /// 时间进度
        /// </summary>
        public decimal DateSchedule { get; set; }

        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalAchievement { get; set; }
        /// <summary>
        /// 总业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> TotalPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> NewCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> OldCustomerPerformanceBrokenLineList { get; set; }
    }
}
