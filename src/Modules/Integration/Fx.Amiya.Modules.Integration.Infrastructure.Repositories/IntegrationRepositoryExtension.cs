using FreeSql;
using Fx.Amiya.Core.Infrastructure;
using Fx.Amiya.Modules.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Infrastructure.Repositories
{
   public static class IntegrationRepositoryExtension
    {
        private static Dictionary<FxDBType, DataType> map = new Dictionary<FxDBType, DataType>() {
            { FxDBType.SqlServer,DataType.SqlServer },
            { FxDBType.MySql,DataType.MySql}
        };
        /// <summary>
        /// 注册积分仓储服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IServiceCollection AddIntegrationRepositoryServices(this IServiceCollection services, string connectionString, string[] readDbConnectionString, FxDBType dbType)
        {
            services.BatchAddRepositoriesServices("Fx.Amiya.Modules.Integration.Infrastructure.Repositories", "repository");
            var freeSql = new FreeSql.FreeSqlBuilder().UseConnectionString(map[dbType], connectionString).UseSlave(readDbConnectionString).Build<IntegrationFlag>();
            services.AddSingleton<IFreeSql<IntegrationFlag>>(freeSql);
            DbModelConfigurations.Configuration(freeSql);
            return services;
        }
    }
}
