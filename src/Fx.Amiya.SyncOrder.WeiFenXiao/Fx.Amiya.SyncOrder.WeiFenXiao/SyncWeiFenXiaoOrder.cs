using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.WeiFenXiao.WeiFenXiaoAppInfoConfig;
using Fx.Common.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeiFenXiao
{
    public class SyncWeiFenXiaoOrder : ISyncWeiFenXiaoOrder
    {
        private IWeiFenXiaoAppInfoReader _weiFenXiaoAppInfoReader;
        private ILogger<SyncWeiFenXiaoOrder> _logger;

        public SyncWeiFenXiaoOrder(IWeiFenXiaoAppInfoReader weiFenXiaoAppInfoReader, ILogger<SyncWeiFenXiaoOrder> logger)
        {
            _weiFenXiaoAppInfoReader = weiFenXiaoAppInfoReader;
            _logger = logger;
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
        /// 同步微信公众号（微分销）发生改变的订单
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<AmiyaOrder>> TranslateTradesSoldChangedOrders(DateTime startDate, DateTime endDate)
        {
            int day = (endDate - startDate).Days;
            if (day > 29)
                throw new Exception("开始时间和结束时间不能超过一个月");

            int dateType = 2;  //按订单修改时间查询
            int pageNum = 1;

            var weChatOfficialAccountAppInfo = await _weiFenXiaoAppInfoReader.GetWeiFenXiaoAppInfo();

            List<AmiyaOrder> amiyaOrderList = new List<AmiyaOrder>();

            amiyaOrderList = await RequestWeiFenXiaoOrderAsync(startDate, endDate, weChatOfficialAccountAppInfo, dateType, pageNum, amiyaOrderList);

            return amiyaOrderList;
        }

        /// <summary>
        /// 同步微分销订单请求
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="weiFenXiaoAppInfo"></param>
        /// <param name="dateType"></param>
        /// <param name="pageNum"></param>
        /// <param name="amiyaOrderList"></param>
        /// <returns></returns>
        private async Task<List<AmiyaOrder>> RequestWeiFenXiaoOrderAsync(DateTime startDate, DateTime endDate, WeiFenXiaoAppInfo weiFenXiaoAppInfo, int dateType, int pageNum, List<AmiyaOrder> amiyaOrderList)
        {
            int pageSize = 95;

            string orderRequestUrl = GetRequestUrl("/order/list") + string.Format("?access_token={0}&start_modify={1}&end_modify={2}"
                 , weiFenXiaoAppInfo.RefreshToken, startDate, endDate);
            var res = await HttpUtil.HTTPJsonGetAsync(orderRequestUrl);

            if (res.Contains("errorcode"))
                _logger.LogInformation(res);

            var order = JsonConvert.DeserializeObject<WeiFenXiaoOrderResult>(res);
            if (order.total > 0)
            {
                foreach (var orderItem in order.orderList)
                {
                    int orderIdNum = 1;
                    foreach (var goodsItem in orderItem.childList)
                    {
                        AmiyaOrder amiyaOrder = new AmiyaOrder();
                        if (orderItem.childList.Count > 1)
                        {
                            if (orderIdNum > 99)
                            {
                                amiyaOrder.Id = orderItem.order_no + orderIdNum.ToString();
                            }
                            else if (orderIdNum > 9)
                            {
                                amiyaOrder.Id = orderItem.order_no + "0" + orderIdNum.ToString();
                            }
                            else
                            {
                                amiyaOrder.Id = orderItem.order_no + "00" + orderIdNum.ToString();
                            }
                            orderIdNum++;
                        }
                        else
                        {
                            amiyaOrder.Id = orderItem.order_no;
                        }
                        amiyaOrder.GoodsId = goodsItem.item_id;
                        amiyaOrder.GoodsName = goodsItem.item_title;
                        amiyaOrder.Quantity = string.IsNullOrEmpty(goodsItem.num) ? 0 : Convert.ToInt32(goodsItem.num);
                        amiyaOrder.ThumbPicUrl = goodsItem.item_img;
                        amiyaOrder.AppointmentHospital = "";
                        amiyaOrder.StatusCode = GetStatusCodeOfWeiFenxiao(orderItem.status);
                        if (Convert.ToInt16(goodsItem.num) == 0)
                        {
                            amiyaOrder.StatusCode = "TRADE_CLOSED";
                        }
                        amiyaOrder.OrderType = (byte)(orderItem.is_self_take == "1" ? 0 : 1);
                        var currentPrice = string.IsNullOrEmpty(goodsItem.current_price) ? 0.00M : Convert.ToDecimal(goodsItem.current_price);
                        amiyaOrder.ActualPayment = currentPrice * amiyaOrder.Quantity;
                        amiyaOrder.CreateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(orderItem.create_time) ? 0 : Convert.ToInt64(orderItem.create_time)).AddHours(8);
                        amiyaOrder.UpdateDate = UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(orderItem.order_update_time) ? 0 : Convert.ToInt64(orderItem.order_update_time)).AddHours(8);
                        amiyaOrder.WriteOffDate= UnixTimestampToDateTime(DateTime.Now, string.IsNullOrEmpty(orderItem.end_time) ? 0 : Convert.ToInt64(orderItem.end_time)).AddHours(8);
                        amiyaOrder.AppType = (byte)AppType.WeChatOfficialAccount;
                        amiyaOrder.IsAppointment = false;
                        if (amiyaOrder.OrderType == 0)
                        {
                            //医院根据门店参数实时循环获取
                            amiyaOrder.AppointmentHospital = goodsItem.sku_name;
                        }
                        //     //根据用户id获取用户信息
                        //     string userinfoGetUrl = GetRequestUrl("/user/info") + string.Format("?access_token={0}&user_id={1}"
                        //, weiFenXiaoAppInfo.RefreshToken, orderItem.user_id);
                        //     var userInfoResult = await HttpUtil.HTTPJsonGetAsync(userinfoGetUrl);
                        //     if (res.Contains("error_response"))
                        //         throw new Exception(userInfoResult);

                        //     var userInfo = JsonConvert.DeserializeObject<WeiFenXiaoUserInfo>(userInfoResult);

                        amiyaOrder.BuyerNick = orderItem.receiver_name;
                        amiyaOrder.Phone = orderItem.receiver_mobile;
                        amiyaOrderList.Add(amiyaOrder);
                    }
                }
            }


            int orderCount = order.total;
            if (orderCount >= pageNum * pageSize)
            {
                await RequestWeiFenXiaoOrderAsync(startDate, endDate, weiFenXiaoAppInfo, dateType, pageNum + 1, amiyaOrderList);
            }

            return amiyaOrderList;
        }


        /// <summary>
        /// 获取请求url
        /// </summary>
        /// <param name="path">拼接请求地址</param>
        /// <returns></returns>
        private string GetRequestUrl(string path)
        {
            string url = "http://api.wifenxiao.com";
            if (!string.IsNullOrEmpty(path))
            {
                url += path;
            }
            return url;
        }



        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="statusCode">微分销返回订单状态</param>
        /// <returns></returns>
        private static string GetStatusCodeOfWeiFenxiao(string statusCode)
        {
            string code = "";
            switch (statusCode)
            {
                case "0":
                    code = "WAIT_BUYER_PAY";
                    break;

                //待出库，即买家已付款
                case "1":
                    code = "WAIT_SELLER_SEND_GOODS";
                    break;

                //等待确认收货,即卖家已发货
                case "2":
                    code = "WAIT_BUYER_CONFIRM_GOODS";
                    break;
                //买家确认收货，即：交易成功
                case "3":
                    code = "TRADE_FINISHED";
                    break;
                //付款以前，卖家或买家主动关闭交易
                case "4":
                    code = "TRADE_CLOSED";
                    break;
                //付款以后用户退款成功，交易自动关闭
                case "5":
                    code = "TRADE_CLOSED";
                    break;
                //用户退款中
                case "6":
                    code = "REFUNDING";
                    break;
                default:
                    code = statusCode;
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
