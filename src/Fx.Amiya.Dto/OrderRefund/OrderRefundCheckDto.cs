using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderRefund
{
    public class OrderRefundCheckDto
    {
        public string Id { get; set; }
        public string UnCheckReason { get; set; }
        public int CheckBy { get; set; }
        public int CheckState { get; set; }
    }
}
