using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LeaveMessage
{
    public class ReplyLeaveMessageVo
    {
        public int Id { get; set; }
        public int LeaveMessageId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
