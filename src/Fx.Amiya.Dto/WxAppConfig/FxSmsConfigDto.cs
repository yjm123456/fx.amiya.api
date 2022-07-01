using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.WxAppConfig
{
    /// <summary>
    /// 方旋短信平台配置
    /// </summary>
   public class FxSmsConfigDto
    {
        public List<AliyunSmsConfigDto> AliyunSmsList { get; set; }
    }

    public class AliyunSmsConfigDto
    {
        public string Name { get; set; }
        public string AccessKeyId { get; set; }
        public string AccessSecret { get; set; }

        public string RegionId { get; set; }
        public string SignName { get; set; }
        public string TemplateCode { get; set; }

        public string Remark { get; set; }

    }
}
