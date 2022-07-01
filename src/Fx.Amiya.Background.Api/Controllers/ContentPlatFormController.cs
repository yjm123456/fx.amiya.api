using Fx.Amiya.Background.Api.Vo.ContentPlateForm;
using Fx.Amiya.Dto.ContentPlatform;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
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
    /// 内容平台管理功能接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ContentPlatFormController : ControllerBase
    {
        private IContentPlatformService _contentPalteFormService;
        public ContentPlatFormController(IContentPlatformService contentPalteFormService)
        {
            _contentPalteFormService = contentPalteFormService;
        }


        /// <summary>
        /// 获取内容平台列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ContentPalteFormVo>>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var q = await _contentPalteFormService.GetListWithPageAsync(pageNum, pageSize);

            var contentPalteForm = from d in q.List
                       select new ContentPalteFormVo
                       {
                           Id = d.Id,
                           ContentPlatformName = d.ContentPlatformName,
                           Valid = d.Valid,
                       };
            FxPageInfo<ContentPalteFormVo> contentPalteFormPageInfo = new FxPageInfo<ContentPalteFormVo>();
            contentPalteFormPageInfo.TotalCount = q.TotalCount;
            contentPalteFormPageInfo.List = contentPalteForm;
            contentPalteFormPageInfo.PageSize = pageSize;
            contentPalteFormPageInfo.PageCount = contentPalteForm.Count();
            contentPalteFormPageInfo.CurrentPageIndex = pageNum;
            return ResultData<FxPageInfo<ContentPalteFormVo>>.Success().AddData("contentPalteForm", contentPalteFormPageInfo);
        }

        /// <summary>
        /// 根据名称获取所有内容平台列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("allList")]
        public async Task<ResultData<List<ContentPalteFormVo>>> GetListAsync(string name)
        {
            var contentPalteForms = from d in await _contentPalteFormService.GetListAsync(name, null)
                        select new ContentPalteFormVo
                        {
                            Id = d.Id,
                            ContentPlatformName = d.ContentPlatformName,
                            Valid = d.Valid
                        };
            return ResultData<List<ContentPalteFormVo>>.Success().AddData("contentPalteForms", contentPalteForms.ToList());
        }



        /// <summary>
        /// 获取有效的内容平台列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("validList")]
        public async Task<ResultData<List<ContentPalteFormVo>>> GetValidListAsync(string name)
        {
            var contentPalteForms = from d in await _contentPalteFormService.GetListAsync(name, true)
                        select new ContentPalteFormVo
                        {
                            Id = d.Id,
                            ContentPlatformName = d.ContentPlatformName,
                            Valid = d.Valid
                        };
            return ResultData<List<ContentPalteFormVo>>.Success().AddData("contentPalteForms", contentPalteForms.ToList());
        }



        /// <summary>
        /// 添加内容平台
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddContentPalteFormVo addVo)
        {
            AddContentPlatformDto addDto = new AddContentPlatformDto();
            addDto.ContentPlatformName = addVo.ContentPlatformName;
            await _contentPalteFormService.AddAsync(addDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据编号获取内容平台
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<ContentPalteFormVo>> GetByIdAsync(string id)
        {

            var contentPalteForm = await _contentPalteFormService.GetByIdAsync(id);
            ContentPalteFormVo cooperativeHospitalCityVo = new ContentPalteFormVo();
            cooperativeHospitalCityVo.Id = contentPalteForm.Id;
            cooperativeHospitalCityVo.ContentPlatformName = contentPalteForm.ContentPlatformName;
            cooperativeHospitalCityVo.Valid = contentPalteForm.Valid;

            return ResultData<ContentPalteFormVo>.Success().AddData("contentPalteForm", cooperativeHospitalCityVo);
        }

        /// <summary>
        /// 修改内容平台
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateContentPalteFormVo updateVo)
        {
            UpdateContentPlatformDto updateDto = new UpdateContentPlatformDto();
            updateDto.Id = updateVo.Id;
            updateDto.ContentPlatformName = updateVo.ContentPlatformName;
            updateDto.Valid = updateVo.Valid;
            await _contentPalteFormService.UpdateAsync(updateDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除内容平台
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync([FromRoute] string id)
        {
            await _contentPalteFormService.DeleteAsync(id);
            return ResultData.Success();
        }
    }
}
