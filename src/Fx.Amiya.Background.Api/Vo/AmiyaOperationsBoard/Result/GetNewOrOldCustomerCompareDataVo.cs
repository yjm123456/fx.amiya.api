using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class GetNewOrOldCustomerCompareDataVo
    {
        /// <summary>
        /// 整体流量分析
        /// </summary>
        public OperationBoardGetNewOrOldCustomerCompareDataDetailsVo TotalNewOrOldCustomer { get; set; }
        /// <summary>
        /// 刀刀组流量分析
        /// </summary>
        public OperationBoardGetNewOrOldCustomerCompareDataDetailsVo GroupDaoDaoNewOrOldCustomer { get; set; }
        /// <summary>
        /// 吉娜组流量分析
        /// </summary>
        public OperationBoardGetNewOrOldCustomerCompareDataDetailsVo GroupJiNaNewOrOldCustomer { get; set; }
    }
    public class OperationBoardGetNewOrOldCustomerCompareDataDetailsVo {

        /// <summary>
        /// 新客占比
        /// </summary>
        public decimal? TotalPerformanceNewCustomerRate { get; set; }

        /// <summary>
        /// 老客占比
        /// </summary>
        public decimal? TotalPerformanceOldCustomerRate { get; set; }

        /// <summary>
        /// 新客数值
        /// </summary>
        public decimal? TotalPerformanceNewCustomerNumber { get; set; }

        /// <summary>
        /// 老客数值
        /// </summary>
        public decimal? TotalPerformanceOldCustomerNumber { get; set; }
    }
}
