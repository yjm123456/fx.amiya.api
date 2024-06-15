using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class GetNewOrOldCustomerCompareDataDto
    {
        /// <summary>
        /// 整体业绩分析
        /// </summary>
        public OperationBoardGetNewOrOldCustomerCompareDataDetailsDto TotalNewOrOldCustomer { get; set; }
        /// <summary>
        /// 刀刀组业绩分析
        /// </summary>
        public OperationBoardGetNewOrOldCustomerCompareDataDetailsDto GroupDaoDaoNewOrOldCustomer { get; set; }
        /// <summary>
        /// 吉娜组业绩分析
        /// </summary>
        public OperationBoardGetNewOrOldCustomerCompareDataDetailsDto GroupJiNaNewOrOldCustomer { get; set; }
    }

    public class OperationBoardGetNewOrOldCustomerCompareDataDetailsDto
    {

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
