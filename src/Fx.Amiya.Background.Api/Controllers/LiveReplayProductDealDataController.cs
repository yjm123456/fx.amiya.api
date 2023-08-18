using Fx.Amiya.Background.Api.Vo.LiveReplayProductDealData.Input;
using Fx.Amiya.Background.Api.Vo.LiveReplayProductDealData.Result;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplayProductDealData.Input;
using Fx.Amiya.Dto.LiveRepley;
using Fx.Amiya.Dto.LivingDailyTakeGoods.Input;
using Fx.Amiya.IService;
using Fx.Common;
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
    /// 直播复盘-成交数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LiveReplayProductDealDataController : ControllerBase
    {
        private readonly ILiveReplayProductDealDataService liveReplayProductDealDataService;
        private readonly ILivingDailyTakeGoodsService livingDailyTakeGoodsService;
        private readonly ILiveReplayService liveReplayService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="liveReplayProductDealDataService"></param>
        /// <param name="liveReplayService"></param>
        public LiveReplayProductDealDataController(ILiveReplayProductDealDataService liveReplayProductDealDataService, 
            ILivingDailyTakeGoodsService livingDailyTakeGoodsService,
            ILiveReplayService liveReplayService)
        {
            this.liveReplayService = liveReplayService;
            this.liveReplayProductDealDataService = liveReplayProductDealDataService;
            this.livingDailyTakeGoodsService = livingDailyTakeGoodsService;
        }
        /// <summary>
        /// 获取信息(非分页)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getListWithPage")]
        public async Task<ResultData<List<LiveReplayInfoProductDealDataVo>>> GetListWithPageAsync([FromQuery] QueryReplayProductDealDataVo query)
        {
            List<LiveReplayInfoProductDealDataVo> resultList = new List<LiveReplayInfoProductDealDataVo>();
            QueryLiveReplayProductDealDataDto queryLiveReplayProductDealDataDto = new QueryLiveReplayProductDealDataDto();
            queryLiveReplayProductDealDataDto.LiveReplayId = query.LiveReplayId;
            queryLiveReplayProductDealDataDto.Valid = query.Valid;
            queryLiveReplayProductDealDataDto.KeyWord = query.KeyWord;
            var replayList = await liveReplayProductDealDataService.GetListAsync(queryLiveReplayProductDealDataDto);
            resultList = replayList.Select(e => new LiveReplayInfoProductDealDataVo
            {
                Id = e.Id,
                LiveReplayId = e.LiveReplayId,
                ReplayTarget = e.ReplayTarget,
                DataTarget = e.DataTarget,
                LastLivingData = e.LastLivingData,
                LastLivingCompare = e.LastLivingCompare,
                QuestionAnalize = e.QuestionAnalize,
                LaterPeriodSolution = e.LaterPeriodSolution,
                Sort = e.Sort,
            }).ToList();
            return ResultData<List<LiveReplayInfoProductDealDataVo>>.Success().AddData("data", resultList);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="addVoList"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(List<AddLiveReplayProductDealDataVo> addVoList)
        {
            List<AddLiveReplayProductDealDataDto> addLiveReplayProductDealDataDtos = new List<AddLiveReplayProductDealDataDto>();
            foreach (var addVo in addVoList)
            {
                AddLiveReplayProductDealDataDto liveReplayProductDealData = new AddLiveReplayProductDealDataDto();
                liveReplayProductDealData.LiveReplayId = addVo.LiveReplayId;
                liveReplayProductDealData.ReplayTarget = addVo.ReplayTarget;
                liveReplayProductDealData.DataTarget = addVo.DataTarget;
                liveReplayProductDealData.LastLivingData = addVo.LastLivingData;
                liveReplayProductDealData.LastLivingCompare = addVo.LastLivingCompare;
                liveReplayProductDealData.QuestionAnalize = addVo.QuestionAnalize;
                liveReplayProductDealData.LaterPeriodSolution = addVo.LaterPeriodSolution;
                liveReplayProductDealData.Sort = addVo.Sort;
                addLiveReplayProductDealDataDtos.Add(liveReplayProductDealData);
            }
            await liveReplayProductDealDataService.AddListAsync(addLiveReplayProductDealDataDtos);
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
            await liveReplayProductDealDataService.DeleteByIdListAsync(liveReplayId);
            return ResultData.Success();
        }

        /// <summary>
        /// 根据直播主播id获取成交数据自动填写
        /// </summary>
        /// <param name="replayId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultData<AutoWriteProductDealDataVo>> GetAutoWriteDataAsync(string replayId)
        {
            var lastReplayId = await liveReplayService.GetLastLiveReplayId(replayId);
            AutoWriteProductDealDataVo autoWriteProductDealDataVo = new AutoWriteProductDealDataVo();
            List<LiveReplayInfoProductDealDataVo> resultList = new List<LiveReplayInfoProductDealDataVo>();
            QueryLiveReplayProductDealDataDto queryLiveReplayProductDealDataDto = new QueryLiveReplayProductDealDataDto();
            queryLiveReplayProductDealDataDto.LiveReplayId = lastReplayId;
            queryLiveReplayProductDealDataDto.Valid = true;
            queryLiveReplayProductDealDataDto.KeyWord = "";
            var replayList = await liveReplayProductDealDataService.GetListAsync(queryLiveReplayProductDealDataDto);
            resultList = replayList.Select(e => new LiveReplayInfoProductDealDataVo
            {
                LiveReplayId = e.LiveReplayId,
                DataTarget = e.DataTarget,
                Sort = e.Sort,
            }).ToList();
            //成交数据同比数据赋值
            autoWriteProductDealDataVo.LiveReplayInfoProductDealDataVoList = resultList;

            var thisReplayInfo = await liveReplayService.GetByIdAsync(replayId);
            DateTime liveDate = thisReplayInfo.LiveDate;
            QueryLivingDailyTakeGoodsDto queryLivingDailyTakeGoodsDto = new QueryLivingDailyTakeGoodsDto();
            queryLivingDailyTakeGoodsDto.Valid = true;
            queryLivingDailyTakeGoodsDto.StartDate = liveDate;
            queryLivingDailyTakeGoodsDto.EndDate = liveDate.Date.AddDays(1);
            queryLivingDailyTakeGoodsDto.PageNum = 1;
            queryLivingDailyTakeGoodsDto.PageSize = 999;
            var takeGoodsInfo = await livingDailyTakeGoodsService.GetListWithPageAsync(queryLivingDailyTakeGoodsDto);
            if (takeGoodsInfo.TotalCount > 0)
            {
                //当期成交量赋值
                autoWriteProductDealDataVo.DealNum = takeGoodsInfo.List.Sum(x => x.TakeGoodsQuantity);
                //当期成交额赋值
                autoWriteProductDealDataVo.DealPrice = takeGoodsInfo.List.Sum(x => x.TotalPrice);
            }

            return ResultData<AutoWriteProductDealDataVo>.Success().AddData("data", autoWriteProductDealDataVo);
        }
    }
}
