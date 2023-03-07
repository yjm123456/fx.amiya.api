using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    public class PayRequestInfoDto
    {
		/// <summary>
		/// 微信appId
		/// </summary>
		public string appId
		{
			get;
			set;
		}
		/// <summary>
		/// 订单详情扩展字符串
		/// </summary>
		public string package
		{
			get;
			set;
		}
		/// <summary>
		/// 时间戳
		/// </summary>
		public string timeStamp
		{
			get;
			set;
		}
		/// <summary>
		/// 随机字符串
		/// </summary>
		public string nonceStr
		{
			get;
			set;
		}
		/// <summary>
		/// 签名
		/// </summary>
		public string paySign
		{
			get;
			set;
		}
		/// <summary>
		/// 签名方式
		/// </summary>
		public string signType
		{
			get
			{
				return "MD5";
			}
		}
	}
}
