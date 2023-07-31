using Fx.Amiya.Dto.LiveAnchorDailyTarget;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.TakeGoods;
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
        Task<FxPageInfo<LiveAnchorDailyTargetDto>> GetListWithPageAsync(DateTime startDate, DateTime endDate, int? liveAnchorId, int pageNum, int pageSize, int employeeId);
        Task<FxPageInfo<BeforeLivingDailyTargetDto>> GetBeforeListWithPageAsync(DateTime startDate, DateTime endDate, int type, int? liveAnchorId, int pageNum, int pageSize, int employeeId);
        Task<FxPageInfo<LivingDailyTargetDto>> GetLivingListWithPageAsync(DateTime startDate, DateTime endDate, int? liveAnchorId, int pageNum, int pageSize, int employeeId);

        Task<FxPageInfo<AfterLivingDailyTargetDto>> GetAfterLivingListWithPageAsync(DateTime startDate, DateTime endDate, int? liveAnchorId, int pageNum, int pageSize, int employeeId);
        Task AddAsync(AddLiveAnchorDailyTargetDto addDto);


        #region[抖音]
        Task<LiveAnchorDailyTargetDto> GetBeforeLivingTikTokLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate);
        Task BeforeLivingTikTokAddAsync(BeforeLivingTikTokAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingTikTokUpdateAsync(BeforeLivingTikTokUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion
        #region[知乎]
        Task<LiveAnchorDailyTargetDto> GetBeforeLivingZhihuLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate);
        Task BeforeLivingZhihuAddAsync(BeforeLivingZhihuAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingZhihuUpdateAsync(BeforeLivingZhihuUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion
        #region[小红书]
        Task<LiveAnchorDailyTargetDto> GetBeforeLivingXiaoHongShuLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate);
        Task BeforeLivingXiaoHongShuAddAsync(BeforeLivingXiaoHongShuAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingXiaoHongShuUpdateAsync(BeforeLivingXiaoHongShuUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion
        #region[微博]
        Task<LiveAnchorDailyTargetDto> GetBeforeLivingSinaWeiBoLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate);
        Task BeforeLivingSinaWeiBoAddAsync(BeforeLivingSinaWeiBoAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingSinaWeiBoUpdateAsync(BeforeLivingSinaWeiBoUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion
        #region[视频号]
        Task<LiveAnchorDailyTargetDto> GetBeforeLivingVideoLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate);
        Task BeforeLivingVideoAddAsync(BeforeLivingVideoAddLiveAnchorDailyTargetDto addDto);
        Task BeforeLivingVideoUpdateAsync(BeforeLivingVideoUpdateLiveAnchorDailyTargetDto updateDto);
        #endregion

        Task<LiveAnchorDailyTargetDto> GetLivingLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate);
        Task LivingAddAsync(LivingAddLiveAnchorDailyTargetDto addDto);
        Task LivingUpdateAsync(LivingUpdateLiveAnchorDailyTargetDto updateDto);

        Task<LiveAnchorDailyTargetDto> GetAfterLivingLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate);
        Task AfterLivingAddAsync(AfterLivingAddLiveAnchorDailyTargetDto addDto);
        Task AfterLivingUpdateAsync(AfterLivingUpdateLiveAnchorDailyTargetDto updateDto);

        Task<LiveAnchorDailyTargetDto> GetLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate);
        Task<LiveAnchorDailyTargetDto> GetByIdAndTypeAsync(string id, int type);
        Task<LiveAnchorDailyTargetDto> GetByMonthTargetAsync(string monthTargetId);
        Task UpdateAsync(UpdateLiveAnchorDailyTargetDto updateDto);
        Task DeleteAsync(string id);

        Task<List<LiveAnchorDailyAndMonthTargetDto>> GetByDailyAndMonthAsync(DateTime startDate, DateTime endDate);

        Task<List<OrderOperationConditionDto>> GetConsultingCardBuyDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderOperationConditionDto>> GetConsultingCardUseDataAsync(DateTime startDate, DateTime endDate);
        Task<List<GmvAndRefundGmvDto>> GetDailyDataByLiveAnchorIdsAsync(List<string> targetIds);
        /// <summary>
        /// 根据时间和主播id集合获取下单gmv和退款gmv数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<GmvAndRefundGmvDto>> GetGmvDataAsync(DateTime start,DateTime end,List<int> liveAnchorIds);
    }
}
