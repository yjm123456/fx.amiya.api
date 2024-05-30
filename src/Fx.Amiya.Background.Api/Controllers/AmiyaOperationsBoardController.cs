using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input;
using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result;
using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using Fx.Amiya.Dto.AmiyaOperationsBoardService;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Result;
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
        private readonly IAmiyaOperationsBoardService amiyaOperationsBoardService;
        private readonly ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService;
        private readonly ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        public AmiyaOperationsBoardController(IAmiyaOperationsBoardService amiyaOperationsBoardService, ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService, ILiveAnchorBaseInfoService liveAnchorBaseInfoService)
        {
            this.amiyaOperationsBoardService = amiyaOperationsBoardService;
            this.liveAnchorMonthlyTargetLivingService = liveAnchorMonthlyTargetLivingService;
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
        }
        #region  业绩
        /// <summary>
        /// 根据条件获取业绩数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getTotalAchievementAndDateSchedule")]
        public async Task<ResultData<OperationTotalAchievementDataVo>> GetTotalAchievementAndDateScheduleAsync([FromQuery] QueryOperationDataVo query)
        {
            OperationTotalAchievementDataVo result = new OperationTotalAchievementDataVo();
            QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
            queryOperationDataVo.startDate = query.startDate;
            queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            var data = await amiyaOperationsBoardService.GetTotalAchievementAndDateScheduleAsync(queryOperationDataVo);

            result.NewCustomerPerformance = data.NewCustomerPerformance;
            result.NewCustomerPerformanceCompleteRate = data.NewCustomerPerformanceCompleteRate;
            result.NewCustomerPerformanceYearOnYear = data.NewCustomerPerformanceYearOnYear;
            result.NewCustomerPerformanceChainRatio = data.NewCustomerPerformanceChainRatio;
            result.TodayNewCustomerPerformance = data.TodayNewCustomerPerformance;

            result.OldCustomerPerformance = data.OldCustomerPerformance;
            result.OldCustomerPerformanceCompleteRate = data.OldCustomerPerformanceCompleteRate;
            result.OldCustomerPerformanceYearOnYear = data.OldCustomerPerformanceYearOnYear;
            result.OldCustomerPerformanceChainRatio = data.OldCustomerPerformanceChainRatio;
            result.TodayOldCustomerPerformance = data.TodayOldCustomerPerformance;

            result.TotalPerformance = data.TotalPerformance;
            result.TotalPerformanceCompleteRate = data.TotalPerformanceCompleteRate;
            result.TotalPerformanceYearOnYear = data.TotalPerformanceYearOnYear;
            result.TotalPerformanceChainRatio = data.TotalPerformanceChainRatio;
            result.TodayTotalPerformance = data.TodayTotalPerformance;

            result.TotalPerformanceBrokenLineList = data.TotalPerformanceBrokenLineList.Select(x => new PerformanceBrokenLineListInfoVo
            {
                date = x.date,
                Performance = x.Performance
            }).ToList();
            result.NewCustomerPerformanceBrokenLineList = data.NewCustomerPerformanceBrokenLineList.Select(x => new PerformanceBrokenLineListInfoVo
            {
                date = x.date,
                Performance = x.Performance
            }).ToList();
            result.OldCustomerPerformanceBrokenLineList = data.OldCustomerPerformanceBrokenLineList.Select(x => new PerformanceBrokenLineListInfoVo
            {
                date = x.date,
                Performance = x.Performance
            }).ToList();
            return ResultData<OperationTotalAchievementDataVo>.Success().AddData("data", result);
        }

        /// <summary>
        /// 根据条件获取新老客业绩占比（分组）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getNewOrOldCustomerCompare")]
        public async Task<ResultData<GetNewOrOldCustomerCompareDataVo>> GetNewOrOldCustomerCompareDataVoAsync([FromQuery] QueryOperationDataVo query)
        {
            GetNewOrOldCustomerCompareDataVo result = new GetNewOrOldCustomerCompareDataVo();
            QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
            queryOperationDataVo.startDate = query.startDate;
            queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            var data = await amiyaOperationsBoardService.GetNewOrOldCustomerCompareDataVoAsync(queryOperationDataVo);
            result.TotalPerformanceNewCustomer = data.TotalPerformanceNewCustomer;
            result.TotalPerformanceOldCustomer = data.TotalPerformanceOldCustomer;
            result.GroupDaoDaoPerformanceNewCustomer = data.GroupDaoDaoPerformanceNewCustomer;
            result.GroupDaoDaoPerformanceOldCustomer = data.GroupDaoDaoPerformanceOldCustomer;
            result.GroupJiNaPerformanceNewCustomer = data.GroupJiNaPerformanceNewCustomer;
            result.GroupJiNaPerformanceOldCustomer = data.GroupJiNaPerformanceOldCustomer;
            return ResultData<GetNewOrOldCustomerCompareDataVo>.Success().AddData("data", result);
        }


        /// <summary>
        /// 根据条件获取新老客业绩占比（助理与机构）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getNewOrOldCustomerCompareByEmployeeAndHospital")]
        public async Task<ResultData<List<NewOrOldCustomerPerformanceDataVo>>> GetNewOrOldCustomerCompareByEmployeeAndHospitalDataVoAsync([FromQuery] QueryOperationDataVo query)
        {
            QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
            queryOperationDataVo.startDate = query.startDate;
            queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            // var data = await amiyaOperationsBoardService.GetNewOrOldCustomerCompareDataVoAsync(queryOperationDataVo);

            List<NewOrOldCustomerPerformanceDataVo> result = new List<NewOrOldCustomerPerformanceDataVo>();

            NewOrOldCustomerPerformanceDataVo result1 = new NewOrOldCustomerPerformanceDataVo();
            result1.NewCustomerPerformance=new List<int> ();
            result1.OldCustomerPerformance = new List<int>();
            result1.Name = new List<string>();
            result1.Code = "employee";
            result1.NewCustomerPerformance.Add(320);
            result1.NewCustomerPerformance.Add(301);
            result1.NewCustomerPerformance.Add(306);

            result1.OldCustomerPerformance.Add(120);
            result1.OldCustomerPerformance.Add(131);
            result1.OldCustomerPerformance.Add(106);

            result1.Name.Add("益达");
            result1.Name.Add("伊娜");
            result1.Name.Add("王小美");
            result.Add(result1);


            NewOrOldCustomerPerformanceDataVo result2 = new NewOrOldCustomerPerformanceDataVo();
            result2.NewCustomerPerformance = new List<int>();
            result2.OldCustomerPerformance = new List<int>();
            result2.Name = new List<string>();
            result2.Code = "hospital";
            result2.NewCustomerPerformance.Add(320);
            result2.NewCustomerPerformance.Add(302);
            result2.NewCustomerPerformance.Add(306);

            result2.OldCustomerPerformance.Add(220);
            result2.OldCustomerPerformance.Add(232);
            result2.OldCustomerPerformance.Add(206);

            result2.Name.Add("杭州维多");
            result2.Name.Add("杭州连天美");
            result2.Name.Add("杭州米兰");
            result.Add(result2);
            return ResultData<List<NewOrOldCustomerPerformanceDataVo>>.Success().AddData("data", result);
        }

        #endregion


        #region 流量

        #endregion


        #region 转化
        

        #endregion

        #region【历史版本】

        //#region 运营主看板

        ///// <summary>
        ///// 获取获客情况数据
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("getCustomerData")]
        //public async Task<ResultData<GetCustomerDataVo>> GetCustomerDataAsync([FromQuery] QueryOperationDataVo query)
        //{
        //    QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
        //    queryOperationDataVo.startDate = query.startDate;
        //    queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
        //    var data = await amiyaOperationsBoardService.GetCustomerDataAsync(queryOperationDataVo);
        //    GetCustomerDataVo result = new GetCustomerDataVo();
        //    result.AddCardNum = data.AddCardNum;
        //    result.RefundCardNum = data.RefundCardNum;
        //    result.DistributeConsulationNum = data.DistributeConsulationNum;
        //    result.AddWechatNum = data.AddWechatNum;
        //    return ResultData<GetCustomerDataVo>.Success().AddData("data", result);
        //}

        ///// <summary>
        ///// 获取客户运营情况数据
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("getCustomerAnalizeData")]
        //public async Task<ResultData<GetCustomerAnalizeDataVo>> GetCustomerAnalizeDataAsync([FromQuery] QueryOperationDataVo query)
        //{
        //    QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
        //    queryOperationDataVo.startDate = query.startDate;
        //    queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
        //    var data = await amiyaOperationsBoardService.GetCustomerAnalizeDataAsync(queryOperationDataVo);
        //    GetCustomerAnalizeDataVo result = new GetCustomerAnalizeDataVo();
        //    CustomerAnalizeByGroupVo sendNum = new CustomerAnalizeByGroupVo();
        //    sendNum.TotalNum = data.SendNum.TotalNum;
        //    sendNum.GroupDaoDao = data.SendNum.GroupDaoDao;
        //    sendNum.GroupJiNa = data.SendNum.GroupJiNa;
        //    result.SendNum = sendNum;

        //    CustomerAnalizeByGroupVo visitNum = new CustomerAnalizeByGroupVo();
        //    visitNum.TotalNum = data.VisitNum.TotalNum;
        //    visitNum.GroupDaoDao = data.VisitNum.GroupDaoDao;
        //    visitNum.GroupJiNa = data.VisitNum.GroupJiNa;
        //    result.VisitNum = visitNum;

        //    CustomerAnalizeByGroupVo dealNum = new CustomerAnalizeByGroupVo();
        //    dealNum.TotalNum = data.DealNum.TotalNum;
        //    dealNum.GroupDaoDao = data.DealNum.GroupDaoDao;
        //    dealNum.GroupJiNa = data.DealNum.GroupJiNa;
        //    result.DealNum = dealNum;
        //    return ResultData<GetCustomerAnalizeDataVo>.Success().AddData("data", result);
        //}

        ///// <summary>
        ///// 获取客户指标转化数据
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("getCustomerIndexTransformationData")]
        //public async Task<ResultData<List<GetCustomerIndexTransformationResultVo>>> GetCustomerIndexTransformationDataAsync([FromQuery] QueryOperationDataVo query)
        //{
        //    QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
        //    queryOperationDataVo.startDate = query.startDate;
        //    queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
        //    var data = await amiyaOperationsBoardService.GetCustomerIndexTransformationDataAsync(queryOperationDataVo);

        //    List<GetCustomerIndexTransformationResultVo> result = new List<GetCustomerIndexTransformationResultVo>();
        //    //参数转换赋值
        //    GetCustomerIndexTransformationResultVo getAddCardNum = new GetCustomerIndexTransformationResultVo();

        //    getAddCardNum.Name = "下卡量";
        //    getAddCardNum.Value = data.AddCardNum;
        //    result.Add(getAddCardNum);

        //    GetCustomerIndexTransformationResultVo getRefundCardNum = new GetCustomerIndexTransformationResultVo();
        //    getRefundCardNum.Name = "退卡量";
        //    getRefundCardNum.Value = data.RefundCardNum;
        //    result.Add(getRefundCardNum);

        //    GetCustomerIndexTransformationResultVo getDistributeConsulationNum = new GetCustomerIndexTransformationResultVo();
        //    getDistributeConsulationNum.Name = "分诊量";
        //    getDistributeConsulationNum.Value = data.DistributeConsulationNum;
        //    result.Add(getDistributeConsulationNum);

        //    GetCustomerIndexTransformationResultVo getAddWechatNum = new GetCustomerIndexTransformationResultVo();
        //    getAddWechatNum.Name = "加v量";
        //    getAddWechatNum.Value = data.AddWechatNum;
        //    result.Add(getAddWechatNum);

        //    GetCustomerIndexTransformationResultVo getSendOrderNum = new GetCustomerIndexTransformationResultVo();
        //    getSendOrderNum.Name = "派单量";
        //    getSendOrderNum.Value = data.SendOrderNum;
        //    result.Add(getSendOrderNum);

        //    GetCustomerIndexTransformationResultVo getVisitNum = new GetCustomerIndexTransformationResultVo();
        //    getVisitNum.Name = "上门量";
        //    getVisitNum.Value = data.VisitNum;
        //    result.Add(getVisitNum);

        //    GetCustomerIndexTransformationResultVo getDealNum = new GetCustomerIndexTransformationResultVo();
        //    getDealNum.Name = "成交量";
        //    getDealNum.Value = data.DealNum;
        //    result.Add(getDealNum);

        //    return ResultData<List<GetCustomerIndexTransformationResultVo>>.Success().AddData("data", result);
        //}

        ///// <summary>
        ///// 获取助理业绩分析数据
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("getEmployeePerformanceAnalizeData")]
        //public async Task<ResultData<GetEmployeePerformanceAnalizeDataVo>> GetEmployeePerformanceAnalizeDataAsync([FromQuery] QueryOperationDataVo query)
        //{
        //    QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
        //    queryOperationDataVo.startDate = query.startDate;
        //    queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
        //    var data = await amiyaOperationsBoardService.GetEmployeePerformanceAnalizeDataAsync(queryOperationDataVo);
        //    GetEmployeePerformanceAnalizeDataVo result = new GetEmployeePerformanceAnalizeDataVo();
        //    result.EmployeeDatas = data.EmployeeDatas.Select(x => new GetEmployeePerformanceDataVo
        //    {
        //        EmployeeName = x.EmployeeName,
        //        Performance = x.Performance,
        //        CompleteRate = x.CompleteRate,
        //    }).ToList();
        //    result.EmployeeDistributeConsulationNumAndAddWechats = data.EmployeeDistributeConsulationNumAndAddWechats.Select(x => new GetEmployeeDistributeConsulationNumAndAddWechatVo
        //    {
        //        EmployeeName = x.EmployeeName,
        //        DistributeConsulationNum = x.DistributeConsulationNum,
        //        AddWechatNum = x.AddWechatNum,
        //    }).OrderByDescending(x => x.DistributeConsulationNum).ToList();
        //    result.GetEmployeeCustomerAnalizes = data.GetEmployeeCustomerAnalizes.Select(x => new GetEmployeeCustomerAnalizeVo
        //    {
        //        EmployeeName = x.EmployeeName,
        //        SendOrderNum = x.SendOrderNum,
        //        VisitNum = x.VisitNum,
        //        DealNum = x.DealNum
        //    }).ToList();
        //    result.GetEmployeePerformanceRankings = data.GetEmployeePerformanceRankings.Select(x => new GetEmployeePerformanceRankingVo
        //    {
        //        EmployeeName = x.EmployeeName,
        //        Performance = x.Performance,
        //    }).ToList();
        //    return ResultData<GetEmployeePerformanceAnalizeDataVo>.Success().AddData("data", result);
        //}

        //#endregion

        //#region 公司看板
        /// <summary>
        /// 获取公司看板业绩情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("companyPerformanceData")]
        public async Task<ResultData<List<CompanyPerformanceDataVo>>> GetCompanyPerformanceDataAsync([FromQuery] QueryAmiyaCompanyOperationsDataVo query)
        {
            QueryAmiyaCompanyOperationsDataDto querDto = new QueryAmiyaCompanyOperationsDataDto();
            querDto.StartDate = query.StartDate;
            querDto.EndDate = query.EndDate;
            querDto.Unit = query.Unit;
            querDto.LiveAnchorIds = query.LiveAnchorIds;
            var data = await amiyaOperationsBoardService.GetCompanyPerformanceDataAsync(querDto);
            var res = data.Select(e => new CompanyPerformanceDataVo
            {
                GroupName = e.GroupName,
                CurrentMonthNewCustomerPerformance = e.CurrentMonthNewCustomerPerformance,
                NewCustomerPerformanceTarget = e.NewCustomerPerformanceTarget,
                NewCustomerPerformanceTargetComplete = e.NewCustomerPerformanceTargetComplete,
                CurrentMonthOldCustomerPerformance = e.CurrentMonthOldCustomerPerformance,
                OldCustomerTarget = e.OldCustomerTarget,
                OldCustomerTargetComplete = e.OldCustomerTargetComplete,
                TotalPerformance = e.TotalPerformance,
                TotalPerformanceTarget = e.TotalPerformanceTarget,
                TotalPerformanceTargetComplete = e.TotalPerformanceTargetComplete
            }).OrderBy(e => e.GroupName).ToList();
            return ResultData<List<CompanyPerformanceDataVo>>.Success().AddData("data", res);
        }
        /// <summary>
        /// 获取公司看板获客情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("companyCustomerAcquisition")]
        public async Task<ResultData<List<CompanyCustomerAcquisitionDataVo>>> GetCompanyCustomerAcquisitionDataAsync([FromQuery] QueryAmiyaCompanyOperationsDataVo query)
        {
            QueryAmiyaCompanyOperationsDataDto querDto = new QueryAmiyaCompanyOperationsDataDto();
            querDto.StartDate = query.StartDate;
            querDto.EndDate = query.EndDate;
            querDto.Unit = query.Unit;
            querDto.LiveAnchorIds = query.LiveAnchorIds;
            var data = await amiyaOperationsBoardService.GetCompanyCustomerAcquisitionDataAsync(querDto);
            var res = data.Select(e => new CompanyCustomerAcquisitionDataVo
            {
                GroupName = e.GroupName,
                OrderCard = e.OrderCard,
                OrderCardTarget = e.OrderCardTarget,
                OrderCardTargetComplete = e.OrderCardTargetComplete,
                RefundCard = e.RefundCard,
                OrderCardError = e.OrderCardError,
                AllocationConsulation = e.AllocationConsulation,
                AllocationConsulationTarget = e.AllocationConsulationTarget,
                AllocationConsulationTargetComplete = e.AllocationConsulationTargetComplete,
                AddWechat = e.AddWechat,
                AddWechatTarget = e.AddWechatTarget,
                AddWechatTargetComplete = e.AddWechatTargetComplete,
            }).OrderBy(e => e.GroupName).ToList();
            return ResultData<List<CompanyCustomerAcquisitionDataVo>>.Success().AddData("data", res);
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
            querDto.IsOldCustomer = query.IsOldCustomer;
            var data = await amiyaOperationsBoardService.GetCompanyOperationsDataAsync(querDto);
            var res = data.Select(e => new CompanyOperationsDataVo
            {
                GroupName = e.GroupName,
                SendOrder = e.SendOrder,
                SendOrderTarget = e.SendOrderTarget,
                SendOrderTargetComplete = e.SendOrderTargetComplete,
                ToHospital = e.ToHospital,
                ToHospitalTarget = e.ToHospitalTarget,
                ToHospitalTargetComplete = e.ToHospitalTargetComplete,
                Deal = e.Deal,
                DealTarget = e.DealTarget,
                DealTargetComplete = e.DealTargetComplete,
            }).OrderBy(e => e.GroupName).ToList();
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
            querDto.IsEffective = query.IsEffective;
            var data = await amiyaOperationsBoardService.GetCompanyIndicatorConversionDataAsync(querDto);
            var res = data.Select(e => new CompanyIndicatorConversionDataVo
            {
                GroupName = e.GroupName,
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
            }).OrderBy(e => e.GroupName).ToList();
            return ResultData<List<CompanyIndicatorConversionDataVo>>.Success().AddData("data", res);
        }

        /// <summary>
        /// 获取公司当月/历史新客分诊转换情况
        /// </summary>
        /// <returns></returns>
        [HttpGet("companyNewCustomerConversionData")]
        public async Task<ResultData<List<CompanyNewCustomerConversionDataVo>>> GetCompanyNewCustomerConversionDataAsync([FromQuery] QueryAmiyaCompanyOperationsDataVo query)
        {
            List<CompanyNewCustomerConversionDataDto> res = new List<CompanyNewCustomerConversionDataDto>();
            QueryAmiyaCompanyOperationsDataDto querDto = new QueryAmiyaCompanyOperationsDataDto();
            querDto.StartDate = query.StartDate;
            querDto.EndDate = query.EndDate;
            querDto.Unit = query.Unit;
            querDto.LiveAnchorIds = query.LiveAnchorIds;
            querDto.IsEffective = query.IsEffective;
            querDto.IsCurrentMonth = query.IsCurrentMonth;
            if (querDto.IsCurrentMonth.Value)
            {
                res = await amiyaOperationsBoardService.GetCompanyNewCustomerConversionDataAsync(querDto);
            }
            else
            {
                res = await amiyaOperationsBoardService.GetHistoryNewCustomerConversionDataAsync(querDto);
            }
            var data = res.Select(e => new CompanyNewCustomerConversionDataVo
            {
                GroupName = e.GroupName,
                SendOrderCount = e.SendOrderCount,
                DistributeConsulationNum = e.DistributeConsulationNum,
                AddWechatCount = e.AddWechatCount,
                AddWechatRate = e.AddWechatRate,
                SendOrderRate = e.SendOrderRate,
                ToHospitalCount = e.ToHospitalCount,
                ToHospitalRate = e.ToHospitalRate,
                DealCount = e.DealCount,
                DealRate = e.DealRate,
                Performance = e.Performance,
            }).OrderBy(e => e.GroupName).ToList();
            return ResultData<List<CompanyNewCustomerConversionDataVo>>.Success().AddData("data", data);
        }
        //#endregion

        //#region 助理看板
        /// <summary>
        /// 获取助理看板业绩情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("assistantPerformanceData")]
        public async Task<ResultData<List<AssistantPerformanceDataVo>>> GetAssistantPerformanceDataAsync([FromQuery] QueryAmiyaAssistantOperationsDataVo query)
        {
            QueryAmiyaAssistantOperationsDataDto queryDto = new QueryAmiyaAssistantOperationsDataDto();
            queryDto.Unit = query.Unit;
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            if (string.IsNullOrEmpty(query.LiveAnchorIds))
            {
                queryDto.LiveAnchorIds = (await liveAnchorBaseInfoService.GetValidAsync(true)).Select(e => e.Id).ToList();
            }
            else
            {
                queryDto.LiveAnchorIds = query.LiveAnchorIds.Split(",").ToList();
            }

            queryDto.IsOldCustomer = query.IsOldCustomer;
            queryDto.IsEffective = query.IsEffective;

            var data = await amiyaOperationsBoardService.GetAssistantPerformanceDataAsync(queryDto);
            var res = data.Select(e => new AssistantPerformanceDataVo
            {
                AssistantName = e.AssistantName,
                CurrentMonthNewCustomerPerformance = e.CurrentMonthNewCustomerPerformance,
                NewCustomerPerformanceTarget = e.NewCustomerPerformanceTarget,
                NewCustomerPerformanceTargetComplete = e.NewCustomerPerformanceTargetComplete,
                CurrentMonthOldCustomerPerformance = e.CurrentMonthOldCustomerPerformance,
                OldCustomerTarget = e.OldCustomerTarget,
                OldCustomerTargetComplete = e.OldCustomerTargetComplete,
                TotalPerformance = e.TotalPerformance,
                TotalPerformanceTarget = e.TotalPerformanceTarget,
                TotalPerformanceTargetComplete = e.TotalPerformanceTargetComplete,
            }).OrderBy(e => e.TotalPerformance).ToList();
            return ResultData<List<AssistantPerformanceDataVo>>.Success().AddData("data", res);
        }
        /// <summary>
        /// 获取助理看板获客情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("assistantCustomerAcquisition")]
        public async Task<ResultData<List<AssistantCustomerAcquisitionDataVo>>> GetAssistantCustomerAcquisitionDataAsync([FromQuery] QueryAmiyaAssistantOperationsDataVo query)
        {
            QueryAmiyaAssistantOperationsDataDto queryDto = new QueryAmiyaAssistantOperationsDataDto();
            queryDto.Unit = query.Unit;
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            if (string.IsNullOrEmpty(query.LiveAnchorIds))
            {
                queryDto.LiveAnchorIds = (await liveAnchorBaseInfoService.GetValidAsync(true)).Select(e => e.Id).ToList();
            }
            else
            {
                queryDto.LiveAnchorIds = query.LiveAnchorIds.Split(",").ToList();
            }
            queryDto.IsOldCustomer = query.IsOldCustomer;
            queryDto.IsEffective = query.IsEffective;
            var data = await amiyaOperationsBoardService.GetAssistantCustomerAcquisitionDataAsync(queryDto);
            var res = data.Select(e => new AssistantCustomerAcquisitionDataVo
            {
                AssistantName = e.AssistantName,
                PotentialAllocationConsulation = e.PotentialAllocationConsulation,
                PotentialAllocationConsulationTarget = e.PotentialAllocationConsulationTarget,
                PotentialAllocationConsulationTargetComplete = e.PotentialAllocationConsulationTargetComplete,
                PotentialAddWechat = e.PotentialAddWechat,
                PotentialAddWechatTarget = e.PotentialAddWechatTarget,
                PotentialAddWechatTargetComplete = e.PotentialAddWechatTargetComplete,
                EffectiveAllocationConsulation = e.EffectiveAllocationConsulation,
                EffectiveAllocationConsulationTarget = e.EffectiveAllocationConsulationTarget,
                EffectiveAllocationConsulationTargetComplete = e.EffectiveAllocationConsulationTargetComplete,
                EffectiveAddWechat = e.EffectiveAddWechat,
                EffectiveAddWechatTarget = e.EffectiveAddWechatTarget,
                EffectiveAddWechatTargetComplete = e.EffectiveAddWechatTargetComplete,
            }).ToList();
            return ResultData<List<AssistantCustomerAcquisitionDataVo>>.Success().AddData("data", res);
        }
        /// <summary>
        /// 获取助理看板运营情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("assistantOperationsData")]
        public async Task<ResultData<List<AssistantOperationsDataVo>>> GetAssistantOperationsDataAsync([FromQuery] QueryAmiyaAssistantOperationsDataVo query)
        {
            QueryAmiyaAssistantOperationsDataDto queryDto = new QueryAmiyaAssistantOperationsDataDto();
            queryDto.Unit = query.Unit;
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            if (string.IsNullOrEmpty(query.LiveAnchorIds))
            {
                queryDto.LiveAnchorIds = (await liveAnchorBaseInfoService.GetValidAsync(true)).Select(e => e.Id).ToList();
            }
            else
            {
                queryDto.LiveAnchorIds = query.LiveAnchorIds.Split(",").ToList();
                queryDto.LiveAnchorIds = query.LiveAnchorIds.Split(",").ToList();
            }
            queryDto.IsOldCustomer = query.IsOldCustomer;
            queryDto.IsEffective = query.IsEffective;
            var data = await amiyaOperationsBoardService.GetAssistantOperationsDataAsync(queryDto);
            var res = data.Select(e => new AssistantOperationsDataVo
            {
                AssistantName = e.AssistantName,
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
            return ResultData<List<AssistantOperationsDataVo>>.Success().AddData("data", res);
        }
        /// <summary>
        /// 获取助理看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("assistantIndicatorConversionData")]
        public async Task<ResultData<List<AssistantIndicatorConversionDataVo>>> GetAssistantIndicatorConversionDataAsync([FromQuery] QueryAmiyaAssistantOperationsDataVo query)
        {
            QueryAmiyaAssistantOperationsDataDto queryDto = new QueryAmiyaAssistantOperationsDataDto();
            queryDto.Unit = query.Unit;
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            if (string.IsNullOrEmpty(query.LiveAnchorIds))
            {
                queryDto.LiveAnchorIds = (await liveAnchorBaseInfoService.GetValidAsync(true)).Select(e => e.Id).ToList();
            }
            else
            {
                queryDto.LiveAnchorIds = query.LiveAnchorIds.Split(",").ToList();
            }
            queryDto.IsOldCustomer = query.IsOldCustomer;
            queryDto.IsEffective = query.IsEffective;
            var data = await amiyaOperationsBoardService.GetAssistantIndicatorConversionDataAsync(queryDto);
            var res = data.Select(e => new AssistantIndicatorConversionDataVo
            {
                AssistantName = e.AssistantName,
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
            return ResultData<List<AssistantIndicatorConversionDataVo>>.Success().AddData("data", res);
        }
        //#endregion

        #endregion
    }
}
