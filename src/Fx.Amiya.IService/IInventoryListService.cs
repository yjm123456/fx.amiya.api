using Fx.Amiya.Dto.WareHouse.InventoryList;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IInventoryListService
    {
        Task<FxPageInfo<InventoryListDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId, int pageNum, int pageSize);
        Task AddAsync(InventoryListAddDto addDto);
        Task<InventoryListDto> GetByIdAsync(string id);
        Task UpdateAsync(InventoryListUpdateDto updateDto);
        Task DeleteAsync(string id);
        Task<List<InventoryListDto>> ExportListAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId);

    }
}
