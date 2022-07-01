
using Fx.Amiya.Background.Api.Vo.AmiyaDepartment;
using Fx.Amiya.Dto.AmiyaDepartment;
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
    public class AmiyaDepartmentController : ControllerBase
    {
        private IAmiyaDepartmentService amiyaDepartmentService;
        public AmiyaDepartmentController(IAmiyaDepartmentService amiyaDepartmentService)
        {
            this.amiyaDepartmentService = amiyaDepartmentService;
        }

        /// <summary>
        /// 获取所有部门列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<AmiyaDepartmentVo>>> GetListWithPageAsync(int pageNum, int pageSize)
        {
            var q = await amiyaDepartmentService.GetListWithPageAsync(pageNum, pageSize);
            var department = from d in q.List
                             select new AmiyaDepartmentVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Valid = d.Valid
                             };

            FxPageInfo<AmiyaDepartmentVo> departmentPageInfo = new FxPageInfo<AmiyaDepartmentVo>();
            departmentPageInfo.TotalCount = q.TotalCount;
            departmentPageInfo.List = department;
            return ResultData<FxPageInfo<AmiyaDepartmentVo>>.Success().AddData("department", departmentPageInfo);
        }



        /// <summary>
        /// 获取有效的部门名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<AmiyaDepartmentVo>>> GetNameListAsync()
        {
            var department = from d in await amiyaDepartmentService.GetNameListAsync()
                             select new AmiyaDepartmentVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Valid = d.Valid
                             };
            return ResultData<List<AmiyaDepartmentVo>>.Success().AddData("department", department.ToList());
        }



        /// <summary>
        /// 获取有效的直播需求部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameListOfRequirement")]
        public async Task<ResultData<List<AmiyaDepartmentVo>>> GetNameListOfRequirementAsync()
        {
            var department = from d in await amiyaDepartmentService.GetNameListOfRequirementAsync()
                             select new AmiyaDepartmentVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 Valid = d.Valid
                             };
            return ResultData<List<AmiyaDepartmentVo>>.Success().AddData("department", department.ToList());
        }


        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddAmiyaDepartmentVo addVo)
        {
            AddAmiyaDepartmentDto addDto = new AddAmiyaDepartmentDto();
            addDto.Name = addVo.Name;
            await amiyaDepartmentService.AddAsync(addDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 根据编号获取部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<AmiyaDepartmentVo>> GetByIdAsync(int id)
        {
            var department = await amiyaDepartmentService.GetByIdAsync(id);
            AmiyaDepartmentVo amiyaDepartmentVo = new AmiyaDepartmentVo();
            amiyaDepartmentVo.Id = department.Id;
            amiyaDepartmentVo.Name = department.Name;
            amiyaDepartmentVo.Valid = department.Valid;
            return ResultData<AmiyaDepartmentVo>.Success().AddData("department", amiyaDepartmentVo);
        }



        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateAmiyaDepartmentVo updateVo)
        {
            UpdateAmiyaDepartmentDto updateDto = new UpdateAmiyaDepartmentDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.Valid = updateVo.Valid;
            await amiyaDepartmentService.UpdateAsync(updateDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            await amiyaDepartmentService.DeleteAsync(id);
            return ResultData.Success();
        }
    }
}
