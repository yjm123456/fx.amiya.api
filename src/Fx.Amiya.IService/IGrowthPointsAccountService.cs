using Fx.Amiya.Dto.GrowthPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGrowthPointsAccountService
    {
        /// <summary>
        /// 根据customerid获取成长值账号
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<GrowthPointsAccountDto> GetGrowthPointAccountByCustomerId(string customerId);
        /// <summary>
        /// 新建成长值账号
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        Task<GrowthPointsAccountDto> AddAsync(CreateGrowthPointsAccountDto create);
        /// <summary>
        /// 修改成长值
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateGrowthPointsAccountDto update);
    }
}
