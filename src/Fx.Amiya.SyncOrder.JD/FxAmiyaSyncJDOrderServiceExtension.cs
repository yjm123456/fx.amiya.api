using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.JD.JDAppInfoConfig;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.SyncOrder.JD
{
   public static class FxAmiyaSyncJDOrderServiceExtension
    {
        public static void AddFxAmiyaSyncJDOrderServices(this IServiceCollection services)
        {
            services.AddScoped<ISyncOrder, SyncJDOrder>();
            services.AddScoped<IJDAppInfoReader, JDAppInfoReader>();
        }
    }
}
