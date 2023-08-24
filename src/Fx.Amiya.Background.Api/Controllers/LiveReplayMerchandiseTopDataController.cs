using Fx.Amiya.Background.Api.Vo.LiveReplayMerchandiseTopData.Input;
using Fx.Amiya.Background.Api.Vo.LiveReplayMerchandiseTopData.Result;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplayMerchandiseTopData.Input;
using Fx.Amiya.Dto.LiveRepley;
using Fx.Amiya.Dto.LivingDailyTakeGoods.Input;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Common.Extensions;
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
    /// 直播复盘-单品TOP10数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LiveReplayMerchandiseTopDataController : ControllerBase
    {
        private readonly ILiveReplayMerchandiseTopDataService liveReplayMerchandiseTopDataService;
        private readonly ILivingDailyTakeGoodsService livingDailyTakeGoodsService;
        private readonly ILiveReplayService liveReplayService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="liveReplayMerchandiseTopDataService"></param>
        /// <param name="liveReplayService"></param>
        public LiveReplayMerchandiseTopDataController(ILiveReplayMerchandiseTopDataService liveReplayMerchandiseTopDataService,
            ILivingDailyTakeGoodsService livingDailyTakeGoodsService,
            ILiveReplayService liveReplayService)
        {
            this.liveReplayService = liveReplayService;
            this.liveReplayMerchandiseTopDataService = liveReplayMerchandiseTopDataService;
            this.livingDailyTakeGoodsService = livingDailyTakeGoodsService;
        }
        /// <summary>
        /// 获取信息(非分页)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getListWithPage")]
        public async Task<ResultData<List<LiveReplayMerchandiseTopDataVo>>> GetListWithPageAsync([FromQuery] QueryReplayMerchandiseTopDataDataVo query)
        {
            List<LiveReplayMerchandiseTopDataVo> resultList = new List<LiveReplayMerchandiseTopDataVo>();
            QueryLiveReplayMerchandiseTopDataDto queryLiveReplayMerchandiseTopDataDto = new QueryLiveReplayMerchandiseTopDataDto();
            queryLiveReplayMerchandiseTopDataDto.LiveReplayId = query.LiveReplayId;
            queryLiveReplayMerchandiseTopDataDto.Valid = query.Valid;
            queryLiveReplayMerchandiseTopDataDto.KeyWord = query.KeyWord;
            var replayList = await liveReplayMerchandiseTopDataService.GetListAsync(queryLiveReplayMerchandiseTopDataDto);
            resultList = replayList.Select(e => new LiveReplayMerchandiseTopDataVo
            {
                Id = e.Id,
                LiveReplayId = e.LiveReplayId,
                Sort = e.Sort,
                ItemId = e.ItemId,
                ItemName = e.ItemName,
                Gmv = e.Gmv,
                MerchandiseShowNum = e.MerchandiseShowNum,
                MerchandiseVisitNum = e.MerchandiseVisitNum,
                MerchandiseShowVisitRate = e.MerchandiseShowVisitRate,
                MerchandiseCreateOrderNum = e.MerchandiseCreateOrderNum,
                MerchandiseVisitCreateOrderRate = e.MerchandiseVisitCreateOrderRate,
                MerchandiseDealNum = e.MerchandiseDealNum,
                MerchandiseCreateOrderDealRate = e.MerchandiseCreateOrderDealRate,
                MerchandiseQuestion = e.MerchandiseQuestion,
            }).ToList();
            return ResultData<List<LiveReplayMerchandiseTopDataVo>>.Success().AddData("data", resultList);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="addVoList"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(List<AddLiveReplayMerchandiseTopDataVo> addVoList)
        {
            List<AddLiveReplayMerchandiseTopDataDto> addLiveReplayMerchandiseTopDataDtos = new List<AddLiveReplayMerchandiseTopDataDto>();
            foreach (var addVo in addVoList)
            {
                AddLiveReplayMerchandiseTopDataDto liveReplayMerchandiseTopData = new AddLiveReplayMerchandiseTopDataDto();
                liveReplayMerchandiseTopData.LiveReplayId = addVo.LiveReplayId;
                liveReplayMerchandiseTopData.ItemId = addVo.ItemId;
                liveReplayMerchandiseTopData.Gmv = addVo.Gmv;
                liveReplayMerchandiseTopData.MerchandiseShowNum = addVo.MerchandiseShowNum;
                liveReplayMerchandiseTopData.MerchandiseVisitNum = addVo.MerchandiseVisitNum;
                liveReplayMerchandiseTopData.MerchandiseShowVisitRate = addVo.MerchandiseShowVisitRate;
                liveReplayMerchandiseTopData.MerchandiseCreateOrderNum = addVo.MerchandiseCreateOrderNum;
                liveReplayMerchandiseTopData.MerchandiseVisitCreateOrderRate = addVo.MerchandiseVisitCreateOrderRate;
                liveReplayMerchandiseTopData.MerchandiseDealNum = addVo.MerchandiseDealNum;
                liveReplayMerchandiseTopData.MerchandiseCreateOrderDealRate = addVo.MerchandiseCreateOrderDealRate;
                liveReplayMerchandiseTopData.MerchandiseQuestion = addVo.MerchandiseQuestion;
                liveReplayMerchandiseTopData.Sort = addVo.Sort;
                addLiveReplayMerchandiseTopDataDtos.Add(liveReplayMerchandiseTopData);
            }
            await liveReplayMerchandiseTopDataService.AddListAsync(addLiveReplayMerchandiseTopDataDtos);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据直播复盘主表id删除
        /// </summary>
        /// <param name="liveReplayId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ResultData> DeleteAsync(string liveReplayId)
        {
            await liveReplayMerchandiseTopDataService.DeleteByIdListAsync(liveReplayId);
            return ResultData.Success();
        }

        /// <summary>
        /// 根据直播主播id获取单品TOP10数据自动填写
        /// </summary>
        /// <param name="replayId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultData<List<LiveReplayMerchandiseTopDataVo>>> GetAutoWriteDataAsync(string replayId)
        {
            var replayInfo = await liveReplayService.GetByIdAsync(replayId);
            List<LiveReplayMerchandiseTopDataVo> resultList = new List<LiveReplayMerchandiseTopDataVo>();
            var takeGoodsInfo = await livingDailyTakeGoodsService.GetTopTakeGoodsDateByLiveAnchorAsync(replayInfo.LiveDate, replayInfo.LiveDate.AddDays(1).AddMilliseconds(-1), replayInfo.ContentPlatformId, replayInfo.LiveAnchorId);

            var result = takeGoodsInfo.Select(e => new LiveReplayMerchandiseTopDataVo
            {
                Gmv = e.TotalPrice,
                LiveReplayId = replayId,
                ItemId = e.ItemId,
                ItemName = e.ItemName,
                MerchandiseCreateOrderNum = e.OrderNum,
                MerchandiseDealNum = e.TakeGoodsQuantity,
                MerchandiseCreateOrderDealRate = DecimalExtension.CalculateTargetComplete(e.TakeGoodsQuantity, e.OrderNum).Value,
            }).ToList();
            return ResultData<List<LiveReplayMerchandiseTopDataVo>>.Success().AddData("data", result);
        }
    }
}
