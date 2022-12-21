using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Dto.AppointmentCar;
using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.AppointmentCar;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
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
        private IIntegrationAccount integrationAccountService;
        private ICustomerConsumptionVoucherService customerConsumptionVoucherService;
        private readonly IUnitOfWork unitOfWork;
        public AppointmentCarController(IAppointmentCarService appointmentCarService, TokenReader tokenReader, IMiniSessionStorage sessionStorage, IIntegrationAccount integrationAccountService, ICustomerConsumptionVoucherService customerConsumptionVoucherService, IUnitOfWork unitOfWork)
        {
            this.appointmentCarService = appointmentCarService;
            this.tokenReader = tokenReader;
            this.sessionStorage = sessionStorage;
            this.integrationAccountService = integrationAccountService;
            this.customerConsumptionVoucherService = customerConsumptionVoucherService;
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 根据状态获取预约叫车信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<AppointmentCarVo>>> GetListWithPageAsync(int pageNum,int pageSize,int? status) {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var list= await appointmentCarService.WxGetListByPageAsync(customerId,pageNum,pageSize,status);
            FxPageInfo<AppointmentCarVo> fxPageInfo = new FxPageInfo<AppointmentCarVo>();
            fxPageInfo.TotalCount = fxPageInfo.TotalCount;
            fxPageInfo.List = list.List.Select(e=>new AppointmentCarVo { 
                Id=e.Id,
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
            try
            {
                unitOfWork.BeginTransaction();
                if (string.IsNullOrEmpty(add.VoucherId))
                {
                    decimal TotalIntegration = 0;
                    switch (add.CarType)
                    {
                        case 0:
                            TotalIntegration = 1000m;
                            break;
                        case 1:
                            TotalIntegration = 1500m;
                            break;
                        case 2:
                            TotalIntegration = 3000m;
                            break;
                        case 3:
                            TotalIntegration = 4500m;
                            break;
                    }
                    if (TotalIntegration == 0)
                    {
                        throw new Exception("车型错误");
                    }
                    decimal integrationBalance = await integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(customerId);
                    if (TotalIntegration > integrationBalance)
                        throw new Exception("积分余额不足");
                    AddAppointmentCarDto addAppointmentCarDto = new AddAppointmentCarDto();
                    addAppointmentCarDto.Id = Guid.NewGuid().ToString().Replace("-", "");
                    UseIntegrationDto useIntegrationDto = new UseIntegrationDto();
                    useIntegrationDto.CustomerId = customerId;
                    useIntegrationDto.OrderId = addAppointmentCarDto.Id;
                    useIntegrationDto.Date = DateTime.Now;
                    useIntegrationDto.UseQuantity = TotalIntegration;
                    await integrationAccountService.UseByGoodsConsumption(useIntegrationDto);
                    addAppointmentCarDto.Name = add.Name;
                    addAppointmentCarDto.Phone = add.Phone;
                    addAppointmentCarDto.AppointmentDate = add.AppointmentDate;
                    addAppointmentCarDto.Address = add.Address;
                    addAppointmentCarDto.Hospital = add.Hospital;
                    addAppointmentCarDto.CarType = add.CarType;
                    addAppointmentCarDto.ExchangeType = add.ExchageType;
                    addAppointmentCarDto.CustomerId = customerId;
                    addAppointmentCarDto.ExchangeType = (int)AppointmentCarExchangeType.PointDeduction;
                    await appointmentCarService.AddAppointCar(addAppointmentCarDto);
                    unitOfWork.Commit();
                    return ResultData.Success();
                }
                else {
                    var voucher = await customerConsumptionVoucherService.GetCarVoucherByCustomerIdAndVoucherIdAsync(customerId, add.VoucherId);
                    if (voucher == null) throw new Exception("没有此抵用券信息");
                    if (voucher.IsUsed) throw new Exception("该抵用券已被使用");
                    string carType = "";
                    switch (add.CarType) {
                        case 0:
                            carType = "jjx";
                            break;
                        case 1:
                            carType = "ssx";
                            break;
                        case 2:
                            carType = "swx";
                            break;
                        case 3:
                            carType = "hhx";
                            break;

                    }
                    if (string.IsNullOrEmpty(carType)) {
                        throw new Exception("车型错误");
                    }
                    if (voucher.VoucherCode == carType)
                    {
                        UpdateCustomerConsumptionVoucherDto update = new UpdateCustomerConsumptionVoucherDto
                        {
                            CustomerVoucherId = voucher.Id,
                            IsUsed = true,
                            UseDate = DateTime.Now
                        };
                        await customerConsumptionVoucherService.UpdateCustomerConsumptionVoucherUseStatusAsync(update);
                    }
                    else {
                        throw new Exception("所选车型不能使用该抵用券");
                    }

                    
                    AddAppointmentCarDto addAppointmentCarDto = new AddAppointmentCarDto();
                    addAppointmentCarDto.Id = Guid.NewGuid().ToString().Replace("-", "");
                    addAppointmentCarDto.Name = add.Name;
                    addAppointmentCarDto.Phone = add.Phone;
                    addAppointmentCarDto.AppointmentDate = add.AppointmentDate;
                    addAppointmentCarDto.Address = add.Address;
                    addAppointmentCarDto.Hospital = add.Hospital;
                    addAppointmentCarDto.CarType = add.CarType;
                    addAppointmentCarDto.ExchangeType = (int)AppointmentCarExchangeType.VoucherDeduction;
                    addAppointmentCarDto.CustomerId = customerId;
                    await appointmentCarService.AddAppointCar(addAppointmentCarDto);
                    unitOfWork.Commit();
                    return ResultData.Success();
                }
                
            }
            catch (Exception ex) {
                unitOfWork.RollBack();
                throw new Exception("预约叫车失败");
            }
            
           
            
        }
        /// <summary>
        /// 修改预约叫车状态
        /// </summary>
        /// <returns></returns>
        [HttpPut("cancel")]
        public async Task<ResultData> UpdateStatus(UpdateAppointmentCarStatusVo update)
        {
            var record= await appointmentCarService.GetAppointmentCarByIdAsync(update.Id);
            if (record.Status!=0) {
                throw new Exception("预约状态已更改,请联系客服处理");
            }
            UpdateAppointmentCarStatusDto updateAppointmentCarStatusDto = new UpdateAppointmentCarStatusDto();
            updateAppointmentCarStatusDto.Id = update.Id;
            updateAppointmentCarStatusDto.Status = (int)AppointmentCarStatus.Cancle;
            await appointmentCarService.UpdateAppointmentCarStatusAsync(updateAppointmentCarStatusDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 判断是否有该车型的抵用券
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpGet("getWheatherHaveCarVoucher")]
        public async Task<ResultData<string>> GetWheatherHaveCarVoucher(int car) {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            string carType = "";
            switch (car)
            {
                case 0:
                    carType = "jjx";
                    break;
                case 1:
                    carType = "ssx";
                    break;
                case 2:
                    carType = "swx";
                    break;
                case 3:
                    carType = "hhx";
                    break;

            }
            var voucher= await customerConsumptionVoucherService.GetCarTypeVoucherByCustomerIdAndVoucherIdAsync(customerId,carType);
            if (voucher == null)
            {
                return ResultData<string>.Success().AddData("voucherId", "");
            }
            else {
                return ResultData<string>.Success().AddData("voucherId", voucher.Id);
            }
           
        }
    }
}
