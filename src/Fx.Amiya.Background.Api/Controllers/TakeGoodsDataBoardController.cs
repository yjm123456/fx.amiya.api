using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using Fx.Amiya.Background.Api.Vo.TakeGoods.Input;
using Fx.Amiya.Background.Api.Vo.TakeGoods.Result;
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
    /// 带货看板数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class TakeGoodsDataBoardController : ControllerBase
    {
        private readonly ITakeGoodsDataBoardService takeGoodsDataBoardService;

        public TakeGoodsDataBoardController(ITakeGoodsDataBoardService takeGoodsDataBoardService)
        {
            this.takeGoodsDataBoardService = takeGoodsDataBoardService;
        }
        #region GMV看板

        /// <summary>
        /// 获取GMV看板数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("gmvData")]
        public async Task<ResultData<GMVDataVo>> GetGMVDataAsync([FromQuery] QueryGmvDataVo query)
        {
            GMVDataVo result = new GMVDataVo();
            var data = await takeGoodsDataBoardService.GetGMVDataAsync(query.ContentPlatformId, query.LiveAnchorId, query.Year, query.Month);
            result.OrderGmv = data.OrderGmv;
            result.OrderGmvCompleteRate = data.OrderGmvCompleteRate;
            result.OrderGMVChainRatio = data.OrderGMVChainRatio;
            result.OrderGMVYearOnYear = data.OrderGMVYearOnYear;
            result.OrderGMVToDateSchedule = data.OrderGMVToDateSchedule;
            result.OrderGMVDeviation = data.OrderGMVDeviation;
            result.LaterCompleteEveryDayOrderGMV = data.LaterCompleteEveryDayOrderGMV;
            result.QianChuanPutIn = data.QianChuanPutIn;
            result.QianChuanPutInCompleteRate = data.QianChuanPutInCompleteRate;
            result.QianChuanPutInChainRatio = data.QianChuanPutInChainRatio;
            result.QianChuanPutInYearOnYear = data.QianChuanPutInYearOnYear;
            result.QianChuanToDateSchedule = data.QianChuanToDateSchedule;
            result.QianChuanDeviation = data.QianChuanDeviation;
            result.LaterCompleteEveryDayQianChuan = data.LaterCompleteEveryDayQianChuan;
            result.DaoDaoOrderGmv = data.DaoDaoOrderGmv;
            result.DaoDaoOrderGmvCompleteRate = data.DaoDaoOrderGmvCompleteRate;
            result.DaoDaoOrderGMVChainRatio = data.DaoDaoOrderGMVChainRatio;
            result.DaoDaoOrderGMVYearOnYear = data.DaoDaoOrderGMVYearOnYear;
            result.DaoDaoGMVProportion = data.DaoDaoGMVProportion;
            result.DaoDaoOrderGMVToDateSchedule = data.DaoDaoOrderGMVToDateSchedule;
            result.DaoDaoOrderGMVDeviation = data.DaoDaoOrderGMVDeviation;
            result.LaterCompleteEveryDayDaoDaoOrderGMV = data.LaterCompleteEveryDayDaoDaoOrderGMV;
            result.JiNaOrderGmv = data.JiNaOrderGmv;
            result.JiNaOrderGmvCompleteRate = data.JiNaOrderGmvCompleteRate;
            result.JiNaOrderGMVChainRatio = data.JiNaOrderGMVChainRatio;
            result.JiNaOrderGMVYearOnYear = data.JiNaOrderGMVYearOnYear;
            result.JinaGMVProportion = data.JinaGMVProportion;
            result.JinaOrderGMVToDateSchedule = data.JinaOrderGMVToDateSchedule;
            result.JinaOrderGMVDeviation = data.JinaOrderGMVDeviation;
            result.JInaLaterCompleteEveryDayOrderGMV = data.LaterCompleteEveryDayJInaOrderGMV;
            result.RefunGMV = data.RefunGMV;
            result.RefunGMVCompleteRate = data.RefunGMVCompleteRate;
            result.RefunGMVChainRatio = data.RefunGMVChainRatio;
            result.RefunGMVYearOnYear = data.RefunGMVYearOnYear;
            return ResultData<GMVDataVo>.Success().AddData("gmvData", result);
        }
        /// <summary>
        /// 获取件数看板数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("packagesData")]
        public async Task<ResultData<PackagesDataVo>> GetPackagesDataAsync([FromQuery] QueryGmvDataVo query)
        {
            PackagesDataVo result = new PackagesDataVo();
            var data = await takeGoodsDataBoardService.GetPackagesDataAsync(query.ContentPlatformId, query.LiveAnchorId, query.Year, query.Month);
            result.OrderCount = data.OrderCount;
            result.OrderCountChainRatio = data.OrderCountChainRatio;
            result.OrderCountYearOnYear = data.OrderCountYearOnYear;
            result.ActualOrderCount = data.ActualOrderCount;
            result.ActualOrderCountChainRatio = data.ActualOrderCountChainRatio;
            result.ActualOrderCountYearOnYear = data.ActualOrderCountYearOnYear;
            result.DaoDaoOrderCount = data.DaoDaoOrderCount;
            result.DaoDaoOrderCountChainRatio = data.DaoDaoOrderCountChainRatio;
            result.DaoDaoOrderCountYearOnYear = data.DaoDaoOrderCountYearOnYear;
            result.DaoDaoOrderCountProportion = data.DaoDaoOrderCountProportion;
            result.JinaOrderCount = data.JinaOrderCount;
            result.JinaOrderCountChainRatio = data.JinaOrderCountChainRatio;
            result.JinaOrderCountYearOnYear = data.JinaOrderCountYearOnYear;
            result.JinaOrderCountProportion = data.JinaOrderCountProportion;
            result.RefundCount = data.RefundCount;
            result.RefundCountChainRatio = data.RefundCountChainRatio;
            result.RefundCountYearOnYear = data.RefundCountYearOnYear;
            return ResultData<PackagesDataVo>.Success().AddData("packagesData", result);
        }
        /// <summary>
        /// 获取件单价看板数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("singlePriceData")]
        public async Task<ResultData<SinglePriceDataVo>> GetSinglePriceAsync([FromQuery] QueryGmvDataVo query)
        {
            SinglePriceDataVo result = new SinglePriceDataVo();
            var data = await takeGoodsDataBoardService.GetSinglePriceAsync(query.ContentPlatformId, query.LiveAnchorId, query.Year, query.Month);
            result.SinglePrice = data.SinglePrice;
            result.SinglePriceChainRatio = data.SinglePriceChainRatio;
            result.SinglePriceYearOnYear = data.SinglePriceYearOnYear;
            result.ActualSinglePrice = data.ActualSinglePrice;
            result.ActualSinglePriceChainRatio = data.ActualSinglePriceChainRatio;
            result.ActualSinglePriceYearOnYear = data.ActualSinglePriceYearOnYear;
            result.DaoDaoActualSinglePrice = data.DaoDaoActualSinglePrice;
            result.DaoDaoActualSinglePriceChainRatio = data.DaoDaoActualSinglePriceChainRatio;
            result.DaoDaoActualSinglePriceYearOnYear = data.DaoDaoActualSinglePriceYearOnYear;
            result.JinaActualSinglePrice = data.JinaActualSinglePrice;
            result.JinaActualSinglePriceChainRatio = data.JinaActualSinglePriceChainRatio;
            result.JinaActualSinglePriceYearOnYear = data.JinaActualSinglePriceYearOnYear;
            result.RefundSinglePrice = data.RefundSinglePrice;
            result.RefundSinglePriceChainRatio = data.RefundSinglePriceChainRatio;
            result.RefundSinglePriceYearOnYear = data.RefundSinglePriceYearOnYear;
            return ResultData<SinglePriceDataVo>.Success().AddData("singlePrice", result);
        }
        /// <summary>
        /// 获取业绩趋势折线图数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("gmvDataBrokenLineData")]
        public async Task<ResultData<GMVDataBrokenLineVo>> GetGMVDataBrokenLineDataAsync([FromQuery] QueryGmvDataVo query)
        {
            GMVDataBrokenLineVo result = new GMVDataBrokenLineVo();
            var data = await takeGoodsDataBoardService.GetGMVDataBrokenLineDataAsync(query.ContentPlatformId, query.LiveAnchorId, query.Year, query.Month);
            result.OrderGMVBrokenLineList = data.OrderGMVBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            result.QianChuanPutInBrokenLineList = data.QianChuanPutInBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            result.RefundGMVBrokenLineList = data.RefundGMVBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            result.OrderPackagesBrokenLineList = data.OrderPackagesBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            result.RefundPackagesBrokenLineList = data.RefundPackagesBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            result.SinglePriceBrokenLineList = data.SinglePriceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            result.RefundSinglePriceBrokenLineList = data.RefundSinglePriceBrokenLineList.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            return ResultData<GMVDataBrokenLineVo>.Success().AddData("brokenLineData", result);
        }


        /// <summary>
        /// 获取品类看板分析数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("categoryAnalizeData")]
        public async Task<ResultData<CategoryAnalizeDataVo>> GetCategoryAnalizeDataAsync([FromQuery] QueryGmvDataVo query)
        {
            CategoryAnalizeDataVo result = new CategoryAnalizeDataVo();
            var data = await takeGoodsDataBoardService.GetCategoryAnalizeDataAsync(query.ContentPlatformId, query.LiveAnchorId, query.Year, query.Month);
            result.ActualGMVAnalizeData = data.ActualGMVAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();
            result.ActualNumAnalizeData = data.ActualNumAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.ActualSinglePriceAnalizeData = data.ActualSinglePriceAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.RefundGMVAnalizeData = data.RefundGMVAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.RefundNumAnalizeData = data.RefundNumAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Rate = e.Rate,
                Name = e.Value,
            }).ToList();

            result.RefundSinglePriceAnalizeData = data.RefundSinglePriceAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.CreateOrderGMVAnalizeData = data.CreateOrderGMVAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.CreateOrderNumAnalizeData = data.CreateOrderNumAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.CreateOrderSinglePriceAnalizeData = data.CreateOrderSinglePriceAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();


            return ResultData<CategoryAnalizeDataVo>.Success().AddData("categoryAnalizeData", result);
        }

        /// <summary>
        /// 获取品牌看板分析数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("brandAnalizeData")]
        public async Task<ResultData<BrandAnalizeDataVo>> GetbrandAnalizeDataAsync([FromQuery] QueryGmvDataVo query)
        {
            BrandAnalizeDataVo result = new BrandAnalizeDataVo();
            var data = await takeGoodsDataBoardService.GetBrandAnalizeDataAsync(query.ContentPlatformId, query.LiveAnchorId, query.Year, query.Month);
            result.TopCreateOrderGMVDtoList = data.TopCreateOrderGMVDtoList.Select(e => new TopCreateOrderGMVVo
            {
                BrandName = e.BrandName,
                CreateOrderGMV = e.CreateOrderGMV,
                CreateOrderQuantity = e.CreateOrderQuantity,
                SinglePrice = e.SinglePrice
            }).ToList();
            result.CreateOrderGMVAnalizeData = data.CreateOrderGMVAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.CreateOrderNumAnalizeData = data.CreateOrderNumAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.CreateOrderSinglePriceAnalizeData = data.CreateOrderSinglePriceAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();


            return ResultData<BrandAnalizeDataVo>.Success().AddData("brandAnalizeData", result);
        }

        /// <summary>
        /// 获取品项看板分析数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("itemDetailsAnalizeData")]
        public async Task<ResultData<BrandAnalizeDataVo>> GetItemDetailsAnalizeDataAsync([FromQuery] QueryGmvDataVo query)
        {
            BrandAnalizeDataVo result = new BrandAnalizeDataVo();
            var data = await takeGoodsDataBoardService.GetItemDetailsAnalizeDataAsync(query.ContentPlatformId, query.LiveAnchorId, query.Year, query.Month);
            result.TopCreateOrderGMVDtoList = data.TopCreateOrderGMVDtoList.Select(e => new TopCreateOrderGMVVo
            {
                BrandName = e.BrandName,
                CreateOrderGMV = e.CreateOrderGMV,
                CreateOrderQuantity = e.CreateOrderQuantity,
                SinglePrice = e.SinglePrice
            }).ToList();
            result.CreateOrderGMVAnalizeData = data.CreateOrderGMVAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.CreateOrderNumAnalizeData = data.CreateOrderNumAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();

            result.CreateOrderSinglePriceAnalizeData = data.CreateOrderSinglePriceAnalizeData.Select(e => new BaseIdNameAndRateVo
            {
                Id = e.Key,
                Name = e.Value,
                Rate = e.Rate,
            }).ToList();


            return ResultData<BrandAnalizeDataVo>.Success().AddData("itemDetailsAnalizeData", result);
        }

        #endregion
    }
}
