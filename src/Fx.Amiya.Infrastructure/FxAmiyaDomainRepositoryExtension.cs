using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Fx.Amiya.Infrastructure
{
   public static class FxAmiyaDomainRepositoryExtension
    {
        public static void FxAddAmiyaDomainRepositoryServices(this IServiceCollection services)
        {
            var dic = GetClassNameByEndWithRepository("Fx.Amiya.Infrastructure");
            foreach (var item in dic)
            {

                foreach (var interfaceType in item.Value)
                {
                    services.AddScoped(interfaceType, item.Key);
                }

            }

        }

        /// <summary>
        /// 取service结尾的类型，及对应的接口
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static Dictionary<Type, Type[]> GetClassNameByEndWithRepository(string assemblyName)
        {
            if (!string.IsNullOrWhiteSpace(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> types = assembly.GetTypes().ToList();
                var result = new Dictionary<Type, Type[]>();
                foreach (var item in types.Where(t => !t.IsInterface && t.Name.EndsWith("Repository", true, null)))
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
