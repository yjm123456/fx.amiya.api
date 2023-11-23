

using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.BusinessWeChat.Api.Vo.OrderCheckPicture;
using Fx.Amiya.BusinessWeChat.Api.Vo.Performance;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Common.Extensions;
using Fx.Common.Utils;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 数据中心板块接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaBusinessPerformanceController : ControllerBase
    {
        private IAmiyaPerformanceService amiyaPerformanceService;
        private IHospitalPerformanceService hospitalPerformanceService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaPerformanceService"></param>
        /// <param name="hospitalPerformanceService"></param>
        public AmiyaBusinessPerformanceController(IAmiyaPerformanceService amiyaPerformanceService, IHospitalPerformanceService hospitalPerformanceService)
        {
            this.amiyaPerformanceService = amiyaPerformanceService;
            this.hospitalPerformanceService = hospitalPerformanceService;
        }

        #region 【总业绩】
        /// <summary>
        /// 获取总业绩数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("totalPerformance")]
        public async Task<ResultData<CompanyMonthPerformanceVo>> GetTotalPerformanceAsync(int year, int month)
        {
            //获取当前月同比,环比等数据
            var groupPerformance = await amiyaPerformanceService.GetMonthPerformanceAsync(year, month);

            //数据组合
            CompanyMonthPerformanceVo monthPerformanceRatioDto = new CompanyMonthPerformanceVo
            {
                SelfLiveAnchorPerformance = groupPerformance.SelfLiveAnchorPerformance,
                SelfLiveAnchorPerformanceTarget = groupPerformance.SelfLiveAnchorPerformanceTarget,
                SelfLiveAnchorPerformanceCompleteRate = groupPerformance.SelfLiveAnchorPerformanceCompleteRate,
                SelfLiveAnchorPerformanceYearToYear = groupPerformance.SelfLiveAnchorPerformanceYearToYear,
                SelfLiveAnchorPerformanceChainRatio = groupPerformance.SelfLiveAnchorPerformanceChainRatio,

                OtherLiveAnchorPerformance = groupPerformance.OtherLiveAnchorPerformance,
                OtherLiveAnchorPerformanceTarget = groupPerformance.OtherLiveAnchorPerformanceTarget,
                OtherLiveAnchorPerformanceCompleteRate = groupPerformance.OtherLiveAnchorPerformanceCompleteRate,
                OtherLiveAnchorPerformanceYearToYear = groupPerformance.OtherLiveAnchorPerformanceYearToYear,
                OtherLiveAnchorPerformanceChainRatio = groupPerformance.OtherLiveAnchorPerformanceChainRatio,

                CommercePerformance = groupPerformance.CommercePerformance,
                CommercePerformanceTarget = groupPerformance.CommercePerformanceTarget,
                CommercePerformanceCompleteRate = groupPerformance.CommercePerformanceCompleteRate,
                CommercePerformanceYearToYear = groupPerformance.CommercePerformanceYearToYear,
                CommercePerformanceChainRatio = groupPerformance.CommercePerformanceChainRatio,

                OtherPerformance = groupPerformance.OtherPerformance,
                OtherPerformanceTarget = groupPerformance.OtherPerformanceTarget,
                OtherPerformanceCompleteRate = groupPerformance.OtherPerformanceCompleteRate,
                OtherPerformanceYearToYear = groupPerformance.OtherPerformanceYearToYear,
                OtherPerformanceChainRatio = groupPerformance.OtherPerformanceChainRatio,

                TotalPerformance = groupPerformance.TotalPerformance,
                TotalPerformanceChainRatio = groupPerformance.TotalPerformanceChainRatio,
                SelfLiveAnchorPerformanceRatio = groupPerformance.SelfLiveAnchorPerformanceRatio,
                OtherLiveAnchorPerformanceRatio = groupPerformance.OtherLiveAnchorPerformanceRatio,
                CommercePerformanceRatio = groupPerformance.CommercePerformanceRatio,
                OtherPerformanceRatio = groupPerformance.OtherPerformanceRatio,


            };

            return ResultData<CompanyMonthPerformanceVo>.Success().AddData("performance", monthPerformanceRatioDto);
        }

        #endregion

        #region 【达人业绩】
        /// <summary>
        /// 获取达人业绩数据
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="liveAnchorBaseId">主播基础id，不传查询所有</param>
        /// <param name="isSelfLiveAnchor">是否为自播主播</param>
        /// <returns></returns>
        [HttpGet("performanceByLiveAnchorName")]
        public async Task<ResultData<LiveAnchorMonthAndDatePerformanceVo>> GetPerformanceByGroupAsync(DateTime date,  string liveAnchorBaseId, bool? isSelfLiveAnchor)
        {
            //获取当前月同比,环比等数据
            var groupPerformance = await amiyaPerformanceService.GetMonthPerformanceBySelfLiveAnchorAsync(date, liveAnchorBaseId, isSelfLiveAnchor);

            //数据组合
            LiveAnchorMonthPerformanceVo monthPerformanceRatioDto = new LiveAnchorMonthPerformanceVo
            {
                CueerntMonthTotalPerformance = groupPerformance.MonthDataVo.CueerntMonthTotalPerformance,
                TotalPerformanceYearOnYear = groupPerformance.MonthDataVo.TotalPerformanceYearOnYear,
                TotalPerformanceChainratio = groupPerformance.MonthDataVo.TotalPerformanceChainratio,
                TotalPerformanceTarget = groupPerformance.MonthDataVo.TotalPerformanceTarget,
                TotalPerformanceTargetComplete = groupPerformance.MonthDataVo.TotalPerformanceTargetComplete,

                CurrentMonthNewCustomerPerformance = groupPerformance.MonthDataVo.CurrentMonthNewCustomerPerformance,
                NewCustomerPerformanceRatio = groupPerformance.MonthDataVo.NewCustomerPerformanceRatio,
                NewCustomerPerformanceYearOnYear = groupPerformance.MonthDataVo.NewCustomerPerformanceYearOnYear,
                NewCustomerPerformanceChainRatio = groupPerformance.MonthDataVo.NewCustomerPerformanceChainRatio,
                NewCustomerPerformanceTarget = groupPerformance.MonthDataVo.NewCustomerPerformanceTarget,
                NewCustomerPerformanceTargetComplete = groupPerformance.MonthDataVo.NewCustomerPerformanceTargetComplete,

                CurrentMonthOldCustomerPerformance = groupPerformance.MonthDataVo.CurrentMonthOldCustomerPerformance,
                OldCustomerPerformanceRatio = groupPerformance.MonthDataVo.OldCustomerPerformanceRatio,
                OldCustomerPerformanceYearOnYear = groupPerformance.MonthDataVo.OldCustomerPerformanceYearOnYear,
                OldCustomerPerformanceChainRatio = groupPerformance.MonthDataVo.OldCustomerPerformanceChainRatio,
                OldCustomerTarget = groupPerformance.MonthDataVo.OldCustomerTarget,
                OldCustomerTargetComplete = groupPerformance.MonthDataVo.OldCustomerTargetComplete,


                PictureConsultationPerformance = groupPerformance.MonthDataVo.PictureConsultationPerformance,
                PictureConsultationPerformanceRatio = groupPerformance.MonthDataVo.PictureConsultationPerformanceRatio,
                PictureConsultationPerformanceYearOnYear = groupPerformance.MonthDataVo.PictureConsultationPerformanceYearOnYear,
                PictureConsultationPerformanceChainRatio = groupPerformance.MonthDataVo.PictureConsultationPerformanceChainRatio,

                VideoConsultationPerformance = groupPerformance.MonthDataVo.VideoConsultationPerformance,
                VideoConsultationPerformanceRatio = groupPerformance.MonthDataVo.VideoConsultationPerformanceRatio,
                VideoConsultationPerformanceYearOnYear = groupPerformance.MonthDataVo.VideoConsultationPerformanceYearOnYear,
                VideoConsultationPerformanceChainRatio = groupPerformance.MonthDataVo.VideoConsultationPerformanceChainRatio,


                AcompanyingPerformance = groupPerformance.MonthDataVo.AcompanyingPerformance,
                AcompanyingPerformanceRatio = groupPerformance.MonthDataVo.AcompanyingPerformanceRatio,
                AcompanyingPerformanceYearOnYear = groupPerformance.MonthDataVo.AcompanyingPerformanceYearOnYear,
                AcompanyingPerformanceChainRatio = groupPerformance.MonthDataVo.AcompanyingPerformanceChainRatio,


                NotAcompanyingPerformance = groupPerformance.MonthDataVo.NotAcompanyingPerformance,
                NotAcompanyingPerformanceRatio = groupPerformance.MonthDataVo.NotAcompanyingPerformanceRatio,
                NotAcompanyingPerformanceYearOnYear = groupPerformance.MonthDataVo.NotAcompanyingPerformanceYearOnYear,
                NotAcompanyingPerformanceChainRatio = groupPerformance.MonthDataVo.NotAcompanyingPerformanceChainRatio,


                ZeroPricePerformance = groupPerformance.MonthDataVo.ZeroPricePerformance,
                ZeroPricePerformanceRatio = groupPerformance.MonthDataVo.ZeroPricePerformanceRatio,
                ZeroPricePerformanceYearOnYear = groupPerformance.MonthDataVo.ZeroPricePerformanceYearOnYear,
                ZeroPricePerformanceChainRatio = groupPerformance.MonthDataVo.ZeroPricePerformanceChainRatio,


                ExistPricePerformance = groupPerformance.MonthDataVo.ExistPricePerformance,
                ExistPricePerformanceRatio = groupPerformance.MonthDataVo.ExistPricePerformanceRatio,
                ExistPricePerformanceYearOnYear = groupPerformance.MonthDataVo.ExistPricePerformanceYearOnYear,
                ExistPricePerformanceChainRatio = groupPerformance.MonthDataVo.ExistPricePerformanceChainRatio,


                HistorySendDuringMonthDeal = groupPerformance.MonthDataVo.HistorySendDuringMonthDeal,
                HistorySendDuringMonthDealPerformanceRatio = groupPerformance.MonthDataVo.HistorySendDuringMonthDealPerformanceRatio,
                HistorySendDuringMonthDealYearOnYear = groupPerformance.MonthDataVo.HistorySendDuringMonthDealYearOnYear,
                HistorySendDuringMonthDealChainRatio = groupPerformance.MonthDataVo.HistorySendDuringMonthDealChainRatio,


                DuringMonthSendDuringMonthDeal = groupPerformance.MonthDataVo.DuringMonthSendDuringMonthDeal,
                DuringMonthSendDuringMonthDealPerformanceRatio = groupPerformance.MonthDataVo.DuringMonthSendDuringMonthDealPerformanceRatio,
                DuringMonthSendDuringMonthDealYearOnYear = groupPerformance.MonthDataVo.DuringMonthSendDuringMonthDealYearOnYear,
                DuringMonthSendDuringMonthDealChainRatio = groupPerformance.MonthDataVo.DuringMonthSendDuringMonthDealChainRatio,


            };

            //数据组合
            LiveAnchorMonthPerformanceVo todayPerformanceRatioDto = new LiveAnchorMonthPerformanceVo
            {
                CueerntMonthTotalPerformance = groupPerformance.CurrentDateDataVo.CueerntMonthTotalPerformance,
                TotalPerformanceYearOnYear = groupPerformance.CurrentDateDataVo.TotalPerformanceYearOnYear,
                TotalPerformanceChainratio = groupPerformance.CurrentDateDataVo.TotalPerformanceChainratio,
                TotalPerformanceTarget = groupPerformance.CurrentDateDataVo.TotalPerformanceTarget,
                TotalPerformanceTargetComplete = groupPerformance.CurrentDateDataVo.TotalPerformanceTargetComplete,

                CurrentMonthNewCustomerPerformance = groupPerformance.CurrentDateDataVo.CurrentMonthNewCustomerPerformance,
                NewCustomerPerformanceRatio = groupPerformance.CurrentDateDataVo.NewCustomerPerformanceRatio,
                NewCustomerPerformanceYearOnYear = groupPerformance.CurrentDateDataVo.NewCustomerPerformanceYearOnYear,
                NewCustomerPerformanceChainRatio = groupPerformance.CurrentDateDataVo.NewCustomerPerformanceChainRatio,
                NewCustomerPerformanceTarget = groupPerformance.CurrentDateDataVo.NewCustomerPerformanceTarget,
                NewCustomerPerformanceTargetComplete = groupPerformance.CurrentDateDataVo.NewCustomerPerformanceTargetComplete,

                CurrentMonthOldCustomerPerformance = groupPerformance.CurrentDateDataVo.CurrentMonthOldCustomerPerformance,
                OldCustomerPerformanceRatio = groupPerformance.CurrentDateDataVo.OldCustomerPerformanceRatio,
                OldCustomerPerformanceYearOnYear = groupPerformance.CurrentDateDataVo.OldCustomerPerformanceYearOnYear,
                OldCustomerPerformanceChainRatio = groupPerformance.CurrentDateDataVo.OldCustomerPerformanceChainRatio,
                OldCustomerTarget = groupPerformance.CurrentDateDataVo.OldCustomerTarget,
                OldCustomerTargetComplete = groupPerformance.CurrentDateDataVo.OldCustomerTargetComplete,


                PictureConsultationPerformance = groupPerformance.CurrentDateDataVo.PictureConsultationPerformance,
                PictureConsultationPerformanceRatio = groupPerformance.CurrentDateDataVo.PictureConsultationPerformanceRatio,
                PictureConsultationPerformanceYearOnYear = groupPerformance.CurrentDateDataVo.PictureConsultationPerformanceYearOnYear,
                PictureConsultationPerformanceChainRatio = groupPerformance.CurrentDateDataVo.PictureConsultationPerformanceChainRatio,

                VideoConsultationPerformance = groupPerformance.CurrentDateDataVo.VideoConsultationPerformance,
                VideoConsultationPerformanceRatio = groupPerformance.CurrentDateDataVo.VideoConsultationPerformanceRatio,
                VideoConsultationPerformanceYearOnYear = groupPerformance.CurrentDateDataVo.VideoConsultationPerformanceYearOnYear,
                VideoConsultationPerformanceChainRatio = groupPerformance.CurrentDateDataVo.VideoConsultationPerformanceChainRatio,


                AcompanyingPerformance = groupPerformance.CurrentDateDataVo.AcompanyingPerformance,
                AcompanyingPerformanceRatio = groupPerformance.CurrentDateDataVo.AcompanyingPerformanceRatio,
                AcompanyingPerformanceYearOnYear = groupPerformance.CurrentDateDataVo.AcompanyingPerformanceYearOnYear,
                AcompanyingPerformanceChainRatio = groupPerformance.CurrentDateDataVo.AcompanyingPerformanceChainRatio,


                NotAcompanyingPerformance = groupPerformance.CurrentDateDataVo.NotAcompanyingPerformance,
                NotAcompanyingPerformanceRatio = groupPerformance.CurrentDateDataVo.NotAcompanyingPerformanceRatio,
                NotAcompanyingPerformanceYearOnYear = groupPerformance.CurrentDateDataVo.NotAcompanyingPerformanceYearOnYear,
                NotAcompanyingPerformanceChainRatio = groupPerformance.CurrentDateDataVo.NotAcompanyingPerformanceChainRatio,


                ZeroPricePerformance = groupPerformance.CurrentDateDataVo.ZeroPricePerformance,
                ZeroPricePerformanceRatio = groupPerformance.CurrentDateDataVo.ZeroPricePerformanceRatio,
                ZeroPricePerformanceYearOnYear = groupPerformance.CurrentDateDataVo.ZeroPricePerformanceYearOnYear,
                ZeroPricePerformanceChainRatio = groupPerformance.CurrentDateDataVo.ZeroPricePerformanceChainRatio,


                ExistPricePerformance = groupPerformance.CurrentDateDataVo.ExistPricePerformance,
                ExistPricePerformanceRatio = groupPerformance.CurrentDateDataVo.ExistPricePerformanceRatio,
                ExistPricePerformanceYearOnYear = groupPerformance.CurrentDateDataVo.ExistPricePerformanceYearOnYear,
                ExistPricePerformanceChainRatio = groupPerformance.CurrentDateDataVo.ExistPricePerformanceChainRatio,


                HistorySendDuringMonthDeal = groupPerformance.CurrentDateDataVo.HistorySendDuringMonthDeal,
                HistorySendDuringMonthDealPerformanceRatio = groupPerformance.CurrentDateDataVo.HistorySendDuringMonthDealPerformanceRatio,
                HistorySendDuringMonthDealYearOnYear = groupPerformance.CurrentDateDataVo.HistorySendDuringMonthDealYearOnYear,
                HistorySendDuringMonthDealChainRatio = groupPerformance.CurrentDateDataVo.HistorySendDuringMonthDealChainRatio,


                DuringMonthSendDuringMonthDeal = groupPerformance.CurrentDateDataVo.DuringMonthSendDuringMonthDeal,
                DuringMonthSendDuringMonthDealPerformanceRatio = groupPerformance.CurrentDateDataVo.DuringMonthSendDuringMonthDealPerformanceRatio,
                DuringMonthSendDuringMonthDealYearOnYear = groupPerformance.CurrentDateDataVo.DuringMonthSendDuringMonthDealYearOnYear,
                DuringMonthSendDuringMonthDealChainRatio = groupPerformance.CurrentDateDataVo.DuringMonthSendDuringMonthDealChainRatio,


            };

            LiveAnchorMonthAndDatePerformanceVo liveAnchorMonthAndDatePerformanceVo = new LiveAnchorMonthAndDatePerformanceVo();
            liveAnchorMonthAndDatePerformanceVo.MonthDataVo = monthPerformanceRatioDto;
            liveAnchorMonthAndDatePerformanceVo.CurrentDateDataVo = todayPerformanceRatioDto;
            return ResultData<LiveAnchorMonthAndDatePerformanceVo>.Success().AddData("performance", liveAnchorMonthAndDatePerformanceVo);
        }

        #endregion

        #region【助理业绩】

        /// <summary>
        /// 获取我的当月业绩排名
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="custonerServiceId"></param>
        /// <returns></returns>
        [HttpGet("getMyRank")]
        public async Task<ResultData<string>> GetMyRankAsync(int year, int month, int custonerServiceId)
        {
            var result = await amiyaPerformanceService.GetMyRankAsync(year, month, custonerServiceId);
            return ResultData<string>.Success().AddData("rank", result); ;
        }

        /// <summary>
        /// 获取助理业绩数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorBaseId"></param>
        /// <returns></returns>
        [HttpGet("customerServicePerformance")]
        public async Task<ResultData<List<CustomerPerformanceVo>>> GetCustomerServicePerformanceAsync(int year, int month, string liveAnchorBaseId)
        {
            List<CustomerPerformanceVo> performanceVo = new List<CustomerPerformanceVo>();
            var selectResult = await amiyaPerformanceService.GetBelongCustomerServicePerformanceByLiveAnchorBaseIdAsync(year, month, liveAnchorBaseId);
            foreach (var x in selectResult)
            {
                CustomerPerformanceVo customerPerformanceVo = new CustomerPerformanceVo();
                customerPerformanceVo.CustomerServiceId = x.CustomerServiceId;
                customerPerformanceVo.CustomerServiceName = x.CustomerServiceName;
                customerPerformanceVo.TotalPerformance = x.TotalPerformance;
                customerPerformanceVo.NewCustomerPerformance = x.NewCustomerPerformance;
                customerPerformanceVo.OldCustomerPerformance = x.OldCustomerPerformance;
                customerPerformanceVo.VisitNumRatio = x.VisitNumRatio;
                performanceVo.Add(customerPerformanceVo);
            }

            return ResultData<List<CustomerPerformanceVo>>.Success().AddData("performance", performanceVo);
        }


        /// <summary>
        /// 根据客服id获取助理简单业绩数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        [HttpGet("customerServiceSimplePerformanceById")]
        public async Task<ResultData<CustomerServiceSimplePerformanceVo>> GetCustomerServiceSimplePerformanceByIdAsync(int year, int month, int customerServiceId)
        {
            var selectResult = await amiyaPerformanceService.GetSimpleCustomerServicePerformanceDetails(year, month, customerServiceId);
            CustomerServiceSimplePerformanceVo customerPerformanceVo = new CustomerServiceSimplePerformanceVo();
            customerPerformanceVo.CustomerServiceName = selectResult.CustomerServiceName;
            customerPerformanceVo.Rank = selectResult.Rank == null ? "#" : selectResult.Rank;
            customerPerformanceVo.TotaPrice = selectResult.TotaPrice;
            customerPerformanceVo.SupportPrice = selectResult.SupportPrice;
            customerPerformanceVo.NewCustomerPrice = selectResult.NewCustomerPrice;
            customerPerformanceVo.OldCustomerPrice = selectResult.OldCustomerPrice;
            customerPerformanceVo.NewCustomerNum = selectResult.NewCustomerNum;
            customerPerformanceVo.SequentCustomerNum = selectResult.SequentCustomerNum;
            customerPerformanceVo.DealNum = selectResult.DealNum;
            customerPerformanceVo.OldCustomerNum = selectResult.OldCustomerNum;
            customerPerformanceVo.NewOrOldCustomerRate = selectResult.NewOrOldCustomerRate;
            customerPerformanceVo.VisitRate = selectResult.VisitRate;
            customerPerformanceVo.ThisMonthSendThisMonthVisitNumRatio = selectResult.ThisMonthSendThisMonthVisitNumRatio;
            List<CustomerServiceRankVo> CustomerServiceRankVoList = new List<CustomerServiceRankVo>();
            if (selectResult.CustomerServiceRankDtoList != null)
            {
                foreach (var x in selectResult.CustomerServiceRankDtoList)
                {
                    CustomerServiceRankVo customerServiceRankVo = new CustomerServiceRankVo();
                    customerServiceRankVo.RankId = x.RankId;
                    customerServiceRankVo.CustomerServiceName = x.CustomerServiceName;
                    customerServiceRankVo.TotalAchievement = x.TotalAchievement;
                    CustomerServiceRankVoList.Add(customerServiceRankVo);
                }
                customerPerformanceVo.CustomerServiceRankDtoList = CustomerServiceRankVoList;
            }
            return ResultData<CustomerServiceSimplePerformanceVo>.Success().AddData("performance", customerPerformanceVo);
        }

        /// <summary>
        /// 根据客服id获取助理详细业绩数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        [HttpGet("customerServiceDetailPerformanceById")]
        public async Task<ResultData<CustomerPerformanceDetailsVo>> GetCustomerServiceDetailPerformanceByIdAsync(int year, int month, int customerServiceId)
        {
            var selectResult = await amiyaPerformanceService.GetCustomerServicePerformanceDetails(year, month, customerServiceId);
            CustomerPerformanceDetailsVo customerPerformanceVo = new CustomerPerformanceDetailsVo();
            customerPerformanceVo.CustomerServiceName = selectResult.CustomerServiceName;
            customerPerformanceVo.TotalPerformance = selectResult.TotalPerformance;
            customerPerformanceVo.SupportPerformance = selectResult.SupportPerformance;
            customerPerformanceVo.NewCustomerPerformance = selectResult.NewCustomerPerformance;
            customerPerformanceVo.OldCustomerPerformance = selectResult.OldCustomerPerformance;
            customerPerformanceVo.VisitNumRatio = selectResult.VisitNumRatio;
            customerPerformanceVo.ThisMonthSendThisMonthVisitNumRatio = selectResult.ThisMonthSendThisMonthVisitNumRatio;

            customerPerformanceVo.VideoPerformance = selectResult.VideoPerformance;
            customerPerformanceVo.PicturePerformance = selectResult.PicturePerformance;
            customerPerformanceVo.VideoAndPictureCompare = selectResult.VideoAndPictureCompare;

            customerPerformanceVo.AcompanyingPerformance = selectResult.AcompanyingPerformance;
            customerPerformanceVo.NotAcompanyingPerformance = selectResult.NotAcompanyingPerformance;
            customerPerformanceVo.IsAcompanyingCompare = selectResult.IsAcompanyingCompare;

            customerPerformanceVo.ZeroPerformance = selectResult.ZeroPerformance;
            customerPerformanceVo.HavingPricePerformance = selectResult.HavingPricePerformance;
            customerPerformanceVo.ZeroAndHavingPriceCompare = selectResult.ZeroAndHavingPriceCompare;

            customerPerformanceVo.HistorySendThisMonthDealPerformance = selectResult.HistorySendThisMonthDealPerformance;
            customerPerformanceVo.ThisMonthSendThisMonthDealPerformance = selectResult.ThisMonthSendThisMonthDealPerformance;
            customerPerformanceVo.HistoryAndThisMonthCompare = selectResult.HistoryAndThisMonthCompare;
            return ResultData<CustomerPerformanceDetailsVo>.Success().AddData("performance", customerPerformanceVo);
        }


        #endregion

        #region 【机构业绩】

        /// <summary>
        /// 获取机构业绩数据
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("hospitalPerformance")]
        public async Task<ResultData<List<HospitalPerformanceVo>>> GetHospitalPerformanceAsync(DateTime date)
        {
            List<HospitalPerformanceVo> hospitalPerformanceVo = new List<HospitalPerformanceVo>();
            var hospitalPerformanceDatasResult = await hospitalPerformanceService.GetHospitalPerformanceBymonthBWAsync(date);
            var hospitalPerformanceDatasDecending = hospitalPerformanceDatasResult.OrderByDescending(x => x.TotalAchievement).ToList();
            var hospitalPerformanceDatas = hospitalPerformanceDatasDecending.ToList();
            // var hospitalPerformanceDatas = hospitalPerformanceDatasDecending.Take(20).ToList();
            var totalAchievement = hospitalPerformanceDatasDecending.Sum(x => x.TotalAchievement);
            var todaySumAchievement = hospitalPerformanceDatas.Sum(x => x.TodayTotalAchievement);
            foreach (var x in hospitalPerformanceDatas)
            {
                HospitalPerformanceVo hospitalOperatingDataVo = new HospitalPerformanceVo();
                hospitalOperatingDataVo.HospitalName = x.HospitalName;
                hospitalOperatingDataVo.HospitalLogo = x.HospitalLogo;
                //当月业绩
                hospitalOperatingDataVo.NewCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(x.NewCustomerAchievement);
                hospitalOperatingDataVo.OldCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(x.OldCustomerAchievement);
                hospitalOperatingDataVo.TotalAchievement = DecimalExtension.ChangePriceToTenThousand(x.TotalAchievement);
                hospitalOperatingDataVo.NewOrOldCustomerRate = x.NewOrOldCustomerRate;
                hospitalOperatingDataVo.TotalAchievementRatio = DecimalExtension.CalculateTargetComplete(x.TotalAchievement, totalAchievement);

                //当日业绩
                hospitalOperatingDataVo.TodayNewCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(x.TodayNewCustomerAchievement);
                hospitalOperatingDataVo.TodayOldCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(x.TodayOldCustomerAchievement);
                hospitalOperatingDataVo.TodayTotalAchievement = DecimalExtension.ChangePriceToTenThousand(x.TodayTotalAchievement);
                hospitalOperatingDataVo.TodayNewOrOldCustomerRate = x.TodayNewOrOldCustomerRate;
                hospitalOperatingDataVo.TodayTotalAchievementRatio = DecimalExtension.CalculateTargetComplete(x.TodayTotalAchievement, todaySumAchievement);
                hospitalPerformanceVo.Add(hospitalOperatingDataVo);
            }

            ////加入其他累计
            //HospitalPerformanceVo otherHospitalOperatingDataVo = new HospitalPerformanceVo();
            //otherHospitalOperatingDataVo.HospitalName = "其他";
            //otherHospitalOperatingDataVo.HospitalLogo = "";
            //otherHospitalOperatingDataVo.NewCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(hospitalPerformanceDatasDecending.Sum(x => x.NewCustomerAchievement) - hospitalPerformanceDatas.Sum(x => x.NewCustomerAchievement));
            //otherHospitalOperatingDataVo.OldCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(hospitalPerformanceDatasDecending.Sum(x => x.OldCustomerAchievement) - hospitalPerformanceDatas.Sum(x => x.OldCustomerAchievement));
            //otherHospitalOperatingDataVo.TotalAchievement = DecimalExtension.ChangePriceToTenThousand(hospitalPerformanceDatasDecending.Sum(x => x.TotalAchievement) - hospitalPerformanceDatas.Sum(x => x.TotalAchievement));
            //otherHospitalOperatingDataVo.NewOrOldCustomerRate = DecimalExtension.CalculateAccounted(otherHospitalOperatingDataVo.NewCustomerAchievement, otherHospitalOperatingDataVo.OldCustomerAchievement);
            //otherHospitalOperatingDataVo.TotalAchievementRatio = DecimalExtension.CalculateTargetComplete(otherHospitalOperatingDataVo.TotalAchievement, DecimalExtension.ChangePriceToTenThousand(totalAchievement));
            //hospitalPerformanceVo.Add(otherHospitalOperatingDataVo);
            return ResultData<List<HospitalPerformanceVo>>.Success().AddData("performance", hospitalPerformanceVo);
        }
        #endregion
    }
}
