using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveReplay.Input;
using Fx.Amiya.Dto.LiveRepley;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class LiveReplayService : ILiveReplayService
    {
        private readonly IDalLiveReply dalLiveReply;

        public LiveReplayService(IDalLiveReply dalLiveReply)
        {
            this.dalLiveReply = dalLiveReply;
        }


        public async Task AddAsync(AddLiveReplayDto addDto)
        {
            var replay = dalLiveReply.GetAll().Where(e => e.ContentPlatformId == addDto.ContentPlatformId && e.LiveAnchorId == addDto.LiveAnchorId && e.LiveDate.Date == addDto.LiveDate.Date && e.Valid == true).FirstOrDefault();
            if (replay != null) throw new Exception("当前添加的复盘记录已存在,请在已有记录上修改!");
            LiveReplay liveReplay = new LiveReplay();
            liveReplay.Id = Guid.NewGuid().ToString().Replace("-", "");
            liveReplay.ContentPlatformId = addDto.ContentPlatformId;
            liveReplay.LiveAnchorId = addDto.LiveAnchorId;
            liveReplay.LiveDate = addDto.LiveDate;
            liveReplay.LiveDuration = addDto.LiveDuration;
            liveReplay.GMV = addDto.GMV;
            liveReplay.LivePersonnel = addDto.LivePersonnel;
            liveReplay.CreateDate = DateTime.Now;
            liveReplay.Valid = true;
            await dalLiveReply.AddAsync(liveReplay, true);
        }

        public async Task DeleteAsync(string id)
        {
            var replay = await dalLiveReply.GetAll().Where(e => e.Id == id).SingleOrDefaultAsync();
            if (replay == null) throw new Exception("复盘编号错误");
            replay.Valid = false;
            replay.DeleteDate = DateTime.Now;
            await dalLiveReply.UpdateAsync(replay, true);
        }

        public async Task<LiveReplayInfoDto> GetByIdAsync(string id)
        {
            var replay = await dalLiveReply.GetAll().Include(e => e.Contentplatform).Include(e => e.LiveAnchor).Where(e => e.Id == id && e.Valid == true).SingleOrDefaultAsync();
            if (replay == null) throw new Exception("复盘编号错误");
            LiveReplayInfoDto liveReplayInfoDto = new LiveReplayInfoDto();
            liveReplayInfoDto.Id = replay.Id;
            liveReplayInfoDto.ContentPlatformId = replay.ContentPlatformId;
            liveReplayInfoDto.ContentPlatformName = replay.Contentplatform.ContentPlatformName;
            liveReplayInfoDto.LiveAnchorId = replay.LiveAnchorId;
            liveReplayInfoDto.LiveAnchorName = replay.LiveAnchor.Name;
            liveReplayInfoDto.LiveDate = replay.LiveDate;
            liveReplayInfoDto.LiveDuration = replay.LiveDuration;
            liveReplayInfoDto.GMV = replay.GMV;
            liveReplayInfoDto.LivePersonnel = replay.LivePersonnel;
            return liveReplayInfoDto;

        }

        /// <summary>
        /// 根据直播id获取上一场的直播id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LiveReplayInfoDto> GetLastLiveReplayId(string id)
        {
            LiveReplayInfoDto result = new LiveReplayInfoDto();
            var replay = await dalLiveReply.GetAll().Where(e => e.Id == id && e.Valid == true).FirstOrDefaultAsync();
            if (replay != null)
            {
                var currentLiveDate = replay.LiveDate;
                var liveanchor = replay.LiveAnchorId;
                var contentPlatFormId = replay.ContentPlatformId;
                var lastReplayData = await dalLiveReply.GetAll().Where(e => e.LiveDate < currentLiveDate && e.LiveAnchorId == liveanchor && e.ContentPlatformId == contentPlatFormId && e.Valid == true).ToListAsync();
                if (lastReplayData.Count > 0)
                {
                    var selectResult = lastReplayData.OrderByDescending(x => x.LiveDate).FirstOrDefault();
                    result.Id = selectResult.Id;
                    result.LiveAnchorId = selectResult.LiveAnchorId;
                    result.ContentPlatformId = selectResult.ContentPlatformId;
                }
            }
            return result;
        }

        public async Task<FxPageInfo<LiveReplayInfoDto>> GetListWithPageAsync(QueryReplayDto query)
        {
            FxPageInfo<LiveReplayInfoDto> fxPageInfo = new FxPageInfo<LiveReplayInfoDto>();
            var replay = dalLiveReply.GetAll()
                .Include(e => e.Contentplatform)
                .Include(e => e.LiveAnchor)
                .Where(e => !query.Date.HasValue || e.LiveDate == query.Date.Value.Date)
                .Where(e => !query.Valid.HasValue || e.Valid == query.Valid.Value)
                .Where(e => string.IsNullOrEmpty(query.KeyWord) || e.Contentplatform.ContentPlatformName.Contains(query.KeyWord) || e.LiveAnchor.Name.Contains(query.KeyWord));
            fxPageInfo.TotalCount = await replay.CountAsync();
            fxPageInfo.List = await replay.Select(e => new LiveReplayInfoDto
            {
                Id = e.Id,
                ContentPlatformId = e.ContentPlatformId,
                ContentPlatformName = e.Contentplatform.ContentPlatformName,
                LiveAnchorId = e.LiveAnchorId,
                LiveAnchorName = e.LiveAnchor.Name,
                LiveDate = e.LiveDate,
                LiveDuration = e.LiveDuration,
                GMV = e.GMV,
                LivePersonnel = e.LivePersonnel
            }).OrderByDescending(e => e.LiveDate).Skip((query.PageSize.Value - 1) * query.PageNum.Value).Take(query.PageSize.Value).ToListAsync();
            return fxPageInfo;
        }
        /// <summary>
        /// 根据指定条件获取直播复盘数据
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<LiveReplayInfoDto> GetFirstReplayAsync(QueryFirstReplayDto query)
        {
            FxPageInfo<LiveReplayInfoDto> fxPageInfo = new FxPageInfo<LiveReplayInfoDto>();
            var replay = dalLiveReply.GetAll()
                .Include(e => e.Contentplatform)
                .Include(e => e.LiveAnchor)
                .Where(e => e.Valid == true)
                .Where(e => e.ContentPlatformId == query.ContentPlatformId && e.LiveAnchorId == query.LiveAnchorId && e.LiveDate.Date == query.Date.Date);
            return await replay.Select(e => new LiveReplayInfoDto
            {
                Id = e.Id,
                ContentPlatformId = e.ContentPlatformId,
                ContentPlatformName = e.Contentplatform.ContentPlatformName,
                LiveAnchorId = e.LiveAnchorId,
                LiveAnchorName = e.LiveAnchor.Name,
                LiveDate = e.LiveDate,
                LiveDuration = e.LiveDuration,
                GMV = e.GMV,
                LivePersonnel = e.LivePersonnel
            }).FirstOrDefaultAsync();

        }

        public async Task UpdateAsync(UpdateLiveReplayDto updateDto)
        {
            var replay = await dalLiveReply.GetAll().Where(e => e.Id == updateDto.Id && e.Valid == true).SingleOrDefaultAsync();
            if (replay == null) throw new Exception("直播复盘表编号错误");
            replay.ContentPlatformId = updateDto.ContentPlatformId;
            replay.LiveAnchorId = updateDto.LiveAnchorId;
            replay.LiveDate = updateDto.LiveDate;
            replay.LiveDuration = updateDto.LiveDuration;
            replay.GMV = updateDto.GMV;
            replay.LivePersonnel = updateDto.LivePersonnel;
            replay.UpdateDate = DateTime.Now;
            await dalLiveReply.UpdateAsync(replay, true);
        }
    }
}
