using Fx.Amiya.Dto;
using Fx.Amiya.Dto.Bill;
using Fx.Amiya.Dto.CustomerServiceCompensation.Input;
using Fx.Amiya.Dto.CustomerServiceCompensation.Result;
using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerServiceCompensationService
    {
        Task<FxPageInfo<CustomerServiceCompensationDto>> GetListAsync(QueryCustomerServiceCompensationDto query);
        Task AddAsync(AddCustomerServiceCompensationDto addDto);
        Task<CustomerServiceCompensationDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateCustomerServiceCompensationDto updateDto);
        Task DeleteAsync(string id);
    }
}
