
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.AmiyaHospitalOperation.Input;
using Fx.Amiya.Background.Api.Vo.AmiyaHospitalOperation.Result;
using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using Fx.Amiya.Dto.AmiyaHospitalOperation.Input;
using Fx.Amiya.Dto.AmiyaHospitalOperation.Result;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 机构运营看板
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaHospitalOperationBoardController : ControllerBase
    {
        private readonly IAmiyaHospitalOperationBoardService amiyaHospitalOperationBoardService;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IAmiyaEmployeeService amiyaEmployeeService;

        public AmiyaHospitalOperationBoardController(IHttpContextAccessor httpContextAccessor, IAmiyaHospitalOperationBoardService amiyaHospitalOperationBoardService, IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.amiyaHospitalOperationBoardService = amiyaHospitalOperationBoardService;
            _httpContextAccessor = httpContextAccessor;
            this.amiyaEmployeeService = amiyaEmployeeService;
        }
        /// <summary>
        /// 机构业绩
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalPerformance")]
        public async Task<ResultData<HospitalPerformanceVo>> GetHospitalPerformanceAsync([FromQuery] QueryAmiyaHospitalOperationsDataVo query)
        {
            QueryHospitalPerformanceDto queryDto = new QueryHospitalPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.HospitalId = query.HospitalId;
            var res = await amiyaHospitalOperationBoardService.GetHospitalPerformanceAsync(queryDto);
            HospitalPerformanceVo performanceVo = new HospitalPerformanceVo();
            performanceVo.NewCustomerPerformance = res.NewCustomerPerformance;
            performanceVo.OldCustomerPerformance = res.OldCustomerPerformance;
            performanceVo.TotalPerformance = res.TotalPerformance;
            performanceVo.TodayNewCustomerPerformance = res.TodayNewCustomerPerformance;
            performanceVo.TodayOldCustomerPerformance = res.TodayOldCustomerPerformance;
            performanceVo.TodayTotalPerformance = res.TodayTotalPerformance;
            performanceVo.LastMonthNewCustomerPerformance = res.LastMonthNewCustomerPerformance;
            performanceVo.LastMonthOldCustomerPerformance = res.LastMonthOldCustomerPerformance;
            performanceVo.LastMonthTotalPerformance = res.LastMonthTotalPerformance;
            performanceVo.LastYearNewCustomerPerformance = res.LastYearNewCustomerPerformance;
            performanceVo.LastYearOldCustomerPerformance = res.LastYearOldCustomerPerformance;
            performanceVo.LastYearTotalPerformance = res.LastYearTotalPerformance;
            performanceVo.NewCustomerPerformanceChain = res.NewCustomerPerformanceChain;
            performanceVo.OldCustomerPerformanceChain = res.OldCustomerPerformanceChain;
            performanceVo.TotalPerformanceChain = res.TotalPerformanceChain;
            performanceVo.NewCustomerPerformanceYearOnYear = res.NewCustomerPerformanceYearOnYear;
            performanceVo.OldCustomerPerformanceYearOnYear = res.OldCustomerPerformanceYearOnYear;
            performanceVo.TotalPerformanceYearOnYear = res.TotalPerformanceYearOnYear;
            return ResultData<HospitalPerformanceVo>.Success().AddData("data", performanceVo);
        }

        /// <summary>
        /// 机构上门
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalVisitData")]
        public async Task<ResultData<HospitalVisitDataVo>> GetEffOrPotDistributeConsulationDataAsync([FromQuery] QueryAmiyaHospitalOperationsDataVo query)
        {
            HospitalVisitDataVo data = new HospitalVisitDataVo();
            QueryHospitalPerformanceDto queryDto = new QueryHospitalPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.HospitalId = query.HospitalId;
            var res = await amiyaHospitalOperationBoardService.GetHospitalVisitDataDto(queryDto);
            data.TodayNewCustomerNum = res.TodayNewCustomerNum;
            data.TotalNewCustomerNum = res.TotalNewCustomerNum;
            data.NewCustomerNumChainRate = res.NewCustomerNumChainRate;
            data.NewCustomerNumYearOnYearData = res.NewCustomerNumYearOnYearData;

            data.TodayOldCustomerNum = res.TodayOldCustomerNum;
            data.TotalOldCustomerNum = res.TotalOldCustomerNum;
            data.OldCustomerNumChainRate = res.OldCustomerNumChainRate;
            data.OldCustomerNumYearOnYearData = res.OldCustomerNumYearOnYearData;

            data.TodayTotalCustomerNum = res.TodayTotalCustomerNum;
            data.TotalTotalCustomerNum = res.TotalTotalCustomerNum;
            data.TotalCustomerNumChainRate = res.TotalCustomerNumChainRate;
            data.TotalCustomerNumYearOnYearData = res.TotalCustomerNumYearOnYearData;


            return ResultData<HospitalVisitDataVo>.Success().AddData("data", data);

        }

        /// <summary>
        /// 机构业绩折线图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalPerformancebrokenLineData")]
        public async Task<ResultData<HospitalPerformanceBrokenLineVo>> GetHospitalPerformanceBrokenLineAsync([FromQuery] QueryAmiyaHospitalOperationsDataVo query)
        {
            HospitalPerformanceBrokenLineVo performanceBroken = new HospitalPerformanceBrokenLineVo();
            QueryHospitalPerformanceDto queryDto = new QueryHospitalPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.HospitalId = query.HospitalId;
            var res = await amiyaHospitalOperationBoardService.GetHospitalPerformanceBrokenLineDto(queryDto);
            performanceBroken.NewCustomerPerformance = res.NewCustomerPerformance.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            performanceBroken.OldCustomerPerformance = res.OldCustomerPerformance.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            performanceBroken.TotalPerformance = res.TotalPerformance.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            return ResultData<HospitalPerformanceBrokenLineVo>.Success().AddData("data", performanceBroken);
        }

        /// <summary>
        /// 机构上门客资折线图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalVisitBrokenLineData")]
        public async Task<ResultData<HospitalPerformanceBrokenLineVo>> GetAdminCustomerServiceEffOrPotBrokenLineDataAsync([FromQuery] QueryAmiyaHospitalOperationsDataVo query)
        {
            QueryHospitalPerformanceDto queryDto = new QueryHospitalPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.HospitalId = query.HospitalId;
            var res = await amiyaHospitalOperationBoardService.GetHospitalVisitBrokenLineDto(queryDto);

            HospitalPerformanceBrokenLineVo performanceBroken = new HospitalPerformanceBrokenLineVo();
            performanceBroken.NewCustomerPerformance = res.NewCustomerPerformance.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            performanceBroken.OldCustomerPerformance = res.OldCustomerPerformance.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            performanceBroken.TotalPerformance = res.TotalPerformance.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();

            return ResultData<HospitalPerformanceBrokenLineVo>.Success().AddData("data", performanceBroken);

        }

        /// <summary>
        /// 机构新老客业绩漏斗图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalPerformanceFilterData")]
        public async Task<ResultData<HospitalNewOrOldCustomerDataVo>> GetHospitalPerformanceFilterDataAsync([FromQuery] QuerHospitalPerformanceFilterDataVo query)
        {
            HospitalNewOrOldCustomerDataVo result = new HospitalNewOrOldCustomerDataVo();
            QueryHospitalPerformanceDto queryDto = new QueryHospitalPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.HospitalId = query.HospitalId;
            queryDto.IsCurrent = query.IsCurrentMonth;
            var performance = await amiyaHospitalOperationBoardService.GetAssistantPerformanceFilterDataAsync(queryDto);

            HospitalNewCustomerOperationDataVo newCustomerOperationDataVo = new HospitalNewCustomerOperationDataVo();
           
            newCustomerOperationDataVo.ToHospitalRate = performance.NewCustomerData.ToHospitalRate.HasValue ? performance.NewCustomerData.ToHospitalRate.Value : 0.00M;
            newCustomerOperationDataVo.ToHospitalRateHealthValueThisMonth = performance.NewCustomerData.ToHospitalRateHealthValueThisMonth;
            newCustomerOperationDataVo.DealRate = performance.NewCustomerData.DealRate.HasValue ? performance.NewCustomerData.DealRate.Value : 0.00M;
            newCustomerOperationDataVo.DealRateHealthValueThisMonth = performance.NewCustomerData.DealRateHealthValueThisMonth;
            newCustomerOperationDataVo.newCustomerOperationDataDetails = new List<HospitalNewCustomerOperationDataDetailsVo>();
            foreach (var x in performance.NewCustomerData.newCustomerOperationDataDetails)
            {
                HospitalNewCustomerOperationDataDetailsVo newCustomerOperationDataDetails = new HospitalNewCustomerOperationDataDetailsVo();
                newCustomerOperationDataDetails.Key = x.Key;
                newCustomerOperationDataDetails.Name = x.Name;
                newCustomerOperationDataDetails.Value = x.Value;
                newCustomerOperationDataVo.newCustomerOperationDataDetails.Add(newCustomerOperationDataDetails);
            }

            HospitalOldCustomerOperationDataVo oldCustomerOperationDataVo = new HospitalOldCustomerOperationDataVo();
            oldCustomerOperationDataVo.TotalDealPeople = performance.OldCustomerData.TotalDealPeople;
            oldCustomerOperationDataVo.SecondDealPeople = performance.OldCustomerData.SecondDealPeople;
            oldCustomerOperationDataVo.ThirdDealPeople = performance.OldCustomerData.ThirdDealPeople;
            oldCustomerOperationDataVo.FourthDealCustomer = performance.OldCustomerData.FourthDealCustomer;
            oldCustomerOperationDataVo.FifThOrMoreOrMoreDealCustomer = performance.OldCustomerData.FifThOrMoreOrMoreDealCustomer;
            oldCustomerOperationDataVo.SecondTimeBuyRateProportion = performance.OldCustomerData.SecondTimeBuyRateProportion;
            oldCustomerOperationDataVo.ThirdTimeBuyRateProportion = performance.OldCustomerData.ThirdTimeBuyRateProportion;
            oldCustomerOperationDataVo.FourthTimeBuyRateProportion = performance.OldCustomerData.FourthTimeBuyRateProportion;
            oldCustomerOperationDataVo.FifthTimeOrMoreBuyRateProportion = performance.OldCustomerData.FifthTimeOrMoreBuyRateProportion;
            oldCustomerOperationDataVo.BuyRate = performance.OldCustomerData.BuyRate;
            oldCustomerOperationDataVo.SecondDealCycle = performance.OldCustomerData.SecondDealCycle;
            oldCustomerOperationDataVo.ThirdDealCycle = performance.OldCustomerData.ThirdDealCycle;
            oldCustomerOperationDataVo.FourthDealCycle = performance.OldCustomerData.FourthDealCycle;
            oldCustomerOperationDataVo.FifthDealCycle = performance.OldCustomerData.FifthDealCycle;
            result.NewCustomerData = newCustomerOperationDataVo;
            result.OldCustomerData = oldCustomerOperationDataVo;

            return ResultData<HospitalNewOrOldCustomerDataVo>.Success().AddData("data", result);


        }

        /// <summary>
        /// 机构周期转化
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getHospitalTransformCycleData")]
        public async Task<ResultData<HospitalTransformCycleDataVo>> GetHospitalTransformCycleDataAsync([FromQuery] QuerHospitalPerformanceFilterDataVo query)
        {
            HospitalTransformCycleDataVo data = new HospitalTransformCycleDataVo();
            QueryHospitalPerformanceDto queryDto = new QueryHospitalPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.HospitalId = query.HospitalId;
            queryDto.IsCurrent = query.IsCurrentMonth;
            var res = await amiyaHospitalOperationBoardService.GetHospitalTransformCycleDataAsync(queryDto);
            data.ToHospitalCycleData = res.ToHospitalCycleData;
            data.OldCustomerRePurcheData = res.OldCustomerRePurcheData;
            return ResultData<HospitalTransformCycleDataVo>.Success().AddData(data);
        }
        /// <summary>
        /// 机构线索数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalHospitalCluesData")]
        public async Task<ResultData<HospitaslVisitDataVo>> GetHospitalCluesDataAsync([FromQuery] QueryHospitalVisitDataVo query)
        {
            HospitaslVisitDataVo dataVo = new HospitaslVisitDataVo();
            QueryHospitalVisitDataDto queryDto = new QueryHospitalVisitDataDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.HospitalId = query.HospitalId;
            queryDto.NewCustomer = query.NewCustomer;
            queryDto.OldCustomer = query.OldCustomer;
            var res = await amiyaHospitalOperationBoardService.GetHospitalsCluesDataAsync(queryDto);
            dataVo.TotalVisitCount = res.TotalVisitCount;
            dataVo.TotalDealCount = res.TotalDealCount;
            dataVo.DealRate = res.DealRate;
            dataVo.Items = res.Items.OrderByDescending(e => e.VisitCount).Select(e => new HospitalCluesDataItemVo
            {
                Name = e.Name,
                VisitCount = e.VisitCount,
                DealCount = e.DealCount,
                DealRate = e.DealRate
            }).ToList();
            return ResultData<HospitaslVisitDataVo>.Success().AddData("data", dataVo);
        }
        /// <summary>
        /// 机构业绩贡献占比柱状图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalPerformanceRateData")]
        public async Task<ResultData<HospitalPerformanceRateVo>> GetHospitalPerformanceRateDataAsync([FromQuery] QueryAmiyaHospitalOperationsDataVo query)
        {
            HospitalPerformanceRateVo result = new HospitalPerformanceRateVo();
            QueryHospitalPerformanceDto queryDto = new QueryHospitalPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.HospitalId = query.HospitalId;
            var res = await amiyaHospitalOperationBoardService.GetHospitalPerformanceRateDataAsync(queryDto);
            result.PerformanceRateData = res.PerformanceRateData.OrderByDescending(e => e.Value).Select(e => new BaseIdAndNameVo<string, decimal>
            {
                Id = e.Key,
                Name = e.Value,
            }).ToList();
           
            result.PerformanceRateData.RemoveAll(e => e.Name == 0m);
            return ResultData<HospitalPerformanceRateVo>.Success().AddData("data", result);
        }
    }
}
