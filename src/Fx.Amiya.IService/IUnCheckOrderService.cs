using Fx.Amiya.Dto.UnCheckOrder;
using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IUnCheckOrderService
    {
        Task<FxPageInfo<UnCheckOrderDto>> GetListByPageAsync(DateTime? startDate, DateTime? endDate, bool? isSubmitReconciliationDocuments, int? orderFrom, int? hospitalId, string keyword, int pageNum, int pageSize);
        Task AddListAsync(List<AddUnCheckOrderDto> addUnCheckOrderDtoList);
        Task<UnCheckOrderDto> GetByIdAsync(string id);
        Task<List<UnCheckOrderDto>> GetByPhoneAsync(string phone, int sendHospital);
        Task UpdateAsync(UpdateUnCheckOrderDto updateUnCheckOrderDto);
        Task SendToHospitalByIdListAsync(UnCheckOrderSendToHospitalDto unCheckOrderSendToHospitalDto);
        Task UpdateIsSubmitByIdListAsync(List<string> idList);
        Task DeleteAsync(List<string> idList);
    }
}
