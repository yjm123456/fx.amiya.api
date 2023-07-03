using Fx.Amiya.Dto;
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
        Task<FxPageInfo<ShoppingCartRegistrationDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, bool? isCreateOrder, bool? isSendOrder, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, int pageNum, int pageSize, decimal? minPrice, decimal? maxPrice, int? AdmissionId, DateTime? startRefundTime, DateTime? endRefundTime, DateTime? startBadReviewTime, DateTime? endBadReviewTime, int? emergencyLevel, bool? isBadReview,string baseLiveAnchorId,int? source);
        Task AddAsync(AddShoppingCartRegistrationDto addDto);

        Task AddListAsync(List<AddShoppingCartRegistrationDto> addDtoList);
        Task<ShoppingCartRegistrationDto> GetByIdAsync(string id);
        Task<ShoppingCartRegistrationDto> GetByPhoneAsync(string phone, int createBy);
        Task<ShoppingCartRegistrationDto> GetByPhoneAsync(string phone);
        Task UpdateAsync(UpdateShoppingCartRegistrationDto updateDto);

        Task AssignAsync(string id, int assignBy);
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
        /// <summary>
        /// 获取客户来源
        /// </summary>
        /// <returns></returns>
        List<BaseKeyValueDto<int>> GetCustomerSourceList();
        /// <summary>
        /// 获取面诊方式列表
        /// </summary>
        /// <returns></returns>
        List<BaseKeyValueDto<int>> GetShoppingCartConsultationTypeText();
        #region 【日数据业绩生成】

        /// <summary>
        /// 根据主播ID获取当日面诊卡情况
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<ShoppingCartRegistrationDto>> GetDialyConsulationCardInfoByLiveAnchorId(int liveAnchorId, DateTime recordDate);

        /// <summary>
        /// 根据主播ID获取当日加v派单情况
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<ShoppingCartRegistrationDto>> GetDialyAddWeChatInfoByLiveAnchorId(int liveAnchorId, DateTime recordDate);

        /// <summary>
        /// 根据条件获取今日小黄车退款量
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<ShoppingCartRegistrationDto>> GetDialyYellowCardRefundInfoByLiveAnchorId(int liveAnchorId, DateTime recordDate);

        /// <summary>
        /// 根据条件获取今日小黄车差评量
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<ShoppingCartRegistrationDto>> GetDialyYellowCardBadReviewInfoByLiveAnchorId(int liveAnchorId, DateTime recordDate);

        #endregion


        #region 【报表相关】
        Task<List<ShoppingCartRegistrationDto>> GetShoppingCartRegistrationReportAsync(DateTime? startDate, DateTime? endDate, int? emergencyLevel, int? LiveAnchorId, bool? isCreateOrder, bool? isSendOrder, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, bool isHidePhone,string baseLiveAnchorId,int? source);
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
        /// 获取面诊卡库存
        /// </summary>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<ShoppingCartRegistrationDto>> GetShoppingCartRegistrationInventoryAsync(List<int> liveAnchorIds);


        /// <summary>
        /// 根据条件获取基础经营看板信息
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isHistoryConsulationCardConsumed">是否为历史面诊卡消耗数据</param>
        /// <param name="isConsulationCardRefund">是否为历史面诊卡退单数据</param>
        /// <returns></returns>
        Task<List<ShoppingCartRegistrationDto>> GetBaseBusinessPerformanceByLiveAnchorNameAsync(int year, int month, bool? isHistoryConsulationCardConsumed, bool? isConsulationCardRefund, List<int> liveAnchorIds);


        /// <summary>
        /// 根据平台/有效潜在获取小黄车登记业绩（新经营看板业绩）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isEffectiveCustomerData"></param>
        /// <param name="contentPlatFormId"></param>
        /// <returns></returns>
        Task<List<ShoppingCartRegistrationDto>> GetNewBaseBusinessPerformanceByLiveAnchorNameAsync(DateTime startDate, DateTime endDate, bool isEffectiveCustomerData, string contentPlatFormId);

        /// <summary>
        /// 根据条件获取小黄车照片/视频面诊业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<PerformanceInfoByDateDto>> GetPictureOrVideoConsultationBrokenLineAsync(int year, int month, bool isVideo, List<int> liveAnchorIds);

        /// <summary>
        /// 根据条件获取小黄车登记业绩（经营看板业绩）
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isHistoryConsulationCardConsumed">是否为历史面诊卡消耗数据</param>
        /// <param name="isConsulationCardRefund">是否为历史面诊卡退单数据</param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetBaseBusinessPerformanceByLiveAnchorNameBrokenLineAsync(int year, int month, bool? isHistoryConsulationCardConsumed, bool? isConsulationCardRefund, bool? isAddWechat, bool? isConsulation, List<int> liveAnchorIds);
        #endregion
    }
}
