using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.LiveAnchorDailyTarget;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Amiya.Dto.LiveAnchorDailyTarget;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 主播日运营目标情况数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveAnchorDailyTargetController : ControllerBase
    {
        private ILiveAnchorDailyTargetService _liveAnchorDailyTargetService;
        private IOrderService _orderService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LiveAnchorDailyTargetController(ILiveAnchorDailyTargetService liveAnchorDailyTargetService)
        {
            _liveAnchorDailyTargetService = liveAnchorDailyTargetService;
        }

        /// <summary>
        /// 获取主播日运营目标情况
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="operationEmpId">运营人员id</param>
        /// <param name="netWorkConEmpId">网咨人员id</param>
        /// <param name="liveAnchorId">主播ip账户id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<LiveAnchorDailyTargetVo>>> GetListWithPageAsync(DateTime startDate, DateTime endDate, int? operationEmpId, int? netWorkConEmpId, int? liveAnchorId, int pageNum, int pageSize)
        {
            try
            {
                var q = await _liveAnchorDailyTargetService.GetListWithPageAsync(startDate, endDate, operationEmpId, netWorkConEmpId, liveAnchorId, pageNum, pageSize);

                var liveAnchorDailyTarget = from d in q.List
                                            select new LiveAnchorDailyTargetVo
                                            {
                                                Id = d.Id,
                                                LiveAnchor = d.LiveAnchor,
                                                CreateDate = d.CreateDate,
                                                RecordDate = d.RecordDate,
                                                TodaySendNum = d.TodaySendNum,
                                                FlowInvestmentNum = d.FlowInvestmentNum,
                                                LivingRoomFlowInvestmentNum = d.LivingRoomFlowInvestmentNum,
                                                CluesNum = d.CluesNum,
                                                AddFansNum = d.AddFansNum,
                                                AddWechatNum = d.AddWechatNum,
                                                Consultation = d.Consultation,
                                                ConsultationCardConsumed = d.ConsultationCardConsumed,
                                                Consultation2 = d.Consultation2,
                                                ConsultationCardConsumed2 = d.ConsultationCardConsumed2,
                                                ActivateHistoricalConsultation = d.ActivateHistoricalConsultation,
                                                SendOrderNum = d.SendOrderNum,
                                                NewVisitNum = d.NewVisitNum,
                                                SubsequentVisitNum = d.SubsequentVisitNum,
                                                OldCustomerVisitNum = d.OldCustomerVisitNum,
                                                VisitNum = d.VisitNum,
                                                NewDealNum = d.NewDealNum,
                                                SubsequentDealNum = d.SubsequentDealNum,
                                                OldCustomerDealNum = d.OldCustomerDealNum,
                                                DealNum = d.DealNum,
                                                CargoSettlementCommission = d.CargoSettlementCommission,
                                                NewPerformanceNum = d.NewPerformanceNum,
                                                SubsequentPerformanceNum = d.SubsequentPerformanceNum,
                                                OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                                                NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                                                PerformanceNum = d.PerformanceNum,
                                                OperationEmployeeName = d.OperationEmployeeName,
                                                MinivanRefund = d.MinivanRefund,
                                                MiniVanBadReviews = d.MiniVanBadReviews,
                                                NetWorkConsultingEmployeeName = d.NetWorkConsultingEmployeeName,
                                                LivingTrackingEmployeeName = d.LivingTrackingEmployeeName
                                            };

                FxPageInfo<LiveAnchorDailyTargetVo> liveAnchorDailyTargetPageInfo = new FxPageInfo<LiveAnchorDailyTargetVo>();
                liveAnchorDailyTargetPageInfo.TotalCount = q.TotalCount;
                liveAnchorDailyTargetPageInfo.List = liveAnchorDailyTarget;

                return ResultData<FxPageInfo<LiveAnchorDailyTargetVo>>.Success().AddData("liveAnchorDailyTargetInfo", liveAnchorDailyTargetPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<LiveAnchorDailyTargetVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加主播日运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddLiveAnchorDailyTargetVo addVo)
        {
            try
            {
                var selectResult = await _liveAnchorDailyTargetService.GetLiveAnchorInfoByMonthlyTargetIdAndDate(addVo.LiveanchorMonthlyTargetId, addVo.RecordDate);
                if (selectResult != null)
                {
                    UpdateLiveAnchorDailyTargetDto updateDto = new UpdateLiveAnchorDailyTargetDto();
                    updateDto.Id = selectResult.Id;
                    updateDto.LiveanchorMonthlyTargetId = selectResult.LiveanchorMonthlyTargetId;
                    updateDto.OperationEmployeeId = selectResult.OperationEmployeeId;
                    updateDto.LivingTrackingEmployeeId = selectResult.LivingTrackingEmployeeId;
                    updateDto.NetWorkConsultingEmployeeId = selectResult.NetWorkConsultingEmployeeId;
                    updateDto.TodaySendNum = selectResult.TodaySendNum;
                    updateDto.LivingRoomFlowInvestmentNum = selectResult.LivingRoomFlowInvestmentNum;
                    updateDto.FlowInvestmentNum = selectResult.FlowInvestmentNum;
                    updateDto.CluesNum = selectResult.CluesNum;
                    updateDto.AddFansNum = selectResult.AddFansNum;
                    updateDto.AddWechatNum = selectResult.AddWechatNum;
                    updateDto.Consultation = selectResult.Consultation;
                    updateDto.ConsultationCardConsumed = selectResult.ConsultationCardConsumed;
                    updateDto.Consultation2 = selectResult.Consultation2;
                    updateDto.ConsultationCardConsumed2 = selectResult.ConsultationCardConsumed2;
                    updateDto.ActivateHistoricalConsultation = selectResult.ActivateHistoricalConsultation;
                    updateDto.SendOrderNum = selectResult.SendOrderNum;
                    updateDto.NewVisitNum = selectResult.NewVisitNum;
                    updateDto.SubsequentVisitNum = selectResult.SubsequentVisitNum;
                    updateDto.OldCustomerVisitNum = selectResult.OldCustomerVisitNum;
                    updateDto.VisitNum = selectResult.VisitNum;
                    updateDto.NewDealNum = selectResult.NewDealNum;
                    updateDto.SubsequentDealNum = selectResult.SubsequentDealNum;
                    updateDto.OldCustomerDealNum = selectResult.OldCustomerDealNum;
                    updateDto.DealNum = selectResult.DealNum;
                    updateDto.CargoSettlementCommission = selectResult.CargoSettlementCommission;
                    updateDto.NewPerformanceNum = selectResult.NewPerformanceNum;
                    updateDto.SubsequentPerformanceNum = selectResult.SubsequentPerformanceNum;
                    updateDto.OldCustomerPerformanceNum = selectResult.OldCustomerPerformanceNum;
                    updateDto.NewCustomerPerformanceCountNum = selectResult.NewCustomerPerformanceCountNum;
                    updateDto.PerformanceNum = selectResult.PerformanceNum;
                    updateDto.MinivanRefund = selectResult.MinivanRefund;
                    updateDto.MiniVanBadReviews = selectResult.MiniVanBadReviews;
                    updateDto.RecordDate = selectResult.RecordDate;
                    if (addVo.OperationEmployeeId != 0)
                    {
                        updateDto.TodaySendNum = addVo.TodaySendNum;
                        updateDto.FlowInvestmentNum = addVo.FlowInvestmentNum;
                        updateDto.CluesNum = addVo.CluesNum;
                        updateDto.AddFansNum = addVo.AddFansNum;
                        updateDto.OperationEmployeeId = addVo.OperationEmployeeId;
                    }
                    if (addVo.LivingTrackingEmployeeId != 0)
                    {
                        updateDto.LivingRoomFlowInvestmentNum = addVo.LivingRoomFlowInvestmentNum;
                        updateDto.Consultation = addVo.Consultation;
                        updateDto.Consultation2 = selectResult.Consultation2;
                        updateDto.CargoSettlementCommission = addVo.CargoSettlementCommission;
                        updateDto.LivingTrackingEmployeeId = addVo.LivingTrackingEmployeeId;
                    }
                    if (addVo.NetWorkConsultingEmployeeId != 0)
                    {
                        updateDto.AddWechatNum = addVo.AddWechatNum;
                        updateDto.ConsultationCardConsumed = addVo.ConsultationCardConsumed;
                        updateDto.ConsultationCardConsumed2 = selectResult.ConsultationCardConsumed2;
                        updateDto.ActivateHistoricalConsultation = addVo.ActivateHistoricalConsultation;
                        updateDto.SendOrderNum = addVo.SendOrderNum.HasValue ? addVo.SendOrderNum.Value : 0;
                        updateDto.NewVisitNum = addVo.NewVisitNum.HasValue ? addVo.NewVisitNum.Value : 0;
                        updateDto.SubsequentVisitNum = addVo.SubsequentVisitNum.HasValue ? addVo.SubsequentVisitNum.Value : 0;
                        updateDto.OldCustomerVisitNum = addVo.OldCustomerVisitNum.HasValue ? addVo.OldCustomerVisitNum.Value : 0;
                        updateDto.VisitNum = addVo.VisitNum.HasValue ? addVo.VisitNum.Value : 0;
                        updateDto.NewDealNum = addVo.NewDealNum.HasValue ? addVo.NewDealNum.Value : 0;
                        updateDto.SubsequentDealNum = addVo.SubsequentDealNum.HasValue ? addVo.SubsequentDealNum.Value : 0;
                        updateDto.OldCustomerDealNum = addVo.OldCustomerDealNum.HasValue ? addVo.OldCustomerDealNum.Value : 0;
                        updateDto.DealNum = addVo.DealNum.HasValue ? addVo.DealNum.Value : 0;
                        updateDto.NewPerformanceNum = addVo.NewPerformanceNum.HasValue ? addVo.NewPerformanceNum.Value : 0;
                        updateDto.SubsequentPerformanceNum = addVo.SubsequentPerformanceNum.HasValue ? addVo.SubsequentPerformanceNum.Value : 0;
                        updateDto.NewCustomerPerformanceCountNum = addVo.NewCustomerPerformanceCountNum.HasValue ? addVo.NewCustomerPerformanceCountNum.Value : 0;
                        updateDto.OldCustomerPerformanceNum = addVo.OldCustomerPerformanceNum.HasValue ? addVo.OldCustomerPerformanceNum.Value : 0;
                        updateDto.PerformanceNum = addVo.PerformanceNum.HasValue ? addVo.PerformanceNum.Value : 0;
                        updateDto.MinivanRefund = addVo.MinivanRefund;
                        updateDto.MiniVanBadReviews = addVo.MiniVanBadReviews;
                        updateDto.NetWorkConsultingEmployeeId = addVo.NetWorkConsultingEmployeeId.Value;
                    }
                    await _liveAnchorDailyTargetService.UpdateAsync(updateDto);
                }
                else
                {
                    AddLiveAnchorDailyTargetDto addDto = new AddLiveAnchorDailyTargetDto();
                    addDto.LiveanchorMonthlyTargetId = addVo.LiveanchorMonthlyTargetId;
                    addDto.OperationEmployeeId = addVo.OperationEmployeeId;
                    addDto.LivingTrackingEmployeeId = addVo.LivingTrackingEmployeeId;
                    addDto.NetWorkConsultingEmployeeId = addVo.NetWorkConsultingEmployeeId.HasValue ? addVo.NetWorkConsultingEmployeeId.Value : 0;
                    addDto.TodaySendNum = addVo.TodaySendNum;
                    addDto.FlowInvestmentNum = addVo.FlowInvestmentNum;
                    addDto.LivingRoomFlowInvestmentNum = addVo.LivingRoomFlowInvestmentNum;
                    addDto.CluesNum = addVo.CluesNum;
                    addDto.AddFansNum = addVo.AddFansNum;
                    addDto.AddWechatNum = addVo.AddWechatNum;
                    addDto.Consultation = addVo.Consultation;
                    addDto.ConsultationCardConsumed = addVo.ConsultationCardConsumed;
                    addDto.Consultation2 = addVo.Consultation2;
                    addDto.ConsultationCardConsumed2 = addVo.ConsultationCardConsumed2;
                    addDto.ActivateHistoricalConsultation = addVo.ActivateHistoricalConsultation;
                    addDto.SendOrderNum = addVo.SendOrderNum.HasValue ? addVo.SendOrderNum.Value : 0;
                    addDto.NewVisitNum = addVo.NewVisitNum.HasValue ? addVo.NewVisitNum.Value : 0;
                    addDto.SubsequentVisitNum = addVo.SubsequentVisitNum.HasValue ? addVo.SubsequentVisitNum.Value : 0;
                    addDto.OldCustomerVisitNum = addVo.OldCustomerVisitNum.HasValue ? addVo.OldCustomerVisitNum.Value : 0;
                    addDto.VisitNum = addVo.VisitNum.HasValue ? addVo.VisitNum.Value : 0;
                    addDto.RecordDate = addVo.RecordDate;
                    addDto.NewDealNum = addVo.NewDealNum.HasValue ? addVo.NewDealNum.Value : 0;
                    addDto.SubsequentDealNum = addVo.SubsequentDealNum.HasValue ? addVo.SubsequentDealNum.Value : 0;
                    addDto.OldCustomerDealNum = addVo.OldCustomerDealNum.HasValue ? addVo.OldCustomerDealNum.Value : 0;
                    addDto.DealNum = addVo.DealNum.HasValue ? addVo.DealNum.Value : 0;
                    addDto.CargoSettlementCommission = addVo.CargoSettlementCommission;
                    addDto.NewPerformanceNum = addVo.NewPerformanceNum.HasValue ? addVo.NewPerformanceNum.Value : 0;
                    addDto.SubsequentPerformanceNum = addVo.SubsequentPerformanceNum.HasValue ? addVo.SubsequentPerformanceNum.Value : 0;
                    addDto.OldCustomerPerformanceNum = addVo.OldCustomerPerformanceNum.HasValue ? addVo.OldCustomerPerformanceNum.Value : 0;
                    addDto.NewCustomerPerformanceCountNum = addVo.NewCustomerPerformanceCountNum.HasValue ? addVo.NewCustomerPerformanceCountNum.Value : 0;
                    addDto.MinivanRefund = addVo.MinivanRefund;
                    addDto.MiniVanBadReviews = addVo.MiniVanBadReviews;
                    addDto.PerformanceNum = addVo.PerformanceNum.HasValue ? addVo.PerformanceNum.Value : 0;
                    await _liveAnchorDailyTargetService.AddAsync(addDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据id获取主播日运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<LiveAnchorDailyTargetByIdVo>> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorDailyTarget = await _liveAnchorDailyTargetService.GetByIdAsync(id);
                LiveAnchorDailyTargetByIdVo liveAnchorDailyTargetVo = new LiveAnchorDailyTargetByIdVo();
                liveAnchorDailyTargetVo.Id = liveAnchorDailyTarget.Id;
                liveAnchorDailyTargetVo.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                liveAnchorDailyTargetVo.LivingTrackingEmployeeId = liveAnchorDailyTarget.LivingTrackingEmployeeId;
                liveAnchorDailyTargetVo.OperationEmployeeId = liveAnchorDailyTarget.OperationEmployeeId;
                liveAnchorDailyTargetVo.NetWorkConsultingEmployeeId = liveAnchorDailyTarget.NetWorkConsultingEmployeeId;
                liveAnchorDailyTargetVo.TodaySendNum = liveAnchorDailyTarget.TodaySendNum;
                liveAnchorDailyTargetVo.FlowInvestmentNum = liveAnchorDailyTarget.FlowInvestmentNum;
                liveAnchorDailyTargetVo.LivingRoomFlowInvestmentNum = liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTargetVo.CluesNum = liveAnchorDailyTarget.CluesNum;
                liveAnchorDailyTargetVo.AddFansNum = liveAnchorDailyTarget.AddFansNum;
                liveAnchorDailyTargetVo.AddWechatNum = liveAnchorDailyTarget.AddWechatNum;
                liveAnchorDailyTargetVo.Consultation = liveAnchorDailyTarget.Consultation;
                liveAnchorDailyTargetVo.Consultation2 = liveAnchorDailyTarget.Consultation2;
                liveAnchorDailyTargetVo.ActivateHistoricalConsultation = liveAnchorDailyTarget.ActivateHistoricalConsultation;
                liveAnchorDailyTargetVo.ConsultationCardConsumed = liveAnchorDailyTarget.ConsultationCardConsumed;
                liveAnchorDailyTargetVo.ConsultationCardConsumed2 = liveAnchorDailyTarget.ConsultationCardConsumed2;
                liveAnchorDailyTargetVo.SendOrderNum = liveAnchorDailyTarget.SendOrderNum;
                liveAnchorDailyTargetVo.NewVisitNum = liveAnchorDailyTarget.NewVisitNum;
                liveAnchorDailyTargetVo.SubsequentVisitNum = liveAnchorDailyTarget.SubsequentVisitNum;
                liveAnchorDailyTargetVo.OldCustomerVisitNum = liveAnchorDailyTarget.OldCustomerVisitNum;
                liveAnchorDailyTargetVo.VisitNum = liveAnchorDailyTarget.VisitNum;
                liveAnchorDailyTargetVo.NewDealNum = liveAnchorDailyTarget.NewDealNum;
                liveAnchorDailyTargetVo.SubsequentDealNum = liveAnchorDailyTarget.SubsequentDealNum;
                liveAnchorDailyTargetVo.OldCustomerDealNum = liveAnchorDailyTarget.OldCustomerDealNum;
                liveAnchorDailyTargetVo.DealNum = liveAnchorDailyTarget.DealNum;
                liveAnchorDailyTargetVo.CargoSettlementCommission = liveAnchorDailyTarget.CargoSettlementCommission;
                liveAnchorDailyTargetVo.NewPerformanceNum = liveAnchorDailyTarget.NewPerformanceNum;
                liveAnchorDailyTargetVo.SubsequentPerformanceNum = liveAnchorDailyTarget.SubsequentPerformanceNum;
                liveAnchorDailyTargetVo.NewCustomerPerformanceCountNum = liveAnchorDailyTarget.NewCustomerPerformanceCountNum;
                liveAnchorDailyTargetVo.OldCustomerPerformanceNum = liveAnchorDailyTarget.OldCustomerPerformanceNum;
                liveAnchorDailyTargetVo.PerformanceNum = liveAnchorDailyTarget.PerformanceNum;
                liveAnchorDailyTargetVo.CreateDate = liveAnchorDailyTarget.CreateDate;
                liveAnchorDailyTargetVo.RecordDate = liveAnchorDailyTarget.RecordDate;
                liveAnchorDailyTargetVo.MinivanRefund = liveAnchorDailyTarget.MinivanRefund;
                liveAnchorDailyTargetVo.MiniVanBadReviews = liveAnchorDailyTarget.MiniVanBadReviews;

                return ResultData<LiveAnchorDailyTargetByIdVo>.Success().AddData("liveAnchorDailyTargetInfo", liveAnchorDailyTargetVo);
            }
            catch (Exception ex)
            {
                return ResultData<LiveAnchorDailyTargetByIdVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改主播日运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateLiveAnchorDailyTargetVo updateVo)
        {
            try
            {
                UpdateLiveAnchorDailyTargetDto updateDto = new UpdateLiveAnchorDailyTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.LiveanchorMonthlyTargetId = updateVo.LiveanchorMonthlyTargetId;
                updateDto.LivingTrackingEmployeeId = updateVo.LivingTrackingEmployeeId;
                updateDto.OperationEmployeeId = updateVo.OperationEmployeeId;
                updateDto.NetWorkConsultingEmployeeId = updateVo.NetWorkConsultingEmployeeId;
                updateDto.TodaySendNum = updateVo.TodaySendNum;
                updateDto.LivingRoomFlowInvestmentNum = updateVo.LivingRoomFlowInvestmentNum;
                updateDto.FlowInvestmentNum = updateVo.FlowInvestmentNum;
                updateDto.CluesNum = updateVo.CluesNum;
                updateDto.AddFansNum = updateVo.AddFansNum;
                updateDto.AddWechatNum = updateVo.AddWechatNum;
                updateDto.Consultation = updateVo.Consultation;
                updateDto.ConsultationCardConsumed = updateVo.ConsultationCardConsumed;
                updateDto.Consultation2 = updateVo.Consultation2;
                updateDto.ConsultationCardConsumed2 = updateVo.ConsultationCardConsumed2;
                updateDto.ActivateHistoricalConsultation = updateVo.ActivateHistoricalConsultation;
                updateDto.SendOrderNum = updateVo.SendOrderNum;
                updateDto.NewVisitNum = updateVo.NewVisitNum;
                updateDto.SubsequentVisitNum = updateVo.SubsequentVisitNum;
                updateDto.OldCustomerVisitNum = updateVo.OldCustomerVisitNum;
                updateDto.VisitNum = updateVo.VisitNum;
                updateDto.NewDealNum = updateVo.NewDealNum;
                updateDto.SubsequentDealNum = updateVo.SubsequentDealNum;
                updateDto.OldCustomerDealNum = updateVo.OldCustomerDealNum;
                updateDto.DealNum = updateVo.DealNum;
                updateDto.CargoSettlementCommission = updateVo.CargoSettlementCommission;
                updateDto.NewPerformanceNum = updateVo.NewPerformanceNum;
                updateDto.SubsequentPerformanceNum = updateVo.SubsequentPerformanceNum;
                updateDto.OldCustomerPerformanceNum = updateVo.OldCustomerPerformanceNum;
                updateDto.NewCustomerPerformanceCountNum = updateVo.NewCustomerPerformanceCountNum;
                updateDto.PerformanceNum = updateVo.PerformanceNum;
                updateDto.MinivanRefund = updateVo.MinivanRefund;
                updateDto.MiniVanBadReviews = updateVo.MiniVanBadReviews;
                updateDto.RecordDate = updateVo.RecordDate;
                await _liveAnchorDailyTargetService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除主播日运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _liveAnchorDailyTargetService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
