using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input;
using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 啊美雅运营看板
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaOperationsBoardController : ControllerBase
    {

        #region  运营主看板
        /// <summary>
        /// 获取时间进度和总业绩
        /// </summary>
        /// <returns></returns>
        [HttpGet("getTotalAchievementAndDateSchedule")]
        public async Task<ResultData<OperationTotalAchievementDataVo>> GetTotalAchievementAndDateScheduleAsync([FromQuery] QueryOperationDataVo query)
        {
            OperationTotalAchievementDataVo result = new OperationTotalAchievementDataVo();
            return ResultData<OperationTotalAchievementDataVo>.Success().AddData("data", result);
        }

        /// <summary>
        /// 获取获客情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCustomerData")]
        public async Task<ResultData<GetCustomerDataVo>> GetCustomerDataAsync([FromQuery] QueryOperationDataVo query)
        {
            return ResultData<GetCustomerDataVo>.Success().AddData("data", new GetCustomerDataVo());
        }
        
        /// <summary>
        /// 获取客户运营情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCustomerAnalizeData")]
        public async Task<ResultData<GetCustomerAnalizeDataVo>> GetCustomerAnalizeDataAsync([FromQuery] QueryOperationDataVo query)
        {
            return ResultData<GetCustomerAnalizeDataVo>.Success().AddData("data", new GetCustomerAnalizeDataVo());
        }

        /// <summary>
        /// 获取客户指标转化数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCustomerIndexTransformationData")]
        public async Task<ResultData<GetCustomerIndexTransformationDataVo>> GetCustomerIndexTransformationDataAsync([FromQuery] QueryOperationDataVo query)
        {
            return ResultData<GetCustomerIndexTransformationDataVo>.Success().AddData("data", new GetCustomerIndexTransformationDataVo());
        }

        /// <summary>
        /// 获取助理业绩分析数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getEmployeePerformanceAnalizeData")]
        public async Task<ResultData<GetEmployeePerformanceAnalizeData>> GetEmployeePerformanceAnalizeDataAsync([FromQuery] QueryOperationDataVo query)
        {
            return ResultData<GetEmployeePerformanceAnalizeData>.Success().AddData("data", new GetEmployeePerformanceAnalizeData());
        }


        #endregion

        #region 公司看板
        /// <summary>
        /// 获取公司看板业绩情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("companyPerformanceData")]
        public async Task<ResultData<List<CompanyPerformanceDataVo>>> GetCompanyPerformanceDataAsync([FromQuery] QueryAmiyaCompanyOperationsDataVo query)
        {
            return ResultData<List<CompanyPerformanceDataVo>>.Success().AddData("data", new List<CompanyPerformanceDataVo>());
        }
        /// <summary>
        /// 获取公司看板获客情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("companyCustomerAcquisition")]
        public async Task<ResultData<List<CompanyCustomerAcquisitionDataVo>>> GetCompanyCustomerAcquisitionDataAsync([FromQuery] QueryAmiyaCompanyOperationsDataVo query)
        {
            return ResultData<List<CompanyCustomerAcquisitionDataVo>>.Success().AddData("data", new List<CompanyCustomerAcquisitionDataVo>());
        }
        /// <summary>
        /// 获取公司看板运营情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("companyOperationsData")]
        public async Task<ResultData<List<CompanyOperationsDataVo>>> GetCompanyOperationsDataAsync([FromQuery] QueryAmiyaCompanyOperationsDataVo query)
        {
            return ResultData<List<CompanyOperationsDataVo>>.Success().AddData("data", new List<CompanyOperationsDataVo>());
        }
        /// <summary>
        /// 获取公司看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("companyIndicatorConversionData")]
        public async Task<ResultData<List<CompanyIndicatorConversionDataVo>>> GetCompanyIndicatorConversionDataAsync([FromQuery] QueryAmiyaCompanyOperationsDataVo query)
        {
            return ResultData<List<CompanyIndicatorConversionDataVo>>.Success().AddData("data", new List<CompanyIndicatorConversionDataVo>());
        }
        #endregion

        #region 助理看板
        /// <summary>
        /// 获取助理看板业绩情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("assistantPerformanceData")]
        public async Task<ResultData<List<AssistantPerformanceDataVo>>> GetAssistantPerformanceDataAsync([FromQuery] QueryAmiyaAssistantOperationsDataVo query)
        {
            return ResultData<List<AssistantPerformanceDataVo>>.Success().AddData("data", new List<AssistantPerformanceDataVo>());
        }
        /// <summary>
        /// 获取助理看板获客情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("assistantCustomerAcquisition")]
        public async Task<ResultData<List<AssistantCustomerAcquisitionDataVo>>> GetAssistantCustomerAcquisitionDataAsync([FromQuery] QueryAmiyaAssistantOperationsDataVo query)
        {
            return ResultData<List<AssistantCustomerAcquisitionDataVo>>.Success().AddData("data", new List<AssistantCustomerAcquisitionDataVo>());
        }
        /// <summary>
        /// 获取助理看板运营情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("assistantOperationsData")]
        public async Task<ResultData<List<AssistantOperationsDataVo>>> GetAssistantOperationsDataAsync([FromQuery] QueryAmiyaAssistantOperationsDataVo query)
        {
            return ResultData<List<AssistantOperationsDataVo>>.Success().AddData("data", new List<AssistantOperationsDataVo>());
        }
        /// <summary>
        /// 获取助理看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("assistantIndicatorConversionData")]
        public async Task<ResultData<List<AssistantIndicatorConversionDataVo>>> GetAssistantIndicatorConversionDataAsync([FromQuery] QueryAmiyaAssistantOperationsDataVo query)
        {
            return ResultData<List<AssistantIndicatorConversionDataVo>>.Success().AddData("data", new List<AssistantIndicatorConversionDataVo>());
        }
        #endregion
    }
}
