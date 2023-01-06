﻿using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IContentPlatFormOrderDealInfoService
    {
        Task<FxPageInfo<ContentPlatFormOrderDealInfoDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, DateTime? sendStartDate, DateTime? sendEndDate, int? consultationType, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, bool? isToHospital, DateTime? tohospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, bool? isDeal, int? lastDealHospitalId, bool? isAccompanying, bool? isOldCustomer, int? CheckState, bool? isReturnBakcPrice, DateTime? returnBackPriceStartDate, DateTime? returnBackPriceEndDate, int? customerServiceId, string keyWord, int employeeId, int pageNum, int pageSize);

        Task<FxPageInfo<ContentPlatFormOrderDealInfoDto>> GetContentPlatFormOrderDealInfoByReconciliationDocumentsIdAsync(string reconciliationDocumentsId, int pageNum, int pageSize);
        Task<List<ContentPlatFormOrderDealInfoDto>> GetOrderDealInfoListReportAsync(DateTime? startDate, DateTime? endDate, DateTime? sendStartDate, DateTime? sendEndDate, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? consultationType, bool? isToHospital, DateTime? tohospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, bool? isDeal, int? lastDealHospitalId, bool? isAccompanying, bool? isOldCustomer, int? CheckState, bool? isReturnBakcPrice, DateTime? returnBackPriceStartDate, DateTime? returnBackPriceEndDate, int? customerServiceId, string keyWord, int employeeId, bool hidePhone);
        Task<FxPageInfo<ContentPlatFormOrderDealInfoDto>> GetListWithPageAsync(string contentPlafFormOrderId, int pageNum, int pageSize);
        Task AddAsync(AddContentPlatFormOrderDealInfoDto addDto);
        Task<ContentPlatFormOrderDealInfoDto> GetByIdAsync(string id);

        Task UpdateAsync(UpdateContentPlatFormOrderDealInfoDto updateDto);

        /// <summary>
        /// 更新新/老客数据
        /// </summary>
        /// <param name="orderDealId"></param>
        /// <param name="isOldCustomer"></param>
        /// <returns></returns>
        Task UpdateIsOldCustomerAsync(string orderDealId, bool isOldCustomer);

        Task DeleteAsync(string id);
        Task<List<ContentPlatFormOrderDealInfoDto>> GetByOrderIdAsync(string orderId);
        Task CheckAsync(UpdateContentPlatFormOrderDealInfoDto updateDto);

        Task SettleAsync(UpdateContentPlatFormOrderDealInfoDto updateDto);
        /// <summary>
        /// 根据对账单id批量回款
        /// </summary>
        /// <param name="reconciliationDocumentsList"></param>
        /// <returns></returns>
        Task<List<OrderReturnBackPriceDto>> SettleListAsync(ReconciliationDocumentsReturnBackPriceDto reconciliationDocumentsList);
        /// <summary>
        /// 获取当日上门成交业绩
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderDealInfoDto>> GetTodaySendPerformanceAsync(int liveAnchorId, DateTime recordDate);
        /// <summary>
        /// 查询总业绩
        /// </summary>
        /// <param name="IsOldCustomer">新老客</param>
        /// <returns></returns>
        Task<decimal> GetPerformance(bool? IsOldCustomer);
        /// <summary>
        /// 新客上门总人数
        /// </summary>
        /// <returns></returns>
        Task<decimal> GetNewCustomerToHospitalCount();
        /// <summary>
        /// 新客成交总人数
        /// </summary>
        /// <returns></returns>
        Task<decimal> GetNewCustomerDealCount();

        /// <summary>
        /// 根据到院id获取当日上门成交业绩
        /// </summary>
        /// <param name="recordDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderDealInfoDto>> GetTodaySendPerformanceByHospitalIdAsync(List<int> hospitalId, DateTime recordDate);

        /// <summary>>
        /// 根据到院id获取当月上门成交业绩
        /// </summary>
        /// <param name="hospitalIds"></param>
        /// <param name="recordDate"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderDealInfoDto>> GetMonthSendPerformanceByHospitalIdListAsync(List<int> hospitalIds, DateTime recordDate);
        /// <summary>
        /// 根据到院id和时间获取指定月份成交量
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="recordDate"></param>
        /// <returns></returns>
        Task<int> GetMonthSendPerformanceByHospitalIdAsync(int hospitalId,int year, int month);
        /// <summary>
        /// 根据到院id和时间获取指定年份成交量
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        Task<int> GetYearSendPerformanceByHospitalIdAsync(int hospitalId, int year);
        /// <summary>
        /// 根据到院id获取总成交量
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<int> GetSendPerformanceByHospitalIdAsync(int hospitalId);
        /// <summary>
        /// 根据到院id与月份获取上门成交业绩
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderDealInfoDto>> GetSendPerformanceByHospitalIdAndMonthAsync(int hospitalId, int year, int month);



        #region【业绩板块】

        /// <summary>
        /// 根据主播获取指定年月的业绩(可选择是否筛选新老客)
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCustomer"></param>
        /// <param name="LiveAnchorIds">各个平台主播id集合</param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderDealInfoDto>> GetPerformanceByYearAndMonth(int year, int month, bool? isCustomer, List<int> LiveAnchorIds);


        /// <summary>
        /// 获取派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSend">历史/当月派单,true为历史派单当月成交，false为当月派单当月成交</param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderDealInfoDto>> GetSendAndDealPerformanceByYearAndMonth(int year, int month, bool? isOldSend, List<int> liveAnchorIds);

        /// <summary>
        /// 按月筛选新老客数据
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="isCustomer">筛选新老客(传null不筛选)</param>
        /// <param name="LiveAnchorIds">各个平台主播id集合</param>
        /// <returns></returns>
        Task<List<PerformanceInfoByDateDto>> GetPerformanceBrokenLineAsync(int year, int month, bool? isCustomer, List<int> LiveAnchorIds);

        /// <summary>
        /// 获取成交情况折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSend"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHistoryAndThisMonthOrderPerformance(int year, int month, bool? isOldSend, List<int> liveAnchorIds);


        /// <summary>
        /// 根据主播获取分组独立/协助业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isAssist"></param>
        /// <param name="LiveAnchorIds"></param>
        /// <param name="amiyaEmployeeId"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderDealInfoDto>> GetIndependentOrAssistPerformanceByYearAndMonth(int year, int month, bool? isAssist, List<int> LiveAnchorIds, int amiyaEmployeeId);

        /// <summary>
        /// 获取主播客单价
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldCustomer"></param>
        /// <param name="LiveAnchorIds"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetGuestUnitPricePerformanceBrokenLineAsync(int year, int month, bool? isOldCustomer, List<int> LiveAnchorIds);

        /// <summary>
        /// 根据条件获取独立/协助业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isAssist"></param>
        /// <param name="LiveAnchorIds"></param>
        /// <param name="amiyaEmployeeId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetIndependenceOrAssistAsync(int year, int month, bool? isAssist, List<int> LiveAnchorIds, int amiyaEmployeeId);


        #endregion

        #region 【分组业绩板块】
        #endregion


        #region 全国机构top10运营占比
        /// <summary>
        /// 获取总业绩业绩前10的医院业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenHospitalTotalPerformance();

        /// <summary>
        /// 获取新客业绩前10的医院业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenNewCustomerPerformance();


        /// <summary>
        /// 获取老客业绩前10的医院业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenOldCustomerPerformance();


        /// <summary>
        /// 获取新客上门前10的医院业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenNewCustomerToHospitalPformance();

        /// <summary>
        /// 获取新客成交人数前10的医院业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenNewCustomerDealPerformance();
        #endregion

        #region 城市top10运营占比
        /// <summary>
        /// 获取总业绩业绩前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityTotalPerformance();

        /// <summary>
        /// 获取新客业绩前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityNewCustomerPerformance();


        /// <summary>
        /// 获取老客业绩前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityOldCustomerPerformance();


        /// <summary>
        /// 获取新客上门前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityNewCustomerToHospitalPformance();

        /// <summary>
        /// 获取新客成交人数前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityNewCustomerDealPerformance();
        #endregion

        #region 【对账单板块】
        Task<List<UnCheckHospitalOrderDto>> GetUnCheckHospitalOrderAsync(DateTime? startDate, DateTime? endDate, int? hospitalId);
        #endregion
    }
}
