
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.Dto.TikTokUserInfo;
using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.TikTok.TikTokAppInfoConfig;
using Fx.Common.Utils;
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
        public async Task<List<TikTokOrder>> TranslateTradesSoldChangedOrders(DateTime startDate, DateTime endDate)
        {
            int day = (endDate - startDate).Days;
            if (day > 29)
                throw new Exception("开始时间和结束时间不能超过一个月");           
            int dateType = 2;  //按订单修改时间查询
            int pageNum = 0;
            var tikTokAppInfo = await _tikTokAppInfoReader.GetTikTokAppInfo();      
            List<TikTokOrder> amiyaOrderList = new List<TikTokOrder>();
            amiyaOrderList = await RequestTikTokOrderAsync(startDate, endDate, tikTokAppInfo, dateType, pageNum, amiyaOrderList);
            return amiyaOrderList;
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
        private async Task<List<TikTokOrder>> RequestTikTokOrderAsync(DateTime startDate, DateTime endDate, TikTokAppInfo tikTokAppInfo, int dateType, int pageNum, List<TikTokOrder> amiyaOrderList)
        {
            try {
                int pageSize = 100;
                var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();

                var host = "https://openapi-fxg.jinritemai.com";
                var start = DateTimeOffset.Now.ToUnixTimeSeconds() - 900;
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
                Console.WriteLine("param_json:" + paramJson);

                //计算签名
                var signVal = Sign(tikTokAppInfo.AppKey, tikTokAppInfo.AppSecret, "order.searchList", timestamp, paramJson);
                Console.WriteLine("sign_val:" + signVal);

                //发起请求
                var res = Fetch(tikTokAppInfo.AppKey, host, "order.searchList", timestamp, paramJson, tikTokAppInfo.AccessToken, signVal);

                TikTokOrderResult order = JsonConvert.DeserializeObject<TikTokOrderResult>(res); ;

                if (order.err_no > 0)
                    _logger.LogInformation(res);
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
                            tikTokOrder.ActualPayment = goodsItem.pay_amount/100;
                            tikTokOrder.CreateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(goodsItem.create_time.ToString()) ? 0 : goodsItem.create_time).AddHours(8);
                            tikTokOrder.UpdateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(goodsItem.update_time.ToString()) ? 0 : goodsItem.update_time).AddHours(8);
                            tikTokOrder.WriteOffDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(goodsItem.confirm_receipt_time.ToString()) ? 0 : goodsItem.confirm_receipt_time).AddHours(8);
                            tikTokOrder.AppType = (byte)AppType.Douyin;
                            tikTokOrder.IsAppointment = false;
                            if (tikTokOrder.OrderType == 0)
                            {
                                //医院根据门店参数实时循环获取
                                //暂时占位
                                tikTokOrder.AppointmentHospital = goodsItem.product_name;
                            }
                            currentChildList.Add(tikTokOrder);                            
                        }
                        currentChildList.ForEach(o=> { o.CipherPhone = orderItem.encrypt_post_tel;o.CipherName = orderItem.encrypt_post_receiver; });
                        /*AddTikTokUserDto addTikTokUserDto = new AddTikTokUserDto();
                        addTikTokUserDto.CipherName = orderItem.encrypt_post_receiver;
                        addTikTokUserDto.CipherPhone = orderItem.encrypt_post_tel;
                        var userinfo = _tikTokUserInfoService.getTikTokUserInfoByCipherPhone(orderItem.encrypt_post_tel);*/
                        //如果密文已存在且有对应的解密信息,直接将用户信息赋值给订单
                        /*if (userinfo != null)
                        {
                            if (!string.IsNullOrEmpty(userinfo.Phone))
                            {
                                currentChildList.ForEach(o => {
                                    o.Phone = userinfo.Phone;
                                    o.BuyerNick = userinfo.Name;
                                    o.TikTokUserId = userinfo.Id;
                                });
                            }
                        }
                        else
                        {
                            addTikTokUserDto.Id = GuidUtil.NewGuidShortString();
                            await _tikTokUserInfoService.AddAsync(addTikTokUserDto);
                            currentChildList.ForEach(o => o.TikTokUserId = addTikTokUserDto.Id);
                        }*/
                        amiyaOrderList.AddRange(currentChildList);
                    }
                }


                long orderCount = order.data.total;
                if (orderCount >= (pageNum + 1) * pageSize)
                {
                    await RequestTikTokOrderAsync(startDate, endDate, tikTokAppInfo, dateType, pageNum + 1, amiyaOrderList);
                }

                return amiyaOrderList;
            } catch (Exception ex) {
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
            Console.WriteLine("sign_pattern:" + signPattern);

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
            //售后状态只要不是初始化状态,就视订单为退款\售后状态
            if (afterSaleInfo.after_sale_status>0) {
                return code = "REFUNDING";
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
                    code = statusCode.ToString();
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
    }
}
