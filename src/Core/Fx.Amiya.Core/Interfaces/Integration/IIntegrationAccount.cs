using Fx.Amiya.Core.Dto.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Interfaces.Integration
{
    /// <summary>
    /// 积分接口
    /// </summary>
    public interface IIntegrationAccount
    {
        /// <summary>
        /// 获取一个客户的积分余额
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<decimal> GetIntegrationBalanceByCustomerIDAsync(string customerId);

        /// <summary>
        /// 获取所有有积分的客户id
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetAllCustomerHasIntergration();

        /// <summary>
        /// 添加一条积分充值记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddIntegrationGenerateRecordAsync(IntegrationGenerateRecordAddDto item);


        /// <summary>
        /// 添加消费奖励积分
        /// </summary>
        /// <returns></returns>
        Task AddByConsumptionAsync(ConsumptionIntegrationDto consumptionIntegration);

        /// <summary>
        /// 积分商品退款返还积分
        /// </summary>
        /// <param name="consumptionIntegration"></param>
        /// <returns></returns>
        Task ReturnByConsumptionAsync(ConsumptionIntegrationDto consumptionIntegration);

        /// <summary>
        /// 根据日期获取积分充值记录
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<List<IntegrationGenerateRecordsDto>> GetIntegrationGenerateRecordsByDateAsync(DateTime startDate, DateTime endDate);


        /// <summary>
        /// 根据客户编号获取积分充值记录
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<List<IntegrationGenerateRecordsDto>> GetIntegrationGenerateRecordsByCustomerIDAsync(string customerID);

        /// <summary>
        /// 根据订单号获取是否有积分充值记录
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<bool> GetIsIntegrationGenerateRecordByOrderIdAsync(string orderId);




        /// <summary>
        /// 添加一条积分使用记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddIntegrationUseRecordAsync(IntegrationUseRecordAddDto item);

        /// <summary>
        /// 根据日期获取积分使用记录
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<List<IntegrationUseRecordDto>> GetIntegrationUseRecordsByDateAsync(DateTime startDate, DateTime endDate);


        /// <summary>
        /// 根据客户编号获取积分使用记录
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<List<IntegrationUseRecordDto>> GetIntegrationUseRecordsByCustomerIDAsync(string customerID);


        /// <summary>
        /// 根据客户编号数组获取积分账户列表
        /// </summary>
        /// <param name="customerIds"></param>
        /// <returns></returns>
       Task<List<IntegrationAccountDto>> GetIntegrationAccountListByCustomerIdsAsync(List<string> customerIds);


        /// <summary>
        /// 商品消费使用积分
        /// </summary>
        /// <param name="useIntegration"></param>
        /// <returns></returns>
        Task UseByGoodsConsumption(UseIntegrationDto useIntegration);

        /// <summary>
        /// 积分过期
        /// </summary>
        /// <param name="useIntegration"></param>
        /// <returns></returns>
        Task ExpiredGoodsConsumption();
    }
}
