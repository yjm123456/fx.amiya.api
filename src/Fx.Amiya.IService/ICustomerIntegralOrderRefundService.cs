using Fx.Amiya.Dto.CustomerIntegralOrderRefunds;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerIntegralOrderRefundService
    {
        Task<FxPageInfo<CustomerIntegralOrderRefundsDto>> GetListWithPageAsync(string keyword, int? checkState, int pageNum, int pageSize);
        Task AddAsync(AddCustomerIntegralOrderRefundsDto addDto);
        Task AddByTradeAsync(AddCustomerIntegralOrderRefundsDto addDto);
        Task<CustomerIntegralOrderRefundsDto> GetByIdAsync(string id);
        Task<CustomerIntegralOrderRefundsDto> GetByOrderIdAsync(string orderId);
        Task UpdateAsync(string id, string refundReason);
        Task CheckAsync(CustomerIntegralOrderRefundCheckDto updateDto);
        Task DeleteAsync(string id);
    }
}
