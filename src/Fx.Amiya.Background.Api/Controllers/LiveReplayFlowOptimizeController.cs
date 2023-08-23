using Fx.Amiya.Background.Api.Vo.LiveReplayFlowOptimize.Input;
using Fx.Amiya.Background.Api.Vo.LiveReplayFlowOptimize.Result;
using Fx.Amiya.Background.Api.Vo.LiveReplayProductDealData.Result;
using Fx.Amiya.Dto.LiveReplayFlowOptimize.Input;
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
    /// 直播分析-流量优化
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveReplayFlowOptimizeController : ControllerBase
    {
        private readonly ILiveReplayFlowOptimizeService liveReplayFlowOptimizeService;
        private readonly ILiveReplayService liveReplayService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="liveReplayFlowOptimizeService"></param>
        /// <param name="liveReplayService"></param>
        public LiveReplayFlowOptimizeController(ILiveReplayFlowOptimizeService liveReplayFlowOptimizeService, ILiveReplayService liveReplayService)
        {
            this.liveReplayFlowOptimizeService = liveReplayFlowOptimizeService;
            this.liveReplayService = liveReplayService;
        }

        /// <summary>
        /// 获取信息(非分页)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getListWithPage")]
        public async Task<ResultData<List<LiveReplayFlowOptimizeDataVo>>> GetListWithPageAsync([FromQuery] QueryLiveReplayFlowOptimizeDataVo query)
        {
            List<LiveReplayFlowOptimizeDataVo> resultList = new List<LiveReplayFlowOptimizeDataVo>();
            QueryLiveReplayFlowOptimizeDataDto queryLiveReplayFlowOptimizeDataDto = new QueryLiveReplayFlowOptimizeDataDto();
            queryLiveReplayFlowOptimizeDataDto.LiveReplayId = query.LiveReplayId;
            queryLiveReplayFlowOptimizeDataDto.Valid = query.Valid;
            queryLiveReplayFlowOptimizeDataDto.KeyWord = query.KeyWord;
            var replayList = await liveReplayFlowOptimizeService.GetListAsync(queryLiveReplayFlowOptimizeDataDto);
            resultList = replayList.Select(e => new LiveReplayFlowOptimizeDataVo
            {
                Id = e.Id,
                LiveReplayId = e.LiveReplayId,
                FlowSource = e.FlowSource,
                Proportion = e.Proportion,
                DrainageCount = e.DrainageCount,
                LastDrainageCount = e.LastDrainageCount,
                LastDrainageProportion = e.LastDrainageProportion,
                ProblemAnalysis = e.ProblemAnalysis,
                LaterSolution=e.LaterSolution,
                Sort = e.Sort,
            }).ToList();
            return ResultData<List<LiveReplayFlowOptimizeDataVo>>.Success().AddData("data", resultList);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="addVoList"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(List<AddLiveReplayFlowOptimizeDataVo> addVoList)
        {
            List<AddLiveReplayFlowOptimizeDataDto> addLiveReplayProductDealDataDtos = new List<AddLiveReplayFlowOptimizeDataDto>();
            foreach (var addVo in addVoList)
            {
                AddLiveReplayFlowOptimizeDataDto liveReplayFlowOptimizeData = new AddLiveReplayFlowOptimizeDataDto();
                liveReplayFlowOptimizeData.LiveReplayId = addVo.LiveReplayId;
                liveReplayFlowOptimizeData.FlowSource = addVo.FlowSource;
                liveReplayFlowOptimizeData.Proportion = addVo.Proportion;
                liveReplayFlowOptimizeData.DrainageCount = addVo.DrainageCount;
                liveReplayFlowOptimizeData.LastDrainageCount = addVo.LastDrainageCount;
                liveReplayFlowOptimizeData.LastDrainageProportion = addVo.LastDrainageProportion;
                liveReplayFlowOptimizeData.ProblemAnalysis = addVo.ProblemAnalysis;
                liveReplayFlowOptimizeData.LaterSolution = addVo.LaterSolution;
                liveReplayFlowOptimizeData.Sort = addVo.Sort;
                addLiveReplayProductDealDataDtos.Add(liveReplayFlowOptimizeData);
            }
            await liveReplayFlowOptimizeService.AddListAsync(addLiveReplayProductDealDataDtos);
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
            await liveReplayFlowOptimizeService.DeleteByIdListAsync(liveReplayId);
            return ResultData.Success();
        }

        /// <summary>
        /// 根据直播主播id获取流量优化数据自动填写
        /// </summary>
        /// <param name="replayId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultData<AutoWriteFlowOptimizeDataVo>> GetAutoWriteDataAsync(string replayId)
        {
            var lastReplayId = await liveReplayService.GetLastLiveReplayId(replayId);
            AutoWriteFlowOptimizeDataVo autoWriteFlowOptimizeDataVo = new AutoWriteFlowOptimizeDataVo();
            List<LiveReplayFlowOptimizeDataVo> resultList = new List<LiveReplayFlowOptimizeDataVo>();
            QueryLiveReplayFlowOptimizeDataDto queryLiveReplayFlowOptimizeDataDto = new QueryLiveReplayFlowOptimizeDataDto();
            queryLiveReplayFlowOptimizeDataDto.LiveReplayId = lastReplayId;
            queryLiveReplayFlowOptimizeDataDto.Valid = true;
            queryLiveReplayFlowOptimizeDataDto.KeyWord = "";
            var replayList = await liveReplayFlowOptimizeService.GetListAsync(queryLiveReplayFlowOptimizeDataDto);
            resultList = replayList.Select(e => new LiveReplayFlowOptimizeDataVo
            {
                LastDrainageCount=e.DrainageCount,
                LastDrainageProportion=e.Proportion,
                Sort=e.Sort
            }).ToList();
            autoWriteFlowOptimizeDataVo.LiveReplayFlowOptimizeDataVoList = resultList;
            return ResultData<AutoWriteFlowOptimizeDataVo>.Success().AddData("data", autoWriteFlowOptimizeDataVo);
        }
    }
}
