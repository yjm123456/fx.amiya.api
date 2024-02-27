using Fx.Amiya.Dto.NewBusinessDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface INewBusinessDashboardService
    {
        Task<BeforeLivingBusinessDataDto> GetBeforeLivingBussinessDataAsync(QueryBeforeLivingBusinessDataDto queryDto);
        Task<BeforeLivingBrokenDataDto> GetBeforeLivingBrokenLineDataAsync(QueryBeforeLivingBusinessDataDto queryDto);
        Task<LivingBusinessDataDto> GetLivingBusinessDataAsync(QueryLivingBusinessDataDto queryDto);
        Task<LivingBrokenDataDto> GetLivingBusinessBrokenDataAsync(QueryLivingBusinessDataDto queryDto);
        Task<LivingAestheticMedicineBusinessDataDto> GetAestheticMedicineBusinessDataAsync(QueryLivingBusinessDataDto queryDto);
        Task<LivingAestheticMedicineBrokenDataDto> GetAestheticMedicineBusinessBrokenDataAsync(QueryLivingBusinessDataDto queryDto);
        Task<AfterLivingBusinessDataDto> GetAfterLivingBusinessDataAsync(QueryAfterLivingBusinessDataDto queryDto);
        Task<AfterLivingBrokenDataDto> GetAfterLivingBrokenDataAsync(QueryAfterLivingBusinessDataDto queryDto);

    }
}
