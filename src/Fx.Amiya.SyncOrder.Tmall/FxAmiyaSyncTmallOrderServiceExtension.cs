using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.Tmall.TmallAppInfoConfig;
using Fx.Amiya.SyncOrder.WeiFenXiao;
using Fx.Amiya.SyncOrder.WeiFenXiao.WeiFenXiaoAppInfoConfig;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.SyncOrder.Tmall
{
  public static  class FxAmiyaSyncTmallOrderServiceExtension
    {
        public static void AddFxAmiyaSyncTmallOrderService(this IServiceCollection services)
        {
            services.AddScoped<ISyncOrder, SyncTmallOrder>();
            services.AddScoped<ITmallAppInfoReader, TmallAppInfoReader>();
        }
    }
}
