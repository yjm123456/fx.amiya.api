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
            performanceVo.OldPerformanceData = old.Select(o => new Vo.Performance.PerformanceListInfo { date = o.Date.ToString(), Performance = o.PerfomancePrice }).ToList();


            //新客业绩数据
            var newPerformance = await _contentPlatFormOrderDealInfoService.GetPerformance(year, month, false);
            performanceVo.NewPerformanceData = newPerformance.Select(n => new Vo.Performance.PerformanceListInfo { date = n.Date.ToString(), Performance = n.PerfomancePrice }).ToList();

            //带货业绩数据
            var comm = await _liveAnchorMonthlyTargetService.GetLiveAnchorCommercePerformance(year, month);
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

            #region 【合作达人业绩】
            groupPerformanceVo.CooperationLiveAnchorPerformance = groupPerformance.CooperationLiveAnchorPerformance;
            groupPerformanceVo.CooperationLiveAnchorPerformanceYearOnYear = groupPerformance.CooperationLiveAnchorPerformanceYearOnYear;
            groupPerformanceVo.CooperationLiveAnchorPerformanceChainRatio = groupPerformance.CooperationLiveAnchorPerformanceChainRatio;
            groupPerformanceVo.CooperationLiveAnchorPerformanceCompleteRate = groupPerformance.CooperationLiveAnchorPerformanceCompleteRate;
            #endregion

            #region 【黄V组业绩】
            groupPerformanceVo.GroupYellowVPerformance = groupPerformance.GroupYellowVPerformance;
            groupPerformanceVo.GroupYellowVPerformanceYearOnYear = groupPerformance.GroupYellowVPerformanceYearOnYear;
            groupPerformanceVo.GroupYellowVPerformanceChainRatio = groupPerformance.GroupYellowVPerformanceChainRatio;
            groupPerformanceVo.GroupYellowVPerformanceCompleteRate = groupPerformance.GroupYellowVPerformanceCompleteRate;
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
            PerformanceRatioDto cooperationLiveAnchorRatio = new PerformanceRatioDto
            {
                PerformanceText = "合作达人业绩",
                PerformancePrice = groupPerformance.CooperationLiveAnchorPerformance,
                PerformanceRatio = groupPerformance.AccountedForCooperationLiveAnchorPerformance
            };
            ratioDtos.Add(cooperationLiveAnchorRatio);
            PerformanceRatioDto yellowVRatio = new PerformanceRatioDto
            {
                PerformanceText = "黄V组业绩",
                PerformancePrice = groupPerformance.GroupYellowVPerformance,
                PerformanceRatio = groupPerformance.AccountedForGroupYellowVPerformance
            };
            ratioDtos.Add(yellowVRatio);

            groupPerformanceVo.PerformanceRatios = ratioDtos.Select(d => new PerformanceRatioVo
            {
                PerformanceText = d.PerformanceText,
                PerformancePrice = d.PerformancePrice,
                PerformanceRatio = d.PerformanceRatio
            }).ToList();
            #endregion

            #region 【折线图】
            //刀刀组业绩折线图
            var historySendThisMonthDealOrderList = await amiyaPerformanceService.GetLiveAnchorPerformanceByBaseIdAsync(year, month, "");
            groupPerformanceVo.GroupDaoDaoPerformanceData = historySendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();

            //吉娜组业绩折线图
            var thisMonthSendThisMonthDealOrderList = await amiyaPerformanceService.GetLiveAnchorPerformanceByBaseIdAsync(year, month, "");
            groupPerformanceVo.GroupJinaPerformanceData = thisMonthSendThisMonthDealOrderList.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();
            //合作达人业绩折线图
            var cooperationLiveAnchorBorkenLines = await amiyaPerformanceService.GetLiveAnchorPerformanceAsync(year, month, "d2e71501-7327-4883-9294-371a77c4cabd");
            groupPerformanceVo.CooperationLiveAnchorPerformanceData = cooperationLiveAnchorBorkenLines.Select(data => new Vo.Performance.PerformanceListInfo
            {
                date = data.Date,
                Performance = data.PerfomancePrice
            }).ToList();
            //黄V组业绩折线图
            var yellowVBorkenLines = await amiyaPerformanceService.GetLiveAnchorPerformanceAsync(year, month, "2bd8b9ad-afd7-4982-b783-fcad7d342f11");
            groupPerformanceVo.GroupYellowVPerformanceData = yellowVBorkenLines.Select(data => new Vo.Performance.PerformanceListInfo
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

            decimal sumSendAndDealOrderInfo = performanceVo.HistorySendDuringMonthDeal.Value + performanceVo.DuringMonthSendDuringMonthDeal.Value;
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


        /// <summary>
        /// 根据年月获取派单成交明细
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isHistorySendOrder">是否为历史派单；true:历史派单当月成交，false：当月派单当月成交</param>
        /// <returns></returns>
        [HttpGet("getSendAndDealPerformanceDetailList")]
        public async Task<ResultData<List<Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder.ContentPlatFormOrderDealInfoVo>>> GetSendAndDealPerformanceDetailList(int year, int month, bool isHistorySendOrder)
        {
            var performanceDetailList = await _contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, isHistorySendOrder);
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
        #endregion
    }
}