using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.TrackTheme;
using Fx.Amiya.Background.Api.Vo.TrackTheme.Input;
using Fx.Amiya.Dto.TrackTheme;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrackThemeController : ControllerBase
    {
        private ITrackThemeService trackThemeService;
        public TrackThemeController(ITrackThemeService trackThemeService)
        {
            this.trackThemeService = trackThemeService;
        }

        /// <summary>
        /// 获取回访主题列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<TrackThemeVo>>> GetListWithPageAsync([FromQuery]QueryTrackThemeVo query)
        {
            var q = await trackThemeService.GetListWithPageAsync(query.TrackTypeId, query.PageNum.Value, query.PageSize.Value,query.Valid);

            var trackTheme = from d in q.List
                             select new TrackThemeVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 TrackTypeId = d.TrackTypeId,
                                 TrackTypeName = d.TrackTypeName,
                                 Valid = d.Valid
                             };
            FxPageInfo<TrackThemeVo> trackThemePageInfo = new FxPageInfo<TrackThemeVo>();
            trackThemePageInfo.TotalCount = q.TotalCount;
            trackThemePageInfo.List = trackTheme;
            return ResultData<FxPageInfo<TrackThemeVo>>.Success().AddData("trackTheme", trackThemePageInfo);
        }



        /// <summary>
        /// 根据回访类型编号获取回访主题名称列表
        /// </summary>
        /// <param name="trackTypeId"></param>
        /// <returns></returns>
        [HttpGet("nameListByTrackTypeId/{trackTypeId}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<TrackThemeNameVo>>> GetNameListByTrackTypeIdAsync(int trackTypeId)
        {
            var trackTheme = from d in await trackThemeService.GetNameListByTrackTypeIdAsync(trackTypeId)
                             select new TrackThemeNameVo
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             };
            return ResultData<List<TrackThemeNameVo>>.Success().AddData("trackTheme", trackTheme.ToList());
        }



        /// <summary>
        /// 添加回访主题
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddTrackThemeVo addVo)
        {
            AddTrackThemeDto addDto = new AddTrackThemeDto();
            addDto.Name = addVo.Name;
            addDto.TrackTypeId = addVo.TrackTypeId;
            await trackThemeService.AddAsync(addDto);
            return ResultData.Success();
        }




        /// <summary>
        /// 根据主题编号回去回访主题信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<TrackThemeVo>> GetByIdAsync(int id)
        {
            var trackTheme = await trackThemeService.GetByIdAsync(id);
            TrackThemeVo trackThemeVo = new TrackThemeVo();
            trackThemeVo.Id = trackTheme.Id;
            trackThemeVo.Name = trackTheme.Name;
            trackThemeVo.TrackTypeId = trackTheme.TrackTypeId;
            trackThemeVo.TrackTypeName = trackTheme.TrackTypeName;
            trackThemeVo.Valid = trackTheme.Valid;
            return ResultData<TrackThemeVo>.Success().AddData("trackTheme", trackThemeVo);
        }


        /// <summary>
        /// 修改回访主题
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateTrackThemeVo updateVo)
        {
            UpdateTrackThemeDto updateDto = new UpdateTrackThemeDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.TrackTypeId = updateVo.TrackTypeId;
            updateDto.Valid = updateVo.Valid;
            await trackThemeService.UpdateAsync(updateDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 删除回访主题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(int id)
        {
            await trackThemeService.DeleteAsync(id);
            return ResultData.Success();
        }
    }
}