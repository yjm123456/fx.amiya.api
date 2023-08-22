using Fx.Amiya.Dto.LiveReplayInteractionlData.Input;
using Fx.Amiya.Dto.LiveReplayInteractionlData.Result;
using Fx.Amiya.Dto.LiveRepley;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveReplayInteractionlDataService
    {
        Task<List<LiveReplayInteractionlDataInfoDto>> GetListAsync(QueryLiveReplayInteractionlDataDto query);
        Task AddListAsync(List<AddLiveReplayInteractionlDataDto> addDtoList);
        Task DeleteByIdListAsync(string liveReplayId);
    }
}
