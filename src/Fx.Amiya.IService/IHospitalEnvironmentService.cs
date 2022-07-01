using Fx.Amiya.Dto.HospitalEnvironment;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalEnvironmentService
    {
        Task<FxPageInfo<HospitalEnvironmentDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize);
        Task AddAsync(HospitalEnvironmentAddDto addDto);
        Task<List<HospitalEnvironmentIdAndNameDto>> GetIdAndNames();
        Task<HospitalEnvironmentDto> GetByIdAsync(string id);
        Task UpdateAsync(HospitalEnvironmentUpdateDto updateDto);
        Task DeleteAsync(string id);
    }
}
