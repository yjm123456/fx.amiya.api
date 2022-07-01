using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.GoodsHospitalPrice;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Core.Interfaces.GoodsHospitalPrice;
using Fx.Amiya.Modules.GoodsHospitalPrice.Domin;
using Fx.Amiya.Modules.GoodsHospitalPrice.Domin.IRepository;
using Fx.Amiya.Modules.GoodsHospitalPrice.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.GoodsHospitalPrice.AppService
{
    public class GoodsHospitalPriceService : IGoodsHospitalsPrice
    {
        private IGoodsHospitalsPriceRepository _goodsHospitalsPriceRepository;
        private IFreeSql<GoodsHospitalPriceFlag> freeSql;
        public GoodsHospitalPriceService(IGoodsHospitalsPriceRepository goodsHospitalsPriceRepository,
              IFreeSql<GoodsHospitalPriceFlag> freeSql)
        {
            _goodsHospitalsPriceRepository = goodsHospitalsPriceRepository;
            this.freeSql = freeSql;
        }

        public async Task AddAsync(GoodsHospitalPriceAddDto goodsInfoAdd)
        {
            GoodsHospitalsPrice goodsHospitalsPrice = new GoodsHospitalsPrice();
            goodsHospitalsPrice.GoodsId = goodsInfoAdd.GoodsId;
            goodsHospitalsPrice.HospitalId = goodsInfoAdd.HospitalId;
            goodsHospitalsPrice.Price = goodsInfoAdd.Price;
            await _goodsHospitalsPriceRepository.AddAsync(goodsHospitalsPrice);
        }

        public async Task DeleteByGoodsId(string goodsId)
        {
            try
            {
                await _goodsHospitalsPriceRepository.RemoveAsync(goodsId);
            }
            catch (Exception err)
            {
                throw new Exception("删除失败");
            }
        }

        public async Task<List<GoodsHospitalPriceDto>> GetByGoodsId(string goodsId)
        {
            List<GoodsHospitalPriceDto> resultList = new List<GoodsHospitalPriceDto>();
            List<GoodsHospitalsPrice> goodsHospitalsPriceList = new List<GoodsHospitalsPrice>();
            var goodsHospitalsPriceDbModel = await freeSql.Select<GoodsHospitalsPriceDbModel>().Where(x => x.GoodsId == goodsId).ToListAsync();
            foreach (var z in goodsHospitalsPriceDbModel)
            {
                GoodsHospitalsPrice goodsHospitalsPrice = new GoodsHospitalsPrice();
                goodsHospitalsPrice.GoodsId = z.GoodsId;
                goodsHospitalsPrice.HospitalId = z.HospitalId;
                goodsHospitalsPrice.Price = z.Price;
                goodsHospitalsPriceList.Add(goodsHospitalsPrice);
            }
            if (goodsHospitalsPriceList.Count > 0)
            {
                goodsHospitalsPriceList = goodsHospitalsPriceList.Where(x => x.GoodsId == goodsId).ToList();
                foreach (var x in goodsHospitalsPriceList)
                {
                    GoodsHospitalPriceDto goodsHospitalPriceDto = new GoodsHospitalPriceDto();
                    goodsHospitalPriceDto.GoodsId = x.GoodsId;
                    goodsHospitalPriceDto.HospitalId = x.HospitalId;
                    goodsHospitalPriceDto.Price = x.Price;
                    resultList.Add(goodsHospitalPriceDto);
                }
            }
            return resultList;
        }

    }
}
