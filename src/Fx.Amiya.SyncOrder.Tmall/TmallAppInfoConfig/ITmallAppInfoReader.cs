using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.Tmall.TmallAppInfoConfig
{
    public interface ITmallAppInfoReader
    {
        Task<TmallAppInfo> GetTmallAppInfo();
    }
}
