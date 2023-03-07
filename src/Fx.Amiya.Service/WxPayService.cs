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
        public WxPayService(IDalOrderRefund dalOrderRefund, IHuiShouQianPaymentService huiShouQianPaymentService, IOrderService orderService)
        {
            this.dalOrderRefund = dalOrderRefund;
            this.huiShouQianPaymentService = huiShouQianPaymentService;
            this.orderService = orderService;
        }

        /// <summary>
        /// 微信退款发起
        /// </summary>
        /// <param name="refundOrderId"></param>
        /// <returns></returns>
        public async Task<RefundOrderResult> WechatRefundAsync(string refundOrderId)
        {
            var refundOrder = dalOrderRefund.GetAll().Where(e => e.Id == refundOrderId).SingleOrDefault();

            //慧收钱退款
            if (refundOrder.ExchangeType== (int)ExchangeType.HuiShouQian) {
              return  await huiShouQianPaymentService.CreateHuiShouQianRefundOrde(refundOrderId);
            }
            if (refundOrder.ExchangeType==(int)ExchangeType.PointAndMoney) {
                var refunResult= await huiShouQianPaymentService.CreateHuiShouQianAndPointRefundOrder(refundOrderId);
                //退还积分
                await orderService.CancelPointAndMoneyOrderWithNoTransactionAsync(refundOrder.TradeId, refundOrder.CustomerId);
                return refunResult;
            }

            if (refundOrder == null) { throw new Exception("退款编号错误"); }
            if (refundOrder.CheckState != (int)CheckState.CheckSuccess) throw new Exception("只有审核通过的订单才能退款");
            var success = dalOrderRefund.GetAll().Where(e => e.TradeId == refundOrder.TradeId && e.RefundState == (int)RefundState.RefundSuccess).ToList();
            if (success.Count>0) {
                throw new Exception("订单已退款,请勿重复请求");
            }
            if (refundOrder.RefundState == (byte)RefundState.RefundSuccess) throw new Exception("订单已退款,请勿重复请求");
            WxRefundPackageInfo packageInfo = new WxRefundPackageInfo();
            packageInfo.NotifyUrl = "https://app.ameiyes.com/amiyamini";
            //packageInfo.NotifyUrl = "http://ymjxui.gnway.cc";
            packageInfo.OutTradeNo = refundOrder.TradeId;
            packageInfo.OutRefundNo = refundOrder.Id;
            packageInfo.TotalFee = (int)(refundOrder.ActualPayAmount * 100m);
            packageInfo.RefundFee = (int)(refundOrder.RefundAmount * 100m);
            packageInfo.RefundDesc = "商品退款";
            var result=await this.BuildRefundRequest(packageInfo);
            result.TardeId = refundOrder.TradeId;
            return result;
        }


        private async Task<RefundOrderResult> BuildRefundRequest(WxRefundPackageInfo packageInfo)
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
            return await this.PostRefundRequest(payDictionary, sign);
        }
        private async Task<RefundOrderResult> PostRefundRequest(PayDictionary dict, string sign)
        {
            dict.Add("sign", sign);
            SignHelper signHelper = new SignHelper();
            string text = await signHelper.BuildQueryAsync(dict, false);
            string postData = await signHelper.BuildXmlAsync(dict, false);
            string refundUrl = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            return this.PostRefundData(refundUrl, postData);
        }
        /// <summary>
        /// 微信支付帮助方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        private RefundOrderResult PostRefundData(string url, string postData)
        {
            string text = string.Empty;           
            try
            {
                Uri requestUri = new Uri(url);
                HttpWebRequest httpWebRequest;                
                if (url.ToLower().StartsWith("https"))
                {
                    //string path = "C:\\wechatsecret\\" + "apiclientrefund78345hsdfcert.p12";
                    //证书文件地址
                    string path = AppDomain.CurrentDomain.BaseDirectory + "apiclientrefund78345hsdfcert.p12";
                    ServicePointManager.ServerCertificateValidationCallback = ((object s, X509Certificate c, X509Chain ch, SslPolicyErrors e) => true);
                    //加载证书
                    X509Certificate2 cer = new X509Certificate2(path, "1632393371");                
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
                                RefundOrderResult refundOrderResult = new RefundOrderResult {
                                    Result=false,
                                    Msg="返回数据为空"
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
                                        TradeNo= refundIdNode.InnerText
                                    };
                                    return refundOrderResult;
                                }
                                else {
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
                                if (refundOrderResult.Msg== "订单不存在") {
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

