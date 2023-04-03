using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeChatVideo.WeChatVideoAppInfoConfig
{
    public interface IWechatVideoAppInfoReader
    {
        Task<WechatVideoAppInfo> GetWeChatVideoAppInfo(int belongLiveAnchor);
    }
}
