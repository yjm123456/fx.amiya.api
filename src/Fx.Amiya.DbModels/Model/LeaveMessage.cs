using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
  public  class LeaveMessage
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string MsgType { get; set; }
        public string FromAppId { get; set; }
        public string MsgId { get; set; }
        public byte Type { get; set; }
        public bool? IsReply { get; set; }
        public int? EmployeeId { get; set; }

        public UserInfo UserInfo { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
