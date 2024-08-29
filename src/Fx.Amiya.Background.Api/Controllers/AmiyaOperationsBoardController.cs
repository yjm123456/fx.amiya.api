using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input;
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
            queryOperationDataVo.keyWord = query.keyWord;
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
            QueryOperationDataDto queryOperationDataDto = new QueryOperationDataDto();
            queryOperationDataDto.startDate = query.startDate;
            queryOperationDataDto.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            queryOperationDataDto.keyWord = query.keyWord;
            var data = await amiyaOperationsBoardService.GetNewOrOldCustomerCompareDataAsync(queryOperationDataDto);


            #region【平台】

            result.TotalFlowRateByContentPlatForm = new OperationBoardContentPlatFormDataVo();
            result.GroupDaoDaoFlowRateByContentPlatForm = new OperationBoardContentPlatFormDataVo();
            result.GroupJiNaFlowRateByContentPlatForm = new OperationBoardContentPlatFormDataVo();

            result.TotalFlowRateByContentPlatForm.DouYinNumber = data.TotalFlowRateByContentPlatForm.DouYinNumber;
            result.TotalFlowRateByContentPlatForm.DouYinRate = data.TotalFlowRateByContentPlatForm.DouYinRate;
            result.TotalFlowRateByContentPlatForm.VideoNumberNumber = data.TotalFlowRateByContentPlatForm.VideoNumberNumber;
            result.TotalFlowRateByContentPlatForm.VideoNumberRate = data.TotalFlowRateByContentPlatForm.VideoNumberRate;
            result.TotalFlowRateByContentPlatForm.XiaoHongShuNumber = data.TotalFlowRateByContentPlatForm.XiaoHongShuNumber;
            result.TotalFlowRateByContentPlatForm.XiaoHongShuRate = data.TotalFlowRateByContentPlatForm.XiaoHongShuRate;
            result.TotalFlowRateByContentPlatForm.PrivateDataNumber = data.TotalFlowRateByContentPlatForm.PrivateDataNumber;
            result.TotalFlowRateByContentPlatForm.PrivateDataRate = data.TotalFlowRateByContentPlatForm.PrivateDataRate;
            result.TotalFlowRateByContentPlatForm.TotalFlowRateNumber = data.TotalFlowRateByContentPlatForm.TotalFlowRateNumber;


            #region{刀刀吉娜数据}

            //result.GroupDaoDaoFlowRateByContentPlatForm.DouYinNumber = data.GroupDaoDaoFlowRateByContentPlatForm.DouYinNumber;
            //result.GroupDaoDaoFlowRateByContentPlatForm.DouYinRate = data.GroupDaoDaoFlowRateByContentPlatForm.DouYinRate;
            //result.GroupDaoDaoFlowRateByContentPlatForm.VideoNumberNumber = data.GroupDaoDaoFlowRateByContentPlatForm.VideoNumberNumber;
            //result.GroupDaoDaoFlowRateByContentPlatForm.VideoNumberRate = data.GroupDaoDaoFlowRateByContentPlatForm.VideoNumberRate;
            //result.GroupDaoDaoFlowRateByContentPlatForm.XiaoHongShuNumber = data.GroupDaoDaoFlowRateByContentPlatForm.XiaoHongShuNumber;
            //result.GroupDaoDaoFlowRateByContentPlatForm.XiaoHongShuRate = data.GroupDaoDaoFlowRateByContentPlatForm.XiaoHongShuRate;
            //result.GroupDaoDaoFlowRateByContentPlatForm.PrivateDataNumber = data.GroupDaoDaoFlowRateByContentPlatForm.PrivateDataNumber;
            //result.GroupDaoDaoFlowRateByContentPlatForm.PrivateDataRate = data.GroupDaoDaoFlowRateByContentPlatForm.PrivateDataRate;
            //result.GroupDaoDaoFlowRateByContentPlatForm.TotalFlowRateNumber = data.GroupDaoDaoFlowRateByContentPlatForm.TotalFlowRateNumber;

            //result.GroupJiNaFlowRateByContentPlatForm.DouYinNumber = data.GroupJiNaFlowRateByContentPlatForm.DouYinNumber;
            //result.GroupJiNaFlowRateByContentPlatForm.DouYinRate = data.GroupJiNaFlowRateByContentPlatForm.DouYinRate;
            //result.GroupJiNaFlowRateByContentPlatForm.VideoNumberNumber = data.GroupJiNaFlowRateByContentPlatForm.VideoNumberNumber;
            //result.GroupJiNaFlowRateByContentPlatForm.VideoNumberRate = data.GroupJiNaFlowRateByContentPlatForm.VideoNumberRate;
            //result.GroupJiNaFlowRateByContentPlatForm.XiaoHongShuNumber = data.GroupJiNaFlowRateByContentPlatForm.XiaoHongShuNumber;
            //result.GroupJiNaFlowRateByContentPlatForm.XiaoHongShuRate = data.GroupJiNaFlowRateByContentPlatForm.XiaoHongShuRate;
            //result.GroupJiNaFlowRateByContentPlatForm.PrivateDataNumber = data.GroupJiNaFlowRateByContentPlatForm.PrivateDataNumber;
            //result.GroupJiNaFlowRateByContentPlatForm.PrivateDataRate = data.GroupJiNaFlowRateByContentPlatForm.PrivateDataRate;
            //result.GroupJiNaFlowRateByContentPlatForm.TotalFlowRateNumber = data.GroupJiNaFlowRateByContentPlatForm.TotalFlowRateNumber;
            #endregion
            #endregion

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

            #region{刀刀吉娜数据}

            //result.GroupDaoDaoBelongChannelPerformance.BeforeLivingNumber = data.GroupDaoDaoBelongChannelPerformance.BeforeLivingNumber;
            //result.GroupDaoDaoBelongChannelPerformance.BeforeLivingRate = data.GroupDaoDaoBelongChannelPerformance.BeforeLivingRate;
            //result.GroupDaoDaoBelongChannelPerformance.LivingNumber = data.GroupDaoDaoBelongChannelPerformance.LivingNumber;
            //result.GroupDaoDaoBelongChannelPerformance.LivingRate = data.GroupDaoDaoBelongChannelPerformance.LivingRate;
            //result.GroupDaoDaoBelongChannelPerformance.AfterLivingNumber = data.GroupDaoDaoBelongChannelPerformance.AfterLivingNumber;
            //result.GroupDaoDaoBelongChannelPerformance.AfterLivingRate = data.GroupDaoDaoBelongChannelPerformance.AfterLivingRate;
            //result.GroupDaoDaoBelongChannelPerformance.OtherNumber = data.GroupDaoDaoBelongChannelPerformance.OtherNumber;
            //result.GroupDaoDaoBelongChannelPerformance.OtherRate = data.GroupDaoDaoBelongChannelPerformance.OtherRate;
            //result.GroupDaoDaoBelongChannelPerformance.TotalPerformanceNumber = data.GroupDaoDaoBelongChannelPerformance.TotalPerformanceNumber;

            //result.GroupJiNaBelongChannelPerformance.BeforeLivingNumber = data.GroupJiNaBelongChannelPerformance.BeforeLivingNumber;
            //result.GroupJiNaBelongChannelPerformance.BeforeLivingRate = data.GroupJiNaBelongChannelPerformance.BeforeLivingRate;
            //result.GroupJiNaBelongChannelPerformance.LivingNumber = data.GroupJiNaBelongChannelPerformance.LivingNumber;
            //result.GroupJiNaBelongChannelPerformance.LivingRate = data.GroupJiNaBelongChannelPerformance.LivingRate;
            //result.GroupJiNaBelongChannelPerformance.AfterLivingNumber = data.GroupJiNaBelongChannelPerformance.AfterLivingNumber;
            //result.GroupJiNaBelongChannelPerformance.AfterLivingRate = data.GroupJiNaBelongChannelPerformance.AfterLivingRate;
            //result.GroupJiNaBelongChannelPerformance.OtherNumber = data.GroupJiNaBelongChannelPerformance.OtherNumber;
            //result.GroupJiNaBelongChannelPerformance.OtherRate = data.GroupJiNaBelongChannelPerformance.OtherRate;
            //result.GroupJiNaBelongChannelPerformance.TotalPerformanceNumber = data.GroupJiNaBelongChannelPerformance.TotalPerformanceNumber;
            #endregion
            #endregion

            #region【新老客】
            #region {业绩}

            result.TotalNewOrOldCustomer = new OperationBoardGetNewOrOldCustomerCompareDataDetailsVo();
            result.GroupDaoDaoNewOrOldCustomer = new OperationBoardGetNewOrOldCustomerCompareDataDetailsVo();
            result.GroupJiNaNewOrOldCustomer = new OperationBoardGetNewOrOldCustomerCompareDataDetailsVo();

            result.TotalNewOrOldCustomer.TotalPerformanceNewCustomerNumber = data.TotalNewOrOldCustomer.TotalPerformanceNewCustomerNumber;
            result.TotalNewOrOldCustomer.TotalPerformanceNewCustomerRate = data.TotalNewOrOldCustomer.TotalPerformanceNewCustomerRate;
            result.TotalNewOrOldCustomer.TotalPerformanceOldCustomerNumber = data.TotalNewOrOldCustomer.TotalPerformanceOldCustomerNumber;
            result.TotalNewOrOldCustomer.TotalPerformanceOldCustomerRate = data.TotalNewOrOldCustomer.TotalPerformanceOldCustomerRate;
            result.TotalNewOrOldCustomer.TotalPerformanceNumber = data.TotalNewOrOldCustomer.TotalPerformanceNumber;

            #region{刀刀吉娜数据}
            //result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNewCustomerNumber = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNewCustomerNumber;
            //result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNewCustomerRate = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNewCustomerRate;
            //result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceOldCustomerNumber = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceOldCustomerNumber;
            //result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceOldCustomerRate = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceOldCustomerRate;
            //result.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNumber = data.GroupDaoDaoNewOrOldCustomer.TotalPerformanceNumber;

            //result.GroupJiNaNewOrOldCustomer.TotalPerformanceNewCustomerNumber = data.GroupJiNaNewOrOldCustomer.TotalPerformanceNewCustomerNumber;
            //result.GroupJiNaNewOrOldCustomer.TotalPerformanceNewCustomerRate = data.GroupJiNaNewOrOldCustomer.TotalPerformanceNewCustomerRate;
            //result.GroupJiNaNewOrOldCustomer.TotalPerformanceOldCustomerNumber = data.GroupJiNaNewOrOldCustomer.TotalPerformanceOldCustomerNumber;
            //result.GroupJiNaNewOrOldCustomer.TotalPerformanceOldCustomerRate = data.GroupJiNaNewOrOldCustomer.TotalPerformanceOldCustomerRate;
            //result.GroupJiNaNewOrOldCustomer.TotalPerformanceNumber = data.GroupJiNaNewOrOldCustomer.TotalPerformanceNumber;
            #endregion
            #endregion

            #region{人数}

            result.TotalNewOrOldCustomerNum = new OperationBoardGetNewOrOldCustomerCompareDataDetailsVo();
            result.GroupDaoDaoNewOrOldCustomerNum = new OperationBoardGetNewOrOldCustomerCompareDataDetailsVo();
            result.GroupJiNaNewOrOldCustomerNum = new OperationBoardGetNewOrOldCustomerCompareDataDetailsVo();

            result.TotalNewOrOldCustomerNum.TotalPerformanceNewCustomerNumber = data.TotalNewOrOldCustomerNum.TotalPerformanceNewCustomerNumber;
            result.TotalNewOrOldCustomerNum.TotalPerformanceNewCustomerRate = data.TotalNewOrOldCustomerNum.TotalPerformanceNewCustomerRate;
            result.TotalNewOrOldCustomerNum.TotalPerformanceOldCustomerNumber = data.TotalNewOrOldCustomerNum.TotalPerformanceOldCustomerNumber;
            result.TotalNewOrOldCustomerNum.TotalPerformanceOldCustomerRate = data.TotalNewOrOldCustomerNum.TotalPerformanceOldCustomerRate;
            result.TotalNewOrOldCustomerNum.TotalPerformanceNumber = data.TotalNewOrOldCustomerNum.TotalPerformanceNumber;

            #region{刀刀吉娜数据}

            //result.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceNewCustomerNumber = data.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceNewCustomerNumber;
            //result.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceNewCustomerRate = data.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceNewCustomerRate;
            //result.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceOldCustomerNumber = data.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceOldCustomerNumber;
            //result.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceOldCustomerRate = data.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceOldCustomerRate;
            //result.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceNumber = data.GroupDaoDaoNewOrOldCustomerNum.TotalPerformanceNumber;

            //result.GroupJiNaNewOrOldCustomerNum.TotalPerformanceNewCustomerNumber = data.GroupJiNaNewOrOldCustomerNum.TotalPerformanceNewCustomerNumber;
            //result.GroupJiNaNewOrOldCustomerNum.TotalPerformanceNewCustomerRate = data.GroupJiNaNewOrOldCustomerNum.TotalPerformanceNewCustomerRate;
            //result.GroupJiNaNewOrOldCustomerNum.TotalPerformanceOldCustomerNumber = data.GroupJiNaNewOrOldCustomerNum.TotalPerformanceOldCustomerNumber;
            //result.GroupJiNaNewOrOldCustomerNum.TotalPerformanceOldCustomerRate = data.GroupJiNaNewOrOldCustomerNum.TotalPerformanceOldCustomerRate;
            //result.GroupJiNaNewOrOldCustomerNum.TotalPerformanceNumber = data.GroupJiNaNewOrOldCustomerNum.TotalPerformanceNumber;
            #endregion

            #endregion
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

            #region{刀刀吉娜数据}

            //result.GroupDaoDaoIsEffictivePerformance.EffictivePerformanceNumber = data.GroupDaoDaoIsEffictivePerformance.EffictivePerformanceNumber;
            //result.GroupDaoDaoIsEffictivePerformance.EffictivePerformanceRate = data.GroupDaoDaoIsEffictivePerformance.EffictivePerformanceRate;
            //result.GroupDaoDaoIsEffictivePerformance.NotEffictivePerformanceNumber = data.GroupDaoDaoIsEffictivePerformance.NotEffictivePerformanceNumber;
            //result.GroupDaoDaoIsEffictivePerformance.NotEffictivePerformanceRate = data.GroupDaoDaoIsEffictivePerformance.NotEffictivePerformanceRate;
            //result.GroupDaoDaoIsEffictivePerformance.TotalPerformanceNumber = data.GroupDaoDaoIsEffictivePerformance.TotalPerformanceNumber;

            //result.GroupJiNaIsEffictivePerformance.EffictivePerformanceNumber = data.GroupJiNaIsEffictivePerformance.EffictivePerformanceNumber;
            //result.GroupJiNaIsEffictivePerformance.EffictivePerformanceRate = data.GroupJiNaIsEffictivePerformance.EffictivePerformanceRate;
            //result.GroupJiNaIsEffictivePerformance.NotEffictivePerformanceNumber = data.GroupJiNaIsEffictivePerformance.NotEffictivePerformanceNumber;
            //result.GroupJiNaIsEffictivePerformance.NotEffictivePerformanceRate = data.GroupJiNaIsEffictivePerformance.NotEffictivePerformanceRate;
            //result.GroupJiNaIsEffictivePerformance.TotalPerformanceNumber = data.GroupJiNaIsEffictivePerformance.TotalPerformanceNumber;
            #endregion

            #endregion

            #region【当月/历史】
            #region{业绩}

            result.TotalIsHistoryPerformance = new OperationBoardGetIsHistoryPerformanceVo();
            result.GroupDaoDaoIsHistoryPerformance = new OperationBoardGetIsHistoryPerformanceVo();
            result.GroupJiNaIsHistoryPerformance = new OperationBoardGetIsHistoryPerformanceVo();

            result.TotalIsHistoryPerformance.HistoryPerformanceNumber = data.TotalIsHistoryPerformance.HistoryPerformanceNumber;
            result.TotalIsHistoryPerformance.HistoryPerformanceRate = data.TotalIsHistoryPerformance.HistoryPerformanceRate;
            result.TotalIsHistoryPerformance.ThisMonthPerformanceNumber = data.TotalIsHistoryPerformance.ThisMonthPerformanceNumber;
            result.TotalIsHistoryPerformance.ThisMonthPerformanceRate = data.TotalIsHistoryPerformance.ThisMonthPerformanceRate;
            result.TotalIsHistoryPerformance.TotalPerformanceNumber = data.TotalIsHistoryPerformance.TotalPerformanceNumber;

            #region{刀刀吉娜数据}
            //result.GroupDaoDaoIsHistoryPerformance.HistoryPerformanceNumber = data.GroupDaoDaoIsHistoryPerformance.HistoryPerformanceNumber;
            //result.GroupDaoDaoIsHistoryPerformance.HistoryPerformanceRate = data.GroupDaoDaoIsHistoryPerformance.HistoryPerformanceRate;
            //result.GroupDaoDaoIsHistoryPerformance.ThisMonthPerformanceNumber = data.GroupDaoDaoIsHistoryPerformance.ThisMonthPerformanceNumber;
            //result.GroupDaoDaoIsHistoryPerformance.ThisMonthPerformanceRate = data.GroupDaoDaoIsHistoryPerformance.ThisMonthPerformanceRate;
            //result.GroupDaoDaoIsHistoryPerformance.TotalPerformanceNumber = data.GroupDaoDaoIsHistoryPerformance.TotalPerformanceNumber;

            //result.GroupJiNaIsHistoryPerformance.HistoryPerformanceNumber = data.GroupJiNaIsHistoryPerformance.HistoryPerformanceNumber;
            //result.GroupJiNaIsHistoryPerformance.HistoryPerformanceRate = data.GroupJiNaIsHistoryPerformance.HistoryPerformanceRate;
            //result.GroupJiNaIsHistoryPerformance.ThisMonthPerformanceNumber = data.GroupJiNaIsHistoryPerformance.ThisMonthPerformanceNumber;
            //result.GroupJiNaIsHistoryPerformance.ThisMonthPerformanceRate = data.GroupJiNaIsHistoryPerformance.ThisMonthPerformanceRate;
            //result.GroupJiNaIsHistoryPerformance.TotalPerformanceNumber = data.GroupJiNaIsHistoryPerformance.TotalPerformanceNumber;
            #endregion

            #endregion
            #region{人数}

            result.TotalIsHistoryPerformanceNum = new OperationBoardGetIsHistoryPerformanceVo();
            result.GroupDaoDaoIsHistoryPerformanceNum = new OperationBoardGetIsHistoryPerformanceVo();
            result.GroupJiNaIsHistoryPerformanceNum = new OperationBoardGetIsHistoryPerformanceVo();

            result.TotalIsHistoryPerformanceNum.HistoryPerformanceNumber = data.TotalIsHistoryPerformanceNum.HistoryPerformanceNumber;
            result.TotalIsHistoryPerformanceNum.HistoryPerformanceRate = data.TotalIsHistoryPerformanceNum.HistoryPerformanceRate;
            result.TotalIsHistoryPerformanceNum.ThisMonthPerformanceNumber = data.TotalIsHistoryPerformanceNum.ThisMonthPerformanceNumber;
            result.TotalIsHistoryPerformanceNum.ThisMonthPerformanceRate = data.TotalIsHistoryPerformanceNum.ThisMonthPerformanceRate;
            result.TotalIsHistoryPerformanceNum.TotalPerformanceNumber = data.TotalIsHistoryPerformanceNum.TotalPerformanceNumber;
            #region{刀刀吉娜数据}

            //result.GroupDaoDaoIsHistoryPerformanceNum.HistoryPerformanceNumber = data.GroupDaoDaoIsHistoryPerformanceNum.HistoryPerformanceNumber;
            //result.GroupDaoDaoIsHistoryPerformanceNum.HistoryPerformanceRate = data.GroupDaoDaoIsHistoryPerformanceNum.HistoryPerformanceRate;
            //result.GroupDaoDaoIsHistoryPerformanceNum.ThisMonthPerformanceNumber = data.GroupDaoDaoIsHistoryPerformanceNum.ThisMonthPerformanceNumber;
            //result.GroupDaoDaoIsHistoryPerformanceNum.ThisMonthPerformanceRate = data.GroupDaoDaoIsHistoryPerformanceNum.ThisMonthPerformanceRate;
            //result.GroupDaoDaoIsHistoryPerformanceNum.TotalPerformanceNumber = data.GroupDaoDaoIsHistoryPerformanceNum.TotalPerformanceNumber;

            //result.GroupJiNaIsHistoryPerformanceNum.HistoryPerformanceNumber = data.GroupJiNaIsHistoryPerformanceNum.HistoryPerformanceNumber;
            //result.GroupJiNaIsHistoryPerformanceNum.HistoryPerformanceRate = data.GroupJiNaIsHistoryPerformanceNum.HistoryPerformanceRate;
            //result.GroupJiNaIsHistoryPerformanceNum.ThisMonthPerformanceNumber = data.GroupJiNaIsHistoryPerformanceNum.ThisMonthPerformanceNumber;
            //result.GroupJiNaIsHistoryPerformanceNum.ThisMonthPerformanceRate = data.GroupJiNaIsHistoryPerformanceNum.ThisMonthPerformanceRate;
            //result.GroupJiNaIsHistoryPerformanceNum.TotalPerformanceNumber = data.GroupJiNaIsHistoryPerformanceNum.TotalPerformanceNumber;
            #endregion
            #endregion

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


            result.TotalBeforeLivingClue = data.TotalBeforeLivingClue;
            result.TodayBeforeLivingClue = data.TodayBeforeLivingClue;
            result.BeforeLivingClueCompleteRate = data.BeforeLivingClueCompleteRate;
            result.BeforeLivingClueYearOnYear = data.BeforeLivingClueYearOnYear;
            result.BeforeLivingClueChainRatio = data.BeforeLivingClueChainRatio;

            result.TotalLivingClue = data.TotalLivingClue;
            result.TodayLivingClue = data.TodayLivingClue;
            result.LivingClueCompleteRate = data.LivingClueCompleteRate;
            result.LivingClueYearOnYear = data.LivingClueYearOnYear;
            result.LivingClueChainRatio = data.LivingClueChainRatio;

            result.TotalAfterLivingClue = data.TotalAfterLivingClue;
            result.TodayTotalAfterLivingClue = data.TodayTotalAfterLivingClue;
            result.TotalAfterLivingClueCompleteRate = data.TotalAfterLivingClueCompleteRate;
            result.TotalAfterLivingClueYearOnYear = data.TotalAfterLivingClueYearOnYear;
            result.TotalAfterLivingClueChainRatio = data.TotalAfterLivingClueChainRatio;

            result.TotalClue = data.TotalClue;
            result.TodayClue = data.TodayClue;
            result.ClueCompleteRate = data.ClueCompleteRate;
            result.ClueYearOnYear = data.ClueYearOnYear;
            result.ClueChainRatio = data.ClueChainRatio;

            result.BeforeLivingClueBrokenLineList = data.BeforeLivingClueBrokenLineList.Select(x => new PerformanceBrokenLineListInfoVo
            {
                date = x.date,
                Performance = x.Performance
            }).ToList();
            result.LivingClueBrokenLineList = data.LivingClueBrokenLineList.Select(x => new PerformanceBrokenLineListInfoVo
            {
                date = x.date,
                Performance = x.Performance
            }).ToList();

            result.AfterLivingClueBrokenLineList = data.AfterLivingClueBrokenLineList.Select(x => new PerformanceBrokenLineListInfoVo
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
            QueryOperationDataDto queryOperationDataDto = new QueryOperationDataDto();
            queryOperationDataDto.startDate = query.startDate;
            queryOperationDataDto.endDate = query.endDate.Value.AddDays(1).AddMilliseconds(-1);
            queryOperationDataDto.keyWord = query.keyWord;
            var data = await amiyaOperationsBoardService.GetFlowRateByContentPlatFormCompareDataAsync(queryOperationDataDto);
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
            #region{刀刀吉娜组}

            //OperationBoardContentPlatFormDataVo groupDaoDaoResultDataByContentPlatFormVo = new OperationBoardContentPlatFormDataVo();
            //groupDaoDaoResultDataByContentPlatFormVo.DouYinNumber = data.GroupDaoDaoFlowRateByContentPlatForm.DouYinNumber;
            //groupDaoDaoResultDataByContentPlatFormVo.DouYinRate = data.GroupDaoDaoFlowRateByContentPlatForm.DouYinRate;
            //groupDaoDaoResultDataByContentPlatFormVo.VideoNumberNumber = data.GroupDaoDaoFlowRateByContentPlatForm.VideoNumberNumber;
            //groupDaoDaoResultDataByContentPlatFormVo.VideoNumberRate = data.GroupDaoDaoFlowRateByContentPlatForm.VideoNumberRate;
            //groupDaoDaoResultDataByContentPlatFormVo.XiaoHongShuNumber = data.GroupDaoDaoFlowRateByContentPlatForm.XiaoHongShuNumber;
            //groupDaoDaoResultDataByContentPlatFormVo.XiaoHongShuRate = data.GroupDaoDaoFlowRateByContentPlatForm.XiaoHongShuRate;
            //groupDaoDaoResultDataByContentPlatFormVo.PrivateDataNumber = data.GroupDaoDaoFlowRateByContentPlatForm.PrivateDataNumber;
            //groupDaoDaoResultDataByContentPlatFormVo.PrivateDataRate = data.GroupDaoDaoFlowRateByContentPlatForm.PrivateDataRate;
            //groupDaoDaoResultDataByContentPlatFormVo.TotalFlowRateNumber = data.GroupDaoDaoFlowRateByContentPlatForm.TotalFlowRateNumber;
            //result.GroupDaoDaoFlowRateByContentPlatForm = groupDaoDaoResultDataByContentPlatFormVo;

            //OperationBoardContentPlatFormDataVo groupJiNaResultDataByContentPlatFormVo = new OperationBoardContentPlatFormDataVo();
            //groupJiNaResultDataByContentPlatFormVo.DouYinNumber = data.GroupJiNaFlowRateByContentPlatForm.DouYinNumber;
            //groupJiNaResultDataByContentPlatFormVo.DouYinRate = data.GroupJiNaFlowRateByContentPlatForm.DouYinRate;
            //groupJiNaResultDataByContentPlatFormVo.VideoNumberNumber = data.GroupJiNaFlowRateByContentPlatForm.VideoNumberNumber;
            //groupJiNaResultDataByContentPlatFormVo.VideoNumberRate = data.GroupJiNaFlowRateByContentPlatForm.VideoNumberRate;
            //groupJiNaResultDataByContentPlatFormVo.XiaoHongShuNumber = data.GroupJiNaFlowRateByContentPlatForm.XiaoHongShuNumber;
            //groupJiNaResultDataByContentPlatFormVo.XiaoHongShuRate = data.GroupJiNaFlowRateByContentPlatForm.XiaoHongShuRate;
            //groupJiNaResultDataByContentPlatFormVo.PrivateDataNumber = data.GroupJiNaFlowRateByContentPlatForm.PrivateDataNumber;
            //groupJiNaResultDataByContentPlatFormVo.PrivateDataRate = data.GroupJiNaFlowRateByContentPlatForm.PrivateDataRate;
            //groupJiNaResultDataByContentPlatFormVo.TotalFlowRateNumber = data.GroupJiNaFlowRateByContentPlatForm.TotalFlowRateNumber;
            //result.GroupJiNaFlowRateByContentPlatForm = groupJiNaResultDataByContentPlatFormVo;
            #endregion
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
            #region{刀刀吉娜组}

            //OperationBoardDepartmentDataVo groupDaoDaoResultDataByDepartmentVo = new OperationBoardDepartmentDataVo();
            //groupDaoDaoResultDataByDepartmentVo.BeforeLivingNumber = data.GroupDaoDaoFlowRateByDepartment.BeforeLivingNumber;
            //groupDaoDaoResultDataByDepartmentVo.BeforeLivingRate = data.GroupDaoDaoFlowRateByDepartment.BeforeLivingRate;
            //groupDaoDaoResultDataByDepartmentVo.LivingNumber = data.GroupDaoDaoFlowRateByDepartment.LivingNumber;
            //groupDaoDaoResultDataByDepartmentVo.LivingRate = data.GroupDaoDaoFlowRateByDepartment.LivingRate;
            //groupDaoDaoResultDataByDepartmentVo.AfterLivingNumber = data.GroupDaoDaoFlowRateByDepartment.AfterLivingNumber;
            //groupDaoDaoResultDataByDepartmentVo.AftereLivingRate = data.GroupDaoDaoFlowRateByDepartment.AftereLivingRate;
            //groupDaoDaoResultDataByDepartmentVo.OtherRate = data.GroupDaoDaoFlowRateByDepartment.OtherRate;
            //groupDaoDaoResultDataByDepartmentVo.OtherNumber = data.GroupDaoDaoFlowRateByDepartment.OtherNumber;
            //groupDaoDaoResultDataByDepartmentVo.TotalFlowRateNumber = data.GroupDaoDaoFlowRateByDepartment.TotalFlowRateNumber;
            //result.GroupDaoDaoFlowRateByDepartment = groupDaoDaoResultDataByDepartmentVo;

            //OperationBoardDepartmentDataVo groupJiNaResultDataByDepartmentVo = new OperationBoardDepartmentDataVo();
            //groupJiNaResultDataByDepartmentVo.BeforeLivingNumber = data.GroupJiNaFlowRateByDepartment.BeforeLivingNumber;
            //groupJiNaResultDataByDepartmentVo.BeforeLivingRate = data.GroupJiNaFlowRateByDepartment.BeforeLivingRate;
            //groupJiNaResultDataByDepartmentVo.LivingNumber = data.GroupJiNaFlowRateByDepartment.LivingNumber;
            //groupJiNaResultDataByDepartmentVo.LivingRate = data.GroupJiNaFlowRateByDepartment.LivingRate;
            //groupJiNaResultDataByDepartmentVo.AfterLivingNumber = data.GroupJiNaFlowRateByDepartment.AfterLivingNumber;
            //groupJiNaResultDataByDepartmentVo.AftereLivingRate = data.GroupJiNaFlowRateByDepartment.AftereLivingRate;
            //groupJiNaResultDataByDepartmentVo.OtherRate = data.GroupJiNaFlowRateByDepartment.OtherRate;
            //groupJiNaResultDataByDepartmentVo.OtherNumber = data.GroupJiNaFlowRateByDepartment.OtherNumber;
            //groupJiNaResultDataByDepartmentVo.TotalFlowRateNumber = data.GroupJiNaFlowRateByDepartment.TotalFlowRateNumber;
            //result.GroupJiNaFlowRateByDepartment = groupJiNaResultDataByDepartmentVo;
            #endregion

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

            #region{刀刀吉娜数据}
            //OperationBoardIsEffictiveDataVo groupDaoDaoResultDataByIsEffictiveVo = new OperationBoardIsEffictiveDataVo();
            //groupDaoDaoResultDataByIsEffictiveVo.EffictiveNumber = data.GroupDaoDaoFlowRateByIsEffictive.EffictiveNumber;
            //groupDaoDaoResultDataByIsEffictiveVo.EffictiveRate = data.GroupDaoDaoFlowRateByIsEffictive.EffictiveRate;
            //groupDaoDaoResultDataByIsEffictiveVo.NotEffictiveNumber = data.GroupDaoDaoFlowRateByIsEffictive.NotEffictiveNumber;
            //groupDaoDaoResultDataByIsEffictiveVo.NotEffictiveRate = data.GroupDaoDaoFlowRateByIsEffictive.NotEffictiveRate;
            //groupDaoDaoResultDataByIsEffictiveVo.TotalFlowRateNumber = data.GroupDaoDaoFlowRateByIsEffictive.TotalFlowRateNumber;
            //result.GroupDaoDaoFlowRateByIsEffictive = groupDaoDaoResultDataByIsEffictiveVo;

            //OperationBoardIsEffictiveDataVo groupJiNaResultDataByIsEffictiveVo = new OperationBoardIsEffictiveDataVo();
            //groupJiNaResultDataByIsEffictiveVo.EffictiveNumber = data.GroupJiNaFlowRateByIsEffictive.EffictiveNumber;
            //groupJiNaResultDataByIsEffictiveVo.EffictiveRate = data.GroupJiNaFlowRateByIsEffictive.EffictiveRate;
            //groupJiNaResultDataByIsEffictiveVo.NotEffictiveNumber = data.GroupJiNaFlowRateByIsEffictive.NotEffictiveNumber;
            //groupJiNaResultDataByIsEffictiveVo.NotEffictiveRate = data.GroupJiNaFlowRateByIsEffictive.NotEffictiveRate;
            //groupJiNaResultDataByIsEffictiveVo.TotalFlowRateNumber = data.GroupJiNaFlowRateByIsEffictive.TotalFlowRateNumber;
            //result.GroupJiNaFlowRateByIsEffictive = groupJiNaResultDataByIsEffictiveVo;
            #endregion

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
        /// 获取助理业绩目标达成情况
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("assistantTargetCompleteData")]
        public async Task<ResultData<List<AssistantTargetCompleteVo>>> GetAssistantTargetCompleteDataAsync([FromQuery] QueryAssistantTargetCompleteDataVo query)
        {
            QueryAssistantTargetCompleteDataDto queryDto = new QueryAssistantTargetCompleteDataDto();
            queryDto.ShowPrivateDomain = query.ShowPrivateDomain;
            queryDto.ShowTikTok = query.ShowTikTok;
            queryDto.ShowWechatVideo = query.ShowWechatVideo;
            queryDto.ShowXiaoHongShu = query.ShowXiaoHongShu;
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            var dataList = await amiyaOperationsBoardService.GetAssitantTargetCompleteAsync(queryDto);
            var res = dataList.Select(e => new AssistantTargetCompleteVo
            {
                Sort = e.Sort,
                Name = e.Name,
                NewCustomerPerformanceTarget = e.NewCustomerPerformanceTarget,
                CurrentMonthNewCustomerPerformance = e.CurrentMonthNewCustomerPerformance,
                HistoryMonthNewCustomerPerformance = e.HistoryMonthNewCustomerPerformance,
                NewCustomerTargetComplete = e.NewCustomerTargetComplete,
                NewCustomerChainRatio = e.NewCustomerChainRatio,
                OldCustomerPerformanceTarget = e.OldCustomerPerformanceTarget,
                CurrentMonthOldCustomerPerformance = e.CurrentMonthOldCustomerPerformance,
                HistoryMonthOldCustomerPerformance = e.HistoryMonthOldCustomerPerformance,
                OldCustomerTargetComplete = e.OldCustomerTargetComplete,
                OldCustomerChainRatio = e.OldCustomerChainRatio,
                TotalCustomerPerformanceTarget = e.TotalCustomerPerformanceTarget,
                CurrentMonthTotalCustomerPerformance = e.CurrentMonthTotalCustomerPerformance,
                HistoryMonthTotalCustomerPerformance = e.HistoryMonthTotalCustomerPerformance,
                TotalCustomerTargetComplete = e.TotalCustomerTargetComplete,
                TotalCustomerChainRatio = e.TotalCustomerChainRatio,
                NewAndOldCustomerRate = e.NewAndOldCustomerRate,
                PerformanceRate = e.PerformanceRate
            }).ToList();
            return ResultData<List<AssistantTargetCompleteVo>>.Success().AddData("data", res);
        }

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
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
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
            queryDto.IsCurrentMonth = query.IsCurrentMonth;
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
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
            queryDto.ShowLuLu = query.ShowLuLu;
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

        #region 助理医美数据运营看板
        /// <summary>
        /// 助理业绩
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("assistantPerformance")]
        public async Task<ResultData<AssistantPerformanceVo>> GetAssitantPerformanceAsync([FromQuery]QueryAssistantPerformanceVo query)
        {
            QueryAssistantPerformanceDto queryDto = new QueryAssistantPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.AssistantId = query.AssistantId;
            var res = await amiyaOperationsBoardService.GetAssitantPerformanceAsync(queryDto);
            AssistantPerformanceVo performanceVo = new AssistantPerformanceVo();
            performanceVo.NewCustomerPerformance = res.NewCustomerPerformance;
            performanceVo.OldCustomerPerformance = res.OldCustomerPerformance;
            performanceVo.TotalPerformance = res.TotalPerformance;
            performanceVo.TodayNewCustomerPerformance = res.TodayNewCustomerPerformance;
            performanceVo.TodayOldCustomerPerformance = res.TodayOldCustomerPerformance;
            performanceVo.TodayTotalPerformance = res.TodayTotalPerformance;
            performanceVo.LastMonthNewCustomerPerformance = res.LastMonthNewCustomerPerformance;
            performanceVo.LastMonthOldCustomerPerformance = res.LastMonthOldCustomerPerformance;
            performanceVo.LastMonthTotalPerformance = res.LastMonthTotalPerformance;
            performanceVo.LastYearNewCustomerPerformance = res.LastYearNewCustomerPerformance;
            performanceVo.LastYearOldCustomerPerformance = res.LastYearOldCustomerPerformance;
            performanceVo.LastYearTotalPerformance = res.LastYearTotalPerformance;
            performanceVo.NewCustomerPerformanceChain = res.NewCustomerPerformanceChain;
            performanceVo.OldCustomerPerformanceChain = res.OldCustomerPerformanceChain;
            performanceVo.TotalPerformanceChain = res.TotalPerformanceChain;
            performanceVo.NewCustomerPerformanceYearOnYear = res.NewCustomerPerformanceYearOnYear;
            performanceVo.OldCustomerPerformanceYearOnYear = res.OldCustomerPerformanceYearOnYear;
            performanceVo.TotalPerformanceYearOnYear = res.TotalPerformanceYearOnYear;
            performanceVo.NewCustomerPerformanceTarget = res.NewCustomerPerformanceTarget;
            performanceVo.OldCustomerPerformanceTarget = res.OldCustomerPerformanceTarget;
            performanceVo.TotalPerformanceTarget = res.TotalPerformanceTarget;
            performanceVo.NewCustomerPerformanceTargetCompleteRate = res.NewCustomerPerformanceTargetCompleteRate;
            performanceVo.OldCustomerPerformanceTargetCompleteRate = res.OldCustomerPerformanceTargetCompleteRate;
            performanceVo.TotalPerformanceTargetCompleteRate = res.TotalPerformanceTargetCompleteRate;
            performanceVo.NewCustomerPerformanceTargetSchedule = res.NewCustomerPerformanceTargetSchedule;
            performanceVo.OldCustomerPerformanceTargetSchedule = res.OldCustomerPerformanceTargetSchedule;
            performanceVo.TotalPerformanceTargetSchedule = res.TotalPerformanceTargetSchedule;
            return ResultData<AssistantPerformanceVo>.Success().AddData("data", performanceVo);
        }
        /// <summary>
        /// 助理业绩折线图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("brokenLineData")]
        public async Task<ResultData<AssistantPerformanceBrokenLineVo>> GetAssistantPerformanceBrokenLineAsync([FromQuery] QueryAssistantPerformanceVo query)
        {
            AssistantPerformanceBrokenLineVo performanceBroken = new AssistantPerformanceBrokenLineVo();
            QueryAssistantPerformanceDto queryDto = new QueryAssistantPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.AssistantId = query.AssistantId;
            var res = await amiyaOperationsBoardService.GetAssistantPerformanceBrokenLineDto(queryDto);
            performanceBroken.NewCustomerPerformance = res.NewCustomerPerformance.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            performanceBroken.OldCustomerPerformance = res.OldCustomerPerformance.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            performanceBroken.TotalPerformance = res.OldCustomerPerformance.Select(e => new PerformanceBrokenLineListInfoVo
            {
                date = e.date,
                Performance = e.Performance
            }).ToList();
            return ResultData<AssistantPerformanceBrokenLineVo>.Success().AddData("data", performanceBroken);
        }
        /// <summary>
        /// 助理新老客业绩漏斗图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("assistantPerformanceFilterData")]
        public async Task<ResultData<AssistantOperationDataVo>> GetAssistantPerformanceFilterDataAsync([FromQuery]QueryAssistantPerformanceFilterDataVo query) {
            AssistantOperationDataVo result = new AssistantOperationDataVo();
            QueryAssistantPerformanceFilterDataDto queryDto = new QueryAssistantPerformanceFilterDataDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.AssistantId = query.AssistantId;
            queryDto.IsEffectiveCustomerData = query.IsEffectiveCustomerData;
            var performance = await amiyaOperationsBoardService.GetAssistantPerformanceFilterDataAsync(queryDto);
            result.NewCustomerData = performance.NewCustomerData.Select(e=>new DataItemVo { 
                Key=e.Key,
                Name=e.Name,
                Value=e.Value
            }).ToList();
            result.OldCustomerData = performance.OldCustomerData.Select(e => new DataItemVo
            {
                Key = e.Key,
                Name = e.Name,
                Value = e.Value
            }).ToList(); ;
            return ResultData<AssistantOperationDataVo>.Success().AddData("data",result);


        }
        /// <summary>
        /// 助理业绩分析数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("analysisData")]
        public async Task<ResultData<AssiatantPerformanceAnalysisDataVo>> GetPerformanceAnalysisDataAsync([FromQuery] QueryAssistantPerformanceVo query)
        {
            AssiatantPerformanceAnalysisDataVo analysisData = new AssiatantPerformanceAnalysisDataVo();
            QueryAssistantPerformanceDto queryDto = new QueryAssistantPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.AssistantId = query.AssistantId;
            var res = await amiyaOperationsBoardService.GetAssistantPerformanceAnalysisDataAsync(queryDto);
            analysisData.DistributeConsulationData.EffictiveRate = res.DistributeConsulationData.EffictiveRate;
            analysisData.DistributeConsulationData.NotEffictiveRate = res.DistributeConsulationData.NotEffictiveRate;
            analysisData.DistributeConsulationData.EffictiveNumber = res.DistributeConsulationData.EffictiveNumber;
            analysisData.DistributeConsulationData.NotEffictiveNumber = res.DistributeConsulationData.NotEffictiveNumber;
            analysisData.DistributeConsulationData.TotalFlowRateNumber = res.DistributeConsulationData.TotalFlowRateNumber;

            analysisData.PerformanceEffictiveOrNoData.EffictivePerformanceNumber = res.PerformanceEffictiveOrNoData.EffictivePerformanceNumber;
            analysisData.PerformanceEffictiveOrNoData.EffictivePerformanceRate = res.PerformanceEffictiveOrNoData.EffictivePerformanceRate;
            analysisData.PerformanceEffictiveOrNoData.NotEffictivePerformanceNumber = res.PerformanceEffictiveOrNoData.NotEffictivePerformanceNumber;
            analysisData.PerformanceEffictiveOrNoData.NotEffictivePerformanceRate = res.PerformanceEffictiveOrNoData.NotEffictivePerformanceRate;
            analysisData.PerformanceEffictiveOrNoData.TotalPerformanceNumber = res.PerformanceEffictiveOrNoData.TotalPerformanceNumber;

            analysisData.SendOrderData.ThisMonthPerformanceNumber = res.SendOrderData.ThisMonthPerformanceNumber;
            analysisData.SendOrderData.ThisMonthPerformanceRate = res.SendOrderData.ThisMonthPerformanceRate;
            analysisData.SendOrderData.HistoryPerformanceNumber = res.SendOrderData.HistoryPerformanceNumber;
            analysisData.SendOrderData.HistoryPerformanceRate = res.SendOrderData.HistoryPerformanceRate;
            analysisData.SendOrderData.TotalPerformanceNumber = res.SendOrderData.TotalPerformanceNumber;

            analysisData.PerformanceHistoryOrNoData.ThisMonthPerformanceNumber = res.PerformanceHistoryOrNoData.ThisMonthPerformanceNumber;
            analysisData.PerformanceHistoryOrNoData.ThisMonthPerformanceRate = res.PerformanceHistoryOrNoData.ThisMonthPerformanceRate;
            analysisData.PerformanceHistoryOrNoData.HistoryPerformanceNumber = res.PerformanceHistoryOrNoData.HistoryPerformanceNumber;
            analysisData.PerformanceHistoryOrNoData.HistoryPerformanceRate = res.PerformanceHistoryOrNoData.HistoryPerformanceRate;
            analysisData.PerformanceHistoryOrNoData.TotalPerformanceNumber = res.PerformanceHistoryOrNoData.TotalPerformanceNumber;

            analysisData.CustomerDealData.TotalPerformanceNewCustomerRate = res.CustomerDealData.TotalPerformanceNewCustomerRate;
            analysisData.CustomerDealData.TotalPerformanceOldCustomerRate = res.CustomerDealData.TotalPerformanceOldCustomerRate;
            analysisData.CustomerDealData.TotalPerformanceNewCustomerNumber = res.CustomerDealData.TotalPerformanceNewCustomerNumber;
            analysisData.CustomerDealData.TotalPerformanceOldCustomerNumber = res.CustomerDealData.TotalPerformanceOldCustomerNumber;
            analysisData.CustomerDealData.TotalPerformanceNumber = res.CustomerDealData.TotalPerformanceNumber;

            analysisData.PerformanceNewCustonerOrNoData.TotalPerformanceNewCustomerRate = res.PerformanceNewCustonerOrNoData.TotalPerformanceNewCustomerRate;
            analysisData.PerformanceNewCustonerOrNoData.TotalPerformanceOldCustomerRate = res.PerformanceNewCustonerOrNoData.TotalPerformanceOldCustomerRate;
            analysisData.PerformanceNewCustonerOrNoData.TotalPerformanceNewCustomerNumber = res.PerformanceNewCustonerOrNoData.TotalPerformanceNewCustomerNumber;
            analysisData.PerformanceNewCustonerOrNoData.TotalPerformanceOldCustomerNumber = res.PerformanceNewCustonerOrNoData.TotalPerformanceOldCustomerNumber;
            analysisData.PerformanceNewCustonerOrNoData.TotalPerformanceNumber = res.PerformanceNewCustonerOrNoData.TotalPerformanceNumber;

            return ResultData<AssiatantPerformanceAnalysisDataVo>.Success().AddData("data", analysisData);
        }
        /// <summary>
        /// 助理机构业绩数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("assistantHospitalPerformanceData")]
        public async Task<ResultData<List<AssistantHospitalPerformanceVo>>> GetAssistantHospitalPerformanceDataAsync([FromQuery] QueryAssistantPerformanceVo query)
        {
            QueryAssistantPerformanceDto queryDto = new QueryAssistantPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.AssistantId = query.AssistantId;
            var res = await amiyaOperationsBoardService.GetAssistantHospitalPerformanceDataAsync(queryDto);
            var result = res.Select(e => new AssistantHospitalPerformanceVo
            {
                Name = e.Name,
                NewCustomerPerformance = e.NewCustomerPerformance,
                OldCustomerPerformance = e.OldCustomerPerformance,
                TotalPerformance = e.TotalPerformance
            }).ToList();
            return ResultData<List<AssistantHospitalPerformanceVo>>.Success().AddData("data", result);
        }
        /// <summary>
        /// 助理机构线索数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("assistantHospitalCluesData")]
        public async Task<ResultData<AssistantHospitalCluesDataVo>> GetAssistantHospitalCluesDataAsync([FromQuery] QueryAssistantPerformanceVo query)
        {
            AssistantHospitalCluesDataVo dataVo = new AssistantHospitalCluesDataVo();
            QueryAssistantPerformanceDto queryDto = new QueryAssistantPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.AssistantId = query.AssistantId;
            var res = await amiyaOperationsBoardService.GetAssistantHospitalCluesDataAsync(queryDto);
            dataVo.TotalSendOrderCount = res.TotalSendOrderCount;
            dataVo.TotalVisitCount = res.TotalVisitCount;
            dataVo.TotalDealCount = res.TotalDealCount;
            dataVo.Items = res.Items.OrderByDescending(e=>e.SendOrderCount).Select(e => new AssistantCluesDataItemVo
            {
                Name = e.Name,
                SendOrderCount = e.SendOrderCount,
                VisitCount = e.VisitCount,
                DealCount = e.DealCount
            }).ToList();
            return ResultData<AssistantHospitalCluesDataVo>.Success().AddData("data", dataVo);
        }
        /// <summary>
        /// 助理目标完成率和助理业绩占比柱状图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("assiatantTargetCompleteAndPerformanceRateData")]
        public async Task<ResultData<AssiatantTargetCompleteAndPerformanceRateVo>> GetAssiatantTargetCompleteAndPerformanceRateDataAsync([FromQuery] QueryAssistantPerformanceVo query)
        {
            AssiatantTargetCompleteAndPerformanceRateVo result = new AssiatantTargetCompleteAndPerformanceRateVo();
            QueryAssistantPerformanceDto queryDto = new QueryAssistantPerformanceDto();
            queryDto.StartDate = query.StartDate;
            queryDto.EndDate = query.EndDate;
            queryDto.AssistantId = query.AssistantId;
            var res = await amiyaOperationsBoardService.GetAssiatantTargetCompleteAndPerformanceRateDataAsync(queryDto);
            result.PerformanceRateData = res.PerformanceRateData.OrderByDescending(e => e.Value).Select(e => new BaseIdAndNameVo<string, decimal>
            {
                Id = e.Key,
                Name = e.Value,
            }).ToList();
            result.TargetCompleteData = res.TargetCompleteData.OrderByDescending(e => e.Value).Select(e => new BaseIdAndNameVo<string, decimal>
            {
                Id = e.Key,
                Name = e.Value,
            }).ToList();
            result.PerformanceRateData.RemoveAll(e => e.Name == 0m);
            result.TargetCompleteData.RemoveAll(e => e.Name == 0m);
            return ResultData<AssiatantTargetCompleteAndPerformanceRateVo>.Success().AddData("data", result);
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
