using Fx.Amiya.Background.Api.Vo.Appointment;
using Fx.Amiya.Background.Api.Vo.OrderReport;
using Fx.Amiya.Background.Api.Vo.Performance;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{

    /// <summary>
    /// 啊美雅业绩接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AmiyaAchievementController : ControllerBase
    {
        private IOrderService orderService;
        private ISendOrderInfoService _sendOrderInfoService;
        private IShoppingCartRegistrationService _shoppingCartRegistrationService;
        private IContentPlatFormOrderDealInfoService _contentPlatFormOrderDealInfoService;
        private IHospitalInfoService _hospitalInfoService;
        private ICustomerService customerService;
        private IHttpContextAccessor httpContextAccessor;
        private IContentPlateFormOrderService _contentPlatFormOrderService;
        private IContentPlatformOrderSendService _sendContentPlatFormOrderInfoService;
        private IAppointmentService appointmentService;
        private ICustomerHospitalConsumeService _customerHospitalConsumeService;
        private ILiveAnchorDailyTargetService _liveAnchorDailyTargetService;
        private ILiveAnchorMonthlyTargetService _liveAnchorMonthlyTargetService;
        private IAmiyaPerformanceService amiyaPerformanceService;
        public AmiyaAchievementController(IOrderService orderService,
            IContentPlatformOrderSendService sendContentPlatFormOrderInfoService,
            IAppointmentService appointmentService,
            IHttpContextAccessor httpContextAccessor,
            ICustomerService customerService,
            IContentPlateFormOrderService contentPlatFormOrderService,
            IHospitalInfoService hospitalInfoService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            ISendOrderInfoService sendOrderInfoService,
            ICustomerHospitalConsumeService customerHospitalConsumeService,
            IShoppingCartRegistrationService shoppingCartRegistrationService,
            ILiveAnchorDailyTargetService liveAnchorDailyTargetService, IAmiyaPerformanceService amiyaPerformanceService, ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService)
        {
            this.orderService = orderService;
            _sendContentPlatFormOrderInfoService = sendContentPlatFormOrderInfoService;
            _sendOrderInfoService = sendOrderInfoService;
            this.httpContextAccessor = httpContextAccessor;
            this.appointmentService = appointmentService;
            _contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.customerService = customerService;
            _hospitalInfoService = hospitalInfoService;
            _shoppingCartRegistrationService = shoppingCartRegistrationService;
            _contentPlatFormOrderService = contentPlatFormOrderService;
            _customerHospitalConsumeService = customerHospitalConsumeService;
            _liveAnchorDailyTargetService = liveAnchorDailyTargetService;
            this.amiyaPerformanceService = amiyaPerformanceService;
            _liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
        }


        #region 【啊美雅业绩】
        /// <summary>
        /// 获取啊美雅业绩数据
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        [HttpGet("totalPerformance")]
        public async Task<ResultData<PerformanceVo>> GetAmeiYanPerformanceAsync(int year, int month)
        {
            //获取当前月各目标及带货金额
            var target = await _liveAnchorMonthlyTargetService.GetPerformance(year, month);
            //获取当前月同比,环比等数据
            var performance = await amiyaPerformanceService.GetMonthPerformance(year, month);

            //查找当前月ip运营总业绩目标
            decimal? totalPerformanceTarget = target.TotalPerformanceTarget + target.CommercePerformanceTarget;
            //查找当前月IP运营带货总业绩目标
            decimal? totalCommerceTarget = target.CommercePerformanceTarget;
            //查找当前月份老客业绩目标
            decimal? oldCustomerTarget = target.OldCustomerPerformanceTarget;
            //查找当前月份新诊业绩目标
            decimal? newCustomerTarget = target.NewCustomerPerformanceTarget;


            //获取当前选中月的已完成业绩
            decimal? sumAlreadyCompletePerformance = target.CommerceCompletePerformance + performance.CueerntMonthTotalPerformance;
            //获取当前选中月已完成的带货总业绩
            decimal? sumAlreadyCompleteCommercePerformance = performance.CurrentMonthCommercePerformance;


            //获取当前月份老客总业绩
            decimal? sumOldPerformance = performance.CurrentMonthOldCustomerPerformance;
            //获取当前月份新客总业绩
            decimal? sumNewPerformance = performance.CurrentMonthNewCustomerPerformance;
            //获取同比月份总业绩
            decimal? TotalPerfomanceYearOnYear = performance.PerformanceYearOnYear + performance.CommercePerformanceYearOnYear;
            //获取环比月份总业绩
            decimal? TotalPerfomanceChainRatio = performance.PerformanceChainRatio + performance.CommercePerformanceChainRation;

            //获取同比月份新诊业绩
            decimal? sumNewPerfomanceYearOnYear = performance.NewCustomerYearOnYear;
            //获取环比月份新诊业绩
            decimal? sumNewPerfomanceChainRatio = performance.NewCustomerChainRatio;
            //获取同比月份老客业绩
            decimal? sumOldPerfomanceYearOnYear = performance.OldCustomerYearOnYear;
            //获取环比月份老客业绩
            decimal? sumOldPerfomanceChainRatio = performance.OldCustomerChainRation;

            //获取同比月份带货业绩
            decimal? sumCommercePerfomanceYearOnYear = performance.CommercePerformanceYearOnYear;
            //获取环比月份带货业绩
            decimal? sumCommercePerfomanceChainRatio = performance.CommercePerformanceChainRation;

            //总业绩目标达成
            decimal? totalTargetComplete = totalPerformanceTarget == 0m ? null : Math.Round(sumAlreadyCompletePerformance.Value / totalPerformanceTarget.Value * 100, 2);
            //新诊目标达成
            decimal? newCustomerTargetComplete = newCustomerTarget == 0m ? null : Math.Round(sumNewPerformance.Value / newCustomerTarget.Value * 100, 2);
            //老客业绩目标达成
            decimal? oldCustomerTargetComplete = oldCustomerTarget == 0m ? null : Math.Round(sumOldPerformance.Value / oldCustomerTarget.Value * 100, 2);
            //带货业绩目标达成
            decimal? commerceTargetComplete = totalCommerceTarget == 0m ? null : Math.Round(sumAlreadyCompleteCommercePerformance.Value / totalCommerceTarget.Value * 100, 2);

            //业绩同比
            decimal? totalPerfomanceYearOnYearRatio = TotalPerfomanceYearOnYear == 0m ? null : Math.Round((sumAlreadyCompletePerformance.Value - TotalPerfomanceYearOnYear.Value) / TotalPerfomanceYearOnYear.Value * 100, 2);
            //业绩环比
            decimal? totalPerfomanceChainRation = TotalPerfomanceChainRatio == 0m ? null : Math.Round((sumAlreadyCompletePerformance.Value - TotalPerfomanceChainRatio.Value) / TotalPerfomanceChainRatio.Value * 100, 2);

            //老客业绩同比
            decimal? oldPerfomanceYearOnYearRation = sumOldPerfomanceYearOnYear == 0m ? null : Math.Round((sumOldPerformance.Value - sumOldPerfomanceYearOnYear.Value) / sumOldPerfomanceYearOnYear.Value * 100, 2);
            //老客业绩环比
            decimal? oldPerfomanceChainRation = sumOldPerfomanceChainRatio == 0m ? null : Math.Round((sumOldPerformance.Value - sumOldPerfomanceChainRatio.Value) / sumOldPerfomanceChainRatio.Value * 100, 2);

            //新诊业绩同比
            decimal? newPerfomanceYearOnYearRation = sumNewPerfomanceYearOnYear == 0 ? null : Math.Round((sumNewPerformance.Value - sumNewPerfomanceYearOnYear.Value) / sumNewPerfomanceYearOnYear.Value * 100, 2);
            //新诊业绩环比
            decimal? newPerfomanceChainRation = sumNewPerfomanceChainRatio == 0m ? null : Math.Round((sumNewPerformance.Value - sumNewPerfomanceChainRatio.Value) / sumNewPerfomanceChainRatio.Value * 100, 2);

            //带货业绩同比
            decimal? commercePerfomanceYearOnYearRatio = sumCommercePerfomanceYearOnYear == 0m ? null : Math.Round((sumAlreadyCompleteCommercePerformance.Value - sumCommercePerfomanceYearOnYear.Value) / sumCommercePerfomanceYearOnYear.Value * 100, 2);
            //带货业绩环比
            decimal? commercePerfomanceChainRation = sumCommercePerfomanceChainRatio == 0m ? null : Math.Round((sumAlreadyCompleteCommercePerformance.Value - sumCommercePerfomanceChainRatio.Value) / sumCommercePerfomanceChainRatio.Value * 100, 2);


            PerformanceInfoDto performanceInfoDto = new PerformanceInfoDto
            {
                TotalPerformance = sumAlreadyCompletePerformance,
                TotalPerformanceTargetComplete = totalTargetComplete,
                OldPerformanceTargetComplete = oldCustomerTargetComplete,
                NewPerformanceTargetComplete = newCustomerTargetComplete,
                CommercePerformanceTargetComplete = commerceTargetComplete,
                NewPerformance = sumNewPerformance,
                OldPerformance = sumOldPerformance,
                CommercePerformance = sumAlreadyCompleteCommercePerformance,
                TotalPerformanceYearOnYear = totalPerfomanceYearOnYearRatio,
                TotalPerformanceChainRatio = totalPerfomanceChainRation,
                OldPerformanceYearOnYear = oldPerfomanceYearOnYearRation,
                OldPerformanceChainRatio = oldPerfomanceChainRation,
                NewPerformanceYearOnYear = newPerfomanceYearOnYearRation,
                NewPerformanceChainRatio = newPerfomanceChainRation,
                CommercePerformanceYearOnYear = commercePerfomanceYearOnYearRatio,
                CommercePerformanceChainRatio = commercePerfomanceChainRation
            };
            List<PerformanceRatioDto> ratioDtos = new List<PerformanceRatioDto>();
            if (sumAlreadyCompletePerformance != 0m)
            {
                PerformanceRatioDto newRatio = new PerformanceRatioDto
                {
                    PerformanceText = "新诊业绩",
                    PerformancePrice = sumNewPerformance,
                    PerformanceRatio = Math.Round(sumNewPerformance.Value / sumAlreadyCompletePerformance.Value * 100, 2)
                };
                PerformanceRatioDto oldRatio = new PerformanceRatioDto
                {
                    PerformanceText = "老客业绩",
                    PerformancePrice = sumOldPerformance,
                    PerformanceRatio = Math.Round(sumOldPerformance.Value / sumAlreadyCompletePerformance.Value * 100, 2)
                };
                PerformanceRatioDto commerceRatio = new PerformanceRatioDto
                {
                    PerformanceText = "带货业绩",
                    PerformancePrice = sumAlreadyCompleteCommercePerformance,
                    PerformanceRatio = Math.Round(sumAlreadyCompleteCommercePerformance.Value / sumAlreadyCompletePerformance.Value * 100, 2)
                };
                ratioDtos.Add(newRatio);
                ratioDtos.Add(oldRatio);
                ratioDtos.Add(commerceRatio);
            }
            else
            {
                PerformanceRatioDto newRatio = new PerformanceRatioDto
                {
                    PerformanceText = "新诊业绩",
                    PerformancePrice = 0,
                    PerformanceRatio = 0
                };
                PerformanceRatioDto oldRatio = new PerformanceRatioDto
                {
                    PerformanceText = "老客业绩",
                    PerformancePrice = 0,
                    PerformanceRatio = 0
                };
                PerformanceRatioDto commerceRatio = new PerformanceRatioDto
                {
                    PerformanceText = "带货业绩",
                    PerformancePrice = 0,
                    PerformanceRatio = 0
                };
                ratioDtos.Add(newRatio);
                ratioDtos.Add(oldRatio);
                ratioDtos.Add(commerceRatio);
            }
            //各业绩占比
            performanceInfoDto.PerformanceRatios = ratioDtos;
            //老客业绩数据
            var old = await _contentPlatFormOrderDealInfoService.GetPerformance(year, month, true);

            List<Dto.Performance.PerformanceListInfo> oldPerfomanceList = new List<Dto.Performance.PerformanceListInfo>();

            for (int i = 0; i < month; i++)
            {
                Dto.Performance.PerformanceListInfo listInfo = new Dto.Performance.PerformanceListInfo();
                DateTime date = new DateTime(year, i + 1, 1);
                listInfo.date = date.Month.ToString();
                listInfo.Performance = 0.00m;
                oldPerfomanceList.Add(listInfo);
            }

            foreach (var oldPerfomance in old)
            {
                oldPerfomanceList.Find(x => x.date == oldPerfomance.Date.Month.ToString()).Performance = oldPerfomance.PerfomancePrice;
            }


            //新客业绩数据
            var newp = await _contentPlatFormOrderDealInfoService.GetPerformance(year, month, false);
            List<Dto.Performance.PerformanceListInfo> newPerfomanceList = new List<Dto.Performance.PerformanceListInfo>();
            for (int i = 0; i < month; i++)
            {
                Dto.Performance.PerformanceListInfo listInfo = new Dto.Performance.PerformanceListInfo();
                DateTime date = new DateTime(year, i + 1, 1);
                listInfo.date = date.Month.ToString();
                listInfo.Performance = 0.00m;
                newPerfomanceList.Add(listInfo);
            }
            foreach (var newPerfomance in newp)
            {
                newPerfomanceList.Find(x => x.date == newPerfomance.Date.Month.ToString()).Performance = newPerfomance.PerfomancePrice;
            }


            //带货业绩数据
            var comm = await _liveAnchorMonthlyTargetService.GetLiveAnchorCommercePerformance(year, month);
            List<Dto.Performance.PerformanceListInfo> commercePerfomanceList = new List<Dto.Performance.PerformanceListInfo>();
            for (int i = 0; i < month; i++)
            {
                Dto.Performance.PerformanceListInfo listInfo = new Dto.Performance.PerformanceListInfo();
                DateTime date = new DateTime(year, i + 1, 1);
                listInfo.date = date.Month.ToString();
                listInfo.Performance = 0.00m;
                commercePerfomanceList.Add(listInfo);
            }
            foreach (var commercePerfomance in comm)
            {
                commercePerfomanceList.Find(x => x.date == commercePerfomance.Date.Month.ToString()).Performance = commercePerfomance.PerfomancePrice;
            }
            performanceInfoDto.commercePerformanceList = commercePerfomanceList;
            performanceInfoDto.oldPerformanceList = oldPerfomanceList;
            performanceInfoDto.newPerformanceList = newPerfomanceList;



            PerformanceVo performanceVo = new PerformanceVo
            {
                TotalPerformance = performanceInfoDto.TotalPerformance,
                TotalPerformanceYearOnYear = performanceInfoDto.TotalPerformanceYearOnYear,
                TotalPerformanceChainRatio = performanceInfoDto.TotalPerformanceChainRatio,
                TotalPerformanceTargetComplete = performanceInfoDto.TotalPerformanceTargetComplete,
                NewPerformance = performanceInfoDto.NewPerformance,
                NewPerformanceYearOnYear = performanceInfoDto.NewPerformanceYearOnYear,
                NewPerformanceChainRatio = performanceInfoDto.NewPerformanceChainRatio,
                NewPerformanceTargetComplete = performanceInfoDto.NewPerformanceTargetComplete,
                OldPerformance = performanceInfoDto.OldPerformance,
                OldPerformanceYearOnYear = performanceInfoDto.OldPerformanceYearOnYear,
                OldPerformanceChainRatio = performanceInfoDto.OldPerformanceChainRatio,
                OldPerformanceTargetComplete = performanceInfoDto.OldPerformanceTargetComplete,
                CommercePerformance = performanceInfoDto.CommercePerformance,
                CommercePerformanceYearOnYear = performanceInfoDto.CommercePerformanceYearOnYear,
                CommercePerformanceChainRatio = performanceInfoDto.CommercePerformanceChainRatio,
                CommercePerformanceTargetComplete = performanceInfoDto.CommercePerformanceTargetComplete,
                PerformanceRatios = performanceInfoDto.PerformanceRatios.Select(d => new PerformanceRatioVo
                {
                    PerformanceText = d.PerformanceText,
                    PerformancePrice = d.PerformancePrice,
                    PerformanceRatio = d.PerformanceRatio
                }).ToList(),
                NewPerformanceData = performanceInfoDto.newPerformanceList.Select(data => new Vo.Performance.PerformanceListInfo
                {
                    date = data.date,
                    Performance = data.Performance
                }).ToList(),
                OldPerformanceData = performanceInfoDto.oldPerformanceList.Select(data => new Vo.Performance.PerformanceListInfo
                {
                    date = data.date,
                    Performance = data.Performance
                }).ToList(),
                CommercePerformanceData = performanceInfoDto.commercePerformanceList.Select(data => new Vo.Performance.PerformanceListInfo
                {
                    date = data.date,
                    Performance = data.Performance
                }).ToList()

            };
            return ResultData<PerformanceVo>.Success().AddData("performance", performanceVo);
        }

        #endregion

        #region 【分组业绩】

        #endregion

        #region 【派单成交业绩】
        /// <summary>
        /// 派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("sendAndDealPerformance")]
        public async Task<ResultData<SendAndDealInfoVo>> GetSendAndDealPerformanceAsync(int year, int month)
        {
            //获取当前月同比,环比等数据
            var performance = await amiyaPerformanceService.GetMonthDealPerformance(year, month);
            SendAndDealInfoVo performanceVo = new SendAndDealInfoVo();

            #region 【历史派单，当月成交数据】
            performanceVo.HistorySendDuringMonthDeal = performance.HistoryMonthSendOrderDealPrice;

            performanceVo.HistorySendDuringMonthDealYearOnYear = performance.LastYearHistorySendTotalPerformance == 0m ? null : Math.Round((performance.HistoryMonthSendOrderDealPrice - performance.LastYearHistorySendTotalPerformance) / performance.LastYearHistorySendTotalPerformance * 100, 2);

            performanceVo.HistorySendDuringMonthDealChainRatio = performance.LastMonthHistorySendTotalPerformance == 0m ? null : Math.Round((performance.HistoryMonthSendOrderDealPrice - performance.LastMonthHistorySendTotalPerformance) / performance.LastMonthHistorySendTotalPerformance * 100, 2);
            #endregion

            #region 【当月派单当月成交数据】
            performanceVo.DuringMonthSendDuringMonthDeal = performance.ThisMonthSendOrderDealPrice;

            performanceVo.DuringMonthSendDuringMonthDealYearOnYear = performance.LastYearTotalPerformance == 0m ? null : Math.Round((performance.ThisMonthSendOrderDealPrice - performance.LastYearTotalPerformance) / performance.LastYearTotalPerformance * 100, 2);

            performanceVo.DuringMonthSendDuringMonthDealChainRatio = performance.LastMonthTotalPerformance == 0m ? null : Math.Round((performance.ThisMonthSendOrderDealPrice - performance.LastMonthTotalPerformance) / performance.LastMonthTotalPerformance * 100, 2);
            #endregion

            #region 【业绩占比】

            decimal sumSendAndDealOrderInfo = performanceVo.HistorySendDuringMonthDeal.Value + performanceVo.DuringMonthSendDuringMonthDeal.Value;
            List<PerformanceRatioDto> ratioDtos = new List<PerformanceRatioDto>();

            PerformanceRatioDto newRatio = new PerformanceRatioDto
            {
                PerformanceText = "历史派单当月成交",
                PerformancePrice = performanceVo.HistorySendDuringMonthDeal,
                PerformanceRatio = sumSendAndDealOrderInfo == 0 ? 0 : Math.Round(performanceVo.HistorySendDuringMonthDeal.Value / sumSendAndDealOrderInfo * 100, 2)
            };
            ratioDtos.Add(newRatio);
            PerformanceRatioDto oldRatio = new PerformanceRatioDto
            {
                PerformanceText = "当月派单当月成交",
                PerformancePrice = performanceVo.DuringMonthSendDuringMonthDeal,
                PerformanceRatio = sumSendAndDealOrderInfo == 0 ? 0 : Math.Round(performanceVo.DuringMonthSendDuringMonthDeal.Value / sumSendAndDealOrderInfo * 100, 2)
            };
            ratioDtos.Add(oldRatio);

            performanceVo.PerformanceRatioVo = ratioDtos.Select(d => new PerformanceRatioVo
            {
                PerformanceText = d.PerformanceText,
                PerformancePrice = d.PerformancePrice,
                PerformanceRatio = d.PerformanceRatio
            }).ToList();
            #endregion

            #region 【折线图】
            //历史派单当月成交折线图
            var historySendThisMonthDealOrderList = await amiyaPerformanceService.GetHistorySendThisMonthDealOrders(year, month, true);
            performanceVo.HistorySendDuringMonthDealList = historySendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            //当月派单当月成交折线图
            var thisMonthSendThisMonthDealOrderList = await amiyaPerformanceService.GetHistorySendThisMonthDealOrders(year, month, false);
            performanceVo.DuringMonthSendDuringMonthDealList = thisMonthSendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            #endregion

            return ResultData<SendAndDealInfoVo>.Success().AddData("performance", performanceVo);
        }


        #endregion
    }
}
