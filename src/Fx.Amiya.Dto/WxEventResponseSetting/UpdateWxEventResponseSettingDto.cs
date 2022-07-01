using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Fx.Amiya.Dto.WxEventResponseSetting
{
    [XmlRoot("xml")]
   public class UpdateWxEventResponseSettingDto
    {
        [XmlIgnore]
        public int Id { get; set; }

        [XmlIgnore]
        public bool IsValid { get; set; }

        [XmlIgnore]
        public string Title { get; set; }

        [XmlIgnore]
        public byte EventType { get; set; }

        [XmlIgnore]
        public byte RspMsgType { get; set; }


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
