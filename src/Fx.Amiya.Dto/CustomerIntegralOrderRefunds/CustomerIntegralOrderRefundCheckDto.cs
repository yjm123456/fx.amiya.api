using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerIntegralOrderRefunds
{
    public class CustomerIntegralOrderRefundCheckDto
    {
        public string Id { get; set; }
        public string CheckReason { get; set; }
        public int CheckBy { get; set; }
        public int CheckState { get; set; }
    }
}
