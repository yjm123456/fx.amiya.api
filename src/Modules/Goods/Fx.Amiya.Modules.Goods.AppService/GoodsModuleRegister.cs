using Fx.Amiya.Core;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Modules.Goods.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.AppService
{
  public  class GoodsModuleRegister: DefaultFxModuleRegister
    {
        public GoodsModuleRegister()
        {
            Name = "GoodsModule";
        }

        public override void AddModuleServices(IServiceCollection services)
        {
            base.AddModuleServices(services);
            services.AddGoodsRepositoryServices(DbConnectionString, ReadDbConnectionStrings, DBType);
            services.AddScoped<IGoodsCategory, GoodsCategoryAppService>();
            services.AddScoped<IGoodsInfo, GoodsInfoAppService>();
        }
    }
}
