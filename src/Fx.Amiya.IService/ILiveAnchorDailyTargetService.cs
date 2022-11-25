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
        Task<FxPageInfo<LiveAnchorDailyTargetDto>> GetListWithPageAsync(DateTime startDate, DateTime endDate, int? liveAnchorId, int pageNum, int pageSize,int employeeId);
        Task AddAsync(AddLiveAnchorDailyTargetDto addDto);


        #region[抖音]
        Task BeforeLivingTikTokAddAsync(BeforeLivingTikTokAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingTikTokUpdateAsync(BeforeLivingTikTokUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion
        #region[知乎]
        Task BeforeLivingZhihuAddAsync(BeforeLivingZhihuAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingZhihuUpdateAsync(BeforeLivingZhihuUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion
        #region[小红书]
        Task BeforeLivingXiaoHongShuAddAsync(BeforeLivingXiaoHongShuAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingXiaoHongShuUpdateAsync(BeforeLivingXiaoHongShuUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion
        #region[微博]
        Task BeforeLivingSinaWeiBoAddAsync(BeforeLivingSinaWeiBoAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingSinaWeiBoUpdateAsync(BeforeLivingSinaWeiBoUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion
        #region[视频号]
        Task BeforeLivingVideoAddAsync(BeforeLivingVideoAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingVideoUpdateAsync(BeforeLivingVideoUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion

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
