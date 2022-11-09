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
        
    }
}
