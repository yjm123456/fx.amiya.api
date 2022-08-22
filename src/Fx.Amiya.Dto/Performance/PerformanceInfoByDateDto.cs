using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class PerformanceInfoByDateDto
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        //业绩
        public decimal PerfomancePrice { get; set; }
    }

    /// <summary>
    /// 折线图数据
    /// </summary>
    public class PerformanceBrokenLine
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        //业绩
        public decimal PerfomancePrice { get; set; }
    }
    public class PerformanceInfoDateDto
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }
        //业绩
        public decimal PerfomancePrice { get; set; }
    }
}
