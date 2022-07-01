using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Common;
using Fx.Amiya.IService;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Wx.Message.Api.Controllers
{
    [Route("fx/amiya/[controller]")]
    [ApiController]
    public class AppConfigurationController : ControllerBase
    {
        private IWxAppConfigService _service;
        private FxAppGlobal _fxAppGlobal;
        public AppConfigurationController(IWxAppConfigService service, FxAppGlobal fxAppGlobal)
        {
            _service = service;
            _fxAppGlobal = fxAppGlobal;
        }

        [HttpGet("reload")]
        public async Task<ResultData> Reload()
        {
            try
            {
                _fxAppGlobal.Reload();
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);

            }

        }
    }
}