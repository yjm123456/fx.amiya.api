﻿using Fx.Amiya.Dto.HospitalIndexData;
using Fx.Amiya.Dto.HospitalOperationData;
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
        private IContentPlatformOrderSendService contentPlatformOrderSendService;
        private IContentPlateFormOrderService contentPlateFormOrderService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ISendOrderInfoService sendOrderInfoService;

        public HospitalPerformanceService(IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            IContentPlatformOrderSendService contentPlatformOrderSendService,
            IContentPlateFormOrderService contentPlateFormOrderService,
            ISendOrderInfoService sendOrderInfoService)
        {
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.contentPlatformOrderSendService = contentPlatformOrderSendService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.sendOrderInfoService = sendOrderInfoService;
        }
        /// <summary>
        /// 机构端首页获取机构数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<HospitalDataDto> GetHospitalDataAsync(int hospitalId)
        {
            HospitalDataDto hospitalDataDto = new HospitalDataDto();
            var lastMonth = DateTime.Now.AddMonths(-1);
            var thisMonth = DateTime.Now;
            //上月筛选开始时间
            var lastMonthStartDate = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            //上月筛选结束时间
            var lastMonthEndDate = lastMonth;
            //上月派单数据
            var lastContentPlatFormOrderSendList = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndMonthAsync(hospitalId, lastMonth.Year, lastMonth.Month);
            //上月同期派单数据
            var lastSameTermContentPlatFormOrderSendList = lastContentPlatFormOrderSendList.Where(e => e.SendDate >= lastMonthStartDate && e.SendDate <= lastMonthEndDate);
            //本月派单数据
            var thisContentPlatFormOrderSendList = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndMonthAsync(hospitalId, thisMonth.Year, thisMonth.Month);
            hospitalDataDto.ThisMonthSendOrderCount = thisContentPlatFormOrderSendList.Count();
            hospitalDataDto.SendOrderCountChainRatio = CalculateChainratio(hospitalDataDto.ThisMonthSendOrderCount, lastSameTermContentPlatFormOrderSendList.Count()).Value;
            //上月成交数据
            var lastContentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetSendPerformanceByHospitalIdAndMonthAsync(hospitalId, lastMonth.Year, lastMonth.Month);
            //上月同期成交数据
            var lastSameTermContentPlatFormOrderDealInfoCount = lastContentPlatFormOrderDealInfoList.Where(e => e.DealDate >= lastMonthStartDate && e.DealDate <= lastMonthEndDate);
            //本月成交数据
            var thisContentPlatFormOrderDealInfoCount = await contentPlatFormOrderDealInfoService.GetMonthSendPerformanceByHospitalIdAsync(hospitalId, thisMonth.Year, thisMonth.Month);
            hospitalDataDto.ThisMonthDealCount = thisContentPlatFormOrderDealInfoCount;
            hospitalDataDto.DealCountChainRatio = CalculateChainratio(thisContentPlatFormOrderDealInfoCount, lastSameTermContentPlatFormOrderDealInfoCount.Count()).Value;
            //全年派单量
            hospitalDataDto.YearSendOrderCount = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndYearAsync(hospitalId, thisMonth.Year);
            //总派单量
            hospitalDataDto.TotalSendOrderCount = await contentPlatformOrderSendService.GetSendDataByHospitalIdAsync(hospitalId);
            //全年成交量
            hospitalDataDto.YearDealCount = await contentPlatFormOrderDealInfoService.GetYearSendPerformanceByHospitalIdAsync(hospitalId, thisMonth.Year);
            //总成交量
            hospitalDataDto.TotalDealCount = await contentPlatFormOrderDealInfoService.GetSendPerformanceByHospitalIdAsync(hospitalId);
            //本月派单成交率
            hospitalDataDto.ThisMonthSendOrderDealRatio = CalculateTargetComplete(thisContentPlatFormOrderDealInfoCount, thisContentPlatFormOrderSendList.Count()).Value;
            //全年派单成交率
            hospitalDataDto.YearSendOrderDealRatio = CalculateTargetComplete(hospitalDataDto.YearDealCount, hospitalDataDto.YearSendOrderCount).Value;
            return hospitalDataDto;

        }
        /// <summary>
        /// 机构端首页获取数据比率
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<HospitalDataRatioDto> GetHospitalDataRatioAsync(int hospitalId)
        {
            //上月
            var lastMonth = DateTime.Now.AddMonths(-1);
            //本月
            var thisMonth = DateTime.Now;
            //上月筛选开始时间
            var lastMonthStartDate = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            //上月筛选结束时间
            var lastMonthEndDate = lastMonth;
            //上月派单数据
            var lastContentPlatFormOrderSendList = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndMonthAsync(hospitalId, lastMonth.Year, lastMonth.Month);
            //上月同期派单数据
            var lastSameTermContentPlatFormOrderSendList = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndMonthAsync(hospitalId, lastMonth.Year, lastMonth.Month);
            //本月派单数据
            var thisContentPlatFormOrderSendList = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndMonthAsync(hospitalId, thisMonth.Year, thisMonth.Month);
            //上月全月上门与成交数据
            var lastContentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetSendPerformanceByHospitalIdAndMonthAsync(hospitalId, lastMonth.Year, lastMonth.Month);
            //上月同期上门与成交数据
            var lastSameTermContentPlatFormOrderDealInfoList = lastContentPlatFormOrderDealInfoList.Where(e => e.DealDate >= lastMonthStartDate && e.DealDate <= lastMonthEndDate);
            //本月上门与成交数据
            var thisContentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetSendPerformanceByHospitalIdAndMonthAsync(hospitalId, thisMonth.Year, thisMonth.Month);
            HospitalDataRatioDto hospitalDataRatioDto = new HospitalDataRatioDto();
            //本月上门率
            hospitalDataRatioDto.ToHospitalRatio = CalculateTargetComplete(thisContentPlatFormOrderDealInfoList.Count, thisContentPlatFormOrderSendList.Count).Value;
            //上月上门率
            var lastMonthToHospitalRatio = CalculateTargetComplete(lastSameTermContentPlatFormOrderDealInfoList.Count(), lastSameTermContentPlatFormOrderSendList.Count).Value;
            hospitalDataRatioDto.ToHospitalRatioChainRatio = CalculateChainratio(hospitalDataRatioDto.ToHospitalRatio, lastMonthToHospitalRatio).Value;


            //上月新客成交人数
            var lastDealNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true);
            //上月同期新客成交人数
            var lastSameTermDealNum = lastDealNum.Where(e => e.DealDate >= lastMonthStartDate && e.DealDate <= lastMonthEndDate);
            //上月同期新客
            var lastNewCustomerNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.DealDate >= lastMonthStartDate && x.DealDate <= lastMonthEndDate);
            //本月新客成交人数
            var thisDealNum = thisContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true);
            var thisNewCustomer = thisContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false);
            //本月新客成交率
            hospitalDataRatioDto.NewCustomerDealRatio = CalculateTargetComplete(thisDealNum.Count(), thisNewCustomer.Count()).Value;
            var lastNewCustomerDealratio = CalculateTargetComplete(lastSameTermDealNum.Count(), lastNewCustomerNum.Count()).Value;
            //新客成交率环比
            hospitalDataRatioDto.NewCustomerDealRatioChainRatio = CalculateChainratio(hospitalDataRatioDto.NewCustomerDealRatio, lastNewCustomerDealratio).Value;

            //上月老客成交人数
            var lastOldCustomerDealNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true);
            //上月同期老客成交人数
            var lastSameTermOldCustomerDealNum = lastOldCustomerDealNum.Where(e => e.DealDate >= lastMonthStartDate && e.DealDate <= lastMonthEndDate);
            //上月老客上门数
            var lastOldCustomerNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true);
            //上月同期老客上门人数
            var lastOldSameTermCustomerNum = lastContentPlatFormOrderDealInfoList.Where(e => e.DealDate >= lastMonthStartDate && e.DealDate <= lastMonthEndDate);
            //本月老客成交人数
            var thisOldCustomerDealNum = thisContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true);
            //本月老客上门数
            var thisOldCustomerNum = thisContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true);
            //本月老客成交率
            hospitalDataRatioDto.OldCustomerDealRatio = CalculateTargetComplete(thisOldCustomerDealNum.Count(), thisOldCustomerNum.Count()).Value;
            var lastOldCustomerDealratio = CalculateTargetComplete(lastSameTermOldCustomerDealNum.Count(), lastOldSameTermCustomerNum.Count()).Value;
            //老客成交率环比
            hospitalDataRatioDto.OldCustomerDealRatioChainRatio = CalculateChainratio(hospitalDataRatioDto.OldCustomerDealRatio, lastOldCustomerDealratio).Value;

            //上月新客人数
            //var lastNewCustomerCount = lastContentPlatFormOrderDealInfoList.Where(e => e.IsOldCustomer == false).Count();
            //上月同期新客人数
            var lastSameTermNewCustomerCount = lastContentPlatFormOrderDealInfoList.Where(e => e.IsOldCustomer == false && e.DealDate >= lastMonthStartDate && e.DealDate <= lastMonthEndDate).Count();
            //本月新客人数
            var thisNewCustomerCount = thisContentPlatFormOrderDealInfoList.Where(e => e.IsOldCustomer == false).Count();
            //本月新客占比
            hospitalDataRatioDto.NewCustomerRatio = CalculateTargetComplete(thisNewCustomerCount, thisContentPlatFormOrderDealInfoList.Count()).Value;
            //上月新客占比
            var lastNewCustomerRatio = CalculateTargetComplete(lastSameTermNewCustomerCount, lastSameTermContentPlatFormOrderDealInfoList.Count()).Value;
            //新客占比环比
            hospitalDataRatioDto.NewCustomerRatioChainRatio = CalculateChainratio(hospitalDataRatioDto.NewCustomerRatio, lastNewCustomerRatio).Value;

            //上月老客人数
            //var lastOldCustomerCount = lastContentPlatFormOrderDealInfoList.Where(e => e.IsOldCustomer == true).Count();
            //上月同期老客人数
            var lastSameTermOldCustomerCount = lastContentPlatFormOrderDealInfoList.Where(e => e.IsOldCustomer == true && e.DealDate >= lastMonthStartDate && e.DealDate <= lastMonthEndDate).Count();
            //本月老客人数
            var thisOldCustomerCount = thisContentPlatFormOrderDealInfoList.Where(e => e.IsOldCustomer == true).Count();
            //本月老客占比
            hospitalDataRatioDto.OldCustomerRatio = CalculateTargetComplete(thisOldCustomerCount, thisContentPlatFormOrderDealInfoList.Count()).Value;
            //上月老客占比
            var lastOldCustomerDealRatio = CalculateTargetComplete(lastSameTermOldCustomerCount, lastSameTermContentPlatFormOrderDealInfoList.Count()).Value;
            //老客占比环比
            hospitalDataRatioDto.OldCustomerRatioChainRatio = CalculateChainratio(hospitalDataRatioDto.OldCustomerRatio, lastOldCustomerDealRatio).Value;
            return hospitalDataRatioDto;
        }

        /// <summary>
        /// 根据时间获取全国机构运营数据概况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        public async Task<List<HospitalPerformanceDto>> GetHospitalPerformanceByDateAsync(int? year, int? month, bool isCity)
        {
            List<HospitalPerformanceDto> resultList = new List<HospitalPerformanceDto>();
            DateTime date = DateTime.Now.Date;
            if (year.HasValue == true)
            {
                date = Convert.ToDateTime(year + "-01-01");
            }
            if (month.HasValue == true)
            {
                date = Convert.ToDateTime(DateTime.Now.Year + "-" + month.Value + "-01");
            }
            var contentPlatFormOrderSendList = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(date);
            foreach (var x in contentPlatFormOrderSendList)
            {
                var isExist = 0;
                if (isCity == true)
                {
                    isExist = resultList.Where(z => z.City == x.City).Count();
                }
                else
                {
                    isExist = resultList.Where(z => z.HospitalId == x.SendHospitalId).Count();
                }
                if (isExist > 0)
                {
                    continue;
                }
                HospitalPerformanceDto hospitalPerformanceDto = new HospitalPerformanceDto();
                hospitalPerformanceDto.HospitalId = x.SendHospitalId;
                hospitalPerformanceDto.HospitalName = x.SendHospital;
                hospitalPerformanceDto.City = x.City;

                List<int> hospitalIds = new List<int>();
                if (isCity)
                {
                    hospitalIds = contentPlatFormOrderSendList.Where(c => c.City == x.City).Select(c => c.SendHospitalId).Distinct().ToList();
                }
                else
                {
                    hospitalIds.Add(x.SendHospitalId);
                }
                hospitalPerformanceDto.SendNum = contentPlatFormOrderSendList.Where(z => hospitalIds.Contains(z.SendHospitalId)).Count();
                var contentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalIds, date);
                hospitalPerformanceDto.VisitNum = contentPlatFormOrderDealInfoList.Count();
                hospitalPerformanceDto.VisitRate = CalculateTargetComplete(hospitalPerformanceDto.VisitNum, hospitalPerformanceDto.SendNum).Value;
                var dealInfoList = contentPlatFormOrderDealInfoList.Where(x => x.IsDeal == true && x.DealDate.HasValue == true);
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

        /// <summary>
        /// 获取选择月份全国机构运营数据概况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        public async Task<List<HospitalPerformanceDto>> GetHospitalPerformanceBymonthAsync(int? year, int? month, bool isCity)
        {
            List<HospitalPerformanceDto> resultList = new List<HospitalPerformanceDto>();
            DateTime date = DateTime.Now.Date;
            if (year.HasValue == true)
            {
                date = Convert.ToDateTime(year + "-01-01");
            }
            if (month.HasValue == true)
            {
                date = Convert.ToDateTime(DateTime.Now.Year + "-" + month.Value + "-01");
            }
            var contentPlatFormOrderSendList = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(date);
            foreach (var x in contentPlatFormOrderSendList)
            {
                var isExist = 0;
                if (isCity == true)
                {
                    isExist = resultList.Where(z => z.City == x.City).Count();
                }
                else
                {
                    isExist = resultList.Where(z => z.HospitalId == x.SendHospitalId).Count();
                }
                if (isExist > 0)
                {
                    continue;
                }
                HospitalPerformanceDto hospitalPerformanceDto = new HospitalPerformanceDto();
                hospitalPerformanceDto.HospitalId = x.SendHospitalId;
                hospitalPerformanceDto.HospitalName = x.SendHospital;
                hospitalPerformanceDto.City = x.City;

                List<int> hospitalIds = new List<int>();
                if (isCity)
                {
                    hospitalIds = contentPlatFormOrderSendList.Where(c => c.City == x.City).Select(c => c.SendHospitalId).Distinct().ToList();
                }
                else
                {
                    hospitalIds.Add(x.SendHospitalId);
                }
                hospitalPerformanceDto.SendNum = contentPlatFormOrderSendList.Where(z => hospitalIds.Contains(z.SendHospitalId)).Count();
                var contentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetMonthSendPerformanceByHospitalIdListAsync(hospitalIds, date);
                hospitalPerformanceDto.VisitNum = contentPlatFormOrderDealInfoList.Count();
                hospitalPerformanceDto.VisitRate = CalculateTargetComplete(hospitalPerformanceDto.VisitNum, hospitalPerformanceDto.SendNum).Value;
                var dealInfoList = contentPlatFormOrderDealInfoList.Where(x => x.IsDeal == true && x.DealDate.HasValue == true);
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



        /// <summary>
        /// 【新】获取选择月份全国机构运营数据概况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        public async Task<List<HospitalPerformanceDto>> GetHospitalPerformanceBymonthBWAsync(int? year, int? month)
        {
            List<HospitalPerformanceDto> resultList = new List<HospitalPerformanceDto>();
            DateTime date = DateTime.Now.Date;
            if (year.HasValue == true)
            {
                date = Convert.ToDateTime(year + "-01-01");
            }
            if (month.HasValue == true)
            {
                date = Convert.ToDateTime(DateTime.Now.Year + "-" + month.Value + "-01");
            }
            var contentPlatFormOrderSendList = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(date);
            foreach (var x in contentPlatFormOrderSendList)
            {
                var isExist = 0;
                isExist = resultList.Where(z => z.HospitalId == x.SendHospitalId).Count();
                if (isExist > 0)
                {
                    continue;
                }
                HospitalPerformanceDto hospitalPerformanceDto = new HospitalPerformanceDto();
                hospitalPerformanceDto.HospitalId = x.SendHospitalId;
                hospitalPerformanceDto.HospitalName = x.SendHospital;
                hospitalPerformanceDto.HospitalLogo = x.ThumbPictureUrl;
                List<int> hospitalIds = new List<int>();
                hospitalIds.Add(x.SendHospitalId);
                var contentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetMonthSendPerformanceByHospitalIdListAsync(hospitalIds, date);
                var dealInfoList = contentPlatFormOrderDealInfoList.Where(x => x.IsDeal == true && x.DealDate.HasValue == true);
                hospitalPerformanceDto.NewCustomerAchievement = dealInfoList.Where(x => x.IsOldCustomer == false).Sum(x => x.Price);

                hospitalPerformanceDto.OldCustomerAchievement = dealInfoList.Where(x => x.IsOldCustomer == true).Sum(x => x.Price);
                hospitalPerformanceDto.TotalAchievement = dealInfoList.Sum(x => x.Price);
                hospitalPerformanceDto.NewOrOldCustomerRate = CalculateAccounted(hospitalPerformanceDto.NewCustomerAchievement, hospitalPerformanceDto.OldCustomerAchievement);
                resultList.Add(hospitalPerformanceDto);
            }

            return resultList;
        }


        /// <summary>
        /// 根据医院id获取医院新客前月与前月业绩
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<HospitalNewCustomerAchievementDto> GetHospitalOperationDailyData(int hospitalId)
        {
            HospitalNewCustomerAchievementDto result = new HospitalNewCustomerAchievementDto();
            /*int month = DateTime.Now.Month;
            int lastMonth = 0;
            if (month != 1)
            {
                lastMonth = month - 1;
            }
            else
            {
                lastMonth = 12;
            }

            int beforeMonth = 0;
            if (month != 2)
            {
                beforeMonth = month - 2;
            }
            else
            {
                beforeMonth = 12;
            }*/

            //var month = DateTime.Now.Month;
            var lastMonth = DateTime.Now.AddMonths(-1);
            var beforeMonth = DateTime.Now.AddMonths(-2);
            //上月派单数据
            var lastContentPlatFormOrderSendList = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndMonthAsync(hospitalId, lastMonth.Year, lastMonth.Month);
            var lastsendNum = lastContentPlatFormOrderSendList.Where(z => z.SendHospitalId == hospitalId).Count();
            //上月上门与成交数据
            var lastContentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetSendPerformanceByHospitalIdAndMonthAsync(hospitalId, lastMonth.Year, lastMonth.Month);
            //上月新客上门率
            var lastVisitNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false).Count();
            result.ThisNewCustomerVisitRate = CalculateTargetComplete(lastVisitNum, lastsendNum).Value;
            //上月新客成交率
            var lastDealNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true);
            result.ThisNewCustomerDealRate = CalculateTargetComplete(lastDealNum.Count(), lastContentPlatFormOrderDealInfoList.Count()).Value;
            //上月新客客单价
            var lastCustomerTotalPrice = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true).Sum(x => x.Price);
            result.ThisNewCustomerUnitPrice = Division(lastCustomerTotalPrice, lastDealNum.Count()).Value;
            //上月老客复购率
            var lastOldCustomerVisitNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true).Count();
            result.ThisOldCustomerRepurchaseRate = CalculateTargetComplete(lastOldCustomerVisitNum, lastContentPlatFormOrderDealInfoList.Count()).Value;
            //上月老客客单价
            var lastOldCustomerTotalPrice = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true).Sum(x => x.Price);
            var lastOldDealNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true);
            result.ThisOldCustomerUnitPrice = Division(lastOldCustomerTotalPrice, lastOldDealNum.Count()).Value;

            //前月派单数据
            var beforeContentPlatFormOrderSendList = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndMonthAsync(hospitalId, beforeMonth.Year, beforeMonth.Month);
            var beforesendNum = beforeContentPlatFormOrderSendList.Where(z => z.SendHospitalId == hospitalId).Count();
            //前月上门与成交数据
            var beforeContentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetSendPerformanceByHospitalIdAndMonthAsync(hospitalId, beforeMonth.Year, beforeMonth.Month);
            //前月新客上门率
            var beforeVisitNum = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false).Count();
            result.LastNewCustomerVisitRate = CalculateTargetComplete(beforeVisitNum, beforesendNum).Value;
            //前月新客成交率
            var beforeDealNum = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true);
            result.LastNewCustomerDealRate = CalculateTargetComplete(beforeDealNum.Count(), beforeContentPlatFormOrderDealInfoList.Count()).Value;
            //前月新客客单价
            var beforeCustomerTotalPrice = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true).Sum(x => x.Price);
            result.LastNewCustomerUnitPrice = Division(beforeCustomerTotalPrice, beforeDealNum.Count()).Value;
            //前月老客复购率
            var beforeOldCustomerVisitNum = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true).Count();
            result.LastOldCustomerRepurchaseRate = CalculateTargetComplete(beforeOldCustomerVisitNum, beforeContentPlatFormOrderDealInfoList.Count()).Value;
            //前月老客客单价
            var beforeOldCustomerTotalPrice = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true).Sum(x => x.Price);
            var beforeOldDealNum = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true);
            result.LastOldCustomerUnitPrice = Division(beforeOldCustomerTotalPrice, beforeOldDealNum.Count()).Value;

            //新客上门率环比
            result.NewCustomerVisitChainRatio = CalculateChainratio(result.ThisNewCustomerVisitRate, result.LastNewCustomerVisitRate).Value;
            //新客成交率环比
            result.NewCustomerDealChainRatio = CalculateChainratio(result.ThisNewCustomerDealRate, result.LastNewCustomerDealRate).Value;
            //新客客单价环比
            result.NewCustomerUnitPriceChainRatio = CalculateChainratio(result.ThisNewCustomerUnitPrice, result.LastNewCustomerUnitPrice).Value;
            //老客复购率环比
            result.OldCustomerRepurchaseChainRatio = CalculateChainratio(result.ThisOldCustomerRepurchaseRate, result.LastOldCustomerRepurchaseRate).Value;
            //老客客单价环比
            result.OldCustomerUnitPriceChainRatio = CalculateChainratio(result.ThisOldCustomerUnitPrice, result.LastOldCustomerUnitPrice).Value;

            return result;
        }


        /// <summary>
        /// 根据医院id和时间获取前月和前月数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="date">时间</param>
        /// <returns></returns>
        public async Task<HospitalOperationTotalDataDto> GetHospitalOperationMonthData(int hospitalId, DateTime date)
        {
            HospitalOperationTotalDataDto result = new HospitalOperationTotalDataDto();
            var lastMonth = date.AddMonths(-1);
            var beforeMonth = date.AddMonths(-2);
            var lastContentPlatFormOrderSendList = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndMonthAsync(hospitalId, lastMonth.Year, lastMonth.Month);
            var lastsendNum = lastContentPlatFormOrderSendList.Where(z => z.SendHospitalId == hospitalId).Count();
            //上月派单数据
            result.ThisMonthSendOrderCount = lastsendNum;
            //上月上门与成交数据
            var lastContentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetSendPerformanceByHospitalIdAndMonthAsync(hospitalId, lastMonth.Year, lastMonth.Month);
            var lastVisitNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false).Count();
            //上月新客上门数
            result.ThisMonthNewCustomerToHospitalCount = lastVisitNum;
            //上月新客上门率
            result.ThisMonthNewCustomerToHospitalRate = CalculateTargetComplete(lastVisitNum, lastsendNum).Value;
            var lastDealNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true);
            //上月新客成交人数
            result.ThisMonthNewCustomerDealCount = lastDealNum.Count();
            //上月新客成交率
            result.ThisMonthNewCustomerDealRate = CalculateTargetComplete(lastDealNum.Count(), lastContentPlatFormOrderDealInfoList.Count()).Value;
            var lastCustomerTotalPrice = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true).Sum(x => x.Price);
            //上月新客业绩
            result.ThisMonthNewCustomerPerformance = lastCustomerTotalPrice;
            //上月新客客单价
            result.ThisMonthNewCustomerUnitPrice = Division(lastCustomerTotalPrice, lastDealNum.Count()).Value;
            //上月老客上门人数
            var lastOldCustomerVisitNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true).Count();
            result.ThisMonthOldCustomerToHospitalCount = lastOldCustomerVisitNum;
            //上月老客成交人数
            var lastOldCustomerDealNum = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true);
            result.ThisMonthOldCustomerDealCount = lastOldCustomerDealNum.Count();
            //上月老客成交率
            result.ThisMonthOldCustomerDealRate = CalculateTargetComplete(lastOldCustomerDealNum.Count(), lastContentPlatFormOrderDealInfoList.Where(e => e.IsOldCustomer == true).Count()).Value;
            //上月老客业绩
            var lastOldCustomerTotalPrice = lastContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true).Sum(x => x.Price);
            result.ThisMonthOldCustomerPerformance = lastOldCustomerTotalPrice;
            //上月老客客单价
            result.ThisMonthOldCustomerUnitPrice = Division(lastOldCustomerTotalPrice, lastOldCustomerDealNum.Count()).Value;
            //上月总业绩
            result.ThisMonthTotalPerformance = lastContentPlatFormOrderDealInfoList.Where(x => x.IsDeal == true).Sum(x => x.Price);
            //上月老客业绩占比
            result.ThisMonthOldCustomerPerformanceRatio = CalculateTargetComplete(lastOldCustomerTotalPrice, result.ThisMonthTotalPerformance).Value;


            //前月派单数据
            var beforeContentPlatFormOrderSendList = await contentPlatformOrderSendService.GetSendDataByHospitalIdAndMonthAsync(hospitalId, beforeMonth.Year, beforeMonth.Month);
            var beforesendNum = beforeContentPlatFormOrderSendList.Where(z => z.SendHospitalId == hospitalId).Count();
            //前月派单数据
            result.LastMonthSendOrderCount = beforesendNum;
            //前月上门与成交数据
            var beforeContentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetSendPerformanceByHospitalIdAndMonthAsync(hospitalId, beforeMonth.Year, beforeMonth.Month);
            var beforeVisitNum = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false).Count();
            //前月新客上门数
            result.LastMonthNewCustomerToHospitalCount = beforeVisitNum;
            //前月新客上门率
            result.LastMonthNewCustomerToHospitalRate = CalculateTargetComplete(beforeVisitNum, beforesendNum).Value;
            var beforeDealNum = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true);
            //前月新客成交人数
            result.LastMonthNewCustomerDealCount = beforeDealNum.Count();
            //前月新客成交率
            result.LastMonthNewCustomerDealRate = CalculateTargetComplete(beforeDealNum.Count(), beforeContentPlatFormOrderDealInfoList.Count()).Value;
            var beforeCustomerTotalPrice = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == false && x.IsDeal == true).Sum(x => x.Price);
            //前月新客业绩
            result.LastMonthNewCustomerPerformance = beforeCustomerTotalPrice;
            //前月新客客单价
            result.LastMonthNewCustomerUnitPrice = Division(beforeCustomerTotalPrice, beforeDealNum.Count()).Value;
            //前月老客上门人数
            var beforeOldCustomerVisitNum = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true).Count();
            result.LastMonthOldCustomerToHospitalCount = beforeOldCustomerVisitNum;
            //前月老客成交人数
            var beforeOldCustomerDealNum = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true);
            result.LastMonthOldCustomerDealCount = beforeOldCustomerDealNum.Count();
            //前月老客成交率
            result.LastMonthOldCustomerDealRate = CalculateTargetComplete(beforeOldCustomerDealNum.Count(), beforeContentPlatFormOrderDealInfoList.Where(e => e.IsOldCustomer == true).Count()).Value;
            //前月老客业绩
            var beforeOldCustomerTotalPrice = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsOldCustomer == true && x.IsDeal == true).Sum(x => x.Price);
            result.LastMonthOldCustomerPerformance = beforeOldCustomerTotalPrice;
            //前月老客客单价
            result.LastMonthOldCustomerUnitPrice = Division(beforeOldCustomerTotalPrice, beforeOldCustomerDealNum.Count()).Value;
            //前月总业绩
            result.LastMonthTotalPerformance = beforeContentPlatFormOrderDealInfoList.Where(x => x.IsDeal == true).Sum(x => x.Price);
            //前月老客业绩占比
            result.LastMonthOldCustomerPerformanceRatio = CalculateTargetComplete(beforeOldCustomerTotalPrice, result.LastMonthTotalPerformance).Value;

            result.SendOrderCountChainRatio = CalculateChainratio(result.ThisMonthSendOrderCount, result.LastMonthSendOrderCount).Value;
            result.NewCustomerToHospitalCountChainRatio = CalculateChainratio(result.ThisMonthNewCustomerToHospitalCount, result.LastMonthNewCustomerToHospitalCount).Value;
            result.NewCustomerToHospitalRateChainRatio = CalculateChainratio(result.ThisMonthNewCustomerToHospitalRate, result.LastMonthNewCustomerToHospitalRate).Value;
            result.NewCustomerDealCountChainRatio = CalculateChainratio(result.ThisMonthNewCustomerDealCount, result.LastMonthNewCustomerDealCount).Value;
            result.NewCustomerDealRateChainRatio = CalculateChainratio(result.ThisMonthNewCustomerDealRate, result.LastMonthNewCustomerDealRate).Value;
            result.NewCustomerPerformanceChainRatio = CalculateChainratio(result.ThisMonthNewCustomerPerformance, result.LastMonthNewCustomerPerformance).Value;
            result.NewCustomerUnitPriceChainRatio = CalculateChainratio(result.ThisMonthNewCustomerUnitPrice, result.LastMonthNewCustomerUnitPrice).Value;
            result.OldCustomerToHospitalCountChainRatio = CalculateChainratio(result.ThisMonthOldCustomerToHospitalCount, result.LastMonthOldCustomerToHospitalCount).Value;
            result.OldCustomerDealCountChainRatio = CalculateChainratio(result.ThisMonthOldCustomerDealCount, result.LastMonthOldCustomerDealCount).Value;
            result.OldCustomerDealRateChainRatio = CalculateChainratio(result.ThisMonthOldCustomerDealRate, result.LastMonthOldCustomerDealRate).Value;
            result.OldCustomerPerformanceChainRatio = CalculateChainratio(result.ThisMonthOldCustomerPerformance, result.LastMonthOldCustomerPerformance).Value;
            result.OldCustomerUnitPriceChainRatio = CalculateChainratio(result.ThisMonthOldCustomerUnitPrice, result.LastMonthOldCustomerUnitPrice).Value;
            result.TotalPerformanceChainRatio = CalculateChainratio(result.ThisMonthTotalPerformance, result.LastMonthTotalPerformance).Value;
            result.OldCustomerPerformanceRatioChainRatio = CalculateChainratio(result.ThisMonthOldCustomerPerformanceRatio, result.LastMonthOldCustomerPerformanceRatio).Value;

            return result;
        }

        #region 累计运营数据


        #region 合作机构top10运营数据
        public async Task<HospitalAccumulatePerformanceDto> GetTopTenHospitalPerfromance()
        {
            HospitalAccumulatePerformanceDto performanceDto = new HospitalAccumulatePerformanceDto();
            #region 总业绩
            var totalPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenHospitalTotalPerformance();
            var totalPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(null);

            HospitalPerformanceItem hospitalPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = totalPerformance,
                PerformanceList = totalPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.TotalPerformnaceRatio = hospitalPerformanceItem;
            performanceDto.TotalPerformnaceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = totalPerformance - performanceDto.TotalPerformnaceRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion

            #region 新客业绩
            var newCustomerPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenNewCustomerPerformance();
            var newCustomerPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(false);

            HospitalPerformanceItem newCustomerPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = newCustomerPerformance,
                PerformanceList = newCustomerPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.NewCustomerPerformanceRatio = newCustomerPerformanceItem;
            performanceDto.NewCustomerPerformanceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = newCustomerPerformance - performanceDto.NewCustomerPerformanceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 老客业绩
            var oldCustomerPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenOldCustomerPerformance();
            var oldCustomerPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(true);


            HospitalPerformanceItem oldCustomerPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = oldCustomerPerformance,
                PerformanceList = oldCustomerPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.OldCustomerPerformanceRatio = oldCustomerPerformanceItem;
            performanceDto.OldCustomerPerformanceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = oldCustomerPerformance - performanceDto.OldCustomerPerformanceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 派单量
            var sendOrderPerformanceList = await contentPlatformOrderSendService.GetTopTenHospitalSendOrderPerformance();
            var sendOrderPerformance = await contentPlatformOrderSendService.GetTotalSendCount();


            HospitalPerformanceItem sendOrderPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = sendOrderPerformance,
                PerformanceList = sendOrderPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.SendOrderPerformanceRatio = sendOrderPerformanceItem;
            performanceDto.SendOrderPerformanceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = sendOrderPerformance - performanceDto.SendOrderPerformanceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 新客上门人数
            var newCustomerToHospitalPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenNewCustomerToHospitalPformance();
            var newCustomerToHospitalPerformance = await contentPlatFormOrderDealInfoService.GetNewCustomerToHospitalCount();


            HospitalPerformanceItem newCustomerToHospitalPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = newCustomerToHospitalPerformance,
                PerformanceList = newCustomerToHospitalPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.NewCustomerToHospitalPerformanceRatio = newCustomerToHospitalPerformanceItem;
            performanceDto.NewCustomerToHospitalPerformanceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = newCustomerToHospitalPerformance - performanceDto.NewCustomerToHospitalPerformanceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 新客成交人数
            var newCustomerDealPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenNewCustomerDealPerformance();
            var newCustomerDealPerformance = await contentPlatFormOrderDealInfoService.GetNewCustomerDealCount();


            HospitalPerformanceItem newCustomerDealPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = newCustomerDealPerformance,
                PerformanceList = newCustomerDealPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.NewCustomerDealCountRatio = newCustomerDealPerformanceItem;
            performanceDto.NewCustomerDealCountRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = newCustomerDealPerformance - performanceDto.NewCustomerDealCountRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            return performanceDto;
        }


        #endregion

        #region 合作城市top10运营数据

        /// <summary>
        /// 获取合作城市top10运营数据占比
        /// </summary>
        /// <returns></returns>
        public async Task<CityAccumulatePerformanceDto> GetTopTenCityPerformance()
        {
            CityAccumulatePerformanceDto cityAccumulatePerformance = new CityAccumulatePerformanceDto();
            #region 总业绩

            var totalPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityTotalPerformance();
            var totalPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(null);
            CityPerformanceItem totalPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = totalPerformance,
                PerformanceList = totalPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.TotalPerformnaceRatio = totalPerformanceItem;
            cityAccumulatePerformance.TotalPerformnaceRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = totalPerformance - cityAccumulatePerformance.TotalPerformnaceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 新客业绩

            var newCustomerPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityNewCustomerPerformance();
            var newCustomerPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(false);
            CityPerformanceItem newCustomerPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = newCustomerPerformance,
                PerformanceList = newCustomerPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.NewCustomerPerformanceRatio = newCustomerPerformanceItem;
            cityAccumulatePerformance.NewCustomerPerformanceRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = newCustomerPerformance - cityAccumulatePerformance.NewCustomerPerformanceRatio.PerformanceList.Sum(c => c.Performance) });


            #endregion

            #region 老客业绩

            var oldCustomerPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityOldCustomerPerformance();
            var oldCustomerPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(true);
            CityPerformanceItem oldCustomerPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = oldCustomerPerformance,
                PerformanceList = oldCustomerPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.OldCustomerPerformanceRatio = oldCustomerPerformanceItem;
            cityAccumulatePerformance.OldCustomerPerformanceRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = oldCustomerPerformance - cityAccumulatePerformance.OldCustomerPerformanceRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion

            #region 派单占比

            var sendOrderPerformanceList = await contentPlatformOrderSendService.GetTopTenCitySendOrderPerformance();
            var sendOrderPerformance = await contentPlatformOrderSendService.GetTotalSendCount();
            CityPerformanceItem sendOrderPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = sendOrderPerformance,
                PerformanceList = sendOrderPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.SendOrderPerformanceRatio = sendOrderPerformanceItem;
            cityAccumulatePerformance.SendOrderPerformanceRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = sendOrderPerformance - cityAccumulatePerformance.SendOrderPerformanceRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion

            #region 新客上门人数占比

            var newCustomerToHospitalPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityNewCustomerToHospitalPformance();
            var newCustomerToHospitalPerformance = await contentPlatFormOrderDealInfoService.GetNewCustomerToHospitalCount();
            CityPerformanceItem newCustomerToHospitalPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = newCustomerToHospitalPerformance,
                PerformanceList = newCustomerToHospitalPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.NewCustomerToHospitalPerformanceRatio = newCustomerToHospitalPerformanceItem;
            cityAccumulatePerformance.NewCustomerToHospitalPerformanceRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = newCustomerToHospitalPerformance - cityAccumulatePerformance.NewCustomerToHospitalPerformanceRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion

            #region 新客成交人数

            var newCustomerDealPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityNewCustomerDealPerformance();
            var newCustomerDealPerformancePerformance = await contentPlatFormOrderDealInfoService.GetNewCustomerDealCount();
            CityPerformanceItem newCustomerDealPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = newCustomerDealPerformancePerformance,
                PerformanceList = newCustomerDealPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.NewCustomerDealCountRatio = newCustomerDealPerformanceItem;
            cityAccumulatePerformance.NewCustomerDealCountRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = newCustomerDealPerformancePerformance - cityAccumulatePerformance.NewCustomerDealCountRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion
            return cityAccumulatePerformance;
        }
        #endregion


        #endregion

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
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            DateTime date = Convert.ToDateTime(year + "-01-01");
            //派单情况
            var sendOrder = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(date);
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
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            var visit = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
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
            DateTime date = Convert.ToDateTime(year + "-01-01");
            //派单情况
            var sendOrder = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(date);
            var sendOrderBrokenLine = sendOrder.Where(x => x.SendHospitalId == hospitalId).GroupBy(x => x.SendDate.Month).Select(x => new HospitalVisitRateDto { Date = x.Key.ToString(), SendOrderNum = x.Count() }).ToList();
            int month = DateTime.Now.Month;
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            var visit = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
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
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
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
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            //当前医院上门情况
            var visit = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
            var visitBrokenLine = visit.Where(x => x.IsToHospital == true).GroupBy(x => x.ToHospitalDate.Value.Month).Select(x => new HospitalDealRateDto { Date = x.Key.ToString(), VisitNum = x.Count() }).ToList();

            //当前医院新客成交情况
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
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
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
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
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            //当前医院新客成交情况
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
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
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
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
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
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
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            //当前医院老客成交情况
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
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
        /// <summary>
        /// 获取全年医院总业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHospitalTotalCustomerPerformanceNum(int year, int hospitalId)
        {
            DateTime date = date = Convert.ToDateTime(year + "-01-01");
            int month = DateTime.Now.Month;
            if (year != DateTime.Now.Year)
            {
                month = 12;
            }
            var newCustomerDeal = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(new List<int> { hospitalId }, date);
            var newCustomerDealPriceBrokenLine = newCustomerDeal.Where(x => x.IsDeal == true && x.DealDate.HasValue == true).GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Sum(p => p.Price) }).ToList();
            var changedealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, newCustomerDealPriceBrokenLine);
            return changedealBrokenLine;
        }

        #endregion

        #region  【内部方法】
        /// <summary>
        /// 计算环比
        /// </summary>
        /// <param name="currentMonthPerformance"></param>
        /// <param name="performanceChainRatio"></param>
        /// <returns></returns>
        private decimal? CalculateChainratio(decimal currentMonthPerformance, decimal performanceChainRatio)
        {
            if (currentMonthPerformance == 0m || performanceChainRatio == 0m)
                return 0.00M;
            return Math.Round((currentMonthPerformance - performanceChainRatio) / performanceChainRatio * 100, 2);
        }
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
            if (dataB == 0.00m && dataA == 0.00m)
            {
                return "5:5";
            }
            if (count == 0.00M)
            {
                return "5:5";
            }
            if (dataA == 0.00M && dataB != 0.00M)
            {
                return "0:10";
            }
            if (dataA != 0.00M && dataB == 0.00M)
            {
                return "10:0";
            }
            var dataAcount = Math.Round(dataA / count * 10, 1);
            var dataBcount = Math.Round(dataB / count * 10, 1);
            return dataAcount.ToString() + ":" + dataBcount.ToString();
        }
        /// <summary>
        /// 计算客单价
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public decimal? Division(decimal? a, int? b)
        {
            if (a == 0m || b == 0M || a.HasValue == false || b.HasValue == false)
                return 0;
            return Math.Round(a.Value / b.Value, 2);
        }




        #endregion
    }
}