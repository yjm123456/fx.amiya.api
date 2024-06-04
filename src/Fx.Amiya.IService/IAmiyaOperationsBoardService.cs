using Fx.Amiya.Dto.TikTokUserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Amiya.Dto.AmiyaOperationsBoardService;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Result;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Input;
using Fx.Amiya.Dto.HospitalPerformance;

namespace Fx.Amiya.IService
{
    public interface IAmiyaOperationsBoardService
    {
        #region  运营主看板
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
        Task<GetNewOrOldCustomerCompareDataDto> GetNewOrOldCustomerCompareDataVoAsync(QueryOperationDataDto query);

        /// <summary>
        /// 获取获客情况数据
        /// </summary>
        /// <returns></returns>
         Task<GetCustomerDataDto> GetCustomerDataAsync(QueryOperationDataDto query);
       

        /// <summary>
        /// 获取客户运营情况数据
        /// </summary>
        /// <returns></returns>
         Task<GetCustomerAnalizeDataDto> GetCustomerAnalizeDataAsync(QueryOperationDataDto query);
       

        /// <summary>
        /// 获取客户指标转化数据
        /// </summary>
        /// <returns></returns>
         Task<GetCustomerIndexTransformationResultDto> GetCustomerIndexTransformationDataAsync(QueryOperationDataDto query);
        

        /// <summary>
        /// 获取助理业绩分析数据
        /// </summary>
        /// <returns></returns>
         Task<GetEmployeePerformanceAnalizeDataDto> GetEmployeePerformanceAnalizeDataAsync(QueryOperationDataDto query);
       


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
        Task<List<FlowTransFormDataVo>> GetFlowTransFormDataAsync(QueryTransformDataDto query);
        /// <summary>
        /// 获取助理流量转化和客户转化情况数据
        /// </summary>
        /// <returns></returns>
        Task<List<FlowTransFormDataVo>> GetAssistantFlowTransFormDataAsync(QueryTransformDataDto query);
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
    }
}
