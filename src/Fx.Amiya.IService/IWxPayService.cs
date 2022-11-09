using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IWxPayService
    {
        /// <summary>
        /// 微信退款发起
        /// </summary>
        /// <param name="refundOrderId"></param>
        /// <returns></returns>
        Task WechatRefundAsync(string refundOrderId);
        /// <summary>
        /// 微信退款回调
        /// </summary>
        /// <returns></returns>
        Task WechatRefundNotifyAsync();
    }
}
