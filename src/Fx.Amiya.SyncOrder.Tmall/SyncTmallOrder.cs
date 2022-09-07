using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.Tmall.TmallAppInfoConfig;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace Fx.Amiya.SyncOrder.Tmall
{
    public class SyncTmallOrder : ISyncOrder
    {
        private ITmallAppInfoReader tmallAppInfoReader;
        private ILogger<SyncTmallOrder> logger;

        public SyncTmallOrder(ITmallAppInfoReader tmallAppInfoReader, ILogger<SyncTmallOrder> logger)
        {
            this.tmallAppInfoReader = tmallAppInfoReader;
            this.logger = logger;
        }



        /// <summary>
        /// 同步天猫全部订单
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaOrder>> TranslateAllTradesSoldOrders(DateTime startDate, DateTime endDate)
        {
            List<long> orderIds = new List<long>();
            int pageNum = 1;
            var tmallAppInfo = await tmallAppInfoReader.GetTmallAppInfo();
            orderIds = TradesSoldRequest(startDate, endDate, tmallAppInfo, pageNum, orderIds);
            return GetOrderDetailListAsync(tmallAppInfo, orderIds);
        }

        /// <summary>
        /// 根据订单号同步天猫订单
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaOrder>> TranslateTradesSoldOrdersByOrderId(long orderId)
        {
            List<long> orderIds = new List<long>();
            orderIds.Add(orderId);
            var tmallAppInfo = await tmallAppInfoReader.GetTmallAppInfo();
            return GetOrderDetailListAsync(tmallAppInfo, orderIds);
        }


        /// <summary>
        /// 同步天猫已卖出的增量交易数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AmiyaOrder>> TranslateTradesSoldChangedOrders(DateTime startDate, DateTime endDate)
        {
            int pageNum = 1;
            List<long> orderIds = new List<long>();
            var tmallAppInfo = await tmallAppInfoReader.GetTmallAppInfo();
            orderIds = TradesSoldIncrementRequest(startDate, endDate, tmallAppInfo, pageNum, orderIds);
            return GetOrderDetailListAsync(tmallAppInfo, orderIds);
        }





        private List<long> TradesSoldRequest(DateTime startDate, DateTime endDate, TmallAppInfo tmallAppInfo, int pageNum, List<long> tids)
        {
            string url = "http://gw.api.taobao.com/router/rest";

            ITopClient client = new DefaultTopClient(url, tmallAppInfo.AppKey, tmallAppInfo.AppSecret, "json");
            TradesSoldGetRequest req = new TradesSoldGetRequest();
            req.Fields = "tid,total_results";
            req.StartCreated = startDate;
            req.EndCreated = endDate;
            req.PageNo = pageNum;
            req.PageSize = 90;
            req.UseHasNext = true;
            TradesSoldGetResponse rsp = client.Execute(req, tmallAppInfo.AccessToken);

            var resJson = JsonConvert.DeserializeObject<dynamic>(rsp.Body);

            if (rsp.Body.Contains("trades"))
            {
                try
                {
                    string tradesResponse = JsonConvert.SerializeObject(resJson.trades_sold_get_response);
                    if (!tradesResponse.Contains("trades"))
                        return new List<long>();

                    var trade = resJson.trades_sold_get_response.trades.trade;
                    foreach (var item in trade)
                    {
                        tids.Add(Convert.ToInt64(item.tid));
                    }

                    if (resJson.trades_sold_get_response.has_next == true)
                    {
                        pageNum = pageNum + 1;
                        TradesSoldRequest(startDate, endDate, tmallAppInfo, pageNum, tids);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogInformation(ex.Message);
                }
            }

            return tids;
        }



        public List<AmiyaOrder> GetOrderDetailListAsync(TmallAppInfo tmallAppInfo, List<long> orderIds)
        {
            List<AmiyaOrder> tmallOrderList = new List<AmiyaOrder>();
            foreach (var orderId in orderIds)
            {
                var strTaobaoOrder = GetTradeFullinfo(tmallAppInfo, orderId);
                var taobaoOrder = JsonConvert.DeserializeObject<dynamic>(strTaobaoOrder);
                if (strTaobaoOrder.IndexOf("error_response") > -1)
                {
                    var error = taobaoOrder.error_response.sub_msg;
                    throw new Exception(error.ToObject<string>());
                }
                var trade = taobaoOrder.trade_fullinfo_get_response.trade;
                var taobaoOrders = trade.orders.order;
                foreach (var item in taobaoOrders)
                {
                    AmiyaOrder tmallOrder = new AmiyaOrder();
                    tmallOrder.Id = item.oid.ToObject<string>();
                    tmallOrder.GoodsId = item.num_iid;
                    tmallOrder.GoodsName = item.title;
                    tmallOrder.AppointmentHospital = item.et_shop_name;
                    if (strTaobaoOrder.Contains("order_attr"))
                    {
                        string tr = item.order_attr;
                        var sd = JsonConvert.DeserializeObject<dynamic>(item.order_attr.ToObject<string>());
                        tmallOrder.Phone = sd.mobile;
                    }
                    else
                    {
                        tmallOrder.Phone = "";
                    }
                    tmallOrder.Quantity = item.num;
                    tmallOrder.ActualPayment = item.total_fee;
                    //加入应收款
                    tmallOrder.AccountReceivable = item.payment;
                    tmallOrder.IsAppointment = false;
                    tmallOrder.StatusCode = item.status.ToObject<string>();
                    tmallOrder.CreateDate = trade.created.ToObject<DateTime>();
                    tmallOrder.UpdateDate = trade.modified.ToObject<DateTime>();
                    if (item.end_time!=null)
                    {
                        tmallOrder.WriteOffDate = item.end_time.ToObject<DateTime>();
                    }
                    tmallOrder.ThumbPicUrl = item.pic_path.ToObject<string>();
                    tmallOrder.BuyerNick = trade.buyer_nick.ToObject<string>();
                    tmallOrder.OrderType = orderTypeDictionary[trade.type.ToObject<string>()];
                    tmallOrder.AppType = (byte)AppType.Tmall;
                    tmallOrderList.Add(tmallOrder);

                }
            }
            return tmallOrderList;
        }



        /// <summary>
        /// 获取单笔交易的详细信息
        /// </summary>
        /// <returns></returns>
        private string GetTradeFullinfo(TmallAppInfo tmallAppInfo, long tid)
        {
            string url = "http://gw.api.taobao.com/router/rest";
            ITopClient client = new DefaultTopClient(url, tmallAppInfo.AppKey, tmallAppInfo.AppSecret, "json");
            TradeFullinfoGetRequest req = new TradeFullinfoGetRequest();
            //req.Fields = "receiver_mobile,receiver_phone,tid,o2o_shop_id,o2o_shop_name,type,orders,created,modified,buyer_nick,type";
            req.Fields = "tid,o2o_shop_id,o2o_shop_name,type,orders,created,modified,buyer_nick,type";
            req.Tid = tid;
            try
            {
                TradeFullinfoGetResponse rsp = client.Execute(req, tmallAppInfo.AccessToken);
                return rsp.Body;
            }
            catch (Exception err)
            {
                string xx = err.Message.ToString();
                return xx;
            }
        }




        private List<long> TradesSoldIncrementRequest(DateTime startDate, DateTime endDate, TmallAppInfo tmallAppInfo, int pageNum, List<long> tids)
        {
            string url = "http://gw.api.taobao.com/router/rest";
            ITopClient client = new DefaultTopClient(url, tmallAppInfo.AppKey, tmallAppInfo.AppSecret, "json");
            TradesSoldIncrementGetRequest req = new TradesSoldIncrementGetRequest();
            req.Fields = "tid";
            req.StartModified = startDate;
            req.EndModified = endDate;
            req.PageNo = pageNum;
            req.PageSize = 90;
            req.UseHasNext = true;
            TradesSoldIncrementGetResponse rsp = client.Execute(req, tmallAppInfo.AccessToken);

            var res = JsonConvert.DeserializeObject<dynamic>(rsp.Body);

            if (rsp.Body.Contains("trades"))
            {
                string tradesResponse = JsonConvert.SerializeObject(res.trades_sold_increment_get_response);
                if (!tradesResponse.Contains("trades"))
                    return new List<long>();

                var trade = res.trades_sold_increment_get_response.trades.trade;

                foreach (var item in trade)
                {
                    tids.Add(Convert.ToInt64(item.tid));
                }
                if (res.trades_sold_increment_get_response.has_next == true)
                {
                    pageNum = pageNum + 1;
                    TradesSoldIncrementRequest(startDate, endDate, tmallAppInfo, pageNum, tids);
                }
            }
            return tids;
        }

        public Task<List<RefundOrder>> GetRefundOrdersAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderLocCode>> GetOrderLocCodesAsync(DateTime startDate, DateTime endDate, int codeStatus)
        {
            throw new NotImplementedException();
        }


        Dictionary<string, byte> orderTypeDictionary = new Dictionary<string, byte>()
        {
            { "eticket",0}, //虚拟订单（电子凭证）
            { "fixed",1}   //实物订单（快递发货）
        };
    }
}
