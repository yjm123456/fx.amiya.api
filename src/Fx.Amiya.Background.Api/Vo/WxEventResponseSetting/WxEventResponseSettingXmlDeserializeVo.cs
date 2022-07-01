using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WxEventResponseSetting
{
    public class WxEventResponseSettingXmlDeserializeVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 事件类型：1=首次关注，2=再次关注
        /// </summary>
        public byte EventType { get; set; }

        /// <summary>
        /// 事件类型名称
        /// </summary>
        public string EventTypeName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 消息类型：1=文本消息，2=图文消息
        /// </summary>
        public byte RspMsgType { get; set; }

        /// <summary>
        /// 消息类型名称
        /// </summary>
        public string RspMsgTypeName { get; set; }


        /// <summary>
        /// 文本消息对象
        /// </summary>
        public ResponseMessageTextVo TextMsg { get; set; }

        /// <summary>
        /// 图文消息数组对象
        /// </summary>
        public List<ResponseMessageNewsItemVo> ArticleMsgList { get; set; }
    }
}
