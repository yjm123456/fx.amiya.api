using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class PerformanceRatioDto
    {
        /// <summary>
        /// 业绩名称
        /// </summary>
        public string PerformanceText { get; set; }
        /// <summary>
        /// 业绩金额
        /// </summary>
        public decimal? PerformancePrice { get; set; }
        /// <summary>
        /// 业绩占比
        /// </summary>
        public decimal? PerformanceRatio { get; set; }
    }
}
