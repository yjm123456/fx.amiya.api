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

    /// <summary>
    /// 助理与机构线索柱状图输出类
    /// </summary>
    public class CustomerFlowRateDataListDto
    {
        /// <summary>
        /// 助理业绩分析
        /// </summary>
        public List<CustomerFlowRateDataDto> EmployeeFlowRate { get; set; }
        /// <summary>
        /// 机构业绩分析
        /// </summary>
        public List<CustomerFlowRateDataDto> HospitalFlowRate { get; set; }
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


    public class CustomerFlowRateDataDto
    {
        /// <summary>
        /// 分诊量
        /// </summary>
        public int DistributeConsulationNum { get; set; }
        /// <summary>
        /// 派单量
        /// </summary>
        public int SendOrderNum { get; set; }
        /// <summary>
        /// 上门量
        /// </summary>
        public int VisitNum { get; set; }

        /// <summary>
        /// 新客成交量
        /// </summary>
        public int NewCustomerDealNum { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
