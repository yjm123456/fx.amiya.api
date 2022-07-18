using Fx.Amiya.Core;
using Fx.Amiya.Core.Interfaces.GoodsShopCar;
using Fx.Amiya.Modules.GoodsShopCar.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.GoodsShopCar.AppService
{
    public class GoodsShopCarModuleRegister:DefaultFxModuleRegister
    {
        public GoodsShopCarModuleRegister()
        {
            Name = "GoodsShopCarModule";
        }

        public override void AddModuleServices(IServiceCollection services)
        {
            base.AddModuleServices(services);
            services.AddGoodsShopcarRepositoryServices(DbConnectionString, ReadDbConnectionStrings, DBType);
            services.AddScoped<IGoodsShopCar, GoodsShopCarAppService>();
        }
    }
}
