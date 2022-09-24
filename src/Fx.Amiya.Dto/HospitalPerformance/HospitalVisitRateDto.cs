using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalPerformance
{
    /// <summary>
    /// 机构上门率
    /// </summary>
    public class HospitalVisitRateDto
    {
        public string Date { get; set; }
        public int SendOrderNum { get; set; }
        public int VisitNum { get; set; }

        public decimal PerfomancePrice { get; set; }
    }

    /// <summary>
    /// 机构新客成交率
    /// </summary>
    public class HospitalDealRateDto
    {
        public string Date { get; set; }
        public int VisitNum { get; set; }
        public int DealNum { get; set; }

        public decimal PerfomancePrice { get; set; }
    }
    /// <summary>
    /// 机构新/老客客单价
    /// </summary>
    public class HospitalUnitPriceDto
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 成交业绩
        /// </summary>
        public decimal CustomerPerformance { get; set; }
        /// <summary>
        /// 成交人数
        /// </summary>
        public int CustomerDealNum { get; set; }
        /// <summary>
        /// 成交客单价
        /// </summary>

        public decimal PerfomancePrice { get; set; }
    }
}
