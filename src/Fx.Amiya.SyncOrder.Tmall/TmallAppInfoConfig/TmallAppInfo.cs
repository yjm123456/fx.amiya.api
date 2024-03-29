﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.SyncOrder.Tmall.TmallAppInfoConfig
{
   public class TmallAppInfo
    {
        public int Id { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string AccessToken { get; set; }
        public DateTime? AuthorizeDate { get; set; }
        public byte AppType { get; set; }
        public DateTime ExpireDate { get; set; }
        public string RefreshToken { get; set; }
    }
}
