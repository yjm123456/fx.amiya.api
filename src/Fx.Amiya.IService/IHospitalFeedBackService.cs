using Fx.Amiya.Dto.HospitalFeedBack;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalFeedBackService
    {
        Task<FxPageInfo<HospitalFeedBackDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? hospitalId, string keyword, int pageNum, int pageSize);
        Task AddAsync(AddHospitalFeedBackDto addDto);
        Task<HospitalFeedBackDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateHospitalFeedBackDto updateDto);
        Task DeleteAsync(string id);

    }
}
