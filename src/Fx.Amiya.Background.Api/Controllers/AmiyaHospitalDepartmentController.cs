using Fx.Amiya.Background.Api.Vo.AmiyaHospitalDepartment;
using Fx.Amiya.Dto.AmiyaHospitalDepartment;
using Fx.Amiya.IService;
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
    /// 医院科室数据板块接口
    /// </summary>

    [Route("[controller]")]
    [ApiController]
    public class AmiyaHospitalDepartmentController : ControllerBase
    {

        private IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaHospitalDepartmentService"></param>
        public AmiyaHospitalDepartmentController(IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService)
        {
            this.amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
        }


        /// <summary>
        /// 获取医院科室信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<AmiyaHospitalDepartmentVo>>> GetListWithPageAsync(string keyword)
        {
            try
            {
                var q = await amiyaHospitalDepartmentService.GetListWithPageAsync(keyword);

                var amiyaHospitalDepartment = from d in q.List
                              select new AmiyaHospitalDepartmentVo
                              {
                                  Id = d.Id,
                                  DepartmentName = d.DepartmentName,
                                  Description = d.Description,
                                  Valid = d.Valid,
                                  Sort=d.Sort
                              };

                FxPageInfo<AmiyaHospitalDepartmentVo> amiyaHospitalDepartmentPageInfo = new FxPageInfo<AmiyaHospitalDepartmentVo>();
                amiyaHospitalDepartmentPageInfo.TotalCount = q.TotalCount;
                amiyaHospitalDepartmentPageInfo.List = amiyaHospitalDepartment;

                return ResultData<FxPageInfo<AmiyaHospitalDepartmentVo>>.Success().AddData("amiyaHospitalDepartmentInfo", amiyaHospitalDepartmentPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<AmiyaHospitalDepartmentVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取医院科室id和名称（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAmiyaHospitalDepartmentList")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<AmiyaHospitalDepartmentIdAndNameVo>>> getAmiyaHospitalDepartmentList()
        {
            try
            {
                var q = await amiyaHospitalDepartmentService.GetIdAndNames();

                var amiyaHospitalDepartment = from d in q
                              select new AmiyaHospitalDepartmentIdAndNameVo
                              {
                                  Id = d.Id,
                                  DepartmentName = d.DepartmentName
                              };

                return ResultData<List<AmiyaHospitalDepartmentIdAndNameVo>>.Success().AddData("AmiyaHospitalDepartmentList", amiyaHospitalDepartment.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<AmiyaHospitalDepartmentIdAndNameVo>>.Fail().AddData("AmiyaHospitalDepartmentList", new List<AmiyaHospitalDepartmentIdAndNameVo>());
            }
        }


        /// <summary>
        /// 添加医院科室信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddAmiyaGoodsDemandVo addVo)
        {
            try
            {
                AddAmiyaHospitalDepartmentDto addDto = new AddAmiyaHospitalDepartmentDto();
                addDto.DepartmentName = addVo.DepartmentName;
                addDto.Description = addVo.Description;
                await amiyaHospitalDepartmentService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据医院科室编号获取医院科室信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<AmiyaHospitalDepartmentVo>> GetByIdAsync(string id)
        {
            try
            {
                var amiyaHospitalDepartment = await amiyaHospitalDepartmentService.GetByIdAsync(id);
                AmiyaHospitalDepartmentVo amiyaHospitalDepartmentVo = new AmiyaHospitalDepartmentVo();
                amiyaHospitalDepartmentVo.Id = amiyaHospitalDepartment.Id;
                amiyaHospitalDepartmentVo.DepartmentName = amiyaHospitalDepartment.DepartmentName;
                amiyaHospitalDepartmentVo.Description = amiyaHospitalDepartment.Description;
                amiyaHospitalDepartmentVo.Valid = amiyaHospitalDepartment.Valid;
                amiyaHospitalDepartmentVo.Sort = amiyaHospitalDepartment.Sort;
                return ResultData<AmiyaHospitalDepartmentVo>.Success().AddData("amiyaHospitalDepartmentInfo", amiyaHospitalDepartmentVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaHospitalDepartmentVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改医院科室信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateAmiyaGoodsDemandVo updateVo)
        {
            try
            {
                UpdateAmiyaHospitalDepartmentDto updateDto = new UpdateAmiyaHospitalDepartmentDto();
                updateDto.Id = updateVo.Id;
                updateDto.DepartmentName = updateVo.DepartmentName;
                updateDto.Description = updateVo.Description;
                updateDto.Valid = updateVo.Valid;
                await amiyaHospitalDepartmentService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除医院科室信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await amiyaHospitalDepartmentService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        /// <summary>
        /// 移动医院科室
        /// </summary>
        /// <param name="goodsCategoryMove">医院科室移动基础类</param>
        /// <returns></returns>
        [HttpPut("move")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateSortAsync(AmiyaHospitalDepartmentMoveVo goodsCategoryMove)
        {
            AmiyaHospitalDepartmentMoveDto hospitalDepartmentMoveDto = new AmiyaHospitalDepartmentMoveDto()
            {
                Id = goodsCategoryMove.Id,
                MoveState = goodsCategoryMove.MoveState
            };
            await amiyaHospitalDepartmentService.MoveAsync(hospitalDepartmentMoveDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 置顶/底医院科室
        /// </summary>
        /// <param name="goodsCategoryMove">医院科室移动基础类</param>
        /// <returns></returns>
        [HttpPut("movetopordown")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateTopOrDownAsync(AmiyaHospitalDepartmentMoveVo goodsCategoryMove)
        {
            AmiyaHospitalDepartmentMoveDto hospitalDepartmentDto = new AmiyaHospitalDepartmentMoveDto()
            {
                Id = goodsCategoryMove.Id,
                MoveState = goodsCategoryMove.MoveState,
            };
            await amiyaHospitalDepartmentService.MoveTopOrDownAsync(hospitalDepartmentDto);
            return ResultData.Success();
        }
    }
}
