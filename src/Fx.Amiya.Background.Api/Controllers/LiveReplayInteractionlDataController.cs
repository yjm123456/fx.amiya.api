using Fx.Amiya.Background.Api.Vo.LiveReplayInteractionlData.Input;
using Fx.Amiya.Background.Api.Vo.LiveReplayInteractionlData.Result;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplayInteractionlData.Input;
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
    /// 直播复盘-互动数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LiveReplayInteractionlDataController : ControllerBase
    {
        private readonly ILiveReplayInteractionlDataService liveReplayInteractionlDataService;
        private readonly ILiveReplayService liveReplayService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="liveReplayInteractionlDataService"></param>
        /// <param name="liveReplayService"></param>
        public LiveReplayInteractionlDataController(ILiveReplayInteractionlDataService liveReplayInteractionlDataService, 
            ILiveReplayService liveReplayService)
        {
            this.liveReplayService = liveReplayService;
            this.liveReplayInteractionlDataService = liveReplayInteractionlDataService;
        }
        /// <summary>
        /// 获取信息(非分页)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getListWithPage")]
        public async Task<ResultData<List<LiveReplayInteractionlDataVo>>> GetListWithPageAsync([FromQuery] QueryReplayInteractionlDataVo query)
        {
            List<LiveReplayInteractionlDataVo> resultList = new List<LiveReplayInteractionlDataVo>();
            QueryLiveReplayInteractionlDataDto queryLiveReplayInteractionlDataDto = new QueryLiveReplayInteractionlDataDto();
            queryLiveReplayInteractionlDataDto.LiveReplayId = query.LiveReplayId;
            queryLiveReplayInteractionlDataDto.Valid = query.Valid;
            queryLiveReplayInteractionlDataDto.KeyWord = query.KeyWord;
            var replayList = await liveReplayInteractionlDataService.GetListAsync(queryLiveReplayInteractionlDataDto);
            resultList = replayList.Select(e => new LiveReplayInteractionlDataVo
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
            return ResultData<List<LiveReplayInteractionlDataVo>>.Success().AddData("data", resultList);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="addVoList"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(List<AddLiveReplayInteractionlDataVo> addVoList)
        {
            List<AddLiveReplayInteractionlDataDto> addLiveReplayInteractionlDataDtos = new List<AddLiveReplayInteractionlDataDto>();
            foreach (var addVo in addVoList)
            {
                AddLiveReplayInteractionlDataDto liveReplayInteractionlData = new AddLiveReplayInteractionlDataDto();
                liveReplayInteractionlData.LiveReplayId = addVo.LiveReplayId;
                liveReplayInteractionlData.ReplayTarget = addVo.ReplayTarget;
                liveReplayInteractionlData.DataTarget = addVo.DataTarget;
                liveReplayInteractionlData.LastLivingData = addVo.LastLivingData;
                liveReplayInteractionlData.LastLivingCompare = addVo.LastLivingCompare;
                liveReplayInteractionlData.QuestionAnalize = addVo.QuestionAnalize;
                liveReplayInteractionlData.LaterPeriodSolution = addVo.LaterPeriodSolution;
                liveReplayInteractionlData.Sort = addVo.Sort;
                addLiveReplayInteractionlDataDtos.Add(liveReplayInteractionlData);
            }
            await liveReplayInteractionlDataService.AddListAsync(addLiveReplayInteractionlDataDtos);
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
            await liveReplayInteractionlDataService.DeleteByIdListAsync(liveReplayId);
            return ResultData.Success();
        }

        /// <summary>
        /// 根据直播主播id获取互动数据自动填写
        /// </summary>
        /// <param name="replayId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultData<AutoWriteInteractionlDataVo>> GetAutoWriteDataAsync(string replayId)
        {
            var lastReplayId = await liveReplayService.GetLastLiveReplayId(replayId);
            AutoWriteInteractionlDataVo autoWriteProductDealDataVo = new AutoWriteInteractionlDataVo();
            List<LiveReplayInteractionlDataVo> resultList = new List<LiveReplayInteractionlDataVo>();
            QueryLiveReplayInteractionlDataDto queryLiveReplayInteractionlDataDto = new QueryLiveReplayInteractionlDataDto();
            queryLiveReplayInteractionlDataDto.LiveReplayId = lastReplayId;
            queryLiveReplayInteractionlDataDto.Valid = true;
            queryLiveReplayInteractionlDataDto.KeyWord = "";
            var replayList = await liveReplayInteractionlDataService.GetListAsync(queryLiveReplayInteractionlDataDto);
            resultList = replayList.Select(e => new LiveReplayInteractionlDataVo
            {
                LiveReplayId = e.LiveReplayId,
                DataTarget = e.DataTarget,
                Sort = e.Sort,
            }).ToList();
            //互动数据同比数据赋值
            autoWriteProductDealDataVo.LiveReplayInfoInteractionlDataVoList = resultList;

            return ResultData<AutoWriteInteractionlDataVo>.Success().AddData("data", autoWriteProductDealDataVo);
        }
    }
}
