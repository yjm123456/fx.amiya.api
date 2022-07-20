using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.TikTok.TikTokAppInfoConfig;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.TikTok
{
   public static class FxAmiyaSyncTikTokOrderServiceExtension
    {
        public static void AddFxAmiyaSyncTikTokOrderService(this IServiceCollection services)
        {
            services.AddScoped<ISyncTikTokOrder, SyncTikTokOrder>();
            services.AddScoped<ITikTokAppInfoReader, TikTokAppInfoReader>();
        }
    }
}
