using Fx.Amiya.Dto.HuiShouQianPay;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Jd.Api.Util;
using jos_sdk_net.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HuiShouQianPaymentService : IHuiShouQianPaymentService
    {
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
            if (huiShouQianCommonInfo.SignContent==null)
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
            if (string.IsNullOrEmpty(huiShouQianPayRequestInfo.TransNo)|| huiShouQianPayRequestInfo.TransNo.Length>64) {
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
        public async Task<HuiShouQianOrderResult> CreateHuiShouQianOrder(HuiShouQianPayRequestInfo huiShouQianPayRequestInfo)
        {
            HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
            var commonParam= BuildCommonParam(huiShouQianPayRequestInfo);
            return await PostOrderAsync(huiShouQianPackageInfo.OrderUrl, commonParam);           
        }
        /// <summary>
        /// 创建慧收钱退款订单
        /// </summary>
        /// <returns></returns>
        public async Task<HuiShouQianRefundResult> CreateHuiShouQianRefundOrde(HuiShouQianRefundRequestParam huiShouQianRefundRequestParam)
        {
            HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
            var commonParam = BuildRefundCommonParam(huiShouQianRefundRequestParam);
            return await PostRefundOrderAsync(huiShouQianPackageInfo.OrderUrl, commonParam);
        }
        /// <summary>
        /// 创建公共请求参数
        /// </summary>
        /// <returns></returns>
        private string BuildCommonParam(HuiShouQianPayRequestInfo huiShouQianPayRequestInfo) {           
            HuiShouQianCommonInfo huiShouQianCommonInfo = new HuiShouQianCommonInfo();                        
            huiShouQianCommonInfo.SignContent = huiShouQianPayRequestInfo;
            string signContent = JsonConvert.SerializeObject(huiShouQianPayRequestInfo);
            var signData = BuildPayParamString(huiShouQianCommonInfo.Method, huiShouQianCommonInfo.Version, huiShouQianCommonInfo.Format, huiShouQianCommonInfo.MerchantNo, huiShouQianCommonInfo.SignType,signContent,""); 
            var sign = RAS2EncriptUtil.Sign(signData, "");
            huiShouQianCommonInfo.Sign = sign;
            return JsonConvert.SerializeObject(huiShouQianCommonInfo);
        }
        /// <summary>
        /// 创建退款公共请求参数
        /// </summary>
        /// <returns></returns>
        private string BuildRefundCommonParam(HuiShouQianRefundRequestParam huiShouQianRefundRequestParam)
        {
            HuiShouQianRefundCommonParam huiShouQianCommonInfo = new HuiShouQianRefundCommonParam();
            huiShouQianCommonInfo.SignContent = huiShouQianRefundRequestParam;
            string signContent = JsonConvert.SerializeObject(huiShouQianRefundRequestParam);
            var signData = BuildPayParamString(huiShouQianCommonInfo.Method, huiShouQianCommonInfo.Version, huiShouQianCommonInfo.Format, huiShouQianCommonInfo.MerchantNo, huiShouQianCommonInfo.SignType, signContent, "");
            var sign = RAS2EncriptUtil.Sign(signData, "");
            huiShouQianCommonInfo.Sign = sign;
            return JsonConvert.SerializeObject(huiShouQianCommonInfo);
        }
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        private async Task<HuiShouQianOrderResult> PostOrderAsync(string url, string postData)
        {
            var response= await HttpUtil.HttpJsonPostAsync(url,postData);
            var result = JsonConvert.DeserializeObject<HuiShouQianCommonResponseResult>(response);
            if (result.success == "true") {
                string signContent = BuildPayResponseParamString(result,"");
                bool verifyResult= RAS2EncriptUtil.VerifySignature(signContent, result.sign,"");
                if (verifyResult) {                    
                    HuiShouQianOrderResult huiShouQianOrderResult = new HuiShouQianOrderResult();
                    huiShouQianOrderResult.Success = true;
                    var payParam = result.result.qrCode;
                    HuiShouQianPayParam huiShouQianPayParam = new HuiShouQianPayParam();
                    huiShouQianPayParam.AppId = payParam.appId;
                    huiShouQianPayParam.TimeStamp = payParam.timeStamp;
                    huiShouQianPayParam.NonceStr = payParam.nonceStr;
                    huiShouQianPayParam.Package = payParam.package;
                    huiShouQianPayParam.SignType = payParam.signType;
                    huiShouQianPayParam.PaySign = payParam.paySign;
                    huiShouQianOrderResult.PayParam = huiShouQianPayParam;
                    return huiShouQianOrderResult;
                } else {
                    HuiShouQianOrderResult huiShouQianOrderResult = new HuiShouQianOrderResult();
                    huiShouQianOrderResult.Success = false;
                    huiShouQianOrderResult.ErrorCode = result.errorCode;
                    huiShouQianOrderResult.ErrorMsg = "签名验证失败";
                    return huiShouQianOrderResult;
                }
            } else{
                HuiShouQianOrderResult huiShouQianOrderResult = new HuiShouQianOrderResult();
                huiShouQianOrderResult.Success = false;
                huiShouQianOrderResult.ErrorCode = result.errorCode;
                huiShouQianOrderResult.ErrorMsg = result.errorMsg;
                return huiShouQianOrderResult;
            }            
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        private async Task<HuiShouQianRefundResult> PostRefundOrderAsync(string url, string postData)
        {
            var response = await HttpUtil.HttpJsonPostAsync(url, postData);
            var result = JsonConvert.DeserializeObject<HuiShouQianRefundOrderResultCommonParam>(response);
            if (result.success == "true")
            {
                string signContent = BuildRefundResponseParamString(result, "");
                bool verifyResult = RAS2EncriptUtil.VerifySignature(signContent, result.sign, "");
                if (verifyResult)
                {
                    HuiShouQianRefundResult huiShouRefundrResult = new HuiShouQianRefundResult();
                    huiShouRefundrResult.Success = true;

                    var responseParam = result.result;
                    HuiShouqianRefundResponse huiShouqianRefundResponse = new HuiShouqianRefundResponse();
                    
                    return huiShouRefundrResult;
                }
                else
                {
                    HuiShouQianRefundResult huiShouQianOrderResult = new HuiShouQianRefundResult();
                    huiShouQianOrderResult.Success = false;
                    huiShouQianOrderResult.ErrorCode = result.errorCode;
                    huiShouQianOrderResult.ErrorMsg = "签名验证失败";
                    return huiShouQianOrderResult;
                }
            }
            else
            {
                HuiShouQianRefundResult huiShouQianOrderResult = new HuiShouQianRefundResult();
                huiShouQianOrderResult.Success = false;
                huiShouQianOrderResult.ErrorCode = result.errorCode;
                huiShouQianOrderResult.ErrorMsg = result.errorMsg;
                return huiShouQianOrderResult;
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
        /// 拼接下单返回参数
        /// </summary>
        /// <param name="huiShouQianCommon"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string BuildPayResponseParamString(HuiShouQianCommonResponseResult huiShouQianCommon, string key) {
            StringBuilder builder = new StringBuilder();
            if (huiShouQianCommon.success=="true")
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
    }
}
