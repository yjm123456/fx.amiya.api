using Fx.Amiya.Dto.ContentPlatFormOrderDealDetails.Input;
using Fx.Amiya.Dto.ContentPlatFormOrderDealDetails.Result;
using Fx.Amiya.Dto.WareHouse.InWareHouse;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IContentPlatFormOrderDealDetailsService
    {
        Task<FxPageInfo<ContentPlatFormOrderDealDetailsDto>> GetListAsync(QueryContentPlatFormOrderDealDetailsDto query);
        Task AddAsync(AddContentPlatFormOrderDealDetailsDto addDto);
        Task<ContentPlatFormOrderDealDetailsDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateContentPlatFormOrderDealDetailsDto updateDto);
        Task ConfirmOrderAsync(ConfirmContentPlatFormOrderDealDetailsDto updateDto);
        Task DeleteByDealIdAsync(DeleteContentPlatFormOrderDealDetailsByDealIdDto deleteDto);
        Task DeleteAsync(DeleteContentPlatFormOrderDealDetailsDto deleteDto);


    }
}
