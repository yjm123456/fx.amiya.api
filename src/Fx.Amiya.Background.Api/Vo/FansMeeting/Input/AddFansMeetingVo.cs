using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.FansMeeting.Input
{
    public class AddFansMeetingVo
    {
        /// <summary>
        /// 粉丝见面会名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 粉丝见面会开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 粉丝见面会结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
    }
}
