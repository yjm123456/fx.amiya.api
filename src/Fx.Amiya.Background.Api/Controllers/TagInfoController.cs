using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.TagInfo;
using Fx.Amiya.Dto.TagInfo;
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
    public class TagInfoController : ControllerBase
    {
        private ITagInfoService tagInfoService;

        public TagInfoController(ITagInfoService tagInfoService)
        {
            this.tagInfoService = tagInfoService;
        }


        /// <summary>
        /// 获取所有标签列表(分页)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<TagInfoVo>>> GetListWithPageAsync(byte? type, string name, int pageNum, int pageSize)
        {
            try
            {
                var q = await tagInfoService.GetListWithPageAsync(type, name, pageNum, pageSize);
                var tagInfo = from d in q.List
                              select new TagInfoVo
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  Type = d.Type,
                                  TypeName = d.TypeName,
                                  Valid = d.Valid
                              };

                FxPageInfo<TagInfoVo> tagPageInfo = new FxPageInfo<TagInfoVo>();
                tagPageInfo.TotalCount = q.TotalCount;
                tagPageInfo.List = tagInfo;

                return ResultData<FxPageInfo<TagInfoVo>>.Success().AddData("tagInfo", tagPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<TagInfoVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据获取标签列表
        /// </summary>
        /// <param name="type">0=医院规模,1=医院设施，null=全部</param>
        /// <returns></returns>
       [HttpGet("nameList")]
       [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<TagNameVo>>> GetNameListAsync(byte? type)
        {
            try
            {
                var tagInfo = from d in await tagInfoService.GetNameListAsync(type)
                              select new TagNameVo
                              {
                                  Id = d.Id,
                                  Name = d.Name
                              };
                return ResultData<List<TagNameVo>>.Success().AddData("tagInfo",tagInfo.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<TagNameVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 添加医院标签
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddTagInfoVo addVo)
        {
            try
            {
                AddTagInfoDto addDto = new AddTagInfoDto();
                addDto.Name = addVo.Name;
                addDto.Type = addVo.Type;

                await tagInfoService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据标签编号获取标签信息
        /// </summary>
        /// <param name="id">标签编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<TagInfoVo>> GetByIdAsync(int id)
        {
            try
            {
                var tagInfo = await tagInfoService.GetByIdAsync(id);
                TagInfoVo tagInfoVo = new TagInfoVo();
                tagInfoVo.Id = tagInfo.Id;
                tagInfoVo.Name = tagInfo.Name;
                tagInfoVo.Type = tagInfo.Type;
                tagInfoVo.TypeName = tagInfo.TypeName;
                tagInfoVo.Valid = tagInfo.Valid;

                return ResultData<TagInfoVo>.Success().AddData("tagInfo", tagInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<TagInfoVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改医院标签信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateTagInfoVo updateVo)
        {
            try
            {
                UpdateTagInfoDto updateDto = new UpdateTagInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.Type = updateVo.Type;
                updateDto.Valid = updateVo.Valid;

                await tagInfoService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 删除医院标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await tagInfoService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}