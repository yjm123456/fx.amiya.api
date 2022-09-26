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
        /// 根据时间获取全国机构运营数据概况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        public async Task<List<HospitalPerformanceDto>> GetHospitalPerformanceByDateAsync(int? year, int? month, bool isCity)
        {
            List<HospitalPerformanceDto> resultList = new List<HospitalPerformanceDto>();
            DateTime date = DateTime.Now;
            if (year.HasValue == true)
            {
                date = Convert.ToDateTime(year + "-01-01");
            }
            if (month.HasValue == true)
            {
                date = Convert.ToDateTime(DateTime.Now.Year + "-" + month.Value + "-01");
            }
            //获取所有时间符合的派单数据
            var contentPlatFormOrderSendList = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(date);
            //遍历数据
            foreach (var x in contentPlatFormOrderSendList)
            {
                var isExist = 0;
                //判断是按城市还是医院
                if (isCity == true)
                {
                    //按城市先判断结果列表中是否已包含当前城市
                    isExist = resultList.Where(z => z.City == x.City).Count();
                }
                else
                {
                    //判断当前医院是否已存在
                    isExist = resultList.Where(z => z.HospitalId == x.SendHospitalId).Count();
                }
                //已存在返回
                if (isExist > 0)
                {
                    continue;
                }
                HospitalPerformanceDto hospitalPerformanceDto = new HospitalPerformanceDto();
                hospitalPerformanceDto.HospitalId = x.SendHospitalId;
                hospitalPerformanceDto.HospitalName = x.SendHospital;
                hospitalPerformanceDto.City = x.City;
                hospitalPerformanceDto.SendNum = contentPlatFormOrderSendList.Where(z => z.SendHospitalId == x.SendHospitalId).Count();

                List<int> hospitalIds = new List<int>();
                //如果是按城市获取该城市的所有医院
                if (isCity)
                {
                    hospitalIds = contentPlatFormOrderSendList.Where(c => c.City == x.City).Select(c => c.SendHospitalId).Distinct().ToList();
                }
                else
                {
                    hospitalIds.Add(x.SendHospitalId);
                }
                var contentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceByHospitalIdAsync(hospitalIds, date);
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
            var sendOrderPerformanceList = await sendOrderInfoService.GetTopTenHospitalSendOrderPerformance();
            var sendOrderPerformance = await sendOrderInfoService.GetTotalSendCount();


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

            var sendOrderPerformanceList = await sendOrderInfoService.GetTopTenCitySendOrderPerformance();
            var sendOrderPerformance = await sendOrderInfoService.GetTotalSendCount();
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