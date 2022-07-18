using Fx.Amiya.DbModels.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.Core
{
    public interface ISyncTikTokOrder
    {
        /// <summary>
        /// 同步全部订单
        /// </summary>
        /// <returns></returns>
        Task<List<AmiyaOrder>> TranslateAllTradesSoldOrders(DateTime startDate,DateTime endDate);


        /// <summary>
        /// 同步发生改变的订单
        /// </summary>
        /// <returns></returns>
        Task<List<AmiyaOrder>> TranslateTradesSoldChangedOrders(DateTime startDate, DateTime endDate);



        /// <summary>
        /// 获取退款订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
         Task<List<RefundOrder>> GetRefundOrdersAsync(DateTime startDate, DateTime endDate);


        /// <summary>
        /// 获取订单消费码信息列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="codeStatus">码状态(-1：已退款，0：等待发码，1：未消费，2：已消费，3：已过期，101：退款锁定，103：过期锁定)</param>
        /// <returns></returns>
        Task<List<OrderLocCode>> GetOrderLocCodesAsync(DateTime startDate, DateTime endDate,int codeStatus);


    }
}
