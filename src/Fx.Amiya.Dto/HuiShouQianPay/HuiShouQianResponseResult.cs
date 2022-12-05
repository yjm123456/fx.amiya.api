using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    public class HuiShouQianCommonResponseResult
    {
        //服务端响应状态，如果为true，则可以调用result；如果为false，则调用errorCode来获取出错信息
        public string success { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string errorCode { get; set; }
        /// <summary>
        /// 错误描述	
        /// </summary>
        public string errorMsg { get; set; }
        /// <summary>
        /// 响应内容	
        /// </summary>
        public HuiShouQianResponseResult result { get; set; }
        /// <summary>
        /// 签名数据	
        /// </summary>
        public string sign { get; set; }
    }
    public class HuiShouQianResponseResult {
        /// <summary>
        /// 原样返回商户订单号	
        /// </summary>
        public string transNo { get; set; }
        /// <summary>
        /// 慧收钱交易订单号
        /// </summary>
        public string tradeNo { get; set; }
        /// <summary>
        /// 订单交易金额
        /// </summary>
        public string orderAmt { get; set; }
        /// <summary>
        /// 交易状态	
        /// </summary>
        public string orderStatus { get; set; }
        
        /// <summary>
        /// 错误码	
        /// </summary>
        public string respCode { get; set; }
        /// <summary>
        /// 错误信息	
        /// </summary>
        public string respMsg { get; set; }
        public string extend { get; set; }
        public string payType { get; set; }
        /// <summary>
        /// 返回唤醒支付的参数
        /// </summary>
        public WechatPayParam qrCode { get; set; }
        /// <summary>
        /// 慧收钱上送三方支付的交易订单号
        /// </summary>
        public string channelOrderNo { get; set; }
    }
    public class WechatPayParam {
        public string appId { get; set; }
        public string timeStamp { get; set; }
        public string nonceStr { get; set; }
        public string package { get; set; }
        public string signType { get; set; }
        public string paySign { get; set; }
    }
}
