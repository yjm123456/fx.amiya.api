using Fx.Amiya.Dto.CustomerInfo;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerService
    {
        /// <summary>
        /// 绑定客户
        /// </summary>
        /// <param name="fxUserId"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task<string> BindCustomerAsync(string fxUserId, string phoneNumber);


        /// <summary>
        /// 根据客户编号获取绑定的手机号
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<string> GetPhoneByCustomerIdAsync(string customerId);




        /// <summary>
        /// 根据客户编号获取客户信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<CustomerInfoDto> GetByIdAsync(string customerId);



        Task<CustomerInfoDto> GetByUserIdAsync(string userId);

        Task<CustomerDto> GetCustomerByUserIdAsync(string userId);

        /// <summary>
        /// 根据电话号查询客户信息
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<BindCustomerInfoDto> GetByPhoneAsync(string phone);



        /// <summary>
        /// 根据客户编号修改客户手机号
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task UpdatePhoneByIdAsync(string customerId, string phone);

        /// <summary>
        /// 获取客户数量
        /// </summary>
        /// <returns></returns>
        Task<CustomerQuantityDto> GetCustomerQuantityAsync();


        /// <summary>
        /// 获取微信客户列表
        /// </summary>
        /// <param name="customerSearchParamDto"></param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerInfoDto>> GetWxCustomerListAsync(CustomerSearchParamDto customerSearchParamDto);

        /// <summary>
        /// 获取绑定了客服的客户列表
        /// </summary>
        /// <returns></returns>
        Task<FxPageInfo<BindCustomerInfoDto>> GetBindCustomerServiceListAsync(CustomerSearchParamDto customerSearchParam);

        /// <summary>
        /// 根据条件获取客户消费列表
        /// </summary>
        /// <param name="customerSearchParam"></param>
        /// <returns></returns>
        Task<FxPageInfo<BindCustomerConsumptionInfoDto>> GetBindCustomerConsumptionServiceListAsync(CustomerCunsumptionSearchParamDto customerSearchParam);

        /// <summary>
        /// 私域运营板块老客复购情况
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<BindCustomerConsumptionInfoDto>> GetTopBindCustomerConsumptionServiceListAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 获取客户回访情况列表
        /// </summary>
        /// <param name="customerSearchParam"></param>
        /// <returns></returns>
        Task<FxPageInfo<BindTrackCustomerInfoDto>> GetCustomerTrackServiceListAsync(CustomerTrackInfoSearchDto customerSearchParam);
        /// <summary>
        /// 解密手机号
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        Task<string> DecryptoPhone(string encryptPhone);


        /// <summary>
        /// 根据加密电话查询简单的客户和订单信息
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        Task<CustomerSimpleInfoDto> GetCustomerSimpleByPhoneAsync(string encryptPhone);



        /// <summary>
        /// 根据医院编号获取派单的客户列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerInfoDto>> GetCustomerListByHospitalIdAsync(int hospitalId, string keyword,int pageNum, int pageSize);


        /// <summary>
        /// 编辑客户基础信息
        /// </summary>
        /// <param name="editDto"></param>
        /// <returns></returns>
         Task EditAsync(EditCustomerDto editDto);


        /// <summary>
        /// 根据加密电话获取客户基础信息
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        Task<CustomerBaseInfoDto> GetCustomerBaseInfoByEncryptPhoneAsync(string encryptPhone);

        /// <summary>
        /// 根据电话获取客户编号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>没有返回null</returns>
        Task<string> GetCustomerIdByPhoneAsync(string phone);


        /// <summary>
        /// 根据加密电话获取客户编号
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns>没有返回null</returns>
        Task<string> GetCustomerIdByEncryptPhoneAsync(string encryptPhone);

    }
}
