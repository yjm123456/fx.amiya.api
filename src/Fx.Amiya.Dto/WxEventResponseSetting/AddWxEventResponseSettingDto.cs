using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Fx.Amiya.Dto.WxEventResponseSetting
{
    [XmlRoot("xml")]
    public class AddWxEventResponseSettingDto
    {
        /// <summary>
        /// 事件类型：1=首次关注，2=再次关注
        /// </summary>
        [XmlIgnore]
        public byte EventType { get; set; }

        /// <summary>
        /// 消息类型：1=文本消息，2=图文消息
        /// </summary>
        [XmlIgnore]
        public byte RspMsgType { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [XmlIgnore]
        public string Title { get; set; }

        /// <summary>
        /// 文本消息对象
        /// </summary>
        [XmlIgnore]
        public ResponseMessageTextDto TextMsg { get; set; }

        /// <summary>
        /// 图文消息数组对象
        /// </summary>
        public List<ResponseMessageNewsItemDto> Articles { get; set; }
    }
}
