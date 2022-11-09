using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.WxAppConfig;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class WxAppConfigController : ControllerBase
    {
        private IWxAppConfigService wxAppConfigService;
        public WxAppConfigController(IWxAppConfigService wxAppConfigService)
        {
            this.wxAppConfigService = wxAppConfigService;
        }
        /// <summary>
        /// 当前邮箱通知状态
        /// </summary>
        /// <returns></returns>
        [HttpGet("getEmailNoticeControll")]
        public async Task<ResultData<bool>> GetEmailNoticeControll()
        {
            var result= await wxAppConfigService.EmailNotice();
            return ResultData<bool>.Success().AddData("emailNotice", result);
        }

        /// <summary>
        /// 是否启动邮箱通知
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("updateEmailNoticeControll")]
        public async Task<ResultData> UpdateEmailNoticeControll(bool emailNotice)
        {
            await wxAppConfigService.UpdateEmailNotice(emailNotice);
            return ResultData.Success();
        }

        [HttpGet]
        public async Task<ResultData<string>> GetWxAppConfigAsync()
        {
            try
            {
                var config = await wxAppConfigService.GetWxAppConfigStringAsync();

                return ResultData<string>.Success().AddData("wxAppConfig", config);
            }
            catch (Exception ex)
            {
                return ResultData<string>.Fail(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ResultData> SaveAsync([FromBody]string strConfig)
        {
            try
            {
                await wxAppConfigService.SaveAsync(strConfig);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 获取呼叫中心配置
        /// </summary>
        /// <returns></returns>
        [HttpGet("callCenter")]
        public async Task<ResultData<CallCenterConfigVo>> GetWxAppCallCenterConfigAsync()
        {
            var callCenterConfig = await wxAppConfigService.GetWxAppCallCenterConfigAsync();
            CallCenterConfigVo callCenterConfigVo = new CallCenterConfigVo();
            callCenterConfigVo.CallRecordStoreAddress = callCenterConfig.CallRecordStoreAddress;
            callCenterConfigVo.EnableVoiceCardCallable = callCenterConfig.EnableVoiceCardCallable;
            callCenterConfigVo.SupportOldCallBox = callCenterConfig.SupportOldCallBox;
            callCenterConfigVo.SwitchSimCardInCallCount = callCenterConfig.SwitchSimCardInCallCount;
            callCenterConfigVo.VoiceCardManagerAddress = callCenterConfig.VoiceCardManagerAddress;
            callCenterConfigVo.PhoneEncryptKey = callCenterConfig.PhoneEncryptKey;
            callCenterConfigVo.EnablePhoneEncrypt = callCenterConfig.EnablePhoneEncrypt;
            callCenterConfigVo.HidePhoneNumber = callCenterConfig.HidePhoneNumber;
             
            return ResultData<CallCenterConfigVo>.Success().AddData("callCenterConfig", callCenterConfigVo);
        }
    }
} 