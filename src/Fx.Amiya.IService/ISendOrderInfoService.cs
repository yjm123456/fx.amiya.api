using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.SendOrderInfo;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ISendOrderInfoService
    {
        /// <summary>
        /// 获取派单信息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="appType">下单平台</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SendOrderInfoDto>> GetListWithPageAsync(string keyword, int employeeId, DateTime? startDate, DateTime? endDate, byte? appType, string statusCode,int? hospitalId, int pageNum, int pageSize);

        /// <summary>
        /// 获取未派单订单列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId"></param>
        /// <param name="appType">下单平台</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<UnSendOrderInfoDto>> GetUnSendOrderListWithPageAsync(string keyword, int employeeId, byte? appType, string statusCode, int pageNum, int pageSize);


        /// <summary>
        /// 添加派单信息
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task AddAsync(AddSendOrderInfoDto addDto, int employeeId);



        /// <summary>
        /// 修改派单
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateSendOrderInfoDto updateDto, int employeeId);


        /// <summary>
        /// 根据编号获取简单的派单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SendOrderInfoSimpleDto> GetSimpleByIdAsync(int id);


        /// <summary>
        /// 根据医院编号获取派单列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SendOrderInfoDto>> GetListByHospitalIdAsync(int hospitalId, string keyword, DateTime? startDate, DateTime? endDate, int pageNum, int pageSize,bool IsHidePhone);

        /// <summary>
        /// 获取今日派单情况
        /// </summary>
        /// <returns></returns>
        Task<List<TodaySendOrderInfoDto>> GetTodaySendOrderAsync();

        /// <summary>
        /// 各医院今日接单情况
        /// </summary>
        /// <returns></returns>
        Task<List<TodayHospitalOrderNumDto>> GetTodayHospitalOrderNumAsync();
        /// <summary>
        /// 根据医院编号和加密电话获取派单信息
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SendOrderInfoDto>> GetCustomerHospitalOrdersAsync(int hospitalId, string encryptPhone, int pageNum, int pageSize);
        /// <summary>
        /// 根据订单号获取派单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<List<SendOrderInfoDto>> GetSendOrderInfoByOrderId(string orderId);

        /// <summary>
        /// 添加派单留言板
        /// </summary>
        /// <param name="addSendOrderMessageBoard"></param>
        /// <returns></returns>
        Task AddSendOrderMessageBoardAsync(AddSendOrderMessageBoardDto addSendOrderMessageBoard);

        /// <summary>
        /// 获取派单留言板列表
        /// </summary>
        /// <param name="id">派单信息编号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SendOrderMessageBoardDto>> GetSendOrderMessageBoardListByIdAsync(int? hospitalId, int id, int pageNum, int pageSize);
       

        #region 报表模块

        /// <summary>
        /// 获取派单报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<SendOrderReportDto>> GetSendOrderReportAsync(DateTime? startDate, DateTime? endDate,string state,bool isHidePhone);

        /// <summary>
        /// 获医院订单报表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="hospitalName">医院名称</param>
        /// <returns></returns>
        Task<List<SendOrderReportDto>> GetHospitalOrderReportAsync(DateTime? startDate, DateTime? endDate, string hospitalName, bool isHidePhone);

        /// <summary>
        /// 获取客服已派单报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<SendOrderReportDto>> GetCustomerSendOrderReportAsync(DateTime? startDate, DateTime? endDate, int employeeId, int belongEmpId, string orderStatus, bool isHidePhone);
        /// <summary>
        /// 获取客服未派单报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isHidePhone"></param>
        /// <returns></returns>
        Task<List<UnSendOrderInfoReportDto>> GetUnSendOrderReportWithPageAsync(DateTime? startDate, DateTime? endDate, int employeeId, bool isHidePhone);
        #endregion

        #region 【数据中心板块】

        Task<List<OrderOperationConditionDto>> GetOrderSendDataAsync(DateTime startDate, DateTime endDate);

        Task<List<OrderOperationConditionDto>> GetOrderUnSendDataAsync(DateTime startDate, DateTime endDate);

        Task<List<HospitalOrderNumAndPriceDto>> GetHospitalOrderNumAsync(DateTime startDate, DateTime endDate);

        #endregion

        
    }
}
