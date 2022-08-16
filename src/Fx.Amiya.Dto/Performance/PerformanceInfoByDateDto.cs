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
        public DateTime Date { get; set; }
        //业绩
        public decimal PerfomancePrice { get; set; }
    }
}
