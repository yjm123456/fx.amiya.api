using Fx.Amiya.Core.Dto.GoodsShopCar;
using Fx.Amiya.Core.Interfaces.GoodsShopCar;
using Fx.Amiya.Modules.GoodsShopCar.DbModel;
using Fx.Amiya.Modules.GoodsShopCar.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.GoodsShopCar.AppService
{
    public class GoodsShopCarAppService : IGoodsShopCar
    {
        private readonly IFreeSql<GoodsShopCarFlag> freeSql;
        public GoodsShopCarAppService(IFreeSql<GoodsShopCarFlag> freeSql) {
            this.freeSql = freeSql;
        }
        public Task<List<GoodsShopCarDto>> GetShopCarByCustomerId(string customerId)
        {
            var carList = freeSql.Select<GoodsShopCarDdModel>().Where(e => e.CustomerId == customerId);
            var shoplist=
        }
    }
}
