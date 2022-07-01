using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.WxEventResponseSetting
{
   public class WxEventResponseSettingDto
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public string Title { get; set; }
        public string RspMsgXml { get; set; }
        public byte EventType { get; set; }
        public string EventTypeName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public byte RspMsgType { get; set; }
        public string RspMsgTypeName { get; set; }
    }
}
