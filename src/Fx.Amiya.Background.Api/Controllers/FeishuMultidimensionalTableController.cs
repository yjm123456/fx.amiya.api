using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.FeishuMultidimensionalTable;
using Fx.Amiya.Background.Api.Vo.FeishuMultidimensionalTable.Input;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.TikTokShortVideoData;
using Fx.Amiya.Dto.TikTokShortVideoData.Input;
using Fx.Amiya.IService;
using Fx.Amiya.SyncFeishuMultidimensionalTable;
using Fx.Amiya.SyncFeishuMultidimensionalTable.FeishuAppConfig;
using Fx.Authorization.Attributes;
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
    /// 飞书多维表格数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class FeishuMultidimensionalTableController : ControllerBase
    {
        private readonly ISyncFeishuMultidimensionalTable syncFeishuMultidimensionalTable;
        private readonly ITikTokShortVideoDataService tikTokShortVideoDataService;
        public FeishuMultidimensionalTableController(ISyncFeishuMultidimensionalTable syncFeishuMultidimensionalTable, ITikTokShortVideoDataService tikTokShortVideoDataService)
        {
            this.syncFeishuMultidimensionalTable = syncFeishuMultidimensionalTable;
            this.tikTokShortVideoDataService = tikTokShortVideoDataService;
        }


        /// <summary>
        /// 获取短视频数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("shortVideoData")]
        public async Task<ResultData<FxPageInfo<TikTokShortVideoDataInfoVo>>> GetShortVideoDataAsync([FromQuery] ShortVideoDataQueryVo query) {
            FxPageInfo<TikTokShortVideoDataInfoVo> pageInfo = new FxPageInfo<TikTokShortVideoDataInfoVo>();
            ShortVideoDataQueryDto queryDto =new ShortVideoDataQueryDto();
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            queryDto.KeyWord = query.KeyWord;
            queryDto.LiveAnchorId = query.LiveAnchorId;
            var res =await tikTokShortVideoDataService.GetShortVideoDataByPageAsync(queryDto);
            pageInfo.TotalCount = res.TotalCount;
            pageInfo.List = res.List.Select(e => new TikTokShortVideoDataInfoVo {
                Id = e.Id,
                PlayNum = e.PlayNum,
                Title = e.Title,
                Like = e.Like,
                VideoId = e.VideoId,
                Comments = e.Comments,
                LiveAnchorName = e.LiveAnchorName
            }).ToList();
            return ResultData<FxPageInfo<TikTokShortVideoDataInfoVo>>.Success().AddData("videoData",pageInfo);
        }
    }
}
