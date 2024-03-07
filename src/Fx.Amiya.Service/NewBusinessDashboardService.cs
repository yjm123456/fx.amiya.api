using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.NewBusinessDashboard;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class NewBusinessDashboardService : INewBusinessDashboardService
    {
        private readonly ILiveAnchorMonthlyTargetBeforeLivingService liveAnchorMonthlyTargetBeforeLivingService;
        private readonly ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService;
        private readonly IDalBeforeLivingTikTokDailyTarget dalBeforeLivingTikTokDailyTarget;
        private readonly IDalBeforeLivingVideoDailyTarget dalBeforeLivingVideoDailyTarget;
        private readonly IDalBeforeLivingXiaoHongShuDailyTarget dalBeforeLivingXiaoHongShuDailyTarget;
        private readonly IDalLivingDailyTarget dalLivingDailyTarget;
        private readonly ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService;
        private readonly ILiveAnchorService liveAnchorService;

        public NewBusinessDashboardService(ILiveAnchorMonthlyTargetBeforeLivingService liveAnchorMonthlyTargetBeforeLivingService, IDalBeforeLivingTikTokDailyTarget dalBeforeLivingTikTokDailyTarget, IDalBeforeLivingVideoDailyTarget dalBeforeLivingVideoDailyTarget, IDalBeforeLivingXiaoHongShuDailyTarget dalBeforeLivingXiaoHongShuDailyTarget, ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService, IDalLivingDailyTarget dalLivingDailyTarget, ILiveAnchorBaseInfoService liveAnchorBaseInfoService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService, ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService, ILiveAnchorService liveAnchorService)
        {
            this.liveAnchorMonthlyTargetBeforeLivingService = liveAnchorMonthlyTargetBeforeLivingService;
            this.dalBeforeLivingTikTokDailyTarget = dalBeforeLivingTikTokDailyTarget;
            this.dalBeforeLivingVideoDailyTarget = dalBeforeLivingVideoDailyTarget;
            this.dalBeforeLivingXiaoHongShuDailyTarget = dalBeforeLivingXiaoHongShuDailyTarget;
            this.liveAnchorMonthlyTargetLivingService = liveAnchorMonthlyTargetLivingService;
            this.dalLivingDailyTarget = dalLivingDailyTarget;
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.liveAnchorMonthlyTargetAfterLivingService = liveAnchorMonthlyTargetAfterLivingService;
            this.liveAnchorService = liveAnchorService;
        }
        #region 直播前

        /// <summary>
        /// 获取直播前业绩看板数据
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<BeforeLivingBusinessDataDto> GetBeforeLivingBussinessDataAsync(QueryBeforeLivingBusinessDataDto queryDto)
        {
            BeforeLivingBusinessDataDto beforeLivingBusinessDataDto = new BeforeLivingBusinessDataDto();
            if (!(queryDto.ShowTikokData || queryDto.ShowWechatVideoData || queryDto.ShowXiaoHongShuData))
            {
                return beforeLivingBusinessDataDto;
            }
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(queryDto.Year, queryDto.Month == 0 ? 1 : queryDto.Month);
            var target = await liveAnchorMonthlyTargetBeforeLivingService.GetBeforeLivingTargetByYearAndMonthAsync(queryDto);
            if (target == null) return new BeforeLivingBusinessDataDto();
            var lastMonthData = await GetBeforeLivingBusinessDataByDateAsync(queryDto.BaseLiveAnchorId, sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, queryDto.ShowTikokData, queryDto.ShowWechatVideoData, queryDto.ShowXiaoHongShuData);
            var thisMonthData = await GetBeforeLivingBusinessDataByDateAsync(queryDto.BaseLiveAnchorId, sequentialDate.StartDate, sequentialDate.EndDate, queryDto.ShowTikokData, queryDto.ShowWechatVideoData, queryDto.ShowXiaoHongShuData);
            var lastYearData = await GetBeforeLivingBusinessDataByDateAsync(queryDto.BaseLiveAnchorId, sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, queryDto.ShowTikokData, queryDto.ShowWechatVideoData, queryDto.ShowXiaoHongShuData);
            beforeLivingBusinessDataDto.IncreaseFans = thisMonthData.IncreaseFans;
            beforeLivingBusinessDataDto.IncreaseFansToDateSchedule = CalculateSchedule(target.IncreaseFansTarget, thisMonthData.IncreaseFans, queryDto.Year, queryDto.Month);
            beforeLivingBusinessDataDto.IncreaseFansTarget = target.IncreaseFansTarget;
            beforeLivingBusinessDataDto.IncreaseFansTargetCompleteRate = CalculateTargetComplete(thisMonthData.IncreaseFans, target.IncreaseFansTarget);
            beforeLivingBusinessDataDto.IncreaseFansChainRatio = CalculateChainratio(thisMonthData.IncreaseFans, lastMonthData.IncreaseFans);
            beforeLivingBusinessDataDto.IncreaseFansYearOnYear = CalculateYearOnYear(thisMonthData.IncreaseFans, lastYearData.IncreaseFans);
            beforeLivingBusinessDataDto.IncreaseFansFees = thisMonthData.IncreaseFansFees;
            beforeLivingBusinessDataDto.IncreaseFansFeesToDateSchedule = CalculateSchedule(target.IncreaseFansFeesTarget, thisMonthData.IncreaseFansFees, queryDto.Year, queryDto.Month);
            beforeLivingBusinessDataDto.IncreaseFansFeesTarget = target.IncreaseFansFeesTarget;
            beforeLivingBusinessDataDto.IncreaseFansFeesTargetCompleteRate = CalculateTargetComplete(thisMonthData.IncreaseFansFees, target.IncreaseFansFeesTarget);
            beforeLivingBusinessDataDto.IncreaseFansFeesChainRatio = CalculateChainratio(thisMonthData.IncreaseFansFees, lastMonthData.IncreaseFansFees);
            beforeLivingBusinessDataDto.IncreaseFansFeesYearOnYear = CalculateYearOnYear(thisMonthData.IncreaseFansFees, lastYearData.IncreaseFansFees);
            beforeLivingBusinessDataDto.IncreaseFansFeesCostToDateSchedule = CalculateSchedule(target.IncreaseFansFeesCostTarget, thisMonthData.IncreaseFansFeesCost, queryDto.Year, queryDto.Month);
            beforeLivingBusinessDataDto.IncreaseFansFeesCostTarget = target.IncreaseFansFeesCostTarget;
            beforeLivingBusinessDataDto.IncreaseFansFeesCostTargetCompleteRate = CalculateTargetComplete(thisMonthData.IncreaseFansFeesCost, target.IncreaseFansFeesCostTarget);
            beforeLivingBusinessDataDto.IncreaseFansFeesCostChainRatio = CalculateChainratio(thisMonthData.IncreaseFansFeesCost, lastMonthData.IncreaseFansFeesCostTarget);
            beforeLivingBusinessDataDto.IncreaseFansFeesCostYearOnYear = CalculateYearOnYear(thisMonthData.IncreaseFansFeesCost, lastYearData.IncreaseFansFeesCostTarget);
            beforeLivingBusinessDataDto.ShowcaseIncome = thisMonthData.ShowcaseIncome;
            beforeLivingBusinessDataDto.ShowcaseIncomeToDateSchedule = CalculateSchedule(target.ShowcaseIncomeTarget, thisMonthData.ShowcaseIncome, queryDto.Year, queryDto.Month);
            beforeLivingBusinessDataDto.ShowcaseIncomeTarget = target.ShowcaseIncomeTarget;
            beforeLivingBusinessDataDto.ShowcaseIncomeTargetCompleteRate = CalculateTargetComplete(thisMonthData.ShowcaseIncome, target.ShowcaseIncomeTarget);
            beforeLivingBusinessDataDto.ShowcaseIncomeChainRatio = CalculateChainratio(thisMonthData.ShowcaseIncome, lastMonthData.ShowcaseIncome);
            beforeLivingBusinessDataDto.ShowcaseIncomeYearOnYear = CalculateYearOnYear(thisMonthData.ShowcaseIncome, lastYearData.ShowcaseIncome);
            beforeLivingBusinessDataDto.ShowcaseFee = thisMonthData.ShowcaseFee;
            beforeLivingBusinessDataDto.ShowcaseFeeToDateSchedule = CalculateSchedule(target.ShowcaseFeeTarget, thisMonthData.ShowcaseFee, queryDto.Year, queryDto.Month); ;
            beforeLivingBusinessDataDto.ShowcaseFeeTarget = target.ShowcaseFeeTarget;
            beforeLivingBusinessDataDto.ShowcaseFeeTargetCompleteRate = CalculateTargetComplete(thisMonthData.ShowcaseFee, target.ShowcaseFeeTarget);
            beforeLivingBusinessDataDto.ShowcaseFeeChainRatio = CalculateChainratio(thisMonthData.ShowcaseFee, lastMonthData.ShowcaseFee);
            beforeLivingBusinessDataDto.ShowcaseFeeYearOnYear = CalculateYearOnYear(thisMonthData.ShowcaseFee, lastYearData.ShowcaseFee); ;
            beforeLivingBusinessDataDto.Clues = thisMonthData.Clues;
            beforeLivingBusinessDataDto.CluesToDateSchedule = CalculateSchedule(target.CluesTarget, thisMonthData.Clues, queryDto.Year, queryDto.Month);
            beforeLivingBusinessDataDto.CluesTarget = target.CluesTarget;
            beforeLivingBusinessDataDto.CluesTargetCompleteRate = CalculateTargetComplete(thisMonthData.Clues, target.CluesTarget);
            beforeLivingBusinessDataDto.CluesChainRatio = CalculateChainratio(thisMonthData.Clues, lastMonthData.Clues);
            beforeLivingBusinessDataDto.CluesYearOnYear = CalculateYearOnYear(thisMonthData.Clues, lastYearData.Clues);
            beforeLivingBusinessDataDto.SendNum = thisMonthData.SendNum;
            beforeLivingBusinessDataDto.SendNumToDateSchedule = CalculateSchedule(target.SendNumTarget, thisMonthData.SendNum, queryDto.Year, queryDto.Month);
            beforeLivingBusinessDataDto.SendNumTarget = target.SendNumTarget;
            beforeLivingBusinessDataDto.SendNumTargetCompleteRate = CalculateTargetComplete(thisMonthData.SendNum, target.SendNumTarget);
            beforeLivingBusinessDataDto.SendNumChainRatio = CalculateChainratio(thisMonthData.SendNum, lastMonthData.SendNum);
            beforeLivingBusinessDataDto.SendNumYearOnYear = CalculateYearOnYear(thisMonthData.SendNum, lastYearData.SendNum);
            return beforeLivingBusinessDataDto;
        }
        /// <summary>
        /// 获取直播前业绩趋势图
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<BeforeLivingBrokenDataDto> GetBeforeLivingBrokenLineDataAsync(QueryBeforeLivingBusinessDataDto queryDto)
        {

            BeforeLivingBrokenDataDto beforeLivingBrokenDataDto = new BeforeLivingBrokenDataDto();
            List<BeforeLivingBrokenDataItemDto> dataList = new List<BeforeLivingBrokenDataItemDto>();

            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(queryDto.Year, queryDto.Month == 0 ? 1 : queryDto.Month);
            if (queryDto.ShowTikokData)
            {
                var res = dalBeforeLivingTikTokDailyTarget.GetAll().Where(e => e.RecordDate >= sequentialDate.StartDate && e.RecordDate < sequentialDate.EndDate && e.Valid == true).Select(e => new BeforeLivingBrokenDataItemDto
                {
                    IncreaseFans = e.TikTokIncreaseFans,
                    IncreaseFansFees = e.TikTokIncreaseFansFees,
                    ShowcaseIncome = e.TikTokShowcaseIncome,
                    ShowcaseFee = e.TikTokShowCaseFee,
                    Clues = e.TikTokClues,
                    SendNum = e.SendNum,
                    Time = e.RecordDate.Day.ToString(),
                    BaseLiveAnchorId = e.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.LiveAnchorBaseId
                });
                if (!string.IsNullOrEmpty(queryDto.BaseLiveAnchorId))
                {
                    res = res.Where(e => e.BaseLiveAnchorId == queryDto.BaseLiveAnchorId);
                }
                dataList.AddRange(res.ToList());

            }
            if (queryDto.ShowWechatVideoData)
            {
                var res = dalBeforeLivingVideoDailyTarget.GetAll().Where(e => e.RecordDate >= sequentialDate.StartDate && e.RecordDate < sequentialDate.EndDate && e.Valid == true).Select(e => new BeforeLivingBrokenDataItemDto
                {
                    IncreaseFans = e.VideoIncreaseFans,
                    IncreaseFansFees = e.VideoIncreaseFansFees,
                    ShowcaseIncome = e.VideoShowcaseIncome,
                    ShowcaseFee = e.VideoShowCaseFee,
                    Clues = e.VideoClues,
                    SendNum = e.SendNum,
                    Time = e.RecordDate.Day.ToString(),
                    BaseLiveAnchorId = e.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.LiveAnchorBaseId
                });
                if (!string.IsNullOrEmpty(queryDto.BaseLiveAnchorId))
                {
                    res = res.Where(e => e.BaseLiveAnchorId == queryDto.BaseLiveAnchorId);
                }
                dataList.AddRange(res.ToList());
            }
            if (queryDto.ShowXiaoHongShuData)
            {
                var res = dalBeforeLivingXiaoHongShuDailyTarget.GetAll().Where(e => e.RecordDate >= sequentialDate.StartDate && e.RecordDate < sequentialDate.EndDate && e.Valid == true).Select(e => new BeforeLivingBrokenDataItemDto
                {
                    IncreaseFans = e.XiaoHongShuIncreaseFans,
                    IncreaseFansFees = e.XiaoHongShuIncreaseFansFees,
                    ShowcaseIncome = e.XiaoHongShuShowcaseIncome,
                    ShowcaseFee = e.XiaoHongShuShowCaseFee,
                    Clues = e.XiaoHongShuClues,
                    SendNum = e.SendNum,
                    Time = e.RecordDate.Day.ToString(),
                    BaseLiveAnchorId = e.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.LiveAnchorBaseId
                }); ;
                if (!string.IsNullOrEmpty(queryDto.BaseLiveAnchorId))
                {
                    res = res.Where(e => e.BaseLiveAnchorId == queryDto.BaseLiveAnchorId);
                }
                dataList.AddRange(res.ToList());
            }
            dataList = dataList.GroupBy(e => e.Time).Select(e => new BeforeLivingBrokenDataItemDto
            {
                Time = e.Key,
                IncreaseFans = e.Sum(e => e.IncreaseFans),
                IncreaseFansFees = e.Sum(e => e.IncreaseFansFees),
                ShowcaseIncome = e.Sum(e => e.ShowcaseIncome),
                ShowcaseFee = e.Sum(e => e.ShowcaseFee)
            }).ToList();
            dataList = this.FillDate(queryDto.Year, queryDto.Month, dataList);
            beforeLivingBrokenDataDto.IncreaseFansData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.IncreaseFans)
            }).ToList();
            beforeLivingBrokenDataDto.IncreaseFansFeeData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.IncreaseFansFees)
            }).ToList();
            beforeLivingBrokenDataDto.ShowcaseIncomeData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.ShowcaseIncome)
            }).ToList();
            beforeLivingBrokenDataDto.ShowcaseFeeDta = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.ShowcaseFee)
            }).ToList();
            return beforeLivingBrokenDataDto;
        }
        /// <summary>
        /// 根据时间获取直播前运营数据
        /// </summary>
        /// <param name="baseLiveAnchorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="showTikTokData"></param>
        /// <param name="showWechatvideoData"></param>
        /// <param name="showXiaoHongShuData"></param>
        /// <returns></returns>
        private async Task<BeforeLivingBusinessDataDto> GetBeforeLivingBusinessDataByDateAsync(string baseLiveAnchorId, DateTime startDate, DateTime endDate, bool showTikTokData, bool showWechatvideoData, bool showXiaoHongShuData)
        {
            BeforeLivingBusinessDataDto beforeLivingBusinessDataDto = new BeforeLivingBusinessDataDto();
            if (showTikTokData)
            {
                var res = dalBeforeLivingTikTokDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.Valid == true);
                if (!string.IsNullOrEmpty(baseLiveAnchorId))
                {
                    res = res.Where(e => e.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.LiveAnchorBaseId == baseLiveAnchorId);
                }
                beforeLivingBusinessDataDto.IncreaseFans += res.Sum(e => e.TikTokIncreaseFans);
                beforeLivingBusinessDataDto.IncreaseFansFees += res.Sum(e => e.TikTokIncreaseFansFees);
                beforeLivingBusinessDataDto.ShowcaseIncome += res.Sum(e => e.TikTokShowcaseIncome);
                beforeLivingBusinessDataDto.ShowcaseFee += res.Sum(e => e.TikTokShowCaseFee);
                beforeLivingBusinessDataDto.Clues += res.Sum(e => e.TikTokClues);
                beforeLivingBusinessDataDto.SendNum += res.Sum(e => e.SendNum);
            }
            if (showWechatvideoData)
            {
                var res = dalBeforeLivingVideoDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.Valid == true);
                if (!string.IsNullOrEmpty(baseLiveAnchorId))
                {
                    res = res.Where(e => e.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.LiveAnchorBaseId == baseLiveAnchorId);
                }
                beforeLivingBusinessDataDto.IncreaseFans += res.Sum(e => e.VideoIncreaseFans);
                beforeLivingBusinessDataDto.IncreaseFansFees += res.Sum(e => e.VideoIncreaseFansFees);
                beforeLivingBusinessDataDto.ShowcaseIncome += res.Sum(e => e.VideoShowcaseIncome);
                beforeLivingBusinessDataDto.ShowcaseFee += res.Sum(e => e.VideoShowCaseFee);
                beforeLivingBusinessDataDto.Clues += res.Sum(e => e.VideoClues);
                beforeLivingBusinessDataDto.SendNum += res.Sum(e => e.SendNum);
            }
            if (showXiaoHongShuData)
            {
                var res = dalBeforeLivingXiaoHongShuDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.Valid == true);
                if (!string.IsNullOrEmpty(baseLiveAnchorId))
                {
                    res = res.Where(e => e.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.LiveAnchorBaseId == baseLiveAnchorId);
                }
                beforeLivingBusinessDataDto.IncreaseFans += res.Sum(e => e.XiaoHongShuIncreaseFans);
                beforeLivingBusinessDataDto.IncreaseFansFees += res.Sum(e => e.XiaoHongShuIncreaseFansFees);
                beforeLivingBusinessDataDto.ShowcaseIncome += res.Sum(e => e.XiaoHongShuShowcaseIncome);
                beforeLivingBusinessDataDto.ShowcaseFee += res.Sum(e => e.XiaoHongShuShowCaseFee);
                beforeLivingBusinessDataDto.Clues += res.Sum(e => e.XiaoHongShuClues);
                beforeLivingBusinessDataDto.SendNum += res.Sum(e => e.SendNum);
            }
            return beforeLivingBusinessDataDto;
        }
        #endregion
        #region 直播中
        public async Task<LivingBusinessDataDto> GetLivingBusinessDataAsync(QueryLivingBusinessDataDto queryDto)
        {
            LivingBusinessDataDto livingBusinessDataDto = new LivingBusinessDataDto();
            if (!(queryDto.ShowTikokData || queryDto.ShowWechatVideoData))
            {
                return livingBusinessDataDto;
            }
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(queryDto.Year, queryDto.Month == 0 ? 1 : queryDto.Month);
            var target = await liveAnchorMonthlyTargetLivingService.GetTargetAsync(queryDto);
            if (target == null) return new LivingBusinessDataDto();
            var lastMonthData = await GetLivingBusinessDataByDateAsync(queryDto.BaseLiveAnchorId, sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, queryDto.ShowTikokData, queryDto.ShowWechatVideoData);
            var thisMonthData = await GetLivingBusinessDataByDateAsync(queryDto.BaseLiveAnchorId, sequentialDate.StartDate, sequentialDate.EndDate, queryDto.ShowTikokData, queryDto.ShowWechatVideoData);
            var lastYearData = await GetLivingBusinessDataByDateAsync(queryDto.BaseLiveAnchorId, sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, queryDto.ShowTikokData, queryDto.ShowWechatVideoData);
            livingBusinessDataDto.OrderGMV = thisMonthData.OrderGMV;
            livingBusinessDataDto.OrderGMVToDateSchedule = CalculateSchedule(target.OrderGMVTarget, thisMonthData.OrderGMV, queryDto.Year, queryDto.Month);
            livingBusinessDataDto.OrderGMVTarget = target.OrderGMVTarget;
            livingBusinessDataDto.OrderGMVTargetCompleteRate = CalculateTargetComplete(thisMonthData.OrderGMV, target.OrderGMVTarget);
            livingBusinessDataDto.OrderGMVChainRatio = CalculateChainratio(thisMonthData.OrderGMV, lastMonthData.OrderGMV);
            livingBusinessDataDto.OrderGMVYearOnYear = CalculateYearOnYear(thisMonthData.OrderGMV, lastYearData.OrderGMV);
            livingBusinessDataDto.RefundGMV = thisMonthData.RefundGMV;
            livingBusinessDataDto.RefundGMVToDateSchedule = CalculateSchedule(target.RefundGMVTarget, thisMonthData.RefundGMV, queryDto.Year, queryDto.Month);
            livingBusinessDataDto.RefundGMVTarget = target.RefundGMVTarget;
            livingBusinessDataDto.RefundGMVTargetCompleteRate = CalculateTargetComplete(thisMonthData.RefundGMV, target.RefundGMVTarget);
            livingBusinessDataDto.RefundGMVChainRatio = CalculateChainratio(thisMonthData.RefundGMV, lastMonthData.RefundGMV);
            livingBusinessDataDto.RefundGMVYearOnYear = CalculateYearOnYear(thisMonthData.RefundGMV, lastYearData.RefundGMV);
            livingBusinessDataDto.ActualReturnBackMoney = thisMonthData.ActualReturnBackMoney;
            livingBusinessDataDto.ActualReturnBackMoneyToDateSchedule = CalculateSchedule(target.ActualReturnBackMoneyTarget, thisMonthData.ActualReturnBackMoney, queryDto.Year, queryDto.Month);
            livingBusinessDataDto.ActualReturnBackMoneyTarget = target.ActualReturnBackMoneyTarget;
            livingBusinessDataDto.ActualReturnBackMoneyTargetCompleteRate = CalculateTargetComplete(thisMonthData.ActualReturnBackMoney, target.ActualReturnBackMoneyTarget);
            livingBusinessDataDto.ActualReturnBackMoneyChainRatio = CalculateChainratio(thisMonthData.ActualReturnBackMoney, lastMonthData.ActualReturnBackMoney);
            livingBusinessDataDto.ActualReturnBackMoneyYearOnYear = CalculateYearOnYear(thisMonthData.ActualReturnBackMoney, lastYearData.ActualReturnBackMoney);
            livingBusinessDataDto.InvestFlow = thisMonthData.InvestFlow;
            livingBusinessDataDto.InvestFlowToDateSchedule = CalculateSchedule(target.InvestFlowTarget, thisMonthData.InvestFlow, queryDto.Year, queryDto.Month);
            livingBusinessDataDto.InvestFlowTarget = target.InvestFlowTarget;
            livingBusinessDataDto.InvestFlowTargetCompleteRate = CalculateTargetComplete(thisMonthData.InvestFlow, target.InvestFlowTarget);
            livingBusinessDataDto.InvestFlowChainRatio = CalculateChainratio(thisMonthData.InvestFlow, lastMonthData.InvestFlow);
            livingBusinessDataDto.InvestFlowYearOnYear = CalculateYearOnYear(thisMonthData.InvestFlow, lastYearData.InvestFlow);
            return livingBusinessDataDto;


        }
        /// <summary>
        /// 获取直播中带货数据
        /// </summary>
        /// <param name="baseLiveAnchorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="showTikTokData"></param>
        /// <param name="showWechatVideoData"></param>
        /// <returns></returns>
        private async Task<LivingBusinessDataDto> GetLivingBusinessDataByDateAsync(string baseLiveAnchorId, DateTime startDate, DateTime endDate, bool showTikTokData, bool showWechatVideoData)
        {
            LivingBusinessDataDto livingBusinessDataDto = new LivingBusinessDataDto();
            if (showTikTokData)
            {
                var res = dalLivingDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.LiveAnchorMonthlyTargetLiving.LiveAnchor.ContentPlateFormId == "4e4e9564-f6c3-47b6-a7da-e4518bab66a1" && e.Valid == true);
                if (!string.IsNullOrEmpty(baseLiveAnchorId))
                {
                    res = res.Where(e => e.LiveAnchorMonthlyTargetLiving.LiveAnchor.LiveAnchorBaseId == baseLiveAnchorId);
                }
                livingBusinessDataDto.OrderGMV += res.Sum(e => e.EliminateCardGMV);
                livingBusinessDataDto.RefundGMV += res.Sum(e => e.RefundGMV);
                livingBusinessDataDto.ActualReturnBackMoney += 0;
                livingBusinessDataDto.InvestFlow += res.Sum(e => e.QianChuanNum) + res.Sum(e => e.TikTokPlusNum) + res.Sum(e => e.ShuiXinTuiNum);

            }
            if (showWechatVideoData)
            {
                var res = dalLivingDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.LiveAnchorMonthlyTargetLiving.LiveAnchor.ContentPlateFormId == "9196b247-1ab9-4d0c-a11e-a1ef09019878" && e.Valid == true);
                if (!string.IsNullOrEmpty(baseLiveAnchorId))
                {
                    res = res.Where(e => e.LiveAnchorMonthlyTargetLiving.LiveAnchor.LiveAnchorBaseId == baseLiveAnchorId);
                }
                livingBusinessDataDto.OrderGMV += res.Sum(e => e.EliminateCardGMV);
                livingBusinessDataDto.RefundGMV += res.Sum(e => e.RefundGMV);
                livingBusinessDataDto.ActualReturnBackMoney += 0;
                livingBusinessDataDto.InvestFlow += res.Sum(e => e.WeiXinDou);
            }

            return livingBusinessDataDto;
        }

        /// <summary>
        /// 获取直播中带货业绩趋势图
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<LivingBrokenDataDto> GetLivingBusinessBrokenDataAsync(QueryLivingBusinessDataDto queryDto)
        {
            LivingBrokenDataDto livingBrokenDataDto = new LivingBrokenDataDto();
            List<LivingBrokenDataItemDto> dataList = new List<LivingBrokenDataItemDto>();
            var startDate = new DateTime(queryDto.Year, 1, 1);
            var endDate = startDate.AddYears(1);
            if (queryDto.ShowTikokData)
            {
                var res = dalLivingDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.LiveAnchorMonthlyTargetLiving.LiveAnchor.ContentPlateFormId == "4e4e9564-f6c3-47b6-a7da-e4518bab66a1" && e.Valid == true).Select(e => new LivingBrokenDataItemDto
                {
                    OrderGMV = e.EliminateCardGMV,
                    RefundGMV = e.RefundGMV,
                    ActualReturnBackMoney = 0,
                    InvestFlow = e.TikTokPlusNum + e.QianChuanNum + e.ShuiXinTuiNum,
                    Time = e.RecordDate.Month.ToString(),
                    BaseLiveAnchorId = e.LiveAnchorMonthlyTargetLiving.LiveAnchor.LiveAnchorBaseId
                });
                if (!string.IsNullOrEmpty(queryDto.BaseLiveAnchorId))
                {
                    res = res.Where(e => e.BaseLiveAnchorId == queryDto.BaseLiveAnchorId);
                }
                dataList.AddRange(res.ToList());

            }
            if (queryDto.ShowWechatVideoData)
            {
                var res = dalLivingDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.LiveAnchorMonthlyTargetLiving.LiveAnchor.ContentPlateFormId == "9196b247-1ab9-4d0c-a11e-a1ef09019878" && e.Valid == true).Select(e => new LivingBrokenDataItemDto
                {
                    OrderGMV = e.EliminateCardGMV,
                    RefundGMV = e.RefundGMV,
                    ActualReturnBackMoney = 0,
                    InvestFlow = e.WeiXinDou,
                    Time = e.RecordDate.Month.ToString(),
                    BaseLiveAnchorId = e.LiveAnchorMonthlyTargetLiving.LiveAnchor.LiveAnchorBaseId
                });
                if (!string.IsNullOrEmpty(queryDto.BaseLiveAnchorId))
                {
                    res = res.Where(e => e.BaseLiveAnchorId == queryDto.BaseLiveAnchorId);
                }
                dataList.AddRange(res.ToList());
            }

            dataList = dataList.GroupBy(e => e.Time).Select(e => new LivingBrokenDataItemDto
            {
                Time = e.Key,
                OrderGMV = e.Sum(e => e.OrderGMV),
                RefundGMV = e.Sum(e => e.RefundGMV),
                ActualReturnBackMoney = e.Sum(e => e.ActualReturnBackMoney),
                InvestFlow = e.Sum(e => e.InvestFlow)
            }).ToList();
            dataList = this.FillLivingDate(queryDto.Year, queryDto.Month, dataList);
            livingBrokenDataDto.OrderGMVData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.OrderGMV)
            }).ToList();
            livingBrokenDataDto.RefundGMVData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.RefundGMV)
            }).ToList();
            livingBrokenDataDto.ActualReturnBackMoneyData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.ActualReturnBackMoney)
            }).ToList();
            livingBrokenDataDto.InvestFlowData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.InvestFlow)
            }).ToList();
            return livingBrokenDataDto;
        }

        public async Task<LivingAestheticMedicineBusinessDataDto> GetAestheticMedicineBusinessDataAsync(QueryLivingBusinessDataDto queryDto)
        {
            LivingAestheticMedicineBusinessDataDto livingAestheticMedicineBusinessDataDto = new LivingAestheticMedicineBusinessDataDto();
            if (!(queryDto.ShowTikokData || queryDto.ShowWechatVideoData))
            {
                return livingAestheticMedicineBusinessDataDto;
            }
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(queryDto.Year, queryDto.Month == 0 ? 1 : queryDto.Month);
            var target = await liveAnchorMonthlyTargetLivingService.GetTargetAsync(queryDto);
            if (target == null) return new LivingAestheticMedicineBusinessDataDto();
            var lastMonthData = await GetLivingAestheticMedicineBusinessDataByDateAsync(queryDto.BaseLiveAnchorId, sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, queryDto.ShowTikokData, queryDto.ShowWechatVideoData);
            var thisMonthData = await GetLivingAestheticMedicineBusinessDataByDateAsync(queryDto.BaseLiveAnchorId, sequentialDate.StartDate, sequentialDate.EndDate, queryDto.ShowTikokData, queryDto.ShowWechatVideoData);
            var lastYearData = await GetLivingAestheticMedicineBusinessDataByDateAsync(queryDto.BaseLiveAnchorId, sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, queryDto.ShowTikokData, queryDto.ShowWechatVideoData);
            livingAestheticMedicineBusinessDataDto.DesignCardOrder = thisMonthData.DesignCardOrder;
            livingAestheticMedicineBusinessDataDto.DesignCardOrderToDateSchedule = CalculateSchedule(target.DesignCardOrderTarget, thisMonthData.DesignCardOrder, queryDto.Year, queryDto.Month);
            livingAestheticMedicineBusinessDataDto.DesignCardOrderTarget = target.DesignCardOrderTarget;
            livingAestheticMedicineBusinessDataDto.DesignCardOrderTargetCompleteRate = CalculateTargetComplete(thisMonthData.DesignCardOrder, target.DesignCardOrderTarget);
            livingAestheticMedicineBusinessDataDto.DesignCardOrderChainRatio = CalculateChainratio(thisMonthData.DesignCardOrder, lastMonthData.DesignCardOrder);
            livingAestheticMedicineBusinessDataDto.DesignCardOrderYearOnYear = CalculateYearOnYear(thisMonthData.DesignCardOrder, lastYearData.DesignCardOrder);
            livingAestheticMedicineBusinessDataDto.DesignCardRefund = thisMonthData.DesignCardRefund;
            livingAestheticMedicineBusinessDataDto.DesignCardRefundToDateSchedule = CalculateSchedule(target.DesignCardRefundTarget, thisMonthData.DesignCardRefund, queryDto.Year, queryDto.Month);
            livingAestheticMedicineBusinessDataDto.DesignCardRefundTarget = target.DesignCardRefundTarget;
            livingAestheticMedicineBusinessDataDto.DesignCardRefundTargetCompleteRate = CalculateTargetComplete(thisMonthData.DesignCardRefund, target.DesignCardRefundTarget);
            livingAestheticMedicineBusinessDataDto.DesignCardRefundChainRatio = CalculateChainratio(thisMonthData.DesignCardRefund, lastMonthData.DesignCardRefund);
            livingAestheticMedicineBusinessDataDto.DesignCardRefundYearOnYear = CalculateYearOnYear(thisMonthData.DesignCardRefund, lastYearData.DesignCardRefund);
            livingAestheticMedicineBusinessDataDto.DesignCardActual = thisMonthData.DesignCardActual;
            livingAestheticMedicineBusinessDataDto.DesignCardActualToDateSchedule = CalculateSchedule(target.DesignCardOrderTarget - target.DesignCardRefundTarget, thisMonthData.DesignCardActual, queryDto.Year, queryDto.Month);
            livingAestheticMedicineBusinessDataDto.DesignCardActualTarget = target.DesignCardOrderTarget - target.DesignCardRefundTarget;
            livingAestheticMedicineBusinessDataDto.DesignCardActualTargetCompleteRate = CalculateTargetComplete(thisMonthData.DesignCardActual, livingAestheticMedicineBusinessDataDto.DesignCardActualTarget);
            livingAestheticMedicineBusinessDataDto.DesignCardActualChainRatio = CalculateChainratio(thisMonthData.DesignCardActual, lastMonthData.DesignCardActual);
            livingAestheticMedicineBusinessDataDto.DesignCardActualYearOnYear = CalculateYearOnYear(thisMonthData.DesignCardActual, lastYearData.DesignCardActual);
            return livingAestheticMedicineBusinessDataDto;
        }
        /// <summary>
        /// 获取直播中医美数据
        /// </summary>
        /// <param name="baseLiveAnchorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="showTikTokData"></param>
        /// <param name="showWechatVideoData"></param>
        /// <returns></returns>
        private async Task<LivingAestheticMedicineBusinessDataDto> GetLivingAestheticMedicineBusinessDataByDateAsync(string baseLiveAnchorId, DateTime startDate, DateTime endDate, bool showTikTokData, bool showWechatVideoData)
        {
            LivingAestheticMedicineBusinessDataDto livingBusinessDataDto = new LivingAestheticMedicineBusinessDataDto();
            if (showTikTokData)
            {
                var res = dalLivingDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.LiveAnchorMonthlyTargetLiving.LiveAnchor.ContentPlateFormId == "4e4e9564-f6c3-47b6-a7da-e4518bab66a1" && e.Valid == true);
                if (!string.IsNullOrEmpty(baseLiveAnchorId))
                {
                    res = res.Where(e => e.LiveAnchorMonthlyTargetLiving.LiveAnchor.LiveAnchorBaseId == baseLiveAnchorId);
                }
                livingBusinessDataDto.DesignCardOrder += res.Sum(e => e.Consultation) + res.Sum(e => e.Consultation2);
                livingBusinessDataDto.DesignCardRefund += res.Sum(e => e.RefundCard);
                livingBusinessDataDto.DesignCardActual = livingBusinessDataDto.DesignCardOrder - livingBusinessDataDto.DesignCardRefund;


            }
            if (showWechatVideoData)
            {
                var res = dalLivingDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.LiveAnchorMonthlyTargetLiving.LiveAnchor.ContentPlateFormId == "9196b247-1ab9-4d0c-a11e-a1ef09019878" && e.Valid == true);
                if (!string.IsNullOrEmpty(baseLiveAnchorId))
                {
                    res = res.Where(e => e.LiveAnchorMonthlyTargetLiving.LiveAnchor.LiveAnchorBaseId == baseLiveAnchorId);
                }
                livingBusinessDataDto.DesignCardOrder += res.Sum(e => e.Consultation) + res.Sum(e => e.Consultation2);
                livingBusinessDataDto.DesignCardRefund += res.Sum(e => e.RefundCard);
                livingBusinessDataDto.DesignCardActual = livingBusinessDataDto.DesignCardOrder - livingBusinessDataDto.DesignCardRefund;
            }

            return livingBusinessDataDto;
        }
        /// <summary>
        /// 获取直播中年趋势图
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<LivingAestheticMedicineBrokenDataDto> GetAestheticMedicineBusinessBrokenDataAsync(QueryLivingBusinessDataDto queryDto)
        {
            LivingAestheticMedicineBrokenDataDto livingBrokenDataDto = new LivingAestheticMedicineBrokenDataDto();
            List<LivingAestheticMedicineBrokenDataItemDto> dataList = new List<LivingAestheticMedicineBrokenDataItemDto>();
            var startDate = new DateTime(queryDto.Year, 1, 1);
            var endDate = startDate.AddYears(1);
            if (queryDto.ShowTikokData)
            {
                var res = dalLivingDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.LiveAnchorMonthlyTargetLiving.LiveAnchor.ContentPlateFormId == "4e4e9564-f6c3-47b6-a7da-e4518bab66a1" && e.Valid == true).Select(e => new LivingAestheticMedicineBrokenDataItemDto
                {
                    DesignCardOrder = e.Consultation + e.Consultation2,
                    DesignCardRefund = e.RefundCard,
                    DesignCardActual = e.Consultation + e.Consultation2 - e.RefundCard,
                    Time = e.RecordDate.Month.ToString(),
                    BaseLiveAnchorId = e.LiveAnchorMonthlyTargetLiving.LiveAnchor.LiveAnchorBaseId
                });
                if (!string.IsNullOrEmpty(queryDto.BaseLiveAnchorId))
                {
                    res = res.Where(e => e.BaseLiveAnchorId == queryDto.BaseLiveAnchorId);
                }
                dataList.AddRange(res.ToList());

            }
            if (queryDto.ShowWechatVideoData)
            {
                var res = dalLivingDailyTarget.GetAll().Where(e => e.RecordDate >= startDate && e.RecordDate < endDate && e.LiveAnchorMonthlyTargetLiving.LiveAnchor.ContentPlateFormId == "9196b247-1ab9-4d0c-a11e-a1ef09019878" && e.Valid == true).Select(e => new LivingAestheticMedicineBrokenDataItemDto
                {
                    DesignCardOrder = e.Consultation + e.Consultation2,
                    DesignCardRefund = e.RefundCard,
                    DesignCardActual = e.Consultation + e.Consultation2 - e.RefundCard,
                    Time = e.RecordDate.Month.ToString(),
                    BaseLiveAnchorId = e.LiveAnchorMonthlyTargetLiving.LiveAnchor.LiveAnchorBaseId
                });
                if (!string.IsNullOrEmpty(queryDto.BaseLiveAnchorId))
                {
                    res = res.Where(e => e.BaseLiveAnchorId == queryDto.BaseLiveAnchorId);
                }
                dataList.AddRange(res.ToList());
            }

            dataList = dataList.GroupBy(e => e.Time).Select(e => new LivingAestheticMedicineBrokenDataItemDto
            {
                Time = e.Key,
                DesignCardOrder = e.Sum(e => e.DesignCardOrder),
                DesignCardRefund = e.Sum(e => e.DesignCardRefund),
                DesignCardActual = e.Sum(e => e.DesignCardActual),

            }).ToList();
            dataList = this.FillLivingAestheticMedicineDate(queryDto.Year, queryDto.Month, dataList);
            livingBrokenDataDto.DesignCardOrderData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.DesignCardOrder)
            }).ToList();
            livingBrokenDataDto.DesignCardRefundData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.DesignCardRefund)
            }).ToList();
            livingBrokenDataDto.DesignCardActualData = dataList.GroupBy(e => e.Time).Select(e => new PeformanceBrokenLineListInfoDto
            {
                date = e.Key.ToString(),
                Performance = e.Sum(e => e.DesignCardActual)
            }).ToList();

            return livingBrokenDataDto;
        }

        #endregion


        #region 直播后

        public async Task<AfterLivingBusinessDataDto> GetAfterLivingBusinessDataAsync(QueryAfterLivingBusinessDataDto queryDto)
        {
            AfterLivingBusinessDataDto afterLivingBusinessDataDto = new AfterLivingBusinessDataDto();
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(queryDto.Year, queryDto.Month == 0 ? 1 : queryDto.Month);
            //获取各个平台的主播ID
            List<int> LiveAnchorInfo = new List<int>();
            if (!string.IsNullOrEmpty(queryDto.BaseLiveAnchorId) || (queryDto.IsSelfLiveanchor.HasValue && queryDto.IsSelfLiveanchor == false))
            {
                LiveAnchorInfo = await this.GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync(queryDto.BaseLiveAnchorId, queryDto.IsSelfLiveanchor);
            }


            //获取目标
            var target = await liveAnchorMonthlyTargetAfterLivingService.GetPerformanceTargetAsync(queryDto.Year, queryDto.Month, LiveAnchorInfo);
            #region 总业绩
            //总业绩
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(sequentialDate.StartDate, sequentialDate.EndDate, LiveAnchorInfo);
            var curTotalPerformance = order.Sum(o => o.Price);
            //同比业绩
            var orderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, LiveAnchorInfo);
            //环比业绩
            List<ContentPlatFormOrderDealInfoDto> orderChain = new List<ContentPlatFormOrderDealInfoDto>();
            orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, LiveAnchorInfo);
            afterLivingBusinessDataDto.TotalPerformance = curTotalPerformance;
            afterLivingBusinessDataDto.TotalPerformanceTarget = target.TotalPerformanceTarget;
            afterLivingBusinessDataDto.TotalPerformanceCompleteRate = CalculateTargetComplete(curTotalPerformance, target.TotalPerformanceTarget);
            afterLivingBusinessDataDto.TotalPerformanceChainRatio = CalculateChainratio(curTotalPerformance, orderChain.Sum(e => e.Price));
            afterLivingBusinessDataDto.TotalPerformanceYearOnYear = CalculateYearOnYear(curTotalPerformance, orderYearOnYear.Sum(e => e.Price));
            afterLivingBusinessDataDto.TotalPerformanceToDateSchedule = CalculateSchedule(target.TotalPerformanceTarget, curTotalPerformance, queryDto.Year, queryDto.Month);

            #endregion

            #region 新客业绩
            var curNewCustomer = order.Where(o => o.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderYearOnYear = orderYearOnYear.Where(x => x.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderChainRatio = orderChain.Where(x => x.IsOldCustomer == false).Sum(o => o.Price);
            afterLivingBusinessDataDto.NewCustomerPerformance = curNewCustomer;
            afterLivingBusinessDataDto.NewCustomerPerformanceTarget = target.NewCustomerPerformanceTarget;
            afterLivingBusinessDataDto.NewCustomerPerformanceCompleteRate = CalculateTargetComplete(curNewCustomer, target.NewCustomerPerformanceTarget);
            afterLivingBusinessDataDto.NewCustomerPerformanceChainRatio = CalculateChainratio(curNewCustomer, newOrderChainRatio);
            afterLivingBusinessDataDto.NewCustomerPerformanceYearOnYear = CalculateYearOnYear(curNewCustomer, newOrderYearOnYear);
            afterLivingBusinessDataDto.NewCustomerPerformanceToDateSchedule = CalculateSchedule(target.NewCustomerPerformanceTarget, curNewCustomer, queryDto.Year, queryDto.Month);
            afterLivingBusinessDataDto.NewCustomerPerformanceRate = DecimalExtension.CalculateTargetComplete(curNewCustomer, curTotalPerformance).Value;
            #endregion
            #region 老客业绩
            var curOldCustomer = order.Where(o => o.IsOldCustomer == true).Sum(o => o.Price);
            var OldOrderYearOnYear = orderYearOnYear.Where(x => x.IsOldCustomer == true).Sum(o => o.Price);
            var OldOrderChainRatio = orderChain.Where(x => x.IsOldCustomer == true).Sum(o => o.Price);
            afterLivingBusinessDataDto.OldCustomerPerformance = curOldCustomer;
            afterLivingBusinessDataDto.OldCustomerPerformanceTarget = target.OldCustomerPerformanceTarget;
            afterLivingBusinessDataDto.OldCustomerPerformanceCompleteRate = CalculateTargetComplete(curOldCustomer, target.OldCustomerPerformanceTarget);
            afterLivingBusinessDataDto.OldCustomerPerformanceChainRatio = CalculateChainratio(curOldCustomer, OldOrderChainRatio);
            afterLivingBusinessDataDto.OldCustomerPerformanceYearOnYear = CalculateYearOnYear(curOldCustomer, OldOrderYearOnYear);
            afterLivingBusinessDataDto.OldCustomerPerformanceToDateSchedule = CalculateSchedule(target.OldCustomerPerformanceTarget, curOldCustomer, queryDto.Year, queryDto.Month);
            afterLivingBusinessDataDto.OldCustomerPerformanceRate = DecimalExtension.CalculateTargetComplete(curOldCustomer, curTotalPerformance).Value;
            #endregion
            #region 有效业绩
            var curEffective = order.Where(o => o.AddOrderPrice > 0).Sum(o => o.Price);
            var EffectiveYearOnYear = orderYearOnYear.Where(o => o.AddOrderPrice > 0).Sum(o => o.Price);
            var EffectiveChainRatio = orderChain.Where(o => o.AddOrderPrice > 0).Sum(o => o.Price);
            afterLivingBusinessDataDto.EffectivePerformance = curEffective;
            afterLivingBusinessDataDto.EffectivePerformanceTarget = target.EffectivePerformance;
            afterLivingBusinessDataDto.EffectivePerformanceCompleteRate = CalculateTargetComplete(curEffective, target.EffectivePerformance);
            afterLivingBusinessDataDto.EffectivePerformanceChainRatio = CalculateChainratio(curEffective, EffectiveChainRatio);
            afterLivingBusinessDataDto.EffectivePerformanceYearOnYear = CalculateYearOnYear(curEffective, EffectiveYearOnYear);
            afterLivingBusinessDataDto.EffectivePerformanceToDateSchedule = CalculateSchedule(target.EffectivePerformance, curEffective, queryDto.Year, queryDto.Month);
            afterLivingBusinessDataDto.EffectivePerformanceRate = DecimalExtension.CalculateTargetComplete(curEffective, curTotalPerformance).Value;
            #endregion
            #region 潜在业绩
            var curPotential = order.Where(o => o.AddOrderPrice == 0).Sum(o => o.Price);
            var PotentialYearOnYear = orderYearOnYear.Where(o => o.AddOrderPrice == 0).Sum(o => o.Price);
            var PotentialChainRatio = orderChain.Where(o => o.AddOrderPrice == 0).Sum(o => o.Price);
            afterLivingBusinessDataDto.PotentialPerformance = curPotential;
            afterLivingBusinessDataDto.PotentialPerformanceTarget = target.PotentialPerformance;
            afterLivingBusinessDataDto.PotentialPerformanceCompleteRate = CalculateTargetComplete(curPotential, target.PotentialPerformance);
            afterLivingBusinessDataDto.PotentialPerformanceChainRatio = CalculateChainratio(curPotential, PotentialChainRatio);
            afterLivingBusinessDataDto.PotentialPerformanceYearOnYear = CalculateYearOnYear(curPotential, PotentialYearOnYear);
            afterLivingBusinessDataDto.PotentialPerformanceToDateSchedule = CalculateSchedule(target.PotentialPerformance, curPotential, queryDto.Year, queryDto.Month);
            afterLivingBusinessDataDto.PotentialPerformanceRate = DecimalExtension.CalculateTargetComplete(curPotential, curTotalPerformance).Value;
            #endregion

            #region 新客有效业绩
            var curNewCustomerEffective = order.Where(o => o.AddOrderPrice > 0 && o.IsOldCustomer == false).Sum(o => o.Price);
            var NewCustomerEffectiveYearOnYear = orderYearOnYear.Where(o => o.AddOrderPrice > 0 && o.IsOldCustomer == false).Sum(o => o.Price);
            var NewCustomerEffectiveChainRatio = orderChain.Where(o => o.AddOrderPrice > 0 && o.IsOldCustomer == false).Sum(o => o.Price);
            afterLivingBusinessDataDto.NewCustomerEffectivePerformance = curNewCustomerEffective;
            afterLivingBusinessDataDto.NewCustomerEffectivePerformanceChain = CalculateChainratio(curNewCustomerEffective, NewCustomerEffectiveChainRatio);
            afterLivingBusinessDataDto.NewCustomerEffectivePerformanceYearToYear = CalculateYearOnYear(curNewCustomerEffective, NewCustomerEffectiveYearOnYear);
            afterLivingBusinessDataDto.NewCustomerEffectivePerformanceRate = DecimalExtension.CalculateTargetComplete(curNewCustomerEffective, curNewCustomer).Value;
            #endregion
            #region 新客潜在业绩
            var curNewCustomerPotential = order.Where(o => o.AddOrderPrice == 0 && o.IsOldCustomer == false).Sum(o => o.Price);
            var NewCustomerPotentialYearOnYear = orderYearOnYear.Where(o => o.AddOrderPrice == 0 && o.IsOldCustomer == false).Sum(o => o.Price);
            var NewCustomerPotentialChainRatio = orderChain.Where(o => o.AddOrderPrice == 0 && o.IsOldCustomer == false).Sum(o => o.Price);
            afterLivingBusinessDataDto.NewCustomerPotentialPerformance = curNewCustomerPotential;
            afterLivingBusinessDataDto.NewCustomerPotentialPerformanceChain = CalculateChainratio(curNewCustomerPotential, NewCustomerPotentialChainRatio);
            afterLivingBusinessDataDto.NewCustomerPotentialPerformanceYearToYear = CalculateYearOnYear(curNewCustomerPotential, NewCustomerPotentialYearOnYear);
            afterLivingBusinessDataDto.NewCustomerPotentialPerformanceRate = DecimalExtension.CalculateTargetComplete(curNewCustomerPotential, curNewCustomer).Value;
            #endregion
            #region 老客有效业绩
            var curOldCustomerEffective = order.Where(o => o.AddOrderPrice > 0 && o.IsOldCustomer == true).Sum(o => o.Price);
            var OldCustomerEffectiveYearOnYear = orderYearOnYear.Where(o => o.AddOrderPrice > 0 && o.IsOldCustomer == true).Sum(o => o.Price);
            var OldCustomerEffectiveChainRatio = orderChain.Where(o => o.AddOrderPrice > 0 && o.IsOldCustomer == true).Sum(o => o.Price);
            afterLivingBusinessDataDto.OldCustomerEffectivePerformance = curOldCustomerEffective;
            afterLivingBusinessDataDto.OldCustomerEffectivePerformanceChain = CalculateChainratio(curOldCustomerEffective, OldCustomerEffectiveChainRatio);
            afterLivingBusinessDataDto.OldCustomerEffectivePerformanceYearToYear = CalculateYearOnYear(curOldCustomerEffective, OldCustomerEffectiveYearOnYear);
            afterLivingBusinessDataDto.OldCustomerEffectivePerformanceRate = DecimalExtension.CalculateTargetComplete(curOldCustomerEffective, curOldCustomer).Value;
            #endregion
            #region 老客潜在业绩
            var curOldCustomerPotential = order.Where(o => o.AddOrderPrice == 0 && o.IsOldCustomer == true).Sum(o => o.Price);
            var OldCustomerPotentialYearOnYear = orderYearOnYear.Where(o => o.AddOrderPrice == 0 && o.IsOldCustomer == true).Sum(o => o.Price);
            var OldCustomerPotentialChainRatio = orderChain.Where(o => o.AddOrderPrice == 0 && o.IsOldCustomer == true).Sum(o => o.Price);
            afterLivingBusinessDataDto.OldCustomerPotentialPerformance = curOldCustomerPotential;
            afterLivingBusinessDataDto.OldCustomerPotentialPerformanceChain = CalculateChainratio(curOldCustomerPotential, OldCustomerPotentialChainRatio);
            afterLivingBusinessDataDto.OldCustomerPotentialPerformanceYearToYear = CalculateYearOnYear(curOldCustomerPotential, OldCustomerPotentialYearOnYear);
            afterLivingBusinessDataDto.OldCustomerPotentialPerformanceRate = DecimalExtension.CalculateTargetComplete(curOldCustomerPotential, curOldCustomer).Value;
            #endregion
            return afterLivingBusinessDataDto;
        }
        /// <summary>
        /// 获取直播后趋势图数据
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<AfterLivingBrokenDataDto> GetAfterLivingBrokenDataAsync(QueryAfterLivingBusinessDataDto queryDto)
        {
            AfterLivingBrokenDataDto amiyaAchievementDetailDataDto = new AfterLivingBrokenDataDto();
            //获取各个平台的主播ID
            List<int> LiveAnchorInfo = new List<int>();
            if (!string.IsNullOrEmpty(queryDto.BaseLiveAnchorId) || (queryDto.IsSelfLiveanchor.HasValue && queryDto.IsSelfLiveanchor == false))
            {
                LiveAnchorInfo = await this.GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync(queryDto.BaseLiveAnchorId, queryDto.IsSelfLiveanchor);
            }
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(queryDto.Year, queryDto.Month == 0 ? 1 : queryDto.Month);
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(sequentialDate.StartDate, sequentialDate.EndDate, LiveAnchorInfo);
            List<AfterLivingBrokenItemDataDto> dataList = new List<AfterLivingBrokenItemDataDto>();
            dataList = order.GroupBy(e => e.CreateDate.Day)
                     .Select(x => new AfterLivingBrokenItemDataDto
                     {
                         Time = x.Key.ToString(),
                         TotalPerformance = x.Sum(e => e.Price),
                         NewCustomerPerformance = x.Where(e => e.IsOldCustomer == false).Sum(e => e.Price),
                         OldCustomerPerformance = x.Where(e => e.IsOldCustomer == true).Sum(e => e.Price),
                         EffectivePerformance = x.Where(e => e.AddOrderPrice > 0).Sum(e => e.Price),
                         PotentialPerformance = x.Where(e => e.AddOrderPrice == 0).Sum(e => e.Price),
                         NewCustomerEffectivePerformance = x.Where(e => e.IsOldCustomer == false && e.AddOrderPrice > 0).Sum(e => e.Price),
                         NewCustomerPotentialPerformance = x.Where(e => e.IsOldCustomer == false && e.AddOrderPrice == 0).Sum(e => e.Price),
                         OldCustomerEffectivePerformance = x.Where(e => e.IsOldCustomer == true && e.AddOrderPrice > 0).Sum(e => e.Price),
                         OldCustomerPotentialPerformance = x.Where(e => e.IsOldCustomer == true && e.AddOrderPrice == 0).Sum(e => e.Price),
                     }).ToList();
            dataList = this.FillAfterLivingDate(queryDto.Year, queryDto.Month, dataList);
            amiyaAchievementDetailDataDto.TotalPerformanceBrokenLineList = dataList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time, Performance = e.TotalPerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.NewCustomerPerformanceBrokenLineList = dataList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time, Performance = e.NewCustomerPerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.OldCustomerPerformanceBrokenLineList = dataList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time, Performance = e.OldCustomerPerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.EffectivePerformanceBrokenLineList = dataList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time, Performance = e.EffectivePerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.PotentialPerformanceBrokenLineList = dataList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time, Performance = e.PotentialPerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.NewCustomerEffectivePerformanceBrokenLineList = dataList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time, Performance = e.NewCustomerEffectivePerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.NewCustomerPotentialPerformanceBrokenLineList = dataList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time, Performance = e.NewCustomerPotentialPerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.OldCustomerEffectivePerformanceBrokenLineList = dataList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time, Performance = e.OldCustomerEffectivePerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.OldCustomerPotentialPerformanceBrokenLineList = dataList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time, Performance = e.OldCustomerPotentialPerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            return amiyaAchievementDetailDataDto;
        }
        #endregion

        #region 公共类
        /// <summary>
        /// 根据主播id与是否自播获取主播id集合
        /// </summary>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        private async Task<List<int>> GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync(string baseLiveAnchorId, bool? isSelfLiveAnchor)
        {
            List<int> LiveAnchorInfo = new List<int>();
            //获取主播基础信息id
            var liveAnchorBaseInfo = await liveAnchorBaseInfoService.GetByIdAndIsSelfLiveAnchorAsync(baseLiveAnchorId, isSelfLiveAnchor);
            var liveanchorBaseIds = liveAnchorBaseInfo.Select(x => x.Id).ToList();
            if (liveanchorBaseIds.Count != 0)
            {
                var liveAnchor = await liveAnchorService.GetValidListByLiveAnchorBaseIdAsync(liveanchorBaseIds);
                LiveAnchorInfo = liveAnchor.Select(x => x.Id).ToList();
            }
            return LiveAnchorInfo;
        }

        /// <summary>
        /// 计算同比增长率
        /// </summary>
        /// <param name="currentMonthPerformance">当前月业绩</param>
        /// <param name="performanceYearOnYear">同比业绩</param>
        /// <returns></returns>
        private decimal? CalculateYearOnYear(decimal currentMonthPerformance, decimal performanceYearOnYear)
        {
            if (performanceYearOnYear == 0m)
                return null;
            var result = Math.Round((currentMonthPerformance - performanceYearOnYear) / performanceYearOnYear * 100, 2, MidpointRounding.AwayFromZero);
            if (result > 99.99M)
            {
                result = Math.Round(result, 1, MidpointRounding.AwayFromZero);
            }
            if (result > 999.99M)
            {
                result = Math.Round(result, 0, MidpointRounding.AwayFromZero);
            }
            return result;

        }
        /// <summary>
        /// 计算环比增长率
        /// </summary>
        /// <param name="currentMonthPerformance">当前月业绩</param>
        /// <param name="performanceChainRatio">环比业绩</param>
        /// <returns></returns>
        private decimal? CalculateChainratio(decimal currentMonthPerformance, decimal performanceChainRatio)
        {
            if (performanceChainRatio == 0m)
                return null;
            var result = Math.Round((currentMonthPerformance - performanceChainRatio) / performanceChainRatio * 100, 2, MidpointRounding.AwayFromZero);
            if (currentMonthPerformance > 0 && performanceChainRatio < 0)
            {
                result = Math.Abs(result);
            }
            if (result > 99.99M)
            {
                result = Math.Round(result, 1, MidpointRounding.AwayFromZero);
            }
            if (result > 999.99M)
            {
                result = Math.Round(result, 0, MidpointRounding.AwayFromZero);
            }
            if (result < 99.99M)
            {
                result = Math.Round(result, 1, MidpointRounding.AwayFromZero);
            }
            if (result < 999.99M)
            {
                result = Math.Round(result, 0, MidpointRounding.AwayFromZero);
            }
            return result;
        }
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
            var result = Math.Round(completePerformance / monthTarget * 100, 2, MidpointRounding.AwayFromZero);
            if (result > 99.99M)
            {
                result = Math.Round(result, 1, MidpointRounding.AwayFromZero);
            }
            if (result > 999.99M)
            {
                result = Math.Round(result, 0, MidpointRounding.AwayFromZero);
            }
            return result;
        }
        /// <summary>
        /// 计算对比时间进度
        /// </summary>
        /// <param name="performanceTarget">总业绩目标</param>
        /// <param name="currentPerformance">当前完成业绩</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        private decimal CalculateSchedule(decimal performanceTarget, decimal currentPerformance, int year, int month)
        {
            decimal ContrastTimeSchedule = 0m;

            if (performanceTarget == 0m || currentPerformance == 0m)
            {
                return ContrastTimeSchedule;
            }

            decimal timeSchedule = 0;
            var now = DateTime.Now;
            var totalDay = DateTime.DaysInMonth(now.Year, now.Month);
            var nowDay = now.Day;
            if (year != now.Year || month != now.Month)
            {
                timeSchedule = 100m;
            }
            else
            {
                timeSchedule = Math.Round(Convert.ToDecimal(nowDay) / Convert.ToDecimal(totalDay) * 100, 2, MidpointRounding.AwayFromZero);
            }
            decimal performanceSchedule = Math.Round(currentPerformance / performanceTarget * 100, 2, MidpointRounding.AwayFromZero);
            ContrastTimeSchedule = performanceSchedule - timeSchedule;
            return ContrastTimeSchedule;
        }
        /// <summary>
        /// 填充直播前趋势图数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private List<BeforeLivingBrokenDataItemDto> FillDate(int year, int month, List<BeforeLivingBrokenDataItemDto> dataList)
        {
            List<BeforeLivingBrokenDataItemDto> list = new List<BeforeLivingBrokenDataItemDto>();
            var totalDays = DateTime.DaysInMonth(year, month);
            for (int i = 1; i < totalDays + 1; i++)
            {
                var day = i.ToString();
                BeforeLivingBrokenDataItemDto item = new BeforeLivingBrokenDataItemDto();
                item.Time = day;
                item.IncreaseFans = dataList.Where(e => e.Time == day).Select(e => e.IncreaseFans).SingleOrDefault();
                item.IncreaseFansFees = dataList.Where(e => e.Time == day).Select(e => e.IncreaseFansFees).SingleOrDefault();
                item.ShowcaseIncome = dataList.Where(e => e.Time == day).Select(e => e.ShowcaseIncome).SingleOrDefault();
                item.ShowcaseFee = dataList.Where(e => e.Time == day).Select(e => e.ShowcaseFee).SingleOrDefault();
                item.Clues = dataList.Where(e => e.Time == day).Select(e => e.Clues).SingleOrDefault();
                item.SendNum = dataList.Where(e => e.Time == day).Select(e => e.SendNum).SingleOrDefault();
                list.Add(item);
            }
            return list;
        }
        /// <summary>
        /// 填充直播中带货
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private List<LivingBrokenDataItemDto> FillLivingDate(int year, int month, List<LivingBrokenDataItemDto> dataList)
        {
            List<LivingBrokenDataItemDto> list = new List<LivingBrokenDataItemDto>();
            for (int i = 1; i < 13; i++)
            {
                var day = i.ToString();
                LivingBrokenDataItemDto item = new LivingBrokenDataItemDto();
                item.Time = day;
                item.OrderGMV = dataList.Where(e => e.Time == day).Select(e => e.OrderGMV).SingleOrDefault();
                item.RefundGMV = dataList.Where(e => e.Time == day).Select(e => e.RefundGMV).SingleOrDefault();
                item.ActualReturnBackMoney = dataList.Where(e => e.Time == day).Select(e => e.ActualReturnBackMoney).SingleOrDefault();
                item.InvestFlow = dataList.Where(e => e.Time == day).Select(e => e.InvestFlow).SingleOrDefault();
                list.Add(item);
            }
            return list;
        }
        /// <summary>
        /// 填充直播后趋势图数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>                   
        /// <param name="dataList"></param>
        /// <returns></returns>
        private List<AfterLivingBrokenItemDataDto> FillAfterLivingDate(int year, int month, List<AfterLivingBrokenItemDataDto> dataList)
        {
            List<AfterLivingBrokenItemDataDto> list = new List<AfterLivingBrokenItemDataDto>();
            var totalDays = DateTime.DaysInMonth(year, month);
            for (int i = 1; i < totalDays + 1; i++)
            {
                var day = i.ToString();
                AfterLivingBrokenItemDataDto item = new AfterLivingBrokenItemDataDto();
                item.Time = day;
                item.TotalPerformance = dataList.Where(e => e.Time == day).Select(e => e.TotalPerformance).SingleOrDefault();
                item.NewCustomerPerformance = dataList.Where(e => e.Time == day).Select(e => e.NewCustomerPerformance).SingleOrDefault();
                item.OldCustomerPerformance = dataList.Where(e => e.Time == day).Select(e => e.OldCustomerPerformance).SingleOrDefault();
                item.EffectivePerformance = dataList.Where(e => e.Time == day).Select(e => e.EffectivePerformance).SingleOrDefault();
                item.PotentialPerformance = dataList.Where(e => e.Time == day).Select(e => e.PotentialPerformance).SingleOrDefault();
                item.NewCustomerEffectivePerformance = dataList.Where(e => e.Time == day).Select(e => e.NewCustomerEffectivePerformance).SingleOrDefault();
                item.NewCustomerPotentialPerformance = dataList.Where(e => e.Time == day).Select(e => e.NewCustomerPotentialPerformance).SingleOrDefault();
                item.OldCustomerEffectivePerformance = dataList.Where(e => e.Time == day).Select(e => e.OldCustomerEffectivePerformance).SingleOrDefault();
                item.OldCustomerPotentialPerformance = dataList.Where(e => e.Time == day).Select(e => e.OldCustomerPotentialPerformance).SingleOrDefault();
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// 填充直播中带货
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private List<LivingAestheticMedicineBrokenDataItemDto> FillLivingAestheticMedicineDate(int year, int month, List<LivingAestheticMedicineBrokenDataItemDto> dataList)
        {
            List<LivingAestheticMedicineBrokenDataItemDto> list = new List<LivingAestheticMedicineBrokenDataItemDto>();
            for (int i = 1; i < 13; i++)
            {
                var day = i.ToString();
                LivingAestheticMedicineBrokenDataItemDto item = new LivingAestheticMedicineBrokenDataItemDto();
                item.Time = day;
                item.DesignCardOrder = dataList.Where(e => e.Time == day).Select(e => e.DesignCardOrder).SingleOrDefault();
                item.DesignCardRefund = dataList.Where(e => e.Time == day).Select(e => e.DesignCardRefund).SingleOrDefault();
                item.DesignCardActual = dataList.Where(e => e.Time == day).Select(e => e.DesignCardActual).SingleOrDefault();
                list.Add(item);
            }
            return list;
        }



        #endregion
    }
}
