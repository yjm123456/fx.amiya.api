using Fx.Amiya.Dto.LiveReplay.Input;
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
        Task<FxPageInfo<LiveReplayInfoDto>> GetListWithPageAsync(QueryReplayDto query);
        Task AddAsync(AddLiveReplayDto addDto);
        Task<LiveReplayInfoDto> GetByIdAsync(string id);
        Task<LiveReplayInfoDto> GetLastLiveReplayId(string id);
        Task UpdateAsync(UpdateLiveReplayDto updateDto);
        Task DeleteAsync(string id);
        /// <summary>
        /// 根据指定条件获取直播复盘数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<LiveReplayInfoDto> GetFirstReplayAsync(QueryFirstReplayDto query);
    }
}
