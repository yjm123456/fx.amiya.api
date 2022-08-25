using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.Performance;
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

        /// <summary>
        /// 根据主播平台获取折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="contentPlatFormId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceAsync(int year, int month, string contentPlatFormId);
        /// <summary>
        /// 根据主播基础id获取折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorBaseId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceByBaseIdAsync(int year, int month, string liveAnchorBaseId);

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
        Task<GroupVideoAndPicturePerformanceDto> GetShoppingCartPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName);

        /// <summary>
        /// 跟进条件获取独立跟进/协助业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<IndependentOrAssistPerformanceDto> GetIndependentOrAssistByLiveAnchorPerformanceAsync(int year, int month, string liveAnchorName);
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
        /// 根据条件获取小黄车照片/视频面诊业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        Task<List<PerformanceInfoByDateDto>> GetPictureOrVideoConsultationAsync(int year, int month, bool isVideo, string liveAnchorName);

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
    }
}
