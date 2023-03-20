using Fx.Amiya.Background.Api.Vo.AestheticsDesignReport.Input;
using Fx.Amiya.Background.Api.Vo.AestheticsDesignReport.Output;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 美学设计报告
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AestheticsDesignReportController : ControllerBase
    {
        private readonly IAestheticsDesignReportService aestheticsDesignReportService;

        public AestheticsDesignReportController(IAestheticsDesignReportService aestheticsDesignReportService)
        {
            this.aestheticsDesignReportService = aestheticsDesignReportService;
        }
        /// <summary>
        /// 获取美学设计报告列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<AestheticsDesignReportVo> GetListByPage([FromQuery]QueryAestheticsDesignReportVo query) {
            return null;
        }
        
    }
}
