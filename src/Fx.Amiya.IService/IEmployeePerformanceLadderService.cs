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

        /// <summary>
        /// 根据业绩获取提点
        /// </summary>
        /// <param name="performance"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<decimal> GetPointByPerformanceAsync(decimal performance, int? employeeId);

        /// <summary>
        /// 根据成交编号获取助理业绩提点
        /// </summary>
        /// <param name="dealId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<decimal> GetPointByDealIdAndEmpIdAsync(string dealId, int? employeeId);
    }
}
