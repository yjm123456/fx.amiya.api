using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class PerformanceScheduleDto
    {
        /// <summary>
        /// 对比时间进度
        /// </summary>
        public decimal ContrastTimeSchedule { get; set; }
        /// <summary>
        /// 对比时间进度业绩偏差
        /// </summary>
        public decimal PerformanceDeviation { get; set; }
        /// <summary>
        /// 距目标完成后期后期每天需完成数据
        /// </summary>
        public decimal ResidueTimeNeedCompletePerformance { get; set; }
    }
}
