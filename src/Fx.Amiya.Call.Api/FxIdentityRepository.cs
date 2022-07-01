using Fx.Amiya.IService;
using Fx.Identity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Call.Api
{
    public class FxIdentityRepository : IFxIdentityRepository
    {
        private IAmiyaEmployeeService amiyaEmployeeService;
        public FxIdentityRepository(IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.amiyaEmployeeService = amiyaEmployeeService;
        }
        public async Task<FxInternalEmployeeIdentity> GetFxInternalEmployeeIdentityAsync(string id)
        {
            var employee = await amiyaEmployeeService.GetByIdAsync(Convert.ToInt32(id));
            return new FxAmiyaEmployeeIdentity()
            {
                Id = employee.Id.ToString(),
                Name = employee.Name,
                UserName = employee.UserName,
                Valid = employee.Valid,
                Frozen = false,
                PositionId = employee.PositionId.ToString(),
                PositionName = employee.PositionName,
                DepartmentId = employee.DepartmentId.ToString(),
                DepartmentName = employee.DepartmentName,
                IsCustomerService=employee.IsCustomerService
            };
        }

        public Task<FxPartnerIdentity> GetFxPartnerIdentityAsync(string appId)
        {
            throw new NotImplementedException();
        }

        public Task<FxTenantIdentity> GetFxTenantIdentityAsync(string tenantId)
        {
            throw new NotImplementedException();
        }
    }
}
