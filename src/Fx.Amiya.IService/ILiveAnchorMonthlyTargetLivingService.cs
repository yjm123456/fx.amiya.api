using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.Performance;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveAnchorMonthlyTargetLivingService
    {
        Task<FxPageInfo<LiveAnchorMonthlyTargetLivingDto>> GetListWithPageAsync(int Year, int Month, int? LiveAnchorId, int employeeId, int pageNum, int pageSize);
        Task AddAsync(AddLiveAnchorMonthlyTargetLivingDto addDto);
        Task<List<LiveAnchorMonthlyTargetKeyAndValueDto>> GetIdAndNames(int year, int month);
        Task<LiveAnchorMonthlyTargetLivingDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateLiveAnchorMonthlyTargetLivingDto updateDto);
        Task EditAsync(UpdateLiveAnchorMonthlyLivingTargetRateAndNumDto editDto);
        Task DeleteAsync(string id);

    }
}
