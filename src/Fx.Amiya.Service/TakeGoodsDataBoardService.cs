using Fx.Amiya.Dto;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.TakeGoods;
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
    public class TakeGoodsDataBoardService : ITakeGoodsDataBoardService
    {
        private ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService;
        private ILiveAnchorService liveAnchorService;
        private ILivingDailyTakeGoodsService livingDailyTakeGoodsService;
        private ILiveAnchorDailyTargetService liveAnchorDailyTargetService;

        public TakeGoodsDataBoardService(ILiveAnchorService liveAnchorService, ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService, ILivingDailyTakeGoodsService livingDailyTakeGoodsService, ILiveAnchorDailyTargetService liveAnchorDailyTargetService)
        {

            this.liveAnchorService = liveAnchorService;
            this.liveAnchorMonthlyTargetLivingService = liveAnchorMonthlyTargetLivingService;
            this.livingDailyTakeGoodsService = livingDailyTakeGoodsService;
            this.liveAnchorDailyTargetService = liveAnchorDailyTargetService;
        }
        #region GMV看板

        /// <summary>
        /// GMV看板
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<GMVDataDto> GetGMVDataAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            GMVDataDto gMVData = new GMVDataDto();
            var ids = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, liveAnchorId);

            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month == 0 ? 1 : month);
            var thisMonthTarget = await liveAnchorMonthlyTargetLivingService.GetBasePerformanceTargetAsync(year, month, ids);

            var thisMonthData = await liveAnchorDailyTargetService.GetGmvDataAsync(sequentialDate.StartDate, sequentialDate.EndDate, ids);
            var lastMonthData = await liveAnchorDailyTargetService.GetGmvDataAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, ids);
            var lastYearData = await liveAnchorDailyTargetService.GetGmvDataAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, ids);

            #region 下单gmv
            gMVData.OrderGmv = thisMonthData.Sum(e => e.GMV);
            gMVData.OrderGmvCompleteRate = DecimalExtension.CalculateTargetComplete(gMVData.OrderGmv, thisMonthTarget.GMVTarget).Value;
            gMVData.OrderGMVYearOnYear = DecimalExtension.CalculateChain(gMVData.OrderGmv, lastYearData.Sum(e => e.GMV)).Value;
            gMVData.OrderGMVChainRatio = DecimalExtension.CalculateChain(gMVData.OrderGmv, lastMonthData.Sum(e => e.GMV)).Value;
            var orderGmvSchedule = CalculateSchedule(thisMonthTarget.GMVTarget, gMVData.OrderGmv, year, month);
            gMVData.OrderGMVToDateSchedule = orderGmvSchedule.ContrastTimeSchedule;
            gMVData.OrderGMVDeviation = orderGmvSchedule.PerformanceDeviation;
            gMVData.LaterCompleteEveryDayOrderGMV = orderGmvSchedule.ResidueTimeNeedCompletePerformance;
            #endregion

            #region 直播间投流
            gMVData.QianChuanPutIn = thisMonthData.Sum(e => e.LivingRoomCumulativeFlowInvestment);
            gMVData.QianChuanPutInCompleteRate = DecimalExtension.CalculateTargetComplete(gMVData.QianChuanPutIn, thisMonthTarget.LivingRoomFlowInvestmentTarget).Value;
            gMVData.QianChuanPutInChainRatio = DecimalExtension.CalculateChain(gMVData.QianChuanPutIn, lastMonthData.Sum(e => e.LivingRoomCumulativeFlowInvestment)).Value;
            gMVData.QianChuanPutInYearOnYear = DecimalExtension.CalculateChain(gMVData.QianChuanPutIn, lastYearData.Sum(e => e.LivingRoomCumulativeFlowInvestment)).Value;
            var qianChuanSchedule = CalculateSchedule(thisMonthTarget.LivingRoomFlowInvestmentTarget, gMVData.QianChuanPutIn, year, month);
            gMVData.QianChuanToDateSchedule = qianChuanSchedule.ContrastTimeSchedule;
            gMVData.QianChuanDeviation = qianChuanSchedule.PerformanceDeviation;
            gMVData.LaterCompleteEveryDayQianChuan = qianChuanSchedule.ResidueTimeNeedCompletePerformance;
            #endregion

            #region 直播间投流细分

            gMVData.QianChuanNum = thisMonthData.Sum(e => e.QianChuanNum);
            gMVData.ShuiXinTuiNum = thisMonthData.Sum(e=>e.ShuiXinTuiNum);
            gMVData.TikTokPlusNum = thisMonthData.Sum(e=>e.TikTokPlusNum);
            gMVData.WeiXinDou = thisMonthData.Sum(e=>e.WeiXinDou);

            #endregion 

            #region 刀刀组和吉娜组数据
            if (string.IsNullOrEmpty(liveAnchorId))
            {


                var daodaoIds = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, "f0a77257-c905-4719-95c4-ad2c4f33855c");
                var jinaIds = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, "af69dcf5-f749-41ea-8b50-fe685facdd8b");

                var daodaoThisMonthTarget = await liveAnchorMonthlyTargetLivingService.GetBasePerformanceTargetAsync(year, month, daodaoIds);
                var daodaoThisMonthData = await liveAnchorDailyTargetService.GetGmvDataAsync(sequentialDate.StartDate, sequentialDate.EndDate, daodaoIds);
                var daodaoLastMonthData = await liveAnchorDailyTargetService.GetGmvDataAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, daodaoIds);
                var daodaoLastYearData = await liveAnchorDailyTargetService.GetGmvDataAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, daodaoIds);


                var jinaThisMonthTarget = await liveAnchorMonthlyTargetLivingService.GetBasePerformanceTargetAsync(year, month, jinaIds);
                var jinaThisMonthData = await liveAnchorDailyTargetService.GetGmvDataAsync(sequentialDate.StartDate, sequentialDate.EndDate, jinaIds);
                var jinaLastMonthData = await liveAnchorDailyTargetService.GetGmvDataAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, jinaIds);
                var jinaLastYearData = await liveAnchorDailyTargetService.GetGmvDataAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, jinaIds);

                gMVData.DaoDaoOrderGmv = daodaoThisMonthData.Sum(e => e.GMV);
                gMVData.DaoDaoOrderGmvCompleteRate = DecimalExtension.CalculateTargetComplete(gMVData.DaoDaoOrderGmv, daodaoThisMonthTarget.GMVTarget).Value;
                gMVData.DaoDaoOrderGMVChainRatio = DecimalExtension.CalculateChain(gMVData.DaoDaoOrderGmv, daodaoLastMonthData.Sum(e => e.GMV)).Value;
                gMVData.DaoDaoOrderGMVYearOnYear = DecimalExtension.CalculateChain(gMVData.DaoDaoOrderGmv, daodaoLastYearData.Sum(e => e.GMV)).Value;

                var daoaoSchedule = CalculateSchedule(daodaoThisMonthTarget.GMVTarget, gMVData.DaoDaoOrderGmv, year, month);
                gMVData.DaoDaoOrderGMVToDateSchedule = daoaoSchedule.ContrastTimeSchedule;
                gMVData.DaoDaoOrderGMVDeviation = daoaoSchedule.PerformanceDeviation;
                gMVData.LaterCompleteEveryDayDaoDaoOrderGMV = daoaoSchedule.ResidueTimeNeedCompletePerformance;


                gMVData.JiNaOrderGmv = jinaThisMonthData.Sum(e => e.GMV);
                gMVData.JiNaOrderGmvCompleteRate = DecimalExtension.CalculateTargetComplete(gMVData.JiNaOrderGmv, jinaThisMonthTarget.GMVTarget).Value;
                gMVData.JiNaOrderGMVChainRatio = DecimalExtension.CalculateChain(gMVData.JiNaOrderGmv, jinaLastMonthData.Sum(e => e.GMV)).Value;
                gMVData.JiNaOrderGMVYearOnYear = DecimalExtension.CalculateChain(gMVData.JiNaOrderGmv, jinaLastYearData.Sum(e => e.GMV)).Value;

                var jinaSchedule = CalculateSchedule(jinaThisMonthTarget.GMVTarget, gMVData.JiNaOrderGmv, year, month);
                gMVData.JinaOrderGMVToDateSchedule = jinaSchedule.ContrastTimeSchedule;
                gMVData.JinaOrderGMVDeviation = jinaSchedule.PerformanceDeviation;
                gMVData.LaterCompleteEveryDayJInaOrderGMV = jinaSchedule.ResidueTimeNeedCompletePerformance;
            }
            #endregion

            #region 退款GMV

            gMVData.RefunGMV = thisMonthData.Sum(e => e.RefundGMV);
            gMVData.RefunGMVCompleteRate = DecimalExtension.CalculateTargetComplete(gMVData.RefunGMV, thisMonthTarget.RefundGMVTarget).Value;
            gMVData.RefunGMVYearOnYear = DecimalExtension.CalculateChain(gMVData.RefunGMV, lastYearData.Sum(e => e.RefundGMV)).Value;
            gMVData.RefunGMVChainRatio = DecimalExtension.CalculateChain(gMVData.RefunGMV, lastMonthData.Sum(e => e.RefundGMV)).Value;


            #endregion
            return gMVData;

        }

        /// <summary>
        /// 业绩趋势折线图
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<GMVDataBrokenLineDto> GetGMVDataBrokenLineDataAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            GMVDataBrokenLineDto gMVDataBrokenLineDto = new GMVDataBrokenLineDto();
            var ids = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, liveAnchorId);
            var targetIds = await liveAnchorMonthlyTargetLivingService.GetTargetIdsAsync(year, month, ids);
            var flowData = await liveAnchorDailyTargetService.GetDailyDataByLiveAnchorIdsAsync(targetIds,year,month);
            var flowList = flowData.GroupBy(e => e.Date.Day).Select(e => new { Date = e.Key, GMV = e.Sum(e => e.GMV), RefundGMV = e.Sum(e => e.RefundGMV), LivingRoomCumulativeFlowInvestment = e.Sum(e => e.LivingRoomCumulativeFlowInvestment) }).ToList();
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1);
            var thisMonthData = await livingDailyTakeGoodsService.GetTakeGoodsDataAsync(startDate, endDate, contentPlatformId, ids);
            List<GroupTakeGoodsDataDto> dataList = new List<GroupTakeGoodsDataDto>();
            dataList = thisMonthData.GroupBy(e => e.TakeGoodsDate.Day).Select(e => new GroupTakeGoodsDataDto
            {
                Date = e.Key,     
                OrderPackages = e.Sum(c => c.TakeGoodsType == (int)TakeGoodsType.CreateOrder ? c.Count : 0),
                RefundPackages = e.Sum(c => c.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder ? c.Count : 0),
                SinglePrice = DecimalExtension.Division(e.Sum(c => c.TakeGoodsType == (int)TakeGoodsType.CreateOrder ? c.GMV : 0m), e.Sum(c => c.TakeGoodsType == (int)TakeGoodsType.CreateOrder ? c.Count : 0)).Value,
                RefundSinglePrice = DecimalExtension.Division(e.Sum(c => c.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder ? c.GMV : 0m), e.Sum(c => c.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder ? c.Count : 0)).Value,
            }).ToList();
            List<GroupTakeGoodsDataDto> monthDataList = new List<GroupTakeGoodsDataDto>();
            foreach (var flow in flowList)
            {
                GroupTakeGoodsDataDto data = new GroupTakeGoodsDataDto();
                data.Date = flow.Date;
                data.OrderGMV = flow.GMV;
                data.QianChuanPutIn = flow.LivingRoomCumulativeFlowInvestment;
                data.RefundGMV = flow.RefundGMV;
                data.OrderPackages = 0;
                data.SinglePrice = 0;
                data.RefundSinglePrice = 0;
                monthDataList.Add(data);
            }
            gMVDataBrokenLineDto.OrderGMVBrokenLineList = this.FillDate(year, month, monthDataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Date.ToString(), Performance = e.OrderGMV }).OrderBy(e => Convert.ToInt32(e.date)).ToList(); ;
            gMVDataBrokenLineDto.QianChuanPutInBrokenLineList = this.FillDate(year, month, monthDataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Date.ToString(), Performance = e.QianChuanPutIn }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            gMVDataBrokenLineDto.RefundGMVBrokenLineList = this.FillDate(year, month, monthDataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Date.ToString(), Performance = e.RefundGMV }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            gMVDataBrokenLineDto.OrderPackagesBrokenLineList = this.FillDate(year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Date.ToString(), Performance = e.OrderPackages }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            gMVDataBrokenLineDto.RefundPackagesBrokenLineList = this.FillDate(year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Date.ToString(), Performance = e.RefundPackages }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            gMVDataBrokenLineDto.SinglePriceBrokenLineList = this.FillDate(year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Date.ToString(), Performance = e.SinglePrice }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            gMVDataBrokenLineDto.RefundSinglePriceBrokenLineList = this.FillDate(year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Date.ToString(), Performance = e.RefundSinglePrice }).OrderBy(e => Convert.ToInt32(e.date)).ToList();

            return gMVDataBrokenLineDto;

        }
        /// <summary>
        /// 件数看板
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<PackagesDataDto> GetPackagesDataAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            PackagesDataDto packagesData = new PackagesDataDto();
            var ids = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, liveAnchorId);
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month == 0 ? 1 : month);
            var thisMonthData = await livingDailyTakeGoodsService.GetTakeGoodsDataAsync(sequentialDate.StartDate, sequentialDate.EndDate, contentPlatformId, ids);
            var lastMonthData = await livingDailyTakeGoodsService.GetTakeGoodsDataAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, contentPlatformId, ids);
            var lastYearData = await livingDailyTakeGoodsService.GetTakeGoodsDataAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, contentPlatformId, ids);

            #region 下单件数

            packagesData.OrderCount = thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count);
            packagesData.OrderCountChainRatio = DecimalExtension.CalculateChain(packagesData.OrderCount, lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count)).Value;
            packagesData.OrderCountYearOnYear = DecimalExtension.CalculateChain(packagesData.OrderCount, lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count)).Value;

            #endregion

            #region 退款件数

            packagesData.RefundCount = thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count);
            packagesData.RefundCountChainRatio = DecimalExtension.CalculateChain(packagesData.OrderCount, lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value;
            packagesData.RefundCountYearOnYear = DecimalExtension.CalculateChain(packagesData.OrderCount, lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value;


            #endregion

            #region 分组数据

            if (string.IsNullOrEmpty(liveAnchorId))
            {
                var daodaoIds = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, "f0a77257-c905-4719-95c4-ad2c4f33855c");
                var jinaIds = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, "af69dcf5-f749-41ea-8b50-fe685facdd8b");

                packagesData.DaoDaoOrderCount = thisMonthData.Where(e => daodaoIds.Contains(e.LiveAnchorId)).Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count);
                packagesData.DaoDaoOrderCountChainRatio = DecimalExtension.CalculateChain(packagesData.DaoDaoOrderCount, lastMonthData.Where(e => daodaoIds.Contains(e.LiveAnchorId)).Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count)).Value;
                packagesData.DaoDaoOrderCountYearOnYear = DecimalExtension.CalculateChain(packagesData.DaoDaoOrderCount, lastYearData.Where(e => daodaoIds.Contains(e.LiveAnchorId)).Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count)).Value;
                packagesData.DaoDaoOrderCountProportion = DecimalExtension.CalculateTargetComplete(packagesData.DaoDaoOrderCount, packagesData.OrderCount).Value;

                packagesData.JinaOrderCount = thisMonthData.Where(e => jinaIds.Contains(e.LiveAnchorId)).Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count);
                packagesData.JinaOrderCountChainRatio = DecimalExtension.CalculateChain(packagesData.JinaOrderCount, lastMonthData.Where(e => jinaIds.Contains(e.LiveAnchorId)).Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count)).Value;
                packagesData.JinaOrderCountYearOnYear = DecimalExtension.CalculateChain(packagesData.JinaOrderCount, lastYearData.Where(e => jinaIds.Contains(e.LiveAnchorId)).Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count)).Value;
                packagesData.JinaOrderCountProportion = DecimalExtension.CalculateTargetComplete(packagesData.JinaOrderCount, packagesData.OrderCount).Value;

            }

            #endregion

            #region 实际件数

            packagesData.ActualOrderCount = packagesData.OrderCount - packagesData.RefundCount;
            packagesData.ActualOrderCountChainRatio = DecimalExtension.CalculateChain(packagesData.ActualOrderCount, lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value;
            packagesData.ActualOrderCountYearOnYear = DecimalExtension.CalculateChain(packagesData.ActualOrderCount, lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value;

            #endregion

            return packagesData;

        }
        /// <summary>
        /// 件单价看板
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<SinglePriceDataDto> GetSinglePriceAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            SinglePriceDataDto singlePriceData = new SinglePriceDataDto();
            var ids = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, liveAnchorId);
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month == 0 ? 1 : month);
            var thisMonthData = await livingDailyTakeGoodsService.GetTakeGoodsDataAsync(sequentialDate.StartDate, sequentialDate.EndDate, contentPlatformId, ids);
            var lastMonthData = await livingDailyTakeGoodsService.GetTakeGoodsDataAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, contentPlatformId, ids);
            var lastYearData = await livingDailyTakeGoodsService.GetTakeGoodsDataAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, contentPlatformId, ids);

            #region 件单价

            singlePriceData.SinglePrice = DecimalExtension.Division(thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.TotalPrice), thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count)).Value;
            singlePriceData.SinglePriceChainRatio = DecimalExtension.CalculateChain(singlePriceData.SinglePrice, DecimalExtension.Division(lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.TotalPrice), lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count)).Value).Value;
            singlePriceData.SinglePriceYearOnYear = DecimalExtension.CalculateChain(singlePriceData.SinglePrice, DecimalExtension.Division(lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.TotalPrice), lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count)).Value).Value;

            #endregion

            #region 实际件单价

            singlePriceData.ActualSinglePrice = DecimalExtension.Division(thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.TotalPrice) - thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.TotalPrice),
                thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count) - thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value;
            var lastMonthSinglePrice = DecimalExtension.Division(lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.TotalPrice) - lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.TotalPrice),
                lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count) - lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value;
            var lastYearSinglePrice = DecimalExtension.Division(lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.TotalPrice) - lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.TotalPrice),
                lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder).Sum(e => e.Count) - lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value;
            singlePriceData.ActualSinglePriceChainRatio = DecimalExtension.CalculateChain(singlePriceData.ActualSinglePrice, lastMonthSinglePrice).Value;
            singlePriceData.ActualSinglePriceYearOnYear = DecimalExtension.CalculateChain(singlePriceData.ActualSinglePrice, lastYearSinglePrice).Value;

            #endregion

            #region 分组

            if (string.IsNullOrEmpty(liveAnchorId))
            {
                var daodaoIds = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, "f0a77257-c905-4719-95c4-ad2c4f33855c");
                var jinaIds = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, "af69dcf5-f749-41ea-8b50-fe685facdd8b");

                singlePriceData.DaoDaoActualSinglePrice = DecimalExtension.Division(thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && daodaoIds.Contains(e.LiveAnchorId)).Sum(e => e.TotalPrice), thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && daodaoIds.Contains(e.LiveAnchorId)).Sum(e => e.Count)).Value;
                singlePriceData.DaoDaoActualSinglePriceChainRatio = DecimalExtension.CalculateChain(singlePriceData.DaoDaoActualSinglePrice, DecimalExtension.Division(lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && daodaoIds.Contains(e.LiveAnchorId)).Sum(e => e.TotalPrice), lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && daodaoIds.Contains(e.LiveAnchorId)).Sum(e => e.Count)).Value).Value;
                singlePriceData.DaoDaoActualSinglePriceYearOnYear = DecimalExtension.CalculateChain(singlePriceData.DaoDaoActualSinglePrice, DecimalExtension.Division(lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && daodaoIds.Contains(e.LiveAnchorId)).Sum(e => e.TotalPrice), lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && daodaoIds.Contains(e.LiveAnchorId)).Sum(e => e.Count)).Value).Value;

                singlePriceData.JinaActualSinglePrice = DecimalExtension.Division(thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && jinaIds.Contains(e.LiveAnchorId)).Sum(e => e.TotalPrice), thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && jinaIds.Contains(e.LiveAnchorId)).Sum(e => e.Count)).Value;
                singlePriceData.JinaActualSinglePriceChainRatio = DecimalExtension.CalculateChain(singlePriceData.JinaActualSinglePrice, DecimalExtension.Division(lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && jinaIds.Contains(e.LiveAnchorId)).Sum(e => e.TotalPrice), lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && jinaIds.Contains(e.LiveAnchorId)).Sum(e => e.Count)).Value).Value;
                singlePriceData.JinaActualSinglePriceYearOnYear = DecimalExtension.CalculateChain(singlePriceData.JinaActualSinglePrice, DecimalExtension.Division(lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && jinaIds.Contains(e.LiveAnchorId)).Sum(e => e.TotalPrice), lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.CreateOrder && jinaIds.Contains(e.LiveAnchorId)).Sum(e => e.Count)).Value).Value;

            }

            #endregion

            #region 退款件单价

            singlePriceData.RefundSinglePrice = DecimalExtension.Division(thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.TotalPrice), thisMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value;
            singlePriceData.RefundSinglePriceChainRatio = DecimalExtension.CalculateChain(singlePriceData.RefundSinglePrice, DecimalExtension.Division(lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.TotalPrice), lastMonthData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value).Value;
            singlePriceData.RefundSinglePriceYearOnYear = DecimalExtension.CalculateChain(singlePriceData.RefundSinglePrice, DecimalExtension.Division(lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.TotalPrice), lastYearData.Where(e => e.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder).Sum(e => e.Count)).Value).Value;

            #endregion

            return singlePriceData;

        }


        /// <summary>
        /// 获取当月品类看板分析数据
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<CategoryAnalizeDataDto> GetCategoryAnalizeDataAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            CategoryAnalizeDataDto categoryAnalizeDataDto = new CategoryAnalizeDataDto();
            var ids = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, liveAnchorId);
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month == 0 ? 1 : month);
            var thisMonthData = await livingDailyTakeGoodsService.GetTakeGoodsAnalizeDataAsync(sequentialDate.StartDate, sequentialDate.EndDate, contentPlatformId, ids);
            var createOrderData = thisMonthData.Where(x => x.TakeGoodsType == (int)TakeGoodsType.CreateOrder);
            var totalCreateOrderQuantity = createOrderData.Sum(x => x.TakeGoodsQuantity);
            var totalCreateOrderGMV = createOrderData.Sum(x => x.TotalPrice);
            var refundOrderData = thisMonthData.Where(x => x.TakeGoodsType == (int)TakeGoodsType.ReturnBackOrder);
            var totalRefundOrderQuantity = refundOrderData.Sum(x => x.TakeGoodsQuantity);
            var totalRefundGMV = refundOrderData.Sum(x => x.TotalPrice);
            #region 下单
            //下单GMV占比分析
            categoryAnalizeDataDto.CreateOrderGMVAnalizeData = createOrderData.GroupBy(x => x.CategoryName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = e.Sum(e => e.TotalPrice).ToString(),
                Rate=DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TotalPrice), totalCreateOrderGMV).Value,
            }).OrderByDescending(x => Convert.ToDecimal(x.Value)).Take(10).ToList();

            //下单件数占比分析
            categoryAnalizeDataDto.CreateOrderNumAnalizeData = createOrderData.GroupBy(x => x.CategoryName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = e.Sum(e => e.TakeGoodsQuantity).ToString(),
                Rate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TakeGoodsQuantity), totalCreateOrderQuantity).Value,
            }).OrderByDescending(x => Convert.ToInt32(x.Value)).Take(10).ToList();

            //下单件单价分析
            categoryAnalizeDataDto.CreateOrderSinglePriceAnalizeData = createOrderData.GroupBy(x => x.CategoryName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = Math.Round(e.Sum(e => e.TotalPrice) / e.Sum(e => e.TakeGoodsQuantity), 2, MidpointRounding.AwayFromZero).ToString(),
            }).OrderByDescending(x => Convert.ToDecimal(x.Value)).Take(10).ToList();

            #endregion

            #region 退款
            //退款GMV占比分析
            categoryAnalizeDataDto.RefundGMVAnalizeData = refundOrderData.GroupBy(x => x.CategoryName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = e.Sum(e => e.TotalPrice).ToString(),
                Rate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TotalPrice), totalRefundGMV).Value,
            }).OrderByDescending(x => Convert.ToDecimal(x.Value)).Take(10).ToList();

            //退款件数占比分析
            categoryAnalizeDataDto.RefundNumAnalizeData = refundOrderData.GroupBy(x => x.CategoryName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = e.Sum(e => e.TakeGoodsQuantity).ToString(),
                Rate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TakeGoodsQuantity), totalRefundOrderQuantity).Value,
            }).OrderByDescending(x => Convert.ToInt32(x.Value)).Take(10).ToList();

            //退款件单价分析
            categoryAnalizeDataDto.RefundSinglePriceAnalizeData = refundOrderData.GroupBy(x => x.CategoryName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = Math.Round(e.Sum(e => e.TotalPrice) / e.Sum(e => e.TakeGoodsQuantity), 2, MidpointRounding.AwayFromZero).ToString(),
            }).OrderByDescending(x => Convert.ToDecimal(x.Value)).Take(10).ToList();

            #endregion
            #region 实际
            categoryAnalizeDataDto.ActualGMVAnalizeData = new List<BaseKeyValueAndPercentDto>();
            categoryAnalizeDataDto.ActualNumAnalizeData = new List<BaseKeyValueAndPercentDto>();
            categoryAnalizeDataDto.ActualSinglePriceAnalizeData = new List<BaseKeyValueAndPercentDto>();
            foreach (var x in categoryAnalizeDataDto.CreateOrderGMVAnalizeData)
            {
                BaseKeyValueAndPercentDto actualGmvAnalizeData = new BaseKeyValueAndPercentDto();
                BaseKeyValueAndPercentDto actualNumAnalizeData = new BaseKeyValueAndPercentDto();
                BaseKeyValueAndPercentDto actualSinglePriceAnalizeData = new BaseKeyValueAndPercentDto();
                //实际GMV占比分析
                var refundGMVValue = categoryAnalizeDataDto.RefundGMVAnalizeData.Where(z => z.Key == x.Key).FirstOrDefault();
                decimal refundGMV = 0.00M;
                if (refundGMVValue != null)
                {
                    refundGMV = Convert.ToDecimal(refundGMVValue.Value);
                }
                actualGmvAnalizeData.Key = x.Key;
                actualGmvAnalizeData.Value = (Convert.ToDecimal(x.Value) - refundGMV).ToString();
                actualGmvAnalizeData.Rate = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(actualGmvAnalizeData.Value), totalCreateOrderGMV-totalRefundGMV).Value;
                categoryAnalizeDataDto.ActualGMVAnalizeData.Add(actualGmvAnalizeData);

                //实际件数占比分析
                var createOrderNumAnalize = categoryAnalizeDataDto.CreateOrderNumAnalizeData.Where(z => z.Key == x.Key).FirstOrDefault();
                int createOrderNum = 0;
                if (createOrderNumAnalize != null)
                {
                    createOrderNum = Convert.ToInt32(createOrderNumAnalize.Value);
                }
                var refundOrderNumAnalize = categoryAnalizeDataDto.RefundNumAnalizeData.Where(z => z.Key == x.Key).FirstOrDefault();
                int refundOrderNum = 0;
                if (refundOrderNumAnalize!=null)
                {
                    refundOrderNum = Convert.ToInt32(refundOrderNumAnalize.Value);
                }
                actualNumAnalizeData.Key = x.Key;
                actualNumAnalizeData.Value = (createOrderNum - refundOrderNum).ToString();
                actualNumAnalizeData.Rate = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(actualNumAnalizeData.Value), totalCreateOrderQuantity - totalRefundOrderQuantity).Value;
                categoryAnalizeDataDto.ActualNumAnalizeData.Add(actualNumAnalizeData);

                //实际件单价分析
                var createOrderSinglePriceAnalizeData = categoryAnalizeDataDto.CreateOrderSinglePriceAnalizeData.Where(z => z.Key == x.Key).FirstOrDefault();
                decimal createOrderSinglePrice = 0.00M;
                if (createOrderSinglePriceAnalizeData != null)
                {
                    createOrderSinglePrice = Convert.ToDecimal(createOrderSinglePriceAnalizeData.Value);
                }
                var refundSinglePriceAnalizeData = categoryAnalizeDataDto.RefundSinglePriceAnalizeData.Where(z => z.Key == x.Key).FirstOrDefault();
                decimal refundOrderSinglePrice = 0.00M;
                if (refundSinglePriceAnalizeData != null)
                {
                    refundOrderSinglePrice = Convert.ToDecimal(refundSinglePriceAnalizeData.Value);
                }
                actualSinglePriceAnalizeData.Key = x.Key;
                actualSinglePriceAnalizeData.Value = (createOrderSinglePrice - refundOrderSinglePrice).ToString();
                categoryAnalizeDataDto.ActualSinglePriceAnalizeData.Add(actualSinglePriceAnalizeData);
            }
            #endregion

            return categoryAnalizeDataDto;

        }


        /// <summary>
        /// 获取当月品牌看板分析数据
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<BrandAnalizeDataDto> GetBrandAnalizeDataAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            BrandAnalizeDataDto brandAnalizeDataDto = new BrandAnalizeDataDto();
            var ids = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, liveAnchorId);
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month == 0 ? 1 : month);
            var thisMonthData = await livingDailyTakeGoodsService.GetTakeGoodsAnalizeDataAsync(sequentialDate.StartDate, sequentialDate.EndDate, contentPlatformId, ids);
            var createOrderData = thisMonthData.Where(x => x.TakeGoodsType == (int)TakeGoodsType.CreateOrder);
            //下单GMV TOP20
            brandAnalizeDataDto.TopCreateOrderGMVDtoList = createOrderData.GroupBy(x => x.BrandName).Select(e => new TopCreateOrderGMVDto
            {
                BrandName = e.Key,
                CreateOrderGMV = e.Sum(e => e.TotalPrice),
                CreateOrderQuantity = e.Sum(e => e.TakeGoodsQuantity),
                SinglePrice = Math.Round((e.Sum(e => e.TotalPrice) / e.Sum(e => e.TakeGoodsQuantity)), 2, MidpointRounding.AwayFromZero)
            }).OrderByDescending(x => x.CreateOrderGMV).Take(10).ToList();
            //下单GMV占比分析
            brandAnalizeDataDto.CreateOrderGMVAnalizeData = createOrderData.GroupBy(x => x.BrandName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = e.Sum(e => e.TotalPrice).ToString(),
            }).OrderByDescending(x => Convert.ToDecimal(x.Value)).Take(10).ToList();

            //下单件数占比分析
            brandAnalizeDataDto.CreateOrderNumAnalizeData = createOrderData.GroupBy(x => x.BrandName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = e.Sum(e => e.TakeGoodsQuantity).ToString(),
            }).OrderByDescending(x => Convert.ToInt32(x.Value)).Take(10).ToList();

            //下单件单价分析
            brandAnalizeDataDto.CreateOrderSinglePriceAnalizeData = createOrderData.GroupBy(x => x.BrandName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = Math.Round(e.Sum(e => e.TotalPrice) / e.Sum(e => e.TakeGoodsQuantity), 2, MidpointRounding.AwayFromZero).ToString(),
            }).OrderByDescending(x => Convert.ToDecimal(x.Value)).Take(10).ToList();


            return brandAnalizeDataDto;

        }

        /// <summary>
        /// 获取当月品项看板分析数据
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<BrandAnalizeDataDto> GetItemDetailsAnalizeDataAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            BrandAnalizeDataDto brandAnalizeDataDto = new BrandAnalizeDataDto();
            var ids = await liveAnchorService.GetLiveAnchorIdsByContentPlatformIdAndBaseId(contentPlatformId, liveAnchorId);
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month == 0 ? 1 : month);
            var thisMonthData = await livingDailyTakeGoodsService.GetTakeGoodsAnalizeDataAsync(sequentialDate.StartDate, sequentialDate.EndDate, contentPlatformId, ids);
            var createOrderData = thisMonthData.Where(x => x.TakeGoodsType == (int)TakeGoodsType.CreateOrder);
            //下单GMV TOP20
            brandAnalizeDataDto.TopCreateOrderGMVDtoList = createOrderData.GroupBy(x => x.ItemDetailsName).Select(e => new TopCreateOrderGMVDto
            {
                BrandName = e.Key,
                CreateOrderGMV = e.Sum(e => e.TotalPrice),
                CreateOrderQuantity = e.Sum(e => e.TakeGoodsQuantity),
                SinglePrice = Math.Round((e.Sum(e => e.TotalPrice) / e.Sum(e => e.TakeGoodsQuantity)), 2, MidpointRounding.AwayFromZero)
            }).OrderByDescending(x => x.CreateOrderGMV).Take(10).ToList();
            //下单GMV占比分析
            brandAnalizeDataDto.CreateOrderGMVAnalizeData = createOrderData.GroupBy(x => x.ItemDetailsName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = e.Sum(e => e.TotalPrice).ToString(),
            }).OrderByDescending(x => Convert.ToDecimal(x.Value)).Take(10).ToList();

            //下单件数占比分析
            brandAnalizeDataDto.CreateOrderNumAnalizeData = createOrderData.GroupBy(x => x.ItemDetailsName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = e.Sum(e => e.TakeGoodsQuantity).ToString(),
            }).OrderByDescending(x => Convert.ToInt32(x.Value)).Take(10).ToList();

            //下单件单价分析
            brandAnalizeDataDto.CreateOrderSinglePriceAnalizeData = createOrderData.GroupBy(x => x.ItemDetailsName).Select(e => new BaseKeyValueAndPercentDto
            {
                Key = e.Key,
                Value = Math.Round(e.Sum(e => e.TotalPrice) / e.Sum(e => e.TakeGoodsQuantity), 2, MidpointRounding.AwayFromZero).ToString(),
            }).OrderByDescending(x => Convert.ToDecimal(x.Value)).Take(10).ToList();


            return brandAnalizeDataDto;

        }

        /// <summary>
        /// 计算时间进度
        /// </summary>
        /// <param name="performanceTarget"></param>
        /// <param name="currentPerformance"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        private PerformanceScheduleDto CalculateSchedule(decimal performanceTarget, decimal currentPerformance, int year, int month)
        {
            PerformanceScheduleDto performanceScheduleDto = new PerformanceScheduleDto();
            if (performanceTarget == 0m || currentPerformance == 0m)
            {
                performanceScheduleDto.ContrastTimeSchedule = 0;
                performanceScheduleDto.PerformanceDeviation = 0;
                performanceScheduleDto.ResidueTimeNeedCompletePerformance = 0;
                return performanceScheduleDto;
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
            performanceScheduleDto.ContrastTimeSchedule = performanceSchedule - timeSchedule;
            performanceScheduleDto.PerformanceDeviation = Math.Round(performanceTarget * (timeSchedule - performanceSchedule) / 100, 2);
            performanceScheduleDto.ResidueTimeNeedCompletePerformance = timeSchedule == 100m ? performanceTarget-currentPerformance>0? performanceTarget - currentPerformance:0 : Math.Round((performanceTarget - currentPerformance) / (totalDay - nowDay), 2, MidpointRounding.AwayFromZero);
            return performanceScheduleDto;

        }
        /// <summary>
        /// 填充空日期数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private List<GroupTakeGoodsDataDto> FillDate(int year, int month, List<GroupTakeGoodsDataDto> dataList)
        {
            List<GroupTakeGoodsDataDto> list = new List<GroupTakeGoodsDataDto>();
            var totalDays = DateTime.DaysInMonth(year, month);
            for (int i = 1; i < totalDays + 1; i++)
            {
                GroupTakeGoodsDataDto item = new GroupTakeGoodsDataDto();
                item.Date = i;
                item.OrderGMV = dataList.Where(e => e.Date == i).Select(e => e.OrderGMV).SingleOrDefault();
                item.QianChuanPutIn = dataList.Where(e => e.Date == i).Select(e => e.QianChuanPutIn).SingleOrDefault();
                item.RefundGMV = dataList.Where(e => e.Date == i).Select(e => e.RefundGMV).SingleOrDefault();
                item.OrderPackages = dataList.Where(e => e.Date == i).Select(e => e.OrderPackages).SingleOrDefault();
                item.RefundPackages = dataList.Where(e => e.Date == i).Select(e => e.RefundPackages).SingleOrDefault();
                item.SinglePrice = dataList.Where(e => e.Date == i).Select(e => e.SinglePrice).SingleOrDefault();
                item.RefundSinglePrice = dataList.Where(e => e.Date == i).Select(e => e.RefundSinglePrice).SingleOrDefault();
                list.Add(item);
            }
            return list;
        }
        #endregion

    }
}
