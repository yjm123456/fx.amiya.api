

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
            customerPerformanceVo.NewCustomerPrice = selectResult.NewCustomerPrice;
            customerPerformanceVo.OldCustomerPrice = selectResult.OldCustomerPrice;
            customerPerformanceVo.NewCustomerNum = selectResult.NewCustomerNum;
            customerPerformanceVo.SequentCustomerNum = selectResult.SequentCustomerNum;
            customerPerformanceVo.DealNum = selectResult.DealNum;
            customerPerformanceVo.OldCustomerNum = selectResult.OldCustomerNum;
            customerPerformanceVo.NewOrOldCustomerRate = selectResult.NewOrOldCustomerRate;
            customerPerformanceVo.VisitRate = selectResult.VisitRate;
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
            customerPerformanceVo.NewCustomerPerformance = selectResult.NewCustomerPerformance;
            customerPerformanceVo.OldCustomerPerformance = selectResult.OldCustomerPerformance;
            customerPerformanceVo.VisitNumRatio = selectResult.VisitNumRatio;

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
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("hospitalPerformance")]
        public async Task<ResultData<List<HospitalPerformanceVo>>> GetHospitalPerformanceAsync(int? year, int? month)
        {
            List<HospitalPerformanceVo> hospitalPerformanceVo = new List<HospitalPerformanceVo>();
            var hospitalPerformanceDatasResult = await hospitalPerformanceService.GetHospitalPerformanceBymonthBWAsync(year, month);
            var hospitalPerformanceDatasDecending = hospitalPerformanceDatasResult.OrderByDescending(x => x.TotalAchievement).ToList();
            var hospitalPerformanceDatas = hospitalPerformanceDatasDecending.Take(10).ToList();
            var totalAchievement = hospitalPerformanceDatasDecending.Sum(x => x.TotalAchievement);
            foreach (var x in hospitalPerformanceDatas)
            {
                HospitalPerformanceVo hospitalOperatingDataVo = new HospitalPerformanceVo();
                hospitalOperatingDataVo.HospitalName = x.HospitalName;
                hospitalOperatingDataVo.HospitalLogo = x.HospitalLogo;
                hospitalOperatingDataVo.NewCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(x.NewCustomerAchievement);
                hospitalOperatingDataVo.OldCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(x.OldCustomerAchievement);
                hospitalOperatingDataVo.TotalAchievement = DecimalExtension.ChangePriceToTenThousand(x.TotalAchievement);
                hospitalOperatingDataVo.NewOrOldCustomerRate = x.NewOrOldCustomerRate;
                hospitalOperatingDataVo.TotalAchievementRatio = DecimalExtension.CalculateTargetComplete(x.TotalAchievement, totalAchievement);
                hospitalPerformanceVo.Add(hospitalOperatingDataVo);
            }

            //加入其他累计
            HospitalPerformanceVo otherHospitalOperatingDataVo = new HospitalPerformanceVo();
            otherHospitalOperatingDataVo.HospitalName = "其他";
            otherHospitalOperatingDataVo.HospitalLogo = "";
            otherHospitalOperatingDataVo.NewCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(hospitalPerformanceDatasDecending.Sum(x => x.NewCustomerAchievement) - hospitalPerformanceDatas.Sum(x => x.NewCustomerAchievement));
            otherHospitalOperatingDataVo.OldCustomerAchievement = DecimalExtension.ChangePriceToTenThousand(hospitalPerformanceDatasDecending.Sum(x => x.OldCustomerAchievement) - hospitalPerformanceDatas.Sum(x => x.OldCustomerAchievement));
            otherHospitalOperatingDataVo.TotalAchievement = DecimalExtension.ChangePriceToTenThousand(hospitalPerformanceDatasDecending.Sum(x => x.TotalAchievement) - hospitalPerformanceDatas.Sum(x => x.TotalAchievement));
            otherHospitalOperatingDataVo.NewOrOldCustomerRate = DecimalExtension.CalculateAccounted(otherHospitalOperatingDataVo.NewCustomerAchievement, otherHospitalOperatingDataVo.OldCustomerAchievement);
            otherHospitalOperatingDataVo.TotalAchievementRatio = DecimalExtension.CalculateTargetComplete(otherHospitalOperatingDataVo.TotalAchievement, DecimalExtension.ChangePriceToTenThousand(totalAchievement));
            hospitalPerformanceVo.Add(otherHospitalOperatingDataVo);
            return ResultData<List<HospitalPerformanceVo>>.Success().AddData("performance", hospitalPerformanceVo);
        }
        #endregion
    }
}
