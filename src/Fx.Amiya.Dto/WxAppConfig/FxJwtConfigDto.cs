using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.WxAppConfig
{
    /// <summary>
    /// jwt配置
    /// </summary>
    public class FxJwtConfigDto
    {
        public string Key { get; set; }
        public int ExpireInSeconds { get; set; }

        public int RefreshTokenExpireInSeconds { get; set; }
    }
}
