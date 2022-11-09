using Fx.Amiya.Dto.OrderRefund;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IOrderRefundService
    {
        /// <summary>
        /// 创建退款订单
        /// </summary>
        /// <returns></returns>
        Task<CreateRefundOrderResult> CreateRefundOrder(CreateRefundOrderDto createRefundOrderDto);
        /// <summary>
        /// 退款发起后更新退款订单状态
        /// </summary>
        /// <returns></returns>
        Task UpdateStartRefundState(RefundStartUpdateDto refundUpdateDto);
        /// <summary>
        /// 退款回调后更新退款订单状态
        /// </summary>
        /// <param name="refundAfterUpdateDto"></param>
        /// <returns></returns>
        Task UpdateAfterRefundState(RefundAfterUpdateDto refundAfterUpdateDto);
        
    }
}
