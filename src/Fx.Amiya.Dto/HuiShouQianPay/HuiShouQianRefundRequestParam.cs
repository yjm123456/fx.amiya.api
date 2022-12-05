using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    /// <summary>
    /// 慧收钱退款请求参数
    /// </summary>
    public class HuiShouQianRefundRequestParam
    {
        /// <summary>
        /// 商户订单号	
        /// </summary>
        public string TransNo { get; set; }
        /// <summary>
        /// 退款类型	
        /// </summary>
        public string RefundType { get; set; }
        /// <summary>
        /// 原支付交易对应的商户订单号
        /// </summary>
        public string OrigTransNo { get; set; }
        /// <summary>
        /// 原支付交易的订单总金额(单位分)
        /// </summary>
        public string OrigOrderAmt { get; set; }
        /// <summary>
        /// 退款金额(单位分)
        /// </summary>
        public string OrderAmt { get; set; }
        /// <summary>
        /// 请求时间,与当前系统时间相差小于10分钟，格式[yyyyMMddHHmmss]	
        /// </summary>
        public string RequestDate { get; set; }
        /// <summary>
        /// 退款原因	
        /// </summary>
        public string RefundReason { get; set; }
        /// <summary>
        /// 后端通知地址	
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 附加字段	
        /// </summary>
        public string Extend { get; set; }
        public HuiShouQianRefundRequestParam() {
            RefundType = "1";
            ReturnUrl = "";
        }
    }
}
