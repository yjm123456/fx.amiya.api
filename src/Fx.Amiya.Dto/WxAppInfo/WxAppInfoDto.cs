using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.WxAppInfo
{
  public  class WxAppInfoDto
    {
        public string WxAppId { get; set; }
        public string WxAppSecret { get; set; }
        public string Description { get; set; }
        public string WxAppName { get; set; }
        public byte Type { get; set; }
        public bool Valid { get; set; }

        public string GrantType { get; set; }

        public string AccountId { get; set; }
    }
}
