using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService
{
    public class GetEmployeePerformanceAnalizeDataDto
    {
        /// <summary>
        /// 助理业绩
        /// </summary>
        public List<GetEmployeePerformanceDataDto> EmployeeDatas { get; set; }
        /// <summary>
        /// 助理获客情况
        /// </summary>
        public List<GetEmployeeDistributeConsulationNumAndAddWechatDto> EmployeeDistributeConsulationNumAndAddWechats { get; set; }

        /// <summary>
        /// 助理客户运营情况
        /// </summary>
        public List<GetEmployeeCustomerAnalizeDto> GetEmployeeCustomerAnalizes { get; set; }

        /// <summary>
        /// 助理业绩排名
        /// </summary>
        public List<GetEmployeePerformanceRankingDto> GetEmployeePerformanceRankings { get; set; }
    }

    /// <summary>
    /// 助理业绩
    /// </summary>
    public class GetEmployeePerformanceDataDto
    {
        /// <summary>
        /// 助理名称
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal Performance { get; set; }
        /// <summary>
        /// 目标完成率
        /// </summary>
        public decimal CompleteRate { get; set; }
    }

    /// <summary>
    /// 助理获客情况
    /// </summary>
    public class GetEmployeeDistributeConsulationNumAndAddWechatDto
    {
        /// <summary>
        /// 助理名称
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 分诊量
        /// </summary>
        public int DistributeConsulationNum { get; set; }

        /// <summary>
        /// 加v量
        /// </summary>
        public int AddWechatNum { get; set; }
    }

    /// <summary>
    /// 助理客户运营情况
    /// </summary>
    public class GetEmployeeCustomerAnalizeDto
    {
        /// <summary>
        /// 助理名称
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 派单量
        /// </summary>
        public int SendOrderNum { get; set; }
        /// <summary>
        /// 上门量
        /// </summary>
        public int VisitNum { get; set; }
        /// <summary>
        /// 成交量
        /// </summary>
        public int DealNum { get; set; }
    }

    public class GetEmployeePerformanceRankingDto
    {
        /// <summary>
        /// 助理名称
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal Performance { get; set; }
    }
}
