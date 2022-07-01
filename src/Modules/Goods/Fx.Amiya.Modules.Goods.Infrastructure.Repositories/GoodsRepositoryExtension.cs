using Fx.Amiya.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using Fx.Amiya.Modules.Infrastructure;

namespace Fx.Amiya.Modules.Goods.Infrastructure.Repositories
{
   public static class GoodsRepositoryExtension
    {
        private static Dictionary<FxDBType, DataType> map = new Dictionary<FxDBType, DataType>() {
            { FxDBType.SqlServer,DataType.SqlServer },
            { FxDBType.MySql,DataType.MySql}
        };


        /// <summary>
        /// 注册商品仓储服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IServiceCollection AddGoodsRepositoryServices(this IServiceCollection services, string connectionString, string[] readDbConnectionString, FxDBType dbType)
        {
            services.BatchAddRepositoriesServices("Fx.Amiya.Modules.Goods.Infrastructure.Repositories", "repository");
            var freeSql = new FreeSql.FreeSqlBuilder().UseConnectionString(map[dbType], connectionString).UseSlave(readDbConnectionString).Build<GoodsFlag>();
            services.AddSingleton<IFreeSql<GoodsFlag>>(freeSql);
            DbModelConfigurations.Configuration(freeSql);
            return services;
        }
    }
}
