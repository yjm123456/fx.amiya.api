using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncFeishuMultidimensionalTable.FeishuAppConfig
{
    public class ShortVideocommentsInfo
    {
        public string CommentsId { get; set; }
        public string CommentsUserId { get; set; }
        public string CommentsUserName { get; set; }
        public int LikeCount { get; set; }
        public string Comments { get; set; }
        public DateTime? CommentsDate { get; set; }
        public int? BelongLiveAnchorId { get; set; }
    }
}
