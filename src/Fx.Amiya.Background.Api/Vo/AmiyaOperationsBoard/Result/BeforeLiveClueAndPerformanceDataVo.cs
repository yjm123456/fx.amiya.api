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
        /// 客资
        /// </summary>
        public int CustomerCount { get; set; }
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal Performance { get; set; }
    }
}
