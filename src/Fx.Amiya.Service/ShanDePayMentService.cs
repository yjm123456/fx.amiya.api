using Fx.Amiya.Dto.ShanDePay;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Open.Infrastructure.Web.Utils;
using Newtonsoft.Json;
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

        public ShanDePayMentService(IDalWechatPayInfo dalWechatPayInfo)
        {
            this.dalWechatPayInfo = dalWechatPayInfo;
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
            //bizContent.extend_params = JsonConvert.SerializeObject(new  { TradeId = orderInfo.TradeId });
            var requestParam = await BuildParamAsync(commonParam, bizContent,payInfo.PrivateKey);
            var text= PostData(commonParam.ServerUrl,JsonConvert.SerializeObject(requestParam));
            return null;
        }
        private async Task<Dictionary<string, string>> BuildParamAsync(ShanDePayCommonParam commonParam, BizContent bizContent,string privateKey) {
            Dictionary<string, string> paramsTemp = new Dictionary<string, string>();
            paramsTemp.Add("app_id", commonParam.app_id);
            paramsTemp.Add("biz_content", JsonConvert.SerializeObject(bizContent));
            paramsTemp.Add("charset", commonParam.charset);
            paramsTemp.Add("format", commonParam.format);
            paramsTemp.Add("method", commonParam.method);
            paramsTemp.Add("nonce", commonParam.nonce);
            SignHelper signHelper = new SignHelper();
            var signContent = await signHelper.BuildQueryAsync(paramsTemp, false);
            RSAHelper rsa = new RSAHelper(RSAType.RSA2, Encoding.UTF8, privateKey, "");
            byte[] data = Encoding.UTF8.GetBytes(rsa.Sign(signContent));
            var sign = Convert.ToBase64String(data);
            paramsTemp.Add("sign", sign);
            paramsTemp.Add("sign_type", commonParam.sign_type);
            paramsTemp.Add("timestamp", commonParam.timestamp);
            paramsTemp.Add("version", commonParam.version);          
            return paramsTemp;
        }
        internal ShanDeOrderResult PostData(string url, string postData)
        {
            string text = string.Empty;
            string result;
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
                    
                    return null;
                }
            }


            /*result = text;
            return result;*/
        }
    }
}
