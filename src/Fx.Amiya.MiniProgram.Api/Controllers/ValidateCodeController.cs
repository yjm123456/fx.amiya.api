using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Dto.ValidateCode;
using Fx.Amiya.IService;
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
        private IFxSmsBasedTemplateSender smsSender;
        public ValidateCodeController(
            IValidateCodeService validateCodeService,
            IFxSmsBasedTemplateSender smsSender)
        {
            this.validateCodeService = validateCodeService;
            this.smsSender = smsSender;
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
                AddValidateCodeDto addDto = new AddValidateCodeDto();
                addDto.PhoneNumber = phoneNumber;
                addDto.ExpireInSeconds = 60 * 15;
                addDto.Code = RandomUtil.CreateRandomCodeOnlyNum(4);

                var validateCode = await validateCodeService.AddAsync(addDto);

                if (validateCode != null)
                {
                    await smsSender.SendSingleAsync(phoneNumber,s_templateName,JsonConvert.SerializeObject(new { code=validateCode.Code}));
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            } 
        }


        /// <summary>
        /// 验证验证码是否有效
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("validate")]
        public async Task<ResultData> ValidateAsync(string phone, string code)
        {
            try
            {
                var validateSuccess = await validateCodeService.ValidateAsync(phone, code);
                if (validateSuccess)
                {
                    return ResultData.Success();
                }
                else
                {
                    
                    return ResultData.Fail("验证码错误或已经失效！");
                }
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

            
    }
}