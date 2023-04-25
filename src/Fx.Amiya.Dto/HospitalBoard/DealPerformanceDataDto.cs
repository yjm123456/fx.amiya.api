using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalBoard
{
    /// <summary>
    /// 成交看板业绩数据
    /// </summary>
    public class DealPerformanceDataDto
    {
        public decimal TotalPerformance { get; set; }
        public decimal NewCustomerPerformance { get; set; }
        public decimal OldCustomerPerformance { get; set; }
    }
}
