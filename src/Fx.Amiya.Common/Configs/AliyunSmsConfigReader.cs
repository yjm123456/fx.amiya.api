using Fx.Sms.Aliyun;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Common.Configs
{
    public class AliyunSmsConfigReader : IAliyunSmsConfigReader
    {
        private FxAppGlobal _fxAppGlobal;
        private IConfiguration _configuration;
        public AliyunSmsConfigReader(FxAppGlobal fxAppGlobal, IConfiguration configuration)
        {
            _fxAppGlobal = fxAppGlobal;
            _configuration = configuration;
        }
        public AliyunSmsConfig GetAliyunSmsConfig()
        {
            return null;
        }

        public Task<AliyunSmsConfig> GetAliyunSmsConfigAsync()
        {
            throw new NotImplementedException();
        }

        public List<AliyunSmsConfig> GetAliyunSmsConfigs()
        {
            var configs = _fxAppGlobal?.AppConfig?.FxSmsConfig?.AliyunSmsList;
            if (configs != null)
            {
                var result = new List<AliyunSmsConfig>();
                configs.ForEach((item) =>
                {
                    AliyunSmsConfig smsConfig = new AliyunSmsConfig()
                    {
                        AccessKeyId = item.AccessKeyId,
                        AccessSecret = item.AccessSecret,
                        Name = item.Name,
                        RegionId = item.RegionId,
                        Remark = item.Remark,
                        SignName = item.SignName,
                        TemplateCode = item.TemplateCode
                    };
                    result.Add(smsConfig);

                });
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<AliyunSmsConfig>> GetAliyunSmsConfigsAsync()
        {
            return GetAliyunSmsConfigs();
        }
    }
}
