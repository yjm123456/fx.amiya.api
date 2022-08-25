using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IShoppingCartRegistrationService
    {
        Task<FxPageInfo<ShoppingCartRegistrationDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, bool? isCreateOrder, bool? isSendOrder, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, int pageNum, int pageSize, decimal? minPrice, decimal? maxPrice, int? AdmissionId, DateTime? startRefundTime, DateTime? endRefundTime, DateTime? startBadReviewTime, DateTime? endBadReviewTime, int? emergencyLevel, bool? isBadReview);
        Task AddAsync(AddShoppingCartRegistrationDto addDto);
        Task<ShoppingCartRegistrationDto> GetByIdAsync(string id);
        Task<ShoppingCartRegistrationDto> GetByPhoneAsync(string phone);
        Task UpdateAsync(UpdateShoppingCartRegistrationDto updateDto);
        /// <summary>
        /// 录单触达
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task UpdateCreateOrderAsync(string phone);
        /// <summary>
        /// 派单触达
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task UpdateSendOrderAsync(string phone);
        Task DeleteAsync(string id);
        /// <summary>
        /// 输出紧急程度列表
        /// </summary>
        /// <returns></returns>
        List<EmergencyLevelDto> GetEmergencyLevelList();


        #region 【报表相关】
        Task<List<ShoppingCartRegistrationDto>> GetShoppingCartRegistrationReportAsync(DateTime? startDate, DateTime? endDate, int? emergencyLevel, int? LiveAnchorId, bool? isCreateOrder, bool? isSendOrder, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, bool isHidePhone);
        #endregion

        #region 【业绩数据】
        /// <summary>
        /// 根据条件获取小黄车登记业绩（照片面诊业绩与视频面诊业绩）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<ShoppingCartRegistrationDto>> GetShoppingCartRegistrationListByLiveAnchorNameAndIsVideoAsync(int year, int month, bool isVideo, List<int> liveAnchorIds);

        /// <summary>
        /// 根据条件获取小黄车照片/视频面诊业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<PerformanceInfoByDateDto>> GetPictureOrVideoConsultationBrokenLineAsync(int year, int month, bool isVideo, List<int> liveAnchorIds);
        #endregion
    }
}
