using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokOrder
{
    public class UpdateTikTokOrderTradeDto
    {
        public string TradeId { get; set; }
        public string StatusCode { get; set; }
        public int? AddressId { get; set; }
    }
}
