﻿using Fx.Amiya.IService;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 告知页面显示
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ControlPageShowController : ControllerBase
    {
        private readonly IControlPageShowService controlPageShowService;

        public ControlPageShowController(IControlPageShowService controlPageShowService)
        {
            this.controlPageShowService = controlPageShowService;
        }
        /// <summary>
        /// 判断是否显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultData<bool>> PageShow() {
            return ResultData<bool>.Success().AddData("visit",await controlPageShowService.IsShow());
        }
    }
}
