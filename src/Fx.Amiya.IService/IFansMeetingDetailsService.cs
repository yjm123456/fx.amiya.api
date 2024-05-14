using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.FansMeetingDetails.Input;
using Fx.Amiya.Dto.FansMeetingDetails.Result;
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
    public interface IFansMeetingDetailsService
    {
        Task<FxPageInfo<FansMeetingDetailsDto>> GetListAsync(QueryFansMeetingDetailsDto query);
        Task AddAsync(AddFansMeetingDetailsDto addDto);
        Task<FansMeetingDetailsDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateFansMeetingDetailsDto updateDto);
        Task DeleteAsync(string id, int empId);
    }
}
