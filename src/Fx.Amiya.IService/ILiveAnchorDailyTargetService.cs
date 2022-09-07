using Fx.Amiya.Dto.LiveAnchorDailyTarget;
using Fx.Amiya.Dto.OrderReport;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveAnchorDailyTargetService
    {
        Task<FxPageInfo<LiveAnchorDailyTargetDto>> GetListWithPageAsync(DateTime startDate, DateTime endDate, int? operationEmpId, int? netWorkConEmpId, int? liveAnchorId, int pageNum, int pageSize,int employeeId);
        Task AddAsync(AddLiveAnchorDailyTargetDto addDto);

        Task BeforeLivingAddAsync(BeforeLivingAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingUpdateAsync(BeforeLivingUpdateLiveAnchorDailyTargetDto updateDto);

        Task LivingAddAsync(LivingAddLiveAnchorDailyTargetDto addDto);
        Task LivingUpdateAsync(LivingUpdateLiveAnchorDailyTargetDto updateDto);

        Task AfterLivingAddAsync(AfterLivingAddLiveAnchorDailyTargetDto addDto);

        Task AfterLivingUpdateAsync(AfterLivingUpdateLiveAnchorDailyTargetDto updateDto);

        Task<LiveAnchorDailyTargetDto> GetLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate);
        Task<LiveAnchorDailyTargetDto> GetByIdAsync(string id);
        Task<LiveAnchorDailyTargetDto> GetByMonthTargetAsync(string monthTargetId);
        Task UpdateAsync(UpdateLiveAnchorDailyTargetDto updateDto);
        Task DeleteAsync(string id);

        Task<List<LiveAnchorDailyAndMonthTargetDto>> GetByDailyAndMonthAsync(DateTime startDate, DateTime endDate);

        Task<List<OrderOperationConditionDto>> GetConsultingCardBuyDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderOperationConditionDto>> GetConsultingCardUseDataAsync(DateTime startDate, DateTime endDate);
    }
}
