using Fx.Amiya.Dto.EmployeePerformanceTarget.Input;
using Fx.Amiya.Dto.EmployeePerformanceTarget.Result;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IEmployeePerformanceTargetService
    {
        Task<FxPageInfo<EmployeePerformanceTargetDto>> GetListAsync(QueryEmployeePerformanceTargetDto query);

        Task AddAsync(AddEmployeePerformanceTargetDto addDto);
        Task<EmployeePerformanceTargetDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateEmployeePerformanceTargetDto updateDto);
        Task DeleteAsync(string id);
    }
}
