using Fx.Amiya.Dto.AmiyaHospitalOperation.Input;
using Fx.Amiya.Dto.AmiyaHospitalOperation.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaHospitalOperationBoardService
    {
        Task<HospitalPerformanceDto> GetHospitalPerformanceAsync(QueryHospitalPerformanceDto query);
        Task<HospitalVisitDataDto> GetHospitalVisitDataDto(QueryHospitalPerformanceDto query);
        Task<HospitalPerformanceBrokenLineDto> GetHospitalPerformanceBrokenLineDto(QueryHospitalPerformanceDto query);
        Task<HospitalPerformanceBrokenLineDto> GetHospitalVisitBrokenLineDto(QueryHospitalPerformanceDto query);
        Task<HospitalNewOrOldCustomerDataDto> GetAssistantPerformanceFilterDataAsync(QueryHospitalPerformanceDto query);
        Task<HospitalTransformCycleDataDto> GetHospitalTransformCycleDataAsync(QueryHospitalPerformanceDto query);
        Task<HospitalsCluesDataDto> GetHospitalsCluesDataAsync(QueryHospitalVisitDataDto query);
        Task<HospitalPerformanceRateDto> GetHospitalPerformanceRateDataAsync(QueryHospitalPerformanceDto query);
        Task<HospitalPerformanceYearDataListDto> GetTotalHospitalPersonalAchievementByYearAsync(QueryHospitalPerfomanceYearDataDto query);
    }
}
