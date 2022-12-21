using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AppointmentCar;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    /// <summary>
    /// 预约叫车
    /// </summary>
    public class AppointmentCarService : IAppointmentCarService
    {
        private readonly IDalAppointmentCar dalAppointmentCar;
        private IDalConfig dalConfig;

        public AppointmentCarService(IDalAppointmentCar dalAppointmentCar, IDalConfig dalConfig)
        {
            this.dalAppointmentCar = dalAppointmentCar;
            this.dalConfig = dalConfig;
        }
        /// <summary>
        /// 添加预约叫车服务
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        public async Task AddAppointCar(AddAppointmentCarDto add)
        {
            //判断积分
            
            //判断优惠券

            AppointmentCar appointmentCar = new AppointmentCar();
            appointmentCar.Id = add.Id;
            appointmentCar.Name = add.Name;
            appointmentCar.Phone = add.Phone;
            appointmentCar.AppointmentDate = add.AppointmentDate;
            appointmentCar.Address = add.Address;
            appointmentCar.Hospital = add.Hospital;
            appointmentCar.CarType = add.CarType;
            appointmentCar.Valid = true;
            appointmentCar.CreateDate = DateTime.Now;
            appointmentCar.CustomerId = add.CustomerId;
            appointmentCar.Status = (int)AppointmentCarStatus.Commit;
            appointmentCar.ExchangeType = add.ExchangeType;
            await dalAppointmentCar.AddAsync(appointmentCar,true);
        }
        /// <summary>
        /// 根据id获取预约叫车信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AppointmentCarInfoDto> GetAppointmentCarByIdAsync(string id)
        {
            
            var record = dalAppointmentCar.GetAll().Where(e => e.Id == id).Select(e=>new AppointmentCarInfoDto { 
                Id=e.Id,
                Name=e.Name,
                Phone=e.Phone,
                AppointmentDate=e.AppointmentDate,
                Address=e.Address,
                Hospital=e.Hospital,
                Status=e.Status,
            }).SingleOrDefault();
            return record;

        }
        /// <summary>
        /// 预约叫车状态列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetConsumptionVoucherTypeListAsync()
        {
            var consumptionVoucherTypes = Enum.GetValues(typeof(AppointmentCarStatus));

            List<BaseKeyValueDto> consumptionVoucherTypeList = new List<BaseKeyValueDto>();
            foreach (var item in consumptionVoucherTypes)
            {
                BaseKeyValueDto baseKeyValueDto = new BaseKeyValueDto();
                baseKeyValueDto.Key = Convert.ToInt32(item).ToString();
                baseKeyValueDto.Value = ServiceClass.GetAppointCArStatusType(Convert.ToInt32(item));
                consumptionVoucherTypeList.Add(baseKeyValueDto);
            }
            return consumptionVoucherTypeList;
        }

        /// <summary>
        /// 后台获取预约叫车列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<AppointmentCarInfoDto>> GetListByPageAsync(string keyword,int pageNum, int pageSize,int? status)
        {
            var config = await GetCallCenterConfig();
            var record = dalAppointmentCar.GetAll().Where(e =>  e.Valid == true && (string.IsNullOrEmpty(keyword)||e.Name.Contains(keyword))&& (!status.HasValue||e.Status == status.Value)).OrderByDescending(e=>e.CreateDate).Select(e => new AppointmentCarInfoDto
            {
                Id=e.Id,
                Name=e.Name,
                Phone= config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(e.Phone) : e.Phone,
                AppointmentDate = e.AppointmentDate,
                Address = e.Address,
                Hospital = e.Hospital,
                CarType = e.CarType,
                CarTypeText = ServiceClass.GetAppointmentCarTypeText(e.CarType),
                Status = e.Status,
                StatusText = ServiceClass.GetAppointmentCarStatusText(e.Status),
                ExchageType = e.ExchangeType,
                ExchageTypeText = ServiceClass.GetAppointmentCarExchageType(e.ExchangeType)
            }); 
            FxPageInfo<AppointmentCarInfoDto> fxPageInfo = new FxPageInfo<AppointmentCarInfoDto>();
            fxPageInfo.TotalCount = record.Count();
            fxPageInfo.List = record.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }
        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }

        public async Task UpdateAppointmentCarAsync(UpdateAppointmentCarDto update)
        {
            var record = dalAppointmentCar.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            record.Name = update.Name;
            record.Phone = update.Phone;
            record.AppointmentDate = update.AppointmentDate;
            record.Address = update.Address;
            record.Hospital = update.Hospital;
            record.UpdateDate = DateTime.Now;
            await dalAppointmentCar.UpdateAsync(record,true);
        }

        public async Task UpdateAppointmentCarStatusAsync(UpdateAppointmentCarStatusDto update)
        {
            var record = dalAppointmentCar.GetAll().Where(e => e.Id == update.Id).SingleOrDefault();
            record.Status = update.Status;
            await dalAppointmentCar.UpdateAsync(record, true);
        }

        public async Task<FxPageInfo<WxAppointmentCarInfoDto>> WxGetListByPageAsync(string customerId, int pageNum, int pageSize, int? status)
        {
            var record = dalAppointmentCar.GetAll().Where(e => e.CustomerId == customerId && e.Valid == true && (!status.HasValue|| e.Status == status)).Select(e => new WxAppointmentCarInfoDto
            {
                Id=e.Id,
                AppointmentDate = e.AppointmentDate,
                Address = e.Address,
                Hospital = e.Hospital,
                CarType = e.CarType,
                CarTypeText = ServiceClass.GetAppointmentCarTypeText(e.CarType),
                Status = e.Status,
                StatusText = ServiceClass.GetAppointmentCarStatusText(e.Status),
                ExchageType=e.ExchangeType,
                ExchageTypeText=ServiceClass.GetAppointmentCarExchageType(e.ExchangeType)
            }); ; ;
            FxPageInfo<WxAppointmentCarInfoDto> fxPageInfo = new FxPageInfo<WxAppointmentCarInfoDto>();
            fxPageInfo.TotalCount = record.Count();
            fxPageInfo.List = record.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }


    }
}
