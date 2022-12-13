using Fx.Amiya.Dto.HospitalCustomerInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalCustomerInfoService
    {
        /// <summary>
        /// 获取医院顾客
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SendHospitalCustomerInfoDto>> GetListWithPageAsync(string keyword, int hospitalId, int employeeId, int pageNum, int pageSize);

        /// <summary>
        /// 获取“我来跟进”的顾客
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="hospitalEmployeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SendHospitalCustomerInfoDto>> GetByHospitalEmployeeIdListWithPageAsync(string keyword, int hospitalEmployeeId, int pageNum, int pageSize);
        Task AddAsync(AddSendHospitalCustomerInfoDto addDto);
        Task<SendHospitalCustomerInfoDto> GetByIdAsync(string id);
        /// <summary>
        /// 根据医院编号与客户手机号获取医院客户信息
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<SendHospitalCustomerInfoDto> GetByHospitalIdAndPhoneAsync(int hospitalId, string phone);

        /// <summary>
        /// 更新查重时间
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateConfirmOrderDateAsync(UpdateSendHospitalCustomerInfoDto updateDto);
        /// <summary>
        /// 更新顾客派单次数与项目需求
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task InsertSendAmountAsync(UpdateSendHospitalCustomerInfoDto updateDto);
        /// <summary>
        /// 更新成交次数
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task InsertDealAmountAsync(UpdateSendHospitalCustomerInfoDto updateDto);
        Task DeleteAsync(string id);
    }
}
