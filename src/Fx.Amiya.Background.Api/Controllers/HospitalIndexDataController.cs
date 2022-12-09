using Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.Background.Api.Vo.HospitalIndex;
using Fx.Amiya.Dto.HospitalIndexData;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
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
    /// 机构首页数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxTenantAuthorize]
    public class HospitalIndexDataController : ControllerBase
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IHospitalPerformanceService hospitalPerformanceService;
        private IContentPlatformOrderSendService _sendOrderInfoService;
        public HospitalIndexDataController(IHttpContextAccessor httpContextAccessor, IHospitalPerformanceService hospitalPerformanceService, IContentPlatformOrderSendService sendOrderInfoService)
        {
            _httpContextAccessor = httpContextAccessor;
            this.hospitalPerformanceService = hospitalPerformanceService;
            _sendOrderInfoService = sendOrderInfoService;
        }
        /// <summary>
        /// 医院获取今日未处理任务
        /// </summary>
        /// <returns></returns>
        [HttpGet("getTodayNotRepeatedSendOrder")]
        [FxTenantAuthorize]
        public async Task<ResultData<List<HospitalCurrentDayNotRepeatedSendOrderVo>>> GetHospitalTodayUnRepeatSendOrderAsync()
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            DateTime startDate = DateTime.Now.Date;
            DateTime endDate = DateTime.Now.Date.AddDays(1);
            var list = await _sendOrderInfoService.GetTodayNotRepeatSendOrderByHospitalIdAsync(hospitalId, (int)ContentPlateFormOrderStatus.SendOrder, startDate, endDate, 1, 5);
            var todayList = list.List.Select(e => new HospitalCurrentDayNotRepeatedSendOrderVo
            {
                Id = e.Id,
                OrderStatus = e.OrderStatus,
                OrderStatusText = e.OrderStatusText,
                Item = e.Item,
                UserInfo = e.UserInfo,
                LastFollowContent = e.LastFollowContent
            }).ToList();
            return ResultData<List<HospitalCurrentDayNotRepeatedSendOrderVo>>.Success().AddData("todayNoRepeatedSendOrder", todayList);
        }
        /// <summary>
        /// 首页机构数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("hospitalData")]
        public async Task<ResultData<HospitalDataVo>> GetHospitalData() {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            var data= await hospitalPerformanceService.GetHospitalDataAsync(hospitalId);
            HospitalDataVo hospitalDataVo = new HospitalDataVo();
            hospitalDataVo.ThisMonthSendOrderCount = data.ThisMonthSendOrderCount;
            hospitalDataVo.SendOrderCountChainRatio = data.SendOrderCountChainRatio;
            hospitalDataVo.ThisMonthDealCount = data.ThisMonthDealCount;
            hospitalDataVo.DealCountChainRatio = data.DealCountChainRatio;
            hospitalDataVo.YearSendOrderCount = data.YearSendOrderCount;
            hospitalDataVo.TotalSendOrderCount = data.TotalSendOrderCount;
            hospitalDataVo.YearDealCount = data.YearDealCount;
            hospitalDataVo.TotalDealCount = data.TotalDealCount;
            hospitalDataVo.ThisMonthSendOrderDealRatio = data.ThisMonthSendOrderDealRatio;
            hospitalDataVo.YearSendOrderDealRatio = data.YearSendOrderDealRatio;
            return ResultData<HospitalDataVo>.Success().AddData("hospitalData", hospitalDataVo);
        }
        /// <summary>
        /// 首页机构数据比例数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("hospitalDataRatio")]
        public async Task<ResultData<HospitalDataRatioVo>> GetHospitalDataRatio()
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            var data = await hospitalPerformanceService.GetHospitalDataRatioAsync(hospitalId);
            HospitalDataRatioVo hospitalDataVo = new HospitalDataRatioVo();
            hospitalDataVo.ToHospitalRatio = data.ToHospitalRatio;
            hospitalDataVo.ToHospitalRatioChainRatio = data.ToHospitalRatioChainRatio;
            hospitalDataVo.NewCustomerDealRatio = data.NewCustomerDealRatio;
            hospitalDataVo.NewCustomerDealRatioChainRatio = data.NewCustomerDealRatioChainRatio;
            hospitalDataVo.OldCustomerDealRatio = data.OldCustomerDealRatio;
            hospitalDataVo.OldCustomerDealRatioChainRatio = data.OldCustomerDealRatioChainRatio;
            hospitalDataVo.NewCustomerRatio = data.NewCustomerRatio;
            hospitalDataVo.NewCustomerRatioChainRatio = data.NewCustomerRatioChainRatio;
            hospitalDataVo.OldCustomerRatio = data.OldCustomerRatio;
            hospitalDataVo.OldCustomerRatioChainRatio = data.OldCustomerRatioChainRatio;
            return ResultData<HospitalDataRatioVo>.Success().AddData("hospitalDataRatio", hospitalDataVo);
        }
    }
}
