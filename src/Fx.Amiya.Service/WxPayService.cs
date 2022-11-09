using Fx.Amiya.Dto.OrderAppInfo;
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

        public WxPayService(IDalOrderRefund dalOrderRefund)
        {
            this.dalOrderRefund = dalOrderRefund;
        }

        /// <summary>
        /// 微信退款发起
        /// </summary>
        /// <param name="refundOrderId"></param>
        /// <returns></returns>
        public async Task<string> WechatRefundAsync(string refundOrderId)
        {
            var refundOrder = dalOrderRefund.GetAll().Where(e => e.Id == refundOrderId).SingleOrDefault();
            if (refundOrder == null) { throw new Exception("退款编号错误"); }

            WxRefundPackageInfo packageInfo = new WxRefundPackageInfo();
            packageInfo.NotifyUrl = string.Format("{0}/amiya/wxmini/Notify/orderpayresult", "http://ymjxui.gnway.cc");
            packageInfo.OutTradeNo = refundOrder.TradeId;
            packageInfo.OutRefundNo = refundOrder.Id;
            packageInfo.TotalFee = (int)(refundOrder.ActualPayAmount * 100m);
            packageInfo.RefundFee = (int)(refundOrder.RefundAmount * 100m);
            packageInfo.RefundDesc = "商品退款";
            /*if (packageInfo.TotalFee < 1m)
            {
                packageInfo.TotalFee = 1m;
            }*/
            return await this.BuildRefundRequest(packageInfo);
        }


        private async Task<string> BuildRefundRequest(WxRefundPackageInfo packageInfo)
        {

            packageInfo.NonceStr = Guid.NewGuid().ToString("N");
            PayDictionary payDictionary = new PayDictionary();
            payDictionary.Add("appid", packageInfo.AppId);
            payDictionary.Add("mch_id", packageInfo.MchId);
            payDictionary.Add("nonce_str", packageInfo.NonceStr);
            /*payDictionary.Add("sign", Guid.NewGuid().ToString("N"));*/
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
            string sign = await signHelper.SignPackage(payDictionary, packageInfo.MchId);
            var result = await this.PostRefundRequest(payDictionary, sign);
            return result;
        }
        private async Task<string> PostRefundRequest(PayDictionary dict, string sign)
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
        private string PostRefundData(string url, string postData)
        {
            string text = string.Empty;
            string result = string.Empty;
            try
            {
                Uri requestUri = new Uri(url);
                HttpWebRequest httpWebRequest;
                if (url.ToLower().StartsWith("https"))
                {
                    
                    ServicePointManager.ServerCertificateValidationCallback = ((object s, X509Certificate c, X509Chain ch, SslPolicyErrors e) => true);
                    httpWebRequest = (HttpWebRequest)WebRequest.CreateDefault(requestUri);
                }
                else
                {
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
                }
                Encoding uTF = Encoding.UTF8;
                byte[] bytes = uTF.GetBytes(postData);
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                //httpWebRequest.ClientCertificates.Add();
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
                            text = string.Format("获取信息错误doc.load：{0}", ex.Message) + text;
                        }
                        try
                        {
                            if (xmlDocument == null)
                            {
                                result = "false";
                                return result;
                            }
                            XmlNode xmlNode = xmlDocument.SelectSingleNode("xml/return_code");
                            if (xmlNode == null)
                            {
                                result = "";
                                return result;
                            }
                            if (xmlNode.InnerText == "SUCCESS")
                            {
                                result = "success";
                                return result;
                            }
                            else
                            {
                                XmlNode xmlNode3 = xmlDocument.SelectSingleNode("xml/return_msg");
                                if (xmlNode3 != null)
                                {
                                    result = xmlNode3.InnerText;
                                    return result;
                                }
                                result = xmlDocument.InnerXml;
                                return result;
                            }
                        }
                        catch (Exception ex)
                        {
                            text = string.Format("获取信息错误node.load：{0}", ex.Message) + text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                text = string.Format("获取信息错误post error：{0}", ex.Message) + text;
            }
            result = text;
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

