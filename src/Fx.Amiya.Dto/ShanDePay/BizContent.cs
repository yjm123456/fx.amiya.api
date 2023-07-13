using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ShanDePay
{
    /// <summary>
    /// 请求业务参数
    /// </summary>
    public class BizContent
    {
        public string body { get; set; } = "商品支付";
        /// <summary>
        /// 微信用户openid
        /// </summary>
        public string buyer_id { get; set; }
        public string create_ip { get; set; }
        /// <summary>
        /// 订单创建时间 order
        /// </summary>
        public string create_time { get; set; }
        
        /// <summary>
        /// 小程序appid
        /// </summary>
        public string mer_app_id { get; set; }
        /// <summary>
        /// 微信用户openid
        /// </summary>
        public string mer_buyer_id { get; set; }
        //public string notify_url { get; set; } = "https://www.amyk.cn/amiya/wxmini/notify/shanDePayResultNotify";

        public string notify_url { get; set; } = "https://app.ameiyes.com/amiyamini/amiya/wxmini/Notify/shanDePayResultNotify";
        /// <summary>
        /// 商户订单号不可重复
        /// </summary>
        public string out_order_no { get; set; }
        public string pay_type { get; set; } = "JSAPI";
        public string pay_way { get; set; } = "WECHAT";
        /// <summary>
        /// 自定义字段,用于存储tradeid
        /// </summary>
        public string req_reserved { get; set; }
        /// <summary>
        /// 门店号
        /// </summary>
        public string store_id { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal total_amount { get; set; }
       
        
        /*/// <summary>
        /// 特殊参数 json格式
        /// </summary>
        public string extend_params { get; set; }*/
    }
}
