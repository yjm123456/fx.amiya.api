using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaWareHouseService
    {
        Task<FxPageInfo<AmiyaWareHouseDto>> GetListWithPageAsync(string keyword, string wareHouseInfoId, int pageNum, int pageSize);
        Task AddAsync(AmiyaWareHouseAddDto addDto);
        Task<AmiyaWareHouseDto> GetByIdAsync(string id);
        Task UpdateAsync(AmiyaWareHouseUpdateDto updateDto);
        Task InventoryWareHouseAsync(AmiyaWareHouseUpdateDto updateDto);
        Task OutWareHouseAsync(AmiyaWareHouseUpdateDto updateDto);
        Task InWareHouseAsync(AmiyaWareHouseUpdateDto updateDto);
        Task DeleteAsync(string id);
        Task<List<AmiyaWareHouseDto>> ExportListAsync(string keyword, string wareHouseInfoId);

    }
}
