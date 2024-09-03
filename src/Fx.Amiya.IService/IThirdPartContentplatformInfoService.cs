using Fx.Amiya.Dto;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.ThirdPartContentplatformInfo.Input;
using Fx.Amiya.Dto.ThirdPartContentplatformInfo.Result;
using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.Performance.BusinessWechatDto;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IThirdPartContentplatformInfoService
    {
        Task<FxPageInfo<ThirdPartContentplatformInfoDto>> GetListAsync(QueryThirdPartContentplatformInfoDto query);
        Task AddAsync(AddThirdPartContentplatformInfoDto addDto);
        Task<ThirdPartContentplatformInfoDto> GetByIdAsync(string id);
        Task<ThirdPartContentplatformInfoDto> GetByNameAsync(string name);
        Task UpdateAsync(UpdateThirdPartContentplatformInfoDto updateDto);
        Task DeleteAsync(string id);
        Task<List<BaseKeyValueDto>> GetValidListAsync();
    }
}
