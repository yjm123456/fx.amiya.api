using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 直播复盘
    /// </summary>
    public class LiveReplay:BaseDbModel
    {
        /// <summary>
        /// 平台id
        /// </summary>
        public string ContentPlatformId { get; set; }
        /// <summary>
        /// 主播ipid
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 直播时间
        /// </summary>
        public DateTime LiveDate { get; set; }
        /// <summary>
        /// 直播时长(单位为分钟)
        /// </summary>
        public int LiveDuration { get; set; }
        /// <summary>
        /// GMV
        /// </summary>
        public decimal GMV { get; set; }
        /// <summary>
        /// 直播人员
        /// </summary>
        public string LivePersonnel { get; set; }
        /// <summary>
        /// 平台
        /// </summary>
        public Contentplatform Contentplatform { get; set; }
        /// <summary>
        /// 主播
        /// </summary>
        public LiveAnchor LiveAnchor { get; set; }

        public List<LiveReplayProductDealData> LiveReplayProductDealDataList { get; set; }

        public List<LiveReplayInteractionlData> LiveReplayInteractionlDataList { get; set; }

        public List<LiveReplayMerchandiseTopData> LiveReplayMerchandiseTopDataList { get; set; }
    }
}
