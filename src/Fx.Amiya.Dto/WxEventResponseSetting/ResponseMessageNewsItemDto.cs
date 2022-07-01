using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Fx.Amiya.Dto.WxEventResponseSetting
{
    [Serializable]
    [XmlType(TypeName = "item")]
    public class ResponseMessageNewsItemDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        public string Url { get; set; }
    }
}
