using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.WxAppConfig
{
  public  class WxAppConfigDto
    {
      
        public FxJwtConfigDto FxJwtConfig { get; set; }
        public FxOpenConfigDto FxOpenConfig { get; set; }
        public FxOSSConfigDto FxOSSConfig { get; set; }


        public FxRedisConfigDto FxRedisConfig { get; set; }
        public FxSmsConfigDto FxSmsConfig { get; set; }
        public FxUniteWxAccessTokenConfigDto FxUniteWxAccessTokenConfig { get; set; }

    
        public FxMessageCenterConfigDto FxMessageCenterConfig { get; set; }

        public CallCenterConfigDto CallCenterConfig { get; set; }

        public SyncOrderConfigDto SyncOrderConfig { get; set; }

        public FxNoticeConfigDto NoticeConfig { get; set; }
    }
}
