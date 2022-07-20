using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorWeChatInfo
{
    public class LiveAnchorWechatInfoVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }


        /// <summary>
        /// 平台
        /// </summary>
        public string ContentPlatFormName { get; set; }
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
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
    }
}
