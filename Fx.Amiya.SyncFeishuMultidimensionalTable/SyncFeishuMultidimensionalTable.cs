using Fx.Amiya.SyncFeishuMultidimensionalTable.FeishuAppConfig;
using Fx.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fx.Amiya.SyncFeishuMultidimensionalTable
{
    public class SyncFeishuMultidimensionalTable : ISyncFeishuMultidimensionalTable
    {
        private readonly IFeishuAppinfoReader feishuAppinfoReader;

        public SyncFeishuMultidimensionalTable(IFeishuAppinfoReader feishuAppinfoReader)
        {
            this.feishuAppinfoReader = feishuAppinfoReader;
        }

        public async Task<List<int>> GetLiveAnchorIdsAsync()
        {
            return await feishuAppinfoReader.GetBindLiveAnchorIdsAsync();
        }

        public async Task<List<ShortVideoDataInfo>> GetShortVideoDataByCodeAsync(int liveAnchorId, string pageToken="")
        {
            var appinfo = await feishuAppinfoReader.GetFeishuAppInfoAsync(liveAnchorId);
            var res = await RequestTableDataAsync(appinfo, pageToken);
            var returnData = JsonConvert.DeserializeObject<dynamic>(res);
            if (returnData.code != 0) throw new Exception($"获取多维表格数据失败:{returnData.msg}");
            List<ShortVideoDataInfo> dataList = new List<ShortVideoDataInfo>();
            if (returnData.data.items == null) return new List<ShortVideoDataInfo>();
            foreach (var data in returnData.data.items)
            {
                ShortVideoDataInfo dataInfo = new ShortVideoDataInfo();
                dataInfo.PlayNum = data.fields.播放数;
                dataInfo.Title = data.fields.标题;
                dataInfo.Like = data.fields.点赞数;
                dataInfo.Comments = data.fields.评论数;
                dataInfo.VideoId = data.fields.视频ID;
                dataInfo.BelongLiveAnchorId= appinfo.BelongLiveAnchorId;
                dataList.Add(dataInfo);
            }
            var hasMore = (bool)returnData.data.has_more;
            var pagetoken= (string)returnData.data.page_token;
            while (hasMore)
            {
                var res2 = await RequestTableDataAsync(appinfo, pagetoken);
                var returnData2 = JsonConvert.DeserializeObject<dynamic>(res2);
                if (returnData2.code != 0) throw new Exception($"获取多维表格数据失败:{returnData2.msg}");
                List<ShortVideoDataInfo> list = new List<ShortVideoDataInfo>();
                foreach (var data in returnData2.data.items)
                {
                    ShortVideoDataInfo dataInfo = new ShortVideoDataInfo();
                    dataInfo.PlayNum = data.fields.播放数;
                    dataInfo.Title = data.fields.标题;
                    dataInfo.Like = data.fields.点赞数;
                    dataInfo.Comments = data.fields.评论数;
                    dataInfo.VideoId = data.fields.视频ID;
                    dataInfo.BelongLiveAnchorId = appinfo.BelongLiveAnchorId;
                    dataList.Add(dataInfo);
                }
                dataList.AddRange(list);
                pagetoken = returnData2.data.page_token;
                hasMore = returnData2.data.has_more;
            }
            return dataList;
        }
        private async Task<string> RequestTableDataAsync(FeishuAppinfo appinfo, string pageToken)
        {
            string url = $"https://open.feishu.cn/open-apis/bitable/v1/apps/{appinfo.AppToken}/tables/{appinfo.TableId}/records?page_size=500&filter=AND(CurrentValue.[数据写入日期]=TODAY())";
            if (!string.IsNullOrEmpty(pageToken))
            {
                url = $"{url}&page_token={pageToken}";
            }
            var header = new Dictionary<string, string>();
            header.Add("Authorization", $"Bearer {appinfo.AccessToken}");
            return HttpUtil.HTTPJsonGet(url, header);
        }

    }
}
