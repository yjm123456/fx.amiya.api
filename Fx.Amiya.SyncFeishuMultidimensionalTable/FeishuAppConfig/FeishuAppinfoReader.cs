using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncFeishuMultidimensionalTable.FeishuAppConfig
{
    public class FeishuAppinfoReader : IFeishuAppinfoReader
    {
        private readonly IFeishuAppinfoService feishuAppinfoService;
        private readonly IDalFeishuAppinfo dalFeishuAppinfo;
        public FeishuAppinfoReader(IFeishuAppinfoService feishuAppinfoService, IDalFeishuAppinfo dalFeishuAppinfo)
        {
            this.feishuAppinfoService = feishuAppinfoService;
            this.dalFeishuAppinfo = dalFeishuAppinfo;
        }

        public async Task<List<BindLiveAnchorInfo>> GetBindLiveAnchorIdsAsync()
        {
            return await dalFeishuAppinfo.GetAll().Where(e=>e.Valid==true).Select(e=>new BindLiveAnchorInfo { LiveAnchorId= e.BelongLiveAnchorId ,AppId=e.Id}).ToListAsync();
        }

        public async Task<FeishuAppinfo> GetFeishuAppInfoAsync(int liveAnchorId)
        {
            var appinfo = await feishuAppinfoService.GetFeishuAppinfoByCodeAsync(liveAnchorId);
            FeishuAppinfo feishuAppinfo=new FeishuAppinfo();
            feishuAppinfo.AppId= appinfo.AppId;
            feishuAppinfo.AppSecret=appinfo.AppSecret;
            feishuAppinfo.AppToken=appinfo.AppToken;
            feishuAppinfo.TableId=appinfo.TableId;
            feishuAppinfo.AccessToken = appinfo.AccessToken;
            feishuAppinfo.ExpireDate = appinfo.ExpireDate;
            feishuAppinfo.BelongLiveAnchorId = appinfo.BelongLiveAnchorId;
            feishuAppinfo.Id = appinfo.Id;
            return feishuAppinfo;
        }
    }
}
