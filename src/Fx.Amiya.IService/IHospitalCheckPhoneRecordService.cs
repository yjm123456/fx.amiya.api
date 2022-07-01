using Fx.Amiya.Dto.HospitalCheckPhoneRecord;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalCheckPhoneRecordService
    {

        /// <summary>
        /// 获取医院查看电话记录列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalCheckPhoneRecordDto>> GetListWithPageAsync(int? hospitalId, int pageNum, int pageSize);


        /// <summary>
        /// 添加正常交易订单的查看电话记录
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="hospitaId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<string> AddAsync(AddHospitalCheckPhoneRecordDto addDto, int hospitaId, int employeeId);


        /// <summary>
        /// 添加内容平台订单的查看电话记录
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="hospitaId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<string> AddContentPlatformOrderCheckPhoneRecordAsync(AddHospitalCheckPhoneRecordDto addDto, int hospitaId, int employeeId);
    }
}
