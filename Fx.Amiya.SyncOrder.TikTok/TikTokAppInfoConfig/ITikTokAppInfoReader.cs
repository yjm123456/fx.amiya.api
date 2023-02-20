using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.TikTok.TikTokAppInfoConfig
{
    public interface ITikTokAppInfoReader
    {
        Task<TikTokAppInfo> GetTikTokAppInfo(int belongLiveAnchor);
    }
}
