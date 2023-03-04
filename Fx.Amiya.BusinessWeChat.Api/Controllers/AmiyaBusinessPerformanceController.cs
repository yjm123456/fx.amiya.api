﻿

using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.BusinessWeChat.Api.Vo.OrderCheckPicture;
using Fx.Amiya.BusinessWeChat.Api.Vo.Performance;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
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
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorBaseId">主播基础id，不传查询所有</param>
        /// <param name="isSelfLiveAnchor">是否为自播主播</param>
        /// <returns></returns>
        [HttpGet("performanceByLiveAnchorName")]
        public async Task<ResultData<LiveAnchorMonthPerformanceVo>> GetPerformanceByGroupAsync(int year, int month, string liveAnchorBaseId, bool? isSelfLiveAnchor)
        {
            //获取当前月同比,环比等数据
            var groupPerformance = await amiyaPerformanceService.GetMonthPerformanceBySelfLiveAnchorAsync(year, month, liveAnchorBaseId, isSelfLiveAnchor);

            //数据组合
            LiveAnchorMonthPerformanceVo monthPerformanceRatioDto = new LiveAnchorMonthPerformanceVo
            {
                CueerntMonthTotalPerformance = groupPerformance.CueerntMonthTotalPerformance,
                TotalPerformanceYearOnYear = groupPerformance.TotalPerformanceYearOnYear,
                TotalPerformanceChainratio = groupPerformance.TotalPerformanceChainratio,
                TotalPerformanceTarget = groupPerformance.TotalPerformanceTarget,
                TotalPerformanceTargetComplete = groupPerformance.TotalPerformanceTargetComplete,

                CurrentMonthNewCustomerPerformance = groupPerformance.CurrentMonthNewCustomerPerformance,
                NewCustomerPerformanceRatio = groupPerformance.NewCustomerPerformanceRatio,
                NewCustomerPerformanceYearOnYear = groupPerformance.NewCustomerPerformanceYearOnYear,
                NewCustomerPerformanceChainRatio = groupPerformance.NewCustomerPerformanceChainRatio,
                NewCustomerPerformanceTarget = groupPerformance.NewCustomerPerformanceTarget,
                NewCustomerPerformanceTargetComplete = groupPerformance.NewCustomerPerformanceTargetComplete,

                CurrentMonthOldCustomerPerformance = groupPerformance.CurrentMonthOldCustomerPerformance,
                OldCustomerPerformanceRatio = groupPerformance.OldCustomerPerformanceRatio,
                OldCustomerPerformanceYearOnYear = groupPerformance.OldCustomerPerformanceYearOnYear,
                OldCustomerPerformanceChainRatio = groupPerformance.OldCustomerPerformanceChainRatio,
                OldCustomerTarget = groupPerformance.OldCustomerTarget,
                OldCustomerTargetComplete = groupPerformance.OldCustomerTargetComplete,


                PictureConsultationPerformance = groupPerformance.PictureConsultationPerformance,
                PictureConsultationPerformanceRatio = groupPerformance.PictureConsultationPerformanceRatio,
                PictureConsultationPerformanceYearOnYear = groupPerformance.PictureConsultationPerformanceYearOnYear,
                PictureConsultationPerformanceChainRatio = groupPerformance.PictureConsultationPerformanceChainRatio,

                VideoConsultationPerformance = groupPerformance.VideoConsultationPerformance,
                VideoConsultationPerformanceRatio = groupPerformance.VideoConsultationPerformanceRatio,
                VideoConsultationPerformanceYearOnYear = groupPerformance.VideoConsultationPerformanceYearOnYear,
                VideoConsultationPerformanceChainRatio = groupPerformance.VideoConsultationPerformanceChainRatio,


                AcompanyingPerformance = groupPerformance.AcompanyingPerformance,
                AcompanyingPerformanceRatio = groupPerformance.AcompanyingPerformanceRatio,
                AcompanyingPerformanceYearOnYear = groupPerformance.AcompanyingPerformanceYearOnYear,
                AcompanyingPerformanceChainRatio = groupPerformance.AcompanyingPerformanceChainRatio,


                NotAcompanyingPerformance = groupPerformance.NotAcompanyingPerformance,
                NotAcompanyingPerformanceRatio = groupPerformance.NotAcompanyingPerformanceRatio,
                NotAcompanyingPerformanceYearOnYear = groupPerformance.NotAcompanyingPerformanceYearOnYear,
                NotAcompanyingPerformanceChainRatio = groupPerformance.NotAcompanyingPerformanceChainRatio,


                ZeroPricePerformance = groupPerformance.ZeroPricePerformance,
                ZeroPricePerformanceRatio = groupPerformance.ZeroPricePerformanceRatio,
                ZeroPricePerformanceYearOnYear = groupPerformance.ZeroPricePerformanceYearOnYear,
                ZeroPricePerformanceChainRatio = groupPerformance.ZeroPricePerformanceChainRatio,


                ExistPricePerformance = groupPerformance.ExistPricePerformance,
                ExistPricePerformanceRatio = groupPerformance.ExistPricePerformanceRatio,
                ExistPricePerformanceYearOnYear = groupPerformance.ExistPricePerformanceYearOnYear,
                ExistPricePerformanceChainRatio = groupPerformance.ExistPricePerformanceChainRatio,


                HistorySendDuringMonthDeal = groupPerformance.HistorySendDuringMonthDeal,
                HistorySendDuringMonthDealPerformanceRatio = groupPerformance.HistorySendDuringMonthDealPerformanceRatio,
                HistorySendDuringMonthDealYearOnYear = groupPerformance.HistorySendDuringMonthDealYearOnYear,
                HistorySendDuringMonthDealChainRatio = groupPerformance.HistorySendDuringMonthDealChainRatio,


                DuringMonthSendDuringMonthDeal = groupPerformance.DuringMonthSendDuringMonthDeal,
                DuringMonthSendDuringMonthDealPerformanceRatio = groupPerformance.DuringMonthSendDuringMonthDealPerformanceRatio,
                DuringMonthSendDuringMonthDealYearOnYear = groupPerformance.DuringMonthSendDuringMonthDealYearOnYear,
                DuringMonthSendDuringMonthDealChainRatio = groupPerformance.DuringMonthSendDuringMonthDealChainRatio,


            };

            return ResultData<LiveAnchorMonthPerformanceVo>.Success().AddData("performance", monthPerformanceRatioDto);
        }

        #endregion

        #region【助理业绩(todo;)】

        #endregion

        #region 【机构业绩】

        /// <summary>
        /// 获取机构业绩数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("hospitalPerformance")]
        public async Task<ResultData<List<HospitalPerformanceVo>>> GetHospitalPerformanceAsync(int? year, int? month)
        {
            DecimalChangeHelper decimalChangeHelper = new DecimalChangeHelper();
            List<HospitalPerformanceVo> hospitalPerformanceVo = new List<HospitalPerformanceVo>();
            var hospitalPerformanceDatasResult = await hospitalPerformanceService.GetHospitalPerformanceBymonthBWAsync(year, month);
            var hospitalPerformanceDatasDecending = hospitalPerformanceDatasResult.OrderByDescending(x => x.TotalAchievement).ToList();
            var hospitalPerformanceDatas = hospitalPerformanceDatasDecending.Take(10).ToList();
            var totalAchievement = hospitalPerformanceDatasDecending.Sum(x => x.TotalAchievement);
            foreach (var x in hospitalPerformanceDatas)
            {
                HospitalPerformanceVo hospitalOperatingDataVo = new HospitalPerformanceVo();
                hospitalOperatingDataVo.HospitalName = x.HospitalName;
                hospitalOperatingDataVo.SendNum = x.SendNum;
                hospitalOperatingDataVo.VisitNum = x.VisitNum;
                hospitalOperatingDataVo.HospitalLogo = x.HospitalLogo;
                hospitalOperatingDataVo.VisitRate = x.VisitRate;
                hospitalOperatingDataVo.NewCustomerDealNum = x.NewCustomerDealNum;
                hospitalOperatingDataVo.NewCustomerDealRate = x.NewCustomerDealRate;
                hospitalOperatingDataVo.NewCustomerAchievement = x.NewCustomerAchievement;
                hospitalOperatingDataVo.NewCustomerUnitPrice = x.NewCustomerUnitPrice;
                hospitalOperatingDataVo.OldCustomerDealNum = x.OldCustomerDealNum;
                hospitalOperatingDataVo.OldCustomerAchievement = x.OldCustomerAchievement;
                hospitalOperatingDataVo.OldCustomerUnitPrice = x.OldCustomerUnitPrice;
                hospitalOperatingDataVo.TotalAchievement = x.TotalAchievement;
                hospitalOperatingDataVo.NewOrOldCustomerRate = x.NewOrOldCustomerRate;
                hospitalOperatingDataVo.TotalAchievementRatio = decimalChangeHelper.CalculateTargetComplete(x.TotalAchievement, totalAchievement);
                hospitalPerformanceVo.Add(hospitalOperatingDataVo);
            }

            //加入其他累计
            HospitalPerformanceVo otherHospitalOperatingDataVo = new HospitalPerformanceVo();
            otherHospitalOperatingDataVo.HospitalName = "其他";
            otherHospitalOperatingDataVo.SendNum = hospitalPerformanceDatasDecending.Sum(x => x.SendNum) - hospitalPerformanceDatas.Sum(x => x.SendNum);
            otherHospitalOperatingDataVo.VisitNum = hospitalPerformanceDatasDecending.Sum(x => x.VisitNum) - hospitalPerformanceDatas.Sum(x => x.VisitNum);
            otherHospitalOperatingDataVo.HospitalLogo = "";
            otherHospitalOperatingDataVo.VisitRate = 0.00M;
            otherHospitalOperatingDataVo.NewCustomerDealNum = hospitalPerformanceDatasDecending.Sum(x => x.NewCustomerDealNum) - hospitalPerformanceDatas.Sum(x => x.NewCustomerDealNum);
            otherHospitalOperatingDataVo.NewCustomerDealRate = 0.00M;
            otherHospitalOperatingDataVo.NewCustomerAchievement = hospitalPerformanceDatasDecending.Sum(x => x.NewCustomerAchievement) - hospitalPerformanceDatas.Sum(x => x.NewCustomerAchievement);
            otherHospitalOperatingDataVo.NewCustomerUnitPrice = 0.00M;
            otherHospitalOperatingDataVo.OldCustomerDealNum = hospitalPerformanceDatasDecending.Sum(x => x.OldCustomerDealNum) - hospitalPerformanceDatas.Sum(x => x.OldCustomerDealNum);
            otherHospitalOperatingDataVo.OldCustomerAchievement = hospitalPerformanceDatasDecending.Sum(x => x.OldCustomerAchievement) - hospitalPerformanceDatas.Sum(x => x.OldCustomerAchievement);
            otherHospitalOperatingDataVo.OldCustomerUnitPrice = 0.00M;
            otherHospitalOperatingDataVo.TotalAchievement = hospitalPerformanceDatasDecending.Sum(x => x.TotalAchievement) - hospitalPerformanceDatas.Sum(x => x.TotalAchievement);
            otherHospitalOperatingDataVo.NewOrOldCustomerRate = "/";
            otherHospitalOperatingDataVo.TotalAchievementRatio = decimalChangeHelper.CalculateTargetComplete(otherHospitalOperatingDataVo.TotalAchievement, totalAchievement);
            hospitalPerformanceVo.Add(otherHospitalOperatingDataVo);
            return ResultData<List<HospitalPerformanceVo>>.Success().AddData("performance", hospitalPerformanceVo);
        }
        #endregion
    }
}
