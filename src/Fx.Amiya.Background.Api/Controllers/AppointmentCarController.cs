using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.AppointmentCar;
using Fx.Amiya.Dto.AppointmentCar;
using Fx.Amiya.IService;
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
    /// 预约叫车
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AppointmentCarController : ControllerBase
    {
        private readonly IAppointmentCarService appointmentCarService;

        public AppointmentCarController(IAppointmentCarService appointmentCarService)
        {
            this.appointmentCarService = appointmentCarService;
        }

        /// <summary>
        /// 获取预约叫车信息列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="status">状态</param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<AppointmentCarVo>>> GetListWithPageAsync(string keyword,int pageNum, int pageSize, int? status)
        {
            var list = await appointmentCarService.GetListByPageAsync(keyword,pageNum, pageSize, status);
            FxPageInfo<AppointmentCarVo> fxPageInfo = new FxPageInfo<AppointmentCarVo>();
            fxPageInfo.TotalCount = fxPageInfo.TotalCount;
            fxPageInfo.List = list.List.Select(e => new AppointmentCarVo
            {
                Id = e.Id,
                AppointmentDate = e.AppointmentDate,
                Phone = e.Phone,
                Name = e.Name,
                Address = e.Address,
                Hospital = e.Hospital,
                CarType = e.CarType,
                CarTypeText = e.CarTypeText,
                ExchageType = e.ExchageType,
                ExchageTypeText = e.ExchageTypeText,
                Status = e.Status,
                StatusText = e.StatusText
            });
            return ResultData<FxPageInfo<AppointmentCarVo>>.Success().AddData("appointment", fxPageInfo);
        }
        /// <summary>
        /// 修改预约叫车信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAppointmentCar(UpdateAppointmentCarVo updateVo) {
            UpdateAppointmentCarDto updateAppointmentCarDto = new UpdateAppointmentCarDto();
            updateAppointmentCarDto.Id = updateVo.Id;
            updateAppointmentCarDto.Name = updateVo.Name;
            updateAppointmentCarDto.Phone = updateVo.Phone;
            updateAppointmentCarDto.AppointmentDate = updateVo.AppointmentDate;
            updateAppointmentCarDto.Address = updateVo.Address;
            updateAppointmentCarDto.Hospital = updateVo.Hospital;
            await appointmentCarService.UpdateAppointmentCarAsync(updateAppointmentCarDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据id获取预约叫车信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<ResultData<SimpleAppointmentCarVo>> GetById(string id) {
            var record= await appointmentCarService.GetAppointmentCarByIdAsync(id);
            SimpleAppointmentCarVo simpleAppointmentCarVo = new SimpleAppointmentCarVo();
            simpleAppointmentCarVo.Id = record.Id;
            simpleAppointmentCarVo.Name = record.Name;
            simpleAppointmentCarVo.Phone = record.Phone;
            simpleAppointmentCarVo.AppointmentDate = record.AppointmentDate;
            simpleAppointmentCarVo.Address = record.Address;
            simpleAppointmentCarVo.Hospital = record.Hospital;
            return ResultData<SimpleAppointmentCarVo>.Success().AddData("info", simpleAppointmentCarVo);
        }
        /// <summary>
        /// 获取预约叫车状态列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("appointmentCarTypeList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetConsumptionVoucherTypeListAsync()
        {
            var list = (await appointmentCarService.GetConsumptionVoucherTypeListAsync()).Select(c => new BaseIdAndNameVo
            {
                Id = c.Key,
                Name = c.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("appointmentCarTypeList", list);
        }
        /// <summary>
        /// 修改预约叫车状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("updateStaus")]
        public async Task<ResultData> UpdateStatus(UpdateAppointmentCarStatusVo update) {
            UpdateAppointmentCarStatusDto updateAppointmentCarStatusDto = new UpdateAppointmentCarStatusDto();
            updateAppointmentCarStatusDto.Id = update.Id;
            updateAppointmentCarStatusDto.Status = update.Status;
            await appointmentCarService.UpdateAppointmentCarStatusAsync(updateAppointmentCarStatusDto);
            return ResultData.Success();
        }


    }
}
