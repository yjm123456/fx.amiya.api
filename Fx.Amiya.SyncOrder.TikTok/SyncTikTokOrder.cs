
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.Dto.TikTokUserInfo;
using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.TikTok.TikTokAppInfoConfig;
using Fx.Common.Utils;
using Jd.Api.Util;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fx.Amiya.SyncOrder.TikTok
{
    public class SyncTikTokOrder : ISyncTikTokOrder
    {
        private ITikTokAppInfoReader _tikTokAppInfoReader;
        private ILogger<SyncTikTokOrder> _logger;
        private ITikTokUserInfoService _tikTokUserInfoService;

        public SyncTikTokOrder(ITikTokAppInfoReader tikTokAppInfoReader, ILogger<SyncTikTokOrder> logger, ITikTokUserInfoService tikTokUserInfoService)
        {
            _tikTokAppInfoReader = tikTokAppInfoReader;
            _logger = logger;
            _tikTokUserInfoService = tikTokUserInfoService;
        }

        public Task<List<OrderLocCode>> GetOrderLocCodesAsync(DateTime startDate, DateTime endDate, int codeStatus)
        {
            throw new NotImplementedException();
        }

        public Task<List<RefundOrder>> GetRefundOrdersAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<AmiyaOrder>> TranslateAllTradesSoldOrders(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 同步（抖音）发生改变的订单
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<TikTokOrder>> TranslateTradesSoldChangedOrders(DateTime startDate, DateTime endDate, int belongLiveAnchorId)
        {
            try
            {
                int pageNum = 0;
                var tikTokAppInfo = await _tikTokAppInfoReader.GetTikTokAppInfo(belongLiveAnchorId);
                List<TikTokOrder> amiyaOrderList = new List<TikTokOrder>();
                amiyaOrderList = await RequestTikTokOrderAsync(startDate, endDate, tikTokAppInfo, pageNum, amiyaOrderList);
                return amiyaOrderList;
            }
            catch (Exception ex)
            {
                return new List<TikTokOrder>();
            }
        }

        /// <summary>
        /// 同步抖音订单请求
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="tikTokAppInfo"></param>
        /// <param name="dateType"></param>
        /// <param name="pageNum"></param>
        /// <param name="amiyaOrderList"></param>
        /// <returns></returns>
        private async Task<List<TikTokOrder>> RequestTikTokOrderAsync(DateTime startDate, DateTime endDate, TikTokAppInfo tikTokAppInfo, int pageNum, List<TikTokOrder> amiyaOrderList)
        {
            try
            {
                int pageSize = 100;
                var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();

                var host = "https://openapi-fxg.jinritemai.com";
                var start = DateTimeOffset.Now.ToUnixTimeSeconds() - 2400;
                var end = DateTimeOffset.Now.ToUnixTimeSeconds();
                //请求参数
                var param = new Dictionary<string, object> {
                { "page",pageNum},
                { "size",pageSize},
                { "update_time_start",start},
                { "update_time_end",end},
                {"order_by","update_time" }
            };
                var paramJson = Marshal(param);

                //计算签名
                var signVal = Sign(tikTokAppInfo.AppKey, tikTokAppInfo.AppSecret, "order.searchList", timestamp, paramJson);

                //发起请求
                var res = Fetch(tikTokAppInfo.AppKey, host, "order.searchList", timestamp, paramJson, tikTokAppInfo.AccessToken, signVal);

                TikTokOrderResult order = JsonConvert.DeserializeObject<TikTokOrderResult>(res); ;

                if (order.data.total > 0)
                {
                    foreach (var orderItem in order.data.shop_order_list)
                    {
                        var currentChildList = new List<TikTokOrder>();
                        foreach (var goodsItem in orderItem.sku_order_list)
                        {
                            TikTokOrder tikTokOrder = new TikTokOrder();
                            tikTokOrder.Id = goodsItem.order_id;
                            tikTokOrder.GoodsId = goodsItem.product_id.ToString();
                            tikTokOrder.GoodsName = goodsItem.product_name;
                            tikTokOrder.Quantity = Convert.ToInt32(goodsItem.item_num);
                            tikTokOrder.ThumbPicUrl = goodsItem.product_pic;
                            tikTokOrder.AppointmentHospital = "";
                            tikTokOrder.StatusCode = GetStatusCodeOfDouYin(goodsItem.order_status, goodsItem.after_sale_info);
                            tikTokOrder.OrderType = goodsItem.order_type;
                            tikTokOrder.ActualPayment = goodsItem.pay_amount / 100;
                            tikTokOrder.CreateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(goodsItem.create_time.ToString()) ? 0 : goodsItem.create_time).AddHours(8);
                            tikTokOrder.UpdateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(goodsItem.update_time.ToString()) ? 0 : goodsItem.update_time).AddHours(8);
                            tikTokOrder.WriteOffDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(goodsItem.confirm_receipt_time.ToString()) ? 0 : goodsItem.confirm_receipt_time).AddHours(8);
                            long finishDate = goodsItem.finish_time;
                            if (finishDate != 0)
                            {
                                tikTokOrder.FinishDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(goodsItem.finish_time.ToString()) ? 0 : goodsItem.finish_time).AddHours(8);
                            }
                            else
                            {
                                tikTokOrder.FinishDate = null;
                            }
                            tikTokOrder.AppType = (byte)AppType.Douyin;
                            tikTokOrder.BelongLiveAnchorId = tikTokAppInfo.BelongLiveAnchorId;
                            tikTokOrder.IsAppointment = false;

                            currentChildList.Add(tikTokOrder);
                        }
                        currentChildList.ForEach(o => { o.CipherPhone = orderItem.encrypt_post_tel; o.CipherName = orderItem.encrypt_post_receiver; });
                        amiyaOrderList.AddRange(currentChildList);
                    }
                }


                long orderCount = order.data.total;
                if (orderCount >= (pageNum + 1) * pageSize)
                {
                    await RequestTikTokOrderAsync(startDate, endDate, tikTokAppInfo, pageNum + 1, amiyaOrderList);
                }
                return amiyaOrderList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Fetch(string appKey, string host, string method, long timestamp, string paramJson,
    string accessToken, string sign)
        {
            var methodPath = method.Replace('.', '/');
            var u = host + "/" + methodPath +
                    "?method=" + HttpUtility.UrlEncode(method, Encoding.UTF8) +
                    "&app_key=" + HttpUtility.UrlEncode(appKey, Encoding.UTF8) +
                    "&access_token=" + HttpUtility.UrlEncode(accessToken, Encoding.UTF8) +
                    "&timestamp=" + HttpUtility.UrlEncode(timestamp.ToString(), Encoding.UTF8) +
                    "&v=" + HttpUtility.UrlEncode("2", Encoding.UTF8) +
                    "&sign=" + HttpUtility.UrlEncode(sign, Encoding.UTF8) +
                    "&sign_method=" + HttpUtility.UrlEncode("hmac-sha256", Encoding.UTF8);
            var header = new Dictionary<string, string>();
            header.Add("Content-Type", "application/json;charset=UTF-8");
            header.Add("Accept", "*/*");
            var res = HttpUtil.CommonHttpRequest(paramJson, u, "POST");
            return res;

        }
        // 序列化参数
        private string Marshal(object o)
        {
            var raw = JsonConvert.SerializeObject(o);
            // 反序列化为JObject
            var dict = JsonConvert.DeserializeObject(raw);

            // 重新序列化
            var settings = new JsonSerializerSettings();
            settings.Converters = new List<JsonConverter> { new JObjectConverter(), new JValueConverter() };
            return JsonConvert.SerializeObject(dict, Formatting.None, settings);
        }

        /// <summary>
        /// 获取请求url
        /// </summary>
        /// <param name="path">拼接请求地址</param>
        /// <returns></returns>
        private string GetRequestUrl(string path)
        {
            string url = "https://openapi-fxg.jinritemai.com";
            if (!string.IsNullOrEmpty(path))
            {
                url += path;
            }
            return url;
        }
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="method">方法描述</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="paramJson">请求参数</param>
        /// <returns></returns>
        public string Sign(string appKey, string appSecret, string method, long timestamp, string paramJson)
        {
            // 按给定规则拼接参数
            var paramPattern = "app_key" + appKey + "method" + method + "param_json" + paramJson + "timestamp" +
                               timestamp + "v2";
            var signPattern = appSecret + paramPattern + appSecret;

            return HmacHelper.Hmac(signPattern, appSecret);
        }

        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="statusCode">抖音返回订单状态</param>
        /// <returns></returns>
        private static string GetStatusCodeOfDouYin(long statusCode, TikTokAfterSaleInfo afterSaleInfo)
        {
            string code = "";
            // refund_status 退款状态: 0 - 无需退款 1 - 待退款 2 - 退款中 3 - 退款成功 4 - 退款失败
            //售后状态只要不是初始化状态,就视订单为退款\售后状态
            if (afterSaleInfo.after_sale_status > 0)
            {

                if (afterSaleInfo.refund_status > 0)
                {
                    switch (afterSaleInfo.refund_status)
                    {
                        //待退款
                        case 1L:
                            code = "PENDING_REFUND";
                            break;
                        //退款中
                        case 2L:
                            code = "REFUNDING";
                            break;
                        //退款成功
                        case 3L:
                            code = "TRADE_CLOSED_AFTER_REFUND";
                            break;
                        //退款失败
                        case 4L:
                            code = "REFUND_FAIL";
                            break;
                        default:
                            code = "UNKNOW";
                            break;
                    }
                    return code;

                }
            }
            switch (statusCode)
            {
                case 1L:
                    code = "WAIT_BUYER_PAY";
                    break;

                //待出库，即买家已付款
                case 105L:
                    code = "WAIT_SELLER_SEND_GOODS";
                    break;

                //已付款,商家备货
                case 2L:
                    code = "WAIT_SELLER_SEND_GOODS";
                    break;
                //订单中的部分商品已发货
                case 101L:
                    code = "WAIT_BUYER_CONFIRM_GOODS";
                    break;
                //订单中的全部商品已发货
                case 3L:
                    code = "WAIT_BUYER_CONFIRM_GOODS";
                    break;
                //订单取消
                case 4L:
                    code = "TRADE_CLOSED";
                    break;
                //订单完成
                case 5L:
                    code = "TRADE_FINISHED";
                    break;

                default:
                    code = "UNKNOW";
                    break;
            }

            return code;
        }

        /// <summary>
        /// unix时间戳转换成日期
        /// </summary>
        /// <param name="unixTimeStamp">时间戳（秒）</param>
        /// <returns></returns>
        private static DateTime UnixTimestampToDateTime(DateTime target, long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            return start.AddSeconds(timestamp);
        }

        public async Task<List<TikTokOrder>> TranslateTradesSoldOrdersByOrderId(string orderId, int belongLiveAnchorId)
        {
            try
            {
                var tikTokAppInfo = await _tikTokAppInfoReader.GetTikTokAppInfo(belongLiveAnchorId);
                var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                var host = "https://openapi-fxg.jinritemai.com";
                //请求参数
                var param = new Dictionary<string, object> {
                { "shop_order_id",orderId},
                };
                var paramJson = Marshal(param);

                //计算签名
                var signVal = Sign(tikTokAppInfo.AppKey, tikTokAppInfo.AppSecret, "order.orderDetail", timestamp, paramJson);

                //发起请求
                var res = Fetch(tikTokAppInfo.AppKey, host, "order.orderDetail", timestamp, paramJson, tikTokAppInfo.AccessToken, signVal);

                var order = JsonConvert.DeserializeObject<dynamic>(res); ;

                if (order.err_no > 0)
                {
                    return null;
                }
                List<TikTokOrder> tiktokOrderInfoList = new List<TikTokOrder>();
                foreach (var item in order.data.shop_order_detail.sku_order_list)
                {
                    TikTokOrder tikTokOrder = new TikTokOrder();
                    tikTokOrder.Id = item.order_id;
                    tikTokOrder.GoodsId = item.product_id.ToString();
                    tikTokOrder.GoodsName = item.product_name;
                    tikTokOrder.Quantity = Convert.ToInt32(item.item_num);
                    tikTokOrder.ThumbPicUrl = item.product_pic;
                    tikTokOrder.AppointmentHospital = "";
                    TikTokAfterSaleInfo tikTokAfterSaleInfo = new TikTokAfterSaleInfo();
                    tikTokAfterSaleInfo.after_sale_status = item.after_sale_info.after_sale_status;
                    tikTokAfterSaleInfo.after_sale_type = item.after_sale_info.after_sale_type;
                    tikTokAfterSaleInfo.refund_status = item.after_sale_info.refund_status;
                    tikTokOrder.OrderType = item.order_type;
                    long status = item.order_status;
                    tikTokOrder.StatusCode = GetStatusCodeOfDouYin(status, tikTokAfterSaleInfo);
                    tikTokOrder.ActualPayment = item.pay_amount / 100;
                    tikTokOrder.AccountReceivable = item.pay_amount / 100;
                    tikTokOrder.BelongLiveAnchorId = belongLiveAnchorId;
                    long createTime = item.create_time;
                    long updateTime = item.update_time;
                    long finishTime = item.finish_time;
                    long confirmTime = item.confirm_receipt_time;
                    tikTokOrder.CreateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(createTime.ToString()) ? 0 : createTime).AddHours(8);
                    tikTokOrder.UpdateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(updateTime.ToString()) ? 0 : updateTime).AddHours(8);
                    if (finishTime != 0)
                    {
                        tikTokOrder.FinishDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(finishTime.ToString()) ? 0 : finishTime).AddHours(8);
                    }
                    else
                    {
                        tikTokOrder.FinishDate = null;
                    }
                    tikTokOrder.AppType = (byte)AppType.Douyin;
                    tikTokOrder.IsAppointment = false;
                    tikTokOrder.CipherName = item.encrypt_post_receiver;
                    tikTokOrder.CipherPhone = item.encrypt_post_tel;
                    var userInfo = await _tikTokUserInfoService.DecryptUserInfoByOrderIdAsync(tikTokOrder.Id, tikTokOrder.CipherName, tikTokOrder.CipherPhone, belongLiveAnchorId);
                    //解密成功
                    if (userInfo != null)
                    {
                        tikTokOrder.Phone = userInfo.Phone;
                        tikTokOrder.BuyerNick = userInfo.Name;
                    }
                    tiktokOrderInfoList.Add(tikTokOrder);
                }
                return tiktokOrderInfoList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
