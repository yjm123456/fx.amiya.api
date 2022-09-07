using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITaskService
    {
        /// <summary>
        /// 完成签到任务
        /// </summary>
        /// <returns></returns>
        Task CompleteSignTaskAsync(string customerid);
        /// <summary>
        /// 完成商城下单任务
        /// </summary>
        /// <param name="customerid">用户id</param>
        /// <param name="actualpay">实际支付金额</param>
        /// <param name="orderid">订单id</param>
        /// <returns></returns>
        Task CompleteShopOrderTaskAsync(string customerid,decimal actualpay, string orderid);
    }
}
