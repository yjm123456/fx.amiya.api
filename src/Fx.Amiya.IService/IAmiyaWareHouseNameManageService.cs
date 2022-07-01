using Fx.Amiya.Dto.WareHouse.WareHouseNameManage;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaWareHouseNameManageService
    {
        Task<FxPageInfo<AmiyaWareHouseNameManageDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize);
        Task AddAsync(AmiyaWareHouseNameManageAddDto addDto);
        Task<AmiyaWareHouseNameManageDto> GetByIdAsync(string id);
        Task<List<AmiyaWareHouseNameBaseInfoDto>> GetIdAndNameAsync();
        Task UpdateAsync(AmiyaWareHouseNameManageUpdateDto updateDto);
        Task DeleteAsync(string id);

    }
}
