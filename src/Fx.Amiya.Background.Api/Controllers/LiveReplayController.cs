using Fx.Amiya.Background.Api.Vo.LiveReplay.Input;
using Fx.Amiya.Background.Api.Vo.LiveReplay.Result;
using Fx.Amiya.DbModels.Model;
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
    /// 直播复盘
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LiveReplayController : ControllerBase
    {
        private readonly ILiveReplayService liveReplayService;

        public LiveReplayController(ILiveReplayService liveReplayService)
        {
            this.liveReplayService = liveReplayService;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddLiveReplayVo addDto)
        {
            AddLiveReplayDto liveReplay = new AddLiveReplayDto();
            liveReplay.ContentPlatformId = addDto.ContentPlatformId;
            liveReplay.LiveAnchorId = addDto.LiveAnchorId;
            liveReplay.LiveDate = addDto.LiveDate;
            liveReplay.LiveDuration = addDto.LiveDuration;
            liveReplay.GMV = addDto.GMV;
            liveReplay.LivePersonnel =string.Join( ",", addDto.LivePersonnels);
            await liveReplayService.AddAsync(liveReplay);
            return ResultData.Success();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ResultData> DeleteAsync(string id)
        {
            await liveReplayService.DeleteAsync(id);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据id获取复盘表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<ResultData<LiveReplayInfoVo>> GetByIdAsync(string id)
        {
            var replay =await liveReplayService.GetByIdAsync(id);
            LiveReplayInfoVo liveReplayInfoVo = new LiveReplayInfoVo();
            liveReplayInfoVo.Id = replay.Id;
            liveReplayInfoVo.ContentPlatformId = replay.ContentPlatformId;
            liveReplayInfoVo.ContentPlatformName = replay.ContentPlatformName;
            liveReplayInfoVo.LiveAnchorId = replay.LiveAnchorId;
            liveReplayInfoVo.LiveAnchorName = replay.LiveAnchorName;
            liveReplayInfoVo.LiveDate = replay.LiveDate;
            liveReplayInfoVo.LiveDuration = replay.LiveDuration;
            liveReplayInfoVo.GMV = replay.GMV;
            liveReplayInfoVo.LivePersonnels = replay.LivePersonnel.Split(",").ToList();
            return ResultData<LiveReplayInfoVo>.Success().AddData("data", liveReplayInfoVo);
        }
        /// <summary>
        /// 分页获取信息
        /// </summary>
        /// <param name="valid"></param>
        /// <param name="keyWord"></param>
        /// <param name="date"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        [HttpGet("getListWithPage")]
        public async Task<ResultData<FxPageInfo<LiveReplayInfoVo>>> GetListWithPageAsync([FromQuery]QueryReplayVo query)
        {
            FxPageInfo<LiveReplayInfoVo> fxPageInfo = new FxPageInfo<LiveReplayInfoVo>();
            var replayList =await liveReplayService.GetListWithPageAsync(query.Valid,query.KeyWord,query.Date,query.PageSize.Value,query.PageNum.Value);
            fxPageInfo.TotalCount = replayList.TotalCount;
            fxPageInfo.List = replayList.List.Select(e => new LiveReplayInfoVo
            {
                Id = e.Id,
                ContentPlatformId = e.ContentPlatformId,
                ContentPlatformName = e.ContentPlatformName,
                LiveAnchorId = e.LiveAnchorId,
                LiveAnchorName = e.LiveAnchorName,
                LiveDate = e.LiveDate,
                LiveDuration = e.LiveDuration,
                GMV = e.GMV,
                LivePersonnels = e.LivePersonnel.Split(",").ToList()
            }).ToList();
            return ResultData<FxPageInfo<LiveReplayInfoVo>>.Success().AddData("data", fxPageInfo);
        }
        /// <summary>
        /// 修改复盘表信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateAsync(UpdateLiveReplayVo updateVo)
        {
            UpdateLiveReplayDto updateDto = new UpdateLiveReplayDto();
            updateDto.Id = updateVo.Id;
            updateDto.ContentPlatformId = updateVo.ContentPlatformId;
            updateDto.LiveAnchorId = updateVo.LiveAnchorId;
            updateDto.LiveDate = updateVo.LiveDate;
            updateDto.LiveDuration = updateVo.LiveDuration;
            updateDto.GMV = updateVo.GMV;
            updateDto.LivePersonnel = string.Join(",", updateVo.LivePersonnels);
            await liveReplayService.UpdateAsync(updateDto);
        }
    }
}
