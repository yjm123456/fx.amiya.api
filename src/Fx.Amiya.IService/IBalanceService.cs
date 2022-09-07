using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IBalanceService
    {
        /// <summary>
        /// 余额支付
        /// </summary>
        /// <param name="customerid">用户id</param>
        /// <param name="orderid">订单id</param>
        /// <param name="amount">支付金额</param>
        /// <returns></returns>
        Task BalancePayAsync(string customerid, string orderid, decimal amount);
    }
}
