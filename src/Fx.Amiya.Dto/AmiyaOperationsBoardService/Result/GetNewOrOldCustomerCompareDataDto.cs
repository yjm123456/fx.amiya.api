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
        /// 总业绩分析的新客占比
        /// </summary>
        public decimal? TotalPerformanceNewCustomer { get; set; }

        /// <summary>
        /// 总业绩分析的老客占比
        /// </summary>
        public decimal? TotalPerformanceOldCustomer { get; set; }
        /// <summary>
        /// 刀刀组业绩分析的新客占比
        /// </summary>
        public decimal? GroupDaoDaoPerformanceNewCustomer { get; set; }

        /// <summary>
        /// 刀刀组业绩分析的老客占比
        /// </summary>
        public decimal? GroupDaoDaoPerformanceOldCustomer { get; set; }
        /// <summary>
        /// 吉娜组业绩分析的新客占比
        /// </summary>
        public decimal? GroupJiNaPerformanceNewCustomer { get; set; }

        /// <summary>
        /// 吉娜组业绩分析的老客占比
        /// </summary>
        public decimal? GroupJiNaPerformanceOldCustomer { get; set; }
    }
}
