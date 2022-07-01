using Fx.Amiya.Dto.AmiyaEmployee;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IEmployeeBindLiveAnchorService
    {
        Task<List<EmployeeBindLiveAnchorDto>> GetByEmpIdAsync(int employeeId);
        Task UpdateAsync(UpdateEmployeeBindLiveAnchorDto updateDto);
    }
}
