using Fx.Amiya.Dto.LiveReplayWordAnalyse.Input;
using Fx.Amiya.Dto.LiveReplayWordAnalyse.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveReplayWordAnalyseService
    {
        Task<List<LiveReplayWordAnalyseDataInfoDto>> GetListAsync(QueryLiveReplayWordAnalyseDataDto query);
        Task AddListAsync(List<AddLiveReplayWordAnalyseDataDto> addDtoList);
        Task DeleteByIdListAsync(string liveReplayId);
    }
}
