using Fx.Amiya.Dto.ConsumptionLevel;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IConsumptionLevelService
    {
        Task<FxPageInfo<ConsumptionLevelDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize);
        Task AddAsync(ConsumptionLevelAddDto addDto);
        Task<List<ConsumptionLevelIdAndNameDto>> GetIdAndNames();
        Task<ConsumptionLevelDto> GetByIdAsync(string id);
        Task UpdateAsync(ConsumptionLevelUpdateDto updateDto);
        Task DeleteAsync(string id);
    }
}
