﻿using Fx.Amiya.Dto.TikTokUserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Amiya.Dto.AmiyaOperationsBoardService;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Result;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Input;
using Fx.Amiya.Dto.HospitalPerformance;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.Dto.Performance;

namespace Fx.Amiya.IService
{
    public interface IAmiyaOperationsBoardService
    {
        #region  运营主看板

        #region 【业绩】
        /// <summary>
        /// 获取时间进度和总业绩
        /// </summary>
        /// <returns></returns>
        Task<OperationTotalAchievementDataDto> GetTotalAchievementAndDateScheduleAsync(QueryOperationDataDto query);
        /// <summary>
        /// 根据条件获取新老客业绩占比
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetNewOrOldCustomerCompareDataDto> GetNewOrOldCustomerCompareDataAsync(QueryOperationDataDto query);

        /// <summary>
        /// 根据条件获取助理与机构新老客业绩对比情况
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<NewOrOldCustomerPerformanceDataListDto> GetNewOrOldCustomerCompareByEmployeeAndHospitalAsync(QueryOperationDataDto query);
        #endregion
        #region 【流量】
        Task<OperationTotalFlowRateDataDto> GetCustomerDataAsync(QueryOperationDataDto query);

        Task<OperationBoardContentPlatFormDataDto> GetFlowRateByContentPlatFormCompareDataAsync(QueryOperationDataDto query);

        Task<CustomerFlowRateDataListDto> GetCustomerFlowRateByEmployeeAndHospitalAsync(QueryCustomerFlowRateWithEmployeeAndHospitalDto query);

        Task<GetFlowRateByContentPlatformDataDto> GetFlowRateByContentPlatformAsync(QueryOperationDataDto query);

        Task<GetFlowRateDetailsByContentPlatformDataDto> GetFlowRateDetailsByContentPlatformAsync(QueryOperationDataDto query);
        Task<List<AssitantTargetCompleteDto>> GetAssitantTargetCompleteAsync(QueryAssistantTargetCompleteDataDto query);
        #endregion

        #region 助理运营看板
        Task<AssistantPerformanceDto> GetAssitantPerformanceAsync(QueryAssistantPerformanceDto query);
        Task<AssistantPerformanceBrokenLineDto> GetAssistantPerformanceBrokenLineDto(QueryAssistantPerformanceDto query);
        Task<AssistantOperationDataDto> GetAssistantPerformanceFilterDataAsync(QueryAssistantPerformanceFilterDataDto query);
        Task<AssistantPerformanceAnalysisDataDto> GetAssistantPerformanceAnalysisDataAsync(QueryAssistantPerformanceDto query);
        Task<AssiatantTargetCompleteAndPerformanceRateDto> GetAssiatantTargetCompleteAndPerformanceRateDataAsync(QueryAssistantPerformanceDto query);
        Task<List<AssistantHospitalPerformanceDto>> GetAssistantHospitalPerformanceDataAsync(QueryAssistantPerformanceDto query);
        Task<AssistantHospitalCluesDataDto> GetAssistantHospitalCluesDataAsync(QueryAssistantHospitalCluesDataDto query);
        /// <summary>
        /// 获取助理分诊数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<AssistantDistributeConsulationDto> GetAssistantDistributeConsulationDataAsync(QueryAssistantPerformanceDto query);
        /// <summary>
        /// 获取助理分诊折线图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<AssistantDistributeConsulationBrokenLineDto> GetAssistantDistributeConsulationBrokenLineDataAsync(QueryAssistantPerformanceDto query);
        /// <summary>
        /// 获取助理转化周期柱状图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<AssistantTransformCycleDataDto> GetAssistantTransformCycleDataAsync(QueryAssistantPerformanceDto query);
        /// <summary>
        /// 获取运营看板转化周期柱状图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<AssistantTransformCycleDataDto> GetLiveAnchorTransformCycleDataAsync(QueryLiveAnchorPerformanceDto query);

        #endregion

        #region 行政客服运营看板

