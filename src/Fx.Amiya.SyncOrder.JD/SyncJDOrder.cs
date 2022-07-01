
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.JD.JDAppInfoConfig;
using Fx.Common.Utils;
using Fx.Infrastructure.Utils;
using Jd.ACES;
using Jd.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.JD
{
    public class SyncJDOrder : ISyncOrder
    {
        private IJDAppInfoReader jDAppInfoReader;
        private ILogger<SyncJDOrder> logger;

        public SyncJDOrder(IJDAppInfoReader jDAppInfoReader,
            ILogger<SyncJDOrder> logger)
        {
            this.jDAppInfoReader = jDAppInfoReader;
            this.logger = logger;
        }


        private const string baseUrl = "http://api.jd.com/routerjson";


        /// <summary>
        /// 同步京东全部订单
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaOrder>> TranslateAllTradesSoldOrders(DateTime startDate, DateTime endDate)
        {

            int day = (endDate - startDate).Days;
            if (day > 29)
                throw new Exception("开始时间和结束时间不能超过一个月");

            int dateType = 1;  //按订单创建时间查询
            int pageNum = 1;


            var jDAppInfo = await jDAppInfoReader.GetJdAppInfo();

            List<AmiyaOrder> amiyaOrderList = new List<AmiyaOrder>();
            amiyaOrderList = await RequestJDOrderAsync(startDate, endDate, jDAppInfo, dateType, pageNum, amiyaOrderList);
            return amiyaOrderList;

        }




        /// <summary>
        /// 同步京东发生改变的订单
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaOrder>> TranslateTradesSoldChangedOrders(DateTime startDate, DateTime endDate)
        {
            int day = (endDate - startDate).Days;
            if (day > 29)
                throw new Exception("开始时间和结束时间不能超过一个月");

            int dateType = 2;  //按订单修改时间查询
            int pageNum = 1;

            var jDAppInfo = await jDAppInfoReader.GetJdAppInfo();

            List<AmiyaOrder> amiyaOrderList = new List<AmiyaOrder>();

            amiyaOrderList = await RequestJDOrderAsync(startDate, endDate, jDAppInfo, dateType, pageNum, amiyaOrderList);

            return amiyaOrderList;
        }



        /// <summary>
        /// 获取退款订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<RefundOrder>> GetRefundOrdersAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var jDAppInfo = await jDAppInfoReader.GetJdAppInfo();

                int pageNum = 1;
                List<RefundOrder> refundOrderList = new List<RefundOrder>();

                int applyTimeType = 1; //申请退款时间类型
                int approveTimeType = 2;//审核退款时间类型

                var applyRefundOrders = await RequestRefundOrderAsync(jDAppInfo, applyTimeType, startDate, endDate, pageNum, new List<RefundOrder>());
                var approveRefundOrders = await RequestRefundOrderAsync(jDAppInfo, approveTimeType, startDate, endDate, pageNum, new List<RefundOrder>());

                refundOrderList.AddRange(approveRefundOrders);

                foreach (var item in applyRefundOrders)
                {
                    if (!approveRefundOrders.Exists(e => e.OrderId == item.OrderId))
                        refundOrderList.Add(item);

                }


                return refundOrderList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }





        /// <summary>
        /// 获取订单消费码信息列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="codeStatus">码状态(-1：已退款，0：等待发码，1：未消费，2：已消费，3：已过期，101：退款锁定，103：过期锁定)</param>
        /// <returns></returns>
        public async Task<List<OrderLocCode>> GetOrderLocCodesAsync(DateTime startDate, DateTime endDate, int codeStatus)
        {
            try
            {
                int day = (endDate - startDate).Days;
                if (day > 30)
                    throw new Exception("开始时间和结束时间相差不能超过30天");
                var jDAppInfo = await jDAppInfoReader.GetJdAppInfo();

                int pageNum = 1;
                return await RequestLocOrderAsync(jDAppInfo, pageNum, startDate, endDate, codeStatus, new List<OrderLocCode>());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }











        /// <summary>
        /// 同步订单请求
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="jDAppInfo"></param>
        /// <param name="dateType"></param>
        /// <param name="pageNum"></param>
        /// <param name="amiyaOrderList"></param>
        /// <returns></returns>
        private async Task<List<AmiyaOrder>> RequestJDOrderAsync(DateTime startDate, DateTime endDate, JDAppInfo jDAppInfo, int dateType, int pageNum, List<AmiyaOrder> amiyaOrderList)
        {
            string method = "jingdong.pop.order.enSearch";
            int pageSize = 95;


            var paramData = new
            {
                start_date = string.Format("{0:yyyy-MM-dd HH:mm:ss}", startDate),
                end_date = string.Format("{0:yyyy-MM-dd HH:mm:ss}", endDate),
                order_state = "WAIT_SELLER_STOCK_OUT,WAIT_GOODS_RECEIVE_CONFIRM,WAIT_SELLER_DELIVERY,PAUSE,FINISHED_L,TRADE_CANCELED,LOCKED,POP_ORDER_PAUSE",
                optional_fields = "orderInfoList,consigneeInfo,itemInfoList,orderStartTime,modified,orderPayment,orderState,open_id_buyer,realPin,orderType",
                page = pageNum.ToString(),
                page_size = pageSize.ToString(),
                dateType = dateType.ToString()
            };

            string url = GetRequestUrl(jDAppInfo, method, JsonConvert.SerializeObject(paramData));

            var res = await HttpUtil.HTTPJsonGetAsync(url);
            if (res.Contains("error_response"))
                throw new Exception(res);

            var order = JsonConvert.DeserializeObject<dynamic>(res);

            var orderResult = order.jingdong_pop_order_enSearch_responce.searchorderinfo_result;
            bool success = orderResult.apiResult.success.ToObject<bool>();
            if (success == false)
                throw new Exception(orderResult.apiResult.chineseErrCode.ToObject<string>());

            int orderCount = orderResult.orderTotal.ToObject<int>();
            if (orderCount > 0)
            {

                var orderList = orderResult.orderInfoList;
                foreach (var orderItem in orderList)
                {

                    AmiyaOrder amiyaOrder = new AmiyaOrder();
                    amiyaOrder.Id = orderItem.orderId.ToObject<string>();

                    foreach (var goodsItem in orderItem.itemInfoList)
                    {
                        amiyaOrder.GoodsId = goodsItem.wareId.ToObject<string>();
                        amiyaOrder.GoodsName = goodsItem.skuName.ToObject<string>();
                        amiyaOrder.Quantity = goodsItem.itemTotal.ToObject<int>();
                    }
                    string encryptPhone = orderItem.consigneeInfo.mobile.ToObject<string>();


                    amiyaOrder.Phone = DecryptString(jDAppInfo, encryptPhone);

                    amiyaOrder.AppointmentHospital = "";
                    amiyaOrder.StatusCode = GetStatusCodeOfJD(orderItem.orderState.ToObject<string>(), orderItem.orderType.ToObject<string>());
                    amiyaOrder.OrderType = orderTypeDictionary[orderItem.orderType.ToObject<string>()];
                    amiyaOrder.ActualPayment = orderItem.orderPayment.ToObject<decimal>();
                    amiyaOrder.CreateDate = orderItem.orderStartTime.ToObject<DateTime>();
                    amiyaOrder.UpdateDate = orderItem.modified.ToObject<DateTime>();
                    //amiyaOrder.Quantity= orderItem.itemTotal.ToObject<int>();
                    // string encryptBuyerNick = orderItem.realPin.ToObject<string>();

                    //amiyaOrder.BuyerNick = DecryptString(jDAppInfo, encryptBuyerNick);
                    amiyaOrder.BuyerNick = "";

                    amiyaOrder.AppType = (byte)AppType.JD;
                    amiyaOrder.IsAppointment = false;
                    string picUrl = amiyaOrderList.FirstOrDefault(e => e.GoodsId == amiyaOrder.GoodsId)?.ThumbPicUrl;
                    amiyaOrder.ThumbPicUrl = picUrl ?? await GetGoodsUrlByGoodsIdAsync(jDAppInfo, amiyaOrder.GoodsId);

                    CousumeCodeInfo cousumeCodeInfo = await GetCousumeCodeInfoByOrderIdAsync(jDAppInfo, orderItem.orderId.ToObject<string>());
                    amiyaOrder.AppointmentHospital = cousumeCodeInfo.AppointmentHospital;
                    if (amiyaOrder.OrderType == 0)
                        amiyaOrder.StatusCode = consumeCodeStatus[cousumeCodeInfo.CodeStatus];
                    amiyaOrderList.Add(amiyaOrder);
                }


                if (orderCount >= pageNum * pageSize)
                {
                    await RequestJDOrderAsync(startDate, endDate, jDAppInfo, dateType, pageNum + 1, amiyaOrderList);
                }
            }

            return amiyaOrderList;
        }





        /// <summary>
        /// 查询退款订单请求
        /// </summary>
        /// <param name="jDAppInfo"></param>
        /// <param name="timeType">时间类型：1=按申请时间查询，2=按审核时间查询</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="refundOrderList"></param>
        /// <returns></returns>
        private async Task<List<RefundOrder>> RequestRefundOrderAsync(JDAppInfo jDAppInfo, int timeType, DateTime startDate, DateTime endDate, int pageNum, List<RefundOrder> refundOrderList)
        {
            string method = "jingdong.asc.serviceAndRefund.view";
            int pageSize = 45;

            string url = "";
            if (timeType == 1)
            {
                var paramData = new
                {
                    applyTimeBegin = string.Format("{0:yyyy-MM-dd HH:mm:ss}", startDate),
                    applyTimeEnd = string.Format("{0:yyyy-MM-dd HH:mm:ss}", endDate),
                    pageNumber = pageNum,
                    pageSize = pageSize
                };
                url = GetRequestUrl(jDAppInfo, method, JsonConvert.SerializeObject(paramData));


            }
            else
            {
                var paramData = new
                {
                    approveTimeBegin = string.Format("{0:yyyy-MM-dd HH:mm:ss}", startDate),
                    approveTimeEnd = string.Format("{0:yyyy-MM-dd HH:mm:ss}", endDate),
                    pageNumber = pageNum,
                    pageSize = pageSize
                };
                url = GetRequestUrl(jDAppInfo, method, JsonConvert.SerializeObject(paramData));


            }

            var res = await HttpUtil.HTTPJsonGetAsync(url);
            if (res.Contains("error_response"))
                throw new Exception(res);

            var order = JsonConvert.DeserializeObject<dynamic>(res);
            var orderResult = order.jingdong_asc_serviceAndRefund_view_responce.pageResult;
            bool success = orderResult.success.ToObject<bool>();
            if (success == false)
                throw new Exception("查询退款订单请求失败");
            int refundOrderCount = orderResult.totalCount.ToObject<int>();
            if (refundOrderCount > 0)
            {

                var refundDataList = orderResult.data;

                foreach (var refundInfo in refundDataList)
                {
                    var sameOrderServiceBill = refundInfo.sameOrderServiceBill;
                    RefundOrder refundOrder = new RefundOrder();
                    refundOrder.OrderId = sameOrderServiceBill.orderId.ToObject<string>();

                    string strRefundOrder = Convert.ToString(refundInfo);
                    if (!strRefundOrder.Contains("completeTime"))
                    {
                        //退款中  
                        refundOrder.Status = 101;

                    }
                    else
                    {
                        //	status:13,成功,14,失败,others,其他
                        refundOrder.Status = refundInfo.status.ToObject<int>();
                    }
                    refundOrder.StatusCode = refundStatusCode[refundOrder.Status];
                    refundOrderList.Add(refundOrder);
                }
            }
            if (refundOrderCount > pageNum * pageSize)
                await RequestRefundOrderAsync(jDAppInfo, timeType, startDate, endDate, pageNum + 1, refundOrderList);
            return refundOrderList;
        }




        /// <summary>
        /// 查询订单消费码信息
        /// </summary>
        /// <param name="jDAppInfo"></param>
        /// <param name="pageNum"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="codeStatus">码状态(-1：已退款，0：等待发码，1：未消费，2：已消费，3：已过期，101：退款锁定，103：过期锁定)</param>
        /// <param name="writeOffOrderList"></param>
        /// <returns></returns>
        private async Task<List<OrderLocCode>> RequestLocOrderAsync(JDAppInfo jDAppInfo, int pageNum, DateTime startDate, DateTime endDate, int codeStatus, List<OrderLocCode> orderLocCodeList)
        {
            string method = "jingdong.pop.oto.locorderinfos.get";
            int pageSize = 45;
            var paramData = new
            {
                time_type = 1,  //	查询时间的类型，1表示码状态的修改时间，2表示订单创建时间
                start_date = string.Format("{0:yyyy-MM-dd HH:mm:ss}", startDate),
                end_date = string.Format("{0:yyyy-MM-dd HH:mm:ss}", endDate),
                code_status = codeStatus,   //码状态(-1：已退款，0：等待发码，1：未消费，2：已消费，3：已过期，101：退款锁定，103：过期锁定)
                code_type = 0,  //码类型(0代表码是京东生成，1代表商家生成码)
                page_index = pageNum,
                page_size = pageSize
            };

            string url = GetRequestUrl(jDAppInfo, method, JsonConvert.SerializeObject(paramData));
            var res = await HttpUtil.HTTPJsonGetAsync(url);
            if (res.Contains("error_response"))
                throw new Exception(res);


            var order = JsonConvert.DeserializeObject<dynamic>(res);
            var loccodeinfoResult = order.jingdong_pop_oto_locorderinfos_get_responce.loccodeinfo_result;
            bool success = loccodeinfoResult.is_success.ToObject<bool>();
            if (success == false)
                throw new Exception(loccodeinfoResult.result_message.ToObject<string>());


            int totalCoune = loccodeinfoResult.total_code.ToObject<int>();
            if (totalCoune > 0)
            {
                var loccodeinfoList = loccodeinfoResult.loccodeinfo_list;
                foreach (var loccodeinfo in loccodeinfoList)
                {
                    OrderLocCode orderLocCode = new OrderLocCode();
                    orderLocCode.OrderId = loccodeinfo.order_id.ToObject<string>();
                    orderLocCode.Status = loccodeinfo.code_status;
                    orderLocCode.StatusCode = consumeCodeStatus[loccodeinfo.code_status.ToObject<int>()];
                    orderLocCode.AppointmentHospital = loccodeinfo.order_shop_name.ToObject<string>();
                    orderLocCodeList.Add(orderLocCode);
                }
            }

            if (totalCoune > pageNum * pageSize)
                await RequestLocOrderAsync(jDAppInfo, pageNum + 1, startDate, endDate, codeStatus, orderLocCodeList);

            return orderLocCodeList;
        }


        /// <summary>
        /// 获取请求url
        /// </summary>
        /// <param name="jDAppInfo"></param>
        /// <param name="method"></param>
        /// <param name="paramJson"></param>
        /// <returns></returns>
        private string GetRequestUrl(JDAppInfo jDAppInfo, string method, string paramJson)
        {
            DateTime date = DateTime.Now;
            string timestamp = string.Format("{0:yyyy-MM-dd HH:mm:ss}", date.AddMinutes(-2));
            Dictionary<string, string> signDictionary = new Dictionary<string, string>();
            signDictionary.Add("access_token", jDAppInfo.AccessToken);
            signDictionary.Add("app_key", jDAppInfo.AppKey);
            signDictionary.Add("method", method);
            signDictionary.Add("timestamp", timestamp);
            signDictionary.Add("v", "2.0");
            signDictionary.Add("360buy_param_json", paramJson);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(jDAppInfo.AppSecret);
            signDictionary = signDictionary.OrderBy(e => e.Key).ToDictionary(e => e.Key, t => t.Value);
            foreach (KeyValuePair<string, string> item in signDictionary)
            {
                if (!string.IsNullOrWhiteSpace(item.Value))
                {
                    stringBuilder.Append(string.Format("{0}{1}", item.Key, item.Value));
                }
            }
            stringBuilder.Append(jDAppInfo.AppSecret);
            string sign = MD5Helper.Get32MD5One(stringBuilder.ToString());

            string url = baseUrl + string.Format("?360buy_param_json={0}&access_token={1}&app_key={2}&method={3}&timestamp={4}&v={5}&sign={6}"
                 , paramJson, jDAppInfo.AccessToken, jDAppInfo.AppKey, method, timestamp, "2.0", sign);

            return url;
        }



        /// <summary>
        /// 根据商品编号获取商品图片
        /// </summary>
        /// <param name="jDAppInfo"></param>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        private async Task<string> GetGoodsUrlByGoodsIdAsync(JDAppInfo jDAppInfo, string goodsId)
        {
            string method = "jingdong.image.read.findFirstImage";
            var paramData = new
            {
                wareId = goodsId,         //	商品id
                colorId = "0000000000"    //颜色id.如果默认SKU,则传0000000000
            };

            string url = GetRequestUrl(jDAppInfo, method, JsonConvert.SerializeObject(paramData));
            var res = await HttpUtil.HTTPJsonGetAsync(url);
            if (res.Contains("error_response"))
                logger.LogInformation(res);


            var imageRes = JsonConvert.DeserializeObject<dynamic>(res);
            var imageResponce = imageRes.jingdong_image_read_findFirstImage_responce;
            if (imageResponce.code.ToObject<int>() == 0)
            {
                return "https://m.360buyimg.com/n0/" + imageResponce.image.imgUrl.ToObject<string>();
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 根据订单号获取消费码信息
        /// </summary>
        /// <param name="jDAppInfo"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CousumeCodeInfo> GetCousumeCodeInfoByOrderIdAsync(JDAppInfo jDAppInfo, string orderId)
        {
            string method = "jingdong.pop.oto.locorderinfo.get";
            var paramData = new
            {
                order_id = orderId,   //订单号
                code_type = 0        //码类型(0代表码是京东生成，1代表商家生成码)
            };

            string url = GetRequestUrl(jDAppInfo, method, JsonConvert.SerializeObject(paramData));
            var res = await HttpUtil.HTTPJsonGetAsync(url);
            if (res.Contains("error_response"))
                throw new Exception(res);

            var cousumeCode = JsonConvert.DeserializeObject<dynamic>(res);
            var loccodeinfoResult = cousumeCode.jingdong_pop_oto_locorderinfo_get_responce.loccodeinfo_result;
            bool success = loccodeinfoResult.is_success.ToObject<bool>();
            if (success == false)
                throw new Exception(loccodeinfoResult.result_message.ToObject<string>());

            CousumeCodeInfo cousumeCodeInfo = new CousumeCodeInfo();
            if (res.Contains("loccodeinfo_list"))
            {
                var loccodeinfoList = loccodeinfoResult.loccodeinfo_list;
                foreach (var item in loccodeinfoList)
                {
                    cousumeCodeInfo.OrderId = item.order_id.ToObject<string>();
                    if (res.Contains("order_shop_name"))
                        cousumeCodeInfo.AppointmentHospital = item.order_shop_name.ToObject<string>();
                    cousumeCodeInfo.CodeStatus = item.code_status.ToObject<int>();
                    cousumeCodeInfo.CodeStatusText = consumeCodeStatus[item.code_status.ToObject<int>()];
                }
            }

            return cousumeCodeInfo;
        }



        private string DecryptString(JDAppInfo jDAppInfo, string encryptText)
        {
            TDEClient tDEClient = TDEClient.GetInstance(baseUrl, jDAppInfo.AppKey, jDAppInfo.AppSecret, jDAppInfo.AccessToken);
            return tDEClient.DecryptString(encryptText);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="orderType">订单类型：22=SOP（实物订单），75=LOC（虚拟订单）</param>
        /// <returns></returns>
        public static string GetStatusCodeOfJD(string statusCode, string orderType)
        {
            string code = "";
            switch (statusCode)
            {
                case "FINISHED_L":
                    if (orderType == "75")
                    {
                        code = "WAIT_BUYER_CONFIRM_GOODS";
                    }
                    else
                    {
                        code = "TRADE_FINISHED";
                    }
                    break;

                //待出库，即买家已付款
                case "WAIT_SELLER_STOCK_OUT":
                    code = "WAIT_SELLER_SEND_GOODS";
                    break;

                //等待确认收货,即卖家已发货
                case "WAIT_GOODS_RECEIVE_CONFIRM":
                    code = "WAIT_BUYER_CONFIRM_GOODS";
                    break;

                default:
                    code = statusCode;
                    break;
            }

            return code;
        }

        public Task<List<AmiyaOrder>> TranslateTradesSoldOrdersByOrderId(long orderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        Dictionary<string, byte> orderTypeDictionary = new Dictionary<string, byte>()
        {
            { "75",0}, //虚拟订单（电子凭证）
            { "22",1}   //实物订单（快递发货）
        };



        //退款状态码
        Dictionary<int, string> refundStatusCode = new Dictionary<int, string>()
        {

            { 101,"REFUNDING"},    //退款中
            { 13,"TRADE_CLOSED"},  //付款以后用户退款成功，交易自动关闭（已退款）
            { 14,"REFUND_FAIL"},   //退款失败
        };


        //消费码状态
        Dictionary<int, string> consumeCodeStatus = new Dictionary<int, string>()
        {
             { -1,"TRADE_CLOSED"},  //付款以后用户退款成功，交易自动关闭（已退款）
            { 0,"AWAIT_CODE"},     //等待发码
            { 1,"WAIT_BUYER_CONFIRM_GOODS"}, //等待买家确认收货（未消费）
            { 2,"TRADE_FINISHED"}, //TRADE_FINISHED（已消费）
            { 3,"IS_EXPIRE"},       //已过期
            { 101,"REFUNDING"},    //退款中
        };

    }
}
