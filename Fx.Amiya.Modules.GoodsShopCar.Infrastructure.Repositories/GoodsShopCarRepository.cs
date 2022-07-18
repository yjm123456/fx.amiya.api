using Fx.Amiya.Modules.GoodsShopCar.DbModel;
using Fx.Amiya.Modules.GoodsShopCar.Domin.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Amiya.Modules.GoodsShopCar;

namespace Fx.Amiya.Modules.GoodsShopCar.Infrastructure.Repositories
{
    public class GoodsShopCarRepository : IGoodsShopCarRepository
    {
       /* private IFreeSql<GoodsShopCarFlag> freeSql;
        public GoodsShopCarRepository(IFreeSql<GoodsShopCarFlag> freeSql)
        {
            this.freeSql = freeSql;
        }
        public Task<List<Domin.GoodsShopCar>> GetShopCarListByCustomerById(string customerId)
        {
            var shopcarList = freeSql.Select<GoodsShopCarDdModel>().Where(e => e.CustomerId == customerId);
            var list =from d in shopcarList
                      select new Domin.GoodsShopCar { 
                        Id=d.id,
                      }
            
        }*/
    }
}
