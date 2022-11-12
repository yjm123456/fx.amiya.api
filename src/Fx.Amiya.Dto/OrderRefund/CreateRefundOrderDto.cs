using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderRefund
{
    public class CreateRefundOrderDto
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string TradeId { get; set; }
        public string Remark { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Valid { get; set; }
    }
}
