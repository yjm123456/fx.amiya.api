using Fx.Amiya.Dto;
using Fx.Amiya.Dto.HealthValue;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHealthValueService
    {
        Task<FxPageInfo<HealthValueDto>> GetListWithPageAsync(bool? valid, string keyWord,int pageSize,int pageNum);
        Task AddAsync(AddHealthValueDto addHealthValueDto);
        Task<HealthValueDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateHealthValueDto updateHealthValueDto);
        Task DeleteAsync(string id);
        /// <summary>
        /// 根据编码获取健康值
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<decimal> GetValueByCode(string code);

        Task<List<BaseKeyValueAndPercentDto>> GetValidListAsync();
    }
}
