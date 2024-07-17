using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget;
using Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget.AfterLiving;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
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
    /// 直播后主播月度运营目标情况数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveAnchorMonthlyTargetAfterLivingController : ControllerBase
    {
        private ILiveAnchorMonthlyTargetAfterLivingService _liveAnchorMonthlyTargetAfterLivingService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LiveAnchorMonthlyTargetAfterLivingController(ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService,
            IHttpContextAccessor httpContextAccessor)
        {
            _liveAnchorMonthlyTargetAfterLivingService = liveAnchorMonthlyTargetAfterLivingService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取直播后主播月度运营目标情况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<LiveAnchorMonthlyTargetAfterLivingVo>>> GetListWithPageAsync(int year, int month, int? liveAnchorId, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await _liveAnchorMonthlyTargetAfterLivingService.GetListWithPageAsync(year, month, liveAnchorId, employeeId, pageNum, pageSize);

                var liveAnchorMonthlyTargetAfterLiving = from d in q.List
                                                    select new LiveAnchorMonthlyTargetAfterLivingVo
                                                    {
                                                        Id = d.Id,
                                                        Year = d.Year,
                                                        Month = d.Month,
                                                        MonthlyTargetName = d.MonthlyTargetName,
                                                        LiveAnchorId = d.LiveAnchorId,
                                                        ContentPlatFormId = d.ContentPlatFormId,
                                                        LiveAnchorName = d.LiveAnchorName,
                                                        AddWechatTarget = d.AddWechatTarget,
                                                        CumulativeAddWechat = d.CumulativeAddWechat,
                                                        AddWechatCompleteRate = d.AddWechatCompleteRate,
                                                        ConsultationCardConsumedTarget = d.ConsultationCardConsumedTarget,
                                                        CumulativeConsultationCardConsumed = d.CumulativeConsultationCardConsumed,
                                                        ConsultationCardConsumedCompleteRate = d.ConsultationCardConsumedCompleteRate,
                                                        ConsultationCardConsumedTarget2 = d.ConsultationCardConsumedTarget2,
                                                        CumulativeConsultationCardConsumed2 = d.CumulativeConsultationCardConsumed2,
                                                        ConsultationCardConsumedCompleteRate2 = d.ConsultationCardConsumedCompleteRate2,
                                                        ActivateHistoricalConsultationTarget = d.ActivateHistoricalConsultationTarget,
                                                        CumulativeActivateHistoricalConsultation = d.CumulativeActivateHistoricalConsultation,
                                                        ActivateHistoricalConsultationCompleteRate = d.ActivateHistoricalConsultationCompleteRate,
                                                        SendOrderTarget = d.SendOrderTarget,
                                                        CumulativeSendOrder = d.CumulativeSendOrder,
                                                        SendOrderCompleteRate = d.SendOrderCompleteRate,
                                                        NewCustomerVisitTarget = d.NewCustomerVisitTarget,
                                                        CumulativeNewCustomerVisit = d.CumulativeNewCustomerVisit,
                                                        NewCustomerVisitCompleteRate = d.NewCustomerVisitCompleteRate,
                                                        OldCustomerVisitTarget = d.OldCustomerVisitTarget,
                                                        CumulativeOldCustomerVisit = d.CumulativeOldCustomerVisit,
                                                        OldCustomerVisitCompleteRate = d.OldCustomerVisitCompleteRate,
                                                        VisitTarget = d.VisitTarget,
                                                        CumulativeVisit = d.CumulativeVisit,
                                                        VisitCompleteRate = d.VisitCompleteRate,
                                                        NewCustomerDealTarget = d.NewCustomerDealTarget,
                                                        CumulativeNewCustomerDealTarget = d.CumulativeNewCustomerDealTarget,
                                                        NewCustomerDealRate = d.NewCustomerDealRate,
                                                        OldCustomerDealTarget = d.OldCustomerDealTarget,
                                                        CumulativeOldCustomerDealTarget = d.CumulativeOldCustomerDealTarget,
                                                        OldCustomerDealRate = d.OldCustomerDealRate,
                                                        DealTarget = d.DealTarget,
                                                        CumulativeDealTarget = d.CumulativeDealTarget,
                                                        DealRate = d.DealRate,
                                                        PerformanceTarget = d.PerformanceTarget,
                                                        CumulativePerformance = d.CumulativePerformance,
                                                        PerformanceCompleteRate = d.PerformanceCompleteRate,
                                                        NewCustomerPerformanceTarget = d.NewCustomerPerformanceTarget,
                                                        NewCustomerPerformanceCompleteRate = d.NewCustomerPerformanceCompleteRate,
                                                        CumulativeNewCustomerPerformance = d.CumulativeNewCustomerPerformance,
                                                        OldCustomerPerformanceTarget = d.OldCustomerPerformanceTarget,
                                                        OldCustomerPerformanceCompleteRate = d.OldCustomerPerformanceCompleteRate,
                                                        CumulativeOldCustomerPerformance = d.CumulativeOldCustomerPerformance,
                                                        SubsequentPerformanceCompleteRate = d.SubsequentPerformanceCompleteRate,
                                                        SubsequentPerformanceTarget = d.SubsequentPerformanceTarget,
                                                        CumulativeSubsequentPerformance = d.CumulativeSubsequentPerformance,
                                                        MinivanRefundTarget = d.MinivanRefundTarget,
                                                        CumulativeMinivanRefund = d.CumulativeMinivanRefund,
                                                        MinivanRefundCompleteRate = d.MinivanRefundCompleteRate,
                                                        MiniVanBadReviewsTarget = d.MiniVanBadReviewsTarget,
                                                        CumulativeMiniVanBadReviews = d.CumulativeMiniVanBadReviews,
                                                        MiniVanBadReviewsCompleteRate = d.MiniVanBadReviewsCompleteRate,
                                                        CreateDate = d.CreateDate,
                                                        EffectivePerformanceTarget = d.EffectivePerformanceTarget,
                                                        CumulativeEffectivePerformance=d.CumulativeEffectivePerformance,
                                                        EffectivePerformanceCompleteRate=d.EffectivePerformanceCompleteRate,
                                                        PotentialPerformanceTarget = d.PotentialPerformanceTarget,
                                                        CumulativePotentialPerformance=d.CumulativePotentialPerformance,
                                                        PotentialPerformanceCompleteRate=d.PotentialPerformanceCompleteRate,
                                                        DistributeConsulationTarget=d.DistributeConsulationTarget,
                                                        DistributeConsulationCompleteRate=d.DistributeConsulationCompleteRate,
                                                        CumulativeDistributeConsulation=d.CumulativeDistributeConsulation,
                                                        CluesTarget=d.CluesTarget,
                                                        CumulativeClues=d.CumulativeClues,
                                                        CluesCompleteRate=d.CluesCompleteRate
                                                    };

                FxPageInfo<LiveAnchorMonthlyTargetAfterLivingVo> liveAnchorMonthlyTargetAfterLivingPageInfo = new FxPageInfo<LiveAnchorMonthlyTargetAfterLivingVo>();
                liveAnchorMonthlyTargetAfterLivingPageInfo.TotalCount = q.TotalCount;
                liveAnchorMonthlyTargetAfterLivingPageInfo.List = liveAnchorMonthlyTargetAfterLiving;

                return ResultData<FxPageInfo<LiveAnchorMonthlyTargetAfterLivingVo>>.Success().AddData("liveAnchorMonthlyTargetAfterLivingInfo", liveAnchorMonthlyTargetAfterLivingPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<LiveAnchorMonthlyTargetAfterLivingVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据年月获取id和名称（下拉框使用）
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        [HttpGet("getLiveAnchorMonthlyTargetAfterLiving")]
        public async Task<ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>> getExpressList(int year, int month)
        {
            try
            {
                if (year == 0 || month == 0)
                {
                    throw new Exception("请选择年月后再进行月目标选取！");
                }
                var q = await _liveAnchorMonthlyTargetAfterLivingService.GetIdAndNames(year, month);

                var liveAnchorMonthlyTargetAfterLiving = from d in q
                                                    select new LiveAnchorMonthlyTargetKeyAndValueVo
                                                    {
                                                        Id = d.Id,
                                                        Name = d.Name
                                                    };

                return ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>.Success().AddData("liveAnchorMonthlyTargetAfterLiving", liveAnchorMonthlyTargetAfterLiving.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>.Fail().AddData("liveAnchorMonthlyTargetAfterLiving", new List<LiveAnchorMonthlyTargetKeyAndValueVo>());
            }
        }


        /// <summary>
        /// 添加直播后主播月度运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddLiveAnchorMonthlyTargetAfterLivingVo addVo)
        {
            try
            {
                AddLiveAnchorMonthlyTargetAfterLivingDto addDto = new AddLiveAnchorMonthlyTargetAfterLivingDto();
                addDto.Year = addVo.Year;
                addDto.Month = addVo.Month;
                addDto.MonthlyTargetName = addVo.MonthlyTargetName;
                addDto.LiveAnchorId = addVo.LiveAnchorId;

                addDto.AddWechatTarget = addVo.AddWechatTarget;
                addDto.ConsultationCardConsumedTarget = addVo.ConsultationCardConsumedTarget;
                addDto.ConsultationCardConsumedTarget2 = addVo.ConsultationCardConsumedTarget2;
                addDto.ActivateHistoricalConsultationTarget = addVo.ActivateHistoricalConsultationTarget;
                addDto.SendOrderTarget = addVo.SendOrderTarget;
                addDto.NewCustomerVisitTarget = addVo.NewCustomerVisitTarget;
                addDto.OldCustomerVisitTarget = addVo.OldCustomerVisitTarget;
                addDto.VisitTarget = addVo.VisitTarget;
                addDto.NewCustomerDealTarget = addVo.NewCustomerDealTarget;
                addDto.OldCustomerDealTarget = addVo.OldCustomerDealTarget;
                addDto.DealTarget = addVo.DealTarget;
                addDto.NewCustomerPerformanceTarget = addVo.NewCustomerPerformanceTarget;
                addDto.SubsequentPerformanceTarget = addVo.SubsequentPerformanceTarget;
                addDto.OldCustomerPerformanceTarget = addVo.OldCustomerPerformanceTarget;
                addDto.PerformanceTarget = addVo.PerformanceTarget;
                addDto.MiniVanBadReviewsTarget = addVo.MiniVanBadReviewsTarget;
                addDto.MinivanRefundTarget = addVo.MinivanRefundTarget;
                addDto.EffectivePerformanceTarget = addVo.EffectivePerformanceTarget;
                addDto.PotentialPerformanceTarget = addVo.PotentialPerformanceTarget;
                addDto.DistributeConsulationTarget = addVo.DistributeConsulationTarget;
                addDto.CluesTarget= addVo.CluesTarget;
                await _liveAnchorMonthlyTargetAfterLivingService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据id获取直播后主播月度运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<LiveAnchorMonthlyTargetAfterLivingVo>> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorMonthlyTarget = await _liveAnchorMonthlyTargetAfterLivingService.GetByIdAsync(id);
                LiveAnchorMonthlyTargetAfterLivingVo liveAnchorMonthlyTargetVo = new LiveAnchorMonthlyTargetAfterLivingVo();
                liveAnchorMonthlyTargetVo.Id = liveAnchorMonthlyTarget.Id;
                liveAnchorMonthlyTargetVo.Year = liveAnchorMonthlyTarget.Year;
                liveAnchorMonthlyTargetVo.Month = liveAnchorMonthlyTarget.Month;
                liveAnchorMonthlyTargetVo.MonthlyTargetName = liveAnchorMonthlyTarget.MonthlyTargetName;
                liveAnchorMonthlyTargetVo.LiveAnchorId = liveAnchorMonthlyTarget.LiveAnchorId;
                liveAnchorMonthlyTargetVo.ContentPlatFormId = liveAnchorMonthlyTarget.ContentPlatFormId;

                liveAnchorMonthlyTargetVo.AddWechatTarget = liveAnchorMonthlyTarget.AddWechatTarget;
                liveAnchorMonthlyTargetVo.CumulativeAddWechat = liveAnchorMonthlyTarget.CumulativeAddWechat;
                liveAnchorMonthlyTargetVo.AddWechatCompleteRate = liveAnchorMonthlyTarget.AddWechatCompleteRate;
                liveAnchorMonthlyTargetVo.ConsultationCardConsumedTarget = liveAnchorMonthlyTarget.ConsultationCardConsumedTarget;
                liveAnchorMonthlyTargetVo.CumulativeConsultationCardConsumed = liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed;
                liveAnchorMonthlyTargetVo.ConsultationCardConsumedCompleteRate = liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate;
                liveAnchorMonthlyTargetVo.ConsultationCardConsumedTarget2 = liveAnchorMonthlyTarget.ConsultationCardConsumedTarget2;
                liveAnchorMonthlyTargetVo.CumulativeConsultationCardConsumed2 = liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2;
                liveAnchorMonthlyTargetVo.ConsultationCardConsumedCompleteRate2 = liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate2;
                liveAnchorMonthlyTargetVo.ActivateHistoricalConsultationTarget = liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget;
                liveAnchorMonthlyTargetVo.CumulativeActivateHistoricalConsultation = liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation;
                liveAnchorMonthlyTargetVo.ActivateHistoricalConsultationCompleteRate = liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate;
                liveAnchorMonthlyTargetVo.SendOrderTarget = liveAnchorMonthlyTarget.SendOrderTarget;
                liveAnchorMonthlyTargetVo.CumulativeSendOrder = liveAnchorMonthlyTarget.CumulativeSendOrder;
                liveAnchorMonthlyTargetVo.SendOrderCompleteRate = liveAnchorMonthlyTarget.SendOrderCompleteRate;

                liveAnchorMonthlyTargetVo.NewCustomerVisitTarget = liveAnchorMonthlyTarget.NewCustomerVisitTarget;
                liveAnchorMonthlyTargetVo.CumulativeNewCustomerVisit = liveAnchorMonthlyTarget.CumulativeNewCustomerVisit;
                liveAnchorMonthlyTargetVo.NewCustomerVisitCompleteRate = liveAnchorMonthlyTarget.NewCustomerVisitCompleteRate;

                liveAnchorMonthlyTargetVo.OldCustomerVisitTarget = liveAnchorMonthlyTarget.OldCustomerVisitTarget;
                liveAnchorMonthlyTargetVo.CumulativeOldCustomerVisit = liveAnchorMonthlyTarget.CumulativeOldCustomerVisit;
                liveAnchorMonthlyTargetVo.OldCustomerVisitCompleteRate = liveAnchorMonthlyTarget.OldCustomerVisitCompleteRate;

                liveAnchorMonthlyTargetVo.VisitTarget = liveAnchorMonthlyTarget.VisitTarget;
                liveAnchorMonthlyTargetVo.CumulativeVisit = liveAnchorMonthlyTarget.CumulativeVisit;
                liveAnchorMonthlyTargetVo.VisitCompleteRate = liveAnchorMonthlyTarget.VisitCompleteRate;

                liveAnchorMonthlyTargetVo.NewCustomerDealTarget = liveAnchorMonthlyTarget.NewCustomerDealTarget;
                liveAnchorMonthlyTargetVo.CumulativeNewCustomerDealTarget = liveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget;
                liveAnchorMonthlyTargetVo.NewCustomerDealRate = liveAnchorMonthlyTarget.NewCustomerDealRate;

                liveAnchorMonthlyTargetVo.OldCustomerDealTarget = liveAnchorMonthlyTarget.OldCustomerDealTarget;
                liveAnchorMonthlyTargetVo.CumulativeOldCustomerDealTarget = liveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget;
                liveAnchorMonthlyTargetVo.OldCustomerDealRate = liveAnchorMonthlyTarget.OldCustomerDealRate;

                liveAnchorMonthlyTargetVo.DealTarget = liveAnchorMonthlyTarget.DealTarget;
                liveAnchorMonthlyTargetVo.CumulativeDealTarget = liveAnchorMonthlyTarget.CumulativeDealTarget;
                liveAnchorMonthlyTargetVo.DealRate = liveAnchorMonthlyTarget.DealRate;


                liveAnchorMonthlyTargetVo.NewCustomerPerformanceTarget = liveAnchorMonthlyTarget.NewCustomerPerformanceTarget;
                liveAnchorMonthlyTargetVo.CumulativeNewCustomerPerformance = liveAnchorMonthlyTarget.CumulativeNewCustomerPerformance;
                liveAnchorMonthlyTargetVo.NewCustomerPerformanceCompleteRate = liveAnchorMonthlyTarget.NewCustomerPerformanceCompleteRate;

                liveAnchorMonthlyTargetVo.SubsequentPerformanceTarget = liveAnchorMonthlyTarget.SubsequentPerformanceTarget;
                liveAnchorMonthlyTargetVo.CumulativeSubsequentPerformance = liveAnchorMonthlyTarget.CumulativeSubsequentPerformance;
                liveAnchorMonthlyTargetVo.SubsequentPerformanceCompleteRate = liveAnchorMonthlyTarget.SubsequentPerformanceCompleteRate;

                liveAnchorMonthlyTargetVo.OldCustomerPerformanceTarget = liveAnchorMonthlyTarget.OldCustomerPerformanceTarget;
                liveAnchorMonthlyTargetVo.CumulativeOldCustomerPerformance = liveAnchorMonthlyTarget.CumulativeOldCustomerPerformance;
                liveAnchorMonthlyTargetVo.OldCustomerPerformanceCompleteRate = liveAnchorMonthlyTarget.OldCustomerPerformanceCompleteRate;

                liveAnchorMonthlyTargetVo.PerformanceTarget = liveAnchorMonthlyTarget.PerformanceTarget;
                liveAnchorMonthlyTargetVo.CumulativePerformance = liveAnchorMonthlyTarget.CumulativePerformance;
                liveAnchorMonthlyTargetVo.PerformanceCompleteRate = liveAnchorMonthlyTarget.PerformanceCompleteRate;
                liveAnchorMonthlyTargetVo.MinivanRefundTarget = liveAnchorMonthlyTarget.MinivanRefundTarget;
                liveAnchorMonthlyTargetVo.CumulativeMinivanRefund = liveAnchorMonthlyTarget.CumulativeMinivanRefund;
                liveAnchorMonthlyTargetVo.MinivanRefundCompleteRate = liveAnchorMonthlyTarget.MinivanRefundCompleteRate;
                liveAnchorMonthlyTargetVo.MiniVanBadReviewsTarget = liveAnchorMonthlyTarget.MiniVanBadReviewsTarget;
                liveAnchorMonthlyTargetVo.CumulativeMiniVanBadReviews = liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews;
                liveAnchorMonthlyTargetVo.MiniVanBadReviewsCompleteRate = liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate;
                liveAnchorMonthlyTargetVo.CreateDate = liveAnchorMonthlyTarget.CreateDate;

                liveAnchorMonthlyTargetVo.EffectivePerformanceTarget = liveAnchorMonthlyTarget.EffectivePerformanceTarget;
                liveAnchorMonthlyTargetVo.CumulativeEffectivePerformance = liveAnchorMonthlyTarget.CumulativeEffectivePerformance;
                liveAnchorMonthlyTargetVo.EffectivePerformanceCompleteRate = liveAnchorMonthlyTarget.EffectivePerformanceCompleteRate;
                
                liveAnchorMonthlyTargetVo.PotentialPerformanceTarget = liveAnchorMonthlyTarget.PotentialPerformanceTarget;
                liveAnchorMonthlyTargetVo.CumulativePotentialPerformance = liveAnchorMonthlyTarget.CumulativePotentialPerformance;
                liveAnchorMonthlyTargetVo.PotentialPerformanceCompleteRate = liveAnchorMonthlyTarget.PotentialPerformanceCompleteRate;

                liveAnchorMonthlyTargetVo.DistributeConsulationTarget = liveAnchorMonthlyTarget.DistributeConsulationTarget;
                liveAnchorMonthlyTargetVo.CumulativeDistributeConsulation = liveAnchorMonthlyTarget.CumulativeDistributeConsulation;
                liveAnchorMonthlyTargetVo.DistributeConsulationCompleteRate = liveAnchorMonthlyTarget.DistributeConsulationCompleteRate;

                liveAnchorMonthlyTargetVo.CluesTarget=liveAnchorMonthlyTarget.CluesTarget;
                liveAnchorMonthlyTargetVo.CumulativeClues = liveAnchorMonthlyTarget.CumulativeClues;
                liveAnchorMonthlyTargetVo.CluesCompleteRate = liveAnchorMonthlyTarget.CluesCompleteRate;

                return ResultData<LiveAnchorMonthlyTargetAfterLivingVo>.Success().AddData("liveAnchorMonthlyTargetAfterLivingInfo", liveAnchorMonthlyTargetVo);
            }
            catch (Exception ex)
            {
                return ResultData<LiveAnchorMonthlyTargetAfterLivingVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改直播后主播月度运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateLiveAnchorMonthlyTargetAfterLivingVo updateVo)
        {
            try
            {
                UpdateLiveAnchorMonthlyTargetAfterLivingDto updateDto = new UpdateLiveAnchorMonthlyTargetAfterLivingDto();
                updateDto.Id = updateVo.Id;
                updateDto.Year = updateVo.Year;
                updateDto.Month = updateVo.Month;
                updateDto.MonthlyTargetName = updateVo.MonthlyTargetName;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;

                updateDto.AddWechatTarget = updateVo.AddWechatTarget;
                updateDto.ConsultationCardConsumedTarget = updateVo.ConsultationCardConsumedTarget;
                updateDto.ConsultationCardConsumedTarget2 = updateVo.ConsultationCardConsumedTarget2;
                updateDto.ActivateHistoricalConsultationTarget = updateVo.ActivateHistoricalConsultationTarget;
                updateDto.SendOrderTarget = updateVo.SendOrderTarget;
                updateDto.NewCustomerVisitTarget = updateVo.NewCustomerVisitTarget;
                updateDto.OldCustomerVisitTarget = updateVo.OldCustomerVisitTarget;
                updateDto.VisitTarget = updateVo.VisitTarget;
                updateDto.NewCustomerDealTarget = updateVo.NewCustomerDealTarget;
                updateDto.OldCustomerDealTarget = updateVo.OldCustomerDealTarget;
                updateDto.DealTarget = updateVo.DealTarget;
                updateDto.NewCustomerPerformanceTarget = updateVo.NewCustomerPerformanceTarget;
                updateDto.SubsequentPerformanceTarget = updateVo.SubsequentPerformanceTarget;
                updateDto.OldCustomerPerformanceTarget = updateVo.OldCustomerPerformanceTarget;
                updateDto.PerformanceTarget = updateVo.PerformanceTarget;
                updateDto.MinivanRefundTarget = updateVo.MinivanRefundTarget;
                updateDto.MiniVanBadReviewsTarget = updateVo.MiniVanBadReviewsTarget;
                updateDto.EffectivePerformanceTarget = updateVo.EffectivePerformanceTarget;
                updateDto.PotentialPerformanceTarget = updateVo.PotentialPerformanceTarget;
                updateDto.DistributeConsulationTarget=updateVo.DistributeConsulationTarget;
                updateDto.CluesTarget=updateVo.CluesTarget;
                await _liveAnchorMonthlyTargetAfterLivingService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除直播后主播月度运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _liveAnchorMonthlyTargetAfterLivingService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                throw new Exception("该条数据下已产生相应的日数据，请先删除日数据后再删除该条数据！");
            }
        }

    }
}
