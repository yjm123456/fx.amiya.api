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
        /// <summary>
        /// 系统端指标填报数据汇总
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isSumbit"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalOperationIndicatorCollectDto>> GetHospitalOperationIndicatorCollectList(string indicatorId, int? hospitalId, int pageNum, int pageSize, bool? isSumbit);
        /// <summary>
        /// 获取机构提报数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isSumbit"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 根据指标id获取提报和批注状态
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        Task<HospitalReamrkAndSumbitStatusDto> SubmitAndRemarkStatusAsync(string indicatorId);
    }
}
