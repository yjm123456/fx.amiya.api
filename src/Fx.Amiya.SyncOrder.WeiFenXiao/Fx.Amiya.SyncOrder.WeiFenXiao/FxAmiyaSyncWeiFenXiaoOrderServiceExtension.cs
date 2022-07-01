using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.WeiFenXiao.WeiFenXiaoAppInfoConfig;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeiFenXiao
{
   public static class FxAmiyaSyncWeiFenXiaoOrderServiceExtension
    {
        public static void AddFxAmiyaSyncWeiFenXiaoOrderService(this IServiceCollection services)
        {
            services.AddScoped<ISyncWeiFenXiaoOrder, SyncWeiFenXiaoOrder>();
            services.AddScoped<IWeiFenXiaoAppInfoReader, WeiFenXiaoAppInfoReader>();
        }
    }
}
