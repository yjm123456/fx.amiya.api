using Fx.Amiya.DbModels;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Fx.Amiya.Dal
{
   public static class FxAmiyaDbRegisterExtension
    {
        public static void AddFxAmiyaDbService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork<AmiyaDbContext>>();
            var configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>() as IConfiguration;
            string context = configuration.GetConnectionString("MySqlConnectionString");
            serviceCollection.AddDbContext<AmiyaDbContext>(options => options.UseMySql(context));

            AddFxAmiyaDal(serviceCollection);
        }

        public static void AddFxAmiyaDbService(this IServiceCollection serviceCollection, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("数据库连接字符串不能为空");
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork<AmiyaDbContext>>();

            serviceCollection.AddDbContext<AmiyaDbContext>(options => options.UseMySql(connectionString));

            AddFxAmiyaDal(serviceCollection);
        }

        private static void AddFxAmiyaDal(IServiceCollection serviceCollection)
        {
            var dic = GetClassNameByStartWithDal("Fx.Amiya.DAL");
            foreach (var item in dic)
            {
                foreach (var interfaceType in item.Value)
                {
                    serviceCollection.AddScoped(interfaceType, item.Key);
                }

            }
        }


        /// <summary>
        /// 取DAL开头的类型
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static Dictionary<Type, Type[]> GetClassNameByStartWithDal(string assemblyName)
        {
            if (!string.IsNullOrWhiteSpace(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> types = assembly.GetTypes().ToList();
                var result = new Dictionary<Type, Type[]>();
                foreach (var item in types.Where(t => !t.IsInterface && t.Name.StartsWith("Dal", true, null)))
                {
                    var interfaces = item.GetInterfaces();
                    result.Add(item, interfaces);
                }
                return result;
            }
            return new Dictionary<Type, Type[]>();
        }
    }
}
