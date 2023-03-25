using Fx.Amiya.Dto.BindCustomerService;
using Fx.Amiya.Dto.WxAppConfig;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IBindCustomerServiceService
    {
        /// <summary>
        /// 添加绑定客服
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task AddAsync(AddBindCustomerServiceDto addDto, int employeeId);
        /// <summary>
        /// 根据手机号获取绑定客户详情
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<BindCustomerServiceDto> GetEmployeeDetailsByPhoneAsync(string phone);
        Task<BindCustomerServiceDto> GetByIdAsync(int id);

        /// <summary>
        /// 获取我的客户
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<MyCustomerInfoDto> GetCustomerCountByEmployeeIdAsync(int employeeId);

        /// <summary>
        /// 根据手机号获取归属客服id
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<int> GetEmployeeIdByPhone(string phone);

        /// <summary>
        /// 根据手机号获取客户手机号是否有多个
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<List<string>> GetEmployeePhoneByPhone(string phone);

        /// <summary>
        /// 根据手机号获取归属客服名称
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<string> GetBindCustomerServiceNameByPhone(string phone);
        Task UpdateAsync(UpdateBindCustomerServiceDto updateDto, int employeeId);

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
        Task UpdateConsumePriceAsync(string phone, decimal Price, int Channel, string newLiveAnchor, string newWeChatNo, string newContentPlatForm, int AllOrderCount);

        /// <summary>
        /// 扣除客户消费累计金额与订单数
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="Price"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        Task ReduceConsumePriceAsync(string phone, decimal Price, int Channel);
        /// <summary>
        /// 内容平台与升单成交加入成交金额并更新最近消费所属主播
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="Price"></param>
        /// <returns></returns>
        Task UpdateConsumePriceAndLiveAnchorAsync(string phone, decimal Price, int Channel, int AllOrderCount, string LiveAnchorName);

    }
}
