using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LeaveMessage
{
    public class LeaveMessageVo
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// 消息类型  text/image
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        public string MsgId { get; set; }

        /// <summary>
        /// 1=留言，2=回复
        /// </summary>
        public byte Type { get; set; }

        public string TypeText { get; set; }

        /// <summary>
        /// 回复员工编号
        /// </summary>
        public int? EmployeeId { get; set; }

        public string EmployeeName { get; set; }



        /// <summary>
        /// 是否已回复
        /// </summary>
        public bool? IsReply { get; set; }
    }
}
