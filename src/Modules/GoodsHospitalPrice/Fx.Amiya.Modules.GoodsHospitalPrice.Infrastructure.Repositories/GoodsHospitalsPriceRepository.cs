using Fx.Amiya.Modules.GoodsHospitalPrice.Domin;
using Fx.Amiya.Modules.GoodsHospitalPrice.Domin.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.GoodsHospitalPrice.Infrastructure.Repositories
{
    public class GoodsHospitalsPriceRepository : IGoodsHospitalsPriceRepository
    {
        private IFreeSql<GoodsHospitalPriceFlag> freeSql;
        public GoodsHospitalsPriceRepository(IFreeSql<GoodsHospitalPriceFlag> freeSql)
        {
            this.freeSql = freeSql;
        }

        public async Task<GoodsHospitalsPrice> AddAsync(GoodsHospitalsPrice entity)
        {
            GoodsHospitalsPriceDbModel goodsHospitalsPrice = new GoodsHospitalsPriceDbModel()
            {
                GoodsId = entity.GoodsId,
                HospitalId = entity.HospitalId,
                Price = entity.Price
            };

            var res = await freeSql.Insert<GoodsHospitalsPriceDbModel>().AppendData(goodsHospitalsPrice).ExecuteIdentityAsync();
            return entity;
        }

      

        public Task<GoodsHospitalsPrice> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAsync(GoodsHospitalsPrice entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RemoveAsync(string id)
        {
            return await freeSql.Delete<GoodsHospitalsPriceDbModel>().Where(e => e.GoodsId == id).ExecuteAffrowsAsync();
        }

        public Task<int> UpdateAsync(GoodsHospitalsPrice entity)
        {
            throw new NotImplementedException();
        }
    }
}
