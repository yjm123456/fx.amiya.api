using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.TikTokUserInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Jd.Api.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fx.Amiya.Service
{
    public class TikTokUserInfoService : ITikTokUserInfoService
    {
        private readonly IDalTikTokUserInfo dalTikTokUserInfo;
        private IOrderAppInfoService orderAppInfoService;
        private readonly IDalCustomerBaseInfo dalCustomerBaseInfo;
        private readonly IDalTikTokOrderInfo dalTikTokOrderInfo;
        private readonly IIntegrationAccount integrationAccountService;
        private readonly ICustomerService customerService;
        private readonly IMemberCard memberCardService;
        private readonly IMemberRankInfo memberRankInfoService;

        public TikTokUserInfoService(IDalTikTokUserInfo dalTikTokUserInfo, IOrderAppInfoService orderAppInfoService, IDalCustomerBaseInfo dalCustomerBaseInfo, IDalTikTokOrderInfo dalTikTokOrderInfo, IIntegrationAccount integrationAccountService, ICustomerService customerService, IMemberCard memberCardService, IMemberRankInfo memberRankInfo)
        {
            this.dalTikTokUserInfo = dalTikTokUserInfo;
            this.orderAppInfoService = orderAppInfoService;
            this.dalCustomerBaseInfo = dalCustomerBaseInfo;
            this.dalTikTokOrderInfo = dalTikTokOrderInfo;
            this.integrationAccountService = integrationAccountService;
            this.customerService = customerService;
            this.memberCardService = memberCardService;
            this.memberRankInfoService = memberRankInfo;
        }

        public async Task AddAsync(AddTikTokUserDto addTikTokUserDto)
        {
            try
            {
                TikTokUserInfo tikTokUserInfo = new TikTokUserInfo();
                tikTokUserInfo.CipherName = addTikTokUserDto.CipherName;
                tikTokUserInfo.CipherPhone = addTikTokUserDto.CipherPhone;
                tikTokUserInfo.Id = addTikTokUserDto.Id;
                await dalTikTokUserInfo.AddAsync(tikTokUserInfo, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TikTokUserDto> DecryptUserInfoAsync(string userinfoid, string orderid)
        {
            var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            var host = "https://openapi-fxg.jinritemai.com";

            var tikTokAppInfo = await orderAppInfoService.GetTikTokAppInfo();

            var tikTokUserInfo = dalTikTokUserInfo.GetAll().SingleOrDefault(e => e.Id == userinfoid);
            //调用解密接口对加密数据解密
            var decryptParam = new Dictionary<string, List<object>> {
                {"cipher_infos",new List<object>{ new { auth_id=orderid, cipher_text =tikTokUserInfo.CipherName },new { auth_id = orderid, cipher_text = tikTokUserInfo.CipherPhone } } }
            };

            var decryptParamJson = Marshal(decryptParam);

            //计算签名
            var decryptSignVal = Sign(tikTokAppInfo.AppKey, tikTokAppInfo.AppSecret, "order.batchDecrypt", timestamp, decryptParamJson);
            Console.WriteLine("decrypt_sign_val:" + decryptSignVal);

            //请求路径
            var decryptRes = Fetch(tikTokAppInfo.AppKey, host, "order.batchDecrypt", timestamp, decryptParamJson, tikTokAppInfo.AccessToken, decryptSignVal);
            var decrypt = JsonConvert.DeserializeObject<dynamic>(decryptRes);
            TikTokUserDto tikTokUserDto = new TikTokUserDto();
            CustomerBaseInfo customerBaseInfo = new CustomerBaseInfo();
            if (decrypt.data.custom_err.err_code == 0)
            {
                foreach (var item in decrypt.data.decrypt_infos)
                {
                    if (item.cipher_text == tikTokUserInfo.CipherName)
                    {
                        tikTokUserDto.Name = item.decrypt_text;
                        tikTokUserInfo.Name = item.decrypt_text;
                        customerBaseInfo.Name = item.decrypt_text;
                    }
                    else
                    {
                        tikTokUserDto.Phone = item.decrypt_text;
                        tikTokUserInfo.Phone = item.decrypt_text;
                        customerBaseInfo.Phone = item.decrypt_text;
                    }

                }
                if (string.IsNullOrEmpty(tikTokUserDto.Phone)) {
                    return null;
                }
                //解密后将解密信息更新到tiktokuserinfo表中
                await dalTikTokUserInfo.UpdateAsync(tikTokUserInfo, true);
                //将解密信息更新到tiktok订单表中
                var tiktokOrder = dalTikTokOrderInfo.GetAll().SingleOrDefault(o => o.Id == orderid);
                if (tiktokOrder != null)
                {
                    tiktokOrder.Phone = tikTokUserDto.Phone;
                    tiktokOrder.BuyerNick = tikTokUserDto.Name;
                    await dalTikTokOrderInfo.UpdateAsync(tiktokOrder, true);
                }
                //将信息添加到customerbaseinfo表中
                var customBaseInfo = dalCustomerBaseInfo.GetAll().FirstOrDefault(c => c.Phone == customerBaseInfo.Phone);
                if (customBaseInfo == null)
                {
                    await dalCustomerBaseInfo.AddAsync(customerBaseInfo, true);
                }              
            }
            return tikTokUserDto;
        }


        public async Task<TikTokUserDto> DecryptUserInfoByOrderIdAsync(string orderid, string cipherName, string cipherPhone)
        {
            var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            var host = "https://openapi-fxg.jinritemai.com";

            var tikTokAppInfo = await orderAppInfoService.GetTikTokAppInfo();
            //调用解密接口对加密数据解密
            var decryptParam = new Dictionary<string, List<object>> {
                {"cipher_infos",new List<object>{ new { auth_id=orderid, cipher_text=cipherName },new { auth_id = orderid, cipher_text =cipherPhone } } }
            };

            var decryptParamJson = Marshal(decryptParam);

            //计算签名
            var decryptSignVal = Sign(tikTokAppInfo.AppKey, tikTokAppInfo.AppSecret, "order.batchDecrypt", timestamp, decryptParamJson);

            //请求路径
            var decryptRes = Fetch(tikTokAppInfo.AppKey, host, "order.batchDecrypt", timestamp, decryptParamJson, tikTokAppInfo.AccessToken, decryptSignVal);
            var decrypt = JsonConvert.DeserializeObject<dynamic>(decryptRes);
            TikTokUserDto tikTokUserDto = new TikTokUserDto();
            TikTokUserInfo tikTokUserInfo = new TikTokUserInfo();
            CustomerBaseInfo customerBaseInfo = new CustomerBaseInfo();
            if (decrypt.data.custom_err.err_code == 0)
            {
                foreach (var item in decrypt.data.decrypt_infos)
                {
                    string cipherText = item.cipher_text;
                    string decrypttext = item.decrypt_text;
                    if (cipherText == cipherName)
                    {
                        tikTokUserDto.Name = decrypttext;
                    }
                    else
                    {
                        tikTokUserDto.Phone = decrypttext;
                    }
                }
                tikTokUserDto.CipherName = cipherName;
                tikTokUserDto.CipherPhone = cipherPhone;
                if (string.IsNullOrEmpty(tikTokUserDto.Phone)) {
                    return null;
                }
                return tikTokUserDto;
            }
            else
            {
                return null;
            }
        }

        public TikTokUserDto getTikTokUserInfoByCipherPhone(string cipherphone)
        {
            var userInfo = dalTikTokUserInfo.GetAll().SingleOrDefault(u => u.CipherPhone == cipherphone);
            if (userInfo == null)
            {
                return null;
            }
            TikTokUserDto tikTokUserDto = new TikTokUserDto();
            tikTokUserDto.Id = userInfo.Id;
            tikTokUserDto.Name = userInfo.Name;
            tikTokUserDto.Phone = userInfo.Phone;
            tikTokUserDto.CipherName = userInfo.CipherName;
            tikTokUserDto.CipherPhone = userInfo.CipherPhone;
            return tikTokUserDto;
        }
        public string Fetch(string appKey, string host, string method, long timestamp, string paramJson,
    string accessToken, string sign)
        {
            var methodPath = method.Replace('.', '/');
            var u = host + "/" + methodPath +
                    "?method=" + HttpUtility.UrlEncode(method, Encoding.UTF8) +
                    "&app_key=" + HttpUtility.UrlEncode(appKey, Encoding.UTF8) +
                    "&access_token=" + HttpUtility.UrlEncode(accessToken, Encoding.UTF8) +
                    "&timestamp=" + HttpUtility.UrlEncode(timestamp.ToString(), Encoding.UTF8) +
                    "&v=" + HttpUtility.UrlEncode("2", Encoding.UTF8) +
                    "&sign=" + HttpUtility.UrlEncode(sign, Encoding.UTF8) +
                    "&sign_method=" + HttpUtility.UrlEncode("hmac-sha256", Encoding.UTF8);
            var header = new Dictionary<string, string>();
            header.Add("Content-Type", "application/json;charset=UTF-8");
            header.Add("Accept", "*/*");
            var res = HttpUtil.CommonHttpRequest(paramJson, u, "POST");
            return res;

        }
        // 序列化参数
        private string Marshal(object o)
        {
            var raw = JsonConvert.SerializeObject(o);
            // 反序列化为JObject
            var dict = JsonConvert.DeserializeObject(raw);

            // 重新序列化
            var settings = new JsonSerializerSettings();
            settings.Converters = new List<JsonConverter> { new JObjectConverter(), new JValueConverter() };
            return JsonConvert.SerializeObject(dict, Formatting.None, settings);
        }

        /// <summary>
        /// 获取请求url
        /// </summary>
        /// <param name="path">拼接请求地址</param>
        /// <returns></returns>
        private string GetRequestUrl(string path)
        {
            string url = "https://openapi-fxg.jinritemai.com";
            if (!string.IsNullOrEmpty(path))
            {
                url += path;
            }
            return url;
        }
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="method">方法描述</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="paramJson">请求参数</param>
        /// <returns></returns>
        private string Sign(string appKey, string appSecret, string method, long timestamp, string paramJson)
        {
            // 按给定规则拼接参数
            var paramPattern = "app_key" + appKey + "method" + method + "param_json" + paramJson + "timestamp" +
                               timestamp + "v2";
            var signPattern = appSecret + paramPattern + appSecret;
            Console.WriteLine("sign_pattern:" + signPattern);

            return HmacHelper.Hmac(signPattern, appSecret);
        }
    }
}
