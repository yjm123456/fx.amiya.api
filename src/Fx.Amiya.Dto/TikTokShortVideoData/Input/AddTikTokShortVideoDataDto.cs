using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokShortVideoData
{
    public class AddTikTokShortVideoDataDto
    {
        /// <summary>
        /// 播放次数
        /// </summary>
        public int PlayNum { get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int Like { get; set; }
        /// <summary>
        /// 视频id
        /// </summary>
        public string VideoId { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int Comments { get; set; }
        /// <summary>
        /// 归属主播
        /// </summary>
        public int BelongLiveAnchorId { get; set; }
    }
}
