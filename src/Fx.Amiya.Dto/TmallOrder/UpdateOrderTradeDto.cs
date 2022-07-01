using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
   public class UpdateOrderTradeDto
    {
        public string TradeId { get; set; }
        public string StatusCode { get; set; }
        public int? AddressId { get; set; }
    }
}
