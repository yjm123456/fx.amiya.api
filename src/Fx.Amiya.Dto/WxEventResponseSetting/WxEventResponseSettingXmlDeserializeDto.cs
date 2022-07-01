using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Fx.Amiya.Dto.WxEventResponseSetting
{
    [XmlRoot("xml")]
   public class WxEventResponseSettingXmlDeserializeDto
    {
     
        public int Id { get; set; }
     
        public bool IsValid { get; set; }
        public string Title { get; set; }
    
        public byte EventType { get; set; }
        public string EventTypeName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public byte RspMsgType { get; set; }
        public string RspMsgTypeName { get; set; }


        /// <summary>
        /// 文本消息对象
        /// </summary>
        public ResponseMessageTextDto TextMsg { get; set; }

        /// <summary>
        /// 图文消息数组对象
        /// </summary>
        public List<ResponseMessageNewsItemDto> Articles { get; set; }
    }
}
