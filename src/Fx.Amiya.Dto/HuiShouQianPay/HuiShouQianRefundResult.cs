using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    /// <summary>
    /// 慧收钱退款订单请求结果
    /// </summary>
    public class HuiShouQianRefundResult
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
        /// 业务响应参数
        /// </summary>
        public HuiShouqianRefundResponse Result { get; set; }
    }
}
