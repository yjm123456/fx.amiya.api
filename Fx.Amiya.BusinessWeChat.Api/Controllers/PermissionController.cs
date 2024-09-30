using System;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.BusinessWechat.Api;
using Fx.Amiya.BusinessWeChat.Api.Vo.Permission;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalOrTenantAuthroize]
    public class PermissionController : ControllerBase
    {

        private IPermissionService permissionService;
        private IHttpContextAccessor httpContextAccessor;
        public PermissionController(IPermissionService permissionService, IHttpContextAccessor httpContextAccessor)
        {
            this.permissionService = permissionService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("collection")]
        public async Task<ResultData<PermissionCollectionVo>> GetPermissionsAsync()
        {
            string employeeType = "";
            int positionId = 0;
            int employeeId = 0;

            if (httpContextAccessor.HttpContext.User is FxAmiyaEmployeeIdentity employee)
            {
                employeeId = Convert.ToInt32(employee.Id);
                positionId = Convert.ToInt32(employee.PositionId);
                employeeType = EmployeeTypeConstant.AMIYA_EMPLOYEE_TYPE;
            }

            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
            {
                employeeId = Convert.ToInt32(tenant.Id);
                positionId = Convert.ToInt32(tenant.PositionId);
                employeeType = EmployeeTypeConstant.HOSPITAL_EMPLOYEE_TYPE;
            }
            PermissionCollectionVo permissionCollection = new PermissionCollectionVo();


            permissionCollection.Permissions = await permissionService.GetPermissionListAsync(employeeType, employeeId, positionId);


            return ResultData<PermissionCollectionVo>.Success().AddData("permissions", permissionCollection);
        }

    }
}