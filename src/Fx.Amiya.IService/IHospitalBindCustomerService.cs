using Fx.Amiya.Dto.HospitalBindCustomerService;
using Fx.Amiya.Dto.HospitalCustomerInfo;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalBindCustomerService
    {
        /// <summary>
        /// 根据医院id和登陆账户获取“我来跟进”的医院客户
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="hospitalEmployeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SendHospitalCustomerInfoDto>> GetByHospitalEmployeeIdListWithPageAsync(string keyword, int hospitalEmployeeId, int pageNum, int pageSize);

        /// <summary>
        /// 添加绑定客服
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddHospitalBindCustomerServiceDto addDto);
        /// <summary>
        /// 根据手机号获取绑定客户详情
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<HospitalBindCustomerServiceDto> GetEmployeeDetailsByPhoneAsync(string phone);
        Task<HospitalBindCustomerServiceDto> GetByIdAsync(string id);

        /// <summary>
        /// 根据手机号获取归属客服
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<int> GetEmployeeIdByPhone(string phone);

        Task<List<string>> GetEmployeePhoneByPhone(string phone);
        Task UpdateAsync(UpdateHospitalBindCustomerServiceDto updateDto, int employeeId);

        /// <summary>
        /// 小程序绑定客户时修改绑定客服的userId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task UpdateBindUserIdAsync(string customerId);
        /// <summary>
        /// 内容平台与升单成交加入成交金额
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="Price"></param>
        /// <returns></returns>
        Task UpdateConsumePriceAsync(string phone, decimal Price,int Channel, int AllOrderCount);

        /// <summary>
        /// 扣除客户消费累计金额与订单数
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="Price"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        Task ReduceConsumePriceAsync(string phone, decimal Price, int Channel);

    }
}
