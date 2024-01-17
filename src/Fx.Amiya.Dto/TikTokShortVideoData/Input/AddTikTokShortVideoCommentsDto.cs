using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokShortVideoData.Input
{
    public class AddTikTokShortVideoCommentsDto
    {
        /// <summary>
        /// 评论id
        /// </summary>
        public string CommentsId { get; set; }
        /// <summary>
        /// 评论用户id
        /// </summary>
        public string CommentsUserId { get; set; }
        /// <summary>
        /// 评论用户名
        /// </summary>
        public string CommentsUserName { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int LikeCount { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime? CommentsDate { get; set; }
        /// <summary>
        /// 归属主播
        /// </summary>
        public int BelongLiveAnchorId { get; set; }
    }
}
