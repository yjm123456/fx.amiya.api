using Fx.Amiya.Dto.TagInfo;
using Fx.Amiya.Dto.TrackTypeThemeModel;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITrackTypeThemeModelService
    {
        Task<List<TrackTypeThemeModelDto>> GetListAsync(int? trackTypeId);
        Task AddAsync(List<AddTrackTypeThemeModelDto> addDto);
    }
}
