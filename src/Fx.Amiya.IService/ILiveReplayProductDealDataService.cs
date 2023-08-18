using Fx.Amiya.Dto.LiveReplayProductDealData.Input;
using Fx.Amiya.Dto.LiveReplayProductDealData.Result;
using Fx.Amiya.Dto.LiveRepley;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveReplayProductDealDataService
    {
        Task<List<LiveReplayProductDealDataInfoDto>> GetListAsync(QueryLiveReplayProductDealDataDto query);
        Task AddListAsync(List<AddLiveReplayProductDealDataDto> addDtoList);
        Task DeleteByIdListAsync(string liveReplayId);
    }
}
