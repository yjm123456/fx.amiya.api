using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget;
using Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget.Living;
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
    /// 直播中主播月度运营目标情况数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveAnchorMonthlyTargetLivingController : ControllerBase
    {
        private ILiveAnchorMonthlyTargetLivingService _liveAnchorMonthlyTargetLivingService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LiveAnchorMonthlyTargetLivingController(ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService,
            IHttpContextAccessor httpContextAccessor)
        {
            _liveAnchorMonthlyTargetLivingService = liveAnchorMonthlyTargetLivingService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取直播中主播月度运营目标情况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<LiveAnchorMonthlyTargetLivingVo>>> GetListWithPageAsync(int year, int month, int? liveAnchorId, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await _liveAnchorMonthlyTargetLivingService.GetListWithPageAsync(year, month, liveAnchorId, employeeId, pageNum, pageSize);

                var liveAnchorMonthlyTargetLiving = from d in q.List
                                                    select new LiveAnchorMonthlyTargetLivingVo
                                                    {
                                                        Id = d.Id,
                                                        Year = d.Year,
                                                        Month = d.Month,
                                                        MonthlyTargetName = d.MonthlyTargetName,
                                                        LiveAnchorId = d.LiveAnchorId,
                                                        ContentPlatFormId = d.ContentPlatFormId,
                                                        LiveAnchorName = d.LiveAnchorName,
                                                        LivingRoomCumulativeFlowInvestment = d.LivingRoomCumulativeFlowInvestment,
                                                        LivingRoomFlowInvestmentTarget = d.LivingRoomFlowInvestmentTarget,
                                                        LivingRoomFlowInvestmentCompleteRate = d.LivingRoomFlowInvestmentCompleteRate,
                                                        ConsultationTarget = d.ConsultationTarget,
                                                        CumulativeConsultation = d.CumulativeConsultation,
                                                        ConsultationCompleteRate = d.ConsultationCompleteRate,
                                                        ConsultationTarget2 = d.ConsultationTarget2,
                                                        CumulativeConsultation2 = d.CumulativeConsultation2,
                                                        ConsultationCompleteRate2 = d.ConsultationCompleteRate2,
                                                        CargoSettlementCommissionTarget = d.CargoSettlementCommissionTarget,
                                                        CumulativeCargoSettlementCommission = d.CumulativeCargoSettlementCommission,
                                                        CargoSettlementCommissionCompleteRate = d.CargoSettlementCommissionCompleteRate,
                                                        CreateDate = d.CreateDate,
                                                    };

                FxPageInfo<LiveAnchorMonthlyTargetLivingVo> liveAnchorMonthlyTargetLivingPageInfo = new FxPageInfo<LiveAnchorMonthlyTargetLivingVo>();
                liveAnchorMonthlyTargetLivingPageInfo.TotalCount = q.TotalCount;
                liveAnchorMonthlyTargetLivingPageInfo.List = liveAnchorMonthlyTargetLiving;

                return ResultData<FxPageInfo<LiveAnchorMonthlyTargetLivingVo>>.Success().AddData("liveAnchorMonthlyTargetLivingInfo", liveAnchorMonthlyTargetLivingPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<LiveAnchorMonthlyTargetLivingVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据年月获取id和名称（下拉框使用）
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        [HttpGet("getLiveAnchorMonthlyTargetLiving")]
        public async Task<ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>> getExpressList(int year, int month)
        {
            try
            {
                if (year == 0 || month == 0)
                {
                    throw new Exception("请选择年月后再进行月目标选取！");
                }
                var q = await _liveAnchorMonthlyTargetLivingService.GetIdAndNames(year, month);

                var liveAnchorMonthlyTargetLiving = from d in q
                                                    select new LiveAnchorMonthlyTargetKeyAndValueVo
                                                    {
                                                        Id = d.Id,
                                                        Name = d.Name
                                                    };

                return ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>.Success().AddData("liveAnchorMonthlyTargetLiving", liveAnchorMonthlyTargetLiving.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>.Fail().AddData("liveAnchorMonthlyTargetLiving", new List<LiveAnchorMonthlyTargetKeyAndValueVo>());
            }
        }


        /// <summary>
        /// 添加直播中主播月度运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddLiveAnchorMonthlyTargetLivingVo addVo)
        {
            try
            {
                AddLiveAnchorMonthlyTargetLivingDto addDto = new AddLiveAnchorMonthlyTargetLivingDto();
                addDto.Year = addVo.Year;
                addDto.Month = addVo.Month;
                addDto.MonthlyTargetName = addVo.MonthlyTargetName;
                addDto.LiveAnchorId = addVo.LiveAnchorId;
                addDto.LivingRoomFlowInvestmentTarget = addVo.LivingRoomFlowInvestmentTarget;
                addDto.ConsultationTarget = addVo.ConsultationTarget;
                addDto.ConsultationTarget2 = addVo.ConsultationTarget2;
                addDto.CargoSettlementCommissionTarget = addVo.CargoSettlementCommissionTarget;

                await _liveAnchorMonthlyTargetLivingService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据id获取直播中主播月度运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<LiveAnchorMonthlyTargetLivingVo>> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorMonthlyTarget = await _liveAnchorMonthlyTargetLivingService.GetByIdAsync(id);
                LiveAnchorMonthlyTargetLivingVo liveAnchorMonthlyTargetVo = new LiveAnchorMonthlyTargetLivingVo();
                liveAnchorMonthlyTargetVo.Id = liveAnchorMonthlyTarget.Id;
                liveAnchorMonthlyTargetVo.Year = liveAnchorMonthlyTarget.Year;
                liveAnchorMonthlyTargetVo.Month = liveAnchorMonthlyTarget.Month;
                liveAnchorMonthlyTargetVo.MonthlyTargetName = liveAnchorMonthlyTarget.MonthlyTargetName;
                liveAnchorMonthlyTargetVo.LiveAnchorId = liveAnchorMonthlyTarget.LiveAnchorId;
                liveAnchorMonthlyTargetVo.ContentPlatFormId = liveAnchorMonthlyTarget.ContentPlatFormId;
                liveAnchorMonthlyTargetVo.LivingRoomFlowInvestmentTarget = liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget;
                liveAnchorMonthlyTargetVo.LivingRoomCumulativeFlowInvestment = liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment;
                liveAnchorMonthlyTargetVo.LivingRoomFlowInvestmentCompleteRate = liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate;
                liveAnchorMonthlyTargetVo.ConsultationTarget = liveAnchorMonthlyTarget.ConsultationTarget;
                liveAnchorMonthlyTargetVo.CumulativeConsultation = liveAnchorMonthlyTarget.CumulativeConsultation;
                liveAnchorMonthlyTargetVo.ConsultationCompleteRate = liveAnchorMonthlyTarget.ConsultationCompleteRate;
                liveAnchorMonthlyTargetVo.ConsultationTarget2 = liveAnchorMonthlyTarget.ConsultationTarget2;
                liveAnchorMonthlyTargetVo.CumulativeConsultation2 = liveAnchorMonthlyTarget.CumulativeConsultation2;
                liveAnchorMonthlyTargetVo.ConsultationCompleteRate2 = liveAnchorMonthlyTarget.ConsultationCompleteRate2;

                liveAnchorMonthlyTargetVo.CargoSettlementCommissionTarget = liveAnchorMonthlyTarget.CargoSettlementCommissionTarget;
                liveAnchorMonthlyTargetVo.CumulativeCargoSettlementCommission = liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission;
                liveAnchorMonthlyTargetVo.CargoSettlementCommissionCompleteRate = liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate;

                liveAnchorMonthlyTargetVo.CreateDate = liveAnchorMonthlyTarget.CreateDate;

                return ResultData<LiveAnchorMonthlyTargetLivingVo>.Success().AddData("liveAnchorMonthlyTargetLivingInfo", liveAnchorMonthlyTargetVo);
            }
            catch (Exception ex)
            {
                return ResultData<LiveAnchorMonthlyTargetLivingVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改直播中主播月度运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateLiveAnchorMonthlyTargetLivingVo updateVo)
        {
            try
            {
                UpdateLiveAnchorMonthlyTargetLivingDto updateDto = new UpdateLiveAnchorMonthlyTargetLivingDto();
                updateDto.Id = updateVo.Id;
                updateDto.Year = updateVo.Year;
                updateDto.Month = updateVo.Month;
                updateDto.MonthlyTargetName = updateVo.MonthlyTargetName;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;
                updateDto.LivingRoomFlowInvestmentTarget = updateVo.LivingRoomFlowInvestmentTarget;
                updateDto.ConsultationTarget = updateVo.ConsultationTarget;
                updateDto.ConsultationTarget2 = updateVo.ConsultationTarget2;
                updateDto.CargoSettlementCommissionTarget = updateVo.CargoSettlementCommissionTarget;
                await _liveAnchorMonthlyTargetLivingService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除直播中主播月度运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _liveAnchorMonthlyTargetLivingService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                throw new Exception("该条数据下已产生相应的日数据，请先删除日数据后再删除该条数据！");
            }
        }

    }
}
