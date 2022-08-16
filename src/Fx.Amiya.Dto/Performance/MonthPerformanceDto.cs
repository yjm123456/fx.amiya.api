using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class MonthPerformanceDto
    {
        /// <summary>
        /// 本月总业绩
        /// </summary>
        public decimal CueerntMonthTotalPerformance { get; set; }
        /// <summary>
        /// 同比总业绩
        /// </summary>
        public decimal PerformanceYearOnYear { get; set; }
        /// <summary>
        /// 环比总业绩
        /// </summary>
        public decimal PerformanceChainRatio { get; set; }
        /// <summary>
        /// 本月带货总业绩
        /// </summary>
        public decimal CurrentMonthCommercePerformance { get; set; }
        /// <summary>
        /// 同比带货业绩
        /// </summary>
        public decimal CommercePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 环比带货业绩
        /// </summary>
        public decimal CommercePerformanceChainRation { get; set; }
        /// <summary>
        /// 当前月老客业绩
        /// </summary>
        public decimal CurrentMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 当前月新客业绩
        /// </summary>
        public decimal CurrentMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客同比
        /// </summary>
        public decimal OldCustomerYearOnYear { get; set; }
        /// <summary>
        /// 老客环比
        /// </summary>
        public decimal OldCustomerChainRation { get; set; }
        /// <summary>
        /// 新客同比
        /// </summary>
        public decimal NewCustomerYearOnYear { get; set; }
        /// <summary>
        /// 新客环比
        /// </summary>
        public decimal NewCustomerChainRatio { get; set; }
    }
}
