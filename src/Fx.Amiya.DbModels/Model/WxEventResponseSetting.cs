using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class WxEventResponseSetting
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public string Title { get; set; }
        public string RspMsgXml { get; set; }
        public byte EventType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public byte RspMsgType{ get; set; }

    }
}
