using Fx.Amiya.Core.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Fx.Amiya.Core
{
    /// <summary>
    /// 默认模块注册器
    /// </summary>
    public class DefaultFxModuleRegister : IFxModuleRegisterable
    {
        public string Name { get; set; }
        public string DbConnectionString { get; set; }
        public FxDBType DBType { get; set; }
        public string[] ReadDbConnectionStrings { get; set; }

        public virtual void AddModuleServices(IServiceCollection services)
        {
            //如果没有在配置文件中设置数据库连接和数据库类型，那么将使用全局配置

            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var allModuleSettings = configuration.GetSection("ModuleSettings").Get<ModuleSetting[]>();
            var moduleSettings = allModuleSettings?.SingleOrDefault(t => t.Name == Name);
            if (moduleSettings != null)
            {
                this.DbConnectionString = moduleSettings.DbConnectionString;
                this.DBType = moduleSettings.DBType;
                this.ReadDbConnectionStrings = moduleSettings.ReadDbConnectionStrings;
            }
        }
    }
}
