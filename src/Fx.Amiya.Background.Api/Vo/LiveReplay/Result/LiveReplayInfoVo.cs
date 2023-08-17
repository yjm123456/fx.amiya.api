using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveReplay.Result
{
    public class LiveReplayInfoVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 平台id
        /// </summary>
        public string ContentPlatformId { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public string ContentPlatformName { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }
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
