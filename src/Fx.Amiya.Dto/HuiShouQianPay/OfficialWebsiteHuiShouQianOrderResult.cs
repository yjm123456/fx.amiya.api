using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    public class OfficialWebsiteHuiShouQianOrderResult
    {
        public bool Success { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }
        /// <summary>
        /// 支付链接
        /// </summary>
        public string PayUrl { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string TransNo { get; set; }
    }
}
