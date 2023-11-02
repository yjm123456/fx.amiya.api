using Fx.Amiya.Dto;
using Fx.Amiya.Dto.TikTokShortVideoData;
using Fx.Amiya.Dto.TikTokShortVideoData.Input;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITikTokShortVideoDataService
    {
        Task AddListAsync(List<AddTikTokShortVideoDataDto> adddList);
        Task<FxPageInfo<TikTokShortVideoDataInfoDto>> GetShortVideoDataByPageAsync(ShortVideoDataQueryDto query);
    }
}
