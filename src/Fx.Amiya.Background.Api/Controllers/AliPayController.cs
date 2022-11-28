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
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AliPayController : ControllerBase
    {
        private readonly IAliPayService aliPayService;

        public AliPayController(IAliPayService aliPayService)
        {
            this.aliPayService = aliPayService;
        }
        [HttpPost("refund/{tradeId}")]
        public async Task Refund(string tradeId) {
            await aliPayService.OrderRefund(tradeId);
        }
    }
}
