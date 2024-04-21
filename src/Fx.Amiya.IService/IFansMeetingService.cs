using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.FansMeeting.Input;
using Fx.Amiya.Dto.FansMeeting.Result;
using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.Performance.BusinessWechatDto;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IFansMeetingService
    {
        Task<FxPageInfo<FansMeetingDto>> GetListAsync(QueryFansMeetingDto query);
        Task AddAsync(AddFansMeetingDto addDto);
        Task<FansMeetingDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateFansMeetingDto updateDto);
        Task DeleteAsync(string id);
    }
}
