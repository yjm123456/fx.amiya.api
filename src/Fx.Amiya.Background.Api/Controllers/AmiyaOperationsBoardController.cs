﻿using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input;
using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result;
using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using Fx.Amiya.Dto.AmiyaOperationsBoardService;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Input;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Result;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common.Extensions;
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
        /// 根据结束时间获取时间进度
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getTimeSpan")]
        public async Task<ResultData<decimal>> GetTimeSpanAsync([FromQuery] QueryOperationDataVo query)
        {
            decimal result = 0.00M;
            var date = DateTimeExtension.GetDatetimeSchedule(query.endDate.Value).FirstOrDefault();
            result = date.Value;
            return ResultData<decimal>.Success().AddData("data", result);
        }

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
        public async Task<ResultData<GetNewOrOldCustomerCompareDataVo>> GetNewOrOldCustomerCompareDataAsync([FromQuery] QueryOperationDataVo query)
        {
            GetNewOrOldCustomerCompareDataVo result = new GetNewOrOldCustomerCompareDataVo();
            QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
            queryOperationDataVo.startDate = query.startDate;
            queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            var data = await amiyaOperationsBoardService.GetNewOrOldCustomerCompareDataAsync(queryOperationDataVo);

            #region【部门】

            result.TotalBelongChannelPerformance = new OperationBoardBelongChannelPerformanceDataVo();
            result.GroupDaoDaoBelongChannelPerformance = new OperationBoardBelongChannelPerformanceDataVo();
            result.GroupJiNaBelongChannelPerformance = new OperationBoardBelongChannelPerformanceDataVo();

            result.TotalBelongChannelPerformance.BeforeLivingNumber = data.TotalBelongChannelPerformance.BeforeLivingNumber;
            result.TotalBelongChannelPerformance.BeforeLivingRate = data.TotalBelongChannelPerformance.BeforeLivingRate;
            result.TotalBelongChannelPerformance.LivingNumber = data.TotalBelongChannelPerformance.LivingNumber;
            result.TotalBelongChannelPerformance.LivingRate = data.TotalBelongChannelPerformance.LivingRate;
            result.TotalBelongChannelPerformance.AfterLivingNumber = data.TotalBelongChannelPerformance.AfterLivingNumber;
            result.TotalBelongChannelPerformance.AfterLivingRate = data.TotalBelongChannelPerformance.AfterLivingRate;
            result.TotalBelongChannelPerformance.OtherNumber = data.TotalBelongChannelPerformance.OtherNumber;
            result.TotalBelongChannelPerformance.OtherRate = data.TotalBelongChannelPerformance.OtherRate;
            result.TotalBelongChannelPerformance.TotalPerformanceNumber = data.TotalBelongChannelPerformance.TotalPerformanceNumber;

            result.GroupDaoDaoBelongChannelPerformance.BeforeLivingNumber = data.GroupDaoDaoBelongChannelPerformance.BeforeLivingNumber;
            result.GroupDaoDaoBelongChannelPerformance.BeforeLivingRate = data.GroupDaoDaoBelongChannelPerformance.BeforeLivingRate;
            result.GroupDaoDaoBelongChannelPerformance.LivingNumber = data.GroupDaoDaoBelongChannelPerformance.LivingNumber;
            result.GroupDaoDaoBelongChannelPerformance.LivingRate = data.GroupDaoDaoBelongChannelPerformance.LivingRate;
            result.GroupDaoDaoBelongChannelPerformance.AfterLivingNumber = data.GroupDaoDaoBelongChannelPerformance.AfterLivingNumber;
            result.GroupDaoDaoBelongChannelPerformance.AfterLivingRate = data.GroupDaoDaoBelongChannelPerformance.AfterLivingRate;
            result.GroupDaoDaoBelongChannelPerformance.OtherNumber = data.GroupDaoDaoBelongChannelPerformance.OtherNumber;
            result.GroupDaoDaoBelongChannelPerformance.OtherRate = data.GroupDaoDaoBelongChannelPerformance.OtherRate;
            result.GroupDaoDaoBelongChannelPerformance.TotalPerformanceNumber = data.GroupDaoDaoBelongChannelPerformance.TotalPerformanceNumber;

            result.GroupJiNaBelongChannelPerformance.BeforeLivingNumber = data.GroupJiNaBelongChannelPerformance.BeforeLivingNumber;
            result.GroupJiNaBelongChannelPerformance.BeforeLivingRate = data.GroupJiNaBelongChannelPerformance.BeforeLivingRate;
            result.GroupJiNaBelongChannelPerformance.LivingNumber = data.GroupJiNaBelongChannelPerformance.LivingNumber;
            result.GroupJiNaBelongChannelPerformance.LivingRate = data.GroupJiNaBelongChannelPerformance.LivingRate;
            result.GroupJiNaBelongChannelPerformance.AfterLivingNumber = data.GroupJiNaBelongChannelPerformance.AfterLivingNumber;
            result.GroupJiNaBelongChannelPerformance.AfterLivingRate = data.GroupJiNaBelongChannelPerformance.AfterLivingRate;
            result.GroupJiNaBelongChannelPerformance.OtherNumber = data.GroupJiNaBelongChannelPerformance.OtherNumber;
            result.GroupJiNaBelongChannelPerformance.OtherRate = data.GroupJiNaBelongChannelPerformance.OtherRate;
            result.GroupJiNaBelongChannelPerformance.TotalPerformanceNumber = data.GroupJiNaBelongChannelPerformance.TotalPerformanceNumber;
            #endregion

            #region【新老客】

            result.TotalNewOrOldCustomer = new OperationBoardGetNewOrOldCustomerCompareDataDetailsVo();
            result.GroupDaoDaoNewOrOldCustomer = new OperationBoardGetNewOrOldCustomerCompareDataDetailsVo();
            result.GroupJiNaNewOrOldCustomer = new OperationBoardGetNewOrOldCustomerCompareDataDetailsVo();

            result.TotalNewOrOldCustomer.TotalPerformanceNewCustomerNumber = data.TotalNewOrOldCustomer.TotalPerformanceNewCustomerNumber;
            result.TotalNewOrOldCustomer.TotalPerformanceNewCustomerRate = data.TotalNewOrOldCustomer.TotalPerformanceNewCustomerRate;
            result.TotalNewOrOldCustomer.TotalPerformanceOldCustomerNumber = data.TotalNewOrOldCustomer.TotalPerformanceOldCustomerNumber;
            result.TotalNewOrOldCustomer.TotalPerformanceOldCustomerRate = data.TotalNewOrOldCustomer.TotalPerformanceOldCustomerRate;
            result.TotalNewOrOldCustomer.TotalPerformanceNumber = data.TotalNewOrOldCustomer.TotalPerformanceNumber;

            result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNewCustomerNumber = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNewCustomerNumber;
            result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNewCustomerRate = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNewCustomerRate;
            result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceOldCustomerNumber = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceOldCustomerNumber;
            result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceOldCustomerRate = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceOldCustomerRate;
            result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNumber = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNumber;

            result.GroupJiNaNewOrOldCustomer.TotalPerformanceNewCustomerNumber = data.GroupJiNaNewOrOldCustomer.TotalPerformanceNewCustomerNumber;
            result.GroupJiNaNewOrOldCustomer.TotalPerformanceNewCustomerRate = data.GroupJiNaNewOrOldCustomer.TotalPerformanceNewCustomerRate;
            result.GroupJiNaNewOrOldCustomer.TotalPerformanceOldCustomerNumber = data.GroupJiNaNewOrOldCustomer.TotalPerformanceOldCustomerNumber;
            result.GroupJiNaNewOrOldCustomer.TotalPerformanceOldCustomerRate = data.GroupJiNaNewOrOldCustomer.TotalPerformanceOldCustomerRate;
            result.GroupJiNaNewOrOldCustomer.TotalPerformanceNumber = data.GroupJiNaNewOrOldCustomer.TotalPerformanceNumber;
            #endregion

            #region【有效/潜在】

            result.TotalIsEffictivePerformance = new OperationBoardGetIsEffictivePerformanceVo();
            result.GroupDaoDaoIsEffictivePerformance = new OperationBoardGetIsEffictivePerformanceVo();
            result.GroupJiNaIsEffictivePerformance = new OperationBoardGetIsEffictivePerformanceVo();

            result.TotalIsEffictivePerformance.EffictivePerformanceNumber = data.TotalIsEffictivePerformance.EffictivePerformanceNumber;
            result.TotalIsEffictivePerformance.EffictivePerformanceRate = data.TotalIsEffictivePerformance.EffictivePerformanceRate;
            result.TotalIsEffictivePerformance.NotEffictivePerformanceNumber = data.TotalIsEffictivePerformance.NotEffictivePerformanceNumber;
            result.TotalIsEffictivePerformance.NotEffictivePerformanceRate = data.TotalIsEffictivePerformance.NotEffictivePerformanceRate;
            result.TotalIsEffictivePerformance.TotalPerformanceNumber = data.TotalIsEffictivePerformance.TotalPerformanceNumber;

            result.GroupDaoDaoIsEffictivePerformance.EffictivePerformanceNumber = data.GroupDaoDaoIsEffictivePerformance.EffictivePerformanceNumber;
            result.GroupDaoDaoIsEffictivePerformance.EffictivePerformanceRate = data.GroupDaoDaoIsEffictivePerformance.EffictivePerformanceRate;
            result.GroupDaoDaoIsEffictivePerformance.NotEffictivePerformanceNumber = data.GroupDaoDaoIsEffictivePerformance.NotEffictivePerformanceNumber;
            result.GroupDaoDaoIsEffictivePerformance.NotEffictivePerformanceRate = data.GroupDaoDaoIsEffictivePerformance.NotEffictivePerformanceRate;
            result.GroupDaoDaoIsEffictivePerformance.TotalPerformanceNumber = data.GroupDaoDaoIsEffictivePerformance.TotalPerformanceNumber;

            result.GroupJiNaIsEffictivePerformance.EffictivePerformanceNumber = data.GroupJiNaIsEffictivePerformance.EffictivePerformanceNumber;
            result.GroupJiNaIsEffictivePerformance.EffictivePerformanceRate = data.GroupJiNaIsEffictivePerformance.EffictivePerformanceRate;
            result.GroupJiNaIsEffictivePerformance.NotEffictivePerformanceNumber = data.GroupJiNaIsEffictivePerformance.NotEffictivePerformanceNumber;
            result.GroupJiNaIsEffictivePerformance.NotEffictivePerformanceRate = data.GroupJiNaIsEffictivePerformance.NotEffictivePerformanceRate;
            result.GroupJiNaIsEffictivePerformance.TotalPerformanceNumber = data.GroupJiNaIsEffictivePerformance.TotalPerformanceNumber;
            #endregion

            #region【当月/历史】

            result.TotalIsHistoryPerformance = new OperationBoardGetIsHistoryPerformanceVo();
            result.GroupDaoDaoIsHistoryPerformance = new OperationBoardGetIsHistoryPerformanceVo();
            result.GroupJiNaIsHistoryPerformance = new OperationBoardGetIsHistoryPerformanceVo();

            result.TotalIsHistoryPerformance.HistoryPerformanceNumber = data.TotalIsHistoryPerformance.HistoryPerformanceNumber;
            result.TotalIsHistoryPerformance.HistoryPerformanceRate = data.TotalIsHistoryPerformance.HistoryPerformanceRate;
            result.TotalIsHistoryPerformance.ThisMonthPerformanceNumber = data.TotalIsHistoryPerformance.ThisMonthPerformanceNumber;
            result.TotalIsHistoryPerformance.ThisMonthPerformanceRate = data.TotalIsHistoryPerformance.ThisMonthPerformanceRate;
            result.TotalIsHistoryPerformance.TotalPerformanceNumber = data.TotalIsHistoryPerformance.TotalPerformanceNumber;

            result.GroupDaoDaoIsHistoryPerformance.HistoryPerformanceNumber = data.GroupDaoDaoIsHistoryPerformance.HistoryPerformanceNumber;
            result.GroupDaoDaoIsHistoryPerformance.HistoryPerformanceRate = data.GroupDaoDaoIsHistoryPerformance.HistoryPerformanceRate;
            result.GroupDaoDaoIsHistoryPerformance.ThisMonthPerformanceNumber = data.GroupDaoDaoIsHistoryPerformance.ThisMonthPerformanceNumber;
            result.GroupDaoDaoIsHistoryPerformance.ThisMonthPerformanceRate = data.GroupDaoDaoIsHistoryPerformance.ThisMonthPerformanceRate;
            result.GroupDaoDaoIsHistoryPerformance.TotalPerformanceNumber = data.GroupDaoDaoIsHistoryPerformance.TotalPerformanceNumber;

            result.GroupJiNaIsHistoryPerformance.HistoryPerformanceNumber = data.GroupJiNaIsHistoryPerformance.HistoryPerformanceNumber;
            result.GroupJiNaIsHistoryPerformance.HistoryPerformanceRate = data.GroupJiNaIsHistoryPerformance.HistoryPerformanceRate;
            result.GroupJiNaIsHistoryPerformance.ThisMonthPerformanceNumber = data.GroupJiNaIsHistoryPerformance.ThisMonthPerformanceNumber;
            result.GroupJiNaIsHistoryPerformance.ThisMonthPerformanceRate = data.GroupJiNaIsHistoryPerformance.ThisMonthPerformanceRate;
            result.GroupJiNaIsHistoryPerformance.TotalPerformanceNumber = data.GroupJiNaIsHistoryPerformance.TotalPerformanceNumber;
            #endregion
            return ResultData<GetNewOrOldCustomerCompareDataVo>.Success().AddData("data", result);
        }


        /// <summary>
        /// 根据条件获取新老客业绩占比（助理与机构）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getNewOrOldCustomerCompareByEmployeeAndHospital")]
        public async Task<ResultData<NewOrOldCustomerPerformanceDataListVo>> GetNewOrOldCustomerCompareByEmployeeAndHospitalDataAsync([FromQuery] QueryOperationDataVo query)
        {
            QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
            queryOperationDataVo.startDate = query.startDate;
            queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            var data = await amiyaOperationsBoardService.GetNewOrOldCustomerCompareByEmployeeAndHospitalAsync(queryOperationDataVo);

            NewOrOldCustomerPerformanceDataListVo result = new NewOrOldCustomerPerformanceDataListVo();
            result.HospitalPerformance = new List<CustomerPerformanceDataVo>();
            result.EmployeePerformance = new List<CustomerPerformanceDataVo>();
            foreach (var x in data.EmployeePerformance)
            {
                CustomerPerformanceDataVo employeePerformanceVo = new CustomerPerformanceDataVo();
                employeePerformanceVo.NewCustomerPerformance = x.NewCustomerPerformance;
                employeePerformanceVo.OldCustomerPerformance = x.OldCustomerPerformance;
                employeePerformanceVo.TotalCustomerPerformance = x.TotalPerformance;
                employeePerformanceVo.Name = x.Name;
                result.EmployeePerformance.Add(employeePerformanceVo);
            }
            foreach (var x in data.HospitalPerformance)
            {
                CustomerPerformanceDataVo hospitalPerformanceVo = new CustomerPerformanceDataVo();
                hospitalPerformanceVo.NewCustomerPerformance = x.NewCustomerPerformance;
                hospitalPerformanceVo.OldCustomerPerformance = x.OldCustomerPerformance;
                hospitalPerformanceVo.TotalCustomerPerformance = x.TotalPerformance;
                hospitalPerformanceVo.Name = x.Name;
                result.HospitalPerformance.Add(hospitalPerformanceVo);
            }
            return ResultData<NewOrOldCustomerPerformanceDataListVo>.Success().AddData("data", result);
        }

        #endregion


        #region 【流量】
        /// <summary>
        /// 根据条件获取流量数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getTotalFlowRateAndDateSchedule")]
        public async Task<ResultData<OperationTotalFlowRateDataVo>> GetTotalFlowRateAndDateScheduleAsync([FromQuery] QueryOperationDataVo query)
        {
            OperationTotalFlowRateDataVo result = new OperationTotalFlowRateDataVo();
            QueryOperationDataDto queryOperationDataDto = new QueryOperationDataDto();
            queryOperationDataDto.startDate = query.startDate;
            queryOperationDataDto.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            queryOperationDataDto.keyWord = query.keyWord;
            var data = await amiyaOperationsBoardService.GetCustomerDataAsync(queryOperationDataDto);


            result.TotalDistributeConsulation = data.TotalDistributeConsulation;
            result.TodayDistributeConsulation = data.TodayDistributeConsulation;
            result.DistributeConsulationCompleteRate = data.DistributeConsulationCompleteRate;
            result.DistributeConsulationYearOnYear = data.DistributeConsulationYearOnYear;
            result.DistributeConsulationChainRatio = data.DistributeConsulationChainRatio;

            result.TotalAddWechat = data.TotalAddWechat;
            result.TodayAddWechat = data.TodayAddWechat;
            result.AddWechatCompleteRate = data.AddWechatCompleteRate;
            result.AddWechatYearOnYear = data.AddWechatYearOnYear;
            result.AddWechatChainRatio = data.AddWechatChainRatio;

            result.TotalSendOrder = data.TotalSendOrder;
            result.TodayTotalSendOrder = data.TodayTotalSendOrder;
            result.TotalSendOrderCompleteRate = data.TotalSendOrderCompleteRate;
            result.TotalSendOrderYearOnYear = data.TotalSendOrderYearOnYear;
            result.TotalSendOrderChainRatio = data.TotalSendOrderChainRatio;

            result.TotalVisit = data.TotalVisit;
            result.TodayVisit = data.TodayVisit;
            result.VisitCompleteRate = data.VisitCompleteRate;
            result.VisitYearOnYear = data.VisitYearOnYear;
            result.VisitChainRatio = data.VisitChainRatio;

            result.DistributeConsulationBrokenLineList = data.DistributeConsulationBrokenLineList.Select(x => new PerformanceBrokenLineListInfoVo
            {
                date = x.date,
                Performance = x.Performance
            }).ToList();
            result.AddWeChatBrokenLineList = data.AddWeChatBrokenLineList.Select(x => new PerformanceBrokenLineListInfoVo
            {
                date = x.date,
                Performance = x.Performance
            }).ToList();

            result.SendOrderBrokenLineList = data.SendOrderBrokenLineList.Select(x => new PerformanceBrokenLineListInfoVo
            {
                date = x.date,
                Performance = x.Performance
            }).ToList();
            return ResultData<OperationTotalFlowRateDataVo>.Success().AddData("data", result);
        }

        /// <summary>
        /// 根据条件获取流量分析占比（分组）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getGroupFlowRateCompare")]
        public async Task<ResultData<GetGroupFlowRateCompareDataVo>> GetGroupFlowRateCompareDataAsync([FromQuery] QueryOperationDataVo query)
        {
            GetGroupFlowRateCompareDataVo result = new GetGroupFlowRateCompareDataVo();
            QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
            queryOperationDataVo.startDate = query.startDate;
            queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            var data = await amiyaOperationsBoardService.GetFlowRateByContentPlatFormCompareDataAsync(queryOperationDataVo);
            #region 【平台线索分析】
            OperationBoardContentPlatFormDataVo totalResultDataByContentPlatFormVo = new OperationBoardContentPlatFormDataVo();
            totalResultDataByContentPlatFormVo.DouYinNumber = data.TotalFlowRateByContentPlatForm.DouYinNumber;
            totalResultDataByContentPlatFormVo.DouYinRate = data.TotalFlowRateByContentPlatForm.DouYinRate;
            totalResultDataByContentPlatFormVo.VideoNumberNumber = data.TotalFlowRateByContentPlatForm.VideoNumberNumber;
            totalResultDataByContentPlatFormVo.VideoNumberRate = data.TotalFlowRateByContentPlatForm.VideoNumberRate;
            totalResultDataByContentPlatFormVo.XiaoHongShuNumber = data.TotalFlowRateByContentPlatForm.XiaoHongShuNumber;
            totalResultDataByContentPlatFormVo.XiaoHongShuRate = data.TotalFlowRateByContentPlatForm.XiaoHongShuRate;
            totalResultDataByContentPlatFormVo.PrivateDataNumber = data.TotalFlowRateByContentPlatForm.PrivateDataNumber;
            totalResultDataByContentPlatFormVo.PrivateDataRate = data.TotalFlowRateByContentPlatForm.PrivateDataRate;
            totalResultDataByContentPlatFormVo.TotalFlowRateNumber = data.TotalFlowRateByContentPlatForm.TotalFlowRateNumber;
            result.TotalFlowRateByContentPlatForm = totalResultDataByContentPlatFormVo;

            OperationBoardContentPlatFormDataVo groupDaoDaoResultDataByContentPlatFormVo = new OperationBoardContentPlatFormDataVo();
            groupDaoDaoResultDataByContentPlatFormVo.DouYinNumber = data.GroupDaoDaoFlowRateByContentPlatForm.DouYinNumber;
            groupDaoDaoResultDataByContentPlatFormVo.DouYinRate = data.GroupDaoDaoFlowRateByContentPlatForm.DouYinRate;
            groupDaoDaoResultDataByContentPlatFormVo.VideoNumberNumber = data.GroupDaoDaoFlowRateByContentPlatForm.VideoNumberNumber;
            groupDaoDaoResultDataByContentPlatFormVo.VideoNumberRate = data.GroupDaoDaoFlowRateByContentPlatForm.VideoNumberRate;
            groupDaoDaoResultDataByContentPlatFormVo.XiaoHongShuNumber = data.GroupDaoDaoFlowRateByContentPlatForm.XiaoHongShuNumber;
            groupDaoDaoResultDataByContentPlatFormVo.XiaoHongShuRate = data.GroupDaoDaoFlowRateByContentPlatForm.XiaoHongShuRate;
            groupDaoDaoResultDataByContentPlatFormVo.PrivateDataNumber = data.GroupDaoDaoFlowRateByContentPlatForm.PrivateDataNumber;
            groupDaoDaoResultDataByContentPlatFormVo.PrivateDataRate = data.GroupDaoDaoFlowRateByContentPlatForm.PrivateDataRate;
            groupDaoDaoResultDataByContentPlatFormVo.TotalFlowRateNumber = data.GroupDaoDaoFlowRateByContentPlatForm.TotalFlowRateNumber;
            result.GroupDaoDaoFlowRateByContentPlatForm = groupDaoDaoResultDataByContentPlatFormVo;

            OperationBoardContentPlatFormDataVo groupJiNaResultDataByContentPlatFormVo = new OperationBoardContentPlatFormDataVo();
            groupJiNaResultDataByContentPlatFormVo.DouYinNumber = data.GroupJiNaFlowRateByContentPlatForm.DouYinNumber;
            groupJiNaResultDataByContentPlatFormVo.DouYinRate = data.GroupJiNaFlowRateByContentPlatForm.DouYinRate;
            groupJiNaResultDataByContentPlatFormVo.VideoNumberNumber = data.GroupJiNaFlowRateByContentPlatForm.VideoNumberNumber;
            groupJiNaResultDataByContentPlatFormVo.VideoNumberRate = data.GroupJiNaFlowRateByContentPlatForm.VideoNumberRate;
            groupJiNaResultDataByContentPlatFormVo.XiaoHongShuNumber = data.GroupJiNaFlowRateByContentPlatForm.XiaoHongShuNumber;
            groupJiNaResultDataByContentPlatFormVo.XiaoHongShuRate = data.GroupJiNaFlowRateByContentPlatForm.XiaoHongShuRate;
            groupJiNaResultDataByContentPlatFormVo.PrivateDataNumber = data.GroupJiNaFlowRateByContentPlatForm.PrivateDataNumber;
            groupJiNaResultDataByContentPlatFormVo.PrivateDataRate = data.GroupJiNaFlowRateByContentPlatForm.PrivateDataRate;
            groupJiNaResultDataByContentPlatFormVo.TotalFlowRateNumber = data.GroupJiNaFlowRateByContentPlatForm.TotalFlowRateNumber;
            result.GroupJiNaFlowRateByContentPlatForm = groupJiNaResultDataByContentPlatFormVo;
            #endregion

            #region 【部门线索分析】
            OperationBoardDepartmentDataVo totalResultDataByDepartmentVo = new OperationBoardDepartmentDataVo();
            totalResultDataByDepartmentVo.BeforeLivingNumber = data.TotalFlowRateByDepartment.BeforeLivingNumber;
            totalResultDataByDepartmentVo.BeforeLivingRate = data.TotalFlowRateByDepartment.BeforeLivingRate;
            totalResultDataByDepartmentVo.LivingNumber = data.TotalFlowRateByDepartment.LivingNumber;
            totalResultDataByDepartmentVo.LivingRate = data.TotalFlowRateByDepartment.LivingRate;
            totalResultDataByDepartmentVo.AfterLivingNumber = data.TotalFlowRateByDepartment.AfterLivingNumber;
            totalResultDataByDepartmentVo.AftereLivingRate = data.TotalFlowRateByDepartment.AftereLivingRate;
            totalResultDataByDepartmentVo.OtherRate = data.TotalFlowRateByDepartment.OtherRate;
            totalResultDataByDepartmentVo.OtherNumber = data.TotalFlowRateByDepartment.OtherNumber;
            totalResultDataByDepartmentVo.TotalFlowRateNumber = data.TotalFlowRateByDepartment.TotalFlowRateNumber;
            result.TotalFlowRateByDepartment = totalResultDataByDepartmentVo;

            OperationBoardDepartmentDataVo groupDaoDaoResultDataByDepartmentVo = new OperationBoardDepartmentDataVo();
            groupDaoDaoResultDataByDepartmentVo.BeforeLivingNumber = data.GroupDaoDaoFlowRateByDepartment.BeforeLivingNumber;
            groupDaoDaoResultDataByDepartmentVo.BeforeLivingRate = data.GroupDaoDaoFlowRateByDepartment.BeforeLivingRate;
            groupDaoDaoResultDataByDepartmentVo.LivingNumber = data.GroupDaoDaoFlowRateByDepartment.LivingNumber;
            groupDaoDaoResultDataByDepartmentVo.LivingRate = data.GroupDaoDaoFlowRateByDepartment.LivingRate;
            groupDaoDaoResultDataByDepartmentVo.AfterLivingNumber = data.GroupDaoDaoFlowRateByDepartment.AfterLivingNumber;
            groupDaoDaoResultDataByDepartmentVo.AftereLivingRate = data.GroupDaoDaoFlowRateByDepartment.AftereLivingRate;
            groupDaoDaoResultDataByDepartmentVo.OtherRate = data.GroupDaoDaoFlowRateByDepartment.OtherRate;
            groupDaoDaoResultDataByDepartmentVo.OtherNumber = data.GroupDaoDaoFlowRateByDepartment.OtherNumber;
            groupDaoDaoResultDataByDepartmentVo.TotalFlowRateNumber = data.GroupDaoDaoFlowRateByDepartment.TotalFlowRateNumber;
            result.GroupDaoDaoFlowRateByDepartment = groupDaoDaoResultDataByDepartmentVo;

            OperationBoardDepartmentDataVo groupJiNaResultDataByDepartmentVo = new OperationBoardDepartmentDataVo();
            groupJiNaResultDataByDepartmentVo.BeforeLivingNumber = data.GroupJiNaFlowRateByDepartment.BeforeLivingNumber;
            groupJiNaResultDataByDepartmentVo.BeforeLivingRate = data.GroupJiNaFlowRateByDepartment.BeforeLivingRate;
            groupJiNaResultDataByDepartmentVo.LivingNumber = data.GroupJiNaFlowRateByDepartment.LivingNumber;
            groupJiNaResultDataByDepartmentVo.LivingRate = data.GroupJiNaFlowRateByDepartment.LivingRate;
            groupJiNaResultDataByDepartmentVo.AfterLivingNumber = data.GroupJiNaFlowRateByDepartment.AfterLivingNumber;
            groupJiNaResultDataByDepartmentVo.AftereLivingRate = data.GroupJiNaFlowRateByDepartment.AftereLivingRate;
            groupJiNaResultDataByDepartmentVo.OtherRate = data.GroupJiNaFlowRateByDepartment.OtherRate;
            groupJiNaResultDataByDepartmentVo.OtherNumber = data.GroupJiNaFlowRateByDepartment.OtherNumber;
            groupJiNaResultDataByDepartmentVo.TotalFlowRateNumber = data.GroupJiNaFlowRateByDepartment.TotalFlowRateNumber;
            result.GroupJiNaFlowRateByDepartment = groupJiNaResultDataByDepartmentVo;
            #endregion

            #region【分组线索分析】
            result.TotalFlowRate = data.TotalFlowRate;
            result.GroupJiNaFlowRate = data.GroupJiNaFlowRate;
            result.GroupDaoDaoFlowRate = data.GroupDaoDaoFlowRate;
            #endregion

            #region 【有效/潜在线索分析】
            OperationBoardIsEffictiveDataVo totalResultDataByIsEffictiveVo = new OperationBoardIsEffictiveDataVo();
            totalResultDataByIsEffictiveVo.EffictiveNumber = data.TotalFlowRateByIsEffictive.EffictiveNumber;
            totalResultDataByIsEffictiveVo.EffictiveRate = data.TotalFlowRateByIsEffictive.EffictiveRate;
            totalResultDataByIsEffictiveVo.NotEffictiveNumber = data.TotalFlowRateByIsEffictive.NotEffictiveNumber;
            totalResultDataByIsEffictiveVo.NotEffictiveRate = data.TotalFlowRateByIsEffictive.NotEffictiveRate;
            totalResultDataByIsEffictiveVo.TotalFlowRateNumber = data.TotalFlowRateByIsEffictive.TotalFlowRateNumber;
            result.TotalFlowRateByIsEffictive = totalResultDataByIsEffictiveVo;

            OperationBoardIsEffictiveDataVo groupDaoDaoResultDataByIsEffictiveVo = new OperationBoardIsEffictiveDataVo();
            groupDaoDaoResultDataByIsEffictiveVo.EffictiveNumber = data.GroupDaoDaoFlowRateByIsEffictive.EffictiveNumber;
            groupDaoDaoResultDataByIsEffictiveVo.EffictiveRate = data.GroupDaoDaoFlowRateByIsEffictive.EffictiveRate;
            groupDaoDaoResultDataByIsEffictiveVo.NotEffictiveNumber = data.GroupDaoDaoFlowRateByIsEffictive.NotEffictiveNumber;
            groupDaoDaoResultDataByIsEffictiveVo.NotEffictiveRate = data.GroupDaoDaoFlowRateByIsEffictive.NotEffictiveRate;
            groupDaoDaoResultDataByIsEffictiveVo.TotalFlowRateNumber = data.GroupDaoDaoFlowRateByIsEffictive.TotalFlowRateNumber;
            result.GroupDaoDaoFlowRateByIsEffictive = groupDaoDaoResultDataByIsEffictiveVo;

            OperationBoardIsEffictiveDataVo groupJiNaResultDataByIsEffictiveVo = new OperationBoardIsEffictiveDataVo();
            groupJiNaResultDataByIsEffictiveVo.EffictiveNumber = data.GroupJiNaFlowRateByIsEffictive.EffictiveNumber;
            groupJiNaResultDataByIsEffictiveVo.EffictiveRate = data.GroupJiNaFlowRateByIsEffictive.EffictiveRate;
            groupJiNaResultDataByIsEffictiveVo.NotEffictiveNumber = data.GroupJiNaFlowRateByIsEffictive.NotEffictiveNumber;
            groupJiNaResultDataByIsEffictiveVo.NotEffictiveRate = data.GroupJiNaFlowRateByIsEffictive.NotEffictiveRate;
            groupJiNaResultDataByIsEffictiveVo.TotalFlowRateNumber = data.GroupJiNaFlowRateByIsEffictive.TotalFlowRateNumber;
            result.GroupJiNaFlowRateByIsEffictive = groupJiNaResultDataByIsEffictiveVo;
            #endregion

            return ResultData<GetGroupFlowRateCompareDataVo>.Success().AddData("data", result);
        }


        /// <summary>
        /// 根据条件获取线索分析柱状图（助理与机构）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCustomerFlowRateByEmployeeAndHospital")]
        public async Task<ResultData<CustomerFlowRateDataListVo>> GetCustomerFlowRateByEmployeeAndHospitalAsync([FromQuery] QueryOperationDataVo query)
        {
            QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
            queryOperationDataVo.startDate = query.startDate;
            queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            var data = await amiyaOperationsBoardService.GetCustomerFlowRateByEmployeeAndHospitalAsync(queryOperationDataVo);

            CustomerFlowRateDataListVo result = new CustomerFlowRateDataListVo();
            result.HospitalFlowRate = new List<CustomerFlowRateDataVo>();
            result.EmployeeFlowRate = new List<CustomerFlowRateDataVo>();
            foreach (var x in data.EmployeeFlowRate)
            {
                CustomerFlowRateDataVo employeePerformanceVo = new CustomerFlowRateDataVo();
                employeePerformanceVo.DistributeConsulationNum = x.DistributeConsulationNum;
                employeePerformanceVo.SendOrderNum = x.SendOrderNum;
                employeePerformanceVo.VisitNum = x.VisitNum;
                employeePerformanceVo.Name = x.Name;
                result.EmployeeFlowRate.Add(employeePerformanceVo);
            }
            foreach (var x in data.HospitalFlowRate)
            {
                CustomerFlowRateDataVo hospitalPerformanceVo = new CustomerFlowRateDataVo();
                hospitalPerformanceVo.SendOrderNum = x.SendOrderNum;
                hospitalPerformanceVo.VisitNum = x.VisitNum;
                hospitalPerformanceVo.NewCustomerDealNum = x.NewCustomerDealNum;
                hospitalPerformanceVo.Name = x.Name;
                result.HospitalFlowRate.Add(hospitalPerformanceVo);
            }
            result.TotalDistributeConsulationByEmployee = result.EmployeeFlowRate.Sum(x => x.DistributeConsulationNum);
            result.TotalSendOrderByEmployee = result.EmployeeFlowRate.Sum(x => x.SendOrderNum);
            result.TotalVisitByEmployee = result.EmployeeFlowRate.Sum(x => x.VisitNum);
            result.TotalSendOrderByHospital = result.HospitalFlowRate.Sum(x => x.SendOrderNum);
            result.TotalVisitByHospital = result.HospitalFlowRate.Sum(x => x.VisitNum);
            result.TotalDealByHospital = result.HospitalFlowRate.Sum(x => x.NewCustomerDealNum);
            return ResultData<CustomerFlowRateDataListVo>.Success().AddData("data", result);
        }

        /// <summary>
        /// 根据条件获取平台流量分析
        /// </summary>
        /// <returns></returns>
        [HttpGet("getFlowRateByContentPlatform")]
        public async Task<ResultData<GetFlowRateByContentPlatformDataVo>> GetFlowRateByContentPlatformAsync([FromQuery] QueryOperationDataVo query)
        {
            GetFlowRateByContentPlatformDataVo result = new GetFlowRateByContentPlatformDataVo();
            QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
            queryOperationDataVo.startDate = query.startDate;
            queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            var data = await amiyaOperationsBoardService.GetFlowRateByContentPlatformAsync(queryOperationDataVo);

            result.DouYinFolwRateAnalize = data.DouYinFolwRateAnalize.Select(e => new Vo.BaseIdNameAndRateVo
            {
                Name = e.Value,
                Rate = e.Rate
            }).ToList();

            result.VideoNumberFolwRateAnalize = data.VideoNumberFolwRateAnalize.Select(e => new Vo.BaseIdNameAndRateVo
            {
                Name = e.Value,
                Rate = e.Rate
            }).ToList();

            result.XiaoHongShuFolwRateAnalize = data.XiaoHongShuFolwRateAnalize.Select(e => new Vo.BaseIdNameAndRateVo
            {
                Name = e.Value,
                Rate = e.Rate
            }).ToList();

            result.PrivateDataFolwRateAnalize = data.PrivateDataFolwRateAnalize.Select(e => new Vo.BaseIdNameAndRateVo
            {
                Name = e.Value,
                Rate = e.Rate
            }).ToList();
            return ResultData<GetFlowRateByContentPlatformDataVo>.Success().AddData("data", result);
        }

        /// <summary>
        /// 根据平台获取详细流量分析
        /// </summary>
        /// <returns></returns>
        [HttpGet("getFlowRateDetailsByContentPlatform")]
        public async Task<ResultData<GetFlowRateDetailsByContentPlatformDataVo>> GetFlowRateDetailsByContentPlatformAsync([FromQuery] QueryOperationDataVo query)
        {
            GetFlowRateDetailsByContentPlatformDataVo result = new GetFlowRateDetailsByContentPlatformDataVo();
            result.FolwRateDetailsAnalize = new List<Vo.BaseIdNameAndRateVo>();
            QueryOperationDataDto queryOperationDataVo = new QueryOperationDataDto();
            queryOperationDataVo.startDate = query.startDate;
            queryOperationDataVo.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            queryOperationDataVo.keyWord = query.keyWord;
            var data = await amiyaOperationsBoardService.GetFlowRateDetailsByContentPlatformAsync(queryOperationDataVo);

            result.FolwRateDetailsAnalize = data.FolwRateDetailsAnalize.Select(e => new Vo.BaseIdNameAndRateVo
            {
                Name = e.Value,
                Rate = e.Rate
            }).ToList();
            return ResultData<GetFlowRateDetailsByContentPlatformDataVo>.Success().AddData("data", result);
        }
        #endregion


        #region 转化

        /// <summary>
        /// 流量和客户转化情况
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("companyTransformData")]
        public async Task<ResultData<List<FlowTransFormDataVo>>> GetFlowTransformDataAsync([FromQuery] QueryTransformDataVo query)
        {
            QueryTransformDataDto queryDto = new QueryTransformDataDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.ShowTikTok = query.ShowTikTok;
            queryDto.ShowWechatVideo = query.ShowWechatVideo;
            queryDto.ShowXiaoHongShu = query.ShowXiaoHongShu;
            queryDto.ShowPrivateDomain = query.ShowPrivateDomain;
            var result = await amiyaOperationsBoardService.GetFlowTransFormDataAsync(queryDto);
            var res = result.Select(e => new FlowTransFormDataVo
            {
                GroupName = e.GroupName,
                ClueCount = e.ClueCount,
                ClueEffectiveRate = e.ClueEffectiveRate,
                SendOrderCount = e.SendOrderCount,
                DistributeConsulationNum = e.DistributeConsulationNum,
                AddWechatCount = e.AddWechatCount,
                AddWechatRate = e.AddWechatRate,
                SendOrderRate = e.SendOrderRate,
                ToHospitalCount = e.ToHospitalCount,
                ToHospitalRate = e.ToHospitalRate,
                DealCount = e.DealCount,
                NewCustomerDealCount = e.NewCustomerDealCount,
                OldCustomerDealCount = e.OldCustomerDealCount,
                DealRate = e.DealRate,
                NewCustomerPerformance = e.NewCustomerPerformance,
                NewAndOldCustomerRate = e.NewAndOldCustomerRate,
                OldCustomerPerformance = e.OldCustomerPerformance,
                NewCustomerUnitPrice = e.NewCustomerUnitPrice,
                OldCustomerUnitPrice = e.OldCustomerUnitPrice,
                CustomerUnitPrice = e.CustomerUnitPrice,
                Rate = e.Rate
            }).ToList();
            return ResultData<List<FlowTransFormDataVo>>.Success().AddData("data", res);
        }

        /// <summary>
        /// 助理流量和客户转化情况
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("assistantTransformData")]
        public async Task<ResultData<List<FlowTransFormDataVo>>> GetAssistantFlowTransformDataAsync([FromQuery] QueryTransformDataVo query)
        {
            QueryTransformDataDto queryDto = new QueryTransformDataDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.ShowTikTok = query.ShowTikTok;
            queryDto.ShowWechatVideo = query.ShowWechatVideo;
            queryDto.ShowXiaoHongShu = query.ShowXiaoHongShu;
            queryDto.ShowPrivateDomain = query.ShowPrivateDomain;
            var result = await amiyaOperationsBoardService.GetAssistantFlowTransFormDataAsync(queryDto);
            var res = result.Select(e => new FlowTransFormDataVo
            {
                GroupName = e.GroupName,
                ClueCount = e.ClueCount,
                ClueEffectiveRate = e.ClueEffectiveRate,
                SendOrderCount = e.SendOrderCount,
                DistributeConsulationNum = e.DistributeConsulationNum,
                AddWechatCount = e.AddWechatCount,
                AddWechatRate = e.AddWechatRate,
                SendOrderRate = e.SendOrderRate,
                ToHospitalCount = e.ToHospitalCount,
                ToHospitalRate = e.ToHospitalRate,
                DealCount = e.DealCount,
                NewCustomerDealCount = e.NewCustomerDealCount,
                OldCustomerDealCount = e.OldCustomerDealCount,
                DealRate = e.DealRate,
                NewCustomerPerformance = e.NewCustomerPerformance,
                NewAndOldCustomerRate = e.NewAndOldCustomerRate,
                OldCustomerPerformance = e.OldCustomerPerformance,
                NewCustomerUnitPrice = e.NewCustomerUnitPrice,
                OldCustomerUnitPrice = e.OldCustomerUnitPrice,
                CustomerUnitPrice = e.CustomerUnitPrice,
                Rate = e.Rate
            }).ToList();
            return ResultData<List<FlowTransFormDataVo>>.Success().AddData("data", res);
        }
        /// <summary>
        /// 机构转化情况
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalTransformData")]
        public async Task<ResultData<List<HospitalTransformDataVo>>> GetHospitalTransformDataAsync([FromQuery] QueryHospitalTransformDataVo query)
        {
            QueryHospitalTransformDataDto queryDto = new QueryHospitalTransformDataDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.ShowDaoDao = query.ShowDaoDao;
            queryDto.ShowJiNa = query.ShowJiNa;
            queryDto.ShowCooperate = query.ShowCooperate;
            var result = await amiyaOperationsBoardService.GetHospitalPerformanceByDateAsync(queryDto);
            var res = result.Select(e => new HospitalTransformDataVo
            {
                City = e.City,
                HospitalName = e.HospitalName,
                SendNum = e.SendNum,
                VisitNum = e.VisitNum,
                VisitRate = e.VisitRate,
                NewCustomerDealNum = e.NewCustomerDealNum,
                NewCustomerDealRate = e.NewCustomerDealRate,
                NewCustomerAchievement = e.NewCustomerAchievement,
                NewCustomerUnitPrice = e.NewCustomerUnitPrice,
                OldCustomerDealNum = e.OldCustomerDealNum,
                OldCustomerAchievement = e.OldCustomerAchievement,
                OldCustomerUnitPrice = e.OldCustomerUnitPrice,
                TotalAchievement = e.TotalAchievement,
                NewOrOldCustomerRate = e.NewOrOldCustomerRate,
                Rate = e.Rate
            }).ToList();
            return ResultData<List<HospitalTransformDataVo>>.Success().AddData("data", res);
        }

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
