
using Fx.Amiya.Background.Api.Vo.RequirementType;
using Fx.Amiya.Dto.RequirementType;
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
    public class LiveRequirementTypeController : ControllerBase
    {
        private IRequirementTypeService requirementTypeService;
        public LiveRequirementTypeController(IRequirementTypeService requirementTypeService)
        {
            this.requirementTypeService = requirementTypeService;
        }

        /// <summary>
        /// 获取所有需求类型列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<RequirementTypeVo>>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var q = await requirementTypeService.GetListWithPageAsync(pageNum, pageSize);
            var requirementType = from d in q.List
                                  select new RequirementTypeVo
                                  {
                                      Id = d.Id,
                                      Name = d.Name,
                                      Valid = d.Valid
                                  };
            FxPageInfo<RequirementTypeVo> requirementTypePageInfo = new FxPageInfo<RequirementTypeVo>();
            requirementTypePageInfo.TotalCount = q.TotalCount;
            requirementTypePageInfo.List = requirementType;
            return ResultData<FxPageInfo<RequirementTypeVo>>.Success().AddData("requirementType", requirementTypePageInfo);
        }



        /// <summary>
        /// 获取有效的直播需求类型名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<RequirementTypeVo>>> GetNameListAsync()
        {
            var requirementType = from d in await requirementTypeService.GetNameListAsync()
                                  select new RequirementTypeVo
                                  {
                                      Id = d.Id,
                                      Name = d.Name,
                                      Valid = d.Valid
                                  };

            return ResultData<List<RequirementTypeVo>>.Success().AddData("requirementType", requirementType.ToList());
        }


        /// <summary>
        /// 添加需求类型
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddRequirementTypeVo addVo)
        {
            AddRequirementTypeDto addDto = new AddRequirementTypeDto();
            addDto.Name = addVo.Name;
            await requirementTypeService.AddAsync(addDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据编号获取需求类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<RequirementTypeVo>> GetByIdAsync(int id)
        {
            var requirementType = await requirementTypeService.GetByIdAsync(id);
            RequirementTypeVo requirementTypeVo = new RequirementTypeVo();
            requirementTypeVo.Id = requirementType.Id;
            requirementTypeVo.Name = requirementType.Name;
            requirementTypeVo.Valid = requirementType.Valid;
            return ResultData<RequirementTypeVo>.Success().AddData("requirementType", requirementTypeVo);
        }


        /// <summary>
        /// 修改需求类型
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateRequirementTypeVo updateVo)
        {
            UpdateRequirementTypeDto updateDto = new UpdateRequirementTypeDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.Valid = updateVo.Valid;
            await requirementTypeService.UpdateAsync(updateDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 删除需求类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            await requirementTypeService.DeleteAsync(id);
            return ResultData.Success();

        }
    }
}
