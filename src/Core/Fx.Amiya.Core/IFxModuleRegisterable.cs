using Fx.Amiya.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Core
{
    /// <summary>
    /// /// <summary>
    /// 方旋模块注册接口
    /// 每个模块需要有个类实现这个接口，用来注册模块中的服务
    /// </summary>
    /// </summary>
    public interface IFxModuleRegisterable
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据库连接地址
        /// </summary>
        string DbConnectionString { get; set; }

        /// <summary>
        /// 读数据库连接地址
        /// </summary>
        string[] ReadDbConnectionStrings { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        FxDBType DBType { get; set; }
        /// <summary>
        /// 注册模块的服务
        /// </summary>
        /// <param name="services"></param>
        void AddModuleServices(IServiceCollection services);
    }
}
