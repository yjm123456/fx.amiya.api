using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.Performance.BusinessWechatDto;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaPerformanceService
    {

        //管理端
        #region 【啊美雅业绩】
        /// <summary>
        /// 获取当月 总/新客/老客/带货业绩 以及各业绩同比/环比/目标达成率
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<MonthPerformanceRatioDto> GetMonthPerformanceAndRation(int year, int month);

        /// <summary>
        /// 分组业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<GroupPerformanceDto> GetGroupPerformanceAsync(int year, int month);


        /// <summary>
        /// 派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<MonthDealPerformanceDto> GetMonthDealPerformanceAsync(int year, int month);

        /// <summary>
        /// 获取当月/历史派单当月成交折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSendOrder">是否为历史派单订单</param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHistorySendThisMonthDealOrders(int year, int month, bool isOldSendOrder, string liveAnchorName);


        #endregion

        #region 【分组业绩】
        /// <summary>
        /// 分组总业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<MonthPerformanceRatioDto> GetByLiveAnchorPerformanceAsync(int year, int month, string liveAnchorName);

        /// <summary>
        /// 分组派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<MonthDealPerformanceDto> GetMonthDealPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName);

        /// <summary>
        /// 根据条件获取照片，视频面诊业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<GroupVideoAndPicturePerformanceDto> GetContentPlatFormOrderPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName);

        /// <summary>
        /// 跟进条件获取独立跟进/协助业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<IndependentOrAssistPerformanceDto> GetIndependentOrAssistByLiveAnchorPerformanceAsync(int year, int month, string liveAnchorName);

        /// <summary>
        /// 获取基础经营看板业绩信息
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<BaseBusinessPerformanceDto> GetBaseBusinessPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName);

        /// <summary>
        /// 派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<SendAndDealPerformanceByLiveAnchorDto> GetSendOrDealByLiveAnchorAsync(int year, int month, string liveAnchorName);


        /// <summary>
        /// 主播客单价看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<GuestUnitPricePerformanceDto> GetGuestUnitPricePerformanceByLiveAnchorAsync(int year, int month, string liveAnchorName);

        /// <summary>
        /// 各个板块完成率看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<GroupTargetCompleteRateDto> GetPerformanceCompleteRateByLiveAnchorNameAsync(int year, int month, string liveAnchorName);
        #endregion

        #region【 其他相关业务接口（折线图，明细等）】

        /// <summary>
        ///  获取新/老客业绩数据折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCustomer"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        Task<List<PerformanceInfoByDateDto>> GetNewOrOldPerformanceBrokenLineAsync(int year, int month, bool? isCustomer, string liveAnchorName);

        /// <summary>
        /// 获取带货业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<List<PerformanceInfoByDateDto>> GetLiveAnchorCommercePerformanceByLiveAnchorIdAsync(int year, int month, string liveAnchorName);

        /// <summary>
        /// 根据条件获取内容平台照片/视频面诊业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetPictureOrVideoConsultationAsync(int year, int month, bool isVideo, string liveAnchorName);

        /// <summary>
        /// 根据条件获取独立/协助业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="IsAssist"></param>
        /// <param name="liveAnchorName"></param>
        /// <param name="isLiveAnchorIndependence"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetIndependenceOrAssistAsync(int year, int month, bool IsAssist, string liveAnchorName, bool isLiveAnchorIndependence);

        /// <summary>
        /// 获取分组经营看板折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isHistoryConsulationCardConsumed"></param>
        /// <param name="isConsulationCardRefund"></param>
        /// <param name="liveAnchorBaseName"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetBaseBusinessPerformanceBrokenLineAsync(int year, int month, bool? isHistoryConsulationCardConsumed, bool? isConsulationCardRefund, bool? isAddWechat, bool? isConsulation, string liveAnchorBaseName);




        /// <summary>
        /// 获取派单成交业绩（折线图使用）
        /// </summary>
        /// <param name="isSend">是否派单</param>
        /// <param name="isDeal">是否成交</param>
        /// <param name="isToHospital">是否到院</param>
        /// <param name="isOldCustomer">是否老客</param>
        /// <param name="liveAnchorBaseName"></param>
        Task<List<ContentPlatFormOrderInfoDto>> GetSendOrDealBrokenLineAsync(bool? isSend, bool? isDeal, bool? isToHospital, bool? isOldCustomer, string liveAnchorBaseName);

        /// <summary>
        /// 根据主播获取客单价折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldCustomer"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetGuestUnitPricePerformanceAsync(int year, int month, bool? isOldCustomer, string liveAnchorName);


        /// <summary>
        /// 根据主播获取派单成交明细
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSend"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderDealInfoDto>> GetSendAndDealPerformanceByYearAndMonthAndLiveAnchorNameAsync(int year, int month, bool? isOldSend, string liveAnchorName);

        /// <summary>
        /// 获取照片/视频面诊明细
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="LiveAnchorName"></param>
        /// <returns></returns>
        Task<List<ShoppingCartRegistrationDto>> GetPictureOrVideoConsultationByLiveAnchorAsync(int year, int month, bool isVideo, string LiveAnchorName);
        #endregion

        #region[新运营看板业务层]
        Task<AmiyaOperationDataDto> GetPerformanceOperationDataAsync(int year, int month, string contentPlatFormId, bool isEffectiveCustomerData);
        #endregion

        #region 【企业微信】
        /// <summary>
        /// 公司累计总业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<CompanyMonthPerformanceBWDto> GetMonthPerformanceAsync(int year, int month);

        /// <summary>
        ///  自播/合作达人总业绩
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="liveAnchorBaseId"></param>
        /// <param name="isSelfLiveAnchor"></param>
        /// <returns></returns>
        Task<LiveAnchorMonthAndDatePerformanceDto> GetMonthPerformanceBySelfLiveAnchorAsync(DateTime date, string liveAnchorBaseId, bool? isSelfLiveAnchor);

        /// <summary>
        /// 助理总体业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorBaseId"></param>
        /// <returns></returns>
        Task<List<CustomerPerformanceBWDto>> GetBelongCustomerServicePerformanceByLiveAnchorBaseIdAsync(int year, int month, string liveAnchorBaseId);

        /// <summary>
        /// 根据助理id获取助理简单业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        Task<CustomerServiceSimplePerformanceDto> GetSimpleCustomerServicePerformanceDetails(int year, int month, int customerServiceId);

        /// <summary>
        /// 获取我的排名
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        Task<string> GetMyRankAsync(int year, int month, int customerServiceId);

        /// <summary>
        /// 根据客服id查询客服详细业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        Task<DetailCustomerPerformanceBWDto> GetCustomerServicePerformanceDetails(int year, int month, int customerServiceId);
        #endregion
        #region 业绩看板
        /// <summary>
        /// 业绩看板获取总业绩
        /// </summary>
        /// <param name="baseLiveanchorId">基础主播id(传空查所有)</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        Task<AmiyaAchievementDataDto> GetTotalAndLiveanchorPerformanceAsync(string baseLiveanchorId, int year, int month, int day);
        /// <summary>
        /// 业绩看板获取业绩详情
        /// </summary>
        /// <param name="baseLiveanchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        Task<AmiyaAchievementDetailDataDto> GetDetailPerformanceAsync(string baseLiveanchorId, int year, int month, int day);
        /// <summary>
        /// 获取业绩看板折线图
        /// </summary>
        /// <param name="baseLiveanchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<AmiyaAchievementBrokenLineListDto> GetAmiyaAchievementBrokenLineListDataAsync(string baseLiveanchorId, int year, int month);
        #endregion
    }
}
