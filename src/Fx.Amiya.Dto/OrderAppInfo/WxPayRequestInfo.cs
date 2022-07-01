using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderAppInfo
{
	public class WxPayRequestInfo
	{
		public string appId
		{
			get;
			set;
		}

		public string package
		{
			get;
			set;
		}

		public string timeStamp
		{
			get;
			set;
		}

		public string nonceStr
		{
			get;
			set;
		}

		public string paySign
		{
			get;
			set;
		}

		public string signType
		{
			get
			{
				return "MD5";
			}
		}
	}
}
