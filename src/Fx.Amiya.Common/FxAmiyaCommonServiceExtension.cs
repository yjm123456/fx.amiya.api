using Fx.Amiya.Common.Configs;
using Fx.Amiya.Service;
using Fx.Sms.Aliyun;
using Fx.Weixin.MP;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Common
{
  public static  class FxAmiyaCommonServiceExtension
    {
        public static void AddFxAmiyaCommonServices(this IServiceCollection services)
        {
            services.AddAmiyaWeixinAppService();
            services.AddFxWeixinMpService();   //添加fx.weixin.mp的服务类

            services.AddScoped<FxAppGlobal>();
            services.AddScoped<IAccessTokenReader, DefaultAccessTokenReader>();
            services.AddFxAliyunSmsService();
            services.AddScoped<IAliyunSmsConfigReader, AliyunSmsConfigReader>();  //替换原来的aliyunsmsreader
        }
    }
}
