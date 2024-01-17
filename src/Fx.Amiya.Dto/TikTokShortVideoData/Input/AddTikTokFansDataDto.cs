using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokShortVideoData.Input
{
    public class AddTikTokFansDataDto
    {
        public DateTime StatsDate { get; set; }
        public int NewFansCount { get; set; }
        public int TotalFansCount { get; set; }
        /// <summary>
        /// 归属主播
        /// </summary>
        public int BelongLiveAnchorId { get; set; }
    }
}
