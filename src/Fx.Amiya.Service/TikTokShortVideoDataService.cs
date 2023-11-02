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
        public TikTokShortVideoDataService(IDalTikTokShortVideoData dalTikTokShortVideoData, IDalLiveAnchor dalLiveAnchor)
        {
            this.dalTikTokShortVideoData = dalTikTokShortVideoData;
            this.dalLiveAnchor = dalLiveAnchor;
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
    }
}
