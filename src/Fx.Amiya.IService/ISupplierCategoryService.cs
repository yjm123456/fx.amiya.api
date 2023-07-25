using Fx.Amiya.Dto;
using Fx.Amiya.Dto.SupplierCategory.Input;
using Fx.Amiya.Dto.SupplierCategory.OutPut;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ISupplierCategoryService
    {
        Task<FxPageInfo<SupplierCategoryDto>> GetListWithPageAsync(QuerySupplierCategoryDto query);
        Task AddAsync(SupplierCategoryAddDto addDto);
        Task<SupplierCategoryDto> GetByIdAsync(string id);
        Task UpdateAsync(SupplierCategoryUpdateDto updateDto);
        Task DeleteAsync(string id);

        Task<List<BaseKeyValueDto>> GetValidByBrandIdAsync(string warehouseId);

    }
}
