using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input;
using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result;
using Fx.Amiya.Dto.AmiyaOperationsBoardService;
using Fx.Amiya.IService;
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
        private readonly IAmiyaOperationsBoardServiceService amiyaOperationsBoardServiceService;
        private readonly ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService;
        public AmiyaOperationsBoardController(IAmiyaOperationsBoardServiceService amiyaOperationsBoardServiceService, ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService)
        {
            this.amiyaOperationsBoardServiceService = amiyaOperationsBoardServiceService;
            this.liveAnchorMonthlyTargetLivingService = liveAnchorMonthlyTargetLivingService;
        }
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
        public async Task<ResultData<List<GetCustomerIndexTransformationResultVo>>> GetCustomerIndexTransformationDataAsync([FromQuery] QueryOperationDataVo query)
        {
            GetCustomerIndexTransformationDataVo getData = new GetCustomerIndexTransformationDataVo();
            List<GetCustomerIndexTransformationResultVo> result = new List<GetCustomerIndexTransformationResultVo>();
            //参数转换赋值
            GetCustomerIndexTransformationResultVo getAddCardNum = new GetCustomerIndexTransformationResultVo();
            getAddCardNum.Name = "下卡量";
            getAddCardNum.Value = 86;
            result.Add(getAddCardNum);
            GetCustomerIndexTransformationResultVo getRefundCardNum = new GetCustomerIndexTransformationResultVo();
            getRefundCardNum.Name = "退卡量";
            getRefundCardNum.Value = 6;
            result.Add(getRefundCardNum);
            GetCustomerIndexTransformationResultVo getDistributeConsulationNum = new GetCustomerIndexTransformationResultVo();
            getDistributeConsulationNum.Name = "分诊量";
            getDistributeConsulationNum.Value = 70;
            result.Add(getDistributeConsulationNum);

            return ResultData<List<GetCustomerIndexTransformationResultVo>>.Success().AddData("data", result);
        }

        /// <summary>
        /// 获取助理业绩分析数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getEmployeePerformanceAnalizeData")]
        public async Task<ResultData<GetEmployeePerformanceAnalizeDataVo>> GetEmployeePerformanceAnalizeDataAsync([FromQuery] QueryOperationDataVo query)
        {
            return ResultData<GetEmployeePerformanceAnalizeDataVo>.Success().AddData("data", new GetEmployeePerformanceAnalizeDataVo());
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
            QueryAmiyaCompanyOperationsDataDto querDto = new QueryAmiyaCompanyOperationsDataDto();
            querDto.StartDate = query.StartDate;
            querDto.EndDate= query.EndDate;
            querDto.Unit = query.Unit;
            querDto.LiveAnchorIds = query.LiveAnchorIds;
            var data=await amiyaOperationsBoardServiceService.GetCompanyPerformanceDataAsync(querDto);
            var res = data.Select(e => new CompanyPerformanceDataVo {
                GroupName = e.GroupName,
                CurrentMonthNewCustomerPerformance = e.CurrentMonthNewCustomerPerformance,
                NewCustomerPerformanceTarget=e.NewCustomerPerformanceTarget,
                NewCustomerPerformanceTargetComplete=e.NewCustomerPerformanceTargetComplete,
                CurrentMonthOldCustomerPerformance=e.CurrentMonthOldCustomerPerformance,
                OldCustomerTarget=e.OldCustomerTarget,
                OldCustomerTargetComplete=e.OldCustomerTargetComplete,
                TotalPerformance=e.TotalPerformance,
                TotalPerformanceTarget=e.TotalPerformanceTarget,
                TotalPerformanceTargetComplete=e.TotalPerformanceTargetComplete
            }).ToList();
            return ResultData<List<CompanyPerformanceDataVo>>.Success().AddData("data", res);
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
            QueryAmiyaCompanyOperationsDataDto querDto = new QueryAmiyaCompanyOperationsDataDto();
            querDto.StartDate = query.StartDate;
            querDto.EndDate = query.EndDate;
            querDto.Unit = query.Unit;
            querDto.LiveAnchorIds = query.LiveAnchorIds;
            var data = await amiyaOperationsBoardServiceService.GetCompanyOperationsDataAsync(querDto);
            var res = data.Select(e => new CompanyOperationsDataVo {
                GroupName=e.GroupName,
                SendOrder = e.SendOrder,
                SendOrderTarget = e.SendOrderTarget,
                SendOrderTargetComplete = e.SendOrderTargetComplete,
                ToHospital = e.ToHospital,
                ToHospitalTarget = e.ToHospitalTarget,
                ToHospitalTargetComplete = e.ToHospitalTargetComplete,
                Deal = e.Deal,
                DealTarget = e.DealTarget,
                DealTargetComplete = e.DealTargetComplete,
            }).ToList();
            return ResultData<List<CompanyOperationsDataVo>>.Success().AddData("data", res);
        }
        /// <summary>
        /// 获取公司看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("companyIndicatorConversionData")]
        public async Task<ResultData<List<CompanyIndicatorConversionDataVo>>> GetCompanyIndicatorConversionDataAsync([FromQuery] QueryAmiyaCompanyOperationsDataVo query)
        {
            QueryAmiyaCompanyOperationsDataDto querDto = new QueryAmiyaCompanyOperationsDataDto();
            querDto.StartDate = query.StartDate;
            querDto.EndDate = query.EndDate;
            querDto.Unit = query.Unit;
            querDto.LiveAnchorIds = query.LiveAnchorIds;
            var data = await amiyaOperationsBoardServiceService.GetCompanyIndicatorConversionDataAsync(querDto);
            var res = data.Select(e=>new CompanyIndicatorConversionDataVo { 
                GroupName=e.GroupName,
                SevenDaySendOrderRate = e.SevenDaySendOrderRate,
                FifteenDaySendOrderRate = e.FifteenDaySendOrderRate,
                OldCustomerToHospitalRate = e.OldCustomerToHospitalRate,
                RePurchaseRate = e.RePurchaseRate,
                AddWechatRate = e.AddWechatRate,
                SendOrderRate = e.SendOrderRate,
                ToHospitalRate = e.ToHospitalRate,
                NewCustomerDealRate = e.NewCustomerDealRate,
                NewCustomerUnitPrice = e.NewCustomerUnitPrice,
                OldCustomerUnitPrice = e.OldCustomerUnitPrice,
            }).ToList();
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
