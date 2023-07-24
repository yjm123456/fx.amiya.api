using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.Dto.OrderRefund;
using Fx.Amiya.Dto.WxPay;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fx.Amiya.Service
{
    public class WxPayService : IWxPayService
    {
        private IDalOrderRefund dalOrderRefund;
        private readonly IHuiShouQianPaymentService huiShouQianPaymentService;
        private readonly IOrderService orderService;
        private readonly IDalCustomerInfo dalCustomerInfo;
        private readonly IDalWechatPayInfo dalWechatPayInfo;
        private readonly IShanDePayMentService shanDePayMentService;
        public WxPayService(IDalOrderRefund dalOrderRefund, IHuiShouQianPaymentService huiShouQianPaymentService, IOrderService orderService, IDalCustomerInfo dalCustomerInfo, IDalWechatPayInfo dalWechatPayInfo, IShanDePayMentService shanDePayMentService)
        {
            this.dalOrderRefund = dalOrderRefund;
            this.huiShouQianPaymentService = huiShouQianPaymentService;
            this.orderService = orderService;
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalWechatPayInfo = dalWechatPayInfo;
            this.shanDePayMentService = shanDePayMentService;
        }

        /// <summary>
        /// 微信退款发起
        /// </summary>
        /// <param name="refundOrderId"></param>
        /// <returns></returns>
        public async Task<RefundOrderResult> WechatRefundAsync(string refundOrderId)
        {
            RefundOrderResult refunResult = new RefundOrderResult();
            var refundOrder = dalOrderRefund.GetAll().Where(e => e.Id == refundOrderId).SingleOrDefault();
            var customerInfo = dalCustomerInfo.GetAll().Where(e => e.Id == refundOrder.CustomerId).SingleOrDefault();
            if (customerInfo == null)
            {
                throw new Exception("用户编号错误");
            }
            //慧收钱退款
            if (customerInfo.AppId == "wx695942e4818de445" && (refundOrder.ExchangeType == (int)ExchangeType.PointAndMoney || refundOrder.ExchangeType == (int)ExchangeType.HuiShouQian))
            {
                //退还积分
                if (refundOrder.IsPartial)
                {
                    await orderService.CancelPartPointAndMoneyOrderWithNoTransactionAsync(refundOrder.OrderId, refundOrder.CustomerId);
                }
                else {
                    //退还积分
                    await orderService.CancelPointAndMoneyOrderWithNoTransactionAsync(refundOrder.TradeId, refundOrder.CustomerId);
                }
               
                refunResult = await huiShouQianPaymentService.CreateHuiShouQianAndPointRefundOrder(refundOrderId);
                refunResult.IsPartial = refundOrder.IsPartial;
                refunResult.OrderId = refundOrder.OrderId;
                return refunResult;
            }
            

            //杉德支付退款
            if (customerInfo.AppId == "wx8747b7f34c0047eb" && (refundOrder.ExchangeType == (int)ExchangeType.PointAndMoney || refundOrder.ExchangeType == (int)ExchangeType.ShanDePay)){
                //退还积分
                if (refundOrder.IsPartial)
                {
                    await orderService.CancelPartPointAndMoneyOrderWithNoTransactionAsync(refundOrder.OrderId, refundOrder.CustomerId);
                }
                else
                {
                    
                    await orderService.CancelPointAndMoneyOrderWithNoTransactionAsync(refundOrder.TradeId, refundOrder.CustomerId);
                }
                refunResult = await shanDePayMentService.CreateRefundOrderAsync(refundOrderId);
                refunResult.IsPartial = refundOrder.IsPartial;
                refunResult.OrderId = refundOrder.OrderId;
                return refunResult;
            }

            //微信支付退款
            if (refundOrder == null) { throw new Exception("退款编号错误"); }
            if (refundOrder.CheckState != (int)CheckState.CheckSuccess) throw new Exception("只有审核通过的订单才能退款");
            if (refundOrder.IsPartial)
            {
                var success = dalOrderRefund.GetAll().Where(e => e.TradeId == refundOrder.TradeId && e.OrderId == refundOrder.OrderId && e.RefundState == (int)RefundState.RefundSuccess).ToList();
                if (success.Count > 0)
                {
                    throw new Exception("订单已退款,请勿重复请求");
                }
                if (refundOrder.RefundState == (byte)RefundState.RefundSuccess) throw new Exception("订单已退款,请勿重复请求");
            }
            else
            {
                var success = dalOrderRefund.GetAll().Where(e => e.TradeId == refundOrder.TradeId && e.RefundState == (int)RefundState.RefundSuccess).ToList();
                if (success.Count > 0)
                {
                    throw new Exception("订单已退款,请勿重复请求");
                }
                if (refundOrder.RefundState == (byte)RefundState.RefundSuccess) throw new Exception("订单已退款,请勿重复请求");
            }

            //var success = dalOrderRefund.GetAll().Where(e => e.TradeId == refundOrder.TradeId && e.RefundState == (int)RefundState.RefundSuccess).ToList();
            //if (success.Count > 0)
            //{
            //    throw new Exception("订单已退款,请勿重复请求");
            //}
            //if (refundOrder.RefundState == (byte)RefundState.RefundSuccess) throw new Exception("订单已退款,请勿重复请求");
            var wechatPayInfo = dalWechatPayInfo.GetAll().Where(e => e.AppId == customerInfo.AppId).SingleOrDefault();
            if (wechatPayInfo == null)
            {
                throw new Exception("没有为该小程序配置微信支付信息！");
            }

            //退还积分,支付积分大于0时退还,小于等于0时,不处理
            if (refundOrder.IsPartial)
            {
                await orderService.CancelPartPointAndMoneyOrderWithNoTransactionAsync(refundOrder.OrderId, refundOrder.CustomerId);
            }
            else
            {

                await orderService.CancelPointAndMoneyOrderWithNoTransactionAsync(refundOrder.TradeId, refundOrder.CustomerId);
            }

            WxRefundPackageInfo packageInfo = new WxRefundPackageInfo();
            packageInfo.AppId = wechatPayInfo.AppId;
            packageInfo.MchId = wechatPayInfo.PartnerId;
            packageInfo.AppSecret = wechatPayInfo.PartnerKey;
            packageInfo.NotifyUrl = "https://app.ameiyes.com/amiyamini";
            packageInfo.OutTradeNo = string.IsNullOrEmpty(refundOrder.TransNo) ? refundOrder.TradeId :refundOrder.TransNo;
            packageInfo.OutRefundNo = refundOrder.Id;
            packageInfo.TotalFee = (int)(refundOrder.ActualPayAmount * 100m);
            packageInfo.RefundFee = (int)(refundOrder.RefundAmount * 100m);
            packageInfo.RefundDesc = "商品退款";
            var result = await this.BuildRefundRequest(packageInfo, wechatPayInfo.CertificateName);
            result.TardeId = refundOrder.TradeId;
            refunResult.IsPartial = refundOrder.IsPartial;
            refunResult.OrderId = refundOrder.OrderId;
            return result;
        }


        private async Task<RefundOrderResult> BuildRefundRequest(WxRefundPackageInfo packageInfo,string perPath)
        {

            packageInfo.NonceStr = Guid.NewGuid().ToString("N");
            PayDictionary payDictionary = new PayDictionary();
            payDictionary.Add("appid", packageInfo.AppId);
            payDictionary.Add("mch_id", packageInfo.MchId);
            payDictionary.Add("nonce_str", packageInfo.NonceStr);
            payDictionary.Add("sign_type", packageInfo.SignType);
            payDictionary.Add("transaction_id", packageInfo.TransactionId);
            payDictionary.Add("out_trade_no", packageInfo.OutTradeNo);
            payDictionary.Add("out_refund_no", packageInfo.OutRefundNo);
            payDictionary.Add("total_fee", packageInfo.TotalFee);
            payDictionary.Add("refund_fee", packageInfo.RefundFee);
            payDictionary.Add("refund_fee_type", packageInfo.RefundFeeType);
            payDictionary.Add("refund_desc", packageInfo.RefundDesc);
            payDictionary.Add("refund_account", packageInfo.RefundAccount);
            payDictionary.Add("notify_url", packageInfo.NotifyUrl);
            SignHelper signHelper = new SignHelper();
            string sign = await signHelper.SignPackage(payDictionary, packageInfo.AppSecret);
            return await this.PostRefundRequest(payDictionary, sign, packageInfo.AppId, packageInfo.MchId, perPath);
        }
        private async Task<RefundOrderResult> PostRefundRequest(PayDictionary dict, string sign, string appId,string mchId,string perPath)
        {
            dict.Add("sign", sign);
            SignHelper signHelper = new SignHelper();
            string text = await signHelper.BuildQueryAsync(dict, false);
            string postData = await signHelper.BuildXmlAsync(dict, false);
            string refundUrl = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            return this.PostRefundData(refundUrl, postData, appId,mchId, perPath);
        }
        /// <summary>
        /// 微信支付帮助方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="appId">小程序appid</param>
        /// <param name="mchId">微信支付商户号id</param>
        /// <returns></returns>
        private RefundOrderResult PostRefundData(string url, string postData, string appId,string mchId,string perPath)
        {
            string text = string.Empty;
            try
            {
                Uri requestUri = new Uri(url);
                HttpWebRequest httpWebRequest;
                if (url.ToLower().StartsWith("https"))
                {
                    
                    //证书文件地址
                    string path = "";
                    //上合未来密钥
                    path = AppDomain.CurrentDomain.BaseDirectory + perPath;
                    if (string.IsNullOrEmpty(path)) {
                        throw new Exception("没有该小程序的证书文件！");
                    }
                    ServicePointManager.ServerCertificateValidationCallback = ((object s, X509Certificate c, X509Chain ch, SslPolicyErrors e) => true);
                    //加载证书
                    X509Certificate2 cer = null;
                    cer = new X509Certificate2(path, mchId);
                    httpWebRequest = (HttpWebRequest)WebRequest.CreateDefault(requestUri);
                    httpWebRequest.ClientCertificates.Add(cer);
                }
                else
                {
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
                }
                Encoding uTF = Encoding.UTF8;
                byte[] bytes = uTF.GetBytes(postData);
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                requestStream.Dispose();
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (Stream responseStream = httpWebResponse.GetResponseStream())
                    {
                        Encoding uTF2 = Encoding.UTF8;
                        StreamReader streamReader = new StreamReader(responseStream, uTF2);
                        text = streamReader.ReadToEnd();
                        XmlDocument xmlDocument = new XmlDocument();
                        try
                        {
                            xmlDocument.LoadXml(text);
                        }
                        catch (Exception ex)
                        {
                            text = string.Format("获取信息错误：{0}", ex.Message) + text;
                        }
                        try
                        {
                            if (xmlDocument == null)
                            {
                                RefundOrderResult refundOrderResult = new RefundOrderResult
                                {
                                    Result = false,
                                    Msg = "返回数据为空"
                                };
                                return refundOrderResult;
                            }
                            XmlNode xmlNode = xmlDocument.SelectSingleNode("xml/return_code");
                            if (xmlNode == null)
                            {
                                RefundOrderResult refundOrderResult = new RefundOrderResult
                                {
                                    Result = false,
                                    Msg = "请求状态码为空"
                                };
                                return refundOrderResult;
                            }
                            if (xmlNode.InnerText == "SUCCESS")
                            {
                                XmlNode resultNode = xmlDocument.SelectSingleNode("xml/result_code");
                                if (resultNode.InnerText == "SUCCESS")
                                {
                                    XmlNode refundIdNode = xmlDocument.SelectSingleNode("xml/refund_id");
                                    RefundOrderResult refundOrderResult = new RefundOrderResult
                                    {
                                        Result = true,
                                        TradeNo = refundIdNode.InnerText
                                    };
                                    return refundOrderResult;
                                }
                                else
                                {
                                    XmlNode errDescNode = xmlDocument.SelectSingleNode("xml/err_code_des");
                                    RefundOrderResult refundOrderResult = new RefundOrderResult
                                    {
                                        Result = false,
                                        Msg = errDescNode.InnerText
                                    };
                                    return refundOrderResult;
                                }
                            }
                            else
                            {
                                XmlNode xmlNode3 = xmlDocument.SelectSingleNode("xml/return_msg");
                                RefundOrderResult refundOrderResult = new RefundOrderResult
                                {
                                    Result = false,
                                    Msg = xmlNode3.InnerText
                                };
                                if (refundOrderResult.Msg == "订单不存在")
                                {
                                    refundOrderResult.Msg = "该订单非微信支付订单";
                                }
                                return refundOrderResult;
                            }
                        }
                        catch (Exception ex)
                        {
                            text = string.Format("获取信息错误：{0}", ex.Message) + text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                text = string.Format("获取信息错误：{0}", ex.Message) + text;
            }
            RefundOrderResult result = new RefundOrderResult
            {
                Result = false,
                Msg = text
            };
            return result;
        }
        /// <summary>
        /// 微信退款回调
        /// </summary>
        /// <returns></returns>
        public async Task WechatRefundNotifyAsync()
        {

        }

    }
}

