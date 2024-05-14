using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.FansMeetingDetails.Input
{
    public class AttendMeetingQueryVo
    {
        /// <summary>
        /// 粉丝见面会id
        /// </summary>
        public string   Id { get; set; }
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
