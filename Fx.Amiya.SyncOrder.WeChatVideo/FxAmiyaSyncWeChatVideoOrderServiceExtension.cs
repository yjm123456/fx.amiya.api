using Fx.Amiya.SyncOrder.WeChatVideo.WeChatVideoAppInfoConfig;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeChatVideo
{
    public static class FxAmiyaSyncWeChatVideoOrderServiceExtension
    {
        public static IServiceCollection AddFxAmiyaSyncWeChatVideoOrderService(this IServiceCollection services)
        {
            services.AddScoped<ISyncWeChatVideoOrder, SyncWeChatVideoOrder>();
            services.AddScoped<IWechatVideoAppInfoReader, WechatVideoAppInfoReader>();
            return services;
        }
    }
}
