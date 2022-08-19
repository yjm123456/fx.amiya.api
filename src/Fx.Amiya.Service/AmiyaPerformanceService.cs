using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IService;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AmiyaPerformanceService : IAmiyaPerformanceService
    {
        private readonly ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;

        public AmiyaPerformanceService(ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService)
        {
            this.liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
        }

        public async Task<MonthPerformanceDto> GetMonthPerformance(int year, int month)
        {
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month, null);

            //业绩
            var curTotalPerformance = order.Sum(o => o.Price);
            //业绩同比
            var orderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, null);
            var totalPerformanceYearOnYear = orderYearOnYear.Sum(o => o.Price);

            //业绩环比（todo;）
            List<ContentPlatFormOrderDealInfoDto> orderChain = null;
            if (month == 1)
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, null);
            }
            else
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, null);
            }
            var totalPerformanceChainRatio = orderChain.Sum(o => o.Price);
            //老客业绩
            var curOldCustomer = order.Where(o => o.IsOldCustomer == true).Sum(o => o.Price);
            //老客业绩同比
            var oldOrderYearOnYearr = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, true);
            var oldPerformanceYearOnYear = oldOrderYearOnYearr.Sum(o => o.Price);
            //老客业绩环比
            List<ContentPlatFormOrderDealInfoDto> oldOrderChainRatio = null;
            if (month == 1)
            {
                oldOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, true);
            }
            else
            {
                oldOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, true);
            }
            var oldPerformanceRatio = oldOrderChainRatio.Sum(o => o.Price);
            //新客业绩
            var curNewCustomer = order.Where(o => o.IsOldCustomer == false).Sum(o => o.Price);
            //新客同比
            var newOrderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, false);
            var newPerformanceYearOnYear = newOrderYearOnYear.Sum(o => o.Price);
            //新客环比
            List<ContentPlatFormOrderDealInfoDto> newOrderChainRatio = null;
            if (month == 1)
            {
                newOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, false);
            }
            else
            {
                newOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, false);
            }
            var newPerformanceChainRatio = newOrderChainRatio.Sum(o => o.Price);
            var target = await liveAnchorMonthlyTargetService.GetPerformance(year, month);
            //带货业绩同比
            var commercePerformanceYearOnYear = await liveAnchorMonthlyTargetService.GetPerformance(year - 1, month);
            LiveAnchorMonthTargetPerformanceDto liveAnchorMonthTargetPerformanceDto = new LiveAnchorMonthTargetPerformanceDto();
            //带货业绩环比
            if (month == 1)
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetService.GetPerformance(year - 1, 12);
            }
            else
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetService.GetPerformance(year, month - 1);
            }
            MonthPerformanceDto monthPerformanceDto = new MonthPerformanceDto
            {
                CueerntMonthTotalPerformance = curTotalPerformance,
                CurrentMonthNewCustomerPerformance = curNewCustomer,
                CurrentMonthOldCustomerPerformance = curOldCustomer,
                CurrentMonthCommercePerformance = target.CommerceCompletePerformance,
                PerformanceYearOnYear = totalPerformanceYearOnYear,
                PerformanceChainRatio = totalPerformanceChainRatio,
                NewCustomerYearOnYear = newPerformanceYearOnYear,
                NewCustomerChainRatio = newPerformanceChainRatio,
                OldCustomerYearOnYear = oldPerformanceYearOnYear,
                OldCustomerChainRation = oldPerformanceRatio,
                CommercePerformanceYearOnYear = commercePerformanceYearOnYear.CommerceCompletePerformance,
                CommercePerformanceChainRation = liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance
            };
            return monthPerformanceDto;

        }

        public async Task<MonthDealPerformanceDto> GetMonthDealPerformanceAsync(int year, int month)
        {
            MonthDealPerformanceDto monthPerformanceDto = new MonthDealPerformanceDto();

            #region 【当月派单当月成交数据】
            var thisMonthSendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, false);
            //当月派单当月成交
            monthPerformanceDto.ThisMonthSendOrderDealPrice = thisMonthSendOrder.Sum(x => x.Price);

            List<ContentPlatFormOrderDealInfoDto> lastThisMonthOrder = null;
            if (month == 1)
            {
                lastThisMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, 12, false);
            }
            else
            {
                lastThisMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month - 1, false);
            }
            //上月的当月派单当月成交
            var lastMonthTotalPerformance = lastThisMonthOrder.Sum(o => o.Price);
            monthPerformanceDto.LastMonthTotalPerformance = CalculateChainratio(monthPerformanceDto.ThisMonthSendOrderDealPrice, lastMonthTotalPerformance);
            //上年的当月派单当月成交
            var lastYearOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, false);
            var lastYearTotalPerformance = lastYearOrder.Sum(o => o.Price);
            monthPerformanceDto.LastYearTotalPerformance = CalculateYearOnYear(monthPerformanceDto.ThisMonthSendOrderDealPrice, lastYearTotalPerformance);

            #endregion

            #region 【历史派单当月成交数据】
            var historyMonthSendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, true);
            //历史派单当月成交
            monthPerformanceDto.HistoryMonthSendOrderDealPrice = historyMonthSendOrder.Sum(x => x.Price);
            List<ContentPlatFormOrderDealInfoDto> lastHisToryMonthOrder = null;
            if (month == 1)
            {
                lastHisToryMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, 12, true);
            }
            else
            {
                lastHisToryMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month - 1, true);
            }
            //上月的历史派单当月成交
            var lastMonthHistorySendTotalPerformance = lastHisToryMonthOrder.Sum(o => o.Price);
            monthPerformanceDto.LastMonthHistorySendTotalPerformance = CalculateChainratio(monthPerformanceDto.HistoryMonthSendOrderDealPrice, lastMonthHistorySendTotalPerformance);

            //上年的历史派单当月成交
            var lastYearHistorySendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, true);
            var lastYearHistorySendTotalPerformance = lastYearHistorySendOrder.Sum(o => o.Price);
            monthPerformanceDto.LastYearHistorySendTotalPerformance = CalculateYearOnYear(monthPerformanceDto.HistoryMonthSendOrderDealPrice, lastYearHistorySendTotalPerformance);
            #endregion

            monthPerformanceDto.AccountedForDuringMonthSendDuringMonthDealDetails = CalculateTargetComplete(monthPerformanceDto.ThisMonthSendOrderDealPrice, monthPerformanceDto.ThisMonthSendOrderDealPrice + monthPerformanceDto.HistoryMonthSendOrderDealPrice);

            monthPerformanceDto.AccountedForHistorySendDuringMonthDealDetails = CalculateTargetComplete(monthPerformanceDto.HistoryMonthSendOrderDealPrice, monthPerformanceDto.ThisMonthSendOrderDealPrice + monthPerformanceDto.HistoryMonthSendOrderDealPrice);
            return monthPerformanceDto;

        }


        public async Task<GroupPerformanceDto> GetGroupPerformanceAsync(int year, int month)
        {
            GroupPerformanceDto groupPerformanceDto = new GroupPerformanceDto();

            #region 【刀刀组业绩】

            #endregion

            #region 【吉娜组业绩】

            #endregion

            #region 【合作达人业绩】
            var cooperationLiveAnchorPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year, month, "d2e71501-7327-4883-9294-371a77c4cabd");
            //本月量
            groupPerformanceDto.CooperationLiveAnchorPerformance = cooperationLiveAnchorPerformance.GroupPerformance;
            //同比
            var cooperationLiveAnchorPerformanceYearToYear = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year - 1, month, "d2e71501-7327-4883-9294-371a77c4cabd");
            groupPerformanceDto.CooperationLiveAnchorPerformanceYearOnYear = CalculateYearOnYear(cooperationLiveAnchorPerformance.GroupPerformance, cooperationLiveAnchorPerformanceYearToYear.GroupPerformance);
            //环比
            GroupPerformanceListDto monthCooperationLiveAnchorPerformance = new GroupPerformanceListDto();
            if (month == 1)
            {
                monthCooperationLiveAnchorPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year - 1, 12, "d2e71501-7327-4883-9294-371a77c4cabd");
            }
            else
            {
                monthCooperationLiveAnchorPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year, month - 1, "d2e71501-7327-4883-9294-371a77c4cabd");
            }
            groupPerformanceDto.CooperationLiveAnchorPerformanceChainRatio = CalculateChainratio(cooperationLiveAnchorPerformance.GroupPerformance, monthCooperationLiveAnchorPerformance.GroupPerformance);
            //目标达成
            groupPerformanceDto.CooperationLiveAnchorPerformanceCompleteRate = CalculateTargetComplete(cooperationLiveAnchorPerformance.GroupPerformance, cooperationLiveAnchorPerformance.GroupTargetPerformance);
            #endregion

            #region 【黄V组业绩】
            var groupYellowVPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year, month, "2bd8b9ad-afd7-4982-b783-fcad7d342f11");
            //本月量
            groupPerformanceDto.CooperationLiveAnchorPerformance = groupYellowVPerformance.GroupPerformance;
            //同比
            var groupYellowVPerformanceYearToYear = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year - 1, month, "2bd8b9ad-afd7-4982-b783-fcad7d342f11");
            groupPerformanceDto.CooperationLiveAnchorPerformanceYearOnYear = CalculateYearOnYear(groupYellowVPerformance.GroupPerformance, groupYellowVPerformanceYearToYear.GroupPerformance);
            //环比
            GroupPerformanceListDto monthGroupYellowVPerformance = new GroupPerformanceListDto();
            if (month == 1)
            {
                monthGroupYellowVPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year - 1, 12, "2bd8b9ad-afd7-4982-b783-fcad7d342f11");
            }
            else
            {
                monthGroupYellowVPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year, month - 1, "2bd8b9ad-afd7-4982-b783-fcad7d342f11");
            }
            groupPerformanceDto.CooperationLiveAnchorPerformanceChainRatio = CalculateChainratio(groupYellowVPerformance.GroupPerformance, monthGroupYellowVPerformance.GroupPerformance);
            //目标达成
            groupPerformanceDto.CooperationLiveAnchorPerformanceCompleteRate = CalculateTargetComplete(groupYellowVPerformance.GroupPerformance, groupYellowVPerformance.GroupTargetPerformance);
            #endregion

            //各分组业绩占比
            decimal sumPerformance = groupPerformanceDto.GroupDaoDaoPerformance.Value + groupPerformanceDto.GroupJinaPerformance.Value + groupPerformanceDto.CooperationLiveAnchorPerformance.Value + groupPerformanceDto.GroupYellowVPerformance.Value;
            groupPerformanceDto.AccountedForGroupDaoDaoPerformance = CalculateTargetComplete(groupPerformanceDto.GroupDaoDaoPerformance.Value, sumPerformance);


            groupPerformanceDto.AccountedForGroupJinaPerformance = CalculateTargetComplete(groupPerformanceDto.GroupJinaPerformance.Value, sumPerformance);


            groupPerformanceDto.AccountedForCooperationLiveAnchorPerformance = CalculateTargetComplete(groupPerformanceDto.CooperationLiveAnchorPerformance.Value, sumPerformance);


            groupPerformanceDto.AccountedForGroupYellowVPerformance = CalculateTargetComplete(groupPerformanceDto.GroupYellowVPerformance.Value, sumPerformance);

            return groupPerformanceDto;

        }

        /// <summary>
        /// 获取当月/历史派单当月成交折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHistorySendThisMonthDealOrders(int year, int month, bool isOldSendOrder)
        {
            var brokenLine = await contentPlatFormOrderDealInfoService.GetHistoryAndThisMonthOrderPerformance(year, month, isOldSendOrder);
            var list = brokenLine.ToList();
            return BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, list);

        }

        /// <summary>
        /// 根据主播平台获取折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="contentPlatFormId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceAsync(int year, int month, string contentPlatFormId)
        {
            var brokenLine = await liveAnchorMonthlyTargetService.GetLiveAnchorPerformanceBrokenLineAsync(year, contentPlatFormId);
            var list = brokenLine.ToList();
            return BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, list);

        }

        public async Task<MonthPerformanceRatioDto> GetMonthPerformanceAndRation(int year, int month)
        {

            var order = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month, null);
            #region 总业绩
            var curTotalPerformance = order.Sum(o => o.Price);
            var orderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, null);
            var totalPerformanceYearOnYear = orderYearOnYear.Sum(o => o.Price);

            List<ContentPlatFormOrderDealInfoDto> orderChain = null;
            if (month == 1)
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, null);
            }
            else
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, null);
            }
            var totalPerformanceChainRatio = orderChain.Sum(o => o.Price);
            #endregion


            #region 新客业绩
            var curNewCustomer = order.Where(o => o.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, false);
            var newPerformanceYearOnYear = newOrderYearOnYear.Sum(o => o.Price);
            List<ContentPlatFormOrderDealInfoDto> newOrderChainRatio = null;
            if (month == 1)
            {
                newOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, false);
            }
            else
            {
                newOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, false);
            }
            var newPerformanceChainRatio = newOrderChainRatio.Sum(o => o.Price);
            #endregion


            #region 老客业绩
            var curOldCustomer = order.Where(o => o.IsOldCustomer == true).Sum(o => o.Price);

            var oldOrderYearOnYearr = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, true);
            var oldPerformanceYearOnYear = oldOrderYearOnYearr.Sum(o => o.Price);
            List<ContentPlatFormOrderDealInfoDto> oldOrderChainRatio = null;
            if (month == 1)
            {
                oldOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, true);
            }
            else
            {
                oldOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, true);
            }
            var oldPerformanceRatio = oldOrderChainRatio.Sum(o => o.Price);
            #endregion


            #region 带货业绩
            var target = await liveAnchorMonthlyTargetService.GetPerformance(year, month);
            var commercePerformanceYearOnYear = await liveAnchorMonthlyTargetService.GetPerformance(year - 1, month);
            LiveAnchorMonthTargetPerformanceDto liveAnchorMonthTargetPerformanceDto = new LiveAnchorMonthTargetPerformanceDto();
            if (month == 1)
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetService.GetPerformance(year - 1, 12);
            }
            else
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetService.GetPerformance(year, month - 1);
            }
            #endregion
            MonthPerformanceRatioDto monthPerformanceRatioDto = new MonthPerformanceRatioDto
            {
                CueerntMonthTotalPerformance = curTotalPerformance + target.CommerceCompletePerformance,
                CurrentMonthNewCustomerPerformance = curNewCustomer,
                CurrentMonthOldCustomerPerformance = curOldCustomer,
                CurrentMonthCommercePerformance = target.CommerceCompletePerformance,
                TotalPerformanceYearOnYear = CalculateYearOnYear(curTotalPerformance + target.CommerceCompletePerformance, totalPerformanceYearOnYear + commercePerformanceYearOnYear.CommerceCompletePerformance),
                TotalPerformanceChainratio = CalculateChainratio(curTotalPerformance + target.CommerceCompletePerformance, totalPerformanceChainRatio + liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                TotalPerformanceTargetComplete = CalculateTargetComplete(curTotalPerformance + target.CommerceCompletePerformance, target.CommercePerformanceTarget + target.TotalPerformanceTarget),
                NewCustomerPerformanceYearOnYear = CalculateYearOnYear(curNewCustomer, newPerformanceYearOnYear),
                NewCustomerPerformanceChainRatio = CalculateChainratio(curNewCustomer, newPerformanceChainRatio),
                NewCustomerPerformanceTargetComplete = CalculateTargetComplete(curNewCustomer, target.NewCustomerPerformanceTarget),
                OldCustomerPerformanceYearOnYear = CalculateYearOnYear(curOldCustomer, oldPerformanceYearOnYear),
                OldCustomerPerformanceChainRatio = CalculateChainratio(curOldCustomer, oldPerformanceRatio),
                OldCustomerTargetComplete = CalculateTargetComplete(curOldCustomer, target.OldCustomerPerformanceTarget),
                CommercePerformanceYearOnYear = CalculateYearOnYear(target.CommerceCompletePerformance, commercePerformanceYearOnYear.CommerceCompletePerformance),
                CommercePerformanceChainRatio = CalculateChainratio(target.CommerceCompletePerformance, liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                CommercePerformanceTargetComplete = CalculateTargetComplete(target.CommerceCompletePerformance, target.CommercePerformanceTarget),
                NewCustomerPerformanceRatio = CalculateTargetComplete(curNewCustomer, curTotalPerformance + target.CommerceCompletePerformance),
                OldCustomerPerformanceRatio = CalculateTargetComplete(curOldCustomer, curTotalPerformance + target.CommerceCompletePerformance),
                CommercePerformanceRatio = CalculateTargetComplete(target.CommerceCompletePerformance, curTotalPerformance + target.CommerceCompletePerformance)
            };


            return monthPerformanceRatioDto;
        }
        /// <summary>
        /// 计算同比增长率
        /// </summary>
        /// <param name="currentMonthPerformance">当前月业绩</param>
        /// <param name="performanceYearOnYear">同比业绩</param>
        /// <returns></returns>
        private decimal? CalculateYearOnYear(decimal currentMonthPerformance, decimal performanceYearOnYear)
        {
            if (performanceYearOnYear == 0m)
                return null;
            return Math.Round((currentMonthPerformance - performanceYearOnYear) / performanceYearOnYear * 100, 2);
        }
        /// <summary>
        /// 计算环比增长率
        /// </summary>
        /// <param name="currentMonthPerformance">当前月业绩</param>
        /// <param name="performanceChainRatio">环比业绩</param>
        /// <returns></returns>
        private decimal? CalculateChainratio(decimal currentMonthPerformance, decimal performanceChainRatio)
        {
            if (performanceChainRatio == 0m)
                return null;
            return Math.Round((currentMonthPerformance - performanceChainRatio) / performanceChainRatio * 100, 2);
        }
        /// <summary>
        /// 计算目标达成率
        /// </summary>
        /// <param name="completePerformance">已完成业绩</param>
        /// <param name="monthTarget">目标业绩</param>
        /// <returns></returns>
        private decimal? CalculateTargetComplete(decimal completePerformance, decimal monthTarget)
        {
            if (monthTarget == 0m)
                return null;
            return Math.Round(completePerformance / monthTarget * 100, 2);
        }
    }
}
