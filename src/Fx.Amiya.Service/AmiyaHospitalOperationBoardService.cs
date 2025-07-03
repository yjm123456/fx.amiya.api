
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AmiyaHospitalOperation.Input;
using Fx.Amiya.Dto.AmiyaHospitalOperation.Result;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Result;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AmiyaHospitalOperationBoardService : IAmiyaHospitalOperationBoardService
    {
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly IHospitalInfoService hospitalInfoService;
        private readonly IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo;
        private readonly IDalContentPlatformOrderSend _dalContentPlatformOrderSend;
        private readonly IHealthValueService _healthValueService;
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;

        public AmiyaHospitalOperationBoardService(IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo, IDalContentPlatformOrderSend dalContentPlatformOrderSend,
            IHospitalInfoService hospitalInfoService, IHealthValueService healthValueService,
            IContentPlateFormOrderService contentPlateFormOrderService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService)
        {
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.dalContentPlatFormOrderDealInfo = dalContentPlatFormOrderDealInfo;
            _dalContentPlatformOrderSend = dalContentPlatformOrderSend;
            this.hospitalInfoService = hospitalInfoService;
            this._healthValueService = healthValueService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
        }


        /// <summary>
        /// 机构业绩运营情况
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HospitalPerformanceDto> GetHospitalPerformanceAsync(QueryHospitalPerformanceDto query)
        {
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.EndDate.Year, query.EndDate.Month == 0 ? 1 : query.EndDate.Month);

            var todayPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAndHospitalIdListAsync(DateTime.Now.Date, DateTime.Now.AddDays(1).Date, query.HospitalId.Value);
            var currentContentOrderList = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(sequentialDate.EndDate.Year, sequentialDate.EndDate.Month, query.HospitalId.Value, null);
            var lastMonthContentOrderList = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(sequentialDate.LastMonthEndDate.Year, sequentialDate.LastMonthEndDate.Month, query.HospitalId.Value, null);
            var lastYearContentOrderList = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAndHospitalIdListAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, query.HospitalId.Value);
            HospitalPerformanceDto hospitalPerformance = new HospitalPerformanceDto();
            hospitalPerformance.NewCustomerPerformance = currentContentOrderList.Where(e => e.IsOldCustomer == false).Sum(e => e.Price);
            hospitalPerformance.OldCustomerPerformance = currentContentOrderList.Where(e => e.IsOldCustomer == true).Sum(e => e.Price);
            hospitalPerformance.TotalPerformance = currentContentOrderList.Sum(e => e.Price);
            hospitalPerformance.TodayNewCustomerPerformance = todayPerformance.Where(e => e.IsOldCustomer == false).Sum(e => e.Price);
            hospitalPerformance.TodayOldCustomerPerformance = todayPerformance.Where(e => e.IsOldCustomer == true).Sum(e => e.Price);
            hospitalPerformance.TodayTotalPerformance = hospitalPerformance.TodayNewCustomerPerformance + hospitalPerformance.TodayOldCustomerPerformance;
            hospitalPerformance.LastMonthNewCustomerPerformance = lastMonthContentOrderList.Where(e => e.IsOldCustomer == false).Sum(e => e.Price);
            hospitalPerformance.LastMonthOldCustomerPerformance = lastMonthContentOrderList.Where(e => e.IsOldCustomer == true).Sum(e => e.Price);
            hospitalPerformance.LastMonthTotalPerformance = hospitalPerformance.LastMonthNewCustomerPerformance + hospitalPerformance.LastMonthOldCustomerPerformance;
            hospitalPerformance.LastYearNewCustomerPerformance = lastYearContentOrderList.Where(e => e.IsOldCustomer == false).Sum(e => e.Price);
            hospitalPerformance.LastYearOldCustomerPerformance = lastYearContentOrderList.Where(e => e.IsOldCustomer == true).Sum(e => e.Price);
            hospitalPerformance.LastYearTotalPerformance = hospitalPerformance.LastYearNewCustomerPerformance + hospitalPerformance.LastYearOldCustomerPerformance;
            hospitalPerformance.NewCustomerPerformanceChain = DecimalExtension.CalculateChain(hospitalPerformance.NewCustomerPerformance, hospitalPerformance.LastMonthNewCustomerPerformance).Value;
            hospitalPerformance.OldCustomerPerformanceChain = DecimalExtension.CalculateChain(hospitalPerformance.OldCustomerPerformance, hospitalPerformance.LastMonthOldCustomerPerformance).Value;
            hospitalPerformance.TotalPerformanceChain = DecimalExtension.CalculateChain(hospitalPerformance.TotalPerformance, hospitalPerformance.LastMonthTotalPerformance).Value;
            hospitalPerformance.NewCustomerPerformanceYearOnYear = DecimalExtension.CalculateChain(hospitalPerformance.NewCustomerPerformance, hospitalPerformance.LastYearNewCustomerPerformance).Value;
            hospitalPerformance.OldCustomerPerformanceYearOnYear = DecimalExtension.CalculateChain(hospitalPerformance.OldCustomerPerformance, hospitalPerformance.LastYearOldCustomerPerformance).Value;
            hospitalPerformance.TotalPerformanceYearOnYear = DecimalExtension.CalculateChain(hospitalPerformance.TotalPerformance, hospitalPerformance.LastYearTotalPerformance).Value;
            return hospitalPerformance;
        }


        /// <summary>
        /// 机构上门运营情况
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HospitalVisitDataDto> GetHospitalVisitDataDto(QueryHospitalPerformanceDto query)
        {
            HospitalVisitDataDto result = new HospitalVisitDataDto();
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.EndDate.Year, query.EndDate.Month == 0 ? 1 : query.EndDate.Month);

            var todayOrderList = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAndHospitalIdListAsync(DateTime.Now.Date, DateTime.Now.AddDays(1).Date, query.HospitalId.Value);
            var currentContentOrderList = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(sequentialDate.EndDate.Year, sequentialDate.EndDate.Month, query.HospitalId.Value, null);
            var lastMonthContentOrderList = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(sequentialDate.LastMonthEndDate.Year, sequentialDate.LastMonthEndDate.Month, query.HospitalId.Value, null);
            var lastYearContentOrderList = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAndHospitalIdListAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, query.HospitalId.Value);
            result.TodayNewCustomerNum = todayOrderList.Where(x => x.IsOldCustomer == false).Count();
            result.TodayOldCustomerNum = todayOrderList.Where(x => x.IsOldCustomer == true).Count();
            result.TodayTotalCustomerNum = todayOrderList.Count();

            result.TotalNewCustomerNum = currentContentOrderList.Where(x => x.IsOldCustomer == false).Count();
            result.LastMonthNewCustomerNum = lastMonthContentOrderList.Where(x => x.IsOldCustomer == false).Count();
            result.LastYearNewCustomerNum = lastYearContentOrderList.Where(x => x.IsOldCustomer == false).Count();

            result.TotalOldCustomerNum = currentContentOrderList.Where(x => x.IsOldCustomer == true).Count();
            result.LastMonthOldCustomerNum = lastMonthContentOrderList.Where(x => x.IsOldCustomer == true).Count();
            result.LastYearOldCustomerNum = lastYearContentOrderList.Where(x => x.IsOldCustomer == true).Count();

            result.TotalTotalCustomerNum = currentContentOrderList.Count();
            result.LastMonthTotalCustomerNum = lastMonthContentOrderList.Count();
            result.LastYearTotalCustomerNum = lastYearContentOrderList.Count();

            result.NewCustomerNumChainRate = DecimalExtension.CalculateChain(result.TotalNewCustomerNum, result.LastMonthNewCustomerNum).Value;
            result.OldCustomerNumChainRate = DecimalExtension.CalculateChain(result.TotalOldCustomerNum, result.LastMonthOldCustomerNum).Value;
            result.TotalCustomerNumChainRate = DecimalExtension.CalculateChain(result.TotalTotalCustomerNum, result.LastMonthTotalCustomerNum).Value;

            result.NewCustomerNumYearOnYearData = DecimalExtension.CalculateChain(result.TotalNewCustomerNum, result.LastYearNewCustomerNum).Value;
            result.OldCustomerNumYearOnYearData = DecimalExtension.CalculateChain(result.TotalOldCustomerNum, result.LastYearOldCustomerNum).Value;
            result.TotalCustomerNumYearOnYearData = DecimalExtension.CalculateChain(result.TotalTotalCustomerNum, result.LastYearTotalCustomerNum).Value;
            return result;
        }

        /// <summary>
        /// 获取机构业绩折线图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HospitalPerformanceBrokenLineDto> GetHospitalPerformanceBrokenLineDto(QueryHospitalPerformanceDto query)
        {
            HospitalPerformanceBrokenLineDto brokenLineDto = new HospitalPerformanceBrokenLineDto();
            var selectDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.EndDate.Year, query.EndDate.Month);

            var currentContentOrderList = await dalContentPlatFormOrderDealInfo.GetAll()
               .Where(e => e.IsDeal == true)
               .Where(e => e.CreateDate >= selectDate.StartDate && e.CreateDate < selectDate.EndDate)
               .Where(e => e.LastDealHospitalId == query.HospitalId)
               .Select(e => new
               {
                   DealPrice = e.Price,
                   IsOldCustomer = e.IsOldCustomer,
                   CreateDate = e.CreateDate
               }).ToListAsync();
            var newCustomerData = currentContentOrderList
                .Where(e => e.IsOldCustomer == false)
                .GroupBy(e => e.CreateDate.Date)
                .Select(e => new PerformanceBrokenLineListInfoDto
                {
                    date = e.Key.Day.ToString(),
                    Performance = ChangePriceToTenThousand(e.Sum(e => e.DealPrice))
                })
                .ToList();
            var oldCustomerData = currentContentOrderList
                .Where(e => e.IsOldCustomer == true)
                .GroupBy(e => e.CreateDate.Date)
                .Select(e => new PerformanceBrokenLineListInfoDto
                {
                    date = e.Key.Day.ToString(),
                    Performance = ChangePriceToTenThousand(e.Sum(e => e.DealPrice))
                })
                .ToList();
            var totalData = currentContentOrderList
               .GroupBy(e => e.CreateDate.Date)
               .Select(e => new PerformanceBrokenLineListInfoDto
               {
                   date = e.Key.Day.ToString(),
                   Performance = ChangePriceToTenThousand(e.Sum(e => e.DealPrice))
               })
               .ToList();
            brokenLineDto.NewCustomerPerformance = this.FillDate(query.EndDate.Year, query.EndDate.Month, newCustomerData);
            brokenLineDto.OldCustomerPerformance = this.FillDate(query.EndDate.Year, query.EndDate.Month, oldCustomerData);
            brokenLineDto.TotalPerformance = this.FillDate(query.EndDate.Year, query.EndDate.Month, totalData);
            return brokenLineDto;
        }


        /// <summary>
        /// 获取机构上门折线图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HospitalPerformanceBrokenLineDto> GetHospitalVisitBrokenLineDto(QueryHospitalPerformanceDto query)
        {
            HospitalPerformanceBrokenLineDto brokenLineDto = new HospitalPerformanceBrokenLineDto();
            var selectDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.EndDate.Year, query.EndDate.Month);

            var currentContentOrderList = await dalContentPlatFormOrderDealInfo.GetAll()
               .Where(e => e.IsDeal == true && e.Valid == true)
               .Where(e => e.CreateDate >= selectDate.StartDate && e.CreateDate < selectDate.EndDate)
               .Where(e => e.LastDealHospitalId == query.HospitalId)
               .Select(e => new
               {
                   Id = e.Id,
                   contenId = e.ContentPlatFormOrderId,
                   IsOldCustomer = e.IsOldCustomer,
                   CreateDate = e.CreateDate
               }).ToListAsync();

            var newCustomerData = currentContentOrderList
                .Where(e => e.IsOldCustomer == false)
                .GroupBy(e => e.CreateDate.Date)
                .Select(e => new PerformanceBrokenLineListInfoDto
                {
                    date = e.Key.Day.ToString(),
                    Performance = e.Count()
                })
                .ToList();
            var oldCustomerData = currentContentOrderList
                .Where(e => e.IsOldCustomer == true)
                .GroupBy(e => e.CreateDate.Date)
                .Select(e => new PerformanceBrokenLineListInfoDto
                {
                    date = e.Key.Day.ToString(),
                    Performance = e.Count()
                })
                .ToList();
            var totalData = currentContentOrderList
               .GroupBy(e => e.CreateDate.Date)
               .Select(e => new PerformanceBrokenLineListInfoDto
               {
                   date = e.Key.Day.ToString(),
                   Performance = e.Count()
               })
               .ToList();
            brokenLineDto.NewCustomerPerformance = this.FillDate(query.EndDate.Year, query.EndDate.Month, newCustomerData);
            brokenLineDto.OldCustomerPerformance = this.FillDate(query.EndDate.Year, query.EndDate.Month, oldCustomerData);
            brokenLineDto.TotalPerformance = this.FillDate(query.EndDate.Year, query.EndDate.Month, totalData);
            return brokenLineDto;
        }


        /// <summary>
        /// 获取机构漏斗图业绩
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HospitalNewOrOldCustomerDataDto> GetAssistantPerformanceFilterDataAsync(QueryHospitalPerformanceDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate, query.EndDate);
            var assistantIdList = new List<int>();

            List<string> baseLiveAnchorInfoIds = new List<string>();

            HospitalNewOrOldCustomerDataDto hospitalOperationDataDto = new HospitalNewOrOldCustomerDataDto();
            HospitalNewCustomerOperationDataDto newCustomerOperationDataDto = new HospitalNewCustomerOperationDataDto();
            newCustomerOperationDataDto.newCustomerOperationDataDetails = new List<HospitalNewCustomerOperationDataDetailsDto>();
            HospitalOldCustomerOperationDataDto oldCustomerOperationDataDto = new HospitalOldCustomerOperationDataDto();
            var healthValueList = await _healthValueService.GetValidListAsync();

            #region【订单数据】

            var baseOrderPerformance = await contentPlateFormOrderService.GetHospitalOrderSendAndDealDataAsync(selectDate.StartDate, selectDate.EndDate, query.HospitalId.Value, query.IsCurrent.Value);
            #endregion


            #region 【派单】
            HospitalNewCustomerOperationDataDetailsDto sendOrderdetails = new HospitalNewCustomerOperationDataDetailsDto();
            //派单
            sendOrderdetails.Key = "AddWeChat";
            sendOrderdetails.Name = "派单量";
            sendOrderdetails.Value = baseOrderPerformance.SendOrderNum;
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(sendOrderdetails);

            #endregion

            #region 【上门】
            HospitalNewCustomerOperationDataDetailsDto visitdetails = new HospitalNewCustomerOperationDataDetailsDto();
            //上门
            visitdetails.Key = "AddWeChat";
            visitdetails.Name = "上门量";
            visitdetails.Value = baseOrderPerformance.VisitNum;
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(visitdetails);

            //上门率
            newCustomerOperationDataDto.ToHospitalRate = DecimalExtension.CalculateTargetComplete(visitdetails.Value, sendOrderdetails.Value);
            newCustomerOperationDataDto.ToHospitalRateHealthValueThisMonth = healthValueList.Where(e => e.Key == "ToHospitalRateHealthValueThisMonth").Select(e => e.Rate).FirstOrDefault();
            #endregion

            #region 【成交】
            HospitalNewCustomerOperationDataDetailsDto dealdetails = new HospitalNewCustomerOperationDataDetailsDto();
            //成交
            dealdetails.Key = "AddWeChat";
            dealdetails.Name = "成交量";
            dealdetails.Value = baseOrderPerformance.DealNum;
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(dealdetails);

            //成交率
            newCustomerOperationDataDto.DealRate = DecimalExtension.CalculateTargetComplete(dealdetails.Value, visitdetails.Value);
            newCustomerOperationDataDto.DealRateHealthValueThisMonth = healthValueList.Where(e => e.Key == "DealRateHealthValueThisMonth").Select(e => e.Rate).FirstOrDefault();
            #endregion


            hospitalOperationDataDto.NewCustomerData = newCustomerOperationDataDto;
            //老客数据
            var oldCustomerData = await contentPlateFormOrderService.GetHospitalOldCustomerBuyAgainByMonthAsync(selectDate.EndDate, null, query.HospitalId.Value);
            oldCustomerOperationDataDto.TotalDealPeople = oldCustomerData.TotalDealCustomer;
            oldCustomerOperationDataDto.SecondDealPeople = oldCustomerData.SecondDealCustomer;
            oldCustomerOperationDataDto.ThirdDealPeople = oldCustomerData.ThirdDealCustomer;
            oldCustomerOperationDataDto.FourthDealCustomer = oldCustomerData.FourthDealCustomer;
            oldCustomerOperationDataDto.FifThOrMoreOrMoreDealCustomer = oldCustomerData.FifThOrMoreOrMoreDealCustomer;
            oldCustomerOperationDataDto.SecondDealCycle = oldCustomerData.SecondDealCycle;
            oldCustomerOperationDataDto.ThirdDealCycle = oldCustomerData.ThirdDealCycle;
            oldCustomerOperationDataDto.FourthDealCycle = oldCustomerData.FourthDealCycle;
            oldCustomerOperationDataDto.FifthDealCycle = oldCustomerData.FifthDealCycle;
            oldCustomerOperationDataDto.SecondTimeBuyRateProportion = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(oldCustomerOperationDataDto.SecondDealPeople), Convert.ToDecimal(oldCustomerOperationDataDto.TotalDealPeople)).Value;
            oldCustomerOperationDataDto.ThirdTimeBuyRateProportion = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(oldCustomerOperationDataDto.ThirdDealPeople), Convert.ToDecimal(oldCustomerOperationDataDto.TotalDealPeople)).Value;
            oldCustomerOperationDataDto.FourthTimeBuyRateProportion = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(oldCustomerOperationDataDto.FourthDealCustomer), Convert.ToDecimal(oldCustomerOperationDataDto.TotalDealPeople)).Value;
            oldCustomerOperationDataDto.FifthTimeOrMoreBuyRateProportion = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(oldCustomerOperationDataDto.FifThOrMoreOrMoreDealCustomer), Convert.ToDecimal(oldCustomerOperationDataDto.TotalDealPeople)).Value;
            oldCustomerOperationDataDto.BuyRate = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(oldCustomerOperationDataDto.FifThOrMoreOrMoreDealCustomer + oldCustomerOperationDataDto.FourthDealCustomer + oldCustomerOperationDataDto.ThirdDealPeople + oldCustomerOperationDataDto.SecondDealPeople), Convert.ToDecimal(oldCustomerOperationDataDto.TotalDealPeople)).Value;

            hospitalOperationDataDto.OldCustomerData = oldCustomerOperationDataDto;
            return hospitalOperationDataDto;
        }

        /// <summary>
        /// 获取机构转化周期柱状图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        public async Task<HospitalTransformCycleDataDto> GetHospitalTransformCycleDataAsync(QueryHospitalPerformanceDto query)
        {
            HospitalTransformCycleDataDto data = new HospitalTransformCycleDataDto();
            var seqDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.EndDate.Year, query.EndDate.Month);

            var hospitalList = await hospitalInfoService.GetValidHospitalNameListAsync();
            var hospitalIdList = hospitalList.Select(e => e.Id).ToList();

            #region 派单上门

            var dealInfoList = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= seqDate.StartDate && e.CreateDate < seqDate.EndDate && e.Valid == true && e.IsOldCustomer == false && e.IsToHospital == true && e.ToHospitalDate.HasValue)
                    //.Where(e => e.LastDealHospitalId == query.HospitalId.Value)
                    .Select(e => new
                    {
                        HospitalId = e.LastDealHospitalId,
                        Phone = e.ContentPlatFormOrder.Phone,
                        ToHospitalDate = e.ToHospitalDate
                    }).ToListAsync();
            var dealPhoneList = dealInfoList.Select(e => e.Phone).ToList();

            var sendData = await _dalContentPlatformOrderSend.GetAll().Include(x => x.ContentPlatformOrder).Where(e => e.IsMainHospital == true && dealPhoneList.Contains(e.ContentPlatformOrder.Phone)).Select(e => new
            {
                SendDate = e.SendDate,
                Phone = e.ContentPlatformOrder.Phone,
                HospitalId = e.HospitalId,
            }).ToListAsync();
            if (query.IsCurrent.Value == true)
            {
                sendData = sendData.Where(e => e.SendDate >= seqDate.StartDate && e.SendDate < seqDate.EndDate).ToList();
            }
            else
            {
                sendData = sendData.Where(e => e.SendDate < seqDate.StartDate).ToList();
            }
            var dataList2 = (from deal in dealInfoList
                             join cart in sendData
                             on deal.Phone equals cart.Phone
                             select new
                             {
                                 HospitalId = deal.HospitalId,
                                 IntervalDays = (deal.ToHospitalDate.Value - cart.SendDate).Days
                             }).ToList();
            dataList2.RemoveAll(e => e.IntervalDays < 0);
            //转化周期数据
            var res2 = dataList2.GroupBy(e => e.HospitalId).Select(e =>
            {
                var endIndex = DecimalExtension.CalTakeCount(e.Count(), 0.6m);
                var resData = e.OrderBy(e => e.IntervalDays).Skip(0).Take(endIndex);
                return new KeyValuePair<string, int>(
                hospitalList.Where(a => a.Id == e.Key).FirstOrDefault()?.Name ?? "其它",
                DecimalExtension.CalAvg(resData.Sum(e => e.IntervalDays), resData.Count()));
            }).OrderBy(e => e.Value).ToList();
            res2.RemoveAll(e => e.Key == "其它");
            List<Dictionary<string, int>> resultData2 = new List<Dictionary<string, int>>();
            foreach (var z in res2)
            {
                Dictionary<string, int> resultData = new Dictionary<string, int>();
                resultData.Add(z.Key, z.Value);
                resultData2.Add(resultData);
            }
            //foreach (var k in hospitalList)
            //{
            //    bool exists = resultData2.Any(dic => dic.ContainsKey(k.Name));
            //    if (exists == false)
            //    {
            //        Dictionary<string, int> resultData = new Dictionary<string, int>();
            //        resultData.Add(k.Name, 0);
            //        resultData2.Add(resultData);
            //    }
            //}
            List<KeyValuePair<string, int>> toHospitalCycleData = new List<KeyValuePair<string, int>>();
            foreach (var x in resultData2)
            {
                foreach (var kvp in x)
                {
                    toHospitalCycleData.Add(new KeyValuePair<string, int>(kvp.Key, kvp.Value));
                }
            }
            data.ToHospitalCycleData = toHospitalCycleData.OrderBy(x => x.Value).Take(5).ToList();


            #endregion

            #region 复购率

            var totalDealList = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.IsDeal == true && e.Price > 0 && e.ContentPlatFormOrder.DealAmount > 0)
                .Select(e => new
                {
                    Phone = e.ContentPlatFormOrder.Phone,
                    HospitalId = e.LastDealHospitalId,
                }).Where(e => hospitalIdList.Contains(e.HospitalId.Value)).ToListAsync();
            var hospitalTotalDealList = totalDealList.GroupBy(e => e.HospitalId).Select(e => new
            {
                HospitalId = e.Key,
                TotalDealCount = e.Select(e => e.Phone).Distinct().Count()
            }).ToList();
            var currentMonthDeal = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.IsToHospital == true && e.IsOldCustomer == true && e.Valid == true && e.CreateDate >= seqDate.StartDate && e.CreateDate < seqDate.EndDate)
                .Select(e => new
                {
                    Phone = e.ContentPlatFormOrder.Phone,
                    HospitalId = e.LastDealHospitalId,
                }).Where(e => hospitalIdList.Contains(e.HospitalId.Value)).ToListAsync();
            var hospitalCurrentMonthDeal = currentMonthDeal.GroupBy(e => e.HospitalId).Select(e => new
            {
                HospitalId = e.Key,
                TotalDealCount = e.Select(e => e.Phone).Distinct().Count()
            }).ToList();
            //当月复购率数据
            var res3 = (from total in hospitalTotalDealList
                        join current in hospitalCurrentMonthDeal
                        on total.HospitalId equals current.HospitalId
                        into tc
                        from r in tc.DefaultIfEmpty()
                        select new KeyValuePair<string, decimal>(
                            hospitalList.Where(a => a.Id == total.HospitalId).FirstOrDefault()?.Name ?? "其它",
                            r != null ? (total.TotalDealCount == 0 ? 0 : DecimalExtension.CalculateTargetComplete(r.TotalDealCount, total.TotalDealCount).Value) : 0)
                      ).OrderByDescending(e => e.Value).ToList();
            res3.RemoveAll(e => e.Key == "其它" || e.Value == 0);

            List<Dictionary<string, decimal>> resultData3 = new List<Dictionary<string, decimal>>();
            foreach (var z in res3)
            {
                Dictionary<string, decimal> resultData = new Dictionary<string, decimal>();
                resultData.Add(z.Key, z.Value);
                resultData3.Add(resultData);
            }
            //foreach (var k in hospitalList)
            //{
            //    bool exists = resultData3.Any(dic => dic.ContainsKey(k.Name));
            //    if (exists == false)
            //    {
            //        Dictionary<string, decimal> resultData = new Dictionary<string, decimal>();
            //        resultData.Add(k.Name, 0);
            //        resultData3.Add(resultData);
            //    }
            //}
            List<KeyValuePair<string, decimal>> repeateBuyCycleData = new List<KeyValuePair<string, decimal>>();
            foreach (var x in resultData3)
            {
                foreach (var kvp in x)
                {
                    repeateBuyCycleData.Add(new KeyValuePair<string, decimal>(kvp.Key, kvp.Value));
                }
            }
            data.OldCustomerRePurcheData = repeateBuyCycleData.OrderByDescending(x => x.Value).Take(5).ToList();

            #endregion

            return data;
        }

        /// <summary>
        /// 获取机构线索分析
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HospitalsCluesDataDto> GetHospitalsCluesDataAsync(QueryHospitalVisitDataDto query)
        {
            HospitalsCluesDataDto result = new HospitalsCluesDataDto();
            result.Items = new List<HospitalCluesDataItemDto>();
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate, query.EndDate);

            var hospitalList = await hospitalInfoService.GetValidHospitalNameListAsync();
            var hospitalIdList = hospitalList.Select(e => e.Id).ToList();

            #region 机构线索
            var dealInfoList = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= selectDate.StartDate && e.CreateDate < selectDate.EndDate && e.IsToHospital == true && e.Valid == true && e.ToHospitalDate.HasValue)
                    //.Where(e => e.LastDealHospitalId == query.HospitalId.Value)
                    .Select(e => new
                    {
                        IsOldCustomer = e.IsOldCustomer,
                        IsDeal = e.IsDeal,
                        HospitalId = e.LastDealHospitalId,
                        Phone = e.ContentPlatFormOrder.Phone,
                        ToHospitalDate = e.ToHospitalDate
                    }).ToListAsync();
            if (query.NewCustomer == true && query.OldCustomer == false)
            {
                dealInfoList = dealInfoList.Where(x => x.IsOldCustomer == false).ToList();
            }
            if (query.NewCustomer == false && query.OldCustomer == true)
            {
                dealInfoList = dealInfoList.Where(x => x.IsOldCustomer == true).ToList();
            }
            result.Items = hospitalIdList.Select(e =>
            {
                HospitalCluesDataItemDto item = new HospitalCluesDataItemDto();
                var sendNum = _dalContentPlatformOrderSend.GetAll().Where(x => x.SendDate >= query.StartDate && x.SendDate < query.EndDate && x.IsMainHospital == true && x.HospitalId == e).ToList();
                item.Name = hospitalList.Where(x => x.Id == e).Select(z => z.Name).FirstOrDefault();
                item.VisitCount = dealInfoList.Where(x => x.HospitalId == e).Count();
                item.VisitRate = DecimalExtension.CalculateTargetComplete(item.VisitCount, sendNum.Count()).Value;
                item.DealCount = dealInfoList.Where(x => x.IsDeal == true && x.HospitalId == e).Count();
                item.DealRate = DecimalExtension.CalculateTargetComplete(item.DealCount, item.VisitCount).Value;
                return item;
            }).ToList();
            #endregion
            result.TotalDealCount = result.Items.Sum(x => x.DealCount);
            result.TotalVisitCount = result.Items.Sum(x => x.VisitCount);
            result.DealRate = DecimalExtension.CalculateTargetComplete(result.TotalDealCount, result.TotalVisitCount).Value;
            return result;
        }


        /// <summary>
        /// 获机构业绩占比
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HospitalPerformanceRateDto> GetHospitalPerformanceRateDataAsync(QueryHospitalPerformanceDto query)
        {
            HospitalPerformanceRateDto result = new HospitalPerformanceRateDto();
            var selectDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.EndDate.Year, query.EndDate.Month);

            var hospitalIdAndNameList = await hospitalInfoService.GetValidHospitalNameListAsync();

            var dealInfoList = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= selectDate.StartDate && e.CreateDate < selectDate.EndDate && e.IsToHospital == true && e.Valid == true && e.ToHospitalDate.HasValue)
                     //.Where(e => e.LastDealHospitalId == query.HospitalId.Value)
                     .Select(e => new
                     {
                         IsDeal = e.IsDeal,
                         HospitalId = e.LastDealHospitalId,
                         Phone = e.ContentPlatFormOrder.Phone,
                         Price = e.Price
                     }).ToListAsync();
            var totalPerformance = dealInfoList.Sum(e => e.Price);
            foreach (var hospital in hospitalIdAndNameList)
            {
                var sumPerformance = dealInfoList.Where(e => e.HospitalId == hospital.Id).Sum(e => e.Price);
                BaseKeyValueDto<string, decimal> rateItem = new BaseKeyValueDto<string, decimal>();
                rateItem.Key = hospital.Name;
                rateItem.Value = DecimalExtension.CalculateTargetComplete(sumPerformance, totalPerformance).Value;
                result.PerformanceRateData.Add(rateItem);
            }
            return result;
        }



        /// <summary>
        /// 获取机构新/老客单价
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HospitalPerformanceRateDto> GetHospitalPerCustomerPriceDataAsync(QueryHospitalVisitDataDto query)
        {
            HospitalPerformanceRateDto result = new HospitalPerformanceRateDto();
            var selectDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.EndDate.Year, query.EndDate.Month);

            var hospitalIdAndNameList = await hospitalInfoService.GetValidHospitalNameListAsync();

            var dealInfoList = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= selectDate.StartDate && e.CreateDate < selectDate.EndDate && e.IsToHospital == true && e.Valid == true && e.IsDeal == true && e.ToHospitalDate.HasValue)
                     //.Where(e => e.LastDealHospitalId == query.HospitalId.Value)
                     .Select(e => new
                     {
                         IsOldCustomer = e.IsOldCustomer,
                         IsDeal = e.IsDeal,
                         HospitalId = e.LastDealHospitalId,
                         Phone = e.ContentPlatFormOrder.Phone,
                         Price = e.Price
                     }).ToListAsync();
            if (query.NewCustomer == true && query.OldCustomer == false)
            {
                dealInfoList = dealInfoList.Where(x => x.IsOldCustomer == false).ToList();
            }
            if (query.NewCustomer == false && query.OldCustomer == true)
            {
                dealInfoList = dealInfoList.Where(x => x.IsOldCustomer == true).ToList();
            }
            var totalPerformance = dealInfoList.Sum(e => e.Price);
            foreach (var hospital in hospitalIdAndNameList)
            {
                var sumPerformance = dealInfoList.Where(e => e.HospitalId == hospital.Id).Sum(e => e.Price);
                var sumCustomer = dealInfoList.Where(e => e.HospitalId == hospital.Id).Count();
                BaseKeyValueDto<string, decimal> rateItem = new BaseKeyValueDto<string, decimal>();
                rateItem.Key = hospital.Name;
                rateItem.Value = DecimalExtension.Division(sumPerformance, sumCustomer).Value;
                if (rateItem.Value != 0)
                {
                    result.PerformanceRateData.Add(rateItem);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取机构（年度）业绩趋势
        /// </summary>
        /// <returns></returns>
        public async Task<HospitalPerformanceYearDataListDto> GetTotalHospitalPersonalAchievementByYearAsync(QueryHospitalPerfomanceYearDataDto query)
        {
            var thisMonth = DateTime.Now.Month;
            #region 实例化输出项
            HospitalPerformanceYearDataListDto result = new HospitalPerformanceYearDataListDto();
            result.TotalPerformanceData = new List<PerformanceYearDataDto>();
            result.NewCustomerPerformanceData = new List<PerformanceYearDataDto>();
            result.OldCustomerPerformanceData = new List<PerformanceYearDataDto>();
            #endregion

            int totalCount = 1;
            for (int y = 0; y <= totalCount; y++)
            {
                PerformanceYearDataDto totalPerformanceYearData = new PerformanceYearDataDto();
                PerformanceYearDataDto newPerformanceYearData = new PerformanceYearDataDto();
                PerformanceYearDataDto oldPerformanceYearData = new PerformanceYearDataDto();
                switch (y)
                {
                    case 0:
                        totalPerformanceYearData.SortName = newPerformanceYearData.SortName = oldPerformanceYearData.SortName = query.Year + "年实际业绩";
                        #region 整体
                        var JanTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 1, query.HospitalId, null);
                        totalPerformanceYearData.JanuaryPerformance = JanTotalLossPerformance.Sum(x => x.Price).ToString();
                        var FebTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 2, query.HospitalId, null);
                        totalPerformanceYearData.FebruaryPerformance = FebTotalLossPerformance.Sum(x => x.Price).ToString();
                        var MarTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 3, query.HospitalId, null);
                        totalPerformanceYearData.MarchPerformance = MarTotalLossPerformance.Sum(x => x.Price).ToString();
                        var AprTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 4, query.HospitalId, null);
                        totalPerformanceYearData.AprilPerformance = AprTotalLossPerformance.Sum(x => x.Price).ToString();
                        var MayTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 5, query.HospitalId, null);
                        totalPerformanceYearData.MayPerformance = MayTotalLossPerformance.Sum(x => x.Price).ToString();
                        var JunTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 6, query.HospitalId, null);
                        totalPerformanceYearData.JunePerformance = JunTotalLossPerformance.Sum(x => x.Price).ToString();
                        var JulTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 7, query.HospitalId, null);
                        totalPerformanceYearData.JulyPerformance = JulTotalLossPerformance.Sum(x => x.Price).ToString();
                        var AugTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 8, query.HospitalId, null);
                        totalPerformanceYearData.AugustPerformance = AugTotalLossPerformance.Sum(x => x.Price).ToString();
                        var SepTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 9, query.HospitalId, null);
                        totalPerformanceYearData.SeptemberPerformance = SepTotalLossPerformance.Sum(x => x.Price).ToString();
                        var OctTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 10, query.HospitalId, null);
                        totalPerformanceYearData.OctoberPerformance = OctTotalLossPerformance.Sum(x => x.Price).ToString();
                        var NovTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 11, query.HospitalId, null);
                        totalPerformanceYearData.NovemberPerformance = NovTotalLossPerformance.Sum(x => x.Price).ToString();
                        var DecTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 12, query.HospitalId, null);
                        totalPerformanceYearData.DecemberPerformance = DecTotalLossPerformance.Sum(x => x.Price).ToString();
                        totalPerformanceYearData.SumPerformance = (Convert.ToDecimal(totalPerformanceYearData.JanuaryPerformance) + Convert.ToDecimal(totalPerformanceYearData.FebruaryPerformance) + Convert.ToDecimal(totalPerformanceYearData.MarchPerformance) + Convert.ToDecimal(totalPerformanceYearData.AprilPerformance) + Convert.ToDecimal(totalPerformanceYearData.MayPerformance) + Convert.ToDecimal(totalPerformanceYearData.JunePerformance) + Convert.ToDecimal(totalPerformanceYearData.JulyPerformance) + Convert.ToDecimal(totalPerformanceYearData.AugustPerformance) + Convert.ToDecimal(totalPerformanceYearData.SeptemberPerformance) + Convert.ToDecimal(totalPerformanceYearData.OctoberPerformance) + Convert.ToDecimal(totalPerformanceYearData.NovemberPerformance) + Convert.ToDecimal(totalPerformanceYearData.DecemberPerformance)).ToString();
                        totalPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(totalPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion
                        #region 新客
                        var JanDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 1, query.HospitalId, false);
                        newPerformanceYearData.JanuaryPerformance = JanDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var FebDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 2, query.HospitalId, false);
                        newPerformanceYearData.FebruaryPerformance = FebDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var MarDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 3, query.HospitalId, false);
                        newPerformanceYearData.MarchPerformance = MarDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var AprDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 4, query.HospitalId, false);
                        newPerformanceYearData.AprilPerformance = AprDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var MayDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 5, query.HospitalId, false);
                        newPerformanceYearData.MayPerformance = MayDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var JunDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 6, query.HospitalId, false);
                        newPerformanceYearData.JunePerformance = JunDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var JulDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 7, query.HospitalId, false);
                        newPerformanceYearData.JulyPerformance = JulDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var AugDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 8, query.HospitalId, false);
                        newPerformanceYearData.AugustPerformance = AugDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var SepDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 9, query.HospitalId, false);
                        newPerformanceYearData.SeptemberPerformance = SepDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var OctDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 10, query.HospitalId, false);
                        newPerformanceYearData.OctoberPerformance = OctDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var NovDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 11, query.HospitalId, false);
                        newPerformanceYearData.NovemberPerformance = NovDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        var DecDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 12, query.HospitalId, false);
                        newPerformanceYearData.DecemberPerformance = DecDaoDaoLossPerformance.Sum(x => x.Price).ToString();
                        newPerformanceYearData.SumPerformance = (Convert.ToDecimal(newPerformanceYearData.JanuaryPerformance) + Convert.ToDecimal(newPerformanceYearData.FebruaryPerformance) + Convert.ToDecimal(newPerformanceYearData.MarchPerformance) + Convert.ToDecimal(newPerformanceYearData.AprilPerformance) + Convert.ToDecimal(newPerformanceYearData.MayPerformance) + Convert.ToDecimal(newPerformanceYearData.JunePerformance) + Convert.ToDecimal(newPerformanceYearData.JulyPerformance) + Convert.ToDecimal(newPerformanceYearData.AugustPerformance) + Convert.ToDecimal(newPerformanceYearData.SeptemberPerformance) + Convert.ToDecimal(newPerformanceYearData.OctoberPerformance) + Convert.ToDecimal(newPerformanceYearData.NovemberPerformance) + Convert.ToDecimal(newPerformanceYearData.DecemberPerformance)).ToString();
                        newPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(newPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();


                        #endregion
                        #region 老客

                        var JanJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 1, query.HospitalId, true);
                        oldPerformanceYearData.JanuaryPerformance = JanJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var FebJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 2, query.HospitalId, true);
                        oldPerformanceYearData.FebruaryPerformance = FebJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var MarJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 3, query.HospitalId, true);
                        oldPerformanceYearData.MarchPerformance = MarJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var AprJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 4, query.HospitalId, true);
                        oldPerformanceYearData.AprilPerformance = AprJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var MayJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 5, query.HospitalId, true);
                        oldPerformanceYearData.MayPerformance = MayJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var JunJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 6, query.HospitalId, true);
                        oldPerformanceYearData.JunePerformance = JunJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var JulJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 7, query.HospitalId, true);
                        oldPerformanceYearData.JulyPerformance = JulJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var AugJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 8, query.HospitalId, true);
                        oldPerformanceYearData.AugustPerformance = AugJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var SepJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 9, query.HospitalId, true);
                        oldPerformanceYearData.SeptemberPerformance = SepJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var OctJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 10, query.HospitalId, true);
                        oldPerformanceYearData.OctoberPerformance = OctJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var NovJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 11, query.HospitalId, true);
                        oldPerformanceYearData.NovemberPerformance = NovJiNaLossPerformance.Sum(x => x.Price).ToString();
                        var DecJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 12, query.HospitalId, true);
                        oldPerformanceYearData.DecemberPerformance = DecJiNaLossPerformance.Sum(x => x.Price).ToString();
                        oldPerformanceYearData.SumPerformance = (Convert.ToDecimal(oldPerformanceYearData.JanuaryPerformance) + Convert.ToDecimal(oldPerformanceYearData.FebruaryPerformance) + Convert.ToDecimal(oldPerformanceYearData.MarchPerformance) + Convert.ToDecimal(oldPerformanceYearData.AprilPerformance) + Convert.ToDecimal(oldPerformanceYearData.MayPerformance) + Convert.ToDecimal(oldPerformanceYearData.JunePerformance) + Convert.ToDecimal(oldPerformanceYearData.JulyPerformance) + Convert.ToDecimal(oldPerformanceYearData.AugustPerformance) + Convert.ToDecimal(oldPerformanceYearData.SeptemberPerformance) + Convert.ToDecimal(oldPerformanceYearData.OctoberPerformance) + Convert.ToDecimal(oldPerformanceYearData.NovemberPerformance) + Convert.ToDecimal(oldPerformanceYearData.DecemberPerformance)).ToString();
                        oldPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(oldPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion
                        break;
                    case 1:
                        totalPerformanceYearData.SortName = query.Year + "年新/老客占比";

                        #region 整体
                        var totalNewCustomer = await contentPlatFormOrderDealInfoService.GetHospitalNewOrOldCustomerNumByDateAsync(Convert.ToDateTime(query.Year + "-01-01"), Convert.ToDateTime(query.Year + "-12-31"), false, query.HospitalId);
                        var totalOldCustomer = await contentPlatFormOrderDealInfoService.GetHospitalNewOrOldCustomerNumByDateAsync(Convert.ToDateTime(query.Year + "-01-01"), Convert.ToDateTime(query.Year + "-12-31"), true, query.HospitalId);
                        totalPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 1).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 1).Count());
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 2).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 2).Count());
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 3).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 3).Count());
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 4).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 4).Count());
                        totalPerformanceYearData.MayPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 5).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 5).Count());
                        totalPerformanceYearData.JunePerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 6).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 6).Count());
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 7).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 7).Count());
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 8).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 8).Count());
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 9).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 9).Count());
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 10).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 10).Count());
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 11).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 11).Count());
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 12).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 12).Count());
                        totalPerformanceYearData.SumPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Count(), totalOldCustomer.Count());
                        totalPerformanceYearData.AveragePerformance = "/";
                        #endregion

                        break;

                }

                result.TotalPerformanceData.Add(totalPerformanceYearData);
                result.NewCustomerPerformanceData.Add(newPerformanceYearData);
                result.OldCustomerPerformanceData.Add(oldPerformanceYearData);
            }

            return result;
        }

        #region 公共类

        /// <summary>
        /// 填充日期数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private List<PerformanceBrokenLineListInfoDto> FillDate(int year, int month, List<PerformanceBrokenLineListInfoDto> dataList)
        {
            List<PerformanceBrokenLineListInfoDto> list = new List<PerformanceBrokenLineListInfoDto>();

            var totalDays = DateTime.DaysInMonth(year, month);
            for (int i = 1; i < totalDays + 1; i++)
            {
                PerformanceBrokenLineListInfoDto item = new PerformanceBrokenLineListInfoDto();
                item.date = i.ToString();
                item.Performance = dataList.Where(e => e.date == item.date).Select(e => e.Performance).SingleOrDefault() ?? 0m;
                list.Add(item);
            }
            return list;
        }

        private decimal ChangePriceToTenThousand(decimal performance, int unit = 1)
        {
            if (performance == 0m)
                return 0;
            var result = Math.Round((performance / 10000), unit, MidpointRounding.AwayFromZero);
            return result;
        }
        #endregion
    }
}
