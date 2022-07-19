using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class LiveAnchorWeChatInfo
    {
        public string Id { get; set; }
        public int LiveAnchorId { get; set; }
        public string WeChatNo { get; set; }
        public string NickName { get; set; }
        public string Remark { get; set; }
        public bool Valid { get; set; }

        public LiveAnchor LiveAnchor { get; set; }
    }
}
