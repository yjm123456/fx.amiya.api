using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderRemark
{
    public class OrderRemarkDto : BaseDto
    {
        public int BelongAuthorize { get; set; }
        public string OrderId { get; set; }
        public int CreateBy { get; set; }
        public string Remark { get; set; }

        public string Avatar { get; set; }
        public string EmployeeName { get; set; }
    }
}
