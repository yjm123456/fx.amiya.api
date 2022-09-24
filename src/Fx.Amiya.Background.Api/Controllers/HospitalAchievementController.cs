using Fx.Amiya.Background.Api.Vo.HospitalPerformance;
using Fx.Amiya.Background.Api.Vo.Performance;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{

    /// <summary>
    /// 机构业绩接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class HospitalAchievementController : ControllerBase
    {
        private IHospitalPerformanceService hospitalPerformanceService;
        public HospitalAchievementController(IHospitalPerformanceService hospitalPerformanceService)
        {
            this.hospitalPerformanceService = hospitalPerformanceService;
        }


        #region 【全国机构运营总览】

        /// <summary>
        /// 全国机构运营当日数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getHospitalOperationDailyData")]
        public async Task<ResultData<List<HospitalOperatingDataVo>>> GetHospitalOperationDairyData(int? year)
        {
            List<HospitalOperatingDataVo> hospitalPerformanceVo = new List<HospitalOperatingDataVo>();
            var hospitalPerformanceDatas = await hospitalPerformanceService.GetHospitalDailyPerformanceAsync(year);
            hospitalPerformanceDatas = hospitalPerformanceDatas.OrderByDescending(x => x.SendNum).ToList();
            foreach (var x in hospitalPerformanceDatas)
            {
                HospitalOperatingDataVo hospitalOperatingDataVo = new HospitalOperatingDataVo();
                hospitalOperatingDataVo.HospitalName = x.HospitalName;
                hospitalOperatingDataVo.City = x.City;
                hospitalOperatingDataVo.SendNum = x.SendNum;
                hospitalOperatingDataVo.VisitNum = x.VisitNum;
                hospitalOperatingDataVo.VisitRate = x.VisitRate;
                hospitalOperatingDataVo.NewCustomerDealNum = x.NewCustomerDealNum;
                hospitalOperatingDataVo.NewCustomerDealRate = x.NewCustomerDealRate;
                hospitalOperatingDataVo.NewCustomerAchievement = x.NewCustomerAchievement;
                hospitalOperatingDataVo.NewCustomerUnitPrice = x.NewCustomerUnitPrice;
                hospitalOperatingDataVo.OldCustomerDealNum = x.OldCustomerDealNum;
                hospitalOperatingDataVo.OldCustomerAchievement = x.OldCustomerAchievement;
                hospitalOperatingDataVo.OldCustomerUnitPrice = x.OldCustomerUnitPrice;
                hospitalOperatingDataVo.TotalAchievement = x.TotalAchievement;
                hospitalOperatingDataVo.NewOrOldCustomerRate = x.NewOrOldCustomerRate;
                hospitalPerformanceVo.Add(hospitalOperatingDataVo);
            }
            return ResultData<List<HospitalOperatingDataVo>>.Success().AddData("performance", hospitalPerformanceVo);
        }

        /// <summary>
        /// 全国机构运营当年数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getHospitalOperationYearData")]
        public async Task<ResultData<HospitalOperatingYearDataVo>> GetHospitalOperationDairyByYearData(int? year)
        {
            HospitalOperatingYearDataVo hospitalPerformanceVo = new HospitalOperatingYearDataVo();
            var hospitalPerformanceDatas = await hospitalPerformanceService.GetHospitalDailyPerformanceAsync(year);
            hospitalPerformanceDatas = hospitalPerformanceDatas.OrderByDescending(x => x.SendNum).ToList();


            #region [总计数据输出]
            HospitalOperatingDataVo allCountInfoAddCount = new HospitalOperatingDataVo();
            allCountInfoAddCount.HospitalName = "/";
            allCountInfoAddCount.City = "当年总计";
            allCountInfoAddCount.SendNum = hospitalPerformanceDatas.Sum(x => x.SendNum);
            allCountInfoAddCount.VisitNum = hospitalPerformanceDatas.Sum(x => x.VisitNum);
            allCountInfoAddCount.VisitRate = hospitalPerformanceService.CalculateTargetComplete(allCountInfoAddCount.VisitNum, allCountInfoAddCount.SendNum).Value;
            allCountInfoAddCount.NewCustomerDealNum = hospitalPerformanceDatas.Sum(x => x.NewCustomerDealNum);
            allCountInfoAddCount.NewCustomerDealRate = hospitalPerformanceService.CalculateTargetComplete(allCountInfoAddCount.NewCustomerDealNum, allCountInfoAddCount.VisitNum).Value;
            allCountInfoAddCount.NewCustomerAchievement = hospitalPerformanceDatas.Sum(x => x.NewCustomerAchievement);
            allCountInfoAddCount.NewCustomerUnitPrice = hospitalPerformanceService.Division(allCountInfoAddCount.NewCustomerAchievement, allCountInfoAddCount.NewCustomerDealNum).Value;

            allCountInfoAddCount.OldCustomerDealNum = hospitalPerformanceDatas.Sum(x => x.OldCustomerDealNum);
            allCountInfoAddCount.OldCustomerAchievement = hospitalPerformanceDatas.Sum(x => x.OldCustomerAchievement);
            allCountInfoAddCount.OldCustomerUnitPrice = hospitalPerformanceService.Division(allCountInfoAddCount.OldCustomerAchievement, allCountInfoAddCount.OldCustomerDealNum).Value;
            allCountInfoAddCount.TotalAchievement = hospitalPerformanceDatas.Sum(x => x.TotalAchievement);
            allCountInfoAddCount.NewOrOldCustomerRate = hospitalPerformanceService.CalculateAccounted(allCountInfoAddCount.NewCustomerAchievement, allCountInfoAddCount.OldCustomerAchievement);
            hospitalPerformanceVo.TotalSum = allCountInfoAddCount;
            #endregion

            #region [前十数据输出]
            var topTenList = hospitalPerformanceDatas.Take(10).ToList();
            hospitalPerformanceVo.TopTenHospitalOperatingDataVo = new List<HospitalOperatingDataVo>();
            foreach (var x in topTenList)
            {
                HospitalOperatingDataVo topTenInfo = new HospitalOperatingDataVo();
                topTenInfo.HospitalName = x.HospitalName;
                topTenInfo.HospitalId = x.HospitalId;
                topTenInfo.City = x.City;
                topTenInfo.SendNum = x.SendNum;
                topTenInfo.VisitNum = x.VisitNum;
                topTenInfo.VisitRate = x.VisitRate;
                topTenInfo.NewCustomerDealNum = x.NewCustomerDealNum;
                topTenInfo.NewCustomerDealRate = x.NewCustomerDealRate;
                topTenInfo.NewCustomerAchievement = x.NewCustomerAchievement;
                topTenInfo.NewCustomerUnitPrice = x.NewCustomerUnitPrice;
                topTenInfo.OldCustomerDealNum = x.OldCustomerDealNum;
                topTenInfo.OldCustomerAchievement = x.OldCustomerAchievement;
                topTenInfo.OldCustomerUnitPrice = x.OldCustomerUnitPrice;
                topTenInfo.TotalAchievement = x.TotalAchievement;
                topTenInfo.NewOrOldCustomerRate = x.NewOrOldCustomerRate;
                hospitalPerformanceVo.TopTenHospitalOperatingDataVo.Add(topTenInfo);
            }

            #region 加入前十总计数据
            HospitalOperatingDataVo topTenInfoAddCount = new HospitalOperatingDataVo();
            topTenInfoAddCount.HospitalName = "/";
            topTenInfoAddCount.City = "头部总计";
            topTenInfoAddCount.SendNum = topTenList.Sum(x => x.SendNum);
            topTenInfoAddCount.VisitNum = topTenList.Sum(x => x.VisitNum);
            topTenInfoAddCount.VisitRate = hospitalPerformanceService.CalculateTargetComplete(topTenInfoAddCount.VisitNum, topTenInfoAddCount.SendNum).Value;
            topTenInfoAddCount.NewCustomerDealNum = topTenList.Sum(x => x.NewCustomerDealNum);
            topTenInfoAddCount.NewCustomerDealRate = hospitalPerformanceService.CalculateTargetComplete(topTenInfoAddCount.NewCustomerDealNum, topTenInfoAddCount.VisitNum).Value;
            topTenInfoAddCount.NewCustomerAchievement = topTenList.Sum(x => x.NewCustomerAchievement);
            topTenInfoAddCount.NewCustomerUnitPrice = topTenInfoAddCount.NewCustomerAchievement / topTenInfoAddCount.NewCustomerDealNum;

            topTenInfoAddCount.OldCustomerDealNum = topTenList.Sum(x => x.OldCustomerDealNum);
            topTenInfoAddCount.OldCustomerAchievement = topTenList.Sum(x => x.OldCustomerAchievement);
            topTenInfoAddCount.OldCustomerUnitPrice = topTenInfoAddCount.OldCustomerAchievement / topTenInfoAddCount.OldCustomerDealNum;
            topTenInfoAddCount.TotalAchievement = topTenList.Sum(x => x.TotalAchievement);
            topTenInfoAddCount.NewOrOldCustomerRate = hospitalPerformanceService.CalculateAccounted(topTenInfoAddCount.NewCustomerAchievement, topTenInfoAddCount.OldCustomerAchievement);
            hospitalPerformanceVo.TopTenHospitalOperatingDataVo.Add(topTenInfoAddCount);
            #endregion
            #endregion

            #region [其他数据输出]
            var otherList = hospitalPerformanceDatas.ToList();
            var allCount = otherList.Count();
            if (allCount >= 10)
            {
                allCount = 10;

                for (int i = 0; i < allCount; i++)
                {
                    otherList.RemoveAt(0);
                }
                hospitalPerformanceVo.OtherHospitalOperatingDataVo = new List<HospitalOperatingDataVo>();
                foreach (var x in otherList)
                {
                    HospitalOperatingDataVo otherInfo = new HospitalOperatingDataVo();
                    otherInfo.HospitalName = x.HospitalName;
                    otherInfo.HospitalId = x.HospitalId;
                    otherInfo.City = x.City;
                    otherInfo.SendNum = x.SendNum;
                    otherInfo.VisitNum = x.VisitNum;
                    otherInfo.VisitRate = x.VisitRate;
                    otherInfo.NewCustomerDealNum = x.NewCustomerDealNum;
                    otherInfo.NewCustomerDealRate = x.NewCustomerDealRate;
                    otherInfo.NewCustomerAchievement = x.NewCustomerAchievement;
                    otherInfo.NewCustomerUnitPrice = x.NewCustomerUnitPrice;
                    otherInfo.OldCustomerDealNum = x.OldCustomerDealNum;
                    otherInfo.OldCustomerAchievement = x.OldCustomerAchievement;
                    otherInfo.OldCustomerUnitPrice = x.OldCustomerUnitPrice;
                    otherInfo.TotalAchievement = x.TotalAchievement;
                    otherInfo.NewOrOldCustomerRate = x.NewOrOldCustomerRate;
                    hospitalPerformanceVo.OtherHospitalOperatingDataVo.Add(otherInfo);
                }
            }

            #endregion
            return ResultData<HospitalOperatingYearDataVo>.Success().AddData("performance", hospitalPerformanceVo);
        }

        /// <summary>
        /// 根据医院id与年份获取派单折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalSendOrderBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetSendOrderBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            //派单情况
            var sendOrder = await hospitalPerformanceService.GetHospitalSendOrderNum(year, hospitalId);
            //派单折线图转换
            var sendOrderBrokenLine = sendOrder.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeSendOrderBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, sendOrderBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("sendOrderPerformance", changeSendOrderBrokenLine);
        }

        /// <summary>
        /// 根据医院id与年份获取上门数折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalVisitBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetVisitBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            var Visit = await hospitalPerformanceService.GetHospitalVisitNum(year, hospitalId);
            var VisitBrokenLine = Visit.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeVisitBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, VisitBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("VisitPerformance", changeVisitBrokenLine);
        }

        /// <summary>
        /// 根据医院id与年份获取上门率折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalVisitRateBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetVisitRateBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            var VisitRate = await hospitalPerformanceService.GetHospitalVisitRateNum(year, hospitalId);
            var VisitRateBrokenLine = VisitRate.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeVisitRateBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, VisitRateBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("VisitRatePerformance", changeVisitRateBrokenLine);
        }

        /// <summary>
        /// 根据医院id与年份获取新客成交数折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalNewCustomerDealBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetNewCustomerDealBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            var NewCustomerDeal = await hospitalPerformanceService.GetHospitalNewCustomerDealNum(year, hospitalId);
            var NewCustomerDealBrokenLine = NewCustomerDeal.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeNewCustomerDealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, NewCustomerDealBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("NewCustomerDealPerformance", changeNewCustomerDealBrokenLine);
        }
        /// <summary>
        /// 根据医院id与年份获取新客成交率折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalNewCustomerDealRateBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetNewCustomerDealRateBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            var NewCustomerDealRate = await hospitalPerformanceService.GetHospitalNewCustomerDealRateNum(year, hospitalId);
            var NewCustomerDealRateBrokenLine = NewCustomerDealRate.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeNewCustomerDealRateBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, NewCustomerDealRateBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("NewCustomerDealRatePerformance", changeNewCustomerDealRateBrokenLine);
        }
        /// <summary>
        /// 根据医院id与年份获取新客业绩折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalNewCustomerPerformanceBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetNewCustomerPerformanceBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            var NewCustomerPerformance = await hospitalPerformanceService.GetHospitalNewCustomerPerformanceNum(year, hospitalId);
            var NewCustomerPerformanceBrokenLine = NewCustomerPerformance.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeNewCustomerPerformanceBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, NewCustomerPerformanceBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("NewCustomerPerformancePerformance", changeNewCustomerPerformanceBrokenLine);
        }
        /// <summary>
        /// 根据医院id与年份获取新客客单价折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalNewCustomerUnitPriceBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetNewCustomerUnitPriceBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            var NewCustomerUnitPrice = await hospitalPerformanceService.GetHospitalNewCustomerUnitPriceNum(year, hospitalId);
            var NewCustomerUnitPriceBrokenLine = NewCustomerUnitPrice.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeNewCustomerUnitPriceBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, NewCustomerUnitPriceBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("NewCustomerUnitPricePerformance", changeNewCustomerUnitPriceBrokenLine);
        }

        /// <summary>
        /// 根据医院id与年份获取老客成交数折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalOldCustomerDealBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetOldCustomerDealBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            var OldCustomerDeal = await hospitalPerformanceService.GetHospitalOldCustomerDealNum(year, hospitalId);
            var OldCustomerDealBrokenLine = OldCustomerDeal.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeOldCustomerDealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, OldCustomerDealBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("OldCustomerDealPerformance", changeOldCustomerDealBrokenLine);
        }
        /// <summary>
        /// 根据医院id与年份获取老客业绩折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalOldCustomerPerformanceBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetOldCustomerPerformanceBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            var OldCustomerPerformance = await hospitalPerformanceService.GetHospitalOldCustomerPerformanceNum(year, hospitalId);
            var OldCustomerPerformanceBrokenLine = OldCustomerPerformance.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeOldCustomerPerformanceBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, OldCustomerPerformanceBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("OldCustomerPerformancePerformance", changeOldCustomerPerformanceBrokenLine);
        }

        /// <summary>
        /// 根据医院id与年份获取老客客单价折线图
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("getHospitalOldCustomerUnitPriceBrokenLine")]
        public async Task<ResultData<List<PerformanceBrokenLine>>> GetOldCustomerUnitPriceBrokenLine(int year, int hospitalId)
        {
            int month = DateTime.Now.Month;
            var OldCustomerUnitPrice = await hospitalPerformanceService.GetHospitalOldCustomerUnitPriceNum(year, hospitalId);
            var OldCustomerUnitPriceBrokenLine = OldCustomerUnitPrice.Select(data => new PerformanceBrokenLine
            {
                Date = data.Date,
                PerfomancePrice = data.PerfomancePrice
            }).ToList();
            var changeOldCustomerUnitPriceBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, OldCustomerUnitPriceBrokenLine);
            return ResultData<List<PerformanceBrokenLine>>.Success().AddData("OldCustomerUnitPricePerformance", changeOldCustomerUnitPriceBrokenLine);
        }
        #endregion

    }
}