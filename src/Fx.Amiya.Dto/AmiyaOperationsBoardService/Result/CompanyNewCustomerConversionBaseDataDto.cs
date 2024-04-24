using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class CompanyNewCustomerConversionBaseDataDto
    {
        /// <summary>
        /// 派单数
        /// </summary>
        public int SendOrderCount { get; set; }
        /// <summary>
        /// 到院数
        /// </summary>
        public int ToHospitalCount { get; set; }
        /// <summary>
        /// 成交数
        /// </summary>
        public int DealCount { get; set; }
        /// <summary>
        /// 总人数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal DealPrice { get; set; }
    }
}
