using Fx.Amiya.Dto;
using Fx.Amiya.Dto.RunTangDateOperation.Input;
using Fx.Amiya.Dto.RunTangDateOperation.Result;
using Fx.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IRunTangDateOperationService
    {
        Task<FxPageInfo<RunTangDateOperationDto>> GetListAsync(QueryRunTangDateOperationDto query);
        Task AddAsync(AddRunTangDateOperationDto addDto);
        Task<RunTangDateOperationDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateRunTangDateOperationDto updateDto);
        Task DeleteAsync(string id);
    }
}
