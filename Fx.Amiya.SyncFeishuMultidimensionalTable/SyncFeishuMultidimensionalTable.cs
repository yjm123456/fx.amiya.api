using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.SyncFeishuMultidimensionalTable.FeishuAppConfig;
using Fx.Common.Extensions;
using Fx.Common.Utils;
using Microsoft.EntityFrameworkCore;
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
        private readonly IDalFeishuTables dalFeishuTables;
        public SyncFeishuMultidimensionalTable(IFeishuAppinfoReader feishuAppinfoReader, IDalFeishuTables dalFeishuTables)
        {
            this.feishuAppinfoReader = feishuAppinfoReader;
            this.dalFeishuTables = dalFeishuTables;
        }

        public async Task<List<BindLiveAnchorInfo>> GetLiveAnchorIdsAsync()
        {
            return await feishuAppinfoReader.GetBindLiveAnchorIdsAsync();
        }

        public async Task<List<ShortVideocommentsInfo>> GetShortVideoCommentsAsync(int appLiveAnchorId, int tableLiveAnchorId, string pageToken = "")
        {
            var appinfo = await feishuAppinfoReader.GetFeishuAppInfoAsync(appLiveAnchorId);
            var tableInfo = dalFeishuTables.GetAll().Where(e => e.BelongAppId == appinfo.Id && e.TableType == (int)FeishuTableType.Comments && e.LiveAnchorId == tableLiveAnchorId).Select(e => new FeishuTableInfo { Apptoken = e.AppToken, TableId = e.TableId }).FirstOrDefault();
            if (tableInfo == null) return new List<ShortVideocommentsInfo>();
            appinfo.AppToken = tableInfo.Apptoken;
            appinfo.TableId=tableInfo.TableId;
            var res = await RequestCommentsTableDataAsync(appinfo, pageToken);
            var returnData = JsonConvert.DeserializeObject<dynamic>(res);
            if (returnData.code != 0) throw new Exception($"获取多维表格数据失败:{returnData.msg}");
            List<ShortVideocommentsInfo> dataList = new List<ShortVideocommentsInfo>();
            if (returnData.data.items == null) return new List<ShortVideocommentsInfo>();
            foreach (var data in returnData.data.items)
            {
                ShortVideocommentsInfo dataInfo = new ShortVideocommentsInfo();
                dataInfo.CommentsId = data.fields.评论ID;
                dataInfo.CommentsUserId = data.fields.评论人ID;
                dataInfo.CommentsUserName = data.fields.评论人姓名;
                dataInfo.LikeCount = data.fields.点赞次数;
                dataInfo.Comments= data.fields.评论内容;
                dataInfo.CommentsDate = Convert.ToDateTime(data.fields.评论时间);
                dataInfo.BelongLiveAnchorId = tableLiveAnchorId;
                dataList.Add(dataInfo);
            }
            var hasMore = (bool)returnData.data.has_more;
            var pagetoken = (string)returnData.data.page_token;
            while (hasMore)
            {
                var res2 = await RequestCommentsTableDataAsync(appinfo, pagetoken);
                var returnData2 = JsonConvert.DeserializeObject<dynamic>(res2);
                if (returnData2.code != 0) throw new Exception($"获取多维表格数据失败:{returnData2.msg}");
                List<ShortVideocommentsInfo> list = new List<ShortVideocommentsInfo>();
                foreach (var data in returnData2.data.items)
                {
                    ShortVideocommentsInfo dataInfo = new ShortVideocommentsInfo();
                    dataInfo.CommentsId = data.fields.评论ID;
                    dataInfo.CommentsUserId = data.fields.评论人ID;
                    dataInfo.CommentsUserName = data.fields.评论人姓名;
                    dataInfo.LikeCount = data.fields.点赞次数;
                    dataInfo.Comments = data.fields.评论内容;
                    dataInfo.CommentsDate = Convert.ToDateTime(data.fields.评论时间);
                    dataInfo.BelongLiveAnchorId = tableLiveAnchorId;
                    dataList.Add(dataInfo);
                }
                dataList.AddRange(list);
                pagetoken = returnData2.data.page_token;
                hasMore = returnData2.data.has_more;
            }
            return dataList;
        }

        public async Task<List<ShortVideoDataInfo>> GetShortVideoDataByCodeAsync(int appLiveAnchorId,int tableLiveAnchorId, string pageToken="")
        {
            var appinfo = await feishuAppinfoReader.GetFeishuAppInfoAsync(appLiveAnchorId);
            var tableInfo =  dalFeishuTables.GetAll().Where(e => e.BelongAppId == appinfo.Id&&e.TableType== (int)FeishuTableType.VideoData&&e.LiveAnchorId==tableLiveAnchorId).Select(e => new FeishuTableInfo {Apptoken=e.AppToken,TableId=e.TableId }).FirstOrDefault();
            if (tableInfo == null) return new List<ShortVideoDataInfo>();
            appinfo.AppToken = tableInfo.Apptoken;
            appinfo.TableId = tableInfo.TableId;
            var res = await RequestVideoTableDataAsync(appinfo, pageToken);
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
                dataInfo.BelongLiveAnchorId= tableLiveAnchorId;
                dataList.Add(dataInfo);
            }
            var hasMore = (bool)returnData.data.has_more;
            var pagetoken= (string)returnData.data.page_token;
            while (hasMore)
            {
                var res2 = await RequestVideoTableDataAsync(appinfo, pagetoken);
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
                    dataInfo.BelongLiveAnchorId = tableLiveAnchorId;
                    dataList.Add(dataInfo);
                }
                dataList.AddRange(list);
                pagetoken = returnData2.data.page_token;
                hasMore = returnData2.data.has_more;
            }
            return dataList;
        }

        public async Task<List<ShortVideoFansDataInfo>> GetShortVideoFansDataAsync(int appLiveAnchorId, int tableLiveAnchorId, string pageToken = "")
        {
            var appinfo = await feishuAppinfoReader.GetFeishuAppInfoAsync(appLiveAnchorId);
            var tableInfo = dalFeishuTables.GetAll().Where(e => e.BelongAppId == appinfo.Id && e.TableType == (int)FeishuTableType.FansData && e.LiveAnchorId == tableLiveAnchorId).Select(e => new FeishuTableInfo { Apptoken = e.AppToken, TableId = e.TableId }).FirstOrDefault();
            if (tableInfo == null) return new List<ShortVideoFansDataInfo>();
            appinfo.AppToken = tableInfo.Apptoken;
            appinfo.TableId = tableInfo.TableId;
            var res = await RequestFansTableDataAsync(appinfo, pageToken);
            var returnData = JsonConvert.DeserializeObject<dynamic>(res);
            if (returnData.code != 0) throw new Exception($"获取多维表格数据失败:{returnData.msg}");
            List<ShortVideoFansDataInfo> dataList = new List<ShortVideoFansDataInfo>();
            if (returnData.data.items == null) return new List<ShortVideoFansDataInfo>();
            foreach (var data in returnData.data.items)
            {
                ShortVideoFansDataInfo dataInfo = new ShortVideoFansDataInfo();
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));//当地时区
                var time = startTime.AddMilliseconds(Convert.ToInt64(data.fields.统计日期));
                dataInfo.StatsDate = time;
                dataInfo.NewFansCount = data.fields.新增粉丝数;
                dataInfo.TotalFansCount = data.fields.截止当日总粉丝数;
                dataInfo.BelongLiveAnchorId = tableLiveAnchorId;
                dataList.Add(dataInfo);
            }
            var hasMore = (bool)returnData.data.has_more;
            var pagetoken = (string)returnData.data.page_token;
            while (hasMore)
            {
                var res2 = await RequestFansTableDataAsync(appinfo, pagetoken);
                var returnData2 = JsonConvert.DeserializeObject<dynamic>(res2);
                if (returnData2.code != 0) throw new Exception($"获取多维表格数据失败:{returnData2.msg}");
                List<ShortVideoFansDataInfo> list = new List<ShortVideoFansDataInfo>();
                foreach (var data in returnData2.data.items)
                {
                    ShortVideoFansDataInfo dataInfo = new ShortVideoFansDataInfo();
                    dataInfo.StatsDate = data.fields.统计日期;
                    dataInfo.NewFansCount = data.fields.新增粉丝数;
                    dataInfo.TotalFansCount = data.fields.截止当日总粉丝数;
                    dataInfo.BelongLiveAnchorId = tableLiveAnchorId;
                    dataList.Add(dataInfo);
                }
                dataList.AddRange(list);
                pagetoken = returnData2.data.page_token;
                hasMore = returnData2.data.has_more;
            }
            return dataList;
        }

        public async Task<List<int>> GetTableLiveAnchorIdsAsync(string belonAppId, FeishuTableType feishuTableType)
        {
            return await dalFeishuTables.GetAll().Where(e => e.BelongAppId == belonAppId && e.TableType == (int)feishuTableType).Select(e => e.LiveAnchorId).ToListAsync();
        }

        private async Task<string> RequestVideoTableDataAsync(FeishuAppinfo appinfo, string pageToken)
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
        private async Task<string> RequestCommentsTableDataAsync(FeishuAppinfo appinfo, string pageToken)
        {
            string url = $"https://open.feishu.cn/open-apis/bitable/v1/apps/{appinfo.AppToken}/tables/{appinfo.TableId}/records?page_size=500&filter=AND(CurrentValue.[数据写入时间]=TODAY())";
            if (!string.IsNullOrEmpty(pageToken))
            {
                url = $"{url}&page_token={pageToken}";
            }
            var header = new Dictionary<string, string>();
            header.Add("Authorization", $"Bearer {appinfo.AccessToken}");
            return HttpUtil.HTTPJsonGet(url, header);
        }
        private async Task<string> RequestFansTableDataAsync(FeishuAppinfo appinfo, string pageToken)
        {
           
            string url = $"https://open.feishu.cn/open-apis/bitable/v1/apps/{appinfo.AppToken}/tables/{appinfo.TableId}/records?page_size=500&filter=AND(CurrentValue.[统计日期]>=TODAY())";
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
