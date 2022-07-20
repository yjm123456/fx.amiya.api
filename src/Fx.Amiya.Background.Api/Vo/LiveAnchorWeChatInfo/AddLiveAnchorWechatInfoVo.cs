using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorWeChatInfo
{
    public class AddLiveAnchorWechatInfoVo
    {
        /// <summary>
        /// 主播ID
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WeChatNo { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
