
using Fx.Amiya.Dto.AmiyaHospitalOperation.Input;
using Fx.Amiya.Dto.AmiyaHospitalOperation.Result;
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
            result.TotalOldCustomerNum = currentContentOrderList.Where(x => x.IsOldCustomer == true).Count();
            result.TotalTotalCustomerNum = currentContentOrderList.Count();

            result.NewCustomerNumChainRate = DecimalExtension.CalculateChain(result.TotalNewCustomerNum, lastMonthContentOrderList.Where(x => x.IsOldCustomer == false).Count()).Value;
            result.OldCustomerNumChainRate = DecimalExtension.CalculateChain(result.TotalOldCustomerNum, lastMonthContentOrderList.Where(x => x.IsOldCustomer == true).Count()).Value;
            result.TotalCustomerNumChainRate = DecimalExtension.CalculateChain(result.TotalTotalCustomerNum, lastMonthContentOrderList.Count()).Value;

            result.NewCustomerNumYearOnYearData = DecimalExtension.CalculateChain(result.TotalNewCustomerNum, lastYearContentOrderList.Where(x => x.IsOldCustomer == false).Count()).Value;
            result.OldCustomerNumYearOnYearData = DecimalExtension.CalculateChain(result.TotalOldCustomerNum, lastYearContentOrderList.Where(x => x.IsOldCustomer == true).Count()).Value;
            result.TotalCustomerNumYearOnYearData = DecimalExtension.CalculateChain(result.TotalTotalCustomerNum, lastYearContentOrderList.Count()).Value;
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

            #region 派单上门

           // var dealInfoList = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= seqDate.StartDate && e.CreateDate < seqDate.EndDate && e.IsOldCustomer == false && e.IsToHospital == true && e.ToHospitalDate.HasValue)
           //         .Where(e => e.LastDealHospitalId == query.HospitalId.Value)
           //         .Select(e => new
           //         {
           //             HospitalId = e.LastDealHospitalId,
           //             Phone = e.ContentPlatFormOrder.Phone,
           //             ToHospitalDate = e.ToHospitalDate
           //         }).ToListAsync();
           // var dealPhoneList = dealInfoList.Select(e => e.Phone).ToList();
           // var cartInfoList2 = _dalShoppingCartRegistration.GetAll().Where(e => e.IsReturnBackPrice == false && dealPhoneList.Contains(e.Phone))
           //.Select(e => new
           //{
           //    Phone = e.Phone,
           //    AddPrice = e.Price,
           //    RecordDate = e.RecordDate
           //}).ToList();
           // if (query.IsCurrent)
           // {
           //     cartInfoList2 = cartInfoList2.Where(e => e.RecordDate >= seqDate.StartDate && e.RecordDate < seqDate.EndDate).ToList();
           // }
           // else
           // {
           //     cartInfoList2 = cartInfoList2.Where(e => e.RecordDate < seqDate.StartDate).ToList();
           // }
           // var dataList2 = (from deal in dealInfoList
           //                  join cart in cartInfoList2
           //                  on deal.Phone equals cart.Phone
           //                  select new
           //                  {
           //                      EmpId = deal.EmpId,
           //                      AddPrice = cart.AddPrice,
           //                      IntervalDays = (deal.ToHospitalDate.Value - cart.RecordDate).Days
           //                  }).ToList();
           // dataList2.RemoveAll(e => e.IntervalDays < 0);
           // //转化周期数据
           // var res2 = dataList2.GroupBy(e => e.EmpId).Select(e =>
           // {
           //     var endIndex = DecimalExtension.CalTakeCount(e.Count(), 0.6m);
           //     var resData = e.OrderBy(e => e.IntervalDays).Skip(0).Take(endIndex);
           //     return new KeyValuePair<string, int>(
           //     hospitalList.Where(a => a.Id == e.Key).FirstOrDefault()?.Name ?? "其它",
           //     DecimalExtension.CalAvg(resData.Sum(e => e.IntervalDays), resData.Count()));
           // }).OrderBy(e => e.Value).ToList();
           // res2.RemoveAll(e => e.Key == "其它" || e.Value == 0);
           // //当前助理转化周期
           // //var currentAssistanListCount2 = dataList2.Where(e => e.EmpId == query.HospitalId.Value).Count();
           // //var endIndex2 = DecimalExtension.CalTakeCount(currentAssistanListCount2, 0.6m);
           // //var currentAssistanList2 = dataList2.Where(e => e.EmpId == query.HospitalId.Value).OrderBy(e => e.IntervalDays).Skip(0).Take(endIndex2);
           // //var currentEffectiveDays2 = currentAssistanList2.Where(e => e.AddPrice > 0).Sum(e => e.IntervalDays);
           // //var currentEffectiveCount2 = currentAssistanList2.Where(e => e.AddPrice > 0).Count();
           // //var currentPotionelDays2 = currentAssistanList2.Where(e => e.AddPrice == 0).Sum(e => e.IntervalDays);
           // //var currentPotionelCount2 = currentAssistanList2.Where(e => e.AddPrice == 0).Count();
           // //data.TotalToHospitalCycle = DecimalExtension.CalAvg(currentAssistanList2.Sum(e => e.IntervalDays), currentAssistanList2.Count());
           // //data.EffectiveToHospitalCycle = DecimalExtension.CalAvg(currentEffectiveDays2, currentEffectiveCount2);
           // //data.PotionelToHospitalCycle = DecimalExtension.CalAvg(currentPotionelDays2, currentPotionelCount2);
           // List<Dictionary<string, int>> resultData2 = new List<Dictionary<string, int>>();
           // foreach (var z in res2)
           // {
           //     Dictionary<string, int> resultData = new Dictionary<string, int>();
           //     resultData.Add(z.Key, z.Value);
           //     resultData2.Add(resultData);
           // }
           // foreach (var k in hospitalList)
           // {
           //     bool exists = resultData2.Any(dic => dic.ContainsKey(k.Name));
           //     if (exists == false)
           //     {
           //         Dictionary<string, int> resultData = new Dictionary<string, int>();
           //         resultData.Add(k.Name, 0);
           //         resultData2.Add(resultData);
           //     }
           // }
           // List<KeyValuePair<string, int>> toHospitalCycleData = new List<KeyValuePair<string, int>>();
           // foreach (var x in resultData2)
           // {
           //     foreach (var kvp in x)
           //     {
           //         toHospitalCycleData.Add(new KeyValuePair<string, int>(kvp.Key, kvp.Value));
           //     }
           // }
           // data.ToHospitalCycleData = toHospitalCycleData.OrderBy(x => x.Value).ToList();


            #endregion

            #region 复购率

            //var totalDealList = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.IsDeal == true && e.Price > 0 && e.ContentPlatFormOrder.DealAmount > 0)
            //    .Select(e => new
            //    {
            //        Phone = e.ContentPlatFormOrder.Phone,
            //        EmpId = e.ContentPlatFormOrder.IsSupportOrder ? e.ContentPlatFormOrder.SupportEmpId : e.ContentPlatFormOrder.BelongEmpId,
            //    }).Where(e => hospitalIdList.Contains(e.EmpId.Value)).ToListAsync();
            //var hospitalTotalDealList = totalDealList.GroupBy(e => e.EmpId).Select(e => new
            //{
            //    EmpId = e.Key,
            //    TotalDealCount = e.Select(e => e.Phone).Distinct().Count()
            //}).ToList();
            //var currentMonthDeal = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.IsToHospital == true && e.IsOldCustomer == true && e.CreateDate >= seqDate.StartDate && e.CreateDate < seqDate.EndDate)
            //    .Select(e => new
            //    {
            //        Phone = e.ContentPlatFormOrder.Phone,
            //        EmpId = e.ContentPlatFormOrder.IsSupportOrder ? e.ContentPlatFormOrder.SupportEmpId : e.ContentPlatFormOrder.BelongEmpId,
            //    }).Where(e => hospitalIdList.Contains(e.EmpId.Value)).ToListAsync();
            //var hospitalCurrentMonthDeal = currentMonthDeal.GroupBy(e => e.EmpId).Select(e => new
            //{
            //    EmpId = e.Key,
            //    TotalDealCount = e.Select(e => e.Phone).Distinct().Count()
            //}).ToList();
            ////当月复购率数据
            //var res3 = (from total in hospitalTotalDealList
            //            join current in hospitalCurrentMonthDeal
            //            on total.EmpId equals current.EmpId
            //            into tc
            //            from r in tc.DefaultIfEmpty()
            //            select new KeyValuePair<string, decimal>(
            //                hospitalList.Where(a => a.Id == total.EmpId).FirstOrDefault()?.Name ?? "其它",
            //                r != null ? (total.TotalDealCount == 0 ? 0 : DecimalExtension.CalculateTargetComplete(r.TotalDealCount, total.TotalDealCount).Value) : 0)
            //          ).OrderByDescending(e => e.Value).ToList();
            //res3.RemoveAll(e => e.Key == "其它" || e.Value == 0);

            //List<Dictionary<string, decimal>> resultData3 = new List<Dictionary<string, decimal>>();
            //foreach (var z in res3)
            //{
            //    Dictionary<string, decimal> resultData = new Dictionary<string, decimal>();
            //    resultData.Add(z.Key, z.Value);
            //    resultData3.Add(resultData);
            //}
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
            //List<KeyValuePair<string, decimal>> repeateBuyCycleData = new List<KeyValuePair<string, decimal>>();
            //foreach (var x in resultData3)
            //{
            //    foreach (var kvp in x)
            //    {
            //        repeateBuyCycleData.Add(new KeyValuePair<string, decimal>(kvp.Key, kvp.Value));
            //    }
            //}
            //data.OldCustomerRePurcheData = repeateBuyCycleData.OrderBy(x => x.Value).ToList();

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


            #region 机构线索
            //var hospitalInfo = await hospitalInfoService.GetHospitalNameListAsync(null, null);
            //var sendOrderHospitalList = await contentPlateFormOrderService.GetDealCountDataByPhoneListAsync(selectDate.StartDate, selectDate.EndDate, sendPhoneList);
            //var hospitalIds = sendOrderHospitalList.Distinct().ToList();
            //var toHospitalData = await contentPlatFormOrderDealInfoService.GeVisitAndDealNumByHospitalIdAndPhoneListAsync(hospitalIds, selectDate.StartDate, selectDate.EndDate, sendPhoneList);
            //result.Items = hospitalIds.Select(e =>
            //{
            //    HospitalCluesDataItemDto item = new HospitalCluesDataItemDto();
            //    item.Name = hospitalInfo.Where(h => h.Id == e).Select(e => e.Name).FirstOrDefault();
            //    item.VisitCount = toHospitalData.Where(x => x.IsToHospital == true && x.LastDealHospitalId == e).Count();
            //    item.DealCount = toHospitalData.Where(x => x.IsDeal == true && x.LastDealHospitalId == e).Count();
            //    item.DealRate = DecimalExtension.CalculateTargetComplete(item.DealCount, item.VisitCount).Value;
            //    return item;
            //}).ToList();
            #endregion
            // result.DealRate = DecimalExtension.CalculateTargetComplete(result.TotalDealCount, result.TotalVisitCount).Value;
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
            //var selectDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.EndDate.Year, query.EndDate.Month);
            //var hospitalIdAndNameList = (await amiyaEmployeeService.GetAllHospitalAsync()).ToList();
            //var hospitalTarget = await dalEmployeePerformanceTarget.GetAll()
            //    .Where(e => e.Valid == true)
            //    .Where(e => e.BelongYear == selectDate.EndDate.Year && e.BelongMonth == selectDate.EndDate.Month)
            //    .Where(e => hospitalIdAndNameList.Select(e => e.Id).Contains(e.EmployeeId))
            //    .Select(e => new
            //    {
            //        EmployeeId = e.EmployeeId,
            //        Target = e.NewCustomerPerformanceTarget + e.OldCustomerPerformanceTarget,
            //    }).ToListAsync();
            //var currentContentOrderList = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAndHospitalIdListAsync(selectDate.StartDate, selectDate.EndDate, hospitalIdAndNameList.Select(e => e.Id).ToList());
            //var totalPerformance = currentContentOrderList.Sum(e => e.Price);
            //foreach (var hospital in hospitalIdAndNameList)
            //{
            //    var sumPerformance = currentContentOrderList.Where(e => e.BelongEmployeeId == hospital.Id).Sum(e => e.Price);
            //    BaseKeyValueDto<string, decimal> targetItem = new BaseKeyValueDto<string, decimal>();
            //    var target = hospitalTarget.Where(e => e.EmployeeId == hospital.Id).FirstOrDefault()?.Target ?? 0;
            //    targetItem.Key = hospital.Name;
            //    targetItem.Value = DecimalExtension.CalculateTargetComplete(sumPerformance, target).Value;
            //    result.TargetCompleteData.Add(targetItem);
            //    BaseKeyValueDto<string, decimal> rateItem = new BaseKeyValueDto<string, decimal>();
            //    rateItem.Key = hospital.Name;
            //    rateItem.Value = DecimalExtension.CalculateTargetComplete(sumPerformance, totalPerformance).Value;
            //    result.PerformanceRateData.Add(rateItem);
            //}
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
