using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeiFenXiao.WeiFenXiaoAppInfoConfig
{
    public interface IWeiFenXiaoAppInfoReader
    {
        Task<WeiFenXiaoAppInfo> GetWeiFenXiaoAppInfo();
    }
}
