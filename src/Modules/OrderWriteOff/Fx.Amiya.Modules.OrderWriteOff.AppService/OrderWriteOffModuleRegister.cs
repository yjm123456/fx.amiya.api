
using Fx.Amiya.Core;
using Fx.Amiya.Core.Interfaces.OrderWriteOff;
using Fx.Amiya.Modules.GoodsHospitalPrice.Infrastructure.Repositories;
using Fx.Amiya.Modules.OrderWriteOff.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Fx.Amiya.Modules.OrderWriteOff.AppService
{
   public class OrderWriteOffModuleRegister: DefaultFxModuleRegister
    {
        public OrderWriteOffModuleRegister()
        {
            Name = "OrderWriteOffModule";
        }

        public override void AddModuleServices(IServiceCollection services)
        {
            base.AddModuleServices(services);
            services.AddOrderWriteOffRepositoryServices(DbConnectionString, ReadDbConnectionStrings, DBType);
            services.AddScoped<IOrderWriteOff, OrderWriteOffService>();
        }
    }
}
