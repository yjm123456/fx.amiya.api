using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.WxAppConfig
{
    /// <summary>
    /// 方旋OSS配置
    /// </summary>
    public class FxOSSConfigDto
    {
        public string AccessKeyId { get; set; }
        public string AccessKeySecret { get; set; }
        public string Bucket { get; set; }
        public string EndPoint { get; set; }
    }
}
