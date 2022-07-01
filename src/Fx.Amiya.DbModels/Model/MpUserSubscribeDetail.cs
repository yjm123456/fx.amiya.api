using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class MpUserSubscribeDetail
    {
        public long Id { get; set; }
        public string MpUserId { get; set; }
        public string AppId { get; set; }
        public DateTime Date { get; set; }
        public bool Subscribe { get; set; }

        public WxMpUserInfo WxMpUserInfo { get; set; }
    }
}
