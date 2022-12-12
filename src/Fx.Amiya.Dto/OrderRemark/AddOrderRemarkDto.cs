using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderRemark
{
    public class AddOrderRemarkDto 
    {
        public int BelongAuthorize { get; set; }
        public string OrderId { get; set; }
        public int CreateBy { get; set; }
        public string Remark { get; set; }
    }
}
