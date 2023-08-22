using Fx.Amiya.Background.Api.Vo.LiveReplayWordAnalyse.Input;
using Fx.Amiya.Background.Api.Vo.LiveReplayWordAnalyse.Result;
using Fx.Amiya.Dto.LiveReplayWordAnalyse.Input;
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
    /// 直播分析-话术内容
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveReplayWordAnalyseController : ControllerBase
    {
        private readonly ILiveReplayWordAnalyseService liveReplayWordAnalyseService;

        public LiveReplayWordAnalyseController(ILiveReplayWordAnalyseService liveReplayWordAnalyseService)
        {
            this.liveReplayWordAnalyseService = liveReplayWordAnalyseService;
        }




        /// <summary>
        /// 获取信息(非分页)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getListWithPage")]
        public async Task<ResultData<List<LiveReplayWordAnalyseDataVo>>> GetListWithPageAsync([FromQuery] QueryLiveReplayWordAnalyseDataVo query)
        {
            List<LiveReplayWordAnalyseDataVo> resultList = new List<LiveReplayWordAnalyseDataVo>();
            QueryLiveReplayWordAnalyseDataDto queryLiveReplayWordAnalyseDataDto = new QueryLiveReplayWordAnalyseDataDto();
            queryLiveReplayWordAnalyseDataDto.LiveReplayId = query.LiveReplayId;
            queryLiveReplayWordAnalyseDataDto.Valid = query.Valid;
            queryLiveReplayWordAnalyseDataDto.KeyWord = query.KeyWord;
            var replayList = await liveReplayWordAnalyseService.GetListAsync(queryLiveReplayWordAnalyseDataDto);
            resultList = replayList.Select(e => new LiveReplayWordAnalyseDataVo
            {
                Id = e.Id,
                LiveReplayId = e.LiveReplayId,
                ReplayContent = e.ReplayContent,
                WordManifestation = e.WordManifestation,
                ProblemAnalysis = e.ProblemAnalysis,
                LaterSolution = e.LaterSolution,
                Sort = e.Sort,
            }).ToList();
            return ResultData<List<LiveReplayWordAnalyseDataVo>>.Success().AddData("data", resultList);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="addVoList"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(List<AddLiveReplayWordAnalyseDataVo> addVoList)
        {
            List<AddLiveReplayWordAnalyseDataDto> addLiveReplayProductDealDataDtos = new List<AddLiveReplayWordAnalyseDataDto>();
            foreach (var addVo in addVoList)
            {
                AddLiveReplayWordAnalyseDataDto liveReplayWordAnalyseData = new AddLiveReplayWordAnalyseDataDto();
                liveReplayWordAnalyseData.LiveReplayId = addVo.LiveReplayId;
                liveReplayWordAnalyseData.ReplayContent = addVo.ReplayContent;
                liveReplayWordAnalyseData.WordManifestation = addVo.WordManifestation;
                liveReplayWordAnalyseData.ProblemAnalysis = addVo.ProblemAnalysis;
                liveReplayWordAnalyseData.LaterSolution = addVo.LaterSolution;
                liveReplayWordAnalyseData.Sort = addVo.Sort;
                addLiveReplayProductDealDataDtos.Add(liveReplayWordAnalyseData);
            }
            await liveReplayWordAnalyseService.AddListAsync(addLiveReplayProductDealDataDtos);
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
            await liveReplayWordAnalyseService.DeleteByIdListAsync(liveReplayId);
            return ResultData.Success();
        }

        
    }
}
