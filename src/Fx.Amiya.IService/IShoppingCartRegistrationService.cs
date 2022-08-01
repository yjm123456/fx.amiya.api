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
        Task<FxPageInfo<ShoppingCartRegistrationDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, bool? isCreateOrder, bool? isSendOrder, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, int pageNum, int pageSize,decimal? minPrice,decimal? maxPrice,int? AdmissionId);
        Task AddAsync(AddShoppingCartRegistrationDto addDto);
        Task<ShoppingCartRegistrationDto> GetByIdAsync(string id);
        Task<ShoppingCartRegistrationDto> GetByPhoneAsync(string phone);
        Task UpdateAsync(UpdateShoppingCartRegistrationDto updateDto);
        /// <summary>
        /// 录单触达
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task UpdateCreateOrderAsync(string phone);
        /// <summary>
        /// 派单触达
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task UpdateSendOrderAsync(string phone);
        Task DeleteAsync(string id);

        #region 【报表相关】
        Task<List<ShoppingCartRegistrationDto>> GetShoppingCartRegistrationReportAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, bool? isCreateOrder, bool? isSendOrder, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, bool isHidePhone);
        #endregion
    }
}
