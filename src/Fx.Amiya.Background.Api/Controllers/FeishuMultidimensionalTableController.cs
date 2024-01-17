using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.FeishuMultidimensionalTable;
using Fx.Amiya.Background.Api.Vo.FeishuMultidimensionalTable.Input;
using Fx.Amiya.Background.Api.Vo.FeishuMultidimensionalTable.Result;
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
        public async Task<ResultData<FxPageInfo<TikTokShortVideoDataInfoVo>>> GetShortVideoDataAsync([FromQuery] ShortVideoDataQueryVo query)
        {
            FxPageInfo<TikTokShortVideoDataInfoVo> pageInfo = new FxPageInfo<TikTokShortVideoDataInfoVo>();
            ShortVideoDataQueryDto queryDto = new ShortVideoDataQueryDto();
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            queryDto.KeyWord = query.KeyWord;
            queryDto.LiveAnchorId = query.LiveAnchorId;
            var res = await tikTokShortVideoDataService.GetShortVideoDataByPageAsync(queryDto);
            pageInfo.TotalCount = res.TotalCount;
            pageInfo.List = res.List.Select(e => new TikTokShortVideoDataInfoVo
            {
                Id = e.Id,
                PlayNum = e.PlayNum,
                Title = e.Title,
                Like = e.Like,
                VideoId = e.VideoId,
                Comments = e.Comments,
                LiveAnchorName = e.LiveAnchorName
            }).ToList();
            return ResultData<FxPageInfo<TikTokShortVideoDataInfoVo>>.Success().AddData("videoData", pageInfo);
        }
        /// <summary>
        /// 刷新短视频数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("refreshData")]
        public async Task<ResultData> RefreshShortVideoDataAsync()
        {
            var appLiveAnchorIds = await syncFeishuMultidimensionalTable.GetLiveAnchorIdsAsync();
            List<ShortVideoDataInfo> list = new List<ShortVideoDataInfo>();
            foreach (var appLiveAnchorId in appLiveAnchorIds)
            {
                var tableLiveAnchors = await syncFeishuMultidimensionalTable.GetTableLiveAnchorIdsAsync(appLiveAnchorId.AppId, FeishuTableType.VideoData);
                foreach (var tableid in tableLiveAnchors)
                {
                    var dataList = await syncFeishuMultidimensionalTable.GetShortVideoDataByCodeAsync(appLiveAnchorId.LiveAnchorId, tableid);
                    list.AddRange(dataList);
                }
            }

            if (list.Count > 0)
            {
                var data = list.Select(e => new AddTikTokShortVideoDataDto
                {
                    VideoId = e.VideoId,
                    PlayNum = e.PlayNum,
                    Title = e.Title,
                    Like = e.Like,
                    Comments = e.Comments,
                    BelongLiveAnchorId = e.BelongLiveAnchorId
                }).ToList();
                await tikTokShortVideoDataService.AddListAsync(data);

            }
            return ResultData.Success();
        }
        /// <summary>
        /// 获取短视频评论数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("shortVideoCommentsData")]
        public async Task<ResultData<FxPageInfo<ShortVideoCommentsDataInfoVo>>> GetShortVideoCommentsDataAsync([FromQuery] ShortVideoDataQueryVo query)
        {
            FxPageInfo<ShortVideoCommentsDataInfoVo> pageInfo = new FxPageInfo<ShortVideoCommentsDataInfoVo>();
            ShortVideoDataQueryDto queryDto = new ShortVideoDataQueryDto();
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            queryDto.KeyWord = query.KeyWord;
            queryDto.LiveAnchorId = query.LiveAnchorId;
            var res = await tikTokShortVideoDataService.GetShortVideoCommentsDataByPageAsync(queryDto);
            pageInfo.TotalCount = res.TotalCount;
            pageInfo.List = res.List.Select(e => new ShortVideoCommentsDataInfoVo
            {
                Id = e.Id,
                CommentsId=e.CommentsId,
                CommentsUserId=e.CommentsUserId,
                CommentsUserName=e.CommentsUserName,
                LikeCount=e.LikeCount,
                CommentsDate=e.CommentsDate,
                Comments = e.Comments,
                LiveAnchorName = e.LiveAnchorName
            }).ToList();
            return ResultData<FxPageInfo<ShortVideoCommentsDataInfoVo>>.Success().AddData("videoData", pageInfo);
        }
        /// <summary>
        /// 刷新短视频评论数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("refreshCommentsData")]
        public async Task<ResultData> RefreshShortVideoCommentsDataAsync()
        {
            var appLiveAnchorIds = await syncFeishuMultidimensionalTable.GetLiveAnchorIdsAsync();
            List<ShortVideocommentsInfo> list = new List<ShortVideocommentsInfo>();
            foreach (var appLiveAnchorId in appLiveAnchorIds)
            {
                var tableLiveAnchors = await syncFeishuMultidimensionalTable.GetTableLiveAnchorIdsAsync(appLiveAnchorId.AppId, FeishuTableType.Comments);
                foreach (var tableid in tableLiveAnchors)
                {
                    var dataList = await syncFeishuMultidimensionalTable.GetShortVideoCommentsAsync(appLiveAnchorId.LiveAnchorId, tableid);
                    list.AddRange(dataList);
                }
            }

            if (list.Count > 0)
            {
                var data = list.Select(e => new AddTikTokShortVideoCommentsDto
                {
                    CommentsId=e.CommentsId,
                    CommentsUserId=e.CommentsUserId,
                    CommentsUserName=e.CommentsUserName,
                    LikeCount=e.LikeCount,
                    CommentsDate=e.CommentsDate,
                    Comments = e.Comments,
                    BelongLiveAnchorId = e.BelongLiveAnchorId.Value
                }).ToList();
                await tikTokShortVideoDataService.AddCommentsListAsync(data);

            }
            return ResultData.Success();
        }
        /// <summary>
        /// 获取短视频粉丝数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("shortVideoFansData")]
        public async Task<ResultData<FxPageInfo<ShortVideoFansDataInfoVo>>> GetShortVideoFansDataAsync([FromQuery] ShortVideoDataQueryVo query)
        {
            FxPageInfo<ShortVideoFansDataInfoVo> pageInfo = new FxPageInfo<ShortVideoFansDataInfoVo>();
            ShortVideoDataQueryDto queryDto = new ShortVideoDataQueryDto();
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            queryDto.KeyWord = query.KeyWord;
            queryDto.LiveAnchorId = query.LiveAnchorId;
            var res = await tikTokShortVideoDataService.GetShortVideoFansDataByPageAsync(queryDto);
            pageInfo.TotalCount = res.TotalCount;
            pageInfo.List = res.List.Select(e => new ShortVideoFansDataInfoVo
            {
                Id = e.Id,
                StatsDate = e.StatsDate,
                NewFansCount = e.NewFansCount,
                TotalFansCount = e.TotalFansCount,
                LiveAnchorName = e.LiveAnchorName,
            }).ToList();
            return ResultData<FxPageInfo<ShortVideoFansDataInfoVo>>.Success().AddData("videoData", pageInfo);
        }
        /// <summary>
        /// 刷新短视频粉丝数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("refreshFansData")]
        public async Task<ResultData> RefreshShortVideoFansDataAsync()
        {
            var appLiveAnchorIds = await syncFeishuMultidimensionalTable.GetLiveAnchorIdsAsync();
            List<ShortVideoFansDataInfo> list = new List<ShortVideoFansDataInfo>();
            foreach (var appLiveAnchorId in appLiveAnchorIds)
            {
                var tableLiveAnchors = await syncFeishuMultidimensionalTable.GetTableLiveAnchorIdsAsync(appLiveAnchorId.AppId, FeishuTableType.FansData);
                foreach (var tableid in tableLiveAnchors)
                {
                    var dataList = await syncFeishuMultidimensionalTable.GetShortVideoFansDataAsync(appLiveAnchorId.LiveAnchorId, tableid);
                    list.AddRange(dataList);
                }
            }

            if (list.Count > 0)
            {
                var data = list.Select(e => new AddTikTokFansDataDto
                {
                    StatsDate = e.StatsDate,
                    NewFansCount = e.NewFansCount,
                    TotalFansCount = e.TotalFansCount,
                    BelongLiveAnchorId = e.BelongLiveAnchorId.Value
                }).ToList();
                await tikTokShortVideoDataService.AddFansListAsync(data);


            }
            return ResultData.Success();
        }
    }
}

