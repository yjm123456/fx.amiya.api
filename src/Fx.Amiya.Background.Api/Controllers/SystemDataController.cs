using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SystemDataController : ControllerBase
    {

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        [HttpGet("serverTime")]
        public ResultData<DateTime> GetServerTime()
        {
            return ResultData<DateTime>.Success().AddData("serverTime",DateTime.Now);
        }



    }
}