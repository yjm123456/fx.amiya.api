using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
  public  class WxAppInfo
    {
        public string WxAppId { get; set; }
        public string AppSecret { get; set; }
        public string Description { get; set; }
        public string AppName { get; set; }
        public byte Type { get; set; }
        public bool Valid { get; set; }


        public string GrantType { get; set; }

        public string AccountId { get; set; }
    }
}
