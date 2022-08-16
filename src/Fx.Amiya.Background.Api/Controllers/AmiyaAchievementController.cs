using Fx.Amiya.Background.Api.Vo.Appointment;
using Fx.Amiya.Background.Api.Vo.OrderReport;
using Fx.Amiya.Background.Api.Vo.Performance;
using Fx.Amiya.Core.Interfaces.Goods;
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
            ILiveAnchorDailyTargetService liveAnchorDailyTargetService)
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
        }

        #region 例子，可删
        /// <summary>
        /// 获取订单经营情况
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        [HttpGet("OrderOperationCondition")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<OrderOperationConditionVo>>> GetOrderOperationConditionAsync(DateTime? startDate, DateTime? endDate)
        {
            TimeSpan timeSpan = endDate.Value - startDate.Value;
            var date = timeSpan.TotalDays;
            List<OrderOperationConditionVo> orderOperationCondition = new List<OrderOperationConditionVo>();
            var q = await orderService.GetOrderOperationConditionAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.Value.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                orderOperationCondition.Add(condition);
            }
            foreach (var x in q)
            {
                orderOperationCondition.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            return ResultData<List<OrderOperationConditionVo>>.Success().AddData("orderOperationCondition", orderOperationCondition);
        }
        #endregion

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
            
            var performance = await _contentPlatFormOrderDealInfoService.GetOrderDetailInfoPerformance(year, month);
            PerformanceVo performanceVo = new PerformanceVo
            {
                TotalPerformance = performance.TotalPerformance,
                TotalPerformanceYearOnYear = performance.TotalPerformanceYearOnYear,
                TotalPerformanceChainRatio = performance.TotalPerformanceChainRatio,
                TotalPerformanceTargetComplete = performance.TotalPerformanceTargetComplete,
                NewPerformance = performance.NewPerformance,
                NewPerformanceYearOnYear = performance.NewPerformanceYearOnYear,
                NewPerformanceChainRatio = performance.NewPerformanceChainRatio,
                NewPerformanceTargetComplete = performance.NewPerformanceTargetComplete,
                OldPerformance = performance.OldPerformance,
                OldPerformanceYearOnYear = performance.OldPerformanceYearOnYear,
                OldPerformanceChainRatio = performance.OldPerformanceChainRatio,
                OldPerformanceTargetComplete = performance.OldPerformanceTargetComplete,
                CommercePerformance = performance.CommercePerformance,
                CommercePerformanceYearOnYear = performance.CommercePerformanceYearOnYear,
                CommercePerformanceChainRatio = performance.CommercePerformanceChainRatio,
                CommercePerformanceTargetComplete = performance.CommercePerformanceTargetComplete,
                PerformanceRatios = performance.PerformanceRatios.Select(d => new PerformanceRatioVo
                {
                    PerformanceText = d.PerformanceText,
                    PerformancePrice = d.PerformancePrice,
                    PerformanceRatio = d.PerformanceRatio
                }).ToList(),
                NewPerformanceData = performance.newPerformanceList.Select(data => new PerformanceListInfo
                {
                    date = data.date,
                    Performance = data.Performance
                }).ToList(),
                OldPerformanceData = performance.oldPerformanceList.Select(data => new PerformanceListInfo
                {
                    date = data.date,
                    Performance = data.Performance
                }).ToList(),
                CommercePerformanceData = performance.commercePerformanceList.Select(data => new PerformanceListInfo
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

        #endregion
    }
}
