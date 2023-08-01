using Fx.Amiya.Dto;
using Fx.Amiya.Dto.SupplierItemDetails.Input;
using Fx.Amiya.Dto.SupplierItemDetails.OutPut;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ISupplierItemDetailsService
    {
        Task<FxPageInfo<SupplierItemDetailsDto>> GetListWithPageAsync(QuerySupplierItemDetailsDto query);
        Task AddAsync(SupplierItemDetailsAddDto addDto);
        Task<SupplierItemDetailsDto> GetByIdAsync(string id);
        Task UpdateAsync(SupplierItemDetailsUpdateDto updateDto);
        Task DeleteAsync(string id);

        Task<List<BaseKeyValueDto>> GetValidByBrandIdAsync(string warehouseId);

    }
}
