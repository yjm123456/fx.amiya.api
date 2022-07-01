using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Domain
{
   public class WxMpUserSubscribeDetail
    {
        public string MpUserId { get; set; }
        public string AppId { get; set; }
        public DateTime Date { get; set; }
        public bool Subscribe { get; set; }
    }
}
