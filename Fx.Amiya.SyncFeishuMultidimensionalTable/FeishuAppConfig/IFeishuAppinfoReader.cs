using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncFeishuMultidimensionalTable.FeishuAppConfig
{
    public interface IFeishuAppinfoReader
    {
        Task<FeishuAppinfo> GetFeishuAppInfoAsync(int liveAnchorId);
        Task<List<int>> GetBindLiveAnchorIdsAsync();
    }
}
