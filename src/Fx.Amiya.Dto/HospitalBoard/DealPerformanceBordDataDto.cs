using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalBoard
{
    public class DealPerformanceBordDataDto
    {
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal? TotalPerformanceChainRatio { get; set; }
        /// <summary>
        /// 总业绩同比
        /// </summary>
        public decimal? TotalPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal? NewCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 新客业绩同比
        /// </summary>
        public decimal? NewCustomerPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal? OldCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal? OldCustomerPerformanceYearOnYear{ get; set; }
    }
}
