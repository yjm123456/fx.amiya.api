using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderRemark
{
    public class UpdateOrderRemarkDto
    {
        public string Id { get; set; }
        public int BelongAuthorize { get; set; }
        public string OrderId { get; set; }
        public int HospitalId { get; set; }
        public int CreateBy { get; set; }
        public string Remark { get; set; }
    }
}
