using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fx.Common.Utils;
using Fx.Infrastructure.Utils;
using Fx.Weixin.MP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fx.Amiya.Wx.Message.Api.Controllers
{
    [Route("fx/amiya/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private ILogger<MessageController> logger;
        private FxMessageHandler _fxMessageHandler;
        private static string token;
      
        public MessageController(ILogger<MessageController> logger, FxMessageHandler fxMessageHandler, IConfiguration configuration)
        {
            this.logger = logger;
            _fxMessageHandler = fxMessageHandler;
            if (string.IsNullOrEmpty(token))
            {
                token = configuration.GetValue<string>("MpConfig:Token");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get(string signature, string timestamp, string nonce, string echostr)
        {


            var fxsignature = CheckSignature.GetSignature(timestamp, nonce, token);

            if (CheckSignature.Check(signature, timestamp, nonce, token))
            {

                return Content(echostr);
            }
            else
            {

                return Content("failed");
            }
        }
        [HttpPost]
        public async Task Post()
        {
            try
            {
                var stream = HttpContext.Request.Body;
                var requestMessageXml = await new StreamReader(stream).ReadToEndAsync();

                //logger.LogInformation(requestMessageXml);
                _fxMessageHandler.RequestMessageXml = requestMessageXml;
                var responseMessage = await _fxMessageHandler.HandleAsync();

                if (responseMessage == null)
                {

                    await HttpContext.Response.WriteAsync("");
                }
                else
                {
                    string rspString = XmlUtil.Serialize(responseMessage);

                    await HttpContext.Response.WriteAsync(rspString);
                }
            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message);
            }

        }
    }
}
