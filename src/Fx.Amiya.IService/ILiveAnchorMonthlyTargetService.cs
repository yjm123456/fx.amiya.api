using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveAnchorMonthlyTargetService
    {
        Task<FxPageInfo<LiveAnchorMonthlyTargetDto>> GetListWithPageAsync(int Year, int Month, int? LiveAnchorId, int pageNum, int pageSize);
        Task AddAsync(AddLiveAnchorMonthlyTargetDto addDto);
        Task<List<LiveAnchorMonthlyTargetKeyAndValueDto>> GetIdAndNames(int year, int month);
        Task<LiveAnchorMonthlyTargetDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateLiveAnchorMonthlyTargetDto updateDto);
        Task EditAsync(UpdateLiveAnchorMonthlyTargetRateAndNumDto editDto);
        Task DeleteAsync(string id);
    }
}
