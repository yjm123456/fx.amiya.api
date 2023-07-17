using Fx.Amiya.Dto;
using Fx.Amiya.Dto.WareHouse.InWareHouse;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Amiya.Dto.WareHouse.WareHouseStorageRacksDto.Input;
using Fx.Amiya.Dto.WareHouse.WareHouseStorageRacksDto.Output;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaWareHouseStorageRacksService
    {
        Task<FxPageInfo<AmiyaWareHouseStorageRacksDto>> GetListWithPageAsync(QueryAmiyaWareHouseStorageRacksDto query);
        Task AddAsync(AmiyaWareHouseStorageRacksAddDto addDto);
        Task<AmiyaWareHouseStorageRacksDto> GetByIdAsync(string id);
        Task UpdateAsync(AmiyaWareHouseStorageRacksUpdateDto updateDto);
        Task DeleteAsync(string id);

        Task<List<BaseKeyValueDto>> GetValidByWareHouseIdAsync(string warehouseId);

    }
}
