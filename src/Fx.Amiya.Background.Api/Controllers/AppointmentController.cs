using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.Appointment;
using Fx.Amiya.Dto.Appointment;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Identity.Core;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 预约 API
    /// </summary>
    [Route("[controller]")]
    [ApiController]

    public class AppointmentController : ControllerBase
    {
        private IAppointmentService appointmentService;
        private IHttpContextAccessor httpContextAccessor;

        public AppointmentController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            this.appointmentService = appointmentService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取预约列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<AppointmentInfoVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int pageNum, int pageSize)
        {
            try
            {
                int? hospitalId = null;
                int? employeeId = null;
                if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                {
                    hospitalId = tenant.HospitalId;
                }
                else {
                    var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                    employeeId = Convert.ToInt32(employee.Id);
                }

                var q = await appointmentService.GetListWithPageAsync(hospitalId, employeeId, startDate, endDate, pageNum, pageSize);

                var appointment = from d in q.List
                                  select new AppointmentInfoVo
                                  {
                                      Id = d.Id,
                                      AppointmentDate = d.AppointmentDate,
                                      Week = d.Week,
                                      Time = d.Time,
                                      Status = d.Status,
                                      StatusText = d.StatusText,
                                      ItemName = d.ItemName,
                                      Phone = d.Phone,
                                      EncryptPhone = d.EncryptPhone,
                                      CreateDate = d.CreateDate,
                                      SubmitDate = d.SubmitDate,
                                      HospitalId = d.HospitalId,
                                      HospitalName = d.HospitalName,
                                      AppointArea=d.AppointArea,
                                      Remark = d.Remark,
                                      EmpolyeeName=d.EmpolyeeName,
                                      Address=d.Address
                                  };

                FxPageInfo<AppointmentInfoVo> appointmentPageInfo = new FxPageInfo<AppointmentInfoVo>();
                appointmentPageInfo.TotalCount = q.TotalCount;
                appointmentPageInfo.List = appointment;

                return ResultData<FxPageInfo<AppointmentInfoVo>>.Success().AddData("apponintmentInfo", appointmentPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<AppointmentInfoVo>>.Fail(ex.Message);
            }
        }





        /// <summary>
        /// 根据加密手机号获取预约列表（分页）
        /// </summary>
        /// <param name="encryptPhone">加密手机号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listByEncryptPhone")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<AppointmentInfoVo>>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            try
            {
                var q = await appointmentService.GetListByEncryptPhoneAsync(encryptPhone, pageNum, pageSize);
                var appointment = from d in q.List
                                  select new AppointmentInfoVo
                                  {
                                      Id = d.Id,
                                      AppointmentDate = d.AppointmentDate,
                                      Week = d.Week,
                                      Time = d.Time,
                                      Status = d.Status,
                                      StatusText = d.StatusText,
                                      ItemName = d.ItemName,
                                      Phone = d.Phone,
                                      CreateDate = d.CreateDate,
                                      SubmitDate = d.SubmitDate,
                                      HospitalId = d.HospitalId,
                                      HospitalName = d.HospitalName,
                                      Remark = d.Remark
                                  };
                FxPageInfo<AppointmentInfoVo> appointmentPageInfo = new FxPageInfo<AppointmentInfoVo>();
                appointmentPageInfo.TotalCount = q.TotalCount;
                appointmentPageInfo.List = appointment;

                return ResultData<FxPageInfo<AppointmentInfoVo>>.Success().AddData("appointment", appointmentPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<AppointmentInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据编号获取预约信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<AppointmentInfoVo>> GetByIdAsync(int id)
        {
            var appointment = await appointmentService.GetByIdOfWxAsync(id);
            AppointmentInfoVo appointmentInfo = new AppointmentInfoVo();
            appointmentInfo.Id = appointment.Id;
            appointmentInfo.AppointmentDate = appointment.AppointmentDate;
            appointmentInfo.Week = appointment.Week;
            appointmentInfo.Time = appointment.Time;
            appointmentInfo.ItemName = appointment.ItemInfoName;
            appointmentInfo.Phone = appointment.Phone;
            appointmentInfo.AppointArea = appointment.AppointArea;
            appointmentInfo.Address = appointment.Address;
            appointmentInfo.HospitalId = appointment.HospitalInfo.HospitalId;
            return ResultData<AppointmentInfoVo>.Success().AddData("appointment", appointmentInfo);
        }

        /// <summary>
        /// 派单至对应医院
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <returns></returns>
        [HttpPut("sendToHospital")]
        [FxInternalAuthorize]
        public async Task<ResultData> SendToHospitallAsync([FromBody] SendToHospitalVo input)
        {
            try
            {
                await appointmentService.UpdateHospitalId(input.id, input.hospitalId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 修改预约信息
        /// </summary>
        /// <param name="input">预约信息</param>
        /// <returns></returns>
        [HttpPut("updateAppointment")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateAppointmentAsync([FromBody] UpdateAppointmentInfoVo input)
        {
            UpdateAppointmentInfoDto inputDto = new UpdateAppointmentInfoDto();
            inputDto.Id = input.Id;
            inputDto.AppointmentDate = input.AppointmentDate;
            inputDto.Week = input.Week;
            inputDto.Time = input.Time;
            inputDto.ItemName = input.ItemName;
            inputDto.Phone = input.Phone;
            inputDto.AppointArea = input.AppointArea;
            inputDto.Address = input.Address;
            inputDto.HospitalId = input.HospitalId;
            await appointmentService.UpdateAppointmentInfo(inputDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 修改预约信息备注
        /// </summary>
        /// <param name="input">预约信息</param>
        /// <returns></returns>
        [HttpPut("updateAppointmentRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateAppointmentRemarkAsync([FromBody] UpdateAppointmentRemarkVo input)
        {
            UpdateAppointmentRemarkDto inputDto = new UpdateAppointmentRemarkDto();
            inputDto.Id = input.Id;
            inputDto.Remark = input.Remark;
            await appointmentService.UpdateAppointmentRemarkInfo(inputDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 确认完成
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        [HttpPut("confirmFinish")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> ConfirmFinishAsync([Required] int id)
        {
            try
            {
                await appointmentService.ConfirmFinishAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 修改预约状态
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPut("updateStatus")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateStatusAsync(UpdateAppointStatusVo update) {
            UpdateAppointmentStatus updateAppointmentStatus = new UpdateAppointmentStatus();
            updateAppointmentStatus.Id = update.Id;
            updateAppointmentStatus.Status = update.Status;
            await appointmentService.UpdateAppointmentStatusAsync(updateAppointmentStatus);
            return ResultData.Success();
        }
        /// <summary>
        /// 获取预约状态列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("statusList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetStatusList() {
            var list = await appointmentService.GetAppointmentStatusListAsync();
            var result= list.Select(e=>new BaseIdAndNameVo { 
                Id=e.Key,
                Name=e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("statusList",result);
        }
    }
}