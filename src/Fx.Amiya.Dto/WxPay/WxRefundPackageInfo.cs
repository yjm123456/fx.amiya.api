using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.WxPay
{
    public class WxRefundPackageInfo
    {
		/// <summary>
		/// 小程序id
		/// </summary>
        public string AppId { get; set; }
		/// <summary>
		/// 商户号
		/// </summary>
        public string MchId { get; set; }
		/// <summary>
		/// 随机字符串
		/// </summary>
        public string NonceStr { get; set; }
		/// <summary>
		/// 签名
		/// </summary>
        public string Sign { get; set; }
		/// <summary>
		/// 签名类型
		/// </summary>
        public string SignType { get; set; }
		/// <summary>
		/// 微信支付订单号
		/// </summary>
        public string TransactionId { get; set; }
		/// <summary>
		/// 商户订单号
		/// </summary>
        public string OutTradeNo { get; set; }
		/// <summary>
		/// 商户系统内部的退款单号 同一退款单号多次请求只退一笔
		/// </summary>
		public string OutRefundNo { get; set; }
		/// <summary>
		/// 订单金额
		/// </summary>
		public int TotalFee { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public int RefundFee { get; set; }
		/// <summary>
		/// 货币种类
		/// </summary>
        public string RefundFeeType { get;private set; }
		/// <summary>
		/// 退款原因
		/// </summary>
		public string RefundDesc { get; set; }
		/// <summary>
		/// 退款资金来源
		/// </summary>
		public string RefundAccount { get;private set; }
		/// <summary>
		/// 退款结果通知url
		/// </summary>
		public string NotifyUrl { get; set; }
        public WxRefundPackageInfo()
		{
			this.RefundFeeType = "CNY";
			//默认从未结算资金退款
			this.RefundAccount = "REFUND_SOURCE_UNSETTLED_FUNDS";
			this.AppId = "wx695942e4818de445";
			this.MchId = "1632393371";
			this.SignType = "MD5";
		}
	}
}
