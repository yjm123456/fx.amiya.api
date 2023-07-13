using Fx.Amiya.Dto.OrderRefund;
using Fx.Amiya.Dto.ShanDePay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IShanDePayMentService
    {
        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        Task<ShanDeOrderResult> OrderAsync(ShanDeOrderInfo orderInfo);
        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RefundOrderResult> CreateRefundOrderAsync(string id);
    }
}
