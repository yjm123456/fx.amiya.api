using Fx.Amiya.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using Fx.Amiya.Modules.Infrastructure;
using Fx.Amiya.Modules.GoodsHospitalPrice.Infrastructure.Repositories;
using Fx.Amiya.Modules.OrderWriteOff.Infrastructure.Repositories;

namespace Fx.Amiya.Modules.GoodsHospitalPrice.Infrastructure.Repositories
{
   public static class OrderWriteOffRepositoryExtension
    {
        private static Dictionary<FxDBType, DataType> map = new Dictionary<FxDBType, DataType>() {
            { FxDBType.SqlServer,DataType.SqlServer },
            { FxDBType.MySql,DataType.MySql}
        };


        /// <summary>
        /// 注册仓储服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IServiceCollection AddOrderWriteOffRepositoryServices(this IServiceCollection services, string connectionString, string[] readDbConnectionString, FxDBType dbType)
        {
            services.BatchAddRepositoriesServices("Fx.Amiya.Modules.OrderWriteOff.Infrastructure.Repositories", "repository");
            var freeSql = new FreeSql.FreeSqlBuilder().UseConnectionString(map[dbType], connectionString).UseSlave(readDbConnectionString).Build<OrderWriteOffFlag>();
            services.AddSingleton<IFreeSql<OrderWriteOffFlag>>(freeSql);
            DbModelConfigurations.Configuration(freeSql);
            return services;
        }
    }
}
