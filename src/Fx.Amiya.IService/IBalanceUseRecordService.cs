using Fx.Amiya.Dto.Balance;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IBalanceUseRecordService
    {
        /// <summary>
        /// 获取余额消费总额
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        Task<decimal> GetTotalUseAmountAsync(string customerid);
        /// <summary>
        /// 分页获取余额消费记录
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="customerid"></param>
        /// <returns></returns>
        Task<FxPageInfo<BalanceUseRecordInfoDto>> GetBalanceUseRecordListAsync(int pageNum,int pageSize,string customerid);
        /// <summary>
        /// 添加余额消费记录
        /// </summary>
        /// <param name="addBalanceUse"></param>
        /// <returns></returns>
        Task AddBalanceUseRecordAsync(AddBalanceUseRecordDto addBalanceUse);
    }
}