        Task<AdminCustomerServiceCustomerTypeDto> GetAdminCustomerServiceCustomerTypeDataAsync(QueryAssistantPerformanceDto query);
        Task<AdminCustomerServiceCustomerTypeDto> GetAdminCustomerServiceCustomerTypeAddWechatDataAsync(QueryAssistantPerformanceDto query);
        Task<AdminCustomerServiceCustomerTypeBrokenLineDataDto> GetAdminCustomerServiceCustomerTypeBrokenLineDataAsync(QueryAssistantPerformanceDto query);
        Task<AdminCustomerFilterDataDto> GetAdminCustomerFilterDataAsync(QueryAssistantPerformanceDto query);
        Task<AdminCustomerAnalysisDataDto> GetAdminCustomerAnalysisDataAsync(QueryAssistantPerformanceDto query);
        Task<AdminCustomerAssistantDisAndAddVDataDto> GetAdminCustomerAssistantDisAndAddVDataAsync(QueryAssistantPerformanceDto query);
        #endregion

        #endregion

        #region 公司看板
        /// <summary>
        /// 获取公司看板业绩情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<CompanyPerformanceDataDto>> GetCompanyPerformanceDataAsync(QueryAmiyaCompanyOperationsDataDto query);

        /// <summary>
        /// 获取公司看板获客情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<CompanyCustomerAcquisitionDataDto>> GetCompanyCustomerAcquisitionDataAsync(QueryAmiyaCompanyOperationsDataDto query);

        /// <summary>
        /// 获取公司看板运营情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<CompanyOperationsDataDto>> GetCompanyOperationsDataAsync(QueryAmiyaCompanyOperationsDataDto query);

        /// <summary>
        /// 获取公司看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<CompanyIndicatorConversionDataDto>> GetCompanyIndicatorConversionDataAsync(QueryAmiyaCompanyOperationsDataDto query);
        /// <summary>
        /// 获取公司当月新客分诊转化情况
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<List<CompanyNewCustomerConversionDataDto>> GetCompanyNewCustomerConversionDataAsync(QueryAmiyaCompanyOperationsDataDto query);
        /// <summary>
        /// 获取公司历史分诊新客转化情况数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<List<CompanyNewCustomerConversionDataDto>> GetHistoryNewCustomerConversionDataAsync(QueryAmiyaCompanyOperationsDataDto query);
        /// <summary>
        /// 获取流量转化和客户转化情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<FlowTransFormDataDto>> GetFlowTransFormDataAsync(QueryTransformDataDto query);
        /// <summary>
        /// 获取助理流量转化和客户转化情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<FlowTransFormDataDto>> GetAssistantFlowTransFormDataAsync(QueryTransformDataDto query);
        /// <summary>
        /// 根据时间获取全国机构运营数据概况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        Task<List<HospitalPerformanceDto>> GetHospitalPerformanceByDateAsync(QueryHospitalTransformDataDto query);
        #endregion

        #region 助理看板
        /// <summary>
        /// 获取助理看板业绩情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<AssistantPerformanceDataDto>> GetAssistantPerformanceDataAsync(QueryAmiyaAssistantOperationsDataDto query);

        /// <summary>
        /// 获取助理看板获客情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<AssistantCustomerAcquisitionDataDto>> GetAssistantCustomerAcquisitionDataAsync(QueryAmiyaAssistantOperationsDataDto query);

        /// <summary>
        /// 获取助理看板运营情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<AssistantOperationsDataDto>> GetAssistantOperationsDataAsync(QueryAmiyaAssistantOperationsDataDto query);

        /// <summary>
        /// 获取助理看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<AssistantIndicatorConversionDataDto>> GetAssistantIndicatorConversionDataAsync(QueryAmiyaAssistantOperationsDataDto query);
        

        #endregion
        /// <summary>
        /// 获取助理新客上门人数和目标完成率
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<NewCustomerToHospiatlAndTargetCompleteDto> GetNewCustomerToHospiatlAndTargetCompleteAsync(QueryNewCustomerToHospiatlAndTargetCompleteDto query);
        #region 【历史版本】

        ///// <summary>
        ///// 获取客户运营情况数据
        ///// </summary>
        ///// <returns></returns>
        //Task<GetCustomerAnalizeDataDto> GetCustomerAnalizeDataAsync(QueryOperationDataDto query);


        ///// <summary>
        ///// 获取客户指标转化数据
        ///// </summary>
        ///// <returns></returns>
        //Task<GetCustomerIndexTransformationResultDto> GetCustomerIndexTransformationDataAsync(QueryOperationDataDto query);


        ///// <summary>
        ///// 获取助理业绩分析数据
        ///// </summary>
        ///// <returns></returns>
        //Task<GetEmployeePerformanceAnalizeDataDto> GetEmployeePerformanceAnalizeDataAsync(QueryOperationDataDto query);


        #endregion
    }
}
