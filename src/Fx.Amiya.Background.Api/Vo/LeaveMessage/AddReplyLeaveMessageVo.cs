using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LeaveMessage
{
    public class AddReplyLeaveMessageVo
    {
        public int LeaveMessageId { get; set; }

        [Required(ErrorMessage ="回复内容不能为空")]
        public string Content { get; set; }
    }
}
