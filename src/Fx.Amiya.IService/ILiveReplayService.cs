using Fx.Amiya.Dto.LiveRepley;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveReplayService
    {
        Task<FxPageInfo<LiveReplayInfoDto>> GetListWithPageAsync(bool? valid, string keyWord,DateTime? date, int pageSize, int pageNum);
        Task AddAsync(AddLiveReplayDto addDto);
        Task<LiveReplayInfoDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateLiveReplayDto updateDto);
        Task DeleteAsync(string id);
    }
}
