using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    /// <summary>
    /// 慧收钱创建退款订单响应内容
    /// </summary>
    public class HuiShouQianRefundOrderResultCommonParam
    {
        /// <summary>
        /// 服务端响应状态，如果为true，则可以调用result；如果为false，则调用errorCode来获取出错信息
        /// </summary>
        public string success { get; set; }
        /// <summary>
        /// 响应码
        /// </summary>
        public string errorCode { get; set; }
        /// <summary>
        /// 响应描述
        /// </summary>
        public string errorMsg { get; set; }
        /// <summary>
        /// 业务响应参数
        /// </summary>
        public HuiShouQianRefundParam result { get; set; }
        /// <summary>
        /// 响应验签数据
        /// </summary>
        public string sign { get; set; }
    }
    public class HuiShouQianRefundParam {
        /// <summary>
        /// 商户号
        /// </summary>
        public string merchantNo { get; set; }
        /// <summary>
        /// 商户订单号	
        /// </summary>
        public string transNo { get; set; }
        /// <summary>
        /// 交易订单号	
        /// </summary>
        public string tradeNo { get; set; }
        /// <summary>
        /// 退款金额	
        /// </summary>
        public string orderAmt { get; set; }
        /// <summary>
        /// 退款状态	
        /// </summary>
        public string orderStatus { get; set; }
        /// <summary>
        /// 完成时间	
        /// </summary>
        public string finishedDate { get; set; }
        /// <summary>
        /// 响应码	
        /// </summary>
        public string respCode { get; set; }
        /// <summary>
        /// 响应描述	
        /// </summary>
        public string respMsg { get; set; }
    }
}
