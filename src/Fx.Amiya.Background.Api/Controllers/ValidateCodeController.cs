using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Dto.ValidateCode;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common.Utils;
using Fx.Infrastructure.Utils;
using Fx.Open.Infrastructure.Web;
using Fx.Sms.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    /// <summary>
    /// 验证码api
    /// </summary>
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class ValidateCodeController : ControllerBase
    {
        private readonly static string s_templateName = "send_validate_code";
        private IValidateCodeService validateCodeService;
        private IHttpContextAccessor httpContextAccessor;
        private IFxSmsBasedTemplateSender smsSender;
        public ValidateCodeController(
            IValidateCodeService validateCodeService,
            IHttpContextAccessor httpContextAccessor,
            IFxSmsBasedTemplateSender smsSender)
        {
            this.validateCodeService = validateCodeService;
            this.smsSender = smsSender;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        [HttpPost("send/{phoneNumber}")]
        public async Task<ResultData> Send(string phoneNumber)
        {
            try
            {
                var url = httpContextAccessor.HttpContext.Request.Host.Value;
                if (url != "app.ameiyes.com:5620")
                {
                    throw new Exception("非法调用，数据获取失败");
                }
                AddValidateCodeDto addDto = new AddValidateCodeDto();
                addDto.PhoneNumber = phoneNumber;
                addDto.ExpireInSeconds = 60 * 15;
                addDto.Code = RandomUtil.CreateRandomCodeOnlyNum(4);

                var validateCode = await validateCodeService.AddAsync(addDto);

                if (validateCode != null)
                {
                    await smsSender.SendSingleAsync(phoneNumber, s_templateName, JsonConvert.SerializeObject(new { code = validateCode.Code }));
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
    }
}