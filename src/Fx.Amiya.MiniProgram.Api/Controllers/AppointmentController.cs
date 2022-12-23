using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Dto.Appointment;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.Appointment;
using Fx.Infrastructure.Utils;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Fx.Common.Utils;
using System.ComponentModel.DataAnnotations;
using Fx.Common;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{

    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService appointmentService;
        private IMiniSessionStorage sessionStorage;
        private TokenReader tokenReader;
        private IAmiyaGoodsDemandService _goodsDemandService;
        public AppointmentController(IAppointmentService appointmentService,
            IMiniSessionStorage sessionStorage,
            IAmiyaGoodsDemandService goodsDemandService,
            TokenReader tokenReader)
        {
            this.appointmentService = appointmentService;
            this.sessionStorage = sessionStorage;
            this.tokenReader = tokenReader;
            _goodsDemandService = goodsDemandService; 
        }

        ///// <summary>
        /////  获取预约已满的日期
        ///// </summary>
        ///// <param name="hospitalId"></param>
        ///// <param name="itemInfoId"></param>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <returns></returns>
        //[HttpGet("fullDays")]
        //public async Task<ResultData<List<int>>> GetAppointmentFullDaysAsync(int hospitalId, int itemInfoId, int year, int month)
        //{
        //    try
        //    {
        //        var q = await appointmentService.GetAppointmentFullDateAsync(hospitalId, itemInfoId, year, month);
        //        return ResultData<List<int>>.Success().AddData("dateList", q);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResultData<List<int>>.Fail(ex.Message);
        //    }
        //}


        /// <summary>
        /// 获取剩余预约数量
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="itemInfoId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("surplusQuantity")]
        public async Task<ResultData<AppointmentSurplusQuantityVo>> GetSurplusQuantityAsync(int hospitalId, int itemInfoId, DateTime date)
        {
            try
            {
                var q = await appointmentService.GetSurplusQuantityAsync(hospitalId, itemInfoId, date);
                AppointmentSurplusQuantityVo surplusQuantityVo = new AppointmentSurplusQuantityVo()
                {
                    AmSurplusQuantity = q.AmSurplusQuantity,
                    PmSurplusQuantity = q.PmSurplusQuantity
                };

                return ResultData<AppointmentSurplusQuantityVo>.Success().AddData("surplusQuantity", surplusQuantityVo);
            }
            catch (Exception ex)
            {
                return ResultData<AppointmentSurplusQuantityVo>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 判断客户是否有订单信息
        /// </summary>
        /// <param name="itemInfoId">项目编号</param>
        /// <returns></returns>
        [HttpGet("checkOrder/{itemInfoId}")]
        public async Task<ResultData> CheckOrderAsync(int itemInfoId)
        {
            try
            {
                var token = tokenReader.GetToken();
                var sesssionInfo = sessionStorage.GetSession(token);
                string customerId = sesssionInfo.FxCustomerId;


                await appointmentService.CheckOrderAsync(customerId, itemInfoId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加预约
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns>预约编号</returns>
        [HttpPost("add")]
        public async Task<ResultData<int>> AddAsync(AddAppointmentVo addVo)
        {
            try
            {
                var token = tokenReader.GetToken();
                var sesssionInfo = sessionStorage.GetSession(token);
                string customerId = sesssionInfo.FxCustomerId;

                AddAppointmentDto addDto = new AddAppointmentDto();
                addDto.AppointmentDate = addVo.AppointmentDate;
                addDto.Week = addVo.Week;
                addDto.Time = addVo.Time;
                addDto.CustomerName = addVo.CustomerName;
                addDto.CreateDate = DateTime.Now;
                addDto.Phone = addVo.Phone;
                addDto.Remark = addVo.Remark;
                addDto.HospitalId = addVo.HospitalId;
                addDto.ItemInfoName = addVo.ItemInfoName;

                int appointmentId = await appointmentService.AddAsync(addDto, customerId);
                return ResultData<int>.Success().AddData("appointmentId", appointmentId);
            }
            catch (Exception ex)
            {
                return ResultData<int>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取预约列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        ///<param name = "status" > 1:计划中 2:已取消</param>
        /// <param name="itemName">项目名称</param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<WxAppointmentInfoVo>>> GetListOfWxAsync([Required] int pageNum, [Required] int pageSize, int status, string itemName)
        {
            try
            {
                var token = tokenReader.GetToken();
                var sesssionInfo = sessionStorage.GetSession(token);
                string customerId = sesssionInfo.FxCustomerId;
                var q = await appointmentService.GetListOfWxAsync(pageNum, pageSize, status, itemName, customerId);
                var appointment = from d in q.List
                                  select new WxAppointmentInfoVo
                                  {
                                      Id = d.Id,
                                      AppointmentDate = d.AppointmentDate,
                                      Week = d.Week,
                                      Time = d.Time,
                                      Status = d.Status,
                                      CreateDate = d.CreateDate,
                                      SubmitDate = d.SubmitDate,
                                      Phone = d.Phone,
                                      Remark = d.Remark,
                                      ItemInfoName = d.ItemInfoName,
                                      ItemInfopicUrl = _goodsDemandService.GetByNameAsync(d.ItemInfoName).Result.ThumbPictureUrl,
                                      HospitalInfo = new AppointmentHospitalVo
                                      {
                                          HospitalId = d.HospitalInfo.HospitalId,
                                          HospitalName = d.HospitalInfo.HospitalName,
                                          ThumbPicture = d.HospitalInfo.ThumbPicture,
                                          Longitude = d.HospitalInfo.Longitude,
                                          Latitude = d.HospitalInfo.Latitude,
                                          HospitalPhone = d.HospitalInfo.HospitalPhone,
                                      }
                                  };
                FxPageInfo<WxAppointmentInfoVo> orderWriteOffInfo = new FxPageInfo<WxAppointmentInfoVo>();
                orderWriteOffInfo.TotalCount = q.TotalCount;
                orderWriteOffInfo.List = appointment;
                orderWriteOffInfo.PageSize = pageSize;
                orderWriteOffInfo.PageCount = appointment.Count();
                orderWriteOffInfo.CurrentPageIndex = pageNum;
                return ResultData<FxPageInfo<WxAppointmentInfoVo>>.Success().AddData("appointmentInfo", orderWriteOffInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<WxAppointmentInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据预约编号获取预约信息
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<WxAppointmentInfoVo>> GetByIdOfWxAsync(int id)
        {
            try
            {
                var appointment = await appointmentService.GetByIdOfWxAsync(id);
                WxAppointmentInfoVo appointmentInfo = new WxAppointmentInfoVo()
                {
                    AppointmentDate = appointment.AppointmentDate,
                    Week = appointment.Week,
                    Time = appointment.Time,
                    Status = appointment.Status,
                    CreateDate = appointment.CreateDate,
                    SubmitDate = appointment.SubmitDate,
                    Phone = appointment.Phone,
                    Remark = appointment.Remark,
                    ItemInfoName = appointment.ItemInfoName,
                    ItemInfopicUrl = _goodsDemandService.GetByNameAsync(appointment.ItemInfoName).Result.ThumbPictureUrl,
                    HospitalInfo = new AppointmentHospitalVo
                    {
                        HospitalId = appointment.HospitalInfo.HospitalId,
                        HospitalName = appointment.HospitalInfo.HospitalName,
                        ThumbPicture = appointment.HospitalInfo.ThumbPicture,
                        Longitude = appointment.HospitalInfo.Longitude,
                        Latitude = appointment.HospitalInfo.Latitude,
                        HospitalPhone = appointment.HospitalInfo.HospitalPhone,
                        Address = appointment.HospitalInfo.Address
                    }
                };

                return ResultData<WxAppointmentInfoVo>.Success().AddData("appointmentInfo", appointmentInfo);
            }
            catch (Exception ex)
            {
                return ResultData<WxAppointmentInfoVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取预约二维码图片
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        [HttpGet("qrcodeImage/{id}")]
        public async Task<IActionResult> GetQrCodeImage(int id)
        {
            var appointmentData = new { appointmentId = id };
            string content = JsonConvert.SerializeObject(appointmentData);
            string encryptConent = new DesHelper("test1234").EncryptToBase64String(content);
            var imageBytes = await ImageUtil.ImageToBytesAsync(await QrCodeUtil.GetQrCodeAsync(encryptConent));
            return File(imageBytes, "image/jpeg");
        }


        /// <summary>
        /// 获取预约二维码（Base64）
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        [HttpGet("qrcodeBase64/{id}")]
        public async Task<ResultData<string>> GetQrCodeBase64(int id)
        {
            try
            {
                var appointmentData = new { appointmentId = id };
                var content = JsonConvert.SerializeObject(appointmentData);
                string encryptConent = new DesHelper("test1234").EncryptToBase64String(content);
                var imageBytes = await ImageUtil.ImageToBytesAsync(await QrCodeUtil.GetQrCodeAsync(encryptConent));
                if (imageBytes != null)
                {
                    return ResultData<string>.Success().AddData("qrCodeBase64", Convert.ToBase64String(imageBytes));
                }
                else
                {
                    return ResultData<string>.Fail("预约二维码获取失败");
                }
            }
            catch (Exception ex)
            {
                return ResultData<string>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 取消预约
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        [HttpPut("cancel")]
        public async Task<ResultData> CancelAsync([FromBody] int id)
        {
            try
            {
                await appointmentService.CancelAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 确认完成
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        [HttpPut("confirmFinish")]
        public async Task<ResultData> ConfirmFinishAsync([FromBody] int id)
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
        /// 获取最近一次预约的医院名称
        /// </summary>
        /// <returns></returns>
        [HttpGet("getMostRecentlyAppointment")]
        public async Task<ResultData<AppointmentSimpleInfoVo>> GetMostRecentlyAppointment() {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var info= await appointmentService.GetMostRecentlyAppointmentAsync(customerId);
            AppointmentSimpleInfoVo appointmentSimpleInfoVo = new AppointmentSimpleInfoVo();
            appointmentSimpleInfoVo.HospitalName = info.HospitalName;
            return ResultData<AppointmentSimpleInfoVo>.Success().AddData("name", appointmentSimpleInfoVo);
        }
    }
}