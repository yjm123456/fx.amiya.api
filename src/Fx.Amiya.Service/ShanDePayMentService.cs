using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.Dto.OrderRefund;
using Fx.Amiya.Dto.ShanDePay;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Fx.Open.Infrastructure.Web.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ShanDePayMentService : IShanDePayMentService
    {
        private readonly IDalWechatPayInfo dalWechatPayInfo;
        private readonly IDalOrderRefund dalOrderRefund;
        private readonly IOperationLogService operationLogService;
        public ShanDePayMentService(IDalWechatPayInfo dalWechatPayInfo, IDalOrderRefund dalOrderRefund, IOperationLogService operationLogService)
        {
            this.dalWechatPayInfo = dalWechatPayInfo;
            this.dalOrderRefund = dalOrderRefund;
            this.operationLogService = operationLogService;
        }

        /// <summary>
        /// 杉德支付下单
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public async Task<ShanDeOrderResult> OrderAsync(ShanDeOrderInfo orderInfo)
        {
            var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202307072015").FirstOrDefault();
            if (payInfo == null) throw new Exception("没有该支付方式配置信息！");
            //公共请求参数
            ShanDePayCommonParam commonParam = new ShanDePayCommonParam();
            commonParam.app_id = payInfo.AppId;
            commonParam.timestamp = orderInfo.CreateDate.ToString("yyyy-MM-dd HH:mm:ss");
            Random r = new Random();
            commonParam.nonce = r.Next(1000000, 9999999).ToString();
            //业务请求参数
            BizContent bizContent = new BizContent();
            bizContent.create_ip = "47.114.37.45";
            bizContent.create_time = orderInfo.CreateDate.ToString("yyyyMMddHHmmss");
            bizContent.mer_app_id = orderInfo.AppId;
            bizContent.buyer_id = orderInfo.OpenId;
            bizContent.mer_buyer_id = orderInfo.OpenId;
            bizContent.total_amount = orderInfo.TotalFee;
            bizContent.out_order_no = Guid.NewGuid().ToString().Replace("-", "");
            bizContent.store_id = payInfo.StoreId;
            bizContent.req_reserved = orderInfo.TradeId;
            var requestParam = await BuildParamAsync(commonParam, bizContent,payInfo.PrivateKey);
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>(requestParam);
            var result=await PostDataAsync(commonParam.ServerUrl,JsonConvert.SerializeObject(sortedDictionary));
            result.TransNo = bizContent.out_order_no;
            return result;
        }

        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Obsolete]
        public async Task<RefundOrderResult> CreateRefundOrderAsync(string id)
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

            //var success = dalOrderRefund.GetAll().Where(e => e.TradeId == order.TradeId && e.RefundState == (int)RefundState.RefundSuccess).ToList();
            //if (success.Count > 0)
            //{
            //    throw new Exception("订单已退款,请勿重复请求");
            //}
            //if (order.RefundState == (byte)RefundState.RefundSuccess) throw new Exception("订单已退款,请勿重复请求");

            var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202307072015").FirstOrDefault();
            if (payInfo == null) throw new Exception("没有该支付方式配置信息！");
            //公共请求参数
            ShanDePayCommonParam commonParam = new ShanDePayCommonParam();
            commonParam.method = "trade.refund";
            commonParam.app_id = payInfo.AppId;
            commonParam.timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Random r = new Random();
            commonParam.nonce = r.Next(1000000, 9999999).ToString();
            //业务请求参数
            RefundBizContent bizContent = new RefundBizContent();
            bizContent.out_order_no = order.TransNo;
            bizContent.refund_amount = order.RefundAmount;
            bizContent.refund_request_no = Guid.NewGuid().ToString().Replace("-", "");
            var requestParam = await BuildRefundParamAsync(commonParam, bizContent, payInfo.PrivateKey);
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>(requestParam);
            var result = PostRefundData(commonParam.ServerUrl, JsonConvert.SerializeObject(sortedDictionary));
            result.TardeId = order.TradeId;
            return result;
        }

        private async Task<Dictionary<string, string>> BuildParamAsync(ShanDePayCommonParam commonParam, BizContent bizContent,string privateKey) {
            Dictionary<string, string> paramsTemp = new Dictionary<string, string>();
            paramsTemp.Add("app_id", commonParam.app_id);
            paramsTemp.Add("biz_content", JsonConvert.SerializeObject(bizContent));
            paramsTemp.Add("charset", commonParam.charset);
            paramsTemp.Add("format", commonParam.format);
            paramsTemp.Add("method", commonParam.method);
            paramsTemp.Add("nonce", commonParam.nonce);
            paramsTemp.Add("sign_type", commonParam.sign_type);
            paramsTemp.Add("timestamp", commonParam.timestamp);
            paramsTemp.Add("version", commonParam.version);
            SignHelper signHelper = new SignHelper();
            var signContent = await signHelper.BuildQueryAsync(paramsTemp, false);
            var sign= RSAFromPkcs8Helper.Sign(signContent, privateKey, "UTF-8");
            paramsTemp.Add("sign", sign);
            return paramsTemp;
        }
        private async Task<Dictionary<string, string>> BuildRefundParamAsync(ShanDePayCommonParam commonParam, RefundBizContent bizContent, string privateKey)
        {
            Dictionary<string, string> paramsTemp = new Dictionary<string, string>();
            paramsTemp.Add("app_id", commonParam.app_id);
            paramsTemp.Add("biz_content", JsonConvert.SerializeObject(bizContent));
            paramsTemp.Add("charset", commonParam.charset);
            paramsTemp.Add("format", commonParam.format);
            paramsTemp.Add("method", commonParam.method);
            paramsTemp.Add("nonce", commonParam.nonce);
            paramsTemp.Add("sign_type", commonParam.sign_type);
            paramsTemp.Add("timestamp", commonParam.timestamp);
            paramsTemp.Add("version", commonParam.version);
            SignHelper signHelper = new SignHelper();
            var signContent = await signHelper.BuildQueryAsync(paramsTemp, false);
            var sign = RSAFromPkcs8Helper.Sign(signContent, privateKey, "UTF-8");
            paramsTemp.Add("sign", sign);
            return paramsTemp;
        }
        [Obsolete]
        internal async Task<ShanDeOrderResult> PostDataAsync(string url, string postData)
        {
            OperationAddDto operationAddDto = new OperationAddDto(); 
            string text = string.Empty;
            Uri requestUri = new Uri(url, false);
            HttpWebRequest httpWebRequest;
            httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            Encoding uTF = Encoding.UTF8;
            byte[] bytes = uTF.GetBytes(postData);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json;charset=UTF-8";
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
                    var response = JsonConvert.DeserializeObject<ShanDePayCommonResponseDto>(text,new JsonSerializerSettings { 
                        NullValueHandling= NullValueHandling.Ignore,
                        ReferenceLoopHandling=ReferenceLoopHandling.Serialize
                    });
                    ShanDeOrderResult shanDeOrderResult = new ShanDeOrderResult();
                    if (response.code != "200") {

                        //调用失败记录日志
                        operationAddDto.Parameters = postData;
                        operationAddDto.Code = -1;
                        operationAddDto.RouteAddress = "杉德支付下单请求";
                        operationAddDto.RequestType = (int)RequestType.Select;
                        operationAddDto.Message = text;
                        operationAddDto.OperationBy = null;
                        operationAddDto.Source = (int)RequestSource.AmiyaBackground;
                        await operationLogService.AddOperationLogAsync(operationAddDto);

                        shanDeOrderResult.Success = false;
                        shanDeOrderResult.ErrorMsg = response.msg;
                        return shanDeOrderResult;
                    }
                    var payData = response.data.Replace("\\","").Replace("\"{\"","{\"").Replace("\"}\"","\"}");
                    var payInfo = JsonConvert.DeserializeObject<BusinessResponseDto>(payData);                    
                    if (payInfo.sub_code == "SUCCESS")
                    {
                        shanDeOrderResult.Success = true;
                        ShanDePayParam shanDePayParam = new ShanDePayParam();
                        shanDePayParam.AppId = payInfo.pay_data.appId;
                        shanDePayParam.TimeStamp = payInfo.pay_data.timeStamp;
                        shanDePayParam.NonceStr = payInfo.pay_data.nonceStr;
                        shanDePayParam.Package = payInfo.pay_data.package;
                        shanDePayParam.SignType = payInfo.pay_data.signType;
                        shanDePayParam.PaySign = payInfo.pay_data.paySign;
                        shanDeOrderResult.PayParam = shanDePayParam;                      
                    }
                    else
                    {
                        shanDeOrderResult.Success = false;
                        shanDeOrderResult.ErrorMsg = payInfo.sub_msg;

                        //调用失败记录日志
                        operationAddDto.Parameters = postData;
                        operationAddDto.Code = -1;
                        operationAddDto.RouteAddress = "杉德支付下单请求";
                        operationAddDto.RequestType = (int)RequestType.Select;
                        operationAddDto.Message = response.data;
                        operationAddDto.OperationBy = null;
                        operationAddDto.Source = (int)RequestSource.AmiyaBackground;
                        await operationLogService.AddOperationLogAsync(operationAddDto);
                    }
                    return shanDeOrderResult;
                }
            }
            /*result = text;
            return result;*/
        }
        [Obsolete]
        internal RefundOrderResult PostRefundData(string url, string postData)
        {
            string text = string.Empty;
            Uri requestUri = new Uri(url, false);
            HttpWebRequest httpWebRequest;
            httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            Encoding uTF = Encoding.UTF8;
            byte[] bytes = uTF.GetBytes(postData);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json;charset=UTF-8";
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
                    var response = JsonConvert.DeserializeObject<ShanDePayCommonResponseDto>(text, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    });
                    RefundOrderResult refundResult = new RefundOrderResult();
                    if (response.code != "200")
                    {
                        refundResult.Result = false;
                        refundResult.Msg = response.msg;
                        return refundResult;
                    }
                    var responseData = response.data.Replace("\\", "").Replace("\"{\"", "{\"").Replace("\"}\"", "\"}");
                    var refundInfo = JsonConvert.DeserializeObject<RefundBusinessResponseDto>(responseData);
                    if (refundInfo.sub_code == "REFUND_SUCCESS")
                    {
                        refundResult.Result = true;
                        refundResult.Msg = "退款成功";
                        refundResult.TradeNo = refundInfo.refund_request_no;
                    }
                    else
                    {
                        refundResult.Result = false;
                        refundResult.Msg = refundInfo.sub_msg;
                    }
                    return refundResult;
                }
            }
        }

    }
}
