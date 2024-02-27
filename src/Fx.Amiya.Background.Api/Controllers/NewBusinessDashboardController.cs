using Fx.Amiya.Background.Api.Vo.NewBusinessDashboard;
using Fx.Amiya.Background.Api.Vo.NewBusinessDashboard.Input;
using Fx.Amiya.Background.Api.Vo.NewBusinessDashboard.Result;
using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using Fx.Amiya.Dto.NewBusinessDashboard;
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
    /// 新的经营看板
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class NewBusinessDashboardController : ControllerBase
    {
        private INewBusinessDashboardService newBusinessDashboardService;

        public NewBusinessDashboardController(INewBusinessDashboardService newBusinessDashboardService)
        {
            this.newBusinessDashboardService = newBusinessDashboardService;
        }
        #region 直播前业绩看板

        /// <summary>
        /// 直播前业绩看板数据
        /// </summary>
        [HttpGet("getBeforeLivingData")]
        public async Task<ResultData<BeforeLivingBusinessDataVo>> GetBeforeLivingBusinessDataAsync([FromQuery] QueryBeforeLivingBusinessDataVo queryVo)
        {
            QueryBeforeLivingBusinessDataDto queryDto = new QueryBeforeLivingBusinessDataDto();
            queryDto.BaseLiveAnchorId = queryVo.BaseLiveAnchorId;
            queryDto.Year = queryVo.Year;
            queryDto.Month = queryVo.Month;
            queryDto.ShowTikokData = queryVo.ShowTikTokData;
            queryDto.ShowWechatVideoData = queryVo.ShowWechatVideoData;
            queryDto.ShowXiaoHongShuData = queryVo.ShowXiaoHongShuData;
            var data = await newBusinessDashboardService.GetBeforeLivingBussinessDataAsync(queryDto);
            BeforeLivingBusinessDataVo businessDataVo = new BeforeLivingBusinessDataVo();
            businessDataVo.IncreaseFans = data.IncreaseFans;
            businessDataVo.IncreaseFansToDateSchedule = data.IncreaseFansToDateSchedule;
            businessDataVo.IncreaseFansTarget = data.IncreaseFansTarget;
            businessDataVo.IncreaseFansTargetCompleteRate = data.IncreaseFansTargetCompleteRate;
            businessDataVo.IncreaseFansChainRatio = data.IncreaseFansChainRatio;
            businessDataVo.IncreaseFansYearOnYear = data.IncreaseFansYearOnYear;
            businessDataVo.IncreaseFansFees = data.IncreaseFansFees;
            businessDataVo.IncreaseFansFeesToDateSchedule = data.IncreaseFansFeesToDateSchedule;
            businessDataVo.IncreaseFansFeesTarget = data.IncreaseFansFeesTarget;
            businessDataVo.IncreaseFansFeesTargetCompleteRate = data.IncreaseFansFeesTargetCompleteRate;
            businessDataVo.IncreaseFansFeesChainRatio = data.IncreaseFansFeesChainRatio;
            businessDataVo.IncreaseFansFeesYearOnYear = data.IncreaseFansFeesYearOnYear;
            businessDataVo.IncreaseFansFeesCost = data.IncreaseFansFeesCost;
            businessDataVo.IncreaseFansFeesCostToDateSchedule = data.IncreaseFansFeesCostToDateSchedule;
            businessDataVo.IncreaseFansFeesCostTarget = data.IncreaseFansFeesCostTarget;
            businessDataVo.IncreaseFansFeesCostTargetCompleteRate = data.IncreaseFansFeesCostTargetCompleteRate;
            businessDataVo.IncreaseFansFeesCostChainRatio = data.IncreaseFansFeesCostChainRatio;
            businessDataVo.IncreaseFansFeesCostYearOnYear = data.IncreaseFansFeesCostYearOnYear;
            businessDataVo.ShowcaseIncome = data.ShowcaseIncome;
            businessDataVo.ShowcaseIncomeToDateSchedule = data.ShowcaseIncomeToDateSchedule;
            businessDataVo.ShowcaseIncomeTarget = data.ShowcaseIncomeTarget;
            businessDataVo.ShowcaseIncomeTargetCompleteRate = data.ShowcaseIncomeTargetCompleteRate;
            businessDataVo.ShowcaseIncomeChainRatio = data.ShowcaseIncomeChainRatio;
            businessDataVo.ShowcaseIncomeYearOnYear = data.ShowcaseIncomeYearOnYear;
            businessDataVo.ShowcaseFee = data.ShowcaseFee;
            businessDataVo.ShowcaseFeeToDateSchedule = data.ShowcaseFeeToDateSchedule;
            businessDataVo.ShowcaseFeeTarget = data.ShowcaseFeeTarget;
            businessDataVo.ShowcaseFeeTargetCompleteRate = data.ShowcaseFeeTargetCompleteRate;
            businessDataVo.ShowcaseFeeChainRatio = data.ShowcaseFeeChainRatio;
            businessDataVo.ShowcaseFeeYearOnYear = data.ShowcaseFeeYearOnYear;
            businessDataVo.Clues = data.Clues;
            businessDataVo.CluesToDateSchedule = data.CluesToDateSchedule;
            businessDataVo.CluesTarget = data.CluesTarget;
            businessDataVo.CluesTargetCompleteRate = data.CluesTargetCompleteRate;
            businessDataVo.CluesChainRatio = data.CluesChainRatio;
            businessDataVo.CluesYearOnYear = data.CluesYearOnYear;
            businessDataVo.SendNum = data.SendNum;
            businessDataVo.SendNumToDateSchedule = data.SendNumToDateSchedule;
            businessDataVo.SendNumTarget = data.SendNumTarget;
            businessDataVo.SendNumTargetCompleteRate = data.SendNumTargetCompleteRate;
            businessDataVo.SendNumChainRatio = data.SendNumChainRatio;
            businessDataVo.SendNumYearOnYear = data.SendNumYearOnYear;
            return ResultData<BeforeLivingBusinessDataVo>.Success().AddData("data", businessDataVo);
        }
        /// <summary>
        /// 直播前业绩趋势图
        /// </summary>
        /// <param name="queryVo"></param>
        /// <returns></returns>
        [HttpGet("getBeforeLivingBrokenLineData")]
        public async Task<ResultData<BeforeLivingBrokenDataVo>> GetBeforeLivingBusinessBrokenLineDataAsync([FromQuery] QueryBeforeLivingBrokenLineDataVo queryVo)
        {
            QueryBeforeLivingBusinessDataDto queryDto = new QueryBeforeLivingBusinessDataDto();
            queryDto.BaseLiveAnchorId = queryVo.BaseLiveAnchorId;
            queryDto.Year = queryVo.Year;
            queryDto.Month = queryVo.Month;
            queryDto.ShowTikokData = queryVo.ShowTikTokData;
            queryDto.ShowWechatVideoData = queryVo.ShowWechatVideoData;
            queryDto.ShowXiaoHongShuData = queryVo.ShowXiaoHongShuData;
            var data = await newBusinessDashboardService.GetBeforeLivingBrokenLineDataAsync(queryDto);
            BeforeLivingBrokenDataVo beforeLivingBrokenDataVo = new BeforeLivingBrokenDataVo();
            beforeLivingBrokenDataVo.IncreaseFansData = data.IncreaseFansData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            beforeLivingBrokenDataVo.ShowcaseIncomeData = data.ShowcaseIncomeData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            beforeLivingBrokenDataVo.ShowcaseFeeDta = data.ShowcaseFeeDta.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            beforeLivingBrokenDataVo.IncreaseFansFeeData = data.IncreaseFansFeeData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            return ResultData<BeforeLivingBrokenDataVo>.Success().AddData("brokenLine", beforeLivingBrokenDataVo);
        }

        #endregion
        #region 直播中
        /// <summary>
        /// 获取直播中带货业绩数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getLivingBusinessData")]
        public async Task<ResultData<LivingBusinessDataVo>> GetLivingBusinessDataAsync([FromQuery] QueryLivingBusinessDataVo query)
        {
            LivingBusinessDataVo livingBusinessDataVo = new LivingBusinessDataVo();
            QueryLivingBusinessDataDto queryDto = new QueryLivingBusinessDataDto();
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            queryDto.Year = query.Year;
            queryDto.Month = query.Month;
            queryDto.ShowTikokData = query.ShowTikTokData;
            queryDto.ShowWechatVideoData = query.ShowWechatVideoData;
            var res = await newBusinessDashboardService.GetLivingBusinessDataAsync(queryDto);
            livingBusinessDataVo.OrderGMV = res.OrderGMV;
            livingBusinessDataVo.OrderGMVToDateSchedule = res.OrderGMVToDateSchedule;
            livingBusinessDataVo.OrderGMVTarget = res.OrderGMVTarget;
            livingBusinessDataVo.OrderGMVTargetCompleteRate = res.OrderGMVTargetCompleteRate;
            livingBusinessDataVo.OrderGMVChainRatio = res.OrderGMVChainRatio;
            livingBusinessDataVo.OrderGMVYearOnYear = res.OrderGMVYearOnYear;
            livingBusinessDataVo.RefundGMV = res.RefundGMV;
            livingBusinessDataVo.RefundGMVToDateSchedule = res.RefundGMVToDateSchedule;
            livingBusinessDataVo.RefundGMVTarget = res.RefundGMVTarget;
            livingBusinessDataVo.RefundGMVTargetCompleteRate = res.RefundGMVTargetCompleteRate;
            livingBusinessDataVo.RefundGMVChainRatio = res.RefundGMVChainRatio;
            livingBusinessDataVo.RefundGMVYearOnYear = res.RefundGMVYearOnYear;
            livingBusinessDataVo.ActualReturnBackMoney = res.ActualReturnBackMoney;
            livingBusinessDataVo.ActualReturnBackMoneyToDateSchedule = res.ActualReturnBackMoneyToDateSchedule;
            livingBusinessDataVo.ActualReturnBackMoneyTarget = res.ActualReturnBackMoneyTarget;
            livingBusinessDataVo.ActualReturnBackMoneyTargetCompleteRate = res.ActualReturnBackMoneyTargetCompleteRate;
            livingBusinessDataVo.ActualReturnBackMoneyChainRatio = res.ActualReturnBackMoneyChainRatio;
            livingBusinessDataVo.ActualReturnBackMoneyYearOnYear = res.ActualReturnBackMoneyYearOnYear;
            livingBusinessDataVo.InvestFlow = res.InvestFlow;
            livingBusinessDataVo.InvestFlowToDateSchedule = res.InvestFlowToDateSchedule;
            livingBusinessDataVo.InvestFlowTarget = res.InvestFlowTarget;
            livingBusinessDataVo.InvestFlowTargetCompleteRate = res.InvestFlowTargetCompleteRate;
            livingBusinessDataVo.InvestFlowChainRatio = res.InvestFlowChainRatio;
            livingBusinessDataVo.InvestFlowYearOnYear = res.InvestFlowYearOnYear;
            return ResultData<LivingBusinessDataVo>.Success().AddData("data", livingBusinessDataVo);
        }
        /// <summary>
        /// 直播中带货业绩趋势图
        /// </summary>
        /// <param name="queryVo"></param>
        /// <returns></returns>
        [HttpGet("getLivingBusinessBrokenLineData")]
        public async Task<ResultData<LivingBrokenDataVo>> GetLivingBusinessBrokenLineDataAsync([FromQuery] QueryLivingBrokenDataVo queryVo)
        {
            LivingBrokenDataVo livingBrokenDataVo = new LivingBrokenDataVo();
            QueryLivingBusinessDataDto queryDto = new QueryLivingBusinessDataDto();
            queryDto.Year = queryVo.Year;
            queryDto.BaseLiveAnchorId = queryVo.BaseLiveAnchorId;
            queryDto.ShowTikokData = queryVo.ShowTikTokData;
            queryDto.ShowWechatVideoData = queryVo.ShowWechatVideoData;
            var res = await newBusinessDashboardService.GetLivingBusinessBrokenDataAsync(queryDto);
            livingBrokenDataVo.OrderGMVData = res.OrderGMVData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            livingBrokenDataVo.RefundGMVData = res.RefundGMVData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            livingBrokenDataVo.ActualReturnBackMoneyData = res.ActualReturnBackMoneyData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            livingBrokenDataVo.InvestFlowData = res.InvestFlowData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            return ResultData<LivingBrokenDataVo>.Success().AddData("brokenData", livingBrokenDataVo);
        }
        /// <summary>
        /// 获取直播中医美业绩数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getLivingAestheticMedicineBusinessData")]
        public async Task<ResultData<LivingAestheticMedicineBusinessDataVo>> GetLivingAestheticMedicineBusinessDataAsync([FromQuery] QueryLivingBusinessDataVo query)
        {
            LivingAestheticMedicineBusinessDataVo livingBusinessDataVo = new LivingAestheticMedicineBusinessDataVo();
            QueryLivingBusinessDataDto queryDto = new QueryLivingBusinessDataDto();
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            queryDto.Year = query.Year;
            queryDto.Month = query.Month;
            queryDto.ShowTikokData = query.ShowTikTokData;
            queryDto.ShowWechatVideoData = query.ShowWechatVideoData;
            var res = await newBusinessDashboardService.GetAestheticMedicineBusinessDataAsync(queryDto);
            livingBusinessDataVo.DesignCardOrder = res.DesignCardOrder;
            livingBusinessDataVo.DesignCardOrderToDateSchedule = res.DesignCardOrderToDateSchedule;
            livingBusinessDataVo.DesignCardOrderTarget = res.DesignCardOrderTarget;
            livingBusinessDataVo.DesignCardOrderTargetCompleteRate = res.DesignCardOrderTargetCompleteRate;
            livingBusinessDataVo.DesignCardOrderChainRatio = res.DesignCardOrderChainRatio;
            livingBusinessDataVo.DesignCardOrderYearOnYear = res.DesignCardOrderYearOnYear;
            livingBusinessDataVo.DesignCardRefund = res.DesignCardRefund;
            livingBusinessDataVo.DesignCardRefundToDateSchedule = res.DesignCardRefundToDateSchedule;
            livingBusinessDataVo.DesignCardRefundTarget = res.DesignCardRefundTarget;
            livingBusinessDataVo.DesignCardRefundTargetCompleteRate = res.DesignCardRefundTargetCompleteRate;
            livingBusinessDataVo.DesignCardRefundChainRatio = res.DesignCardRefundChainRatio;
            livingBusinessDataVo.DesignCardRefundYearOnYear = res.DesignCardRefundYearOnYear;
            livingBusinessDataVo.DesignCardActual = res.DesignCardActual;
            livingBusinessDataVo.DesignCardActualToDateSchedule = res.DesignCardActualToDateSchedule;
            livingBusinessDataVo.DesignCardActualTarget = res.DesignCardActualTarget;
            livingBusinessDataVo.DesignCardActualTargetCompleteRate = res.DesignCardActualTargetCompleteRate;
            livingBusinessDataVo.DesignCardActualChainRatio = res.DesignCardActualChainRatio;
            livingBusinessDataVo.DesignCardActualYearOnYear = res.DesignCardActualYearOnYear;
            return ResultData<LivingAestheticMedicineBusinessDataVo>.Success().AddData("data", livingBusinessDataVo);
        }
        /// <summary>
        /// 直播中医美业绩趋势图
        /// </summary>
        /// <param name="queryVo"></param>
        /// <returns></returns>
        [HttpGet("getLivingAestheticMedicineBusinessBrokenLineData")]
        public async Task<ResultData<LivingAestheticMedicineBrokenDataVo>> GetLivingAestheticMedicineBusinessBrokenLineDataAsync([FromQuery] QueryLivingBrokenDataVo queryVo)
        {
            LivingAestheticMedicineBrokenDataVo livingBrokenDataVo = new LivingAestheticMedicineBrokenDataVo();
            QueryLivingBusinessDataDto queryDto = new QueryLivingBusinessDataDto();
            queryDto.Year = queryVo.Year;
            queryDto.BaseLiveAnchorId = queryVo.BaseLiveAnchorId;
            queryDto.ShowTikokData = queryVo.ShowTikTokData;
            queryDto.ShowWechatVideoData = queryVo.ShowWechatVideoData;
            var res = await newBusinessDashboardService.GetAestheticMedicineBusinessBrokenDataAsync(queryDto);
            livingBrokenDataVo.DesignCardOrderData = res.DesignCardOrderData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            livingBrokenDataVo.DesignCardRefundData = res.DesignCardRefundData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            livingBrokenDataVo.DesignCardActualData = res.DesignCardActualData.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            return ResultData<LivingAestheticMedicineBrokenDataVo>.Success().AddData("brokenData", livingBrokenDataVo);
        }
        #endregion
        #region 直播后

        /// <summary>
        /// 获取直播后业绩数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getAfterLivingBusinessData")]
        public async Task<ResultData<AfterLivingBusinessDataVo>> GetAfterLivingBusinessDataAsync([FromQuery] QueryAfterLivingBusinessDataVo query)
        {
            AfterLivingBusinessDataVo afterLivingBusinessData = new AfterLivingBusinessDataVo();
            QueryAfterLivingBusinessDataDto queryDto = new QueryAfterLivingBusinessDataDto();
            queryDto.Year = query.Year;
            queryDto.Month = query.Month;
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            queryDto.IsSelfLiveanchor = query.IsSelfLiveanchor;
            var res = await newBusinessDashboardService.GetAfterLivingBusinessDataAsync(queryDto);
            afterLivingBusinessData.TotalPerformance = res.TotalPerformance;
            afterLivingBusinessData.TotalPerformanceTarget = res.TotalPerformanceTarget;
            afterLivingBusinessData.TotalPerformanceCompleteRate = res.TotalPerformanceCompleteRate;
            afterLivingBusinessData.TotalPerformanceYearOnYear = res.TotalPerformanceYearOnYear;
            afterLivingBusinessData.TotalPerformanceChainRatio = res.TotalPerformanceChainRatio;
            afterLivingBusinessData.TotalPerformanceToDateSchedule = res.TotalPerformanceToDateSchedule;
            afterLivingBusinessData.NewCustomerPerformance = res.NewCustomerPerformance;
            afterLivingBusinessData.NewCustomerPerformanceTarget = res.NewCustomerPerformanceTarget;
            afterLivingBusinessData.NewCustomerPerformanceCompleteRate = res.NewCustomerPerformanceCompleteRate;
            afterLivingBusinessData.NewCustomerPerformanceYearOnYear = res.NewCustomerPerformanceYearOnYear;
            afterLivingBusinessData.NewCustomerPerformanceChainRatio = res.NewCustomerPerformanceChainRatio;
            afterLivingBusinessData.NewCustomerPerformanceToDateSchedule = res.NewCustomerPerformanceToDateSchedule;
            afterLivingBusinessData.OldCustomerPerformance = res.OldCustomerPerformance;
            afterLivingBusinessData.OldCustomerPerformanceTarget = res.OldCustomerPerformanceTarget;
            afterLivingBusinessData.OldCustomerPerformanceCompleteRate = res.OldCustomerPerformanceCompleteRate;
            afterLivingBusinessData.OldCustomerPerformanceYearOnYear = res.OldCustomerPerformanceYearOnYear;
            afterLivingBusinessData.OldCustomerPerformanceChainRatio = res.OldCustomerPerformanceChainRatio;
            afterLivingBusinessData.OldCustomerPerformanceToDateSchedule = res.OldCustomerPerformanceToDateSchedule;
            afterLivingBusinessData.EffectivePerformance = res.EffectivePerformance;
            afterLivingBusinessData.EffectivePerformanceTarget = res.EffectivePerformanceTarget;
            afterLivingBusinessData.EffectivePerformanceCompleteRate = res.EffectivePerformanceCompleteRate;
            afterLivingBusinessData.EffectivePerformanceYearOnYear = res.EffectivePerformanceYearOnYear;
            afterLivingBusinessData.EffectivePerformanceChainRatio = res.EffectivePerformanceChainRatio;
            afterLivingBusinessData.EffectivePerformanceToDateSchedule = res.EffectivePerformanceToDateSchedule;
            afterLivingBusinessData.PotentialPerformance = res.PotentialPerformance;
            afterLivingBusinessData.PotentialPerformanceTarget = res.PotentialPerformanceTarget;
            afterLivingBusinessData.PotentialPerformanceCompleteRate = res.PotentialPerformanceCompleteRate;
            afterLivingBusinessData.PotentialPerformanceYearOnYear = res.PotentialPerformanceYearOnYear;
            afterLivingBusinessData.PotentialPerformanceChainRatio = res.PotentialPerformanceChainRatio;
            afterLivingBusinessData.PotentialPerformanceToDateSchedule = res.PotentialPerformanceToDateSchedule;
            afterLivingBusinessData.NewCustomerEffectivePerformance = res.NewCustomerEffectivePerformance;
            afterLivingBusinessData.NewCustomerEffectivePerformanceChain = res.NewCustomerEffectivePerformanceChain;
            afterLivingBusinessData.NewCustomerEffectivePerformanceYearToYear = res.NewCustomerEffectivePerformanceYearToYear;
            afterLivingBusinessData.NewCustomerPotentialPerformance = res.NewCustomerPotentialPerformance;
            afterLivingBusinessData.NewCustomerPotentialPerformanceChain = res.NewCustomerPotentialPerformanceChain;
            afterLivingBusinessData.NewCustomerPotentialPerformanceYearToYear = res.NewCustomerPotentialPerformanceYearToYear;
            afterLivingBusinessData.OldCustomerEffectivePerformance = res.OldCustomerEffectivePerformance;
            afterLivingBusinessData.OldCustomerEffectivePerformanceChain = res.OldCustomerEffectivePerformanceChain;
            afterLivingBusinessData.OldCustomerEffectivePerformanceYearToYear = res.OldCustomerEffectivePerformanceYearToYear;
            afterLivingBusinessData.OldCustomerPotentialPerformance = res.OldCustomerPotentialPerformance;
            afterLivingBusinessData.OldCustomerPotentialPerformanceChain = res.OldCustomerPotentialPerformanceChain;
            afterLivingBusinessData.OldCustomerPotentialPerformanceYearToYear = res.OldCustomerPotentialPerformanceYearToYear;
            afterLivingBusinessData.NewCustomerPerformanceRate = res.NewCustomerPerformanceRate;
            afterLivingBusinessData.OldCustomerPerformanceRate = res.OldCustomerPerformanceRate;
            afterLivingBusinessData.EffectivePerformanceRate = res.EffectivePerformanceRate;
            afterLivingBusinessData.PotentialPerformanceRate = res.PotentialPerformanceRate;
            afterLivingBusinessData.NewCustomerEffectivePerformanceRate = res.NewCustomerEffectivePerformanceRate;
            afterLivingBusinessData.NewCustomerPotentialPerformanceRate = res.NewCustomerPotentialPerformanceRate;
            afterLivingBusinessData.OldCustomerEffectivePerformanceRate = res.OldCustomerEffectivePerformanceRate;
            afterLivingBusinessData.OldCustomerPotentialPerformanceRate = res.OldCustomerPotentialPerformanceRate;
            return ResultData<AfterLivingBusinessDataVo>.Success().AddData("data", afterLivingBusinessData);
        }
        /// <summary>
        /// 获取直播后业绩趋势图数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getAfterLivingBrokenData")]
        public async Task<ResultData<AfterLivingBrokenDataVo>> GetAfterLivingBrokenDataAsync([FromQuery] QueryAfterLivingBusinessDataVo query)
        {
            AfterLivingBrokenDataVo afterLivingBrokenDataVo = new AfterLivingBrokenDataVo();
            QueryAfterLivingBusinessDataDto queryDto = new QueryAfterLivingBusinessDataDto();
            queryDto.Year = query.Year;
            queryDto.Month = query.Month;
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            queryDto.IsSelfLiveanchor = query.IsSelfLiveanchor;
            var res = await newBusinessDashboardService.GetAfterLivingBrokenDataAsync(queryDto);
            afterLivingBrokenDataVo.TotalPerformanceBrokenLineList = res.TotalPerformanceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            afterLivingBrokenDataVo.NewCustomerPerformanceBrokenLineList = res.NewCustomerPerformanceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            afterLivingBrokenDataVo.OldCustomerPerformanceBrokenLineList = res.OldCustomerPerformanceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            afterLivingBrokenDataVo.EffectivePerformanceBrokenLineList = res.EffectivePerformanceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            afterLivingBrokenDataVo.PotentialPerformanceBrokenLineList = res.PotentialPerformanceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            afterLivingBrokenDataVo.NewCustomerEffectivePerformanceBrokenLineList = res.NewCustomerEffectivePerformanceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            afterLivingBrokenDataVo.NewCustomerPotentialPerformanceBrokenLineList = res.NewCustomerPotentialPerformanceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            afterLivingBrokenDataVo.OldCustomerEffectivePerformanceBrokenLineList = res.OldCustomerEffectivePerformanceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            afterLivingBrokenDataVo.OldCustomerPotentialPerformanceBrokenLineList = res.OldCustomerPotentialPerformanceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            return ResultData<AfterLivingBrokenDataVo>.Success().AddData("brokenData", afterLivingBrokenDataVo);
        }
        #endregion

    }
}
