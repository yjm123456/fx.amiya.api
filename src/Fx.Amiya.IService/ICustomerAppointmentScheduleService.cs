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
        Task<List<CustomerAppointmentScheduleDto>> GetTodayImportantScheduleAsync();
        Task<List<CustomerAppointmentScheduleDto>> GetListByCalendarAsync(QueryCustomerAppointSchedulePageListDto query);
        Task AddAsync(AddCustomerAppointmentScheduleDto addDto);
        Task<CustomerAppointmentScheduleDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateCustomerAppointmentScheduleDto updateDto);
        Task DeleteAsync(string id);

        List<BaseIdAndNameDto> GetAppointmentTypeList();


    }
}
