

using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.BusinessWeChat.Api.Vo.OrderCheckPicture;
using Fx.Amiya.BusinessWeChat.Api.Vo.Performance;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaPerformanceService"></param>
        public AmiyaBusinessPerformanceController(IAmiyaPerformanceService amiyaPerformanceService)
        {
            this.amiyaPerformanceService = amiyaPerformanceService;
        }

        #region 【总业绩】
        /// <summary>
        /// 获取总业绩数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("TotalPerformance")]
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
        [HttpGet("PerformanceByLiveAnchorName")]
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



    }
}
