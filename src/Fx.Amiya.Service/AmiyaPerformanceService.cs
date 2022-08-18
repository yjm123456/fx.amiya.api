using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
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

            //业绩环比
            List<ContentPlatFormOrderDealInfoDto> orderChain = null;
            if (month == 1)
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, null);
            }
            else
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month-1, null);
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
                CommercePerformanceYearOnYear=commercePerformanceYearOnYear.CommerceCompletePerformance,
                CommercePerformanceChainRation= liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance
            };
            return monthPerformanceDto;

        }
    }
}
