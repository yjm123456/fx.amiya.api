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
    public interface ILiveAnchorMonthlyTargetBeforeLivingService
    {
        Task<FxPageInfo<LiveAnchorMonthlyTargetBeforeLivingDto>> GetListWithPageAsync(int Year, int Month, int? LiveAnchorId, int employeeId, int pageNum, int pageSize);
        Task AddAsync(AddLiveAnchorMonthlyTargetBeforeLivingDto addDto);
        Task<List<LiveAnchorMonthlyTargetKeyAndValueDto>> GetIdAndNames(int year, int month);
        Task<LiveAnchorMonthlyTargetBeforeLivingDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateLiveAnchorMonthlyTargetBeforeLivingDto updateDto);
        Task EditAsync(UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editDto);
        Task DeleteAsync(string id);

    }
}
