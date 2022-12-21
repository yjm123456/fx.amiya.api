using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AppointmentCar;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    /// <summary>
    /// 预约叫车
    /// </summary>
    public interface IAppointmentCarService
    {
        /// <summary>
        /// 添加预约叫车
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        Task AddAppointCar(AddAppointmentCarDto add);
        /// <summary>
        /// 小程序获取预约叫车列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<WxAppointmentCarInfoDto>> WxGetListByPageAsync(string customerId,int pageNum,int pageSize,int? status);
        /// <summary>
        /// 后台获取预约叫车列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<AppointmentCarInfoDto>> GetListByPageAsync(string keyword,int pageNum, int pageSize,int? status);
        /// <summary>
        /// 修改预约叫车信息
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        Task UpdateAppointmentCarAsync(UpdateAppointmentCarDto update);
        /// <summary>
        /// 根据id获取预约叫车信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AppointmentCarInfoDto> GetAppointmentCarByIdAsync(string id);
        /// <summary>
        /// 获取预约叫车状态列表
        /// </summary>
        /// <returns></returns>
        Task<List<BaseKeyValueDto>> GetConsumptionVoucherTypeListAsync();
        /// <summary>
        /// 修改预约叫车状态
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        Task UpdateAppointmentCarStatusAsync(UpdateAppointmentCarStatusDto update);

    }
}
