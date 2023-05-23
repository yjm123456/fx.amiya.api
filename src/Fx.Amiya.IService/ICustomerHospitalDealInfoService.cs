using Fx.Amiya.Dto;
using Fx.Amiya.Dto.CustomerHospitalDealInfo.Input;
using Fx.Amiya.Dto.CustomerHospitalDealInfo.Result;
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
    public interface ICustomerHospitalDealInfoService
    {
        Task<FxPageInfo<CustomerHospitalDealInfoDto>> GetListWithPageAsync(QueryCustomerHospitalDealInfoPageListDto query);
        Task AddAsync(AddCustomerHospitalDealInfoDto addDto);
        Task DeleteAsync(string id);

        List<BaseIdAndNameDto> GetHospitalDealTypeList();
        List<BaseIdAndNameDto> GetHospitalConsumptionTypeList();
        List<BaseIdAndNameDto> GetHospitalRefundTypeList();
    }
}
