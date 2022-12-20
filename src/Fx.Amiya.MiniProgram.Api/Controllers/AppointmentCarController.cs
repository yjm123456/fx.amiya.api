using Fx.Amiya.Dto.AppointmentCar;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.AppointmentCar;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    /// <summary>
    /// 预约叫车
    /// </summary>
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class AppointmentCarController : ControllerBase
    {
        private readonly IAppointmentCarService appointmentCarService;
        private TokenReader tokenReader;
        private IMiniSessionStorage sessionStorage;
        public AppointmentCarController(IAppointmentCarService appointmentCarService, TokenReader tokenReader, IMiniSessionStorage sessionStorage)
        {
            this.appointmentCarService = appointmentCarService;
            this.tokenReader = tokenReader;
            this.sessionStorage = sessionStorage;
        }
        /// <summary>
        /// 根据状态获取预约叫车信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<AppointmentCarVo>>> GetListWithPageAsync(int pageNum,int pageSize,int status) {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var list= await appointmentCarService.WxGetListByPageAsync(customerId,pageNum,pageSize,status);
            FxPageInfo<AppointmentCarVo> fxPageInfo = new FxPageInfo<AppointmentCarVo>();
            fxPageInfo.TotalCount = fxPageInfo.TotalCount;
            fxPageInfo.List = list.List.Select(e=>new AppointmentCarVo { 
                AppointmentDate=e.AppointmentDate,
                Address=e.Address,
                Hospital=e.Hospital,
                CarType=e.CarType,
                CarTypeText=e.CarTypeText,
                ExchageType=e.ExchageType,
                ExchageTypeText=e.ExchageTypeText,
                Status=e.Status,
                StatusText=e.StatusText
            });
            return ResultData<FxPageInfo<AppointmentCarVo>>.Success().AddData("appointment", fxPageInfo);
        }
        /// <summary>
        /// 添加预约叫车
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAppointmentCar(AddAppointmentCarVo add) {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            AddAppointmentCarDto addAppointmentCarDto = new AddAppointmentCarDto();
            addAppointmentCarDto.Name = add.Name;
            addAppointmentCarDto.Phone = add.Phone;
            addAppointmentCarDto.AppointmentDate = add.AppointmentDate;
            addAppointmentCarDto.Address = add.Address;
            addAppointmentCarDto.Hospital = add.Hospital;
            addAppointmentCarDto.CarType = add.CarType;
            addAppointmentCarDto.ExchangeType = add.ExchageType;
            addAppointmentCarDto.CustomerId = customerId;
            await appointmentCarService.AddAppointCar(addAppointmentCarDto);
            return ResultData.Success();
        }

    }
}
