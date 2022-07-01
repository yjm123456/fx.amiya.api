using Fx.Amiya.Dto;
using Fx.Amiya.IService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fx.Amiya.Service
{
    /// <summary>
    /// 支付宝相关接口
    /// </summary>
    public class AliPayService : IAliPayService
    {
        private ILogger<AliPayService> logger;
        public AliPayService(
          ILogger<AliPayService> logger)
        {
            this.logger = logger;
        }
        //支付宝网关地址（新）
        private static string GATEWAY_NEW = "https://mapi.alipay.com/gateway.do?";
        //支付宝消息验证地址
        private string Https_veryfy_url = "https://mapi.alipay.com/gateway.do?service=notify_verify&";
        //商户的私钥
        private static string _key = "9hyegjtuaak0mbrhrmpw68wu5n4to0mu";
        //编码格式
        private static string _input_charset = "utf-8";
        //签名方式
        private static string _sign_type = "MD5";
        public async Task<string> BuildRequest(SortedDictionary<string, string> input)
        {
            //待请求参数数组
            SortedDictionary<string, string> dicPara = new SortedDictionary<string, string>();
            dicPara = BuildRequestPara(input);
            var result = GATEWAY_NEW;
            var x = CreateLinkStringUrlencode(dicPara, Encoding.UTF8);
            //StringBuilder sbHtml = new StringBuilder();
            //string strMethod = "get";
            //sbHtml.Append("<form id='alipaysubmit' name='alipaysubmit' action='" + GATEWAY_NEW + "_input_charset=" + _input_charset + "' method='" + strMethod.ToLower().Trim() + "'>");

            //foreach (KeyValuePair<string, string> temp in dicPara)
            //{
            //    sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
            //}

            ////submit按钮控件请不要含有name属性
            //sbHtml.Append("<input type='submit' value='" + strMethod + "' style='display:none;'></form>");

            //sbHtml.Append("<script>document.forms['alipaysubmit'].submit();</script>");
            return result+x;
            //return sbHtml.ToString();
        }

        /// <summary>
        ///  验证消息是否是支付宝发出的合法消息
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <param name="notify_id">通知验证ID</param>
        /// <param name="sign">支付宝生成的签名结果</param>
        /// <returns>验证结果</returns>
        public async Task<bool> Verify(SortedDictionary<string, string> inputparam, string notify_id, string sign)
        {
            //获取返回时的签名验证结果
            bool isSign = GetSignVeryfy(inputparam, sign);
            //获取是否是支付宝服务器发来的请求的验证结果
            string responseTxt = "false";
            if (notify_id != null && notify_id != "") { responseTxt = GetResponseTxt(notify_id); }

            //写日志记录（若要调试，请取消下面两行注释）
            string sWord = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 回调详情：responseTxt=" + responseTxt + "\n isSign=" + isSign.ToString() + "\n 返回回来的参数：" + GetPreSignStr(inputparam) + "\n "; logger.LogInformation(sWord);

            //判断responsetTxt是否为true，isSign是否为true
            //responsetTxt的结果不是true，与服务器设置问题、合作身份者ID、notify_id一分钟失效有关
            //isSign不是true，与安全校验码、请求时的参数格式（如：带自定义参数等）、编码格式有关
            if (responseTxt == "true" && isSign)//验证成功
            {
                return true;
            }
            else//验证失败
            {
                return false;
            }
        }

        /// <summary>
        /// 获取待签名字符串（调试用）
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <returns>待签名字符串</returns>
        private string GetPreSignStr(SortedDictionary<string, string> inputPara)
        {
            SortedDictionary<string, string> sPara = new SortedDictionary<string, string>();

            //过滤空值、sign与sign_type参数
            sPara = FilterPara(inputPara);

            //获取待签名字符串
            string preSignStr = CreateLinkString(sPara);

            return preSignStr;
        }


        /// <summary>
        /// 生成要请求给支付宝的参数数组
        /// </summary>
        /// <param name="sParaTemp">请求前的参数数组</param>
        /// <returns>要请求的参数数组</returns>
        private static SortedDictionary<string, string> BuildRequestPara(SortedDictionary<string, string> sParaTemp)
        {
            //待签名请求参数数组
            SortedDictionary<string, string> sPara = new SortedDictionary<string, string>();
            //签名结果
            string mysign = "";

            //过滤签名参数数组
            sPara = FilterPara(sParaTemp);

            //获得签名结果
            mysign = BuildRequestMysign(sPara);

            //签名结果与签名方式加入请求提交参数组中
            sPara.Add("sign", mysign);
            sPara.Add("sign_type", _sign_type);

            return sPara;
        }
        /// <summary>
        /// 生成请求时的签名
        /// </summary>
        /// <param name="sPara">请求给支付宝的参数数组</param>
        /// <returns>签名结果</returns>
        private static string BuildRequestMysign(SortedDictionary<string, string> sPara)
        {
            //把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
            string prestr = CreateLinkString(sPara);

            //把最终的字符串签名，获得签名结果
            string mysign = "";
            switch (_sign_type)
            {
                case "MD5":
                    mysign = Sign(prestr, _key, _input_charset);
                    break;
                default:
                    mysign = "";
                    break;
            }

            return mysign;
        }
        /// <summary>
        /// 签名字符串
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>签名结果</returns>
        private static string Sign(string prestr, string key, string _input_charset)
        {
            StringBuilder sb = new StringBuilder(32);

            prestr = prestr + key;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }

            return sb.ToString();
        }
        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
        /// </summary>
        /// <param name="sArray">需要拼接的数组</param>
        /// <returns>拼接完成以后的字符串</returns>
        private static string CreateLinkString(SortedDictionary<string, string> dicArray)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }
        /// <summary>
        /// 除去数组中的空值和签名参数并以字母a到z的顺序排序
        /// </summary>
        /// <param name="dicArrayPre">过滤前的参数组</param>
        /// <returns>过滤后的参数组</returns>
        private static SortedDictionary<string, string> FilterPara(SortedDictionary<string, string> dicArrayPre)
        {
            SortedDictionary<string, string> dicArray = new SortedDictionary<string, string>();
            foreach (KeyValuePair<string, string> temp in dicArrayPre)
            {
                if (temp.Key.ToLower() != "sign" && temp.Key.ToLower() != "sign_type" && temp.Value != "" && temp.Value != null)
                {
                    dicArray.Add(temp.Key, temp.Value);
                }
            }

            return dicArray;
        }

        /// <summary>
        /// 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串，并对参数值做urlencode
        /// </summary>
        /// <param name="sArray">需要拼接的数组</param>
        /// <param name="code">字符编码</param>
        /// <returns>拼接完成以后的字符串</returns>
        private static string CreateLinkStringUrlencode(SortedDictionary<string, string> dicArray, Encoding code)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + HttpUtility.UrlEncode(temp.Value, code) + "&");
            }

            //去掉最後一個&字符
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }
        
        /// <summary>
        /// 获取是否是支付宝服务器发来的请求的验证结果
        /// </summary>
        /// <param name="notify_id">通知验证ID</param>
        /// <returns>验证结果</returns>
        private string GetResponseTxt(string notify_id)
        {
            string veryfy_url = Https_veryfy_url + "partner=" + AliPayConfig.partner + "&notify_id=" + notify_id;

            //获取远程服务器ATN结果，验证是否是支付宝服务器发来的请求
            string responseTxt = Get_Http(veryfy_url, 120000);

            return responseTxt;
        }
        /// <summary>
        /// 获取远程服务器ATN结果
        /// </summary>
        /// <param name="strUrl">指定URL路径地址</param>
        /// <param name="timeout">超时时间设置</param>
        /// <returns>服务器ATN结果</returns>
        private string Get_Http(string strUrl, int timeout)
        {
            string strResult;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {
                strResult = "错误：" + exp.Message;
            }

            return strResult;
        }
        /// <summary>
        /// 获取返回时的签名验证结果
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <param name="sign">对比的签名结果</param>
        /// <returns>签名验证结果</returns>
        private bool GetSignVeryfy(SortedDictionary<string, string> inputPara, string sign)
        {
            SortedDictionary<string, string> sPara = new SortedDictionary<string, string>();

            //过滤空值、sign与sign_type参数
            sPara = FilterPara(inputPara);

            //获取待签名字符串
            string preSignStr = CreateLinkString(sPara);
            //获得签名验证结果
            bool isSgin = false;
            if (sign != null && sign != "")
            {
                switch (_sign_type)
                {
                    case "MD5":
                        isSgin = Verify(preSignStr, sign, _key, _input_charset);
                        break;
                    default:
                        break;
                }
            }

            return isSgin;
        }
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="sign">签名结果</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>验证结果</returns>
        public static bool Verify(string prestr, string sign, string key, string _input_charset)
        {
            string mysign = Sign(prestr, key, _input_charset);
            if (mysign == sign)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
