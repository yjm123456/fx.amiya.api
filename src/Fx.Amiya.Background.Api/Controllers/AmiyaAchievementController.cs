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

            PerformanceVo performanceVo = new PerformanceVo();

            #region 业绩数据

            var performance = await amiyaPerformanceService.GetMonthPerformanceAndRation(year, month);
            performanceVo.TotalPerformance = performance.CueerntMonthTotalPerformance;
            performanceVo.TotalPerformanceYearOnYear = performance.TotalPerformanceYearOnYear;
            performanceVo.TotalPerformanceChainRatio = performance.TotalPerformanceChainratio;
            performanceVo.TotalPerformanceTargetComplete = performance.TotalPerformanceTargetComplete;
            performanceVo.NewPerformance = performance.CurrentMonthNewCustomerPerformance;
            performanceVo.NewPerformanceYearOnYear = performance.NewCustomerPerformanceYearOnYear;
            performanceVo.NewPerformanceChainRatio = performance.NewCustomerPerformanceChainRatio;
            performanceVo.NewPerformanceTargetComplete = performance.NewCustomerPerformanceTargetComplete;
            performanceVo.OldPerformance = performance.CurrentMonthOldCustomerPerformance;
            performanceVo.OldPerformanceYearOnYear = performance.OldCustomerPerformanceYearOnYear;
            performanceVo.OldPerformanceChainRatio = performance.OldCustomerPerformanceChainRatio;
            performanceVo.OldPerformanceTargetComplete = performance.OldCustomerTargetComplete;
            performanceVo.CommercePerformance = performance.CurrentMonthCommercePerformance;
            performanceVo.CommercePerformanceYearOnYear = performance.CommercePerformanceYearOnYear;
            performanceVo.CommercePerformanceChainRatio = performance.CommercePerformanceChainRatio;
            performanceVo.CommercePerformanceTargetComplete = performance.CommercePerformanceTargetComplete;

            #endregion


            #region 业绩占比
            List<PerformanceRatioVo> ratioDtos = new List<PerformanceRatioVo>();
            if (performance.CueerntMonthTotalPerformance != 0m)
            {
                PerformanceRatioVo newRatio = new PerformanceRatioVo
                {
                    PerformanceText = "新诊业绩",
                    PerformancePrice = performance.CurrentMonthNewCustomerPerformance,
                    PerformanceRatio = performance.NewCustomerPerformanceRatio
                };
                PerformanceRatioVo oldRatio = new PerformanceRatioVo
                {
                    PerformanceText = "老客业绩",
                    PerformancePrice = performance.CurrentMonthOldCustomerPerformance,
                    PerformanceRatio = performance.OldCustomerPerformanceRatio
                };
                PerformanceRatioVo commerceRatio = new PerformanceRatioVo
                {
                    PerformanceText = "带货业绩",
                    PerformancePrice = performance.CurrentMonthCommercePerformance,
                    PerformanceRatio = performance.CommercePerformanceRatio
                };
                ratioDtos.Add(newRatio);
                ratioDtos.Add(oldRatio);
                ratioDtos.Add(commerceRatio);
            }
            performanceVo.PerformanceRatios = ratioDtos;
            #endregion
            #region 折线图
            
            //老客业绩数据
            var old = await _contentPlatFormOrderDealInfoService.GetPerformance(year, month, true);
            performanceVo.OldPerformanceData = old.Select(o=>new Vo.Performance.PerformanceListInfo { date=o.Date.ToString(),Performance=o.PerfomancePrice}).ToList();    


            //新客业绩数据
            var newPerformance = await _contentPlatFormOrderDealInfoService.GetPerformance(year, month, false);
            performanceVo.NewPerformanceData = newPerformance.Select(n=>new Vo.Performance.PerformanceListInfo { date=n.Date.ToString(),Performance=n.PerfomancePrice}).ToList();
            
            //带货业绩数据
            var comm = await _liveAnchorMonthlyTargetService.GetLiveAnchorCommercePerformance(year, month);
            performanceVo.CommercePerformanceData = comm.Select(c=>new Vo.Performance.PerformanceListInfo { date=c.Date.ToString(),Performance=c.PerfomancePrice}).ToList();

            #endregion

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
