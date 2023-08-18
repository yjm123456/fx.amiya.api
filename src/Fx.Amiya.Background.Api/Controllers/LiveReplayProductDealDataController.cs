using Fx.Amiya.Background.Api.Vo.LiveReplayProductDealData.Input;
using Fx.Amiya.Background.Api.Vo.LiveReplayProductDealData.Result;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplayProductDealData.Input;
using Fx.Amiya.Dto.LiveRepley;
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

        public LiveReplayProductDealDataController(ILiveReplayProductDealDataService liveReplayProductDealDataService)
        {
            this.liveReplayProductDealDataService = liveReplayProductDealDataService;
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
    }
}
