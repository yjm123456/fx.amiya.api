using Fx.Amiya.IService;
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
        Task<List<ShortVideoDataInfo>> GetShortVideoDataByCodeAsync(int appLiveAnchorId,int tableLiveAnchorId, string pageToken = "");
        Task<List<BindLiveAnchorInfo>> GetLiveAnchorIdsAsync();
        /// <summary>
        /// 根据belongappid和表类型获取主播
        /// </summary>
        /// <param name="belonAppId"></param>
        /// <param name="feishuTableType"></param>
        /// <returns></returns>
        Task<List<int>> GetTableLiveAnchorIdsAsync(string belonAppId,FeishuTableType feishuTableType);
        /// <summary>
        /// 获取短视频评论数据
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <param name="pageToken"></param>
        /// <returns></returns>
        Task<List<ShortVideocommentsInfo>> GetShortVideoCommentsAsync(int appLiveAnchorId, int tableLiveAnchorId, string pageToken = "");
        /// <summary>
        /// 获取短视频粉丝数据
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <param name="pageToken"></param>
        /// <returns></returns>
        Task<List<ShortVideoFansDataInfo>> GetShortVideoFansDataAsync(int appLiveAnchorId, int tableLiveAnchorId, string pageToken = "");
    }
}
