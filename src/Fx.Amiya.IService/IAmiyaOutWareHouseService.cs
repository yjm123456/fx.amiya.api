using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaOutWareHouseService
    {
        Task<FxPageInfo<AmiyaOutWareHouseDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId, string warehouseStorageRacksId, int pageNum, int pageSize);
        Task AddAsync(AmiyaOutWareHouseAddDto addDto);
        Task<AmiyaOutWareHouseDto> GetByIdAsync(string id);
        Task UpdateAsync(AmiyaOutWareHouseUpdateDto updateDto);
        Task DeleteAsync(string id);

        Task<List<AmiyaOutWareHouseDto>> ExportListAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId, string warehouseStorageRacksId);

    }
}
