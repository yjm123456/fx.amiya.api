using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo.WxBInd;
using Fx.Common.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class WxBindNoticeController : ControllerBase
    {
        private readonly IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService;

        public WxBindNoticeController(IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService)
        {
            this.dockingHospitalCustomerInfoService = dockingHospitalCustomerInfoService;
        }

        [HttpGet("checkToken")]
        public async Task<string> CheckToken([FromQuery] WxBackInfo wxBackInfo)
        {
            return wxBackInfo.echostr;
        }
        /// <summary>
        /// 测试设置模板
        /// </summary>
        /// <returns></returns>
        [HttpGet("setTemplate")]
        public async Task SetTemplate()
        {


        }
    }
}
