using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalOperation.Result
{
    public class HospitalPerformanceDto
    {
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 今日新客业绩
        /// </summary>
        public decimal TodayNewCustomerPerformance { get; set; }
        /// <summary>
        /// 今日老客业绩
        /// </summary>
        public decimal TodayOldCustomerPerformance { get; set; }
        /// <summary>
        /// 今日总业绩
        /// </summary>
        public decimal TodayTotalPerformance { get; set; }
        /// <summary>
        /// 上期新客业绩
        /// </summary>
        public decimal LastMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 上期老客业绩
        /// </summary>
        public decimal LastMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 上期总业绩
        /// </summary>
        public decimal LastMonthTotalPerformance { get; set; }
        /// <summary>
        /// 同期新客业绩
        /// </summary>
        public decimal LastYearNewCustomerPerformance { get; set; }
        /// <summary>
        /// 同期老客业绩
        /// </summary>
        public decimal LastYearOldCustomerPerformance { get; set; }
        /// <summary>
        /// 同期总业绩
        /// </summary>
        public decimal LastYearTotalPerformance { get; set; }
        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal NewCustomerPerformanceChain { get; set; }
        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal OldCustomerPerformanceChain { get; set; }
        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal TotalPerformanceChain { get; set; }
        /// <summary>
        /// 新客业绩同比
        /// </summary>
        public decimal NewCustomerPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal OldCustomerPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 总业绩同比
        /// </summary>
        public decimal TotalPerformanceYearOnYear { get; set; }
    }
}
