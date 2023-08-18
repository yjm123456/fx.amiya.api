using Fx.Amiya.Core.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Fx.Amiya.Core.Services
{
   public class FxAmiyaModulesRegister
    {
        /// <summary>
        /// 注册模块
        /// </summary>
        /// <param name="services"></param>
        /// <param name="defaultDbConnectionString">默认数据库连接地址，当模块没有配置连接地址时，都使用默认连接地址</param>
        /// <param name="defaultReadDbConnectionStrings">默认读数据库连接地址，当模块没有配置连接地址时，都使用默认连接地址</param>
        /// <param name="fxDBType">默认数据库类型，当模块没有配置数据库类型时，都使用默认数据库类型</param>
        public static void RegisteModules(IServiceCollection services, string defaultDbConnectionString = null, string[] defaultReadDbConnectionStrings = null, FxDBType fxDBType = FxDBType.MySql)
        {
            //注册应用程序目录下的所有模块
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            string dbConnectionString = defaultDbConnectionString;
            string[] readDbConnectionString = null;
            if (string.IsNullOrWhiteSpace(dbConnectionString))
            {
                dbConnectionString = configuration.GetConnectionString("MySqlConnectionString");
            }
            if (string.IsNullOrWhiteSpace(dbConnectionString))
                throw new Exception("未指定数据库连接地址！");

            if (defaultReadDbConnectionStrings == null)
                readDbConnectionString = configuration.GetSection("ReadDbConnectionStrings")?.Get<string[]>();

            var registeInterfaceType = typeof(IFxModuleRegisterable);
            var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            Func<string, Assembly> selector = filePath =>
            {
                try
                {
                    return Assembly.LoadFrom(filePath);  //有些程序加载时会把BadImageException异常，所以这里做一些处理
                }
                catch
                {
                    return null;
                }

            };
            var referencedAssemblies = System.IO.Directory.GetFiles(path, "*.dll").Select(selector).ToArray();
            List<Assembly> targentAssembly = new List<Assembly>();
            foreach (var a in referencedAssemblies)   //由于部分程序集调用DefinedTypes属性时会报错，所以用循环把报错的程序集删除
            {
                try
                {
                    var r = a.DefinedTypes;
                    targentAssembly.Add(a);
                }
                catch (Exception)
                {


                }
            }
            var types = targentAssembly
              .SelectMany(a => a.DefinedTypes)
              .Select(type => type.AsType())
              .Where(x => x != registeInterfaceType && registeInterfaceType.IsAssignableFrom(x)).ToArray();
            var implementTypes = types.Where(x => x.IsClass && !x.IsAbstract).ToArray();
            foreach (var implementType in implementTypes)
            {
                var moduleRegister = Activator.CreateInstance(implementType) as IFxModuleRegisterable;

                moduleRegister.DbConnectionString = dbConnectionString;
                moduleRegister.DBType = fxDBType;
                moduleRegister.ReadDbConnectionStrings = readDbConnectionString;
                moduleRegister.AddModuleServices(services);
            }
        }
    }
}
