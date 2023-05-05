using Fx.Amiya.Dto;
using Fx.Amiya.Dto.CustomerAppointmentSchedule.Input;
using Fx.Amiya.Dto.CustomerAppointmentSchedule.Result;
using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerAppointmentScheduleService
    {
        Task<FxPageInfo<CustomerAppointmentScheduleDto>> GetListWithPageAsync(QueryCustomerAppointSchedulePageListDto query);
        /// <summary>
        /// 分页获取主播预约日程
        /// </summary>
        /// <param name="baseLiveAnchorId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <param name="type">预约类型</param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerAppointmentScheduleDto>> GetListWithPageByBaseLiveAnchorAsync(string liveAnchorId,int pageSize,int pageNum,int type);
        Task<List<CustomerAppointmentScheduleDto>> GetTodayImportantScheduleAsync();
        Task<List<CustomerAppointmentScheduleDto>> GetListByCalendarAsync(QueryCustomerAppointSchedulePageListDto query);
        Task AddAsync(AddCustomerAppointmentScheduleDto addDto);
        Task<CustomerAppointmentScheduleDto> GetByIdAsync(string id);

        Task<CustomerAppointmentScheduleDto> GetByEncryptPhoneAsync(string encryptPhone);
        Task UpdateAsync(UpdateCustomerAppointmentScheduleDto updateDto);
        Task DeleteAsync(string id);

        List<BaseIdAndNameDto> GetAppointmentTypeList();
        /// <summary>
        /// 完成客户预约日程
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="type">预约类型</param>
        /// <returns></returns>
        Task UpdateAppointmentCompleteStatusAsync(string phone,int type);
        /// <summary>
        /// 预约日程指派主播
        /// </summary>
        /// <param name="id"></param>
        /// <param name="AssignBy"></param>
        /// <returns></returns>
        Task AssignAsync(string id,string AssignBy);

    }
}
