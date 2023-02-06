using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MiniProgramSendMessage
{
    public class SendAppointmentMessageDto
    {
        public string CustomerId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string AppointmentDate { get; set; }
        /// <summary>
        /// 预约状态
        /// </summary>
        public string AppointmentStatus { get; set; }
        /// <summary>
        /// 预约备注
        /// </summary>
        public string Remark { get; set; }
    }
}
