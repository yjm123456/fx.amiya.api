using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ShanDePay
{
    /// <summary>
    /// 杉德公共请求参数
    /// </summary>
    public class ShanDePayCommonParam
    {
        /// <summary>
        /// 河马付网关接口地址
        /// </summary>
        public string ServerUrl { get; set; } = "https://hmpay.sandpay.com.cn/gateway/api";
        /// <summary>
        /// 代理商应用ID/商户应用ID
        /// </summary>
        public string app_id { get; set; }
        public string method { get; set; } = "trade.create";
        /// <summary>
        /// 接口版本号
        /// </summary>
        public string version = "1.0";
        /// <summary>
        /// 业务参数请求格式
        /// </summary>
        public string format = "JSON";
        /// <summary>
        /// 签名类型
        /// </summary>
        public string sign_type = "RSA";
        /// <summary>
        /// 字符编码
        /// </summary>
        public string charset = "UTF-8";
        /// <summary>
        /// 时间戳 格式 yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce { get; set; }
        /// <summary>
        /// 业务参数
        /// </summary>
        public string biz_content { get; set; }
        
    }
}
