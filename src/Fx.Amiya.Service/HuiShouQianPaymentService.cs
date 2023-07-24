using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.HuiShouQianPay;
using Fx.Amiya.Dto.OrderRefund;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Fx.Open.Infrastructure.Web.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fx.Amiya.Service
{
    public class HuiShouQianPaymentService : IHuiShouQianPaymentService
    {
        private readonly IDalOrderRefund dalOrderRefund;
        private readonly IDalCustomerInfo dalCustomerInfo;
        private readonly IDalWechatPayInfo dalWechatPayInfo;

        public HuiShouQianPaymentService(IDalOrderRefund dalOrderRefund, IDalCustomerInfo dalCustomerInfo, IDalWechatPayInfo dalWechatPayInfo)
        {
            this.dalOrderRefund = dalOrderRefund;
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalWechatPayInfo = dalWechatPayInfo;
        }

        public bool CheckHSQCommonParams(HuiShouQianCommonInfo huiShouQianCommonInfo, out string errmsg)
        {
            bool result = true;
            errmsg = "";
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.Method) || huiShouQianCommonInfo.Method.Length > 32)
            {
                errmsg = "请求方法名错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.Version) || huiShouQianCommonInfo.Version.Length > 16)
            {

                errmsg = "版本号错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.Format) || huiShouQianCommonInfo.Format.Length > 16)
            {

                errmsg = "业务请求参数格式错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.MerchantNo) || huiShouQianCommonInfo.MerchantNo.Length > 16)
            {

                errmsg = "商户号错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianCommonInfo.SignType) || huiShouQianCommonInfo.SignType.Length > 16)
            {

                errmsg = "加密类型错误";
                return false;
            }
            if (huiShouQianCommonInfo.SignContent == null)
            {

                errmsg = "业务数据不能为空";
                return false;
            }
            return result;

        }

        public bool CheckHSQMemoParam(HuiShouQianMemoInfo huiShouQianMemoInfo, out string errmsg)
        {
            bool result = true;
            errmsg = "";
            return result;
        }

        public bool CheckHSQRequestParam(HuiShouQianPayRequestInfo huiShouQianPayRequestInfo, out string errmsg)
        {
            bool result = true;
            errmsg = "";
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.TransNo) || huiShouQianPayRequestInfo.TransNo.Length > 64)
            {
                errmsg = "订单号错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.PayType) || huiShouQianPayRequestInfo.PayType.Length > 32)
            {
                errmsg = "支付类型错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.OrderAmt) || huiShouQianPayRequestInfo.OrderAmt.Length > 16)
            {
                errmsg = "交易金额错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.GoodsInfo) || huiShouQianPayRequestInfo.GoodsInfo.Length > 128)
            {
                errmsg = "商品说明信息错误";
                return false;
            }
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.RequestDate) || huiShouQianPayRequestInfo.RequestDate.Length > 14)
            {
                DateTime date = new DateTime();
                errmsg = "商品说明信息错误";
                return false;
            }
            return result;
        }
        /// <summary>
        /// 创建慧收钱支付订单
        /// </summary>
        /// <returns></returns>
        public async Task<HuiShouQianOrderResult> CreateHuiShouQianOrder(HuiShouQianPayRequestInfo huiShouQianPayRequestInfo, string openId, string customerId)
        {
            HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
            var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202306281235").FirstOrDefault();           
            huiShouQianPackageInfo.PrivateKey = payInfo.PrivateKey;
            huiShouQianPackageInfo.PublicKey = payInfo.PublickKey;
            huiShouQianPackageInfo.Key = payInfo.PartnerKey;
            var commonParam = BuildCommonParam(huiShouQianPayRequestInfo, openId, customerId);
            return PostData(huiShouQianPackageInfo.OrderUrl + "?" + commonParam, "");

        }
        internal HuiShouQianOrderResult PostData(string url, string postData)
        {
            string text = string.Empty;
            string result;
            Uri requestUri = new Uri(url, false);
            HttpWebRequest httpWebRequest;
            httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            Encoding uTF = Encoding.UTF8;
            byte[] bytes = uTF.GetBytes(postData);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
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
                    text = text.Replace("\\\"{", "{");
                    text = text.TrimStart('\"');
                    text = text.TrimEnd('\"');
                    text = text.Replace("\\", "");
                    text = text.Replace("\"{", "{");
                    text = text.Replace("\"}\"", "\"}");
                    var response = JsonConvert.DeserializeObject<HuiShouQianCommonResponseResult>(text, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    if (response.success == "true" && response.result.orderStatus != "FAIL")
                    {
                        HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
                        var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202306281235").FirstOrDefault();                       
                        huiShouQianPackageInfo.Key = payInfo.PartnerKey;
                        huiShouQianPackageInfo.PrivateKey = payInfo.PrivateKey;
                        huiShouQianPackageInfo.PublicKey = payInfo.PublickKey;

                        string signContent = BuildPayResponseParamString(response, huiShouQianPackageInfo.Key);
                        HuiShouQianOrderResult huiShouQianOrderResult = new HuiShouQianOrderResult();
                        huiShouQianOrderResult.Success = true;
                        var payParam = response.result;
                        HuiShouQianPayParam huiShouQianPayParam = new HuiShouQianPayParam();
                        huiShouQianPayParam.AppId = payParam.qrCode.appId;
                        huiShouQianPayParam.TimeStamp = payParam.qrCode.timeStamp;
                        huiShouQianPayParam.NonceStr = payParam.qrCode.nonceStr;
                        huiShouQianPayParam.Package = payParam.qrCode.package;
                        huiShouQianPayParam.SignType = payParam.qrCode.signType;
                        huiShouQianPayParam.PaySign = payParam.qrCode.paySign;
                        huiShouQianOrderResult.PayParam = huiShouQianPayParam;
                        return huiShouQianOrderResult;

                    }
                    else
                    {
                        HuiShouQianOrderResult huiShouQianOrderResult = new HuiShouQianOrderResult();
                        huiShouQianOrderResult.Success = false;
                        huiShouQianOrderResult.ErrorCode = response.errorCode;
                        huiShouQianOrderResult.ErrorMsg = response.errorMsg;
                        return huiShouQianOrderResult;
                    }
                }
            }


            /*result = text;
            return result;*/
        }

        /// <summary>
        /// 创建慧收钱退款订单
        /// </summary>
        /// <returns></returns>
        public async Task<RefundOrderResult> CreateHuiShouQianRefundOrde(string id)
        {
            var order = dalOrderRefund.GetAll().Where(e => e.Id == id).SingleOrDefault();
            if (order == null) { throw new Exception("退款编号错误"); }
            if (order.CheckState != (int)CheckState.CheckSuccess) throw new Exception("只有审核通过的订单才能退款");
            var success = dalOrderRefund.GetAll().Where(e => e.TradeId == order.TradeId && e.RefundState == (int)RefundState.RefundSuccess).ToList();
            if (success.Count > 0)
            {
                throw new Exception("订单已退款,请勿重复请求");
            }
            if (order.RefundState == (byte)RefundState.RefundSuccess) throw new Exception("订单已退款,请勿重复请求");
            HuiShouQianRefundRequestParam huiShouQianRefundRequestParam = new HuiShouQianRefundRequestParam();
            huiShouQianRefundRequestParam.TransNo = Guid.NewGuid().ToString().Replace("-", "");
            huiShouQianRefundRequestParam.OrigTransNo = string.IsNullOrEmpty(order.TransNo) ? order.TradeId : order.TransNo;
            huiShouQianRefundRequestParam.OrigOrderAmt = (order.ActualPayAmount * 100m).ToString().Split(".")[0];
            huiShouQianRefundRequestParam.OrderAmt = (order.ActualPayAmount * 100m).ToString().Split(".")[0];
            huiShouQianRefundRequestParam.RequestDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            huiShouQianRefundRequestParam.RefundReason = "退款";
            huiShouQianRefundRequestParam.Extend = order.Id;
            HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
            var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202306281235").FirstOrDefault();          
            huiShouQianPackageInfo.Key = payInfo.PartnerKey;
            huiShouQianPackageInfo.PrivateKey = payInfo.PrivateKey;
            huiShouQianPackageInfo.PublicKey = payInfo.PublickKey;
            var commonParam = BuildRefundCommonParam(huiShouQianRefundRequestParam);
            var result = await PostRefundData(huiShouQianPackageInfo.RefundUrl + "?", commonParam);
            result.TardeId = order.TradeId;

            return result;
        }
        /// <summary>
        /// 创建公共请求参数
        /// </summary>
        /// <returns></returns>
        private string BuildCommonParam(HuiShouQianPayRequestInfo huiShouQianPayRequestInfo, string openId, string customerId)
        {
            var customerInfo = dalCustomerInfo.GetAll().Where(e => e.Id == customerId).SingleOrDefault();
            if (customerInfo == null) throw new Exception("用户编号错误！");
            HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
            var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202306281235").FirstOrDefault();            
            huiShouQianPackageInfo.Key = payInfo.PartnerKey;
            huiShouQianPackageInfo.PrivateKey = payInfo.PrivateKey;
            huiShouQianPackageInfo.PublicKey = payInfo.PublickKey;
            HuiShouQianCommonInfo huiShouQianCommonInfo = new HuiShouQianCommonInfo();
            huiShouQianCommonInfo.MerchantNo = payInfo.AppId;
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            HuiShouQianMemoInfo huiShouQianMemoInfo = new HuiShouQianMemoInfo();
            huiShouQianMemoInfo.SpbillCreateIp = payInfo.AppSecret;
            huiShouQianMemoInfo.openid = openId;
            huiShouQianMemoInfo.appid = customerInfo.AppId;
            string memoContent = JsonConvert.SerializeObject(huiShouQianMemoInfo, serializerSettings);
            huiShouQianPayRequestInfo.Memo = huiShouQianMemoInfo;
            string signContent = JsonConvert.SerializeObject(huiShouQianPayRequestInfo, serializerSettings);
            huiShouQianCommonInfo.SignContent = signContent;
            var signData = BuildPayParamString(huiShouQianCommonInfo.Method, huiShouQianCommonInfo.Version, huiShouQianCommonInfo.Format, huiShouQianCommonInfo.MerchantNo, huiShouQianCommonInfo.SignType, signContent, huiShouQianPackageInfo.Key);
            RSAHelper rsa = new RSAHelper(RSAType.RSA2, Encoding.UTF8, huiShouQianPackageInfo.PrivateKey, "");
            var sign = rsa.Sign(signData);
            huiShouQianCommonInfo.Sign = sign.ToLower();
            var length = sign.Length;
            var query = BuildQueryParamString(huiShouQianCommonInfo.Method, huiShouQianCommonInfo.Version, huiShouQianCommonInfo.Format, huiShouQianCommonInfo.MerchantNo, huiShouQianCommonInfo.SignType, signContent, sign);
            return query;
        }

        /// <summary>
        /// 创建退款公共请求参数
        /// </summary>
        /// <returns></returns>
        private string BuildRefundCommonParam(HuiShouQianRefundRequestParam huiShouQianRefundRequestParam)
        {
            HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
            var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202306281235").FirstOrDefault();          
            huiShouQianPackageInfo.Key = payInfo.PartnerKey;
            huiShouQianPackageInfo.PrivateKey = payInfo.PrivateKey;
            huiShouQianPackageInfo.PublicKey = payInfo.PublickKey;
            HuiShouQianRefundCommonParam huiShouQianCommonInfo = new HuiShouQianRefundCommonParam();
            huiShouQianCommonInfo.SignContent = huiShouQianRefundRequestParam;
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            string signContent = JsonConvert.SerializeObject(huiShouQianRefundRequestParam, serializerSettings);
            var signData = BuildPayParamString(huiShouQianCommonInfo.Method, huiShouQianCommonInfo.Version, huiShouQianCommonInfo.Format, huiShouQianCommonInfo.MerchantNo, huiShouQianCommonInfo.SignType, signContent, huiShouQianPackageInfo.Key);
            RSAHelper rsa = new RSAHelper(RSAType.RSA2, Encoding.UTF8, huiShouQianPackageInfo.PrivateKey, "");
            var sign = rsa.Sign(signData);
            huiShouQianCommonInfo.Sign = sign;
            return BuildRefundQueryParamString(huiShouQianCommonInfo.Method, huiShouQianCommonInfo.Version, huiShouQianCommonInfo.Format, huiShouQianCommonInfo.MerchantNo, huiShouQianCommonInfo.SignType, signContent, sign);
        }


        internal async Task<RefundOrderResult> PostRefundData(string url, string postData)
        {
            string text = string.Empty;
            string result;

            Uri requestUri = new Uri(url, false);
            HttpWebRequest httpWebRequest;

            httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);

            Encoding uTF = Encoding.UTF8;
            byte[] bytes = uTF.GetBytes(postData);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
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
                    text = text.Replace("\\\"{", "{");
                    text = text.TrimStart('\"');
                    text = text.TrimEnd('\"');
                    text = text.Replace("\\", "");
                    text = text.Replace("\"{", "{");
                    text = text.Replace("\"}\"", "\"}");
                    var response = JsonConvert.DeserializeObject<HuiShouQianRefundResult>(text, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    if (response.Success)
                    {
                        if (response.Result.OrderStatus == "FAIL")
                        {
                            RefundOrderResult refundOrderResult = new RefundOrderResult();
                            refundOrderResult.Result = false;
                            refundOrderResult.Msg = response.Result.RespMsg;
                            return refundOrderResult;
                        }
                        else
                        {
                            RefundOrderResult refundOrderResult = new RefundOrderResult();
                            refundOrderResult.Result = true;
                            refundOrderResult.TradeNo = response.Result.TradeNo;
                            return refundOrderResult;
                        }
                    }
                    else
                    {
                        RefundOrderResult refundOrderResult = new RefundOrderResult();
                        refundOrderResult.Result = false;
                        refundOrderResult.Msg = response.Result.RespMsg;
                        return refundOrderResult;
                    }
                }
            }
        }
        /// <summary>
        /// 拼接下单请求参数
        /// </summary>
        /// <param name="method"></param>
        /// <param name="version"></param>
        /// <param name="format"></param>
        /// <param name="merchantNo"></param>
        /// <param name="signType"></param>
        /// <param name="signContent"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string BuildPayParamString(string method, string version, string format, string merchantNo, string signType, string signContent, string key)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("method=");
            builder.Append(method);
            builder.Append("&version=");
            builder.Append(version);
            builder.Append("&format=");
            builder.Append(format);
            builder.Append("&merchantNo=");
            builder.Append(merchantNo);
            builder.Append("&signType=");
            builder.Append(signType);
            builder.Append("&signContent=");
            builder.Append(signContent);
            builder.Append("&key=");
            builder.Append(key);
            return builder.ToString();
        }
        /// <summary>
        /// 拼接下单请求参数
        /// </summary>
        /// <param name="method"></param>
        /// <param name="version"></param>
        /// <param name="format"></param>
        /// <param name="merchantNo"></param>
        /// <param name="signType"></param>
        /// <param name="signContent"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string BuildQueryParamString(string method, string version, string format, string merchantNo, string signType, string signContent, string key)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("method=");
            builder.Append(method);
            builder.Append("&version=");
            builder.Append(version);
            builder.Append("&format=");
            builder.Append(format);
            builder.Append("&merchantNo=");
            builder.Append(merchantNo);
            builder.Append("&signType=");
            builder.Append(signType);
            builder.Append("&signContent=");
            builder.Append(signContent);
            builder.Append("&sign=");
            builder.Append(key);
            return builder.ToString();
        }
        private string BuildRefundQueryParamString(string method, string version, string format, string merchantNo, string signType, string signContent, string key)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("method=");
            builder.Append(method);
            builder.Append("&version=");
            builder.Append(version);
            builder.Append("&format=");
            builder.Append(format);
            builder.Append("&merchantNo=");
            builder.Append(merchantNo);
            builder.Append("&signType=");
            builder.Append(signType);
            builder.Append("&signContent=");
            builder.Append(signContent);
            builder.Append("&sign=");
            builder.Append(key);
            return builder.ToString();
        }
        /// <summary>
        /// 拼接下单返回参数
        /// </summary>
        /// <param name="huiShouQianCommon"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string BuildPayResponseParamString(HuiShouQianCommonResponseResult huiShouQianCommon, string key)
        {
            StringBuilder builder = new StringBuilder();
            if (huiShouQianCommon.success == "true")
            {
                builder.Append("result=");
                builder.Append(JsonConvert.SerializeObject(huiShouQianCommon.result));
                builder.Append("&success=");
                builder.Append(huiShouQianCommon.success);
                builder.Append("&key=");
                builder.Append(key);
            }
            else
            {
                builder.Append("errorCode=");
                builder.Append(huiShouQianCommon.errorCode);
                builder.Append("&errorMsg=");
                builder.Append(huiShouQianCommon.errorMsg);
                builder.Append("&success=");
                builder.Append(huiShouQianCommon.success);
                builder.Append("&key=");
                builder.Append(key);
            }
            return builder.ToString();
        }
        /// <summary>
        /// 拼接下单返回参数
        /// </summary>
        /// <param name="huiShouQianCommon"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string BuildRefundResponseParamString(HuiShouQianRefundOrderResultCommonParam huiShouQianCommon, string key)
        {
            StringBuilder builder = new StringBuilder();
            if (huiShouQianCommon.success == "true")
            {
                builder.Append("result=");
                builder.Append(JsonConvert.SerializeObject(huiShouQianCommon.result));
                builder.Append("&success=");
                builder.Append(huiShouQianCommon.success);
                builder.Append("&key=");
                builder.Append(key);
            }
            else
            {
                builder.Append("errorCode=");
                builder.Append(huiShouQianCommon.errorCode);
                builder.Append("&errorMsg=");
                builder.Append(huiShouQianCommon.errorMsg);
                builder.Append("&success=");
                builder.Append(huiShouQianCommon.success);
                builder.Append("&key=");
                builder.Append(key);
            }
            return builder.ToString();
        }
        /// <summary>
        /// 创建积分加钱购退款订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RefundOrderResult> CreateHuiShouQianAndPointRefundOrder(string id)
        {
            var order = dalOrderRefund.GetAll().Where(e => e.Id == id).SingleOrDefault();
            if (order == null) { throw new Exception("退款编号错误"); }
            if (order.CheckState != (int)CheckState.CheckSuccess) throw new Exception("只有审核通过的订单才能退款");
            if (order.IsPartial)
            {
                var success = dalOrderRefund.GetAll().Where(e => e.TradeId == order.TradeId && e.OrderId == order.OrderId && e.RefundState == (int)RefundState.RefundSuccess).ToList();
                if (success.Count > 0)
                {
                    throw new Exception("订单已退款,请勿重复请求");
                }
                if (order.RefundState == (byte)RefundState.RefundSuccess) throw new Exception("订单已退款,请勿重复请求");
            }
            else
            {
                var success = dalOrderRefund.GetAll().Where(e => e.TradeId == order.TradeId && e.RefundState == (int)RefundState.RefundSuccess).ToList();
                if (success.Count > 0)
                {
                    throw new Exception("订单已退款,请勿重复请求");
                }
                if (order.RefundState == (byte)RefundState.RefundSuccess) throw new Exception("订单已退款,请勿重复请求");
            }



            HuiShouQianRefundRequestParam huiShouQianRefundRequestParam = new HuiShouQianRefundRequestParam();
            huiShouQianRefundRequestParam.TransNo = Guid.NewGuid().ToString().Replace("-", "");
            huiShouQianRefundRequestParam.OrigTransNo = string.IsNullOrEmpty(order.TransNo) ? order.TradeId : order.TransNo;
            huiShouQianRefundRequestParam.OrigOrderAmt = (order.ActualPayAmount * 100m).ToString().Split(".")[0];
            huiShouQianRefundRequestParam.OrderAmt = (order.RefundAmount * 100m).ToString().Split(".")[0];
            huiShouQianRefundRequestParam.RequestDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            huiShouQianRefundRequestParam.RefundReason = "退款";
            huiShouQianRefundRequestParam.Extend = order.Id;
            HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
            var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202306281235").FirstOrDefault();           
            huiShouQianPackageInfo.Key = payInfo.PartnerKey;
            huiShouQianPackageInfo.PrivateKey = payInfo.PrivateKey;
            huiShouQianPackageInfo.PublicKey = payInfo.PublickKey;
            var commonParam = BuildRefundCommonParam(huiShouQianRefundRequestParam);
            var result = await PostRefundData(huiShouQianPackageInfo.RefundUrl + "?", commonParam);
            result.TardeId = order.TradeId;
            return result;
        }
    }
}
