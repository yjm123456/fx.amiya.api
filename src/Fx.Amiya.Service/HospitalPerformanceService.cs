using Fx.Amiya.Dto.HospitalPerformance;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HospitalPerformanceService : IHospitalPerformanceService
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private IContentPlatformOrderSendService contentPlatformOrderSendService;

        public HospitalPerformanceService(IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            IContentPlatformOrderSendService contentPlatformOrderSendService)
        {
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.contentPlatformOrderSendService = contentPlatformOrderSendService;
        }

        /// <summary>
        /// 获取全国机构日运营数据概况
        /// </summary>
        /// <returns></returns>
        public async Task<List<HospitalPerformanceDto>> GetHospitalDailyPerformanceAsync()
        {
            List<HospitalPerformanceDto> resultList = new List<HospitalPerformanceDto>();
            var contentPlatFormOrderSendList = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync();
            DateTime today = DateTime.Now;
            foreach (var x in contentPlatFormOrderSendList)
            {
                var isExistHosiptal = resultList.Where(x => x.HospitalId == x.HospitalId).Count();
                if (isExistHosiptal > 0)
                {
                    continue;
                }
                HospitalPerformanceDto hospitalPerformanceDto = new HospitalPerformanceDto();
                hospitalPerformanceDto.HospitalId = x.SendHospitalId;
                hospitalPerformanceDto.HospitalName = x.SendHospital;
                hospitalPerformanceDto.City = x.City;
                hospitalPerformanceDto.SendNum = contentPlatFormOrderSendList.Where(z => z.SendHospitalId == x.SendHospitalId).Count();

                var contentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(x.SendHospitalId, today);
                hospitalPerformanceDto.VisitNum = contentPlatFormOrderDealInfoList.Count();
                hospitalPerformanceDto.VisitRate = CalculateTargetComplete(hospitalPerformanceDto.VisitNum, hospitalPerformanceDto.SendNum).Value;
                var dealInfoList = contentPlatFormOrderDealInfoList.Where(x => x.IsDeal == true);
                hospitalPerformanceDto.NewCustomerDealNum = dealInfoList.Where(x => x.IsOldCustomer == false).Count();
                hospitalPerformanceDto.NewCustomerDealRate = CalculateTargetComplete(hospitalPerformanceDto.NewCustomerDealNum, hospitalPerformanceDto.VisitNum).Value;
                hospitalPerformanceDto.NewCustomerAchievement = dealInfoList.Where(x => x.IsOldCustomer == false).Sum(x => x.Price);
                hospitalPerformanceDto.NewCustomerUnitPrice = hospitalPerformanceDto.NewCustomerAchievement / hospitalPerformanceDto.NewCustomerDealNum;

                hospitalPerformanceDto.OldCustomerDealNum = dealInfoList.Where(x => x.IsOldCustomer == true).Count();
                hospitalPerformanceDto.OldCustomerAchievement = dealInfoList.Where(x => x.IsOldCustomer == true).Sum(x => x.Price);
                hospitalPerformanceDto.OldCustomerUnitPrice = hospitalPerformanceDto.OldCustomerAchievement / hospitalPerformanceDto.OldCustomerDealNum;
                hospitalPerformanceDto.TotalAchievement = dealInfoList.Sum(x => x.Price);
                hospitalPerformanceDto.NewOrOldCustomerRate = CalculateAccounted(hospitalPerformanceDto.NewCustomerAchievement, hospitalPerformanceDto.OldCustomerAchievement);
                resultList.Add(hospitalPerformanceDto);
            }

            return resultList;
        }

        #region【公共使用业务，包括折线图，业绩明细等】


        #endregion

        #region  【内部方法】
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
        /// <summary>
        /// 计算占比
        /// </summary>
        /// <param name="completePerformance">a数据</param>
        /// <param name="monthTarget">b数据</param>
        /// <returns></returns>
        private string CalculateAccounted(decimal dataA, decimal dataB)
        {
            Decimal count = dataA + dataB;
            if (dataB == 0m && dataA == 0)
                return "5:5";
            var dataAcount = Math.Round(dataA / count * 10, 1);
            var dataBcount = Math.Round(dataB / count * 10, 1);
            return dataAcount.ToString() + ":" + dataBcount.ToString();
        }

        #endregion
    }
}