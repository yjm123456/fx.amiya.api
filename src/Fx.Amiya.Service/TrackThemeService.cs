using Fx.Amiya.Dto.TrackTheme;
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
  public  class TrackThemeService: ITrackThemeService
    {
        private IDalTrackTheme dalTrackTheme;
        public TrackThemeService(IDalTrackTheme dalTrackTheme)
        {
            this.dalTrackTheme = dalTrackTheme;
        }


        /// <summary>
        /// 获取回访主题列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TrackThemeDto>> GetListWithPageAsync(int? trackTypeId,int pageNum, int pageSize)
        {
            var trackTheme = from d in dalTrackTheme.GetAll()
                             where trackTypeId==null||d.TrackTypeId== trackTypeId
                             select new TrackThemeDto
                             { 
                                Id=d.Id,
                                Name=d.Name,
                                TrackTypeId=d.TrackTypeId,
                                TrackTypeName=d.TrackType.Name,
                                Valid=d.Valid
                             };
            FxPageInfo<TrackThemeDto> trackThemePageInfo = new FxPageInfo<TrackThemeDto>();
            trackThemePageInfo.TotalCount = await trackTheme.CountAsync();
            trackThemePageInfo.List = await trackTheme.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return trackThemePageInfo;
        }



        /// <summary>
        /// 根据回访类型编号获取回访主题名称列表
        /// </summary>
        /// <param name="trackTypeId"></param>
        /// <returns></returns>
        public async Task<List<TrackThemeNameDto>> GetNameListByTrackTypeIdAsync(int trackTypeId)
        {
            var trackTheme = from d in dalTrackTheme.GetAll()
                             where d.TrackTypeId == trackTypeId && d.Valid
                             select new TrackThemeNameDto
                             { 
                                Id=d.Id,
                                Name=d.Name
                             };
            return await trackTheme.ToListAsync();
        }


        /// <summary>
        /// 添加回访主题
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddTrackThemeDto addDto)
        {
            TrackTheme trackTheme = new TrackTheme();
            trackTheme.Name = addDto.Name;
            trackTheme.TrackTypeId = addDto.TrackTypeId;
            trackTheme.Valid = true;
            await dalTrackTheme.AddAsync(trackTheme,true);
        }



        /// <summary>
        /// 根据主题编号回去回访主题信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TrackThemeDto> GetByIdAsync(int id)
        {
            var trackTheme = await dalTrackTheme.GetAll().Include(e=>e.TrackType).SingleOrDefaultAsync(e => e.Id == id);
            if (trackTheme == null)
                throw new Exception("回访主题编号错误");
            TrackThemeDto trackThemeDto = new TrackThemeDto();
            trackThemeDto.Id = trackTheme.Id;
            trackThemeDto.Name = trackTheme.Name;
            trackThemeDto.TrackTypeId = trackTheme.TrackTypeId;
            trackThemeDto.TrackTypeName = trackTheme.TrackType.Name;
            trackThemeDto.Valid = trackTheme.Valid;
            return trackThemeDto;
        }


        /// <summary>
        /// 修改回访主题
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateTrackThemeDto updateDto)
        {
            var trackTheme = await dalTrackTheme.GetAll().SingleOrDefaultAsync(t => t.Id == updateDto.Id);
            if (trackTheme == null)
                throw new Exception("回访主题编号错误");

            trackTheme.Name = updateDto.Name;
            trackTheme.TrackTypeId = updateDto.TrackTypeId;
            trackTheme.Valid = updateDto.Valid;
            await dalTrackTheme.UpdateAsync(trackTheme,true);
        }



        /// <summary>
        /// 删除回访主题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var trackTheme = await dalTrackTheme.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            await dalTrackTheme.DeleteAsync(trackTheme,true);
        }
    }
}
