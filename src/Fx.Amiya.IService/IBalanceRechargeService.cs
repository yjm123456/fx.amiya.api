using Fx.Amiya.Dto.Balance;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IBalanceRechargeService
    {
        /// <summary>
        /// 分页获取充值记录
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="customerid"></param>
        /// <param name="status">充值订单状态</param>
        /// <returns></returns>
        Task<FxPageInfo<BalanceRechargeRecordDto>> GetBalanceRechargeRecordListAsync(int pageNum,int pageSize,string customerid,int? status);
        /// <summary>
        /// 添加充值记录
        /// </summary>
        /// <param name="rechargeRecordDto"></param>
        /// <returns></returns>
        Task<string> AddRechargeRecordAsync(CreateBalanceRechargeRecordDto rechargeRecordDto);
        /// <summary>
        /// 根据记录id获取充值记录
        /// </summary>
        /// <returns></returns>
        Task<BalanceRechargeRecordDto> GetRechargeRecordByIdAsync(string recorId);
        /// <summary>
        /// 更新充值记录状态
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        Task UpdateRechargeRecordStatusAsync(UpdateRechargeRecordStatusDto update);
        /// <summary>
        /// 获取用户处于正在处理中的充值记录
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        Task<BalanceRechargeRecordDto> GetRechargeRecordingAsync(string customerid);
        /// <summary>
        /// 根据充值记录id和用户id获取充值记录
        /// </summary>
        /// <param name="customerid">客户id</param>
        /// <param name="recordid">充值记录id</param>
        /// <returns></returns>
        Task<BalanceRechargeRecordDto> GetRechargeRecordByRecordIdAndCustomerIdAsync(string customerid,string recordid);
        /// <summary>
        /// 取消超时未支付的充值订单
        /// </summary>
        /// <returns></returns>
        Task CancelUnPayREchargeOrderAsync();
        /// <summary>
        /// 获取用户充值总金额(不包含退款记录)
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<decimal> GetAllRechargeAmountAsync(string customerId);
        /// <summary>
        /// 获取所有记录获得储值总金额(充值+退款)
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<decimal> GetAllAmountAsync(string customerId);
        /// <summary>
        /// 获取指定支付类型的储值记录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<List<BalanceRechargeRecordDto>> GetRechargeRecordByExchangeTypeAsync(string customerId, int exchangeType);
    }
}
