using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.FansMeeting.Input
{
    public class QueryFansMeetingVo : BaseQueryVo
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
    }
}
