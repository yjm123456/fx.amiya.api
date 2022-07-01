using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WxEventResponseSetting
{
    /// <summary>
    /// 添加事件消息回复模型
    /// </summary>
    public class AddWxEventResponseSettingVo
    {
        /// <summary>
        /// 事件类型：1=首次关注，2=再次关注
        /// </summary>
        public byte EventType { get; set; }

        /// <summary>
        /// 消息类型：1=文本消息，2=图文消息
        /// </summary>
        public byte RspMsgType { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
       [Required(ErrorMessage ="标题不能为空")]
        public string Title { get; set; }

        /// <summary>
        /// 文本消息对象
        /// </summary>
        public ResponseMessageTextVo TextMsg{ get; set; }

        /// <summary>
        /// 图文消息数组对象
        /// </summary>
        public List<ResponseMessageNewsItemVo> ArticleMsgList { get; set; }
    }
}
