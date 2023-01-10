using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.Dto.WxAppInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IWxAppConfigService
    {
        Task<WxAppConfigDto> GetWxAppConfigAsync();

        /// <summary>
        /// 获取呼叫中心配置
        /// </summary>
        /// <returns></returns>
        Task<CallCenterConfigDto> GetWxAppCallCenterConfigAsync();


        Task<string> GetWxAppConfigStringAsync();
        Task SaveAsync(string strConfig);


        /// <summary>
        /// 当前邮箱通知情况
        /// </summary>
        /// <param name="updateInfo"></param>
        /// <returns></returns>
        Task<bool> EmailNotice();

        /// <summary>
        /// 获取手机号加密情况
        /// </summary>
        /// <returns></returns>
        Task<CallCenterConfigDto> GetCallCenterConfig();

        Task<FxNoticeConfigDto> GetNoticeConfig();

        /// <summary>
        /// 是否开启邮箱通知
        /// </summary>
        /// <param name="updateInfo"></param>
        /// <returns></returns>
        Task UpdateEmailNotice(bool updateInfo);
        Task SendNotice(WxNoticeDto wxNoticeDto);
    }
}
