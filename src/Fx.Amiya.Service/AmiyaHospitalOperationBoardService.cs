
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

            var hospitalList = await hospitalInfoService.GetValidHospitalNameListAsync((int)Area.China);
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

            var hospitalList = await hospitalInfoService.GetValidHospitalNameListAsync((int)Area.China);
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

            var hospitalIdAndNameList = await hospitalInfoService.GetValidHospitalNameListAsync((int)Area.China);

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

            var hospitalIdAndNameList = await hospitalInfoService.GetValidHospitalNameListAsync((int)Area.China);

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

            int totalCount = 4;
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
                        totalPerformanceYearData.JanuaryPerformance = DecimalExtension.ChangePriceToTenThousand(JanTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var FebTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 2, query.HospitalId, null);
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.ChangePriceToTenThousand(FebTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var MarTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 3, query.HospitalId, null);
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.ChangePriceToTenThousand(MarTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var AprTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 4, query.HospitalId, null);
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.ChangePriceToTenThousand(AprTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var MayTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 5, query.HospitalId, null);
                        totalPerformanceYearData.MayPerformance = DecimalExtension.ChangePriceToTenThousand(MayTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var JunTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 6, query.HospitalId, null);
                        totalPerformanceYearData.JunePerformance = DecimalExtension.ChangePriceToTenThousand(JunTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var JulTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 7, query.HospitalId, null);
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.ChangePriceToTenThousand(JulTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var AugTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 8, query.HospitalId, null);
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.ChangePriceToTenThousand(AugTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var SepTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 9, query.HospitalId, null);
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.ChangePriceToTenThousand(SepTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var OctTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 10, query.HospitalId, null);
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.ChangePriceToTenThousand(OctTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var NovTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 11, query.HospitalId, null);
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.ChangePriceToTenThousand(NovTotalLossPerformance.Sum(x => x.Price)).ToString();
                        var DecTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 12, query.HospitalId, null);
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecTotalLossPerformance.Sum(x => x.Price)).ToString();
                        totalPerformanceYearData.SumPerformance = (Convert.ToDecimal(totalPerformanceYearData.JanuaryPerformance) + Convert.ToDecimal(totalPerformanceYearData.FebruaryPerformance) + Convert.ToDecimal(totalPerformanceYearData.MarchPerformance) + Convert.ToDecimal(totalPerformanceYearData.AprilPerformance) + Convert.ToDecimal(totalPerformanceYearData.MayPerformance) + Convert.ToDecimal(totalPerformanceYearData.JunePerformance) + Convert.ToDecimal(totalPerformanceYearData.JulyPerformance) + Convert.ToDecimal(totalPerformanceYearData.AugustPerformance) + Convert.ToDecimal(totalPerformanceYearData.SeptemberPerformance) + Convert.ToDecimal(totalPerformanceYearData.OctoberPerformance) + Convert.ToDecimal(totalPerformanceYearData.NovemberPerformance) + Convert.ToDecimal(totalPerformanceYearData.DecemberPerformance)).ToString();
                        totalPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(totalPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion
                        #region 新客
                        var JanDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 1, query.HospitalId, false);
                        newPerformanceYearData.JanuaryPerformance = DecimalExtension.ChangePriceToTenThousand(JanDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var FebDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 2, query.HospitalId, false);
                        newPerformanceYearData.FebruaryPerformance = DecimalExtension.ChangePriceToTenThousand(FebDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var MarDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 3, query.HospitalId, false);
                        newPerformanceYearData.MarchPerformance = DecimalExtension.ChangePriceToTenThousand(MarDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var AprDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 4, query.HospitalId, false);
                        newPerformanceYearData.AprilPerformance = DecimalExtension.ChangePriceToTenThousand(AprDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var MayDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 5, query.HospitalId, false);
                        newPerformanceYearData.MayPerformance = DecimalExtension.ChangePriceToTenThousand(MayDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var JunDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 6, query.HospitalId, false);
                        newPerformanceYearData.JunePerformance = DecimalExtension.ChangePriceToTenThousand(JunDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var JulDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 7, query.HospitalId, false);
                        newPerformanceYearData.JulyPerformance = DecimalExtension.ChangePriceToTenThousand(JulDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var AugDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 8, query.HospitalId, false);
                        newPerformanceYearData.AugustPerformance = DecimalExtension.ChangePriceToTenThousand(AugDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var SepDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 9, query.HospitalId, false);
                        newPerformanceYearData.SeptemberPerformance = DecimalExtension.ChangePriceToTenThousand(SepDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var OctDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 10, query.HospitalId, false);
                        newPerformanceYearData.OctoberPerformance = DecimalExtension.ChangePriceToTenThousand(OctDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var NovDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 11, query.HospitalId, false);
                        newPerformanceYearData.NovemberPerformance = DecimalExtension.ChangePriceToTenThousand(NovDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        var DecDaoDaoLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 12, query.HospitalId, false);
                        newPerformanceYearData.DecemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecDaoDaoLossPerformance.Sum(x => x.Price)).ToString();
                        newPerformanceYearData.SumPerformance = (Convert.ToDecimal(newPerformanceYearData.JanuaryPerformance) + Convert.ToDecimal(newPerformanceYearData.FebruaryPerformance) + Convert.ToDecimal(newPerformanceYearData.MarchPerformance) + Convert.ToDecimal(newPerformanceYearData.AprilPerformance) + Convert.ToDecimal(newPerformanceYearData.MayPerformance) + Convert.ToDecimal(newPerformanceYearData.JunePerformance) + Convert.ToDecimal(newPerformanceYearData.JulyPerformance) + Convert.ToDecimal(newPerformanceYearData.AugustPerformance) + Convert.ToDecimal(newPerformanceYearData.SeptemberPerformance) + Convert.ToDecimal(newPerformanceYearData.OctoberPerformance) + Convert.ToDecimal(newPerformanceYearData.NovemberPerformance) + Convert.ToDecimal(newPerformanceYearData.DecemberPerformance)).ToString();
                        newPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(newPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();


                        #endregion
                        #region 老客

                        var JanJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 1, query.HospitalId, true);
                        oldPerformanceYearData.JanuaryPerformance = DecimalExtension.ChangePriceToTenThousand(JanJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var FebJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 2, query.HospitalId, true);
                        oldPerformanceYearData.FebruaryPerformance = DecimalExtension.ChangePriceToTenThousand(FebJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var MarJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 3, query.HospitalId, true);
                        oldPerformanceYearData.MarchPerformance = DecimalExtension.ChangePriceToTenThousand(MarJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var AprJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 4, query.HospitalId, true);
                        oldPerformanceYearData.AprilPerformance = DecimalExtension.ChangePriceToTenThousand(AprJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var MayJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 5, query.HospitalId, true);
                        oldPerformanceYearData.MayPerformance = DecimalExtension.ChangePriceToTenThousand(MayJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var JunJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 6, query.HospitalId, true);
                        oldPerformanceYearData.JunePerformance = DecimalExtension.ChangePriceToTenThousand(JunJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var JulJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 7, query.HospitalId, true);
                        oldPerformanceYearData.JulyPerformance = DecimalExtension.ChangePriceToTenThousand(JulJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var AugJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 8, query.HospitalId, true);
                        oldPerformanceYearData.AugustPerformance = DecimalExtension.ChangePriceToTenThousand(AugJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var SepJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 9, query.HospitalId, true);
                        oldPerformanceYearData.SeptemberPerformance = DecimalExtension.ChangePriceToTenThousand(SepJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var OctJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 10, query.HospitalId, true);
                        oldPerformanceYearData.OctoberPerformance = DecimalExtension.ChangePriceToTenThousand(OctJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var NovJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 11, query.HospitalId, true);
                        oldPerformanceYearData.NovemberPerformance = DecimalExtension.ChangePriceToTenThousand(NovJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        var DecJiNaLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 12, query.HospitalId, true);
                        oldPerformanceYearData.DecemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecJiNaLossPerformance.Sum(x => x.Price)).ToString();
                        oldPerformanceYearData.SumPerformance = (Convert.ToDecimal(oldPerformanceYearData.JanuaryPerformance) + Convert.ToDecimal(oldPerformanceYearData.FebruaryPerformance) + Convert.ToDecimal(oldPerformanceYearData.MarchPerformance) + Convert.ToDecimal(oldPerformanceYearData.AprilPerformance) + Convert.ToDecimal(oldPerformanceYearData.MayPerformance) + Convert.ToDecimal(oldPerformanceYearData.JunePerformance) + Convert.ToDecimal(oldPerformanceYearData.JulyPerformance) + Convert.ToDecimal(oldPerformanceYearData.AugustPerformance) + Convert.ToDecimal(oldPerformanceYearData.SeptemberPerformance) + Convert.ToDecimal(oldPerformanceYearData.OctoberPerformance) + Convert.ToDecimal(oldPerformanceYearData.NovemberPerformance) + Convert.ToDecimal(oldPerformanceYearData.DecemberPerformance)).ToString();
                        oldPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(oldPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion
                        break;

                    case 1:
                        totalPerformanceYearData.SortName = newPerformanceYearData.SortName = oldPerformanceYearData.SortName = query.Year - 1 + "年实际业绩";
                        #region 整体
                        var JanTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 1, query.HospitalId, null);
                        totalPerformanceYearData.JanuaryPerformance =DecimalExtension.ChangePriceToTenThousand( JanTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var FebTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 2, query.HospitalId, null);
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.ChangePriceToTenThousand(FebTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var MarTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 3, query.HospitalId, null);
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.ChangePriceToTenThousand(MarTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var AprTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 4, query.HospitalId, null);
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.ChangePriceToTenThousand(AprTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var MayTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 5, query.HospitalId, null);
                        totalPerformanceYearData.MayPerformance = DecimalExtension.ChangePriceToTenThousand(MayTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var JunTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 6, query.HospitalId, null);
                        totalPerformanceYearData.JunePerformance = DecimalExtension.ChangePriceToTenThousand(JunTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var JulTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 7, query.HospitalId, null);
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.ChangePriceToTenThousand(JulTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var AugTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 8, query.HospitalId, null);
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.ChangePriceToTenThousand(AugTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var SepTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 9, query.HospitalId, null);
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.ChangePriceToTenThousand(SepTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var OctTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 10, query.HospitalId, null);
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.ChangePriceToTenThousand(OctTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var NovTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 11, query.HospitalId, null);
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.ChangePriceToTenThousand(NovTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var DecTotalLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 12, query.HospitalId, null);
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecTotalLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        totalPerformanceYearData.SumPerformance = DecimalExtension.ChangePriceToTenThousand(Convert.ToDecimal(totalPerformanceYearData.JanuaryPerformance) + Convert.ToDecimal(totalPerformanceYearData.FebruaryPerformance) + Convert.ToDecimal(totalPerformanceYearData.MarchPerformance) + Convert.ToDecimal(totalPerformanceYearData.AprilPerformance) + Convert.ToDecimal(totalPerformanceYearData.MayPerformance) + Convert.ToDecimal(totalPerformanceYearData.JunePerformance) + Convert.ToDecimal(totalPerformanceYearData.JulyPerformance) + Convert.ToDecimal(totalPerformanceYearData.AugustPerformance) + Convert.ToDecimal(totalPerformanceYearData.SeptemberPerformance) + Convert.ToDecimal(totalPerformanceYearData.OctoberPerformance) + Convert.ToDecimal(totalPerformanceYearData.NovemberPerformance) + Convert.ToDecimal(totalPerformanceYearData.DecemberPerformance)).ToString();
                        totalPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(totalPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion
                        #region 新客
                        var JanNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 1, query.HospitalId, false);
                        newPerformanceYearData.JanuaryPerformance = DecimalExtension.ChangePriceToTenThousand(JanNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var FebNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 2, query.HospitalId, false);
                        newPerformanceYearData.FebruaryPerformance = DecimalExtension.ChangePriceToTenThousand(FebNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var MarNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 3, query.HospitalId, false);
                        newPerformanceYearData.MarchPerformance = DecimalExtension.ChangePriceToTenThousand(MarNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var AprNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 4, query.HospitalId, false);
                        newPerformanceYearData.AprilPerformance = DecimalExtension.ChangePriceToTenThousand(AprNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var MayNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 5, query.HospitalId, false);
                        newPerformanceYearData.MayPerformance = DecimalExtension.ChangePriceToTenThousand(MayNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var JunNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 6, query.HospitalId, false);
                        newPerformanceYearData.JunePerformance = DecimalExtension.ChangePriceToTenThousand(JunNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var JulNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 7, query.HospitalId, false);
                        newPerformanceYearData.JulyPerformance = DecimalExtension.ChangePriceToTenThousand(JulNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var AugNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 8, query.HospitalId, false);
                        newPerformanceYearData.AugustPerformance = DecimalExtension.ChangePriceToTenThousand(AugNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var SepNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 9, query.HospitalId, false);
                        newPerformanceYearData.SeptemberPerformance = DecimalExtension.ChangePriceToTenThousand(SepNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var OctNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 10, query.HospitalId, false);
                        newPerformanceYearData.OctoberPerformance = DecimalExtension.ChangePriceToTenThousand(OctNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var NovNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 11, query.HospitalId, false);
                        newPerformanceYearData.NovemberPerformance = DecimalExtension.ChangePriceToTenThousand(NovNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var DecNewLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 12, query.HospitalId, false);
                        newPerformanceYearData.DecemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecNewLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        newPerformanceYearData.SumPerformance = DecimalExtension.ChangePriceToTenThousand(Convert.ToDecimal(newPerformanceYearData.JanuaryPerformance) + Convert.ToDecimal(newPerformanceYearData.FebruaryPerformance) + Convert.ToDecimal(newPerformanceYearData.MarchPerformance) + Convert.ToDecimal(newPerformanceYearData.AprilPerformance) + Convert.ToDecimal(newPerformanceYearData.MayPerformance) + Convert.ToDecimal(newPerformanceYearData.JunePerformance) + Convert.ToDecimal(newPerformanceYearData.JulyPerformance) + Convert.ToDecimal(newPerformanceYearData.AugustPerformance) + Convert.ToDecimal(newPerformanceYearData.SeptemberPerformance) + Convert.ToDecimal(newPerformanceYearData.OctoberPerformance) + Convert.ToDecimal(newPerformanceYearData.NovemberPerformance) + Convert.ToDecimal(newPerformanceYearData.DecemberPerformance)).ToString();
                        newPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(newPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion
                        #region 老客
                        var JanOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 1, query.HospitalId, true);
                        oldPerformanceYearData.JanuaryPerformance = DecimalExtension.ChangePriceToTenThousand(JanOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var FebOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 2, query.HospitalId, true);
                        oldPerformanceYearData.FebruaryPerformance = DecimalExtension.ChangePriceToTenThousand(FebOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var MarOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 3, query.HospitalId, true);
                        oldPerformanceYearData.MarchPerformance = DecimalExtension.ChangePriceToTenThousand(MarOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var AprOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 4, query.HospitalId, true);
                        oldPerformanceYearData.AprilPerformance = DecimalExtension.ChangePriceToTenThousand(AprOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var MayOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 5, query.HospitalId, true);
                        oldPerformanceYearData.MayPerformance = DecimalExtension.ChangePriceToTenThousand(MayOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var JunOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 6, query.HospitalId, true);
                        oldPerformanceYearData.JunePerformance = DecimalExtension.ChangePriceToTenThousand(JunOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var JulOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 7, query.HospitalId, true);
                        oldPerformanceYearData.JulyPerformance = DecimalExtension.ChangePriceToTenThousand(JulOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var AugOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 8, query.HospitalId, true);
                        oldPerformanceYearData.AugustPerformance = DecimalExtension.ChangePriceToTenThousand(AugOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var SepOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 9, query.HospitalId, true);
                        oldPerformanceYearData.SeptemberPerformance = DecimalExtension.ChangePriceToTenThousand(SepOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var OctOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 10, query.HospitalId, true);
                        oldPerformanceYearData.OctoberPerformance = DecimalExtension.ChangePriceToTenThousand(OctOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var NovOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 11, query.HospitalId, true);
                        oldPerformanceYearData.NovemberPerformance = DecimalExtension.ChangePriceToTenThousand(NovOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        var DecOldLastYearLossPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year - 1, 12, query.HospitalId, true);
                        oldPerformanceYearData.DecemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecOldLastYearLossPerformance.Sum(x => x.Price)).ToString();
                        oldPerformanceYearData.SumPerformance = DecimalExtension.ChangePriceToTenThousand(Convert.ToDecimal(oldPerformanceYearData.JanuaryPerformance) + Convert.ToDecimal(oldPerformanceYearData.FebruaryPerformance) + Convert.ToDecimal(oldPerformanceYearData.MarchPerformance) + Convert.ToDecimal(oldPerformanceYearData.AprilPerformance) + Convert.ToDecimal(oldPerformanceYearData.MayPerformance) + Convert.ToDecimal(oldPerformanceYearData.JunePerformance) + Convert.ToDecimal(oldPerformanceYearData.JulyPerformance) + Convert.ToDecimal(oldPerformanceYearData.AugustPerformance) + Convert.ToDecimal(oldPerformanceYearData.SeptemberPerformance) + Convert.ToDecimal(oldPerformanceYearData.OctoberPerformance) + Convert.ToDecimal(oldPerformanceYearData.NovemberPerformance) + Convert.ToDecimal(oldPerformanceYearData.DecemberPerformance)).ToString();
                        oldPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(oldPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion
                        break;

                    case 2:
                        totalPerformanceYearData.SortName = newPerformanceYearData.SortName = oldPerformanceYearData.SortName = "环比";
                        #region 整体
                        var completeTotalLastMonth = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == (query.Year - 1) + "年实际业绩");
                        var completeTotalThisMonth = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年实际业绩");
                        totalPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.JanuaryPerformance), Convert.ToDecimal(completeTotalLastMonth.DecemberPerformance)).ToString();
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.FebruaryPerformance), Convert.ToDecimal(completeTotalThisMonth.JanuaryPerformance)).ToString();
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.MarchPerformance), Convert.ToDecimal(completeTotalThisMonth.FebruaryPerformance)).ToString();
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.AprilPerformance), Convert.ToDecimal(completeTotalThisMonth.MarchPerformance)).ToString();
                        totalPerformanceYearData.MayPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.MayPerformance), Convert.ToDecimal(completeTotalThisMonth.AprilPerformance)).ToString();
                        totalPerformanceYearData.JunePerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.JunePerformance), Convert.ToDecimal(completeTotalThisMonth.MayPerformance)).ToString();
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.JulyPerformance), Convert.ToDecimal(completeTotalThisMonth.JunePerformance)).ToString();
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.AugustPerformance), Convert.ToDecimal(completeTotalThisMonth.JulyPerformance)).ToString();
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.SeptemberPerformance), Convert.ToDecimal(completeTotalThisMonth.AugustPerformance)).ToString();
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.OctoberPerformance), Convert.ToDecimal(completeTotalThisMonth.SeptemberPerformance)).ToString();
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.NovemberPerformance), Convert.ToDecimal(completeTotalThisMonth.OctoberPerformance)).ToString();
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.DecemberPerformance), Convert.ToDecimal(completeTotalThisMonth.NovemberPerformance)).ToString();
                        totalPerformanceYearData.SumPerformance = "/";
                        totalPerformanceYearData.AveragePerformance = "/";
                        #endregion
                        #region 新客
                        var completeNewLastMonth = result.NewCustomerPerformanceData.SingleOrDefault(x => x.SortName == (query.Year - 1) + "年实际业绩");
                        var completeNewThisMonth = result.NewCustomerPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年实际业绩");
                        newPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.JanuaryPerformance), Convert.ToDecimal(completeNewLastMonth.DecemberPerformance)).ToString();
                        newPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.FebruaryPerformance), Convert.ToDecimal(completeNewThisMonth.JanuaryPerformance)).ToString();
                        newPerformanceYearData.MarchPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.MarchPerformance), Convert.ToDecimal(completeNewThisMonth.FebruaryPerformance)).ToString();
                        newPerformanceYearData.AprilPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.AprilPerformance), Convert.ToDecimal(completeNewThisMonth.MarchPerformance)).ToString();
                        newPerformanceYearData.MayPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.MayPerformance), Convert.ToDecimal(completeNewThisMonth.AprilPerformance)).ToString();
                        newPerformanceYearData.JunePerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.JunePerformance), Convert.ToDecimal(completeNewThisMonth.MayPerformance)).ToString();
                        newPerformanceYearData.JulyPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.JulyPerformance), Convert.ToDecimal(completeNewThisMonth.JunePerformance)).ToString();
                        newPerformanceYearData.AugustPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.AugustPerformance), Convert.ToDecimal(completeNewThisMonth.JulyPerformance)).ToString();
                        newPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.SeptemberPerformance), Convert.ToDecimal(completeNewThisMonth.AugustPerformance)).ToString();
                        newPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.OctoberPerformance), Convert.ToDecimal(completeNewThisMonth.SeptemberPerformance)).ToString();
                        newPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.NovemberPerformance), Convert.ToDecimal(completeNewThisMonth.OctoberPerformance)).ToString();
                        newPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisMonth.DecemberPerformance), Convert.ToDecimal(completeNewThisMonth.NovemberPerformance)).ToString();
                        newPerformanceYearData.SumPerformance = "/";
                        newPerformanceYearData.AveragePerformance = "/";
                        #endregion
                        #region 老客
                        var completeOldLastMonth = result.OldCustomerPerformanceData.SingleOrDefault(x => x.SortName == (query.Year - 1) + "年实际业绩");
                        var completeOldThisMonth = result.OldCustomerPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年实际业绩");
                        oldPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.JanuaryPerformance), Convert.ToDecimal(completeOldLastMonth.DecemberPerformance)).ToString();
                        oldPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.FebruaryPerformance), Convert.ToDecimal(completeOldThisMonth.JanuaryPerformance)).ToString();
                        oldPerformanceYearData.MarchPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.MarchPerformance), Convert.ToDecimal(completeOldThisMonth.FebruaryPerformance)).ToString();
                        oldPerformanceYearData.AprilPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.AprilPerformance), Convert.ToDecimal(completeOldThisMonth.MarchPerformance)).ToString();
                        oldPerformanceYearData.MayPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.MayPerformance), Convert.ToDecimal(completeOldThisMonth.AprilPerformance)).ToString();
                        oldPerformanceYearData.JunePerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.JunePerformance), Convert.ToDecimal(completeOldThisMonth.MayPerformance)).ToString();
                        oldPerformanceYearData.JulyPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.JulyPerformance), Convert.ToDecimal(completeOldThisMonth.JunePerformance)).ToString();
                        oldPerformanceYearData.AugustPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.AugustPerformance), Convert.ToDecimal(completeOldThisMonth.JulyPerformance)).ToString();
                        oldPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.SeptemberPerformance), Convert.ToDecimal(completeOldThisMonth.AugustPerformance)).ToString();
                        oldPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.OctoberPerformance), Convert.ToDecimal(completeOldThisMonth.SeptemberPerformance)).ToString();
                        oldPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.NovemberPerformance), Convert.ToDecimal(completeOldThisMonth.OctoberPerformance)).ToString();
                        oldPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisMonth.DecemberPerformance), Convert.ToDecimal(completeOldThisMonth.NovemberPerformance)).ToString();
                        oldPerformanceYearData.SumPerformance = "/";
                        oldPerformanceYearData.AveragePerformance = "/";
                        #endregion
                        break;

                    case 3:
                        totalPerformanceYearData.SortName = newPerformanceYearData.SortName = oldPerformanceYearData.SortName = "同比";
                        #region 整体
                        var completeTotalHistoryYear = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == (query.Year - 1) + "年实际业绩");
                        var completeTotalThisYear = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年实际业绩");
                        totalPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.JanuaryPerformance), Convert.ToDecimal(completeTotalHistoryYear.JanuaryPerformance)).ToString();
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.FebruaryPerformance), Convert.ToDecimal(completeTotalHistoryYear.FebruaryPerformance)).ToString();
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.MarchPerformance), Convert.ToDecimal(completeTotalHistoryYear.MarchPerformance)).ToString();
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.AprilPerformance), Convert.ToDecimal(completeTotalHistoryYear.AprilPerformance)).ToString();
                        totalPerformanceYearData.MayPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.MayPerformance), Convert.ToDecimal(completeTotalHistoryYear.MayPerformance)).ToString();
                        totalPerformanceYearData.JunePerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.JunePerformance), Convert.ToDecimal(completeTotalHistoryYear.JunePerformance)).ToString();
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.JulyPerformance), Convert.ToDecimal(completeTotalHistoryYear.JulyPerformance)).ToString();
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.AugustPerformance), Convert.ToDecimal(completeTotalHistoryYear.AugustPerformance)).ToString();
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.SeptemberPerformance), Convert.ToDecimal(completeTotalHistoryYear.SeptemberPerformance)).ToString();
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.OctoberPerformance), Convert.ToDecimal(completeTotalHistoryYear.OctoberPerformance)).ToString();
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.NovemberPerformance), Convert.ToDecimal(completeTotalHistoryYear.NovemberPerformance)).ToString();
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.DecemberPerformance), Convert.ToDecimal(completeTotalHistoryYear.DecemberPerformance)).ToString();
                        totalPerformanceYearData.SumPerformance = "/";
                        totalPerformanceYearData.AveragePerformance = "/";
                        #endregion
                        #region 新客
                        var completeNewHistoryYear = result.NewCustomerPerformanceData.SingleOrDefault(x => x.SortName == (query.Year - 1) + "年实际业绩");
                        var completeNewThisYear = result.NewCustomerPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年实际业绩");
                        newPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.JanuaryPerformance), Convert.ToDecimal(completeNewHistoryYear.JanuaryPerformance)).ToString();
                        newPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.FebruaryPerformance), Convert.ToDecimal(completeNewHistoryYear.FebruaryPerformance)).ToString();
                        newPerformanceYearData.MarchPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.MarchPerformance), Convert.ToDecimal(completeNewHistoryYear.MarchPerformance)).ToString();
                        newPerformanceYearData.AprilPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.AprilPerformance), Convert.ToDecimal(completeNewHistoryYear.AprilPerformance)).ToString();
                        newPerformanceYearData.MayPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.MayPerformance), Convert.ToDecimal(completeNewHistoryYear.MayPerformance)).ToString();
                        newPerformanceYearData.JunePerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.JunePerformance), Convert.ToDecimal(completeNewHistoryYear.JunePerformance)).ToString();
                        newPerformanceYearData.JulyPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.JulyPerformance), Convert.ToDecimal(completeNewHistoryYear.JulyPerformance)).ToString();
                        newPerformanceYearData.AugustPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.AugustPerformance), Convert.ToDecimal(completeNewHistoryYear.AugustPerformance)).ToString();
                        newPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.SeptemberPerformance), Convert.ToDecimal(completeNewHistoryYear.SeptemberPerformance)).ToString();
                        newPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.OctoberPerformance), Convert.ToDecimal(completeNewHistoryYear.OctoberPerformance)).ToString();
                        newPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.NovemberPerformance), Convert.ToDecimal(completeNewHistoryYear.NovemberPerformance)).ToString();
                        newPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeNewThisYear.DecemberPerformance), Convert.ToDecimal(completeNewHistoryYear.DecemberPerformance)).ToString();
                        newPerformanceYearData.SumPerformance = "/";
                        newPerformanceYearData.AveragePerformance = "/";
                        #endregion

                        #region 老客
                        var completeOldHistoryYear = result.OldCustomerPerformanceData.SingleOrDefault(x => x.SortName == (query.Year - 1) + "年实际业绩");
                        var completeOldThisYear = result.OldCustomerPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年实际业绩");
                        oldPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.JanuaryPerformance), Convert.ToDecimal(completeOldHistoryYear.JanuaryPerformance)).ToString();
                        oldPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.FebruaryPerformance), Convert.ToDecimal(completeOldHistoryYear.FebruaryPerformance)).ToString();
                        oldPerformanceYearData.MarchPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.MarchPerformance), Convert.ToDecimal(completeOldHistoryYear.MarchPerformance)).ToString();
                        oldPerformanceYearData.AprilPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.AprilPerformance), Convert.ToDecimal(completeOldHistoryYear.AprilPerformance)).ToString();
                        oldPerformanceYearData.MayPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.MayPerformance), Convert.ToDecimal(completeOldHistoryYear.MayPerformance)).ToString();
                        oldPerformanceYearData.JunePerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.JunePerformance), Convert.ToDecimal(completeOldHistoryYear.JunePerformance)).ToString();
                        oldPerformanceYearData.JulyPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.JulyPerformance), Convert.ToDecimal(completeOldHistoryYear.JulyPerformance)).ToString();
                        oldPerformanceYearData.AugustPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.AugustPerformance), Convert.ToDecimal(completeOldHistoryYear.AugustPerformance)).ToString();
                        oldPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.SeptemberPerformance), Convert.ToDecimal(completeOldHistoryYear.SeptemberPerformance)).ToString();
                        oldPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.OctoberPerformance), Convert.ToDecimal(completeOldHistoryYear.OctoberPerformance)).ToString();
                        oldPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.NovemberPerformance), Convert.ToDecimal(completeOldHistoryYear.NovemberPerformance)).ToString();
                        oldPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeOldThisYear.DecemberPerformance), Convert.ToDecimal(completeOldHistoryYear.DecemberPerformance)).ToString();
                        oldPerformanceYearData.SumPerformance = "/";
                        oldPerformanceYearData.AveragePerformance = "/";
                        #endregion
                        break;

                    case 4:
                        totalPerformanceYearData.SortName = newPerformanceYearData.SortName = oldPerformanceYearData.SortName = query.Year + "年客单价";
                        #region 整体
                        var JanTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 1, query.HospitalId, null);
                        totalPerformanceYearData.JanuaryPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(JanTotalAvgPerformance.Sum(x => x.Price), JanTotalAvgPerformance.Count).Value).ToString();
                        var FebTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 2, query.HospitalId, null);
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(FebTotalAvgPerformance.Sum(x => x.Price), FebTotalAvgPerformance.Count).Value).ToString();
                        var MarTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 3, query.HospitalId, null);
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(MarTotalAvgPerformance.Sum(x => x.Price), MarTotalAvgPerformance.Count).Value).ToString();
                        var AprTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 4, query.HospitalId, null);
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(AprTotalAvgPerformance.Sum(x => x.Price), AprTotalAvgPerformance.Count).Value).ToString();
                        var MayTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 5, query.HospitalId, null);
                        totalPerformanceYearData.MayPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(MayTotalAvgPerformance.Sum(x => x.Price), MayTotalAvgPerformance.Count).Value).ToString();
                        var JunTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 6, query.HospitalId, null);
                        totalPerformanceYearData.JunePerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(JunTotalAvgPerformance.Sum(x => x.Price), JunTotalAvgPerformance.Count).Value).ToString();
                        var JulTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 7, query.HospitalId, null);
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(JulTotalAvgPerformance.Sum(x => x.Price), JulTotalAvgPerformance.Count).Value).ToString();
                        var AugTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 8, query.HospitalId, null);
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(AugTotalAvgPerformance.Sum(x => x.Price), AugTotalAvgPerformance.Count).Value).ToString();
                        var SepTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 9, query.HospitalId, null);
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(SepTotalAvgPerformance.Sum(x => x.Price), SepTotalAvgPerformance.Count).Value).ToString();
                        var OctTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 10, query.HospitalId, null);
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(OctTotalAvgPerformance.Sum(x => x.Price), OctTotalAvgPerformance.Count).Value).ToString();
                        var NovTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 11, query.HospitalId, null);
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(NovTotalAvgPerformance.Sum(x => x.Price), NovTotalAvgPerformance.Count).Value).ToString();
                        var DecTotalAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 12, query.HospitalId, null);
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(DecTotalAvgPerformance.Sum(x => x.Price), DecTotalAvgPerformance.Count).Value).ToString();
                        totalPerformanceYearData.SumPerformance = "/";
                        totalPerformanceYearData.AveragePerformance = "/";
                        #endregion
                        #region 新客
                        var JanNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 1, query.HospitalId, false);
                        newPerformanceYearData.JanuaryPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(JanNewCustomerAvgPerformance.Sum(x => x.Price), JanNewCustomerAvgPerformance.Count).Value).ToString();
                        var FebNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 2, query.HospitalId, false);
                        newPerformanceYearData.FebruaryPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(FebNewCustomerAvgPerformance.Sum(x => x.Price), FebNewCustomerAvgPerformance.Count).Value).ToString();
                        var MarNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 3, query.HospitalId, false);
                        newPerformanceYearData.MarchPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(MarNewCustomerAvgPerformance.Sum(x => x.Price), MarNewCustomerAvgPerformance.Count).Value).ToString();
                        var AprNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 4, query.HospitalId, false);
                        newPerformanceYearData.AprilPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(AprNewCustomerAvgPerformance.Sum(x => x.Price), AprNewCustomerAvgPerformance.Count).Value).ToString();
                        var MayNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 5, query.HospitalId, false);
                        newPerformanceYearData.MayPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(MayNewCustomerAvgPerformance.Sum(x => x.Price), MayNewCustomerAvgPerformance.Count).Value).ToString();
                        var JunNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 6, query.HospitalId, false);
                        newPerformanceYearData.JunePerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(JunNewCustomerAvgPerformance.Sum(x => x.Price), JunNewCustomerAvgPerformance.Count).Value).ToString();
                        var JulNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 7, query.HospitalId, false);
                        newPerformanceYearData.JulyPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(JulNewCustomerAvgPerformance.Sum(x => x.Price), JulNewCustomerAvgPerformance.Count).Value).ToString();
                        var AugNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 8, query.HospitalId, false);
                        newPerformanceYearData.AugustPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(AugNewCustomerAvgPerformance.Sum(x => x.Price), AugNewCustomerAvgPerformance.Count).Value).ToString();
                        var SepNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 9, query.HospitalId, false);
                        newPerformanceYearData.SeptemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(SepNewCustomerAvgPerformance.Sum(x => x.Price), SepNewCustomerAvgPerformance.Count).Value).ToString();
                        var OctNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 10, query.HospitalId, false);
                        newPerformanceYearData.OctoberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(OctNewCustomerAvgPerformance.Sum(x => x.Price), OctNewCustomerAvgPerformance.Count).Value).ToString();
                        var NovNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 11, query.HospitalId, false);
                        newPerformanceYearData.NovemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(NovNewCustomerAvgPerformance.Sum(x => x.Price), NovNewCustomerAvgPerformance.Count).Value).ToString();
                        var DecNewCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 12, query.HospitalId, false);
                        newPerformanceYearData.DecemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(DecNewCustomerAvgPerformance.Sum(x => x.Price), DecNewCustomerAvgPerformance.Count).Value).ToString();
                        newPerformanceYearData.SumPerformance = "/";
                        newPerformanceYearData.AveragePerformance = "/";


                        #endregion
                        #region 老客

                        var JanOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 1, query.HospitalId, true);
                        oldPerformanceYearData.JanuaryPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(JanOldCustomerAvgPerformance.Sum(x => x.Price), JanOldCustomerAvgPerformance.Count).Value).ToString();
                        var FebOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 2, query.HospitalId, true);
                        oldPerformanceYearData.FebruaryPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(FebOldCustomerAvgPerformance.Sum(x => x.Price), FebOldCustomerAvgPerformance.Count).Value).ToString();
                        var MarOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 3, query.HospitalId, true);
                        oldPerformanceYearData.MarchPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(MarOldCustomerAvgPerformance.Sum(x => x.Price), MarOldCustomerAvgPerformance.Count).Value).ToString();
                        var AprOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 4, query.HospitalId, true);
                        oldPerformanceYearData.AprilPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(AprOldCustomerAvgPerformance.Sum(x => x.Price), AprOldCustomerAvgPerformance.Count).Value).ToString();
                        var MayOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 5, query.HospitalId, true);
                        oldPerformanceYearData.MayPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(MayOldCustomerAvgPerformance.Sum(x => x.Price), MayOldCustomerAvgPerformance.Count).Value).ToString();
                        var JunOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 6, query.HospitalId, true);
                        oldPerformanceYearData.JunePerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(JunOldCustomerAvgPerformance.Sum(x => x.Price), JunOldCustomerAvgPerformance.Count).Value).ToString();
                        var JulOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 7, query.HospitalId, true);
                        oldPerformanceYearData.JulyPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(JulOldCustomerAvgPerformance.Sum(x => x.Price), JulOldCustomerAvgPerformance.Count).Value).ToString();
                        var AugOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 8, query.HospitalId, true);
                        oldPerformanceYearData.AugustPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(AugOldCustomerAvgPerformance.Sum(x => x.Price), AugOldCustomerAvgPerformance.Count).Value).ToString();
                        var SepOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 9, query.HospitalId, true);
                        oldPerformanceYearData.SeptemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(SepOldCustomerAvgPerformance.Sum(x => x.Price), SepOldCustomerAvgPerformance.Count).Value).ToString();
                        var OctOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 10, query.HospitalId, true);
                        oldPerformanceYearData.OctoberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(OctOldCustomerAvgPerformance.Sum(x => x.Price), OctOldCustomerAvgPerformance.Count).Value).ToString();
                        var NovOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 11, query.HospitalId, true);
                        oldPerformanceYearData.NovemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(NovOldCustomerAvgPerformance.Sum(x => x.Price), NovOldCustomerAvgPerformance.Count).Value).ToString();
                        var DecOldCustomerAvgPerformance = await contentPlatFormOrderDealInfoService.GetSimpleHospitalPerformanceDetailByDateAsync(query.Year, 12, query.HospitalId, true);
                        oldPerformanceYearData.DecemberPerformance = DecimalExtension.ChangePriceToTenThousand(DecimalExtension.Division(DecOldCustomerAvgPerformance.Sum(x => x.Price), DecOldCustomerAvgPerformance.Count).Value).ToString();
                        oldPerformanceYearData.SumPerformance = "/";
                        oldPerformanceYearData.AveragePerformance = "/";
                        #endregion
                        break;



                        #region[新老客占比-弃用]
                        //case 2:
                        //    totalPerformanceYearData.SortName = query.Year + "年新/老客占比";

                        //    #region 整体
                        //    var totalNewCustomer = await contentPlatFormOrderDealInfoService.GetHospitalNewOrOldCustomerNumByDateAsync(Convert.ToDateTime(query.Year + "-01-01"), Convert.ToDateTime(query.Year + "-12-31"), false, query.HospitalId);
                        //    var totalOldCustomer = await contentPlatFormOrderDealInfoService.GetHospitalNewOrOldCustomerNumByDateAsync(Convert.ToDateTime(query.Year + "-01-01"), Convert.ToDateTime(query.Year + "-12-31"), true, query.HospitalId);
                        //    totalPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 1).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 1).Count());
                        //    totalPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 2).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 2).Count());
                        //    totalPerformanceYearData.MarchPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 3).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 3).Count());
                        //    totalPerformanceYearData.AprilPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 4).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 4).Count());
                        //    totalPerformanceYearData.MayPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 5).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 5).Count());
                        //    totalPerformanceYearData.JunePerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 6).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 6).Count());
                        //    totalPerformanceYearData.JulyPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 7).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 7).Count());
                        //    totalPerformanceYearData.AugustPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 8).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 8).Count());
                        //    totalPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 9).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 9).Count());
                        //    totalPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 10).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 10).Count());
                        //    totalPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 11).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 11).Count());
                        //    totalPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 12).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 12).Count());
                        //    totalPerformanceYearData.SumPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Count(), totalOldCustomer.Count());
                        //    totalPerformanceYearData.AveragePerformance = "/";
                        //    #endregion

                        //    break;
                        #endregion
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
