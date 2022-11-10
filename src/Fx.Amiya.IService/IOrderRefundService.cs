using Fx.Amiya.Dto.CustomerHospitalConsume;
using Fx.Amiya.Dto.OrderRefund;
using Fx.Common;
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
        Task<CreateRefundOrderResult> CreateRefundOrderAsync(CreateRefundOrderDto createRefundOrderDto);
        /// <summary>
        /// 退款发起后更新退款订单状态
        /// </summary>
        /// <returns></returns>
        Task UpdateStartRefundStateAsync(RefundStartUpdateDto refundUpdateDto);
        /// <summary>
        /// 退款回调后更新退款订单状态
        /// </summary>
        /// <param name="refundAfterUpdateDto"></param>
        /// <returns></returns>
        Task UpdateAfterRefundStateAsync(RefundAfterUpdateDto refundAfterUpdateDto);
        /// <summary>
        /// 获取退款订单列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="checkState"></param>
        /// <param name="refundState"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderRefundDto>> GetListAsync(string keywords,byte? checkState,byte? refundState,int pageNum,int pageSize);
        /// <summary>
        /// 退款订单审核
        /// </summary>
        /// <param name="orderRefundCheckDto"></param>
        /// <returns></returns>
        Task CheckAsync(OrderRefundCheckDto orderRefundCheckDto);
        /// <summary>
        /// 获取审核状态列表
        /// </summary>
        /// <returns></returns>
        List<CheckStateTypeDto> GetCheckStateType();
        /// <summary>
        /// 获取退款状态列表
        /// </summary>
        /// <returns></returns>
        List<CheckStateTypeDto> GetRefundStateType();

    }
}
