using Fx.Amiya.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using Fx.Amiya.Modules.Infrastructure;

namespace Fx.Amiya.Modules.MemberCard.Infrastructure.Repositories
{
    public static class MemberCardRepositoryExtension
    {
        private static Dictionary<FxDBType, DataType> map = new Dictionary<FxDBType, DataType>() {
            { FxDBType.SqlServer,DataType.SqlServer },
            { FxDBType.MySql,DataType.MySql}
        };

        /// <summary>
        /// 注册会员卡仓储服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IServiceCollection AddMemberCardRepositoryServices(this IServiceCollection services, string connectionString, string[] readDbConnectionString, FxDBType dbType)
        {
            services.BatchAddRepositoriesServices("Fx.Amiya.Modules.MemberCard.Infrastructure.Repositories", "repository");
            var freeSql = new FreeSql.FreeSqlBuilder().UseConnectionString(map[dbType], connectionString).UseSlave(readDbConnectionString).Build<MemberCardFlag>();
            services.AddSingleton<IFreeSql<MemberCardFlag>>(freeSql);
            DbModelConfigurations.Configuration(freeSql);
            return services;
        }
    }
}
