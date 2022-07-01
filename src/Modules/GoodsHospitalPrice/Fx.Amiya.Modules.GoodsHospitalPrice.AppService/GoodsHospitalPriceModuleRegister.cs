using Fx.Amiya.Core;
using Fx.Amiya.Core.Interfaces.GoodsHospitalPrice;
using Fx.Amiya.Modules.GoodsHospitalPrice.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.GoodsHospitalPrice.AppService
{
  public  class GoodsHospitalPriceModuleRegister: DefaultFxModuleRegister
    {
        public GoodsHospitalPriceModuleRegister()
        {
            Name = "GoodsHospitalPriceModule";
        }

        public override void AddModuleServices(IServiceCollection services)
        {
            base.AddModuleServices(services);
            services.AddGoodsHospitalPriceRepositoryServices(DbConnectionString, ReadDbConnectionStrings, DBType);
            services.AddScoped<IGoodsHospitalsPrice, GoodsHospitalPriceService>();
        }
    }
}
