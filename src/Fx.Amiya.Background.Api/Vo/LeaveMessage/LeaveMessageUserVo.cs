using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LeaveMessage
{
    public class LeaveMessageUserVo
    {
        public string UserId { get; set; }
        public string Avatar { get; set; }
        public string NickName { get; set; }
        public List<LeaveMessageDateVo> LeaveMessageDateList { get; set; }
    }

    public class LeaveMessageDateVo
    {
        public DateTime Date { get; set; }
        public List<LeaveMessageVo> LeaveMessageList { get; set; }
    }
}
