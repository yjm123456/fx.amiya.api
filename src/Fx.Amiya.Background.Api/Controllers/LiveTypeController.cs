
using Fx.Amiya.Background.Api.Vo.LiveType;
using Fx.Amiya.Dto.LiveType;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveTypeController : ControllerBase
    {
        private ILiveTypeService liveTypeService;
        public LiveTypeController(ILiveTypeService liveTypeService)
        {
            this.liveTypeService = liveTypeService;
        }

        /// <summary>
        /// 获取所有直播类型列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<LiveTypeVo>>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var q = await liveTypeService.GetListWithPageAsync(pageNum, pageSize);
            var liveType = from d in q.List
                           select new LiveTypeVo
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Valid = d.Valid
                           };
            FxPageInfo<LiveTypeVo> liveTypePageInfo = new FxPageInfo<LiveTypeVo>();
            liveTypePageInfo.TotalCount = q.TotalCount;
            liveTypePageInfo.List = liveType;
            return ResultData<FxPageInfo<LiveTypeVo>>.Success().AddData("liveType", liveTypePageInfo);
        }


        /// <summary>
        /// 获取有效的直播类型名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<LiveTypeVo>>> GetNameListAsync()
        {
            var liveType = from d in await liveTypeService.GetNameListAsync()
                           select new LiveTypeVo
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Valid = d.Valid
                           };
            return ResultData<List<LiveTypeVo>>.Success().AddData("liveType", liveType.ToList());
        }


        /// <summary>
        /// 添加直播类型
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddAsync(AddLiveTypeVo addVo)
        {
            AddLiveTypeDto addDto = new AddLiveTypeDto();
            addDto.Name = addVo.Name;
            await liveTypeService.AddAsync(addDto);
        }


        /// <summary>
        /// 根据编号获取直播类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<LiveTypeVo>> GetByIdAsync(int id)
        {
            var liveType = await liveTypeService.GetByIdAsync(id);
            LiveTypeVo liveTypeVo = new LiveTypeVo();
            liveTypeVo.Id = liveType.Id;
            liveTypeVo.Name = liveType.Name;
            liveTypeVo.Valid = liveType.Valid;
            return ResultData<LiveTypeVo>.Success().AddData("liveType", liveTypeVo);

        }


        /// <summary>
        /// 修改直播类型
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateLiveTypeVo updateVo)
        {
            UpdateLiveTypeDto updateDto = new UpdateLiveTypeDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.Valid = updateVo.Valid;
            return ResultData.Success();
        }



        /// <summary>
        /// 删除直播类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ResultData> DeleteAsync(int id)
        {
            await liveTypeService.DeleteAsync(id);
            return ResultData.Success();
        }
    }
}
