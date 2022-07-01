using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.HospitalPosition;
using Fx.Amiya.Dto.HospitalPosition;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 医院职位 API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalPositionInfoController : ControllerBase
    {
        private IHospitalPositionInfoService hospitalPositionInfoService;
        private IHttpContextAccessor httpContextAccessor;
        public HospitalPositionInfoController(IHospitalPositionInfoService hospitalPositionInfoService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.hospitalPositionInfoService = hospitalPositionInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 管理员获取医院职位列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<HospitalPositionInfoVo>>> GetListAsync()
        {
            try
            {
                var positionInfos = from d in await hospitalPositionInfoService.GetListAsync()
                                    select new HospitalPositionInfoVo
                                    {
                                        Id = d.Id,
                                        Name = d.Name,
                                        CreateDate = d.CreateDate,
                                        UpdateDate = d.UpdateDate,
                                        UpdateBy = d.UpdateBy,
                                        UpdateName = d.UpdateName
                                    };
                return ResultData<List<HospitalPositionInfoVo>>.Success().AddData("positionInfo", positionInfos.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalPositionInfoVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 医院端获取医院职位列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getbyIdAndName")]
        [FxTenantAuthorize]
        public async Task<ResultData<List<HospitalSimplePositionInfoVo>>> GetByIdAndNameAsync()
        {
            try
            {
                var positionInfos = from d in await hospitalPositionInfoService.GetListAsync()
                                    select new HospitalSimplePositionInfoVo
                                    {
                                        Id = d.Id,
                                        Name = d.Name
                                    };
                return ResultData<List<HospitalSimplePositionInfoVo>>.Success().AddData("positionInfo", positionInfos.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalSimplePositionInfoVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加医院职位
        /// </summary>
         /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddHospitalPositionInfoVo addVo)
        {
            try
            {
                AddHospitalPositionInfoDto addDto = new AddHospitalPositionInfoDto();
                addDto.Name = addVo.Name;
                await hospitalPositionInfoService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 根据职位编号获取医院职位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<HospitalPositionInfoVo>> GetByIdAsync(int id)
        {
            try
            {
                var position = await hospitalPositionInfoService.GetByIdAsync(id);
                HospitalPositionInfoVo positionInfoVo = new HospitalPositionInfoVo();
                positionInfoVo.Id = position.Id;
                positionInfoVo.Name = position.Name;
                positionInfoVo.CreateDate = position.CreateDate;
                positionInfoVo.UpdateBy = position.UpdateBy;
                positionInfoVo.UpdateDate = position.UpdateDate;
                positionInfoVo.UpdateName = position.UpdateName;

                return ResultData<HospitalPositionInfoVo>.Success().AddData("positionInfo", positionInfoVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalPositionInfoVo>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 修改医院职位
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalPositionInfoVo updateVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                UpdateHospitalPositionInfoDto updateDto = new UpdateHospitalPositionInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;

                await hospitalPositionInfoService.UpdateAsync(updateDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 根据职位编号删除医院职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await hospitalPositionInfoService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}