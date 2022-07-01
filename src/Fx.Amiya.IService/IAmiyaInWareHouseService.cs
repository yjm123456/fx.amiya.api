using Fx.Amiya.Dto.WareHouse.InWareHouse;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaInWareHouseService
    {
        Task<FxPageInfo<AmiyaInWareHouseDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId, int pageNum, int pageSize);
        Task AddAsync(AmiyaInWareHouseAddDto addDto);
        Task<AmiyaInWareHouseDto> GetByIdAsync(string id);
        Task UpdateAsync(AmiyaInWareHouseUpdateDto updateDto);
        Task DeleteAsync(string id);

        Task<List<AmiyaInWareHouseDto>> ExportListAsync(DateTime? startDate, DateTime? endDate, string keyword, string wareHouseInfoId);

    }
}
