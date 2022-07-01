using Fx.Amiya.Dto.LeaveMessage;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILeaveMessageService
    {
        
        Task<FxPageInfo<LeaveMessageUserDto>> GetListWithPageAsync(int pageNum, int pageSize);
    }
}
