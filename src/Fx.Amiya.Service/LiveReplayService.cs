using Fx.Amiya.DbModels.Model;
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
            LiveReplay liveReplay = new LiveReplay();
            liveReplay.Id = Guid.NewGuid().ToString().Replace("-","");
            liveReplay.ContentPlatformId = addDto.ContentPlatformId;
            liveReplay.LiveAnchorId = addDto.LiveAnchorId;
            liveReplay.LiveDate = addDto.LiveDate;
            liveReplay.LiveDuration = addDto.LiveDuration;
            liveReplay.GMV = addDto.GMV;
            liveReplay.LivePersonnel = addDto.LivePersonnel;
            liveReplay.CreateDate = DateTime.Now;
            liveReplay.Valid = true;
            await dalLiveReply.AddAsync(liveReplay,true);
        }
        
        public async Task DeleteAsync(string id)
        {
            var replay = await dalLiveReply.GetAll().Where(e => e.Id == id).SingleOrDefaultAsync();
            if (replay == null) throw new Exception("复盘编号错误");
            replay.Valid = false;
            replay.DeleteDate = DateTime.Now;
            await dalLiveReply.UpdateAsync(replay,true);
        }
        
        public async Task<LiveReplayInfoDto> GetByIdAsync(string id)
        {
            var replay = await dalLiveReply.GetAll().Include(e=>e.Contentplatform).Include(e=>e.LiveAnchor).Where(e => e.Id == id&&e.Valid==true).SingleOrDefaultAsync();
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
        
        public async Task<FxPageInfo<LiveReplayInfoDto>> GetListWithPageAsync(bool? valid, string keyWord,DateTime? date, int pageSize, int pageNum)
        {
            FxPageInfo<LiveReplayInfoDto> fxPageInfo = new FxPageInfo<LiveReplayInfoDto>();
            var replay =  dalLiveReply.GetAll()
                .Include(e => e.Contentplatform)
                .Include(e => e.LiveAnchor)
                .Where(e => !date.HasValue || e.LiveDate == date.Value.Date)
                .Where(e => !valid.HasValue || e.Valid == valid.Value)
                .Where(e => string.IsNullOrEmpty(keyWord) || e.Contentplatform.ContentPlatformName.Contains(keyWord) || e.LiveAnchor.Name.Contains(keyWord));
            fxPageInfo.TotalCount =await replay.CountAsync();
            fxPageInfo.List =await replay.Select(e => new LiveReplayInfoDto
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
            }).OrderByDescending(e=>e.LiveDate).Skip((pageSize - 1) * pageNum).Take(pageSize).ToListAsync();
            return fxPageInfo;
        }
        
        public async Task UpdateAsync(UpdateLiveReplayDto updateDto)
        {
            var replay =await dalLiveReply.GetAll().Where(e => e.Id == updateDto.Id && e.Valid == true).SingleOrDefaultAsync();
            if (replay == null) throw new Exception("直播复盘表编号错误");
            replay.ContentPlatformId = updateDto.ContentPlatformId;
            replay.LiveAnchorId = updateDto.LiveAnchorId;
            replay.LiveDate = updateDto.LiveDate;
            replay.LiveDuration = updateDto.LiveDuration;
            replay.GMV = updateDto.GMV;
            replay.LivePersonnel = updateDto.LivePersonnel;
            replay.UpdateDate = DateTime.Now;
            await dalLiveReply.UpdateAsync(replay,true);
        }
    }
}
