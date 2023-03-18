using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class AestheticsDesignReportController : ControllerBase
    {
        private readonly IAestheticsDesignReportService aestheticsDesignReportService;

        public AestheticsDesignReportController(IAestheticsDesignReportService aestheticsDesignReportService)
        {
            this.aestheticsDesignReportService = aestheticsDesignReportService;
        }
        public async Task AddAestheticsDesignReport() { }
    }
}
