using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.Doctor;
using Fx.Amiya.Dto.Doctor;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 医生 API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalOrTenantAuthroize]
    public class DoctorController : ControllerBase
    {
        private IDoctorService doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }


        /// <summary>
        /// 获取医生信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<DoctorVo>>> GetListWithPageAsync(int?hospitalId,string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await doctorService.GetListWithPageAsync(hospitalId,keyword, pageNum, pageSize);

                var doctor = from d in q.List
                             select new DoctorVo
                             {
                                 Id = d.Id,
                                 Name = d.Name,
                                 PicUrl = d.PicUrl,
                                 DepartmentName = d.DepartmentName,
                                 Position = d.Position,
                                 ObtainEmploymentYear = d.ObtainEmploymentYear,
                                 HospitalId = d.HospitalId,
                                 HosptalName = d.HosptalName,
                                 IsMain=d.IsMain,
                                 Description=d.Description,
                                 ProjectPicture=d.ProjectPicture
                             };

                FxPageInfo<DoctorVo> doctorPageInfo = new FxPageInfo<DoctorVo>();
                doctorPageInfo.TotalCount = q.TotalCount;
                doctorPageInfo.List = doctor;

                return ResultData<FxPageInfo<DoctorVo>>.Success().AddData("doctorInfo", doctorPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<DoctorVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 添加医生信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddDoctorVo addVo)
        {
            try
            {
                AddDoctorDto addDto = new AddDoctorDto();
                addDto.Name = addVo.Name;
                addDto.PicUrl = addVo.PicUrl;
                addDto.Position = addVo.Position;
                addDto.ObtainEmploymentYear = addVo.ObtainEmploymentYear;
                addDto.HospitalId = addVo.HospitalId;
                addDto.Description = addVo.Description;
                addDto.DepartmentId = addVo.DepartmentId;
                addDto.IsMain = addVo.IsMain;
                addDto.ProjectPicture = addVo.ProjectPicture;
                await doctorService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据医生编号获取医生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<DoctorVo>> GetByIdAsync(int id)
        {
            try
            {
                var doctor = await doctorService.GetByIdAsync(id);
                DoctorVo doctorVo = new DoctorVo();
                doctorVo.Id = doctor.Id;
                doctorVo.Name = doctor.Name;
                doctorVo.PicUrl = doctor.PicUrl;
                doctorVo.Position = doctor.Position;
                doctorVo.ObtainEmploymentYear = doctor.ObtainEmploymentYear;
                doctorVo.HospitalId = doctor.HospitalId;
                doctorVo.HosptalName = doctor.HosptalName;
                doctorVo.Description = doctor.Description;
                doctorVo.DepartmentId = doctor.DepartmentId;
                doctorVo.IsMain = doctor.IsMain;
                doctorVo.ProjectPicture = doctor.ProjectPicture;

                return ResultData<DoctorVo>.Success().AddData("doctorInfo", doctorVo);
            }
            catch (Exception ex)
            {
                return ResultData<DoctorVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改医生信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateDoctorVo updateVo)
        {
            try
            {
                UpdateDoctorDto updateDto = new UpdateDoctorDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.PicUrl = updateVo.PicUrl;
                updateDto.Position = updateVo.Position;
                updateDto.ObtainEmploymentYear = updateVo.ObtainEmploymentYear;
                updateDto.HospitalId = updateVo.HospitalId;

                updateDto.Description = updateVo.Description;
                updateDto.DepartmentId = updateVo.DepartmentId;
                updateDto.IsMain = updateVo.IsMain;
                updateDto.ProjectPicture = updateVo.ProjectPicture;
                await doctorService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除医生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await doctorService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}