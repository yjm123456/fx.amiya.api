using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.LeaveMessage
{
    public class ReplyLeaveMessageDto
    {
        public int Id { get; set; }
        public int LeaveMessageId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
