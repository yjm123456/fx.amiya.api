using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.FansMeetingDetails.Input
{
    public class AttendMeetingQueryDto
    {
        /// <summary>
        /// 粉丝见面会id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
    }
}
