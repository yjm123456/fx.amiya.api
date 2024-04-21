using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.FansMeetingDetails.Input
{
    public class QueryFansMeetingDetailsVo:BaseQueryVo
    {
        /// <summary>
        /// 粉丝见面会id
        /// </summary>
        public string FansMeetingId { get; set; }
    }
}
