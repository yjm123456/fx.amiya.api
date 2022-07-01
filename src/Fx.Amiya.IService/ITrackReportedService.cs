using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.Dto.TrackReported;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITrackReportedService
    {
        Task<FxPageInfo<TrackReportedDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? sendHospitalId, int? employeeId, int? sendStatus, string keyword, int pageNum, int pageSize);

        Task<FxPageInfo<TrackReportedDto>> GetHospitalUnTrackListWithPageAsync(DateTime? startDate, DateTime? endDate, int? sendHospitalId, string keyword, int pageNum, int pageSize);

        Task<FxPageInfo<TrackReportedDto>> GetHospitalDealedListWithPageAsync(DateTime? startDate, DateTime? endDate, int? sendStatus, int? sendHospitalId, string keyword, int pageNum, int pageSize);
        Task AddAsync(AddTrackReportedDto addDto);

        Task<TrackReportedDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateTrackReportedDto updateDto);
        Task DeleteAsync(string id);

        Task HospitalConfirTrackRecordAsync(HospitalConfirmTrackRecordedDto addDto);
        List<OrderAppTypeDto> GetSendStatusTextList();
    }
}
