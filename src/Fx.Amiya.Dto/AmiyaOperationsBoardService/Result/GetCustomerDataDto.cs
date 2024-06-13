using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService
{
    public class GetCustomerDataDto
    {
        /// <summary>
        /// 线索量
        /// </summary>
        public int TotalFlowRateNum { get; set; }
        /// <summary>
        /// 退卡量
        /// </summary>
        public int RefundCardNum { get; set; }

        /// <summary>
        /// 分诊量
        /// </summary>
        public int DistributeConsulationNum { get; set; }

        /// <summary>
        /// 加v量
        /// </summary>
        public int AddWechatNum { get; set; }
    }
}
