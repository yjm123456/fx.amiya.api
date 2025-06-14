using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class BeforeLiveClueAndPerformanceDataVo
    {
        /// <summary>
        /// 部门数据
        /// </summary>
        public BeforeLiveClueAndPerformanceDataItemVo DepartmentData { get; set; }
        /// <summary>
        /// 个人数据
        /// </summary>
        public BeforeLiveClueAndPerformanceDataItemVo EmployeeData { get; set; }
    }
    public class BeforeLiveClueAndPerformanceDataItemVo
    {
        /// <summary>
        /// 当日客资
        /// </summary>
        public int CurrentDayCustomerCount { get; set; }
        /// <summary>
        /// 当日总业绩
        /// </summary>
        public decimal CurrentDayPerformance { get; set; }
        /// <summary>
        /// 当日新客业绩
        /// </summary>
        public decimal CurrentDayNewCustomerPerformance { get; set; }
        /// <summary>
        /// 当日老客业绩
        /// </summary>
        public decimal CurrentDayOldCustomerPerformance { get; set; }
        /// <summary>
        /// 客资
        /// </summary>
        public int CustomerCount { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal Performance { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }

        /// <summary>
        /// 客资目标
        /// </summary>
        public int CustomerCountTarget { get; set; }
        /// <summary>
        /// 客资目标完成率
        /// </summary>
        public decimal CustomerCountTargetComplete { get; set; }
    }
}
