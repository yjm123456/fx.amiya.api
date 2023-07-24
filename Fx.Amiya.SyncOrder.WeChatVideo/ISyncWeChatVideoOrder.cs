using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeChatVideo
{
    public interface ISyncWeChatVideoOrder
    {
        /// <summary>
        /// 同步发生改变的订单
        /// </summary>
        /// <returns></returns>
        Task<List<WechatVideoOrder>> TranslateTradesSoldChangedOrders(DateTime startDate, DateTime endDate, int belongLiveAnchorId);
        /// <summary>
        /// 根据订单id获取订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<WechatVideoOrder> GetOrderInfoByIdAsync(string orderId, string token,int? belongLiveAnchorId);
        
    }
}
