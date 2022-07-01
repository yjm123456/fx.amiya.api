using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IShoppingCartRegistrationService
    {
        Task<FxPageInfo<ShoppingCartRegistrationDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, int pageNum, int pageSize);
        Task AddAsync(AddShoppingCartRegistrationDto addDto);
        Task<ShoppingCartRegistrationDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateShoppingCartRegistrationDto updateDto);
        Task DeleteAsync(string id);

        #region 【报表相关】
        Task<List<ShoppingCartRegistrationDto>> GetShoppingCartRegistrationReportAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, bool isHidePhone);
        #endregion
    }
}
