using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveReplay.Input
{
    public class AddLiveReplayVo
    {
        /// <summary>
        /// 平台id
        /// </summary>
        public string ContentPlatformId { get; set; }

        /// <summary>
        /// 主播id
        /// </summary>
        public int LiveAnchorId { get; set; }

        /// <summary>
        /// 直播时间
        /// </summary>
        public DateTime LiveDate { get; set; }
        /// <summary>
        /// 直播时长
        /// </summary>
        public int LiveDuration { get; set; }
        /// <summary>
        /// gmv
        /// </summary>
        public decimal GMV { get; set; }
        /// <summary>
        /// 直播人员
        /// </summary>
        public List<string> LivePersonnels { get; set; }
    }
}
