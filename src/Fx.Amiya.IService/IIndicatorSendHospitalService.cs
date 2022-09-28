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

        /// <summary>
        /// 修改提交状态
        /// </summary>
        /// <param name="IndicatorId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task UpdateSubmitStateAsync(string IndicatorId, int hospitalId);

        /// <summary>
        /// 修改批注状态
        /// </summary>
        /// <param name="IndicatorId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task UpdateRemarkStatusAsync(string IndicatorId, int hospitalId);
    }
}
