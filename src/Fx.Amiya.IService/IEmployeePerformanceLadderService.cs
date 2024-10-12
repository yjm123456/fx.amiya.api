using Fx.Amiya.Dto;
using Fx.Amiya.Dto.EmployeePerformanceLadder.Input;
using Fx.Amiya.Dto.EmployeePerformanceLadder.Result;
using Fx.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IEmployeePerformanceLadderService
    {
        Task<FxPageInfo<EmployeePerformanceLadderDto>> GetListAsync(QueryEmployeePerformanceLadderDto query);
        Task AddAsync(AddEmployeePerformanceLadderDto addDto);
        Task<EmployeePerformanceLadderDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateEmployeePerformanceLadderDto updateDto);
        Task DeleteAsync(string id);
        Task<List<BaseKeyValueDto>> GetValidListAsync();
    }
}
