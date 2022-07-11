using Fx.Amiya.Dto.GoodsShopCar;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGoodsShopCarService
    {
        Task<FxPageInfo<GoodsShopCarDto>> GetListWithPageAsync(string keyword, string customerId, int pageNum, int pageSize);
        Task AddAsync(AddGoodsShopCarDto addDto);
        Task<GoodsShopCarDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateGoodsShopCarDto updateDto);
        Task DeleteAsync(string id);


    }
}
