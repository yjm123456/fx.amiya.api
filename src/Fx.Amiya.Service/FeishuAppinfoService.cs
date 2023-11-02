using Fx.Amiya.Dto.FeishuAppInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class FeishuAppinfoService : IFeishuAppinfoService
    {
        private readonly IDalFeishuAppinfo dalFeishuAppinfo;

        public FeishuAppinfoService(IDalFeishuAppinfo dalFeishuAppinfo)
        {
            this.dalFeishuAppinfo = dalFeishuAppinfo;
        }

        public async Task<FeishuAppInfoDto> GetFeishuAppinfoByCodeAsync(int liveAnchorId)
        {
            var appinfo = dalFeishuAppinfo.GetAll().Where(e => e.BelongLiveAnchorId == liveAnchorId && e.Valid == true).FirstOrDefault();
            if (appinfo == null) throw new Exception("应用证书不存在");
            if (appinfo.ExpireDate <= DateTime.Now||appinfo.ExpireDate==null)
            {
                string url = "https://open.feishu.cn/open-apis/auth/v3/tenant_access_token/internal";
                var header = new Dictionary<string, string>();
                header.Add("Content-Type", "application/json;charset=UTF-8");
                var param = JsonConvert.SerializeObject(new {app_id=appinfo.AppId, app_secret=appinfo.AppSecret });
                var res = HttpUtil.CommonHttpRequest(param, url, "POST", header);
                var tokenResult = JsonConvert.DeserializeObject<dynamic>(res);
                if (tokenResult.code!=0) {
                    throw new Exception($"操作失败，{tokenResult.code}-{tokenResult.msg }！");
                }
                appinfo.ExpireDate = DateTime.Now.AddSeconds(Convert.ToDouble(tokenResult.expire) - 900);
                appinfo.AccessToken = tokenResult.tenant_access_token;
           
                await dalFeishuAppinfo.UpdateAsync(appinfo, true);
            }
            FeishuAppInfoDto feishuAppInfoDto=new FeishuAppInfoDto();
            feishuAppInfoDto.AppId = appinfo.AppId;
            feishuAppInfoDto.AppSecret=appinfo.AppSecret;
            feishuAppInfoDto.AppToken = appinfo.AppToken;
            feishuAppInfoDto.TableId=appinfo.TableId;
            feishuAppInfoDto.AccessToken=appinfo.AccessToken;
            feishuAppInfoDto.ExpireDate = appinfo.ExpireDate;
            feishuAppInfoDto.BelongLiveAnchorId = appinfo.BelongLiveAnchorId;
            return feishuAppInfoDto;
        }
    }
}
