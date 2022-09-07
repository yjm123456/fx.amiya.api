using Fx.Amiya.MiniProgram.Api.Vo.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Balance
{
    /// <summary>
    /// 充值返回类
    /// </summary>
    public class RechargeResultVo
    {
        /// <summary>
        /// 交易编号
        /// </summary>
        public string TradeId { get; set; }
        /// <summary>
        /// 拉起微信支付参数
        /// </summary>
        public PayRequestInfoVo PayRequestInfo { get; set; }
        /// <summary>
        /// 支付宝跳转页面
        /// </summary>
        public string AlipayUrl { get; set; }
    }
}
