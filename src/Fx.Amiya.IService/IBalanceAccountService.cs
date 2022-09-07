using Fx.Amiya.Dto.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IBalanceAccountService
    {
        /// <summary>
        /// 获取用户余额账号
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<BalanceAccountDto> GetAccountInfoAsync(string customerId);
        /// <summary>
        /// 创建新的余额账号
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<BalanceAccountDto> CreateBalanceAccountAsync(string customerId);
        /// <summary>
        /// 根据用户id更新账户余额
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        
        Task UpdateAccountBalanceAsync(string customerId);
        
        

    }
}
