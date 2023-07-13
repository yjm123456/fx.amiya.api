using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ShanDePay
{
    public class RefundBusinessResponseDto
    {
        public string sub_code { get; set; }
        public string sub_msg { get; set; }
        public string refund_amount { get; set; }
        public string out_order_no { get; set; }
        public string plat_trx_no { get; set; }
        public string bank_order_no { get; set; }
        public string bank_trx_no { get; set; }
        public string pay_way_code { get; set; }
        public string buyer_id { get; set; }
        public string refund_request_no { get; set; }
        public string refund_plat_trx_no { get; set; }
        public string refund_bank_order_no { get; set; }
        public string refund_bank_trx_no { get; set; }
        public string req_reserved { get; set; }
        public string discount_detail { get; set; }
    }
}
