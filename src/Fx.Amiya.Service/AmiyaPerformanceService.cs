using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IService;
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
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, null);
            }
            else
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, null);
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

        public async Task<MonthDealPerformanceDto> GetMonthDealPerformance(int year, int month)
        {
            #region 【当月派单当月成交数据】
            var thisMonthSendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, false);
            //当月派单当月成交
            var thisMonthSendOrderDealPrice = thisMonthSendOrder.Sum(x => x.Price);

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

            var lastYearOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, false);
            //上年的当月派单当月成交
            var lastYearTotalPerformance = lastYearOrder.Sum(o => o.Price);
            #endregion

            #region 【历史派单当月成交数据】
            var historyMonthSendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, true);
            //历史派单当月成交
            var historyMonthSendOrderDealPrice = historyMonthSendOrder.Sum(x => x.Price);

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

            var lastYearHistorySendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, true);
            //上年的历史派单当月成交
            var lastYearHistorySendTotalPerformance = lastYearHistorySendOrder.Sum(o => o.Price);
            #endregion

            MonthDealPerformanceDto monthPerformanceDto = new MonthDealPerformanceDto
            {
                ThisMonthSendOrderDealPrice = thisMonthSendOrderDealPrice,
                LastYearTotalPerformance = lastYearTotalPerformance,
                LastMonthTotalPerformance = lastMonthTotalPerformance,
                HistoryMonthSendOrderDealPrice = historyMonthSendOrderDealPrice,
                LastYearHistorySendTotalPerformance = lastYearHistorySendTotalPerformance,
                LastMonthHistorySendTotalPerformance = lastMonthHistorySendTotalPerformance,
            };
            return monthPerformanceDto;

        }

        /// <summary>
        /// 获取当月/历史派单当月成交折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHistorySendThisMonthDealOrders(int year, int month,bool isOldSendOrder)
        {
            var brokenLine = await contentPlatFormOrderDealInfoService.GetHistoryAndThisMonthOrderPerformance(year, month, isOldSendOrder);
            return brokenLine.ToList();
        }

    }
}
