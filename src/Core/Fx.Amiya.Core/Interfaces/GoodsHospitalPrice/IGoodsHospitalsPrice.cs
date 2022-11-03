using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.GoodsHospitalPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Interfaces.GoodsHospitalPrice
{
    public interface IGoodsHospitalsPrice
    {
        Task AddAsync(GoodsHospitalPriceAddDto goodsInfoAdd);
        Task DeleteByGoodsId(string goodsId);
        Task<List<GoodsHospitalPriceDto>> GetByGoodsId(string goodsId);
        /// <summary>
        /// 根据商品id和医院id获取医院价格
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<GoodsHospitalPriceDto> GetByGoodsIdAndHospitalId(string goodsId,int hospitalId);

    }
}
