using Fx.Amiya.Dto;
using Fx.Amiya.Dto.SupplierBrand.Input;
using Fx.Amiya.Dto.SupplierBrand.Output;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ISupplierBrandService
    {
        Task<FxPageInfo<SupplierBrandDto>> GetListWithPageAsync(QuerySupplierBrandDto query);
        Task AddAsync(SupplierBrandAddDto addDto);
        Task<SupplierBrandDto> GetByIdAsync(string id);
        Task UpdateAsync(SupplierBrandUpdateDto updateDto);
        Task DeleteAsync(string id);
        /// <summary>
        /// 获取所有有效品牌
        /// </summary>
        /// <returns></returns>

        Task<List<BaseKeyValueDto>> GetSupplierBrandListAsync();
    }
}
