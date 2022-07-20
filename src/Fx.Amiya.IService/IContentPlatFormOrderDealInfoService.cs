using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IContentPlatFormOrderDealInfoService
    {
        Task<FxPageInfo<ContentPlatFormOrderDealInfoDto>> GetListWithPageAsync(string contentPlafFormOrderId, int pageNum, int pageSize);
        Task AddAsync(AddContentPlatFormOrderDealInfoDto addDto);
        Task<ContentPlatFormOrderDealInfoDto> GetByIdAsync(string id);

        Task UpdateAsync(UpdateContentPlatFormOrderDealInfoDto updateDto);

        Task DeleteAsync(string id);
        Task<ContentPlatFormOrderDealInfoDto> GetByOrderIdAsync(string orderId);
    }
}
