using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    /// <summary>
    /// 新老客横向堆叠柱状图输出类
    /// </summary>
    public class NewOrOldCustomerPerformanceDataListVo
    {
        /// <summary>
        /// 助理业绩分析
        /// </summary>
        public List<CustomerPerformanceDataVo> EmployeePerformance { get; set; }
        /// <summary>
        /// 助理业绩分析
        /// </summary>
        public List<CustomerPerformanceDataVo> HospitalPerformance { get; set; }
    }

    public class CustomerPerformanceDataVo
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
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
