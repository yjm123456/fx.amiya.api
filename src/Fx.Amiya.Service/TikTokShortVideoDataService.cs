using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.TikTokShortVideoData;
using Fx.Amiya.Dto.TikTokShortVideoData.Input;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class TikTokShortVideoDataService : ITikTokShortVideoDataService
    {
        private readonly IDalTikTokShortVideoData dalTikTokShortVideoData;
        private readonly IDalLiveAnchor dalLiveAnchor;
        private readonly IDalShortVideoComments dalShortVideoComments;
        private readonly IDalShortVideoFansData dalShortVideoFansData;
        public TikTokShortVideoDataService(IDalTikTokShortVideoData dalTikTokShortVideoData, IDalLiveAnchor dalLiveAnchor, IDalShortVideoComments dalShortVideoComments, IDalShortVideoFansData dalShortVideoFansData)
        {
            this.dalTikTokShortVideoData = dalTikTokShortVideoData;
            this.dalLiveAnchor = dalLiveAnchor;
            this.dalShortVideoComments = dalShortVideoComments;
            this.dalShortVideoFansData = dalShortVideoFansData;
        }

        public async Task AddCommentsListAsync(List<AddTikTokShortVideoCommentsDto> adddList)
        {
            if (adddList.Count() == 0) return;
            var liveAnchorId = adddList.First().BelongLiveAnchorId;
            var existsData = dalShortVideoComments.GetAll().Where(e => e.BelongLiveAnchorId == liveAnchorId).ToList();
            foreach (var item in existsData)
            {
                item.Valid = false;
                await dalShortVideoComments.UpdateAsync(item, true);
            }
            foreach (var item in adddList)
            {
                var data = dalShortVideoComments.GetAll().Where(e => e.CommentsId == item.CommentsId).FirstOrDefault();
                if (data == null)
                {
                    ShortVideoComments newData = new ShortVideoComments();
                    newData.Id = Guid.NewGuid().ToString().Replace("-", "");
                    newData.CommentsId = item.CommentsId;
                    newData.CommentsUserId = item.CommentsUserId;
                    newData.CommentsUserName = item.CommentsUserName;
                    newData.LikeCount = item.LikeCount;
                    newData.Comments = item.Comments;
                    newData.CommentsDate = item.CommentsDate;
                    newData.BelongLiveAnchorId=item.BelongLiveAnchorId;
                    newData.CreateDate = DateTime.Now;
                    newData.Valid = true;
                    await dalShortVideoComments.AddAsync(newData, true);
                }
                else
                {
                    data.CommentsUserId = item.CommentsUserId;
                    data.CommentsUserName = item.CommentsUserName;
                    data.LikeCount = item.LikeCount;
                    data.CommentsDate = item.CommentsDate;
                    data.Comments = item.Comments;
                    data.BelongLiveAnchorId = item.BelongLiveAnchorId;
                    data.UpdateDate = DateTime.Now;
                    data.Valid = true;
                    await dalShortVideoComments.UpdateAsync(data, true);
                }
            }
        }

        public async Task AddFansListAsync(List<AddTikTokFansDataDto> adddList)
        {
            if (adddList.Count() == 0) return;
            var liveAnchorId = adddList.First().BelongLiveAnchorId;
            var existsData = dalShortVideoFansData.GetAll().Where(e => e.BelongLiveAnchorId == liveAnchorId).ToList();
            foreach (var item in existsData)
            {
                item.Valid = false;
                await dalShortVideoFansData.UpdateAsync(item, true);
            }
            foreach (var item in adddList)
            {
                ShortVideoFansData shortVideoFansData =new ShortVideoFansData();
                shortVideoFansData.Id = Guid.NewGuid().ToString().Replace("-", "");
                shortVideoFansData.StatsDate = item.StatsDate;
                shortVideoFansData.NewFansCount=item.NewFansCount;
                shortVideoFansData.TotalFansCount=item.TotalFansCount;
                shortVideoFansData.BelongLiveAnchorId=item.BelongLiveAnchorId;
                shortVideoFansData.CreateDate = DateTime.Now;
                shortVideoFansData.Valid = true;
                await dalShortVideoFansData.AddAsync(shortVideoFansData,true);
            }
        }

        public async Task AddListAsync(List<AddTikTokShortVideoDataDto> adddList)
        {
            if (adddList.Count() == 0) return;
            var liveAnchorId = adddList.First().BelongLiveAnchorId;
            var existsData = dalTikTokShortVideoData.GetAll().Where(e => e.BelongLiveAnchorId == liveAnchorId).ToList();
            foreach (var item in existsData)
            {
                item.Valid = false;
                await dalTikTokShortVideoData.UpdateAsync(item, true);
            }
            foreach (var item in adddList)
            {
                var data = dalTikTokShortVideoData.GetAll().Where(e => e.VideoId == item.VideoId).FirstOrDefault();
                if (data == null)
                {
                    TikTokShortVideoData newData = new TikTokShortVideoData();
                    newData.Id = Guid.NewGuid().ToString().Replace("-", "");
                    newData.VideoId = item.VideoId;
                    newData.PlayNum = item.PlayNum;
                    newData.Title = item.Title;
                    newData.Like = item.Like;
                    newData.Comments = item.Comments;
                    newData.BelongLiveAnchorId = item.BelongLiveAnchorId;
                    newData.CreateDate = DateTime.Now;
                    newData.Valid = true;
                    await dalTikTokShortVideoData.AddAsync(newData, true);
                }
                else
                {
                    data.VideoId = item.VideoId;
                    data.PlayNum = item.PlayNum;
                    data.Title = item.Title;
                    data.Like = item.Like;
                    data.Comments = item.Comments;
                    data.BelongLiveAnchorId = item.BelongLiveAnchorId;
                    data.UpdateDate = DateTime.Now;
                    data.Valid = true;
                    await dalTikTokShortVideoData.UpdateAsync(data, true);
                }
            }
        }

        public async Task<FxPageInfo<TikTokShortVideoCommentsDataInfoDto>> GetShortVideoCommentsDataByPageAsync(ShortVideoDataQueryDto query)
        {
            FxPageInfo<TikTokShortVideoCommentsDataInfoDto> pageInfo = new FxPageInfo<TikTokShortVideoCommentsDataInfoDto>();
            var data = from d in dalShortVideoComments.GetAll().Where(e => e.Valid == true && (!query.LiveAnchorId.HasValue || e.BelongLiveAnchorId == query.LiveAnchorId))
                       join c in dalLiveAnchor.GetAll() on d.BelongLiveAnchorId equals c.Id
                       select new { Id = d.Id, CommentsId = d.CommentsId, CommentsUserId = d.CommentsUserId, d.CommentsUserName,d.LikeCount,d.Comments,d.CommentsDate, LiveAnchorName = c.Name };
            if (!string.IsNullOrEmpty(query.KeyWord))
            {
                data = data.Where(e => e.Comments.Contains(query.KeyWord));
            }
            pageInfo.TotalCount = await data.CountAsync();
            pageInfo.List = data.OrderByDescending(e => e.LikeCount).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).Select(e => new TikTokShortVideoCommentsDataInfoDto
            {
                Id = e.Id,
                CommentsId = e.CommentsId,
                CommentsUserId = e.CommentsUserId,
                CommentsUserName = e.CommentsUserName,
                LikeCount = e.LikeCount,
                Comments = e.Comments,
                CommentsDate = e.CommentsDate,
                LiveAnchorName = e.LiveAnchorName
            }).ToList();
            return pageInfo;
        }

        public async Task<FxPageInfo<TikTokShortVideoDataInfoDto>> GetShortVideoDataByPageAsync(ShortVideoDataQueryDto query)
        {
            FxPageInfo<TikTokShortVideoDataInfoDto> pageInfo = new FxPageInfo<TikTokShortVideoDataInfoDto>();
            var data = from d in dalTikTokShortVideoData.GetAll().Where(e => e.Valid == true&&(!query.LiveAnchorId.HasValue||e.BelongLiveAnchorId==query.LiveAnchorId))
                       join c in dalLiveAnchor.GetAll() on d.BelongLiveAnchorId equals c.Id select new {Id=d.Id, PlayNum=d.PlayNum, Title=d.Title,d.Like, VideoId=d.VideoId, Comments=d.Comments,LiveAnchorName=c.Name };
            if (!string.IsNullOrEmpty(query.KeyWord))
            {
                data = data.Where(e => e.Title.Contains(query.KeyWord));
            }
            pageInfo.TotalCount =await data.CountAsync();
            pageInfo.List = data.OrderByDescending(e=>e.PlayNum).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).Select(e => new TikTokShortVideoDataInfoDto
            {
                Id=e.Id,
                PlayNum = e.PlayNum,
                Title=e.Title,
                Like=e.Like,
                VideoId=e.VideoId,
                Comments=e.Comments,
                LiveAnchorName=e.LiveAnchorName
            }).ToList();
            return pageInfo;
        }

        public async Task<FxPageInfo<TikTokFansDataInfoDto>> GetShortVideoFansDataByPageAsync(ShortVideoDataQueryDto query)
        {
            FxPageInfo<TikTokFansDataInfoDto> pageInfo = new FxPageInfo<TikTokFansDataInfoDto>();
            var data = from d in dalShortVideoFansData.GetAll().Where(e => e.Valid == true && (!query.LiveAnchorId.HasValue || e.BelongLiveAnchorId == query.LiveAnchorId))
                       join c in dalLiveAnchor.GetAll() on d.BelongLiveAnchorId equals c.Id
                       select new { Id = d.Id, StatsDate = d.StatsDate, NewFansCount = d.NewFansCount, d.TotalFansCount, LiveAnchorName = c.Name };
            if (!string.IsNullOrEmpty(query.KeyWord))
            {
                data = data.Where(e => e.LiveAnchorName.Contains(query.KeyWord));
            }
            pageInfo.TotalCount = await data.CountAsync();
            pageInfo.List = data.OrderByDescending(e => e.TotalFansCount).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).Select(e => new TikTokFansDataInfoDto
            {
                Id = e.Id,
                StatsDate = e.StatsDate,
                NewFansCount = e.NewFansCount,
                TotalFansCount = e.TotalFansCount,
                LiveAnchorName = e.LiveAnchorName
            }).ToList();
            return pageInfo;
        }
    }
}
