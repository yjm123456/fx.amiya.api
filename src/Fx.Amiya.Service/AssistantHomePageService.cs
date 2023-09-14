using Fx.Amiya.Dto.AssistantHomePage.Input;
using Fx.Amiya.Dto.AssistantHomePage.Result;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AssistantHomePageService : IAssistantHomePageService
    {
        private readonly IShoppingCartRegistrationService shoppingCartRegistrationService;
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        public AssistantHomePageService(IShoppingCartRegistrationService shoppingCartRegistrationService, IContentPlateFormOrderService contentPlateFormOrderService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService)
        {
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
        }

        public async Task<MonthPerformanceCompleteSituationDataDto> GetMonthPerformanceCompleteSituationDataAsync(QueryAssistantHomePageDataDto query)
        {
            if (!query.Date.HasValue) { 
                query.Date=DateTime.Now;
            }
            query.StartDate = new DateTime(query.Date.Value.Year, query.Date.Value.Month, 1);
            query.EndDate = query.StartDate.Value.AddMonths(1).Date;
            MonthPerformanceCompleteSituationDataDto data = new MonthPerformanceCompleteSituationDataDto();
            //小黄车数据
            var baseBusinessPerformance = await shoppingCartRegistrationService.GetAsistantMonthPerformanceDataAsync(query);
            data.TriageCount = baseBusinessPerformance.Where(x => x.AssignEmpId != 0 && x.AssignEmpId.HasValue).Count();
            data.AddWechat= baseBusinessPerformance.Where(x => x.IsAddWeChat == true && x.AssignEmpId != 0 && x.AssignEmpId.HasValue && x.IsReturnBackPrice == false).Count();

            //订单数据
            var baseOrderPerformance = await contentPlateFormOrderService.GetAssistantHomePageDataAsync(query);
            data.SenOrderCount = baseOrderPerformance.SenOrderCount;
            data.ToHospitalCount=baseOrderPerformance.ToHospitalCount;
            data.DealCount=baseOrderPerformance.DealCount;

            //业绩数据
            var performance = await contentPlatFormOrderDealInfoService.GetAssistantMonthPerformanceDataAsync(query);
            data.CompletedPerformance = performance.CompletedPerformance;
            data.NewCustomerPerformance = performance.NewCustomerPerformance;
            data.OldCustomerPerformance=performance.OldCustomerPerformance;

            data.AddWechatRatio = CalculateRatio(data.AddWechat, data.TriageCount).Value;
            data.SendOrderRatio = CalculateRatio(data.SenOrderCount, data.AddWechat).Value;
            data.ToHospitalCountRatio = CalculateRatio(data.ToHospitalCount,data.SenOrderCount).Value;
            data.DealRatio = CalculateRatio(data.DealCount, data.ToHospitalCount).Value;
            return data;
        }
        /// <summary>
        /// 计算占比
        /// </summary>
        /// <param name="completePerformance">已完成业绩</param>
        /// <param name="monthTarget">目标业绩</param>
        /// <returns></returns>
        public  decimal? CalculateRatio(decimal completePerformance, decimal monthTarget)
        {
            if (monthTarget == 0m || completePerformance == 0M)
                return 0;
            return Math.Round(completePerformance / monthTarget * 100, 2);
        }
    }
}
