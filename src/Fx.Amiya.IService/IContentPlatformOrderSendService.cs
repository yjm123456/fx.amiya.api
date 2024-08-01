using Fx.Amiya.Dto.AmiyaOperationsBoardService.Input;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.HospitalBoard;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.SendOrderInfo;
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
        /// 根据id获取派单参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContentPlatformOrderSendOrderInfoDto> GetByIdAsync(int id);

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
        /// 添加派单(单派)
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        //Task AddAsync(AddContentPlatFormSendOrderInfoDto addDto);
        /// <summary>
        /// 添加派单(多派)
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddMultiAsync(AddContentPlatFormSendOrderInfoDto addDto,bool isMain);
        /// <summary>
        /// 修改派单
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateOrderSend(UpdateContentPlatFormSendOrderInfoDto updateDto, int employeeId);
        /// <summary>
        /// 新的修改派单
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task NewUpdateOrderSend(UpdateContentPlatFormSendOrderInfoDto updateDto, int employeeId);
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
        Task<FxPageInfo<ContentPlatFormOrderSendInfoDto>> GetListByHospitalIdAsync(int hospitalId, string keyword, int? OrderStatus, DateTime? startDate, DateTime? endDate, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int pageNum, int pageSize);

        /// <summary>
        /// 获取跟进中/已到院订单
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="IsToHospital"></param>
        /// <param name="toHospitalStartDate"></param>
        /// <param name="toHospitalEndDate"></param>
        /// <param name="toHospitalType"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ContentPlatFormOrderSendInfoDto>> GetFollowingListByHospitalIdAsync(int hospitalId, string keyword, DateTime? startDate, DateTime? endDate, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int pageNum, int pageSize);

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
        /// 医院获取接单信息
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="orderStatus"></param>
        /// <param name="startDate"></param>
        /// <param name="enDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalCurrentDayNotRepeatedSendOrderDto>> GetTodayNotRepeatSendOrderByHospitalIdAsync(int hospitalId,int orderStatus,DateTime startDate,DateTime enDate,int pageNum,int pageSize);


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
        /// <param name="liveAnchorIds">归属主播ID集合</param>
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
        Task<FxPageInfo<SendContentPlatformOrderDto>> GetSendOrderList(List<int?> liveAnchorIds, int? consultationEmpId, int? sendBy, bool? isAcompanying, bool? isOldCustomer, decimal? commissionRatio, string keyword, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int employeeId,int belongEmployeeId, int? orderStatus, string contentPlatFormId, DateTime? startDate, DateTime? endDate, int? hospitalId, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int orderSource, int pageNum, int pageSize,bool? isMainHospital);

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
        Task<List<SendContentPlatFormOrderReportDto>> GetContentPlatFormHospitalOrderReportAsync(DateTime? startDate, DateTime? endDate, int? orderStatus, int hospitalId, bool isHidePhone);

        #endregion

        /// <summary>
        /// 根据时间获取内容平台已派单报表数量
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<OrderOperationConditionDto>> GetOrderSendDataAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 获取今日主播IP派单情况
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<OrderOperationConditionDto>> GetTodaySendOrderByLiveAnchorIdAsync(int liveAnchorId, DateTime recordDate);

        /// <summary>
        /// 获取根据年份获取已派单订单号
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        Task<List<SendContentPlatformOrderDto>> GetTodayOrderSendDataAsync(DateTime startDate);
        /// <summary>
        /// 获取选取时间内已派单数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        Task<List<SendContentPlatformOrderDto>> GetTodayOrderSendDataAsync(QueryHospitalTransformDataDto query);

        /// <summary>
        /// 根据时间获取已到院数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<SendContentPlatformOrderDto>> GetOrderToHospitalDataByDateAsync(DateTime startDate);

        /// <summary>
        /// 根据医院id与月份获取派单业绩
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<List<SendContentPlatformOrderDto>> GetSendDataByHospitalIdAndMonthAsync(int hospitalId, int year, int month);
        /// <summary>
        /// 根据医院id与年份获取派单业绩
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<int> GetSendDataByHospitalIdAndYearAsync(int hospitalId, int year);
        /// <summary>
        /// 获取医院总派单量
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<int> GetSendDataByHospitalIdAsync(int hospitalId);
        /// <summary>
        /// 全国前10城市运营数据
        /// </summary>
        /// <returns></returns>
        Task<List<SendOrderInfoCityPerformanceDto>> GetTopTenCitySendOrderPerformance();
        /// <summary>
        /// 全国前10医院运营数据
        /// </summary>
        /// <returns></returns>
        Task<List<SendOrderInfoPerformanceDto>> GetTopTenHospitalSendOrderPerformance();
        /// <summary>
        /// 获取总派单量
        /// </summary>
        /// <returns></returns>
        Task<decimal> GetTotalSendCount();

        /// <summary>
        /// 根据派单人获取总派单量
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalSendCountByEmployeeAsync(int employeeId, DateTime startDate, DateTime endDate);
        /// <summary>
        /// 根据内容平台id获取派单列表
        /// </summary>
        /// <param name="contentplateformId"></param>
        /// <returns></returns>
        Task<FxPageInfo<SimpleSendOrderInfoDto>> GetSendOrderInfoListByContentplateformIdAsync(QuerySendOrderInfoListDto query);
        /// <summary>
        /// 修改派单订单状态
        /// </summary>
        /// <param name="sendOrderId"></param>
        /// <param name="OrderStatus"></param>
        /// <returns></returns>
        Task UpdateSendOrderStatusAsync(int sendOrderId,int OrderStatus);
        
    }
}
