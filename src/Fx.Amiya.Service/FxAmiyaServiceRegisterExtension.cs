using Fx.Amiya.Dal;
using Fx.Amiya.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Fx.Amiya.Service
{
   public static class FxAmiyaServiceRegisterExtension
    {
        public static void AddAmiyaWeixinAppService(this IServiceCollection serviceCollection)
        {
            var dic = GetClassNameByEndWithService("Fx.Amiya.Service");
            foreach (var item in dic)
            {

                foreach (var interfaceType in item.Value)
                {
                    serviceCollection.AddScoped(interfaceType, item.Key);
                }

            }
            serviceCollection.AddFxAmiyaDbService();
            serviceCollection.FxAddAmiyaDomainRepositoryServices();
        }

        /// <summary>
        /// 取service结尾的类型，及对应的接口
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static Dictionary<Type, Type[]> GetClassNameByEndWithService(string assemblyName)
        {
            if (!string.IsNullOrWhiteSpace(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> types = assembly.GetTypes().ToList();
                var result = new Dictionary<Type, Type[]>();
                foreach (var item in types.Where(t => !t.IsInterface && t.Name.EndsWith("service", true, null)))
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
