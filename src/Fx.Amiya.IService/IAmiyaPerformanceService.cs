using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaPerformanceService
    {

        Task<MonthPerformanceDto> GetMonthPerformance(int year,int month);
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
        Task<List<PerformanceBrokenLine>> GetHistorySendThisMonthDealOrders(int year, int month, bool isOldSendOrder);

        /// <summary>
        /// 根据主播平台获取折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="contentPlatFormId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceAsync(int year, int month, string contentPlatFormId);
    }
}
