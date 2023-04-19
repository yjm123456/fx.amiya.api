using Fx.Amiya.Dto.CustomerAppointmentSchedule.Input;
using Fx.Amiya.Dto.CustomerAppointmentSchedule.Result;
using Fx.Amiya.Dto.MessageNotice.Input;
using Fx.Amiya.Dto.MessageNotice.Result;
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
    public interface IMessageNoticeService
    {
        Task<List<MessageNoticeDto>> GetListAsync(QueryMessageNoticeDto query);
        Task<int> GetMyUnReadAsync(int employeeId);
        Task AddAsync(AddMessageNoticeDto addDto);
        Task UpdateToReadAsync(UpdateMessageNoticeToReadDto updateDto);
    }
}
