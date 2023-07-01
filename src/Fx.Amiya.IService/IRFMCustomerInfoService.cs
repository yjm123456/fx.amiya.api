using Fx.Amiya.Dto;
using Fx.Amiya.Dto.RFMCustomerInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IRFMCustomerInfoService
    {
        Task ImportRFMCustomerInfoAsync(List<ImportRfmCustomerDto> list);
        Task<FxPageInfo<RFMCustomerInfoDto>> GetListByPageAsync(string keyword,int pageNum,int pageSize);
        List<BaseKeyValueDto> GetRFMValueText();
        List<BaseKeyValueDto> GetRFMTagText();
        Task AddAsync(AddRFMCustomerInfoDto addDto);
        Task<RFMCustomerInfoDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateRFMCustomerInfoDto updateDto);
        Task DeleteAsync(string id);
    }
}
