using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.JD.JDAppInfoConfig
{
    public interface IJDAppInfoReader
    {
        Task<JDAppInfo> GetJdAppInfo();
    }
}
