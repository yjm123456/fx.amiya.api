using Fx.Amiya.Dto.LiveType;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.DbModels.Model;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class LiveTypeService : ILiveTypeService
    {
        private IDalLiveType dalLiveType;
        public LiveTypeService(IDalLiveType dalLiveType)
        {
            this.dalLiveType = dalLiveType;
        }

        public async Task<FxPageInfo<LiveTypeDto>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var liveType = from d in dalLiveType.GetAll()
                           select new LiveTypeDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Valid = d.Valid
                           };
            FxPageInfo<LiveTypeDto> liveTypePageInfo = new FxPageInfo<LiveTypeDto>();
            liveTypePageInfo.TotalCount = await liveType.CountAsync();
            liveTypePageInfo.List = await liveType.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return liveTypePageInfo;
        }



        public async Task<List<LiveTypeDto>> GetNameListAsync()
        {
            var liveType = from d in dalLiveType.GetAll()
                           where d.Valid==true
                           select new LiveTypeDto
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Valid = d.Valid
                           };
            return await liveType.ToListAsync();
        }



        public async Task AddAsync(AddLiveTypeDto addDto)
        {
            var liveTypeCount = await dalLiveType.GetAll().CountAsync(e => e.Name == addDto.Name && e.Valid == true);
            if (liveTypeCount > 0)
                throw new Exception("已有该直播类型，请重新输入");

            LiveType liveType = new LiveType();
            liveType.Name = addDto.Name;
            liveType.Valid = true;
            await dalLiveType.AddAsync(liveType,true);
        }



        public async Task<LiveTypeDto> GetByIdAsync(int id)
        {
            var liveType = await dalLiveType.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            if (liveType == null)
                throw new Exception("直播类型编号错误");

            LiveTypeDto liveTypeDto = new LiveTypeDto();
            liveTypeDto.Id = liveType.Id;
            liveTypeDto.Name = liveType.Name;
            liveTypeDto.Valid = liveType.Valid;
            return liveTypeDto;
        }


        public async Task UpdateAsync(UpdateLiveTypeDto updateDto)
        {
            var liveType = await dalLiveType.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (liveType == null)
                throw new Exception("直播类型编号错误");

            var liveTypeCount = await dalLiveType.GetAll().CountAsync(e => e.Name == updateDto.Name && e.Id != updateDto.Id && e.Valid == true);
            if (liveTypeCount > 0)
                throw new Exception("已有该直播类型，请重新输入");

            liveType.Name = updateDto.Name;
            liveType.Valid = updateDto.Valid;
            await dalLiveType.UpdateAsync(liveType,true) ;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var liveType = await dalLiveType.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (liveType == null)
                    throw new Exception("直播类型编号错误");

                await dalLiveType.DeleteAsync(liveType, true);
            }
            catch (Exception ex)
            {
                throw new Exception("删除失败");
            }
        }
    }
}
