using Fx.Amiya.Background.Api.Vo.LiveAnchor;
using Fx.Amiya.Dto.LiveAnchor;
using Fx.Amiya.IService;
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

    /// <summary>
    /// 主播账号
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LiveAnchorController : ControllerBase
    {
        private ILiveAnchorService liveAnchorService;
        private IHttpContextAccessor httpContextAccessor;
        public LiveAnchorController(IHttpContextAccessor httpContextAccessor, ILiveAnchorService liveAnchorService)
        {
            this.liveAnchorService = liveAnchorService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        ///  获取有效的主播账号列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("valid")]
        public async Task<ResultData<List<LiveAnchorIdAndNameVo>>> GetValidListAsync()
        {
            var liveAnchors = from d in await liveAnchorService.GetValidAsync()
                              select new LiveAnchorIdAndNameVo
                              {
                                  Id = d.Id,
                                  Name =(string.IsNullOrEmpty(d.ContentPlateFormName))?d.Name.ToString(): d.Name.ToString() + "(" + d.ContentPlateFormName + ")",
                              };
            return ResultData<List<LiveAnchorIdAndNameVo>>.Success().AddData("liveAnchors", liveAnchors.ToList());
        }

        /// <summary>
        ///  根据内容平台获取有效的主播账号列表
        /// </summary>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        [HttpGet("validList")]
        public async Task<ResultData<List<LiveAnchorVo>>> GetValidListAsync(string contentPlatFormId)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var liveAnchors = from d in await liveAnchorService.GetValidListByContentPlatFormIdAsync(contentPlatFormId, employeeId)
                              select new LiveAnchorVo
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  HostAccountName = d.HostAccountName,
                                  ContentPlateFormId = d.ContentPlateFormId,
                                  ContentPlateFormName = d.ContentPlateFormName,
                                  LiveAnchorBaseId=d.LiveAnchorBaseId,
                                  Valid = d.Valid
                              };
            return ResultData<List<LiveAnchorVo>>.Success().AddData("liveAnchors", liveAnchors.ToList());
        }

        /// <summary>
        /// 获取主播账号列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="contentPlatformId"></param>
        /// <param name="valid"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<LiveAnchorVo>>> GetListAsync(string name,string contentPlatformId,bool valid, int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var q = await liveAnchorService.GetListAsync(name,employeeId,  contentPlatformId, valid, pageNum, pageSize);
            var liveAnchors = from d in q.List
                              select new LiveAnchorVo
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  LiveAnchorBaseId=d.LiveAnchorBaseId,
                                  HostAccountName = d.HostAccountName,
                                  ContentPlateFormId = d.ContentPlateFormId,
                                  ContentPlateFormName = d.ContentPlateFormName,
                                  Valid = d.Valid
                              };
            FxPageInfo<LiveAnchorVo> liveAnchorPageInfo = new FxPageInfo<LiveAnchorVo>();
            liveAnchorPageInfo.TotalCount = q.TotalCount;
            liveAnchorPageInfo.List = liveAnchors;
            return ResultData<FxPageInfo<LiveAnchorVo>>.Success().AddData("liveAnchors", liveAnchorPageInfo);
        }




        /// <summary>
        /// 添加主播账号
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddLiveAnchorVo addVo)
        {
            AddLiveAnchorDto addDto = new AddLiveAnchorDto();
            addDto.HostAccountName = addVo.HostAccountName;
            addDto.ContentPlateFormId = addVo.ContentPlateFormId;
            addDto.Name = addVo.Name;
            addDto.LiveAnchorBaseId = addVo.LiveAnchorBaseId;
            addDto.Valid = addVo.Valid;
            await liveAnchorService.AddAsync(addDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据编号获取主播账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<LiveAnchorVo>> GetByIdAsync(int id)
        {

            var result = await liveAnchorService.GetByIdAsync(id);
            LiveAnchorVo cooperativeHospitalCityVo = new LiveAnchorVo();
            cooperativeHospitalCityVo.Id = result.Id;
            cooperativeHospitalCityVo.Name = result.Name;
            cooperativeHospitalCityVo.LiveAnchorBaseId = result.LiveAnchorBaseId;
            cooperativeHospitalCityVo.Valid = result.Valid;
            cooperativeHospitalCityVo.HostAccountName = result.HostAccountName;
            cooperativeHospitalCityVo.ContentPlateFormId = result.ContentPlateFormId;
            return ResultData<LiveAnchorVo>.Success().AddData("liveAnchor", cooperativeHospitalCityVo);
        }

        /// <summary>
        /// 修改主播账号
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateLiveAnchorVo updateVo)
        {
            UpdateLiveAnchorDto updateDto = new UpdateLiveAnchorDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.LiveAnchorBaseId = updateVo.LiveAnchorBaseId;
            updateDto.Valid = updateVo.Valid;
            updateDto.HostAccountName = updateVo.HostAccountName;
            updateDto.ContentPlateFormId = updateVo.ContentPlateFormId;
            await liveAnchorService.UpdateAsync(updateDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除主播账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync([FromRoute] int id)
        {
            await liveAnchorService.DeleteAsync(id);
            return ResultData.Success();
        }
    }
}
