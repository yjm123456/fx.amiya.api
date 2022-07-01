using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.LeaveMessage
{
   public class LeaveMessageUserDto
    {
        public string UserId { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public DateTime Date { get; set; }

       public List<LeaveMessageDateDto> LeaveMessageDateList { get; set; }
    }

    public class LeaveMessageDateDto
    { 
        public DateTime Date { get; set; }
        public List<LeaveMessageDto> LeaveMessageList { get; set; }
    }
}
