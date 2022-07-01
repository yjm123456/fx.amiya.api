using Fx.Amiya.Dto.Appointment;
using Fx.Amiya.Dto.OrderReport;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAppointmentService
    {
        /// <summary>
        /// 获取预约列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<AppointmentInfoDto>> GetListWithPageAsync(int? hospitalId, int? employeeId, DateTime? startDate, DateTime? endDate, int pageNum, int pageSize);



        /// <summary>
        /// 获取预约经营情况报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<AppointmentOperationConditionDto>> GetAppointmentOperationConditionAsync(DateTime? startDate, DateTime? endDate);

        ///// <summary>
        ///// 获取预约已满的日期
        ///// </summary>
        ///// <param name="hospitalId"></param>
        ///// <param name="itemInfoId"></param>
        ///// <returns></returns>
        //Task<List<int>> GetAppointmentFullDateAsync(int hospitalId, int itemInfoId, int year, int month);


        /// <summary>
        /// 根据医院编号和日期获取剩余预约数量
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<AppointmentSurplusQuantityDto> GetSurplusQuantityAsync(int hospitalId,int itemId, DateTime date);


        /// <summary>
        /// 判断客户是否有订单信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="itemInfoId"></param>
        /// <returns></returns>
        Task CheckOrderAsync(string customerId, int itemInfoId);


        /// <summary>
        /// 添加预约
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<int> AddAsync(AddAppointmentDto addDto, string customerId);


        /// <summary>
        ///获取预约列表（小程序）
        /// </summary>
        /// <param name="status">  0=全部，1=待完成，2=已完成，3=已取消</param>
        /// <returns></returns>
        Task<FxPageInfo<WxAppointmentInfoDto>> GetListOfWxAsync(int pageNum,int pageSize, int status, string itemName, string customerId);

        /// <summary>
        /// 根据预约编号获取预约信息（小程序）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WxAppointmentInfoDto> GetByIdOfWxAsync(int id);


        /// <summary>
        /// 取消预约
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        Task CancelAsync(int id);

        /// <summary>
        /// 派单至对应医院
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <param name="hospitalId">医院编号</param>
        /// <returns></returns>
        Task UpdateHospitalId(int id,int hospitalId);

        /// <summary>
        /// 修改预约信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAppointmentInfo(UpdateAppointmentInfoDto input);


        /// <summary>
        /// 修改预约备注
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAppointmentRemarkInfo(UpdateAppointmentRemarkDto input);

        /// <summary>
        /// 确认完成
        /// </summary>
        /// <param name="id">预约编号</param>
        /// <returns></returns>
        Task ConfirmFinishAsync(int id);



        Task CancelOverTimeAsync();


        /// <summary>
        /// 根据加密手机号获取预约列表（分页）
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        Task<FxPageInfo<AppointmentInfoDto>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize);

        #region 报表模块

        /// <summary>
        /// 获取客户预约报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<AppointmentReportDto>> GetAppointmentReportAsync(DateTime? startDate, DateTime? endDate, int status, bool isHidePhone);

        /// <summary>
        /// 获取医院预约报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<AppointmentReportDto>> GetHospitalAppointmentReportAsync(DateTime? startDate, DateTime? endDate, string hosiptalName, bool isHidePhone);

        #endregion
    }
}
