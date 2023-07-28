using Fx.Amiya.Service;
using Fx.Amiya.SyncOrder.WeChatVideo.WeChatVideoAppInfoConfig;
using Fx.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeChatVideo
{
    public class SyncWeChatVideoOrder : ISyncWeChatVideoOrder
    {
        private readonly IWechatVideoAppInfoReader wechatVideoAppInfoReader;

        public SyncWeChatVideoOrder(IWechatVideoAppInfoReader wechatVideoAppInfoReader)
        {
            this.wechatVideoAppInfoReader = wechatVideoAppInfoReader;
        }
        /// <summary>
        /// 同步订单
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="belongLiveAnchorId"></param>
        /// <returns></returns>
        public async Task<List<WechatVideoOrder>> TranslateTradesSoldChangedOrders(DateTime startDate, DateTime endDate, int belongLiveAnchorId)
        {
            try
            {
                var appInfo = await wechatVideoAppInfoReader.GetWeChatVideoAppInfo(belongLiveAnchorId);
                var idList = await GetAllOrderIdListAsync(appInfo.AccessToken);
                List<WechatVideoOrder> orderList = new List<WechatVideoOrder>();
                foreach (var item in idList)
                {
                    var order = await GetOrderInfoByIdAsync(item, appInfo.AccessToken, null);
                    if (order != null)
                    {
                        orderList.Add(order);
                    }
                }
                orderList.ForEach(e => e.BelongLiveAnchorId = belongLiveAnchorId);
                return orderList;
            }
            catch (Exception ex)
            {
                return new List<WechatVideoOrder>();
            }
        }

        public async Task<List<WechatVideoOrder>> TranslateTradesSoldChangedOrders2(DateTime startDate, DateTime endDate, int belongLiveAnchorId)
        {
            try
            {
                var date = new DateTime(2023, 7, 26, 1, 1, 1);
                var offset = DateTimeOffset.Parse(date.ToString("yyyy-MM-dd HH:mm:ss"));
                var start = offset.AddYears(-1);
                var end = offset.ToUnixTimeSeconds();

                var lastDate = new DateTime(2023, 7, 28, 1, 1, 1);
                var lastEnd = DateTimeOffset.Parse(lastDate.ToString("yyyy-MM-dd HH:mm:ss")).ToUnixTimeSeconds();
                List<WechatVideoOrder> orderList = new List<WechatVideoOrder>();

                while (!(start.ToUnixTimeSeconds() > end)) {
                    var s = start;
                    var e = start.AddDays(7);
                    var appInfo = await wechatVideoAppInfoReader.GetWeChatVideoAppInfo(belongLiveAnchorId);
                    var idList = await GetOrderIdLIstByDayAsync(s.ToUnixTimeSeconds(),e.ToUnixTimeSeconds() , appInfo.AccessToken, null);

                    foreach (var item in idList)
                    {
                        var order = await GetOrderInfoByIdAsync(item, appInfo.AccessToken, null);
                        if (order != null)
                        {
                            orderList.Add(order);
                        }
                    }
                    start = e;
                    
                }
                orderList.ForEach(e => e.BelongLiveAnchorId = belongLiveAnchorId);
                return orderList;
            }
            catch (Exception ex)
            {
                return new List<WechatVideoOrder>();
            }
        }
        /// <summary>
        /// 获取指定时间所有的订单id
        /// </summary>
        /// <param name="startData">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="belongLiveAnchorId">归属主播</param>
        /// <returns></returns>
        private async Task<List<string>> GetAllOrderIdListAsync(string token)
        {
            var orderList = await GetOrderIdLIstAsync(token, null);
            return orderList;
        }
        /// <summary>
        /// 分页获取订单
        /// </summary>
        /// <param name="token"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private async Task<List<string>> GetOrderIdLIstAsync(string token, object param)
        {
            var date = DateTime.Now;
            var offset= DateTimeOffset.Parse(date.ToString("yyyy-MM-dd HH:mm:ss"));
            var start = offset.AddSeconds(-2400).ToUnixTimeSeconds();
            var end = offset.ToUnixTimeSeconds();
            if (param == null)
            {
                param = new { update_time_range = new { start_time = start, end_time = end }, page_size = 100 };
            }
            string requestUrl = $"https://api.weixin.qq.com/channels/ec/order/list/get?access_token={token}";
            var res = await HttpUtil.HttpJsonPostAsync(requestUrl, JsonSerializer.Serialize(param));
            var result = JsonSerializer.Deserialize<WeChatVideoOrderIdListResult>(res);
            List<string> allIds = new List<string>();
            if (result.errcode == 0)
            {
                allIds.AddRange(result.order_id_list);
                if (result.has_more)
                {
                    var nextPageParm = new { update_time_range = new { start_time = start, end_time = end }, page_size = 100, next_key = result.next_key };
                    var nextPageOrder = await GetOrderIdLIstAsync(token, nextPageParm);
                    allIds.AddRange(nextPageOrder);
                }
                return allIds;
            }
            return new List<string>();
        }
        private async Task<List<string>> GetOrderIdLIstByDayAsync(long startTime,long endTime, string token, object param)
        {
           
            if (param == null)
            {
                param = new { update_time_range = new { start_time = startTime, end_time = endTime }, page_size = 100 };
            }
            string requestUrl = $"https://api.weixin.qq.com/channels/ec/order/list/get?access_token={token}";
            var res = await HttpUtil.HttpJsonPostAsync(requestUrl, JsonSerializer.Serialize(param));
            var result = JsonSerializer.Deserialize<WeChatVideoOrderIdListResult>(res);
            List<string> allIds = new List<string>();
            if (result.errcode == 0)
            {
                allIds.AddRange(result.order_id_list);
                if (result.has_more)
                {
                    var nextPageParm = new { update_time_range = new { start_time = startTime, end_time = endTime }, page_size = 100, next_key = result.next_key };
                    var nextPageOrder = await GetOrderIdLIstByDayAsync(startTime, endTime, token, nextPageParm);
                    allIds.AddRange(nextPageOrder);
                }
                return allIds;
            }
           
            return new List<string>();
        }
        /// <summary>
        /// 根据订单id获取订单详情
        /// </summary>
        /// <returns></returns>
        public async Task<WechatVideoOrder> GetOrderInfoByIdAsync(string orderId, string token,int? belongLiveAnchorId)
        {
            if (string.IsNullOrEmpty(token)) {
                if (!belongLiveAnchorId.HasValue) throw new Exception("归属主播id不能为空！");
                var appInfo = await wechatVideoAppInfoReader.GetWeChatVideoAppInfo(belongLiveAnchorId.Value);
                token = appInfo.AccessToken;
            }
            var requestUrl = $"https://api.weixin.qq.com/channels/ec/order/get?access_token={token}";
            var param = new { order_id = orderId };
            var res = await HttpUtil.HttpJsonPostAsync(requestUrl, JsonSerializer.Serialize(param));
            var result = JsonSerializer.Deserialize<WeChatVideoOrderResult>(res);
            if (result.errcode == 0) {
                WechatVideoOrder wechatVideoOrder = new WechatVideoOrder()
                {
                    Id = result.order.order_id,
                    Phone = result.order.order_detail.delivery_info.deliver_method == 1 ? result.order.order_detail.delivery_info.address_info.virtual_order_tel_number : result.order.order_detail.delivery_info.address_info.tel_number,
                    AppointmentHospital = "",
                    StatusCode = ServiceClass.GetWechatVideoOrderStatusText(result.order.status),
                    ActualPayment = result.order.order_detail.price_info.order_price / 100,
                    AccountReceivable = result.order.order_detail.price_info.order_price / 100,
                    CreateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(result.order.create_time.ToString()) ? 0 : result.order.create_time).AddHours(8),
                    UpdateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(result.order.update_time.ToString()) ? 0 : result.order.update_time).AddHours(8),
                    WriteOffDate = null,
                    BuyerNick = result.order.order_detail.delivery_info.address_info.user_name,
                    OrderType = result.order.order_detail.delivery_info.deliver_method,
                };
                wechatVideoOrder.GoodsName = string.Join(",", result.order.order_detail.product_infos.Select(e => e.title));
                wechatVideoOrder.GoodsId = string.Join(",", result.order.order_detail.product_infos.Select(e => e.product_id));
                wechatVideoOrder.Quantity = result.order.order_detail.product_infos.Sum(e => e.sku_cnt);
                wechatVideoOrder.ThumbPicUrl = result.order.order_detail.product_infos.FirstOrDefault().thumb_img;
                return wechatVideoOrder;
            }
            //foreach (var item in result.order.order_detail.product_infos)
            //{
            //    wechatVideoOrder.GoodsName += item.title;
            //    wechatVideoOrder.GoodsId += item.product_id;
            //    wechatVideoOrder.ThumbPicUrl = item.thumb_img;
            //    wechatVideoOrder.Quantity += item.sku_cnt;
            //}
            return null;
            
        }
        private static DateTime UnixTimestampToDateTime(DateTime target, long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            return start.AddSeconds(timestamp);
        }

        

    }
}
