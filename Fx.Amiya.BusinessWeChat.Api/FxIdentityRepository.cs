using Fx.Amiya.IService;
using Fx.Identity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api
{
    public class FxIdentityRepository : IFxIdentityRepository
    {
        private IAmiyaEmployeeService amiyaEmployeeService;
        private IHospitalEmployeeService hospitalEmployeeService;
        public FxIdentityRepository(IAmiyaEmployeeService amiyaEmployeeService,
            IHospitalEmployeeService hospitalEmployeeService)
        {
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.hospitalEmployeeService = hospitalEmployeeService;
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
                IsCustomerService = employee.IsCustomerService
            };
        }

        public Task<FxPartnerIdentity> GetFxPartnerIdentityAsync(string appId)
        {
            throw new NotImplementedException();
        }

        public async Task<FxTenantIdentity> GetFxTenantIdentityAsync(string tenantId)
        {
            var employee = await hospitalEmployeeService.GetByIdAsync(Convert.ToInt32(tenantId));
            return new FxAmiyaHospitalEmployeeIdentity()
            {
                Id = employee.Id.ToString(),
                Name = employee.Name,
                UserName = employee.UserName,
                Valid = employee.Valid,
                Frozen = false,
                PositionId = employee.HospitalPositionId.ToString(),
                HospitalId = employee.HospitalId
            };
        }
    }
}
