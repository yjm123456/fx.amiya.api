using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.TaobaoAppInfo;
using Fx.Amiya.IService;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderAppInfoController : ControllerBase
    {
        private IOrderAppInfoService taobaoAppInfoService;
        private ILogger<OrderAppInfoController> logger;
        public OrderAppInfoController(IOrderAppInfoService taobaoAppInfoService, ILogger<OrderAppInfoController> logger)
        {
            this.taobaoAppInfoService = taobaoAppInfoService;
            this.logger = logger;
        }
        [HttpGet("appAuthorizeUrl")]
        public async Task<ResultData<TaobaoAppSimpleInfoVo>> GetTmallAppAuthorizeUrlAsync()
        {
            var taobaoAppInfo = await taobaoAppInfoService.GetTmallAppInfo();

            TaobaoAppSimpleInfoVo taobaoAppSimpleInfoVo = new TaobaoAppSimpleInfoVo();
            taobaoAppSimpleInfoVo.AppKey = taobaoAppInfo.AppKey;
            taobaoAppSimpleInfoVo.PortionRedirectUri = "/amiyabg/OrderAppInfo/tmallRedirect";
            return ResultData<TaobaoAppSimpleInfoVo>.Success().AddData("taobaoAppInfo", taobaoAppSimpleInfoVo);
         }


        /// <summary>
        /// 回调
        /// </summary>
        /// <returns></returns>
        [HttpGet("tmallRedirect")]
        public async Task<ResultData> RedirectAsync(string code)
        {
          //  string code =  Request.Query["code"].ToString();
            await taobaoAppInfoService.GetTmallAppAccessTokenAsync(code);
            return ResultData.Success();
        }
    }
}