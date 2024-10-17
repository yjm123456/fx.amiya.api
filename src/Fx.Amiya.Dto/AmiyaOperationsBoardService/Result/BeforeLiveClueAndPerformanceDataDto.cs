using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class BeforeLiveClueAndPerformanceDataDto
    {
        /// <summary>
        /// 部门数据
        /// </summary>
        public BeforeLiveClueAndPerformanceDataItemDto DepartmentData { get; set; }
        /// <summary>
        /// 个人数据
        /// </summary>
        public BeforeLiveClueAndPerformanceDataItemDto EmployeeData { get; set; }
    }
    public class BeforeLiveClueAndPerformanceDataItemDto
    {
        /// <summary>
        /// 客资
        /// </summary>
        public int CustomerCount { get; set; }
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal Performance { get; set; }
    }
}
