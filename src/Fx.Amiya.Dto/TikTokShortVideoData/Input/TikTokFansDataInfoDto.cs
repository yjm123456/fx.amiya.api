using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokShortVideoData.Input
{
    public class TikTokFansDataInfoDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 统计时间
        /// </summary>
        public DateTime StatsDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NewFansCount { get; set; }
        public int TotalFansCount { get; set; }
        /// <summary>
        /// 归属主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }
    }
}
