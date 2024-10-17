﻿using Fx.Amiya.Dto.CustomerServiceCheckPerformance.Input;
using Fx.Amiya.Dto.CustomerServiceCheckPerformance.Result;
using Fx.Common;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerServiceCheckPerformanceService
    {
        Task<FxPageInfo<CustomerServiceCheckPerformanceDto>> GetListAsync(QueryCustomerServiceCheckPerformanceDto query);
        Task AddAsync(AddCustomerServiceCheckPerformanceDto addDto);
        Task<CustomerServiceCheckPerformanceDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateCustomerServiceCheckPerformanceDto updateDto);
        Task DeleteAsync(string id);
    }
}
