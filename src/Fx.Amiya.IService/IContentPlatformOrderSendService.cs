using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.OrderReport;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IContentPlatformOrderSendService
    {
        /// <summary>
        /// 根据订单号获取派单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<List<ContentPlatformOrderSendOrderInfoDto>> GetSendOrderInfoByOrderId(string orderId);

        /// <summary>
        /// 根据订单号集合获取简易的派单信息
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        Task<List<ContentPlatformOrderSendOrderInfoDto>> GetSendOrderInfoByOrderId(List<string> orderIds);


        /// <summary>
        /// 获取简易的派单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContentPlatFormSendOrderInfoSimpleDto> GetSimpleByIdAsync(int id);


        /// <summary>
        /// 获取今日派单情况
        /// </summary>
        /// <returns></returns>
        Task<List<TodaySendOrderInfoDto>> GetTodaySendOrderAsync();

        /// <summary>
        /// 添加派单
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddContentPlatFormSendOrderInfoDto addDto);

        /// <summary>
        /// 修改派单
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateOrderSend(UpdateContentPlatFormSendOrderInfoDto updateDto, int employeeId);
        /// <summary>
        /// 医院获取派单列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ContentPlatFormOrderSendInfoDto>> GetListByHospitalIdAsync(int hospitalId, string keyword, DateTime? startDate, DateTime? endDate, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int pageNum, int pageSize);

        /// <summary>
        /// 根据医院id获取未处理订单条数
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<int> GetCountByHospitalIdAsync(int hospitalId);


        /// <summary>
        /// 各医院今日接单情况
        /// </summary>
        /// <returns></returns>
        Task<List<TodayHospitalOrderNumDto>> GetTodayHospitalOrderNumAsync();
       

        /// <summary>
        /// 医院填写备注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateOrderHospitalRemarkAsync(ContentPlatFormOrderRemarkDto input);


        /// <summary>
        /// 获取内容平台订单已派单信息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="liveAnchorId">归属主播ID</param>
        /// <param name="employeeId"> -1查询全部</param>
        /// <param name="consultationEmpId">面诊员id</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="toHospitalStartDate">到院时间起</param>
        /// <param name="toHospitalEndDate">到院时间止</param>        
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SendContentPlatformOrderDto>> GetSendOrderList(int? liveAnchorId, int? consultationEmpId, int? sendBy, bool? isAcompanying, bool? isOldCustomer, decimal? commissionRatio, string keyword, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int employeeId, int? orderStatus, string contentPlatFormId, DateTime? startDate, DateTime? endDate, int? hospitalId, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int orderSource, int pageNum, int pageSize);


        Task<List<SendContentPlatformOrderDto>> GetSendOrderReportList(int? liveAnchorId, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? hospitalId, int employeeId, int belongEmpId, int? orderStatus
          , bool? isAcompanying, bool? isOldCustomer, decimal? commissionRatio, string contentPlatFormId, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, DateTime? startDate, DateTime? endDate, bool isHidePhone);
        #region 报表相关

        /// <summary>
        /// 获取医院订单报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalName"></param>
        /// <param name="isHidePhone"></param>
        /// <returns></returns>
        Task<List<SendContentPlatFormOrderReportDto>> GetContentPlatFormHospitalOrderReportAsync(DateTime? startDate, DateTime? endDate, int hospitalId, bool isHidePhone);

        #endregion

        /// <summary>
        /// 根据时间获取内容平台已派单报表数量
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<OrderOperationConditionDto>> GetOrderSendDataAsync(DateTime startDate, DateTime endDate);
    }
}
