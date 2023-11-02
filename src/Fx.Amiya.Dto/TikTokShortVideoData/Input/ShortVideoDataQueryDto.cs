using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokShortVideoData.Input
{
    public class ShortVideoDataQueryDto:BaseQueryDto
    {
        /// <summary>
        /// 主播id
        /// </summary>
        public int? LiveAnchorId { get; set; }
    }
}
