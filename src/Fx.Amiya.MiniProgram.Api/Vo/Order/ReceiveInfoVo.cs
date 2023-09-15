using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    public class ReceiveInfoVo
    {

        public string MchId { get; set; }
        public string TradeId { get; set; }
        public string TransactionId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
