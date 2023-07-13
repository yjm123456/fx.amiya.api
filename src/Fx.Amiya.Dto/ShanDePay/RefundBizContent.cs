using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ShanDePay
{
    public class RefundBizContent
    {
        public string out_order_no { get; set; }
        public decimal refund_amount { get; set; }
        public string refund_request_no { get; set; }
    }
}
