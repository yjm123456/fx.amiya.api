using Fx.Amiya.Background.Api.Vo.AssistantHomePage;
using Fx.Amiya.Background.Api.Vo.AssistantHomePage.Result;
using Fx.Amiya.Dto.AssistantHomePage.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
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
    /// 助理首页
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AssistantHomePageController : ControllerBase
    {
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ICustomerAppointmentScheduleService customerAppointmentScheduleService;
        private readonly IAssistantHomePageService assistantHomePageService;
        private readonly ITrackService trackService;
        public AssistantHomePageController(IContentPlateFormOrderService contentPlateFormOrderService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService, ICustomerAppointmentScheduleService customerAppointmentScheduleService, IAssistantHomePageService assistantHomePageService, ITrackService trackService)
        {
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.customerAppointmentScheduleService = customerAppointmentScheduleService;
            this.assistantHomePageService = assistantHomePageService;
            this.trackService = trackService;
        }

        /// <summary>
        /// 获取订单数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("orderData")]
        public async Task<ResultData<AssistantOrderDataVo>> GetOrderDataAsync([FromQuery] QueryAssistantHomePageDataVo query)
        {
            AssistantOrderDataVo result = new AssistantOrderDataVo();
            QueryAssistantHomePageDataDto queryDto = new QueryAssistantHomePageDataDto();
            queryDto.Date = query.Date;
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            queryDto.ContentPlatformId = query.ContentPlatformId;
            queryDto.LiveAnchorId = query.LiveAnchorId;
            queryDto.WechatNoId = query.WechatNoId;
            queryDto.Source = query.Source;
            queryDto.AssistantId = query.AssistantId;
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            var data = await contentPlateFormOrderService.GetAssistantOrderDataAsync(queryDto);
            result.TotalShoppingCartRegistionCount = data.TotalShoppingCartRegistionCount;
            result.TotalOrderCount = data.TotalOrderCount;
            result.TodayOrderCount = data.TodayOrderCount;
            result.UnSendOrderCount = data.UnSendOrderCount;
            result.TodayDealOrderCount = data.TodayDealOrderCount;
            return ResultData<AssistantOrderDataVo>.Success().AddData("orderData", result);
        }
        /// <summary>
        /// 获取今日到院数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("todayToHospitalData")]
        public async Task<ResultData<FxPageInfo<TodayToHospitalDataVo>>> GetTodayToHospitalDataAsync([FromQuery] QueryAssistantHomePageDataVo query)
        {
            FxPageInfo<TodayToHospitalDataVo> fxPageInfo = new FxPageInfo<TodayToHospitalDataVo>();
            QueryAssistantHomePageDataDto queryDto = new QueryAssistantHomePageDataDto();
            queryDto.Date = query.Date;
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            queryDto.ContentPlatformId = query.ContentPlatformId;
            queryDto.LiveAnchorId = query.LiveAnchorId;
            queryDto.WechatNoId = query.WechatNoId;
            queryDto.Source = query.Source;
            queryDto.AssistantId = query.AssistantId;
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            var result = await contentPlatFormOrderDealInfoService.GetTodayToHospitalDataAsync(queryDto);
            fxPageInfo.TotalCount = result.TotalCount;
            fxPageInfo.List = result.List.Select(e => new TodayToHospitalDataVo
            {
                Name = e.Name,
                Phone = e.Phone,
                AssistantName = e.AssistantName,
                SendHospital = e.SendHospital,
                Status = e.Status,
                EncryptPhone = e.EncryptPhone
            }).ToList();
            return ResultData<FxPageInfo<TodayToHospitalDataVo>>.Success().AddData("todayToHospitalData", fxPageInfo);
        }
        /// <summary>
        /// 获取今日预约数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("todayAppointmentData")]
        public async Task<ResultData<FxPageInfo<TodayAppointmentDataVo>>> GetTodayAppointmentDataAsync([FromQuery] QueryAssistantHomePageDataVo query)
        {
            FxPageInfo<TodayAppointmentDataVo> fxPageInfo = new FxPageInfo<TodayAppointmentDataVo>();
            QueryAssistantHomePageDataDto queryDto = new QueryAssistantHomePageDataDto();
            queryDto.Date = query.Date;
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            queryDto.ContentPlatformId = query.ContentPlatformId;
            queryDto.LiveAnchorId = query.LiveAnchorId;
            queryDto.WechatNoId = query.WechatNoId;
            queryDto.Source = query.Source;
            queryDto.AssistantId = query.AssistantId;
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            var result = await customerAppointmentScheduleService.GetTodayAppointmentDataAsync(queryDto);
            fxPageInfo.TotalCount = result.TotalCount;
            fxPageInfo.List = result.List.Select(e => new TodayAppointmentDataVo
            {
                Name = e.Name,
                Phone = e.Phone,
                AssistantName = e.AssistantName,
                SendHospital = e.SendHospital,
                Status = e.Status,
                IsAccompany = e.IsAccompany,
                ConsultSituation = e.ConsultSituation,
                EncryptPhone = e.EncryptPhone
            }).ToList();
            return ResultData<FxPageInfo<TodayAppointmentDataVo>>.Success().AddData("todayAppointmentData", fxPageInfo);
        }
        /// <summary>
        /// 获取月业绩完成情况数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("monthPerformanceData")]
        public async Task<ResultData<MonthPerformanceCompleteSituationDataVo>> GetMonthPerformanceCompleteSituationDataAsync([FromQuery] QueryAssistantHomePageDataVo query)
        {
            MonthPerformanceCompleteSituationDataVo data = new MonthPerformanceCompleteSituationDataVo();
            QueryAssistantHomePageDataDto queryDto = new QueryAssistantHomePageDataDto();
            queryDto.Date = query.Date;
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            queryDto.ContentPlatformId = query.ContentPlatformId;
            queryDto.LiveAnchorId = query.LiveAnchorId;
            queryDto.WechatNoId = query.WechatNoId;
            queryDto.Source = query.Source;
            queryDto.AssistantId = query.AssistantId;
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            var result = await assistantHomePageService.GetMonthPerformanceCompleteSituationDataAsync(queryDto);
            data.CompletedPerformance = result.CompletedPerformance;
            data.NewCustomerPerformance = result.NewCustomerPerformance;
            data.OldCustomerPerformance = result.OldCustomerPerformance;
            data.TriageCount = result.TriageCount;
            data.AddWechat = result.AddWechat;
            data.AddWechatRatio = result.AddWechatRatio;
            data.SenOrderCount = result.SenOrderCount;
            data.SendOrderRatio = result.SendOrderRatio;
            data.ToHospitalCount = result.ToHospitalCount;
            data.ToHospitalCountRatio = result.ToHospitalCountRatio;
            data.DealCount = result.DealCount;
            data.DealRatio = result.DealRatio;
            return ResultData<MonthPerformanceCompleteSituationDataVo>.Success().AddData("monthPerformanceData", data);
        }
        /// <summary>
        /// 获取今日回访数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("todayTrackData")]
        public async Task<ResultData<FxPageInfo<TodayTrackDataVo>>> GetTodayTrackDataAsync([FromQuery] QueryAssistantHomePageTrackDataDto query)
        {
            FxPageInfo<TodayTrackDataVo> fxPageInfo = new FxPageInfo<TodayTrackDataVo>();
            QueryAssistantHomePageTrackDataDto queryDto = new QueryAssistantHomePageTrackDataDto();
            queryDto.Type = query.Type;
            queryDto.Date = query.Date;
            queryDto.BaseLiveAnchorId = query.BaseLiveAnchorId;
            queryDto.ContentPlatformId = query.ContentPlatformId;
            queryDto.LiveAnchorId = query.LiveAnchorId;
            queryDto.WechatNoId = query.WechatNoId;
            queryDto.Source = query.Source;
            queryDto.AssistantId = query.AssistantId;
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            var result = await trackService.GetTodayTrackDataAsync(queryDto);
            fxPageInfo.TotalCount = result.TotalCount;
            fxPageInfo.List = result.List.Select(e => new TodayTrackDataVo
            {
                Phone = e.Phone,
                Status = e.Status,
                TrackAssistantName = e.TrackAssistantName,
                TrackPurpose = e.TrackPurpose,
                Remark = e.Remark,
                EncryptPhone = e.EncryptPhone
            }).ToList();
            return ResultData<FxPageInfo<TodayTrackDataVo>>.Success().AddData("todayTrackData", fxPageInfo);
        }

    }
}
