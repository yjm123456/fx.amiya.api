using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.Dto.WxAppInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class WxAppConfigService : IWxAppConfigService
    {
        private IDalConfig dalConfig;
        private IUnitOfWork unitOfWork;
        private IDalNoticeConfig dalNoticeConfig;
        private IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService;

        public WxAppConfigService(IDalConfig dalConfig,
            IUnitOfWork unitOfWork, IDalNoticeConfig dalNoticeConfig, IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService)
        {
            this.dalConfig = dalConfig;
            this.dalNoticeConfig = dalNoticeConfig;
            this.unitOfWork = unitOfWork;
            this.dockingHospitalCustomerInfoService = dockingHospitalCustomerInfoService;
        }


        public async Task<WxAppConfigDto> GetWxAppConfigAsync()
        {
            try
            {
                var configInfo = await dalConfig.GetAll().FirstOrDefaultAsync();

                WxAppConfigDto wxAppConfig = JsonConvert.DeserializeObject<WxAppConfigDto>(configInfo.ConfigJson);


                return wxAppConfig;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<CallCenterConfigDto> GetWxAppCallCenterConfigAsync()
        {
            try
            {
                var configInfo = await dalConfig.GetAll().FirstOrDefaultAsync();

                WxAppConfigDto wxAppConfig = JsonConvert.DeserializeObject<WxAppConfigDto>(configInfo.ConfigJson);

                return wxAppConfig.CallCenterConfig;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<string> GetWxAppConfigStringAsync()
        {
            try
            {
                var configInfo = await dalConfig.GetAll().FirstOrDefaultAsync();

                return configInfo.ConfigJson;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task SaveAsync(string strConfig)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strConfig))
                    throw new Exception("配置不能为空");

                var configInfo = await dalConfig.GetAll().FirstOrDefaultAsync();
                if (configInfo == null)
                {
                    Config config = new Config();
                    config.Id = 1;
                    config.ConfigJson = strConfig;

                    await dalConfig.AddAsync(config, true);
                }
                else
                {
                    configInfo.ConfigJson = strConfig;
                    await dalConfig.UpdateAsync(configInfo, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        /// <summary>
        /// 当前邮箱通知状态
        /// </summary>
        /// <param name="updateInfo"></param>
        /// <returns></returns>
        public async Task<bool> EmailNotice()
        {
            bool result = false;
            var config = await dalNoticeConfig.GetAll().ToListAsync();
            foreach (var x in config)
            {
                if (x.Name == "EMailNoticeConfig")
                {
                    result = x.State;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取手机号加密情况
        /// </summary>
        /// <returns></returns>
        public async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().FirstOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }
        public async Task<FxNoticeConfigDto> GetNoticeConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).NoticeConfig;
        }
        /// <summary>
        /// 是否开启邮箱通知
        /// </summary>
        /// <param name="updateInfo"></param>
        /// <returns></returns>
        public async Task UpdateEmailNotice(bool updateInfo)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var config = await dalNoticeConfig.GetAll().ToListAsync();
                foreach (var x in config)
                {
                    if (x.Name == "EMailNoticeConfig")
                    {
                        //删除
                        await dalNoticeConfig.DeleteAsync(x, true);
                        //新增
                        NoticeConfig noticeConfig = new NoticeConfig();
                        noticeConfig.Id = Guid.NewGuid().ToString();
                        noticeConfig.Name = "EMailNoticeConfig";
                        noticeConfig.State = updateInfo;
                        await dalNoticeConfig.AddAsync(noticeConfig, true);
                    }
                }
                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                unitOfWork.RollBack();
                throw new Exception(e.Message.ToString());
            }
        }
        /// <summary>
        /// 给用户发送积分服务通知
        /// </summary>
        /// <param name="wxNoticeDto"></param>
        /// <returns></returns>
        public async Task SendNotice(WxNoticeDto wxNoticeDto)
        {
            var appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(4);
            var requestUrl = $"https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token={appInfo.AccessToken}";
            var messageBody = new
            {
                template_id = "bbzpcTSDNUnsYCUQeeFz5u5-aRoVRDNUSffS1rNa_wE",
                touser = "oJrxj5RfkI1gjFJOdAjA-t-UJJlA",
                page = "/pages/index/default",// 点击提示信息要进入的小程序页面
                miniprogram_state = "trial",
                lang = "zh_CN",
                data = new
                {
                    thing1 = new { value = $"{wxNoticeDto.Name}" },
                    thing2 = new { value = $"{wxNoticeDto.ActivityName}" },
                    character_string4 = new { value = $"+{wxNoticeDto.AddCount}" },
                    time5 = new { value = wxNoticeDto.ExpireDate },
                    number10 = new { value = wxNoticeDto.TotalCount }
                }
            };
            string body = JsonConvert.SerializeObject(messageBody);
            var result = HttpUtil.HTTPJsonPost(requestUrl, body);

        }
    }
}
