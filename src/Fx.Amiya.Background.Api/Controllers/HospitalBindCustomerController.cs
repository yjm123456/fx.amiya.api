using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.BindCustomerService;
using Fx.Amiya.Background.Api.Vo.HospitalCustomer;
using Fx.Amiya.Dto.BindCustomerService;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxTenantAuthorize]
    public class HospitalBindCustomerController : ControllerBase
    {
        private IHospitalBindCustomerService hospitalBindCustomerService;
        private IHttpContextAccessor httpContextAccessor;
        public HospitalBindCustomerController(IHospitalBindCustomerService hospitalBindCustomerService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.hospitalBindCustomerService = hospitalBindCustomerService;
            this.httpContextAccessor = httpContextAccessor;
        }




    }
}