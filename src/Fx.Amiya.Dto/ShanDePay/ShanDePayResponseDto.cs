using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ShanDePay
{
    public class ShanDePayCommonResponseDto
    {
        public string code { get; set; }
        public string msg { get; set; }
        public string data { get; set; }
        public string sign { get; set; }
    }
    public class BusinessResponseDto {
        public string sub_code { get; set; }
        public string sub_msg { get; set; }
        public string prepay_id { get; set; }
        public PayParam pay_data { get; set; }
        public string bank_way { get; set; }
        public string out_order_no { get; set; }
        public string plat_trx_no { get; set; }
        public string bank_order_no { get; set; }
        public string bank_trx_no { get; set; }
        public string req_reserved { get; set; }

    }
    public class PayParam {
        public string timeStamp { get; set; }
        public string package { get; set; }
        public string paySign { get; set; }
        public string appId { get; set; }
        public string signType { get; set; }
        public string nonceStr { get; set; }
    }
    
}
