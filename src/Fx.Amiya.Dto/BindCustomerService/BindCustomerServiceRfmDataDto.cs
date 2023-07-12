using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.BindCustomerService
{
    public class BindCustomerServiceRfmDataDto
    {
        /// <summary>
        /// rfm类型
        /// </summary>
        public int RFMType { get; set; }

        /// <summary>
        /// 客户数量
        /// </summary>
        public int CustomerCount { get; set; }
        /// <summary>
        /// 累计消费金额
        /// </summary>

        public decimal TotalConsumptionPrice { get; set; }
    }
}
