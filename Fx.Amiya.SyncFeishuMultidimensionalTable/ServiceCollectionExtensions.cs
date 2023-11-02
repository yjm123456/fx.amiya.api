using Fx.Amiya.SyncFeishuMultidimensionalTable.FeishuAppConfig;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncFeishuMultidimensionalTable
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFeishuSyncMultidimensionalTableService(this IServiceCollection services)
        {
            services.AddScoped<ISyncFeishuMultidimensionalTable, SyncFeishuMultidimensionalTable>();
            services.AddScoped<IFeishuAppinfoReader, FeishuAppinfoReader>();
            return services;
        }
    }
}
