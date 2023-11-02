using Fx.Amiya.SyncFeishuMultidimensionalTable.FeishuAppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncFeishuMultidimensionalTable
{
    public interface ISyncFeishuMultidimensionalTable
    {
        /// <summary>
        /// 根据code获取指定账号的多维表格数据
        /// pageToken用于分页查询数据外部调用无需传入
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<List<ShortVideoDataInfo>> GetShortVideoDataByCodeAsync(int liveAnchorId, string pageToken = "");
        Task<List<int>> GetLiveAnchorIdsAsync();
    }
}
