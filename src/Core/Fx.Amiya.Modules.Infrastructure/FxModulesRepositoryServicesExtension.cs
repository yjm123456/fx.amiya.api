using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Fx.Amiya.Modules.Infrastructure
{
    /// <summary>
    /// 注册方旋仓储服务扩展类
    /// </summary>
    public static class FxModulesRepositoryServicesExtension
    {
        /// <summary>
        /// 批量注册仓储服务
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="keyword"></param>
        /// <param name="matchType"></param>
        public static void BatchAddRepositoriesServices(this IServiceCollection services, string assemblyName, string keyword, MatchType matchType = MatchType.EndsWith)
        {
            var dic = Assembly.Load(assemblyName).GetInterfaceAndImplementMap(keyword, matchType);
            foreach (var item in dic)
            {

                foreach (var interfaceType in item.Value)
                {
                    services.AddScoped(interfaceType, item.Key);
                }
            }
        }
    }
}
