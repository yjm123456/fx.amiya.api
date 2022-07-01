using Fx.Amiya.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.Modules.Integration.Infrastructure.Repositories;
using Fx.Amiya.Core.Interfaces.Integration;

namespace Fx.Amiya.Modules.Integration.AppService
{
   public class IntegrationModuleRegister: DefaultFxModuleRegister
    {
        public IntegrationModuleRegister()
        {
            Name = "IntegrationModule";
        }

        public override void AddModuleServices(IServiceCollection services)
        {
            base.AddModuleServices(services);
            services.AddIntegrationRepositoryServices(DbConnectionString, ReadDbConnectionStrings, DBType);
            services.AddScoped<IIntegrationAccount, IntegrationAccountAppService>();
        }
    }
}
