using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.HospitalContentplatformCode.Input;
using Fx.Amiya.Dto.HospitalContentplatformCode.Result;
using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.Performance.BusinessWechatDto;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalContentplatformCodeService
    {
        Task<FxPageInfo<HospitalContentplatformCodeDto>> GetListAsync(QueryHospitalContentplatformCodeDto query);

        Task AddAsync(AddHospitalContentplatformCodeDto addDto);
        Task<HospitalContentplatformCodeDto> GetByIdAsync(string id);

        Task<HospitalContentplatformCodeDto> GetByHospitalIdAndThirdPartContentPlatformIdAsync(int hospitalId, string ThirdPartContentPlatFormId);

        Task UpdateAsync(UpdateHospitalContentplatformCodeDto updateDto);
        Task DeleteAsync(string id, int empId);
    }
}
