using Fx.Amiya.Dto.LiveAnchorWeChatInfo;
using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveAnchorWeChatInfoService
    {
        Task<List<LiveAnchorWeChatInfoDto>> GetValidListByLiveAnchorIdAsync(int? liveAnchorId, int employeeId);
        Task<List<LiveAnchorWeChatInfoDto>> GetValidAsync();
        Task<FxPageInfo<LiveAnchorWeChatInfoDto>> GetListAsync(string keyword, int? liveAnchorId, int employeeId, bool valid, int pageNum, int pageSize);
        Task AddAsync(AddLiveAnchorWeChatInfoDto addDto);
        Task<LiveAnchorWeChatInfoDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateLiveAnchorWeChatInfoDto updateDto);
        Task DeleteAsync(string id);


    }
}
