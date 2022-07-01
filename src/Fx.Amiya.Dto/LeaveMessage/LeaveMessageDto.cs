using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.LeaveMessage
{
    public class LeaveMessageDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string MsgType { get; set; }
        public string MsgId { get; set; }

        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        /// <summary>
        /// 0=留言，1=回复
        /// </summary>
        public byte Type { get; set; }
        public string TypeText { get; set; }
        public bool? IsReply { get; set; }

        

    }
}
