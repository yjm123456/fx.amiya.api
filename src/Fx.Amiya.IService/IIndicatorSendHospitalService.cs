using Fx.Amiya.Dto.HospitalOperationIndicator;
using Fx.Amiya.Dto.IndicatorSendHospital;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IIndicatorSendHospitalService
    {
        Task<FxPageInfo<HospitalOperationIndicatorCollectDto>> GetHospitalOperationIndicatorCollectList(string indicatorId, int? hospitalId, int pageNum, int pageSize, bool? isSumbit);
        Task<FxPageInfo<HospitalIndicatorFillDto>> GetHospitalOperationIndicatorFillList(int? hospitalId, int pageNum, int pageSize, bool? isSumbit);
    }
}
