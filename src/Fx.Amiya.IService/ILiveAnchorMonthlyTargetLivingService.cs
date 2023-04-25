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

        Task<LiveAnchorMonthTargetPerformanceDto> GetPerformance(int year, int month, List<int> liveAnchorIds);

        /// <summary>
        /// 按月获取主播带货业绩
        /// </summary>
        /// <returns></returns>
        Task<List<PerformanceInfoByDateDto>> GetLiveAnchorCommercePerformance(int year, int month, List<int> liveAnchorIds);

        Task<LiveAnchorBaseBusinessMonthTargetPerformanceDto> GetBasePerformanceTargetAsync(int year, int month, List<int> liveAnchorIds);
    }
}
