using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ShanDePay
{
    public class ShanDeOrderInfo
    {
        public string AppId { get; set; }
        public DateTime CreateDate { get; set; }
        public string OpenId { get; set; }
        public decimal TotalFee { get; set; }
        public string TradeId { get; set; }
    }
}
