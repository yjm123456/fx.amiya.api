using Fx.Amiya.Dto.CooperateLiveAnchorAchievement;
using Fx.Amiya.Dto.CooperateLiveAnchorAchievement.Input;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class CooperateLiveAnchorAchievementService : ICooperateLiveAnchorAchievementService
    {
        private readonly ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ILiveAnchorService liveAnchorService;
        private readonly IDalHospitalInfo dalHospitalInfo;

        public CooperateLiveAnchorAchievementService(ILiveAnchorBaseInfoService liveAnchorBaseInfoService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService, ILiveAnchorService liveAnchorService, IDalHospitalInfo dalHospitalInfo)
        {
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.liveAnchorService = liveAnchorService;
            this.dalHospitalInfo = dalHospitalInfo;
        }

        /// <summary>
        /// 获取合作达人业绩
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<List<CooperateLiveAnchorAchievementDto>> GetCooperateLiveAnchorAchievementAsync(DateTime checkDate)
        {
            var baseLiveAnchorIds = await liveAnchorBaseInfoService.GetCooperateLiveAnchorAsync(null);
            var liveAnchorIds = await liveAnchorService.GetLiveAnchorListByBaseInfoIdListAsync(baseLiveAnchorIds.Select(e => e.Id).ToList());
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(checkDate.Year, checkDate.Month);
            var checkDateExtension = DateTimeExtension.GetChooseDateStartDateAndEndDate(checkDate);
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(sequentialDate.StartDate, sequentialDate.EndDate, liveAnchorIds.Select(e => e.Id).ToList());
            var performanceList = order.GroupBy(e => e.BelongLiveAnchor).Select(e => new CooperateLiveAnchorAchievementDto
            {
                BaseLiveAnchorId = baseLiveAnchorIds.Where(a => a.Id == e.Key).First().Id,
                LiveanchorName = baseLiveAnchorIds.Where(a => a.Id == e.Key).First().LiveAnchorName,
                Performance = e.Sum(e => e.Price),
                NewCustomerPerformance = e.Sum(e => e.IsOldCustomer ? 0 : e.Price),
                OldCustomerPerformance = e.Sum(e => e.IsOldCustomer ? e.Price : 0),
                TodayPerformance = e.Where(e => e.DealDate >= checkDateExtension.StartDate && e.DealDate < checkDateExtension.EndDate).Sum(e => e.Price),
                TodayNewCustomerPerformance = e.Where(e => e.DealDate >= checkDateExtension.StartDate && e.DealDate < checkDateExtension.EndDate).Sum(e => e.IsOldCustomer ? 0 : e.Price),
                TodayOldCustomerPerformance = e.Where(e => e.DealDate >= checkDateExtension.StartDate && e.DealDate < checkDateExtension.EndDate).Sum(e => e.IsOldCustomer ? e.Price : 0),
            }).ToList();
            List<CooperateLiveAnchorAchievementDto> performanceData = new List<CooperateLiveAnchorAchievementDto>();
            foreach (var liveAnchor in baseLiveAnchorIds)
            {
                var performance = performanceList.Where(e => e.LiveanchorName == liveAnchor.LiveAnchorName).FirstOrDefault();
                if (performance != null)
                {
                    performanceData.Add(performance);
                }
                else
                {
                    CooperateLiveAnchorAchievementDto newPerformance = new CooperateLiveAnchorAchievementDto
                    {
                        LiveanchorName = liveAnchor.LiveAnchorName,
                    };
                    performanceData.Add(newPerformance);
                }
            }
            performanceData = performanceData.Where(e => e.Performance > 0).ToList();
            CooperateLiveAnchorAchievementDto totalPerformance = new CooperateLiveAnchorAchievementDto();
            totalPerformance.LiveanchorName = "整体业绩";
            totalPerformance.TodayPerformance = performanceData.Sum(x => x.TodayPerformance);
            totalPerformance.Performance = performanceData.Sum(e => e.Performance);
            totalPerformance.NewCustomerPerformance = performanceData.Sum(e => e.NewCustomerPerformance);
            totalPerformance.OldCustomerPerformance = performanceData.Sum(e => e.OldCustomerPerformance);
            performanceData.Add(totalPerformance);
            var result = performanceData.OrderByDescending(e => e.Performance).ToList();
            return result;
        }
        /// <summary>
        /// 获取合作达人机构业绩
        /// </summary>
        /// <returns></returns>

        public async Task<List<CooperateLiveAnchorHospitalAchievementDto>> GetCooperateLiveAnchorHospitalAchieementsAsync(DateTime checkDate)
        {
            var baseLiveAnchorIds = await liveAnchorBaseInfoService.GetCooperateLiveAnchorAsync(null);
            var liveAnchorIds = await liveAnchorService.GetLiveAnchorListByBaseInfoIdListAsync(baseLiveAnchorIds.Select(e => e.Id).ToList());
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(checkDate.Year, checkDate.Month);
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(sequentialDate.StartDate, sequentialDate.EndDate, liveAnchorIds.Select(e => e.Id).ToList());
            var totalPerformance = order.Sum(e => e.Price);
            var checkDateExtension = DateTimeExtension.GetChooseDateStartDateAndEndDate(checkDate);
            var todayTotalPerformance = order.Where(x=>x.DealDate >= checkDateExtension.StartDate && x.DealDate < checkDateExtension.EndDate).Sum(e => e.Price);
            var performanceData = order.GroupBy(e => e.LastDealHospitalId).Select(e => new CooperateLiveAnchorHospitalAchievementDto
            {
                TotalPerformance = e.Sum(e => e.Price),
                TodayTotalPerformance = e.Where(e => e.DealDate >= checkDateExtension.StartDate && e.DealDate < checkDateExtension.EndDate).Sum(e => e.Price),
                NewCustomerPerformance = e.Sum(e => e.IsOldCustomer ? 0 : e.Price),
                TodayNewCustomerPerformance = e.Where(e => e.DealDate >= checkDateExtension.StartDate && e.DealDate < checkDateExtension.EndDate).Sum(e => e.IsOldCustomer ? 0 : e.Price),
                OldCustomerPerformance = e.Sum(e => e.IsOldCustomer ? e.Price : 0),
                TodayOldCustomerPerformance = e.Where(e => e.DealDate >= checkDateExtension.StartDate && e.DealDate < checkDateExtension.EndDate).Sum(e => e.IsOldCustomer ? e.Price : 0),
                HospitalId = e.Key
            }).OrderByDescending(e => e.TotalPerformance).ToList();
            var hospitalNameList = dalHospitalInfo.GetAll().Select(e => new { Name = e.Name, Id = e.Id, Logo = e.ThumbPicUrl }).ToList();
            int index = 1;
            foreach (var item in performanceData)
            {
                item.Rank = index;
                item.HospitalName = hospitalNameList.FirstOrDefault(e => e.Id == item.HospitalId)?.Name ?? "";
                item.Logo = hospitalNameList.FirstOrDefault(e => e.Id == item.HospitalId)?.Logo ?? "";
                item.PerformanceRatio = CalculateRatio(item.TotalPerformance, totalPerformance).Value;
                item.NewCustomerPerformanceRatio = CalculateRatio(item.NewCustomerPerformance, item.TotalPerformance).Value;
                item.OldCustomerPerformanceRatio = CalculateRatio(item.OldCustomerPerformance, item.TotalPerformance).Value;
                //计算今日数据
                item.TodayPerformanceRatio = CalculateRatio(item.TodayTotalPerformance, todayTotalPerformance).Value;
                item.TodayNewCustomerPerformanceRatio = CalculateRatio(item.TodayNewCustomerPerformance, item.TodayTotalPerformance).Value;
                item.TodayOldCustomerPerformanceRatio = CalculateRatio(item.TodayOldCustomerPerformance, item.TodayTotalPerformance).Value;
                index++;
            }
            return performanceData;
        }

        /// <summary>
        /// 计算占比
        /// </summary>
        /// <param name="completePerformance">已完成业绩</param>
        /// <param name="monthTarget">目标业绩</param>
        /// <returns></returns>
        public decimal? CalculateRatio(decimal completePerformance, decimal monthTarget)
        {
            if (monthTarget == 0m || completePerformance == 0M)
                return 0;
            return Math.Round(completePerformance / monthTarget * 100, 2);
        }

    }
}
