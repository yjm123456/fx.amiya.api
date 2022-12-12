using Fx.Amiya.Dto.OrderRemark;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IOrderRemarkService
    {
        Task<FxPageInfo<OrderRemarkDto>> GetListWithPageAsync(string orderId, int pageNum, int pageSize);

        Task AddAsync(AddOrderRemarkDto addDto);

        Task<OrderRemarkDto> GetByIdAsync(string id);

        Task UpdateAsync(UpdateOrderRemarkDto updateDto);

        Task DeleteAsync(string id);
    }
}
