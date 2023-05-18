using Fx.Amiya.Background.Api.Vo.Appointment;
using Fx.Amiya.Background.Api.Vo.OrderReport;
using Fx.Amiya.Background.Api.Vo.Performance;
using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Input;
using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using jos_sdk_net.Util;
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
    [FxInternalAuthorize]
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
        private IHospitalPerformanceService hospitalPerformanceService;
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
            ILiveAnchorDailyTargetService liveAnchorDailyTargetService,
            IAmiyaPerformanceService amiyaPerformanceService,
            ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService,
            IHospitalPerformanceService hospitalPerformanceService)
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
            this.hospitalPerformanceService = hospitalPerformanceService;
            this.amiyaPerformanceService = amiyaPerformanceService;
            _liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
        }


        #region 【总业绩】

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
                    PerformanceText = "新客业绩",
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
            var old = await amiyaPerformanceService.GetNewOrOldPerformanceBrokenLineAsync(year, month, true, null);
            performanceVo.OldPerformanceData = old.Select(o => new Vo.Performance.PerformanceListInfo { date = o.Date.ToString(), Performance = o.PerfomancePrice }).ToList();


            //新客业绩数据
            var newPerformance = await amiyaPerformanceService.GetNewOrOldPerformanceBrokenLineAsync(year, month, false, null);
            performanceVo.NewPerformanceData = newPerformance.Select(n => new Vo.Performance.PerformanceListInfo { date = n.Date.ToString(), Performance = n.PerfomancePrice }).ToList();

            //带货业绩数据
            var comm = await amiyaPerformanceService.GetLiveAnchorCommercePerformanceByLiveAnchorIdAsync(year, month, null);
            performanceVo.CommercePerformanceData = comm.Select(c => new Vo.Performance.PerformanceListInfo { date = c.Date.ToString(), Performance = c.PerfomancePrice }).ToList();

            #endregion 

            return ResultData<PerformanceVo>.Success().AddData("performance", performanceVo);
        }

        #endregion

        #region 【分组业绩】
        /// <summary>
        /// 分组业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("groupPerformance")]
        public async Task<ResultData<GroupPerformanceVo>> GetGroupPerformanceAsync(int year, int month)
        {
            //获取当前月同比,环比等数据
            var groupPerformance = await amiyaPerformanceService.GetGroupPerformanceAsync(year, month);
            GroupPerformanceVo groupPerformanceVo = new GroupPerformanceVo();

            #region 【刀刀组业绩】
            groupPerformanceVo.GroupDaoDaoPerformance = groupPerformance.GroupDaoDaoPerformance;
            groupPerformanceVo.GroupDaoDaoPerformanceYearOnYear = groupPerformance.GroupDaoDaoPerformanceYearOnYear;
            groupPerformanceVo.GroupDaoDaoPerformanceChainRatio = groupPerformance.GroupDaoDaoPerformanceChainRatio;
            groupPerformanceVo.GroupDaoDaoPerformanceCompleteRate = groupPerformance.GroupDaoDaoPerformanceCompleteRate;
            #endregion

            #region 【吉娜组业绩】

            groupPerformanceVo.GroupJinaPerformance = groupPerformance.GroupJinaPerformance;
            groupPerformanceVo.GroupJinaPerformanceYearOnYear = groupPerformance.GroupJinaPerformanceYearOnYear;
            groupPerformanceVo.GroupJinaPerformanceChainRatio = groupPerformance.GroupJinaPerformanceChainRatio;
            groupPerformanceVo.GroupJinaPerformanceCompleteRate = groupPerformance.GroupJinaPerformanceCompleteRate;
            #endregion

            #region 【业绩占比】

            List<PerformanceRatioDto> ratioDtos = new List<PerformanceRatioDto>();

            PerformanceRatioDto daodaoRatio = new PerformanceRatioDto
            {
                PerformanceText = "刀刀组业绩",
                PerformancePrice = groupPerformance.GroupDaoDaoPerformance,
                PerformanceRatio = groupPerformance.AccountedForGroupDaoDaoPerformance
            };
            ratioDtos.Add(daodaoRatio);
            PerformanceRatioDto jinaRatio = new PerformanceRatioDto
            {
                PerformanceText = "吉娜组业绩",
                PerformancePrice = groupPerformance.GroupJinaPerformance,
                PerformanceRatio = groupPerformance.AccountedForGroupJinaPerformance
            };
            ratioDtos.Add(jinaRatio);

            groupPerformanceVo.PerformanceRatios = ratioDtos.Select(d => new PerformanceRatioVo
            {
                PerformanceText = d.PerformanceText,
                PerformancePrice = d.PerformancePrice,
                PerformanceRatio = d.PerformanceRatio
            }).ToList();
            #endregion

            #region 【折线图】
            //刀刀组业绩折线图
            var historySendThisMonthDealOrderList = await amiyaPerformanceService.GetNewOrOldPerformanceBrokenLineAsync(year, month, null, "刀刀");
            groupPerformanceVo.GroupDaoDaoPerformanceData = historySendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            //吉娜组业绩折线图
            var thisMonthSendThisMonthDealOrderList = await amiyaPerformanceService.GetNewOrOldPerformanceBrokenLineAsync(year, month, null, "吉娜");
            groupPerformanceVo.GroupJinaPerformanceData = thisMonthSendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            #endregion

            return ResultData<GroupPerformanceVo>.Success().AddData("performance", groupPerformanceVo);
        }
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
            var performance = await amiyaPerformanceService.GetMonthDealPerformanceAsync(year, month);
            SendAndDealInfoVo performanceVo = new SendAndDealInfoVo();

            #region 【历史派单，当月成交数据】
            performanceVo.HistorySendDuringMonthDeal = performance.HistoryMonthSendOrderDealPrice;

            performanceVo.HistorySendDuringMonthDealYearOnYear = performance.LastYearHistorySendTotalPerformance;

            performanceVo.HistorySendDuringMonthDealChainRatio = performance.LastMonthHistorySendTotalPerformance;
            #endregion

            #region 【当月派单当月成交数据】
            performanceVo.DuringMonthSendDuringMonthDeal = performance.ThisMonthSendOrderDealPrice;

            performanceVo.DuringMonthSendDuringMonthDealYearOnYear = performance.LastYearTotalPerformance;

            performanceVo.DuringMonthSendDuringMonthDealChainRatio = performance.LastMonthTotalPerformance;
            #endregion

            #region 【业绩占比】

            List<PerformanceRatioDto> ratioDtos = new List<PerformanceRatioDto>();
            PerformanceRatioDto newRatio = new PerformanceRatioDto
            {
                PerformanceText = "历史派单当月成交",
                PerformancePrice = performanceVo.HistorySendDuringMonthDeal,
                PerformanceRatio = performance.AccountedForHistorySendDuringMonthDealDetails
            };
            ratioDtos.Add(newRatio);
            PerformanceRatioDto oldRatio = new PerformanceRatioDto
            {
                PerformanceText = "当月派单当月成交",
                PerformancePrice = performanceVo.DuringMonthSendDuringMonthDeal,
                PerformanceRatio = performance.AccountedForDuringMonthSendDuringMonthDealDetails
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
            var historySendThisMonthDealOrderList = await amiyaPerformanceService.GetHistorySendThisMonthDealOrders(year, month, true, null);
            performanceVo.HistorySendDuringMonthDealList = historySendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            //当月派单当月成交折线图
            var thisMonthSendThisMonthDealOrderList = await amiyaPerformanceService.GetHistorySendThisMonthDealOrders(year, month, false, null);
            performanceVo.DuringMonthSendDuringMonthDealList = thisMonthSendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            #endregion

            return ResultData<SendAndDealInfoVo>.Success().AddData("performance", performanceVo);
        }


        #endregion

        #endregion

        #region 【分组业绩】

        #region 【分组总业绩】
        /// <summary>
        /// 分组总业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">中文主播名字（刀刀，吉娜）</param>
        /// <returns></returns>
        [HttpGet("PerformanceByLiveAnchorName")]
        public async Task<ResultData<LiveAnchorGroupPerformanceVo>> GetPerformanceByGroupAsync(int year, int month, string liveAnchorName)
        {
            //获取当前月同比,环比等数据
            var groupPerformance = await amiyaPerformanceService.GetByLiveAnchorPerformanceAsync(year, month, liveAnchorName);
            LiveAnchorGroupPerformanceVo groupPerformanceVo = new LiveAnchorGroupPerformanceVo();

            #region 【总业绩】
            groupPerformanceVo.CueerntMonthTotalPerformance = groupPerformance.CueerntMonthTotalPerformance;
            groupPerformanceVo.TotalPerformanceYearOnYear = groupPerformance.TotalPerformanceYearOnYear;
            groupPerformanceVo.TotalPerformanceChainratio = groupPerformance.TotalPerformanceChainratio;
            groupPerformanceVo.TotalPerformanceTargetComplete = groupPerformance.TotalPerformanceTargetComplete;
            #endregion
            #region 【新诊业绩】
            groupPerformanceVo.CurrentMonthNewCustomerPerformance = groupPerformance.CurrentMonthNewCustomerPerformance;
            groupPerformanceVo.NewCustomerPerformanceYearOnYear = groupPerformance.NewCustomerPerformanceYearOnYear;
            groupPerformanceVo.NewCustomerPerformanceChainRatio = groupPerformance.NewCustomerPerformanceChainRatio;
            groupPerformanceVo.NewCustomerPerformanceTargetComplete = groupPerformance.NewCustomerPerformanceTargetComplete;
            #endregion
            #region 【老客业绩】
            groupPerformanceVo.CurrentMonthOldCustomerPerformance = groupPerformance.CurrentMonthOldCustomerPerformance;
            groupPerformanceVo.OldCustomerPerformanceYearOnYear = groupPerformance.OldCustomerPerformanceYearOnYear;
            groupPerformanceVo.OldCustomerPerformanceChainRatio = groupPerformance.OldCustomerPerformanceChainRatio;
            groupPerformanceVo.OldCustomerTargetComplete = groupPerformance.OldCustomerTargetComplete;
            #endregion
            #region 【带货业绩】
            groupPerformanceVo.CurrentMonthCommercePerformance = groupPerformance.CurrentMonthCommercePerformance;
            groupPerformanceVo.CommercePerformanceYearOnYear = groupPerformance.CommercePerformanceYearOnYear;
            groupPerformanceVo.CommercePerformanceChainRatio = groupPerformance.CommercePerformanceChainRatio;
            groupPerformanceVo.CommercePerformanceTargetComplete = groupPerformance.CommercePerformanceTargetComplete;
            #endregion

            #region 【业绩占比】
            List<PerformanceRatioVo> ratioDtos = new List<PerformanceRatioVo>();
            if (groupPerformanceVo.CueerntMonthTotalPerformance != 0m)
            {
                PerformanceRatioVo newRatio = new PerformanceRatioVo
                {
                    PerformanceText = "新诊业绩",
                    PerformancePrice = groupPerformanceVo.CurrentMonthNewCustomerPerformance,
                    PerformanceRatio = groupPerformance.NewCustomerPerformanceRatio
                };
                PerformanceRatioVo oldRatio = new PerformanceRatioVo
                {
                    PerformanceText = "老客业绩",
                    PerformancePrice = groupPerformanceVo.CurrentMonthOldCustomerPerformance,
                    PerformanceRatio = groupPerformance.OldCustomerPerformanceRatio
                };
                PerformanceRatioVo commerceRatio = new PerformanceRatioVo
                {
                    PerformanceText = "带货业绩",
                    PerformancePrice = groupPerformanceVo.CurrentMonthCommercePerformance,
                    PerformanceRatio = groupPerformance.CommercePerformanceRatio
                };
                ratioDtos.Add(newRatio);
                ratioDtos.Add(oldRatio);
                ratioDtos.Add(commerceRatio);
            }
            groupPerformanceVo.PerformanceRatios = ratioDtos;
            #endregion

            #region 【折线图】

            //老客业绩数据
            var old = await amiyaPerformanceService.GetNewOrOldPerformanceBrokenLineAsync(year, month, true, liveAnchorName);
            groupPerformanceVo.OldPerformanceData = old.Select(o => new Vo.Performance.PerformanceListInfo { date = o.Date.ToString(), Performance = o.PerfomancePrice }).ToList();


            //新客业绩数据
            var newPerformance = await amiyaPerformanceService.GetNewOrOldPerformanceBrokenLineAsync(year, month, false, liveAnchorName);
            groupPerformanceVo.NewPerformanceData = newPerformance.Select(n => new Vo.Performance.PerformanceListInfo { date = n.Date.ToString(), Performance = n.PerfomancePrice }).ToList();

            //带货业绩数据
            var comm = await amiyaPerformanceService.GetLiveAnchorCommercePerformanceByLiveAnchorIdAsync(year, month, liveAnchorName);
            groupPerformanceVo.CommercePerformanceData = comm.Select(c => new Vo.Performance.PerformanceListInfo { date = c.Date.ToString(), Performance = c.PerfomancePrice }).ToList();
            #endregion
            return ResultData<LiveAnchorGroupPerformanceVo>.Success().AddData("performance", groupPerformanceVo);
        }

        #endregion

        #region 【派单成交业绩】
        /// <summary>
        /// 派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">中文主播名字（刀刀，吉娜）</param>
        /// <returns></returns>
        [HttpGet("sendAndDealPerformanceByLiveAnchorName")]
        public async Task<ResultData<GroupSendAndDealInfoVo>> GetSendAndDealPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            //获取当前月同比,环比等数据
            var performance = await amiyaPerformanceService.GetMonthDealPerformanceByLiveAnchorNameAsync(year, month, liveAnchorName);
            GroupSendAndDealInfoVo performanceVo = new GroupSendAndDealInfoVo();

            #region 【历史派单，当月成交数据】
            performanceVo.HistorySendDuringMonthDeal = performance.HistoryMonthSendOrderDealPrice;

            performanceVo.HistorySendDuringMonthDealYearOnYear = performance.LastYearHistorySendTotalPerformance;

            performanceVo.HistorySendDuringMonthDealChainRatio = performance.LastMonthHistorySendTotalPerformance;
            #endregion

            #region 【当月派单当月成交数据】
            performanceVo.DuringMonthSendDuringMonthDeal = performance.ThisMonthSendOrderDealPrice;

            performanceVo.DuringMonthSendDuringMonthDealYearOnYear = performance.LastYearTotalPerformance;

            performanceVo.DuringMonthSendDuringMonthDealChainRatio = performance.LastMonthTotalPerformance;
            #endregion

            #region 【业绩占比】

            List<PerformanceRatioDto> ratioDtos = new List<PerformanceRatioDto>();

            PerformanceRatioDto newRatio = new PerformanceRatioDto
            {
                PerformanceText = "历史派单当月成交",
                PerformancePrice = performanceVo.HistorySendDuringMonthDeal,
                PerformanceRatio = performance.AccountedForHistorySendDuringMonthDealDetails
            };
            ratioDtos.Add(newRatio);
            PerformanceRatioDto oldRatio = new PerformanceRatioDto
            {
                PerformanceText = "当月派单当月成交",
                PerformancePrice = performanceVo.DuringMonthSendDuringMonthDeal,
                PerformanceRatio = performance.AccountedForDuringMonthSendDuringMonthDealDetails
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
            var historySendThisMonthDealOrderList = await amiyaPerformanceService.GetHistorySendThisMonthDealOrders(year, month, true, liveAnchorName);
            performanceVo.HistorySendDuringMonthDealList = historySendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            //当月派单当月成交折线图
            var thisMonthSendThisMonthDealOrderList = await amiyaPerformanceService.GetHistorySendThisMonthDealOrders(year, month, false, liveAnchorName);
            performanceVo.DuringMonthSendDuringMonthDealList = thisMonthSendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            #endregion

            return ResultData<GroupSendAndDealInfoVo>.Success().AddData("performance", performanceVo);
        }

        #endregion

        #region 【面诊业绩】
        /// <summary>
        /// 面诊业绩
        /// </summary>
        /// <param name="year">登记日期年</param>
        /// <param name="month">登记日期月</param>
        /// <param name="liveAnchorName">中文主播名字（刀刀，吉娜）</param>
        /// <returns></returns>
        [HttpGet("consultationPerformanceByLiveAnchorName")]
        public async Task<ResultData<ConsultationPerformanceVo>> GetConsultationPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            //获取当前月同比,环比等数据
            var performance = await amiyaPerformanceService.GetContentPlatFormOrderPerformanceByLiveAnchorNameAsync(year, month, liveAnchorName);
            ConsultationPerformanceVo performanceVo = new ConsultationPerformanceVo();

            #region 【照片面诊数据】
            performanceVo.PictureConsultationPerformance = performance.PicturePerformance;

            performanceVo.PictureConsultationPerformanceYearOnYear = performance.LastYearPicturePerformance;

            performanceVo.PictureConsultationPerformanceChainRatio = performance.LastMonthPicturePerformance;
            #endregion

            #region 【视频面诊数据】
            performanceVo.VideoConsultationPerformance = performance.VideoPerformance;

            performanceVo.VideoConsultationPerformanceYearOnYear = performance.LastYearVideoPerformance;

            performanceVo.VideoConsultationPerformanceChainRatio = performance.LastMonthVideoPerformance;
            #endregion

            #region 【业绩占比】

            List<PerformanceRatioDto> ratioDtos = new List<PerformanceRatioDto>();

            PerformanceRatioDto newRatio = new PerformanceRatioDto
            {
                PerformanceText = "照片面诊业绩",
                PerformancePrice = performanceVo.PictureConsultationPerformance,
                PerformanceRatio = performance.AccountedForPicturePerformance
            };
            ratioDtos.Add(newRatio);
            PerformanceRatioDto oldRatio = new PerformanceRatioDto
            {
                PerformanceText = "视频面诊业绩",
                PerformancePrice = performanceVo.VideoConsultationPerformance,
                PerformanceRatio = performance.AccountedForVideoPerformance
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
            var pictureBrokenLine = await amiyaPerformanceService.GetPictureOrVideoConsultationAsync(year, month, false, liveAnchorName);
            performanceVo.PictureConsultationPerformanceBrokenLine = pictureBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var videoBrokenLine = await amiyaPerformanceService.GetPictureOrVideoConsultationAsync(year, month, true, liveAnchorName);
            performanceVo.VideoConsultationPerformanceBrokenLine = videoBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            #endregion

            return ResultData<ConsultationPerformanceVo>.Success().AddData("performance", performanceVo);
        }
        #endregion

        #region 【独立/协助业绩】
        /// <summary>
        /// 独立/协助业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">中文主播名字（刀刀，吉娜）</param>
        /// <returns></returns>
        [HttpGet("independentOrAssistPerformanceByLiveAnchorName")]
        public async Task<ResultData<IndependentOrAssistPerformanceVo>> GetIndependentOrAssistPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            //获取当前月同比,环比等数据
            var performance = await amiyaPerformanceService.GetIndependentOrAssistByLiveAnchorPerformanceAsync(year, month, liveAnchorName);
            IndependentOrAssistPerformanceVo performanceVo = new IndependentOrAssistPerformanceVo();

            #region 【主播独立业绩】
            performanceVo.LiveAnchorIndenpendentPerformance = performance.LiveAnchorIndenpendentPerformance;

            performanceVo.LiveAnchorIndenpendentPerformanceYearOnYear = performance.LiveAnchorIndenpendentPerformanceYearOnYear;

            performanceVo.LiveAnchorIndenpendentPerformanceChainRatio = performance.LiveAnchorIndenpendentPerformanceChainRatio;
            #endregion

            #region 【助理独立业绩】
            performanceVo.CustomerServiceIndenpendentPerformance = performance.CustomerServiceIndenpendentPerformance;

            performanceVo.CustomerServiceIndenpendentPerformanceChainRatio = performance.CustomerServiceIndenpendentPerformanceChainRatio;

            performanceVo.CustomerServiceIndenpendentPerformanceYearOnYear = performance.CustomerServiceIndenpendentPerformanceYearOnYear;
            #endregion

            #region 【助理协助业绩】
            performanceVo.CustomerServiceAssistPerformance = performance.CustomerServiceAssistPerformance;

            performanceVo.CustomerServiceAssistPerformanceYearOnYear = performance.CustomerServiceAssistPerformanceYearOnYear;

            performanceVo.CustomerServiceAssistPerformanceChainRatio = performance.CustomerServiceAssistPerformanceChainRatio;
            #endregion

            #region 【业绩占比】

            List<PerformanceRatioDto> ratioDtos = new List<PerformanceRatioDto>();

            PerformanceRatioDto liveAnchorIndependence = new PerformanceRatioDto
            {
                PerformanceText = "主播独立业绩",
                PerformancePrice = performanceVo.LiveAnchorIndenpendentPerformance,
                PerformanceRatio = performance.AccountForLiveAnchorIndenpendentPerformance
            };
            ratioDtos.Add(liveAnchorIndependence);
            PerformanceRatioDto customerServiceIndependence = new PerformanceRatioDto
            {
                PerformanceText = "助理独立业绩",
                PerformancePrice = performanceVo.CustomerServiceIndenpendentPerformance,
                PerformanceRatio = performance.AccountForCustomerServiceIndenpendentPerformance
            };
            ratioDtos.Add(customerServiceIndependence);

            PerformanceRatioDto customerServiceAssist = new PerformanceRatioDto
            {
                PerformanceText = "助理协助业绩",
                PerformancePrice = performanceVo.CustomerServiceAssistPerformance,
                PerformanceRatio = performance.AccountForCustomerServiceAssistPerformance
            };
            ratioDtos.Add(customerServiceAssist);

            performanceVo.PerformanceRatioVo = ratioDtos.Select(d => new PerformanceRatioVo
            {
                PerformanceText = d.PerformanceText,
                PerformancePrice = d.PerformancePrice,
                PerformanceRatio = d.PerformanceRatio
            }).ToList();
            #endregion

            #region 【折线图】
            var liveAnchorIndependenceBrokenLine = await amiyaPerformanceService.GetIndependenceOrAssistAsync(year, month, false, liveAnchorName, true);
            performanceVo.LiveAnchorIndenpendentPerformanceBrokenLine = liveAnchorIndependenceBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var customerServiceIndependenceBrokenLine = await amiyaPerformanceService.GetIndependenceOrAssistAsync(year, month, false, liveAnchorName, false);
            performanceVo.CustomerServiceIndenpendentPerformanceBrokenLine = customerServiceIndependenceBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var customerServiceAssistBrokenLine = await amiyaPerformanceService.GetIndependenceOrAssistAsync(year, month, true, liveAnchorName, false);
            performanceVo.CustomerServiceAssistPerformanceBrokenLine = customerServiceAssistBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            #endregion

            return ResultData<IndependentOrAssistPerformanceVo>.Success().AddData("performance", performanceVo);
        }
        #endregion

        #region 【基础经营看板】
        /// <summary>
        /// 基础经营看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">中文主播名字（刀刀，吉娜）</param>
        /// <returns></returns>
        [HttpGet("baseBusinessPerformance")]
        public async Task<ResultData<BaseBusinessPerformanceVo>> GetBaseBusinessPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            //获取当前月同比,环比等数据
            var performance = await amiyaPerformanceService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, liveAnchorName);
            BaseBusinessPerformanceVo performanceVo = new BaseBusinessPerformanceVo();

            #region 【加v】
            performanceVo.AddWeChatNum = performance.AddWeChatNum;

            performanceVo.AddWeChatNumRatioVo = performance.AddWeChatNumRatioVo;

            performanceVo.AddWeChatNumTargetComplete = performance.AddWeChatNumTargetComplete;

            performanceVo.AddWeChatNumYearOnYear = performance.AddWeChatNumYearOnYear;
            #endregion

            #region 【面诊卡下单】
            performanceVo.ConsulationCardNum = performance.ConsulationCardNum;

            performanceVo.ConsulationCardNumYearOnYear = performance.ConsulationCardNumYearOnYear;

            performanceVo.ConsulationCardNumRatioVo = performance.ConsulationCardNumRatioVo;

            performanceVo.ConsulationCardNumTargetComplete = performance.ConsulationCardNumTargetComplete;
            #endregion

            #region 【当月面诊卡消耗】
            performanceVo.ThisMonthConsulationCardConsumedNum = performance.ThisMonthConsulationCardConsumedNum;

            performanceVo.ThisMonthConsulationCardConsumedNumYearOnYear = performance.ThisMonthConsulationCardConsumedNumYearOnYear;

            performanceVo.ThisMonthConsulationCardConsumedNumRatioVo = performance.ThisMonthConsulationCardConsumedNumRatioVo;

            performanceVo.ThisMonthConsulationCardConsumedNumTargetComplete = performance.ThisMonthConsulationCardConsumedNumTargetComplete;
            #endregion

            #region 【历史面诊卡消耗】
            performanceVo.HistoryConsulationCardConsumedNum = performance.HistoryConsulationCardConsumedNum;

            performanceVo.HistoryConsulationCardConsumedNumYearOnYear = performance.HistoryConsulationCardConsumedNumYearOnYear;

            performanceVo.HistoryConsulationCardConsumedNumRatioVo = performance.HistoryConsulationCardConsumedNumRatioVo;

            performanceVo.HistoryConsulationCardConsumedNumTargetComplete = performance.HistoryConsulationCardConsumedNumTargetComplete;
            #endregion

            #region 【当月面诊卡退单】
            performanceVo.ThisMonthConsulationCardRefundNum = performance.ThisMonthConsulationCardRefundNum;

            performanceVo.ThisMonthConsulationCardRefundNumYearOnYear = performance.ThisMonthConsulationCardRefundNumYearOnYear;

            performanceVo.ThisMonthConsulationCardRefundNumRatioVo = performance.ThisMonthConsulationCardRefundNumRatioVo;

            performanceVo.ThisMonthConsulationCardRefundNumTargetComplete = performance.ThisMonthConsulationCardRefundNumTargetComplete;
            #endregion

            #region 【库存面诊卡退单】
            performanceVo.HistoryConsulationCardRefundNum = performance.HistoryConsulationCardRefundNum;

            performanceVo.HistoryConsulationCardRefundNumYearOnYear = performance.HistoryConsulationCardRefundNumYearOnYear;

            performanceVo.HistoryConsulationCardRefundNumRatioVo = performance.HistoryConsulationCardRefundNumRatioVo;

            #endregion

            #region 【面诊卡库存量】
            performanceVo.ConsulationCardInventoryNum = performance.ConsulationCardInventoryNum;
            #endregion

            #region 【折线图】

            var addWechatBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, null, null, true, null, liveAnchorName);
            performanceVo.AddWechatBrokenLine = addWechatBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var consulationCardNumBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, null, null, null, null, liveAnchorName);
            performanceVo.ConsulationCardNumBrokenLine = consulationCardNumBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var thisMonthConsulationCardConsumedNumBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, false, null, null, true, liveAnchorName);
            performanceVo.ThisMonthConsulationCardConsumedNumBrokenLine = thisMonthConsulationCardConsumedNumBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var historyConsulationCardConsumedNumBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, true, null, null, true, liveAnchorName);
            performanceVo.HistoryConsulationCardConsumedNumBrokenLine = historyConsulationCardConsumedNumBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var thisMonthConsulationCardRefundNumBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, null, false, null, null, liveAnchorName);
            performanceVo.ThisMonthConsulationCardRefundNumBrokenLine = thisMonthConsulationCardRefundNumBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var historyConsulationCardRefundNumBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, null, true, null, null, liveAnchorName);
            performanceVo.HistoryConsulationCardRefundNumBrokenLine = historyConsulationCardRefundNumBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();



            #endregion

            return ResultData<BaseBusinessPerformanceVo>.Success().AddData("performance", performanceVo);
        }
        #endregion

        #region 【派单成交经营看板】
        /// <summary>
        /// 派单成交经营看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">中文主播名字（刀刀，吉娜）</param>
        /// <returns></returns>
        [HttpGet("sendAndDealNumPerformance")]
        public async Task<ResultData<SendOrDealPerformanceVo>> GetSendAndDealNumPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            SendOrDealPerformanceVo performanceVo = new SendOrDealPerformanceVo();

            //获取当前月同比,环比等数据
            var performance = await amiyaPerformanceService.GetSendOrDealByLiveAnchorAsync(year, month, liveAnchorName);

            #region 【派单数】
            performanceVo.SendOrderNum = performance.SendOrderNum;

            performanceVo.SendOrderNumYearOnYear = performance.SendOrderNumYearOnYear;

            performanceVo.SendOrderNumChainRatio = performance.SendOrderNumChainRatio;

            performanceVo.SendOrderNumCompleteRate = performance.SendOrderNumCompleteRate;
            #endregion

            #region 【总上门数】
            performanceVo.TotalVisitNum = performance.TotalVisitNum;

            performanceVo.TotalVisitNumYearOnYear = performance.TotalVisitNumYearOnYear;

            performanceVo.TotalVisitNumChainRatio = performance.TotalVisitNumChainRatio;

            performanceVo.TotalVisitNumCompleteRate = performance.TotalVisitNumCompleteRate;
            #endregion


            #region 【新客上门数】
            performanceVo.NewCustomerVisitNum = performance.NewCustomerVisitNum;

            performanceVo.NewCustomerVisitNumYearOnYear = performance.NewCustomerVisitNumYearOnYear;

            performanceVo.NewCustomerVisitNumChainRatio = performance.NewCustomerVisitNumChainRatio;

            performanceVo.NewCustomerVisitNumCompleteRate = performance.NewCustomerVisitNumCompleteRate;
            #endregion


            #region 【老客上门数】
            performanceVo.OldCustomerVisitNum = performance.OldCustomerVisitNum;

            performanceVo.OldCustomerVisitNumYearOnYear = performance.OldCustomerVisitNumYearOnYear;

            performanceVo.OldCustomerVisitNumChainRatio = performance.OldCustomerVisitNumChainRatio;

            performanceVo.OldCustomerVisitNumCompleteRate = performance.OldCustomerVisitNumCompleteRate;
            #endregion


            #region 【总成交数】
            performanceVo.TotalDealNum = performance.TotalDealNum;

            performanceVo.TotalDealNumYearOnYear = performance.TotalDealNumYearOnYear;

            performanceVo.TotalDealNumChainRatio = performance.TotalDealNumChainRatio;

            performanceVo.TotalDealNumCompleteRate = performance.TotalDealNumCompleteRate;
            #endregion


            #region 【新客成交数】
            performanceVo.NewCustomerDealNum = performance.NewCustomerDealNum;

            performanceVo.NewCustomerDealNumYearOnYear = performance.NewCustomerDealNumYearOnYear;

            performanceVo.NewCustomerDealNumChainRatio = performance.NewCustomerDealNumChainRatio;

            performanceVo.NewCustomerDealNumCompleteRate = performance.NewCustomerDealNumCompleteRate;
            #endregion


            #region 【老客成交数】
            performanceVo.OldCustomerDealNum = performance.OldCustomerDealNum;

            performanceVo.OldCustomerDealNumYearOnYear = performance.OldCustomerDealNumYearOnYear;

            performanceVo.OldCustomerDealNumChainRatio = performance.OldCustomerDealNumChainRatio;

            performanceVo.OldCustomerDealNumCompleteRate = performance.OldCustomerDealNumCompleteRate;
            #endregion

            #region 【折线图】


            //开始月份
            DateTime currentDate = new DateTime(year, 1, 1);
            //结束月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            //分组派单情况
            var sendOrder = await amiyaPerformanceService.GetSendOrDealBrokenLineAsync(true, null, null, null, liveAnchorName);
            //派单结果
            var sendResult = sendOrder.Where(d => d.SendDate.HasValue == true && d.SendDate.Value >= currentDate && d.SendDate.Value < endDate).ToList();
            //派单折线图转换
            var sendOrderBrokenLine = sendResult.GroupBy(x => x.SendDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changeSendOrderBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, sendOrderBrokenLine);
            performanceVo.SendOrderBrokenLine = changeSendOrderBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            //总上门结果
            var totalVisitInfo = sendOrder.Where(d => d.IsToHospital == true && d.ToHospitalDate.HasValue == true && d.ToHospitalDate.Value >= currentDate && d.ToHospitalDate.Value < endDate);
            //总上门折线图转换
            var totalVisitBrokenLine = totalVisitInfo.GroupBy(x => x.ToHospitalDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changetotalVisitBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, totalVisitBrokenLine);
            performanceVo.TotalVisitBrokenLine = changetotalVisitBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var newCustomerVisitInfo = totalVisitInfo.Where(x => x.IsOldCustomer == false);
            //新客上门折线图转换
            var newCustomerVisitBrokenLine = newCustomerVisitInfo.GroupBy(x => x.ToHospitalDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changenewCustomerVisitBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, newCustomerVisitBrokenLine);
            performanceVo.NewCustomerVisitBrokenLine = changenewCustomerVisitBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var oldCustomerVisitInfo = totalVisitInfo.Where(x => x.IsOldCustomer == true);
            //老客上门折线图转换
            var oldCustomerVisitBrokenLine = oldCustomerVisitInfo.GroupBy(x => x.ToHospitalDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changeoldCustomerVisitBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, oldCustomerVisitBrokenLine);
            performanceVo.OldCustomerVisitBrokenLine = changeoldCustomerVisitBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();


            //总成交结果
            var totalDealInfo = sendOrder.Where(d => d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.DealDate.HasValue == true && d.DealDate.Value >= currentDate && d.DealDate.Value < endDate);
            //总成交折线图转换
            var totalDealBrokenLine = totalDealInfo.GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changetotalDealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, totalDealBrokenLine);
            performanceVo.TotalDealBrokenLine = changetotalDealBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var newCustomerDealInfo = totalDealInfo.Where(x => x.IsOldCustomer == false);
            //新客成交折线图转换
            var newCustomerDealBrokenLine = newCustomerDealInfo.GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changenewCustomerDealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, newCustomerDealBrokenLine);
            performanceVo.NewCustomerDealBrokenLine = changenewCustomerDealBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var oldCustomerDealInfo = totalDealInfo.Where(x => x.IsOldCustomer == true);
            //老客成交折线图转换
            var oldCustomerDealBrokenLine = oldCustomerDealInfo.GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changeoldCustomerDealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, oldCustomerDealBrokenLine);
            performanceVo.OldCustomerDealBrokenLine = changeoldCustomerDealBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();
            #endregion

            return ResultData<SendOrDealPerformanceVo>.Success().AddData("performance", performanceVo);
        }
        #endregion

        #region 【客单价经营看板】
        /// <summary>
        /// 客单价经营看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">中文主播名字（刀刀，吉娜）</param>
        /// <returns></returns>
        [HttpGet("GuestUnitPricePerformanceByLiveAnchorName")]
        public async Task<ResultData<GuestUnitPricePerformanceVo>> GetGuestUnitPricePerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            //获取当前月同比,环比等数据
            var performance = await amiyaPerformanceService.GetGuestUnitPricePerformanceByLiveAnchorAsync(year, month, liveAnchorName);
            GuestUnitPricePerformanceVo performanceVo = new GuestUnitPricePerformanceVo();

            #region 【总客单价】
            performanceVo.TotalGuestUnitPricePerformance = performance.TotalGuestUnitPricePerformance;

            performanceVo.TotalGuestUnitPricePerformanceYearOnYear = performance.TotalGuestUnitPricePerformanceYearOnYear;

            performanceVo.TotalGuestUnitPricePerformanceChainRatio = performance.TotalGuestUnitPricePerformanceChainRatio;
            #endregion

            #region 【新诊客单价】
            performanceVo.NewGuestUnitPricePerformance = performance.NewGuestUnitPricePerformance;

            performanceVo.NewGuestUnitPricePerformanceYearOnYear = performance.NewGuestUnitPricePerformanceYearOnYear;

            performanceVo.NewGuestUnitPricePerformanceChainRatio = performance.NewGuestUnitPricePerformanceChainRatio;
            #endregion

            #region 【老客客单价】
            performanceVo.OldGuestUnitPricePerformance = performance.OldGuestUnitPricePerformance;

            performanceVo.OldGuestUnitPricePerformanceYearOnYear = performance.OldGuestUnitPricePerformanceYearOnYear;

            performanceVo.OldGuestUnitPricePerformanceChainRatio = performance.OldGuestUnitPricePerformanceChainRatio;
            #endregion


            #region 【折线图】
            var liveAnchorIndependenceBrokenLine = await amiyaPerformanceService.GetGuestUnitPricePerformanceAsync(year, month, null, liveAnchorName);
            performanceVo.TotalGuestUnitPricePerformanceBrokenLine = liveAnchorIndependenceBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var customerServiceIndependenceBrokenLine = await amiyaPerformanceService.GetGuestUnitPricePerformanceAsync(year, month, false, liveAnchorName);
            performanceVo.NewGuestUnitPricePerformanceBrokenLine = customerServiceIndependenceBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var customerServiceAssistBrokenLine = await amiyaPerformanceService.GetGuestUnitPricePerformanceAsync(year, month, true, liveAnchorName);
            performanceVo.OldGuestUnitPricePerformanceBrokenLine = customerServiceAssistBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            #endregion

            return ResultData<GuestUnitPricePerformanceVo>.Success().AddData("performance", performanceVo);
        }



        #endregion

        #region 【各版块占比看板】
        /// <summary>
        /// 各版块占比看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">中文主播名字（刀刀，吉娜）</param>
        /// <returns></returns>
        [HttpGet("performanceCompleteRate")]
        public async Task<ResultData<GroupTargetCompleteRateVo>> GetPerformanceCompleteRateByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            //获取当前月同比,环比等数据
            var performance = await amiyaPerformanceService.GetPerformanceCompleteRateByLiveAnchorNameAsync(year, month, liveAnchorName);
            GroupTargetCompleteRateVo performanceVo = new GroupTargetCompleteRateVo();

            #region 【加v】
            performanceVo.AddWeChatCompleteRate = performance.AddWeChatCompleteRate;

            performanceVo.AddWeChatCompleteRateYearOnYear = performance.AddWeChatCompleteRateYearOnYear;

            performanceVo.AddWeChatCompleteRateChainRatio = performance.AddWeChatCompleteRateChainRatio;

            performanceVo.AddWeChatCompleteRateTarget = performance.AddWeChatCompleteRateTarget;
            #endregion

            #region 【下单面诊卡消耗率】
            performanceVo.ConsulationCardUsedCompleteRate = performance.ConsulationCardUsedCompleteRate;

            performanceVo.ConsulationCardUsedCompleteRateYearOnYear = performance.ConsulationCardUsedCompleteRateYearOnYear;

            performanceVo.ConsulationCardUsedCompleteRateChainRatio = performance.ConsulationCardUsedCompleteRateChainRatio;

            performanceVo.ConsulationCardUsedCompleteRateTarget = performance.ConsulationCardUsedCompleteRateTarget;
            #endregion

            #region 【派单率】
            performanceVo.SendOrderCompleteRate = performance.SendOrderCompleteRate;

            performanceVo.SendOrderCompleteRateChainRatio = performance.SendOrderCompleteRateChainRatio;

            performanceVo.SendOrderCompleteRateYearOnYear = performance.SendOrderCompleteRateYearOnYear;

            performanceVo.SendOrderCompleteRateTarget = performance.SendOrderCompleteRateTarget;
            #endregion

            #region 【新客上门率】
            performanceVo.NewCustomerVisitCompleteRate = performance.NewCustomerVisitCompleteRate;

            performanceVo.NewCustomerVisitCompleteRateYearOnYear = performance.NewCustomerVisitCompleteRateYearOnYear;

            performanceVo.NewCustomerVisitCompleteRateChainRatio = performance.NewCustomerVisitCompleteRateChainRatio;

            performanceVo.NewCustomerVisitCompleteRateTarget = performance.NewCustomerVisitCompleteRateTarget;
            #endregion

            #region 【新客成交率】
            performanceVo.NewCustomerDealCompleteRate = performance.NewCustomerDealCompleteRate;

            performanceVo.NewCustomerDealCompleteRateYearOnYear = performance.NewCustomerDealCompleteRateYearOnYear;

            performanceVo.NewCustomerDealCompleteRateChainRatio = performance.NewCustomerDealCompleteRateChainRatio;

            performanceVo.NewCustomerDealCompleteRateTarget = performance.NewCustomerDealCompleteRateTarget;
            #endregion

            #region 【当月面诊卡退单率】
            performanceVo.ThisMonthConsulationCardRefundCompleteRate = performance.ThisMonthConsulationCardRefundCompleteRate;

            performanceVo.ThisMonthConsulationCardRefundCompleteRateYearOnYear = performance.ThisMonthConsulationCardRefundCompleteRateYearOnYear;

            performanceVo.ThisMonthConsulationCardRefundCompleteRateChainRatio = performance.ThisMonthConsulationCardRefundCompleteRateChainRatio;

            performanceVo.ThisMonthConsulationCardRefundCompleteRateTarget = performance.ThisMonthConsulationCardRefundCompleteRateTarget;

            #endregion

            #region 【历史面诊卡退单率】
            performanceVo.HistoryConsulationCardRefundCompleteRate = performance.HistoryConsulationCardRefundCompleteRate;

            performanceVo.HistoryConsulationCardRefundCompleteRateYearOnYear = performance.HistoryConsulationCardRefundCompleteRateYearOnYear;

            performanceVo.HistoryConsulationCardRefundCompleteRateChainRatio = performance.HistoryConsulationCardRefundCompleteRateChainRatio;

            performanceVo.HistoryConsulationCardRefundCompleteRateTarget = performance.HistoryConsulationCardRefundCompleteRateTarget;

            #endregion

            #region 【折线图】

            var addWechatBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, null, null, true, null, liveAnchorName);
            performanceVo.AddWeChatCompleteRateBrokenLine = addWechatBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var thisMonthConsulationCardConsumedNumBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, false, null, null, true, liveAnchorName);
            performanceVo.ConsulationCardUsedCompleteRateBrokenLine = thisMonthConsulationCardConsumedNumBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();


            //开始月份
            DateTime currentDate = new DateTime(year, 1, 1);
            //结束月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            //分组派单情况
            var sendOrder = await amiyaPerformanceService.GetSendOrDealBrokenLineAsync(true, null, null, null, liveAnchorName);
            //派单结果
            var sendResult = sendOrder.Where(d => d.SendDate.HasValue == true && d.SendDate.Value >= currentDate && d.SendDate.Value < endDate).ToList();
            //派单折线图转换
            var sendOrderBrokenLine = sendResult.GroupBy(x => x.SendDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changeSendOrderBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, sendOrderBrokenLine);
            performanceVo.SendOrderCompleteRateBrokenLine = changeSendOrderBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            //总上门结果
            var newCustomerVisitInfo = sendOrder.Where(d => d.IsToHospital == true && d.IsOldCustomer == false && d.ToHospitalDate.HasValue == true && d.ToHospitalDate.Value >= currentDate && d.ToHospitalDate.Value < endDate);
            //新客上门折线图转换
            var newCustomerVisitBrokenLine = newCustomerVisitInfo.GroupBy(x => x.ToHospitalDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changenewCustomerVisitBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, newCustomerVisitBrokenLine);
            performanceVo.NewCustomerVisitCompleteRateBrokenLine = changenewCustomerVisitBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();


            //总成交结果
            var newCustomerDealInfo = sendOrder.Where(d => d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.IsOldCustomer == false && d.DealDate.HasValue == true && d.DealDate.Value >= currentDate && d.DealDate.Value < endDate);
            //新客成交折线图转换
            var newCustomerDealBrokenLine = newCustomerDealInfo.GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Count() }).ToList();
            var changenewCustomerDealBrokenLine = BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, newCustomerDealBrokenLine);
            performanceVo.NewCustomerDealCompleteRateBrokenLine = changenewCustomerDealBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var thisMonthConsulationCardRefundNumBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, null, false, null, null, liveAnchorName);
            performanceVo.ThisMonthConsulationCardRefundCompleteRateBrokenLine = thisMonthConsulationCardRefundNumBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            var historyConsulationCardRefundNumBrokenLine = await amiyaPerformanceService.GetBaseBusinessPerformanceBrokenLineAsync(year, month, null, true, null, null, liveAnchorName);
            performanceVo.HistoryConsulationCardRefundCompleteRateBrokenLine = historyConsulationCardRefundNumBrokenLine.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();



            #endregion

            return ResultData<GroupTargetCompleteRateVo>.Success().AddData("performance", performanceVo);
        }
        #endregion

        #endregion

        #region 【其他明细】

        /// <summary>
        /// 根据年月获取派单成交明细
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isHistorySendOrder">是否为历史派单；true:历史派单当月成交，false：当月派单当月成交</param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        [HttpGet("getSendAndDealPerformanceDetailList")]
        public async Task<ResultData<List<Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder.ContentPlatFormOrderDealInfoVo>>> GetSendAndDealPerformanceDetailListAsync(int year, int month, bool isHistorySendOrder, string liveAnchorName)
        {
            var performanceDetailList = await amiyaPerformanceService.GetSendAndDealPerformanceByYearAndMonthAndLiveAnchorNameAsync(year, month, isHistorySendOrder, liveAnchorName);
            var contentPlatformOrderDeals = from d in performanceDetailList
                                            select new Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder.ContentPlatFormOrderDealInfoVo
                                            {
                                                Id = d.Id,
                                                CreateDate = d.CreateDate,
                                                ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                SendDate = d.SendDate,
                                                CustomerNickName = d.CustomerNickName,
                                                Phone = d.Phone,
                                                IsOldCustomer = d.IsOldCustomer,
                                                ToHospitalTypeText = d.ToHospitalTypeText,
                                                AddOrderPrice = d.AddOrderPrice,
                                                Price = d.Price,
                                            };
            return ResultData<List<Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder.ContentPlatFormOrderDealInfoVo>>.Success().AddData("performance", contentPlatformOrderDeals.ToList());

        }
        /// <summary>
        /// 根据年月与主播名字获取照片/视频面诊明细
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo">是否为视频面诊；true:视频面诊，false：照片面诊</param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        [HttpGet("getPictureOrVideoPerformanceList")]
        public async Task<ResultData<List<ShoppingCartRegistrationVo>>> GetPictureOrVideoPerformanceListAsync(int year, int month, bool isVideo, string liveAnchorName)
        {
            var performanceDetailList = await amiyaPerformanceService.GetPictureOrVideoConsultationByLiveAnchorAsync(year, month, isVideo, liveAnchorName);
            var contentPlatformOrderDeals = from d in performanceDetailList
                                            select new ShoppingCartRegistrationVo
                                            {
                                                RecordDate = d.RecordDate,
                                                EmergencyLevelText = d.EmergencyLevelText,
                                                CustomerNickName = d.CustomerNickName,
                                                Phone = d.Phone,
                                                Price = d.Price,
                                                IsCreateOrder = d.IsCreateOrder,
                                                IsSendOrder = d.IsSendOrder,
                                                IsConsultation = d.IsConsultation,
                                                IsAddWeChat = d.IsAddWeChat,
                                                IsWriteOff = d.IsWriteOff,
                                                IsReturnBackPrice = d.IsReturnBackPrice,
                                                IsBadReview = d.IsBadReview,
                                            };
            return ResultData<List<ShoppingCartRegistrationVo>>.Success().AddData("performance", contentPlatformOrderDeals.ToList());

        }
        #endregion



        #region 【业绩看板】

        /// <summary>
        /// 获取业绩数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("amiyaAchievementData")]
        public async Task<ResultData<AmiyaAchievementDataVo>> GetAmiyaAchievementDataAsync([FromQuery] QueryAmiyaAchievementDataVo query) {
            AmiyaAchievementDataVo dataVo = new AmiyaAchievementDataVo();

            #region 总业绩
            dataVo.TotalPerformance = 1000;
            dataVo.TotalPerformanceCompleteRate = 50;
            dataVo.TotalPerformanceYearOnYear = 20;
            dataVo.TotalPerformanceChainRatio = 20;
            dataVo.TotalPerformanceToDateSchedule = 50;
            dataVo.TotalPerformanceDeviation = 0;
            dataVo.LaterCompleteEveryDayTotalPerformance = 66.67m;
            #endregion

            #region 刀刀组业绩

            dataVo.GroupDaoDaoPerformance = 500;
            dataVo.GroupDaoDaoPerformanceProportion = 50;
            dataVo.GroupDaoDaoPerformanceCompleteRate = 50;
            dataVo.GroupDaoDaoPerformanceYearOnYear = 20;
            dataVo.GroupDaoDaoPerformanceChainRatio = 20;
            dataVo.GroupDaoDaoPerformanceToDateSchedule = 50;
            dataVo.GroupDaoDaoPerformanceDeviation = 0;
            dataVo.LaterCompleteEveryDayGroupDaoDaoPerformance = 66.67m;

            #endregion

            #region 吉娜组业绩

            dataVo.GroupJinaPerformance = 500;
            dataVo.GroupJinaPerformanceProportion = 50;
            dataVo.GroupJinaPerformanceCompleteRate = 50;
            dataVo.GroupJinaPerformanceYearOnYear = 20;
            dataVo.GroupJinaPerformanceChainRatio = 20;
            dataVo.GroupJinaPerformanceToDateSchedule = 50;
            dataVo.GroupJinaPerformanceDeviation = 0;
            dataVo.LaterCompleteEveryDayGroupJinaPerformance = 66.67m;

            #endregion

            #region 退款业绩 

            dataVo.RefundPerformance = 10;

            #endregion
            return null; 
            



        }
        #endregion

        #region【运营看板】

        #endregion
    }
}