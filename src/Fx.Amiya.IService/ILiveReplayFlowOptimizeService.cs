using Fx.Amiya.Dto.LiveReplayFlowOptimize.Input;
using Fx.Amiya.Dto.LiveReplayFlowOptimize.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveReplayFlowOptimizeService
    {
        Task<List<LiveReplayFlowOptimizeDataInfoDto>> GetListAsync(QueryLiveReplayFlowOptimizeDataDto query);
        Task AddListAsync(List<AddLiveReplayFlowOptimizeDataDto> addDtoList);
        Task DeleteByIdListAsync(string liveReplayId);
    }
}
