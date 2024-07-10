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
        /// 机构业绩分析
        /// </summary>
        public List<CustomerPerformanceDataVo> HospitalPerformance { get; set; }
    }


    /// <summary>
    /// 助理与机构线索柱状图输出类
    /// </summary>
    public class CustomerFlowRateDataListVo
    {
        /// <summary>
        /// 助理总分诊
        /// </summary>
        public int TotalDistributeConsulationByEmployee { get; set; }

        /// <summary>
        /// 助理总派单
        /// </summary>
        public int TotalSendOrderByEmployee { get; set; }
        /// <summary>
        /// 助理总上门
        /// </summary>
        public int TotalVisitByEmployee { get; set; }
        /// <summary>
        /// 助理业绩分析
        /// </summary>
        public List<CustomerFlowRateDataVo> EmployeeFlowRate { get; set; }
        /// <summary>
        /// 机构业绩分析
        /// </summary>
        public List<CustomerFlowRateDataVo> HospitalFlowRate { get; set; }

        /// <summary>
        /// 机构总派单
        /// </summary>
        public int TotalSendOrderByHospital { get; set; }
        /// <summary>
        /// 机构总上门
        /// </summary>
        public int TotalVisitByHospital { get; set; }
        /// <summary>
        /// 机构总成交
        /// </summary>
        public int TotalDealByHospital { get; set; }
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
        /// 总业绩
        /// </summary>
        public decimal TotalCustomerPerformance { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }

    public class CustomerFlowRateDataVo
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
