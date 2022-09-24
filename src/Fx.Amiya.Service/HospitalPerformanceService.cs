using Fx.Amiya.Dto.HospitalPerformance;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IService;
using jos_sdk_net.Util;
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
        /// 获取全国机构日/年运营数据概况
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public async Task<List<HospitalPerformanceDto>> GetHospitalDailyPerformanceAsync(int? year)
        {
            List<HospitalPerformanceDto> resultList = new List<HospitalPerformanceDto>();
            var contentPlatFormOrderSendList = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(year);
            DateTime date = DateTime.Now;
            if (year.HasValue == true)
            {
                date = Convert.ToDateTime(year + "-01-01");
            }
            foreach (var x in contentPlatFormOrderSendList)
            {
                var isExistHosiptal = resultList.Where(z => z.HospitalId == x.SendHospitalId).Count();
                if (isExistHosiptal > 0)
                {
                    continue;
                }
                HospitalPerformanceDto hospitalPerformanceDto = new HospitalPerformanceDto();
                hospitalPerformanceDto.HospitalId = x.SendHospitalId;
                hospitalPerformanceDto.HospitalName = x.SendHospital;
                hospitalPerformanceDto.City = x.City;
                hospitalPerformanceDto.SendNum = contentPlatFormOrderSendList.Where(z => z.SendHospitalId == x.SendHospitalId).Count();

                var contentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(x.SendHospitalId, date);
                hospitalPerformanceDto.VisitNum = contentPlatFormOrderDealInfoList.Count();
                hospitalPerformanceDto.VisitRate = CalculateTargetComplete(hospitalPerformanceDto.VisitNum, hospitalPerformanceDto.SendNum).Value;
                var dealInfoList = contentPlatFormOrderDealInfoList.Where(x => x.IsDeal == true);
                hospitalPerformanceDto.NewCustomerDealNum = dealInfoList.Where(x => x.IsOldCustomer == false).Count();
                hospitalPerformanceDto.NewCustomerDealRate = CalculateTargetComplete(hospitalPerformanceDto.NewCustomerDealNum, hospitalPerformanceDto.VisitNum).Value;
                hospitalPerformanceDto.NewCustomerAchievement = dealInfoList.Where(x => x.IsOldCustomer == false).Sum(x => x.Price);
                hospitalPerformanceDto.NewCustomerUnitPrice = this.Division(hospitalPerformanceDto.NewCustomerAchievement, hospitalPerformanceDto.NewCustomerDealNum).Value;

                hospitalPerformanceDto.OldCustomerDealNum = dealInfoList.Where(x => x.IsOldCustomer == true).Count();
                hospitalPerformanceDto.OldCustomerAchievement = dealInfoList.Where(x => x.IsOldCustomer == true).Sum(x => x.Price);
                hospitalPerformanceDto.OldCustomerUnitPrice = this.Division(hospitalPerformanceDto.OldCustomerAchievement, hospitalPerformanceDto.OldCustomerDealNum).Value;
                hospitalPerformanceDto.TotalAchievement = dealInfoList.Sum(x => x.Price);
                hospitalPerformanceDto.NewOrOldCustomerRate = CalculateAccounted(hospitalPerformanceDto.NewCustomerAchievement, hospitalPerformanceDto.OldCustomerAchievement);
                resultList.Add(hospitalPerformanceDto);
            }

            return resultList;
        }


        #region【公共使用业务，包括折线图，业绩明细等】

        /// <summary>
        /// 获取全年医院派单量折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHospitalSendOrderNum(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            //派单情况
            var sendOrder = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(year);
            //派单折线图转换
            var sendOrderBrokenLine = sendOrder.Where(x => x.SendHospitalId == hospitalId).GroupBy(x => x.SendDate.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changeSendOrderBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, sendOrderBrokenLine);
            return changeSendOrderBrokenLine;
        }


        /// <summary>
        /// 获取全年医院上门数折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHospitalVisitNum(int year, int hospitalId)
        {
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            var visit = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var visitBrokenLine = visit.Where(x => x.IsToHospital == true).GroupBy(x => x.ToHospitalDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changevisitBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, visitBrokenLine);
            return changevisitBrokenLine;
        }
        /// <summary>
        /// 获取全年医院上门率折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<HospitalVisitRateDto>> GetHospitalVisitRateNum(int year, int hospitalId)
        {
            //当前医院派单情况
            var sendOrder = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(year);
            var sendOrderBrokenLine = sendOrder.Where(x => x.SendHospitalId == hospitalId).GroupBy(x => x.SendDate.Month).Select(x => new HospitalVisitRateDto { Date = x.Key.ToString(), SendOrderNum = x.Count() }).ToList();
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            var visit = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var visitBrokenLine = visit.Where(x => x.IsToHospital == true).GroupBy(x => x.ToHospitalDate.Value.Month).Select(x => new HospitalVisitRateDto { Date = x.Key.ToString(), VisitNum = x.Count() }).ToList();
            foreach (var x in sendOrderBrokenLine)
            {
                var visitnumInfo = visitBrokenLine.Where(z => z.Date == x.Date).Select(k => k.VisitNum).FirstOrDefault();
                x.VisitNum = visitnumInfo;
                x.PerfomancePrice = CalculateTargetComplete(x.VisitNum, x.SendOrderNum).Value;
            }
            var changevisitBrokenLine = BreakLineClassUtil<HospitalVisitRateDto>.Convert(month, sendOrderBrokenLine);
            return changevisitBrokenLine;
        }

        /// <summary>
        /// 获取全年医院新客成交数折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHospitalNewCustomerDealNum(int year, int hospitalId)
        {
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var newCustomerDealBrokenLine = newCustomerDeal.Where(x => x.IsToHospital == true && x.IsDeal == true && x.DealDate.HasValue == true && x.IsOldCustomer == false).GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changedealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, newCustomerDealBrokenLine);
            return changedealBrokenLine;
        }

        /// <summary>
        /// 获取全年医院新客成交率折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<HospitalDealRateDto>> GetHospitalNewCustomerDealRateNum(int year, int hospitalId)
        {
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            //当前医院上门情况
            var visit = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var visitBrokenLine = visit.Where(x => x.IsToHospital == true).GroupBy(x => x.ToHospitalDate.Value.Month).Select(x => new HospitalDealRateDto { Date = x.Key.ToString(), VisitNum = x.Count() }).ToList();

            //当前医院新客成交情况
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var newCustomerDealBrokenLine = newCustomerDeal.Where(x => x.IsToHospital == true && x.IsDeal == true && x.DealDate.HasValue == true && x.IsOldCustomer == false).GroupBy(x => x.DealDate.Value.Month).Select(x => new HospitalDealRateDto { Date = x.Key.ToString(), DealNum = x.Count() }).ToList();
            foreach (var x in visitBrokenLine)
            {
                var dealInfo = newCustomerDealBrokenLine.Where(z => z.Date == x.Date).Select(k => k.DealNum).FirstOrDefault();
                x.DealNum = dealInfo;
                x.PerfomancePrice = CalculateTargetComplete(x.DealNum, x.VisitNum).Value;
            }
            var changevisitBrokenLine = BreakLineClassUtil<HospitalDealRateDto>.Convert(month, visitBrokenLine);
            return changevisitBrokenLine;
        }

        /// <summary>
        /// 获取全年医院新客业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHospitalNewCustomerPerformanceNum(int year, int hospitalId)
        {
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var newCustomerDealPriceBrokenLine = newCustomerDeal.Where(x => x.IsToHospital == true && x.IsDeal == true && x.DealDate.HasValue == true && x.IsOldCustomer == false).GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Sum(p => p.Price) }).ToList();
            var changedealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, newCustomerDealPriceBrokenLine);
            return changedealBrokenLine;
        }

        /// <summary>
        /// 获取全年医院新客客单价折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<HospitalUnitPriceDto>> GetHospitalNewCustomerUnitPriceNum(int year, int hospitalId)
        {
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            //当前医院新客成交情况
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var newCustomerDealBrokenLine = newCustomerDeal.Where(x => x.IsToHospital == true && x.IsDeal == true && x.DealDate.HasValue == true && x.IsOldCustomer == false).GroupBy(x => x.DealDate.Value.Month).Select(x => new HospitalUnitPriceDto { Date = x.Key.ToString(), CustomerDealNum = x.Count() }).ToList();

            //当前医院新客业绩情况
            var newCustomerDealPriceBrokenLine = newCustomerDeal.Where(x => x.IsToHospital == true && x.IsDeal == true && x.DealDate.HasValue == true && x.IsOldCustomer == false).GroupBy(x => x.DealDate.Value.Month).Select(x => new HospitalUnitPriceDto { Date = x.Key.ToString(), CustomerPerformance = x.Sum(p => p.Price) }).ToList();
            foreach (var x in newCustomerDealBrokenLine)
            {
                var dealInfo = newCustomerDealPriceBrokenLine.Where(z => z.Date == x.Date).Select(k => k.CustomerPerformance).FirstOrDefault();
                x.CustomerPerformance = dealInfo;
                x.PerfomancePrice = Division(x.CustomerPerformance, x.CustomerDealNum).Value;
            }
            var changevisitBrokenLine = BreakLineClassUtil<HospitalUnitPriceDto>.Convert(month, newCustomerDealBrokenLine);
            return changevisitBrokenLine;
        }


        /// <summary>
        /// 获取全年医院老客成交数折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHospitalOldCustomerDealNum(int year, int hospitalId)
        {
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var newCustomerDealBrokenLine = newCustomerDeal.Where(x => x.IsToHospital == true && x.IsDeal == true && x.DealDate.HasValue == true && x.IsOldCustomer == true).GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changedealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, newCustomerDealBrokenLine);
            return changedealBrokenLine;
        }

        /// <summary>
        /// 获取全年医院老客业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHospitalOldCustomerPerformanceNum(int year, int hospitalId)
        {
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var newCustomerDealPriceBrokenLine = newCustomerDeal.Where(x => x.IsToHospital == true && x.IsDeal == true && x.DealDate.HasValue == true && x.IsOldCustomer == true).GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Sum(p => p.Price) }).ToList();
            var changedealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, newCustomerDealPriceBrokenLine);
            return changedealBrokenLine;
        }

        /// <summary>
        /// 获取全年医院老客客单价折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<HospitalUnitPriceDto>> GetHospitalOldCustomerUnitPriceNum(int year, int hospitalId)
        {
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            //当前医院老客成交情况
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalId, date);
            var newCustomerDealBrokenLine = newCustomerDeal.Where(x => x.IsToHospital == true && x.IsDeal == true && x.DealDate.HasValue == true && x.IsOldCustomer == true).GroupBy(x => x.DealDate.Value.Month).Select(x => new HospitalUnitPriceDto { Date = x.Key.ToString(), CustomerDealNum = x.Count() }).ToList();

            //当前医院老客业绩情况
            var newCustomerDealPriceBrokenLine = newCustomerDeal.Where(x => x.IsToHospital == true && x.IsDeal == true && x.DealDate.HasValue == true && x.IsOldCustomer == true).GroupBy(x => x.DealDate.Value.Month).Select(x => new HospitalUnitPriceDto { Date = x.Key.ToString(), CustomerPerformance = x.Sum(p => p.Price) }).ToList();
            foreach (var x in newCustomerDealBrokenLine)
            {
                var dealInfo = newCustomerDealPriceBrokenLine.Where(z => z.Date == x.Date).Select(k => k.CustomerPerformance).FirstOrDefault();
                x.CustomerPerformance = dealInfo;
                x.PerfomancePrice = Division(x.CustomerPerformance, x.CustomerDealNum).Value;
            }
            var changevisitBrokenLine = BreakLineClassUtil<HospitalUnitPriceDto>.Convert(month, newCustomerDealBrokenLine);
            return changevisitBrokenLine;
        }


        #endregion

        #region  【内部方法】
        /// <summary>
        /// 计算目标达成率
        /// </summary>
        /// <param name="completePerformance">已完成业绩</param>
        /// <param name="monthTarget">目标业绩</param>
        /// <returns></returns>
        public decimal? CalculateTargetComplete(decimal completePerformance, decimal monthTarget)
        {
            if (monthTarget == 0m || completePerformance == 0M)
                return 0;
            return Math.Round(completePerformance / monthTarget * 100, 2);
        }
        /// <summary>
        /// 计算占比
        /// </summary>
        /// <param name="completePerformance">a数据</param>
        /// <param name="monthTarget">b数据</param>
        /// <returns></returns>
        public string CalculateAccounted(decimal dataA, decimal dataB)
        {
            Decimal count = dataA + dataB;
            if (dataB == 0m && dataA == 0)
                return "5:5";
            var dataAcount = Math.Round(dataA / count * 10, 1);
            var dataBcount = Math.Round(dataB / count * 10, 1);
            return dataAcount.ToString() + ":" + dataBcount.ToString();
        }

        public decimal? Division(decimal? a, int? b)
        {
            if (a == 0m || b == 0M || a.HasValue == false || b.HasValue == false)
                return 0;
            return Math.Round(a.Value / b.Value, 2);
        }
        #endregion
    }
}