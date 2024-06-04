using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    /// <summary>
    /// 新老客横向堆叠柱状图输出类
    /// </summary>
    public class NewOrOldCustomerPerformanceDataListDto
    {
        /// <summary>
        /// 助理业绩分析
        /// </summary>
        public List<CustomerPerformanceDataDto> EmployeePerformance { get; set; }
        /// <summary>
        /// 助理业绩分析
        /// </summary>
        public List<CustomerPerformanceDataDto> HospitalPerformance { get; set; }
    }

    public class CustomerPerformanceDataDto
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
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
