using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerIntegralOrderRefunds
{
    public class AddCustomerIntegralOrderRefundsDto
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerId { get; set; }


        /// <summary>
        /// 退款原因
        /// </summary>
        public string RefundReasong { get; set; }
    }
}
