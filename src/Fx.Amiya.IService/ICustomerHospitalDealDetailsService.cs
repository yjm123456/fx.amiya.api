using Fx.Amiya.Dto.CustomerHospitalDealDetails.Input;
using Fx.Amiya.Dto.CustomerHospitalDealDetails.Result;
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
    public interface ICustomerHospitalDealDetailsService
    {
        Task<FxPageInfo<CustomerHospitalDealDetailsDto>> GetListWithPageAsync(QueryCustomerHospitalDealDetailsPageListDto query);
        Task AddAsync(AddCustomerHospitalDealDetailsDto addDto);
        Task DeleteAsync(string id);
    }
}
