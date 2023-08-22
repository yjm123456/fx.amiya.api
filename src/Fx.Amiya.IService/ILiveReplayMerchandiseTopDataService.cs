using Fx.Amiya.Dto.LiveReplayMerchandiseTopData.Input;
using Fx.Amiya.Dto.LiveReplayMerchandiseTopData.Result;
using Fx.Amiya.Dto.LiveRepley;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveReplayMerchandiseTopDataService
    {
        Task<List<LiveReplayMerchandiseTopDataInfoDto>> GetListAsync(QueryLiveReplayMerchandiseTopDataDto query);
        Task AddListAsync(List<AddLiveReplayMerchandiseTopDataDto> addDtoList);
        Task DeleteByIdListAsync(string liveReplayId);
    }
}
