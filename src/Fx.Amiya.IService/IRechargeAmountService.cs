using Fx.Amiya.Dto.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IRechargeAmountService
    {
        Task<List<RechargeAmountDto>> GetRechargeAmountListAsync();
        Task AddRechargeAmount(AddRechargeAmountDto addRechargeAmountDto);
        /// <summary>
        /// 根据id获取充值金额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RechargeAmountDto> GetRechargeAmountAsync(string id);
    }
}
