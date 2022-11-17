
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.DockingHospitalCustomerInfo;
using Fx.Amiya.Dto.HospitalCustomerInfo;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IDockingHospitalCustomerInfoService
    {
        /// <summary>
        /// 根据医院id获取配置信息
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<DockingHospitalCustomerInfoDto> GetDockingHospitalInfo(int hospitalId);

        /// <summary>
        /// 获取美丽日记token信息
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<DockingHospitalCustomerInfoDto> GetBeautyDiaryTokenInfo(int hospitalId);
        /// <summary>
        /// 获取小程序accesstoken
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<DockingHospitalCustomerInfoDto> GetMiniProgramAccessTokenInfo(int hospitalId);

        /// <summary>
        /// 根据条件获取医院客户信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerName"></param>
        /// <param name="customerPhone"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalCustomerInfoDto>> GetListAsync(DateTime startDate, DateTime endDate, string customerName, string customerPhone, int hospitalId, int pageNum, int pageSize);

        /// <summary>
        /// 根据客户编号获取消费记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalCustomerOrderInfoDto>> GetCustomerOrderListAsync(string customerId, int hospitalId, int pageNum, int pageSize);

        /// <summary>
        /// 获取指定日期消费记录
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerName"></param>
        /// <param name="customerPhone"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalCustomerOrderInfoDto>> GetOrderListAsync(DateTime startDate, DateTime endDate, string customerName, string customerPhone, int hospitalId, int pageNum, int pageSize);

        /// <summary>
        /// 获取已配置订单对接的医院
        /// </summary>
        /// <returns></returns>
        Task<List<BaseIdAndNameDto>> GetDockingHospitalIdAndName();

    }
}
