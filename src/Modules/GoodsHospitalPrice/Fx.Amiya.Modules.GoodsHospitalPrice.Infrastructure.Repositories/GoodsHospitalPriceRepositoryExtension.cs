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

namespace Fx.Amiya.Modules.GoodsHospitalPrice.Infrastructure.Repositories
{
   public static class GoodsHospitalPriceRepositoryExtension
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
        public static IServiceCollection AddGoodsHospitalPriceRepositoryServices(this IServiceCollection services, string connectionString, string[] readDbConnectionString, FxDBType dbType)
        {
            services.BatchAddRepositoriesServices("Fx.Amiya.Modules.GoodsHospitalPrice.Infrastructure.Repositories", "repository");
            var freeSql = new FreeSql.FreeSqlBuilder().UseConnectionString(map[dbType], connectionString).UseSlave(readDbConnectionString).Build<GoodsHospitalPriceFlag>();
            services.AddSingleton<IFreeSql<GoodsHospitalPriceFlag>>(freeSql);
            DbModelConfigurations.Configuration(freeSql);
            return services;
        }
    }
}
