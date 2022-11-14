using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    public class HuiShouqianRefundResponse
    {
        public string MerchantNo { get; set; }
        public string TransNo { get; set; }
        public string TradeNo { get; set; }
        public string OrderAmt { get; set; }
        public string OrderStatus { get; set; }
        public string FinishedDate { get; set; }
        public string RespCode { get; set; }
        public string RespMsg { get; set; }
    }
}
