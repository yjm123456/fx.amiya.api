using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveAnchorDailyTarget;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class LiveAnchorDailyTargetService : ILiveAnchorDailyTargetService
    {
        private IDalLiveAnchorDailyTarget dalLiveAnchorDailyTarget;
        private ILiveAnchorService _liveanchorService;
        private ILiveAnchorMonthlyTargetService _liveAnchorMonthlyTargetService;
        private IUnitOfWork unitOfWork;
        private IAmiyaEmployeeService _amiyaEmployeeService;

        public LiveAnchorDailyTargetService(IDalLiveAnchorDailyTarget dalLiveAnchorDailyTarget,
            ILiveAnchorService liveAnchorService,
            IUnitOfWork unitOfWork,
            ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService,
            IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.unitOfWork = unitOfWork;
            this.dalLiveAnchorDailyTarget = dalLiveAnchorDailyTarget;
            _liveanchorService = liveAnchorService;
            _liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
            _amiyaEmployeeService = amiyaEmployeeService;
        }



        /// <summary>
        /// 获取主播日运营报表数据
        /// </summary>
        /// <param name="day">日期</param>
        /// <param name="operationEmpId">运营人员id</param>
        /// <param name="netWorkConEmpId">网咨人员id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<LiveAnchorDailyTargetDto>> GetListWithPageAsync(DateTime startDate, DateTime endDate, int? operationEmpId, int? netWorkConEmpId, int? liveAnchorId, int pageNum, int pageSize)
        {
            try
            {
                endDate = endDate.AddDays(1);
                var liveAnchorDailyTarget = from d in dalLiveAnchorDailyTarget.GetAll()
                                            where d.RecordDate >= startDate && d.RecordDate < endDate
                                            && (operationEmpId.HasValue == false || d.OperationEmployeeId == operationEmpId)
                                            && (netWorkConEmpId.HasValue == false || d.NetWorkConsultingEmployeeId == netWorkConEmpId)
                                            select new LiveAnchorDailyTargetDto
                                            {
                                                Id = d.Id,
                                                LiveanchorMonthlyTargetId = d.LiveanchorMonthlyTargetId,
                                                CreateDate = d.CreateDate,
                                                RecordDate = d.RecordDate,
                                                OperationEmployeeId = d.OperationEmployeeId,
                                                LivingTrackingEmployeeId = d.LivingTrackingEmployeeId,
                                                NetWorkConsultingEmployeeId = d.NetWorkConsultingEmployeeId,
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
                                                NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                                                OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                                                MinivanRefund = d.MinivanRefund,
                                                MiniVanBadReviews = d.MiniVanBadReviews,
                                                PerformanceNum = d.PerformanceNum,
                                            };

                FxPageInfo<LiveAnchorDailyTargetDto> liveAnchorDailyTargetPageInfo = new FxPageInfo<LiveAnchorDailyTargetDto>();
                var diaryTargetInfo = await liveAnchorDailyTarget.OrderByDescending(x => x.CreateDate).ToListAsync();
                List<LiveAnchorDailyTargetDto> resultList = new List<LiveAnchorDailyTargetDto>();
                if (liveAnchorId.HasValue == false)
                {
                    resultList = diaryTargetInfo.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                    foreach (var x in resultList)
                    {
                        var liveanchorMonthlyTarget = await _liveAnchorMonthlyTargetService.GetByIdAsync(x.LiveanchorMonthlyTargetId);
                        var liveAnchor = await _liveanchorService.GetByIdAsync(liveanchorMonthlyTarget.LiveAnchorId);
                        x.LiveAnchor = liveAnchor.Name.ToString();
                        if (x.OperationEmployeeId != 0)
                        {
                            var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.OperationEmployeeId);
                            if (operationEmployee.Id != 0)
                            {
                                x.OperationEmployeeName = operationEmployee.Name;
                            }
                        }
                        if (x.LivingTrackingEmployeeId != 0)
                        {
                            var ivingTrackingEmployee = await _amiyaEmployeeService.GetByIdAsync(x.LivingTrackingEmployeeId);
                            if (ivingTrackingEmployee.Id != 0)
                            {
                                x.LivingTrackingEmployeeName = ivingTrackingEmployee.Name;
                            }
                        }
                        if (x.NetWorkConsultingEmployeeId != 0)
                        {
                            var netWorkConsultingEmployee = await _amiyaEmployeeService.GetByIdAsync(x.NetWorkConsultingEmployeeId);
                            if (netWorkConsultingEmployee.Id != 0)
                            {
                                x.NetWorkConsultingEmployeeName = netWorkConsultingEmployee.Name;
                            }
                        }
                    }
                    liveAnchorDailyTargetPageInfo.TotalCount = await liveAnchorDailyTarget.CountAsync();
                    liveAnchorDailyTargetPageInfo.List = resultList;
                }
                else
                {
                    foreach (var z in diaryTargetInfo)
                    {
                        var liveanchorMonthlyTarget = await _liveAnchorMonthlyTargetService.GetByIdAsync(z.LiveanchorMonthlyTargetId);
                        if (liveanchorMonthlyTarget.LiveAnchorId == liveAnchorId.Value)
                        {

                            var liveAnchor = await _liveanchorService.GetByIdAsync(liveanchorMonthlyTarget.LiveAnchorId);
                            z.LiveAnchor = liveAnchor.Name.ToString();
                            if (z.OperationEmployeeId != 0)
                            {
                                var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(z.OperationEmployeeId);
                                if (operationEmployee.Id != 0)
                                {
                                    z.OperationEmployeeName = operationEmployee.Name.ToString();
                                }

                            }
                            if (z.LivingTrackingEmployeeId != 0)
                            {
                                var ivingTrackingEmployee = await _amiyaEmployeeService.GetByIdAsync(z.LivingTrackingEmployeeId);
                                if (ivingTrackingEmployee.Id != 0)
                                {
                                    z.LivingTrackingEmployeeName = ivingTrackingEmployee.Name;
                                }
                            }
                            if (z.NetWorkConsultingEmployeeId != 0)
                            {
                                var netWorkConsultingEmployee = await _amiyaEmployeeService.GetByIdAsync(z.NetWorkConsultingEmployeeId);
                                if (netWorkConsultingEmployee.Id != 0)
                                {
                                    z.NetWorkConsultingEmployeeName = netWorkConsultingEmployee.Name.ToString();
                                }
                            }
                            resultList.Add(z);
                        }
                    }
                    liveAnchorDailyTargetPageInfo.TotalCount = resultList.Count();
                    liveAnchorDailyTargetPageInfo.List = resultList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                }
                return liveAnchorDailyTargetPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LiveAnchorDailyTargetDto> GetLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate)
        {
            var liveAnchorDiaryInfo = from d in dalLiveAnchorDailyTarget.GetAll()
                                      where d.RecordDate == recordDate && d.LiveanchorMonthlyTargetId == monthlyTargetId
                                      select new LiveAnchorDailyTargetDto
                                      {
                                          Id = d.Id,
                                          LiveanchorMonthlyTargetId = d.LiveanchorMonthlyTargetId,
                                          CreateDate = d.CreateDate,
                                          RecordDate = d.RecordDate,
                                          OperationEmployeeId = d.OperationEmployeeId,
                                          LivingTrackingEmployeeId = d.LivingTrackingEmployeeId,
                                          NetWorkConsultingEmployeeId = d.NetWorkConsultingEmployeeId,
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
                                          NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                                          OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                                          MinivanRefund = d.MinivanRefund,
                                          MiniVanBadReviews = d.MiniVanBadReviews,
                                          PerformanceNum = d.PerformanceNum,
                                      };
            var selectResult = await liveAnchorDiaryInfo.FirstOrDefaultAsync();
            return selectResult;
        }

        public async Task AddAsync(AddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                LiveAnchorDailyTarget liveAnchorDailyTarget = new LiveAnchorDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.LivingTrackingEmployeeId = addDto.LivingTrackingEmployeeId;
                liveAnchorDailyTarget.OperationEmployeeId = addDto.OperationEmployeeId;
                liveAnchorDailyTarget.NetWorkConsultingEmployeeId = addDto.NetWorkConsultingEmployeeId.HasValue ? addDto.NetWorkConsultingEmployeeId.Value : 0;
                liveAnchorDailyTarget.TodaySendNum = addDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                liveAnchorDailyTarget.LivingRoomFlowInvestmentNum = addDto.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTarget.AddFansNum = addDto.AddFansNum;
                liveAnchorDailyTarget.CluesNum = addDto.CluesNum;
                liveAnchorDailyTarget.AddWechatNum = addDto.AddWechatNum;
                liveAnchorDailyTarget.Consultation = addDto.Consultation;
                liveAnchorDailyTarget.ConsultationCardConsumed = addDto.ConsultationCardConsumed;
                liveAnchorDailyTarget.Consultation2 = addDto.Consultation2;
                liveAnchorDailyTarget.ConsultationCardConsumed2 = addDto.ConsultationCardConsumed2;
                liveAnchorDailyTarget.Consultation2 = addDto.Consultation2;
                liveAnchorDailyTarget.ConsultationCardConsumed2 = addDto.ConsultationCardConsumed2;
                liveAnchorDailyTarget.ActivateHistoricalConsultation = addDto.ActivateHistoricalConsultation;
                liveAnchorDailyTarget.SendOrderNum = addDto.SendOrderNum.HasValue ? addDto.SendOrderNum.Value : 0;
                liveAnchorDailyTarget.NewVisitNum = addDto.NewVisitNum.HasValue ? addDto.NewVisitNum.Value : 0;
                liveAnchorDailyTarget.SubsequentVisitNum = addDto.SubsequentVisitNum.HasValue ? addDto.SubsequentVisitNum.Value : 0;
                liveAnchorDailyTarget.OldCustomerVisitNum = addDto.OldCustomerVisitNum.HasValue ? addDto.OldCustomerVisitNum.Value : 0;
                liveAnchorDailyTarget.VisitNum = addDto.VisitNum.HasValue ? addDto.VisitNum.Value : 0;
                liveAnchorDailyTarget.NewDealNum = addDto.NewDealNum.HasValue ? addDto.NewDealNum.Value : 0;
                liveAnchorDailyTarget.SubsequentDealNum = addDto.SubsequentDealNum.HasValue ? addDto.SubsequentDealNum.Value : 0;
                liveAnchorDailyTarget.OldCustomerDealNum = addDto.OldCustomerDealNum.HasValue ? addDto.OldCustomerDealNum.Value : 0;
                liveAnchorDailyTarget.DealNum = addDto.DealNum.HasValue ? addDto.DealNum.Value : 0;
                liveAnchorDailyTarget.CargoSettlementCommission = addDto.CargoSettlementCommission;
                liveAnchorDailyTarget.NewPerformanceNum = addDto.NewPerformanceNum.HasValue ? addDto.NewPerformanceNum.Value : 0;
                liveAnchorDailyTarget.SubsequentPerformanceNum = addDto.SubsequentPerformanceNum.HasValue ? addDto.SubsequentPerformanceNum.Value : 0;
                liveAnchorDailyTarget.NewCustomerPerformanceCountNum = addDto.NewCustomerPerformanceCountNum.HasValue ? addDto.NewCustomerPerformanceCountNum.Value : 0;
                liveAnchorDailyTarget.OldCustomerPerformanceNum = addDto.OldCustomerPerformanceNum.HasValue ? addDto.OldCustomerPerformanceNum.Value : 0;
                liveAnchorDailyTarget.PerformanceNum = addDto.PerformanceNum.HasValue ? addDto.PerformanceNum.Value : 0;
                liveAnchorDailyTarget.MinivanRefund = addDto.MinivanRefund;
                liveAnchorDailyTarget.MiniVanBadReviews = addDto.MiniVanBadReviews;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                await dalLiveAnchorDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = addDto.LivingRoomFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeCluesNum = addDto.CluesNum;
                editLiveAnchorMonthlyTarget.CumulativeAddFansNum = addDto.AddFansNum;
                editLiveAnchorMonthlyTarget.CumulativeAddWechat = addDto.AddWechatNum;
                editLiveAnchorMonthlyTarget.CumulativeConsultation = addDto.Consultation;
                editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = addDto.ConsultationCardConsumed;
                editLiveAnchorMonthlyTarget.CumulativeConsultation2 = addDto.Consultation2;
                editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = addDto.ConsultationCardConsumed2;
                editLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = addDto.ActivateHistoricalConsultation;
                editLiveAnchorMonthlyTarget.CumulativeSendOrder = addDto.SendOrderNum.HasValue ? addDto.SendOrderNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeVisit = addDto.VisitNum.HasValue ? addDto.VisitNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeDealTarget = addDto.DealNum.HasValue ? addDto.DealNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = addDto.CargoSettlementCommission;
                editLiveAnchorMonthlyTarget.CumulativePerformance = addDto.PerformanceNum.HasValue ? addDto.PerformanceNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = addDto.MiniVanBadReviews;
                editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = addDto.MinivanRefund;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task<LiveAnchorDailyTargetDto> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (liveAnchorDailyTarget == null)
                {
                    throw new Exception("主播日运营目标情况编号错误！");
                }

                LiveAnchorDailyTargetDto liveAnchorDailyTargetDto = new LiveAnchorDailyTargetDto();
                liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                liveAnchorDailyTargetDto.OperationEmployeeId = liveAnchorDailyTarget.OperationEmployeeId;
                liveAnchorDailyTargetDto.LivingTrackingEmployeeId = liveAnchorDailyTarget.LivingTrackingEmployeeId;
                liveAnchorDailyTargetDto.NetWorkConsultingEmployeeId = liveAnchorDailyTarget.NetWorkConsultingEmployeeId;
                liveAnchorDailyTargetDto.TodaySendNum = liveAnchorDailyTarget.TodaySendNum;
                liveAnchorDailyTargetDto.FlowInvestmentNum = liveAnchorDailyTarget.FlowInvestmentNum;
                liveAnchorDailyTargetDto.LivingRoomFlowInvestmentNum = liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTargetDto.CluesNum = liveAnchorDailyTarget.CluesNum;
                liveAnchorDailyTargetDto.AddFansNum = liveAnchorDailyTarget.AddFansNum;
                liveAnchorDailyTargetDto.AddWechatNum = liveAnchorDailyTarget.AddWechatNum;
                liveAnchorDailyTargetDto.Consultation = liveAnchorDailyTarget.Consultation;
                liveAnchorDailyTargetDto.Consultation2 = liveAnchorDailyTarget.Consultation2;
                liveAnchorDailyTargetDto.ActivateHistoricalConsultation = liveAnchorDailyTarget.ActivateHistoricalConsultation;
                liveAnchorDailyTargetDto.ConsultationCardConsumed = liveAnchorDailyTarget.ConsultationCardConsumed;
                liveAnchorDailyTargetDto.ConsultationCardConsumed2 = liveAnchorDailyTarget.ConsultationCardConsumed2;
                liveAnchorDailyTargetDto.SendOrderNum = liveAnchorDailyTarget.SendOrderNum;
                liveAnchorDailyTargetDto.NewVisitNum = liveAnchorDailyTarget.NewVisitNum;
                liveAnchorDailyTargetDto.SubsequentVisitNum = liveAnchorDailyTarget.SubsequentVisitNum;
                liveAnchorDailyTargetDto.OldCustomerVisitNum = liveAnchorDailyTarget.OldCustomerVisitNum;
                liveAnchorDailyTargetDto.VisitNum = liveAnchorDailyTarget.VisitNum;
                liveAnchorDailyTargetDto.NewDealNum = liveAnchorDailyTarget.NewDealNum;
                liveAnchorDailyTargetDto.SubsequentDealNum = liveAnchorDailyTarget.SubsequentDealNum;
                liveAnchorDailyTargetDto.OldCustomerDealNum = liveAnchorDailyTarget.OldCustomerDealNum;
                liveAnchorDailyTargetDto.DealNum = liveAnchorDailyTarget.DealNum;
                liveAnchorDailyTargetDto.CargoSettlementCommission = liveAnchorDailyTarget.CargoSettlementCommission;
                liveAnchorDailyTargetDto.NewPerformanceNum = liveAnchorDailyTarget.NewPerformanceNum;
                liveAnchorDailyTargetDto.SubsequentPerformanceNum = liveAnchorDailyTarget.SubsequentPerformanceNum;
                liveAnchorDailyTargetDto.OldCustomerPerformanceNum = liveAnchorDailyTarget.OldCustomerPerformanceNum;
                liveAnchorDailyTargetDto.NewCustomerPerformanceCountNum = liveAnchorDailyTarget.NewCustomerPerformanceCountNum;
                liveAnchorDailyTargetDto.PerformanceNum = liveAnchorDailyTarget.PerformanceNum;
                liveAnchorDailyTargetDto.CreateDate = liveAnchorDailyTarget.CreateDate;
                liveAnchorDailyTargetDto.RecordDate = liveAnchorDailyTarget.RecordDate;
                liveAnchorDailyTargetDto.MinivanRefund = liveAnchorDailyTarget.MinivanRefund;
                liveAnchorDailyTargetDto.MiniVanBadReviews = liveAnchorDailyTarget.MiniVanBadReviews;
                return liveAnchorDailyTargetDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LiveAnchorDailyTargetDto> GetByMonthTargetAsync(string monthTargetId)
        {
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().FirstOrDefaultAsync(e => e.LiveanchorMonthlyTargetId == monthTargetId);
                LiveAnchorDailyTargetDto liveAnchorDailyTargetDto = new LiveAnchorDailyTargetDto();
                if (liveAnchorDailyTarget == null)
                {
                    return liveAnchorDailyTargetDto;
                }

                liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                liveAnchorDailyTargetDto.OperationEmployeeId = liveAnchorDailyTarget.OperationEmployeeId;
                liveAnchorDailyTargetDto.LivingTrackingEmployeeId = liveAnchorDailyTarget.LivingTrackingEmployeeId;
                liveAnchorDailyTargetDto.NetWorkConsultingEmployeeId = liveAnchorDailyTarget.NetWorkConsultingEmployeeId;
                liveAnchorDailyTargetDto.TodaySendNum = liveAnchorDailyTarget.TodaySendNum;
                liveAnchorDailyTargetDto.FlowInvestmentNum = liveAnchorDailyTarget.FlowInvestmentNum;
                liveAnchorDailyTargetDto.LivingRoomFlowInvestmentNum = liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTargetDto.CluesNum = liveAnchorDailyTarget.CluesNum;
                liveAnchorDailyTargetDto.AddFansNum = liveAnchorDailyTarget.AddFansNum;
                liveAnchorDailyTargetDto.AddWechatNum = liveAnchorDailyTarget.AddWechatNum;
                liveAnchorDailyTargetDto.Consultation = liveAnchorDailyTarget.Consultation;
                liveAnchorDailyTargetDto.Consultation2 = liveAnchorDailyTarget.Consultation2;
                liveAnchorDailyTargetDto.ConsultationCardConsumed = liveAnchorDailyTarget.ConsultationCardConsumed;
                liveAnchorDailyTargetDto.ConsultationCardConsumed2 = liveAnchorDailyTarget.ConsultationCardConsumed2;
                liveAnchorDailyTargetDto.ActivateHistoricalConsultation = liveAnchorDailyTarget.ActivateHistoricalConsultation;
                liveAnchorDailyTargetDto.SendOrderNum = liveAnchorDailyTarget.SendOrderNum;
                liveAnchorDailyTargetDto.VisitNum = liveAnchorDailyTarget.VisitNum;
                liveAnchorDailyTargetDto.DealNum = liveAnchorDailyTarget.DealNum;
                liveAnchorDailyTargetDto.CargoSettlementCommission = liveAnchorDailyTarget.CargoSettlementCommission;
                liveAnchorDailyTargetDto.PerformanceNum = liveAnchorDailyTarget.PerformanceNum;
                liveAnchorDailyTargetDto.MiniVanBadReviews = liveAnchorDailyTarget.MiniVanBadReviews;
                liveAnchorDailyTargetDto.MinivanRefund = liveAnchorDailyTarget.MinivanRefund;
                liveAnchorDailyTargetDto.CreateDate = liveAnchorDailyTarget.CreateDate;

                return liveAnchorDailyTargetDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateLiveAnchorDailyTargetDto updateDto)
        {
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (liveAnchorDailyTarget == null)
                    throw new Exception("主播日运营目标情况编号错误！");
                //先扣除原有的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = -liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                editLiveAnchorMonthlyTarget.CumulativeAddWechat = -liveAnchorDailyTarget.AddWechatNum;
                editLiveAnchorMonthlyTarget.CumulativeConsultation = -liveAnchorDailyTarget.Consultation;
                editLiveAnchorMonthlyTarget.CumulativeConsultation2 = -liveAnchorDailyTarget.Consultation2;
                editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = -liveAnchorDailyTarget.ConsultationCardConsumed;
                editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = -liveAnchorDailyTarget.ConsultationCardConsumed2;
                editLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = -liveAnchorDailyTarget.ActivateHistoricalConsultation;
                editLiveAnchorMonthlyTarget.CumulativeSendOrder = -liveAnchorDailyTarget.SendOrderNum;
                editLiveAnchorMonthlyTarget.CumulativeVisit = -liveAnchorDailyTarget.VisitNum;
                editLiveAnchorMonthlyTarget.CumulativeDealTarget = -liveAnchorDailyTarget.DealNum;
                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = -liveAnchorDailyTarget.CargoSettlementCommission;
                editLiveAnchorMonthlyTarget.CumulativePerformance = -liveAnchorDailyTarget.PerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = -liveAnchorDailyTarget.MinivanRefund;
                editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = -liveAnchorDailyTarget.MiniVanBadReviews;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmployeeId = updateDto.OperationEmployeeId;
                liveAnchorDailyTarget.LivingTrackingEmployeeId = updateDto.LivingTrackingEmployeeId;
                liveAnchorDailyTarget.NetWorkConsultingEmployeeId = updateDto.NetWorkConsultingEmployeeId;
                liveAnchorDailyTarget.TodaySendNum = updateDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                liveAnchorDailyTarget.LivingRoomFlowInvestmentNum = updateDto.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTarget.CluesNum = updateDto.CluesNum;
                liveAnchorDailyTarget.AddFansNum = updateDto.AddFansNum;
                liveAnchorDailyTarget.AddWechatNum = updateDto.AddWechatNum;
                liveAnchorDailyTarget.Consultation = updateDto.Consultation;
                liveAnchorDailyTarget.ConsultationCardConsumed = updateDto.ConsultationCardConsumed;
                liveAnchorDailyTarget.Consultation2 = updateDto.Consultation2;
                liveAnchorDailyTarget.ConsultationCardConsumed2 = updateDto.ConsultationCardConsumed2;
                liveAnchorDailyTarget.ActivateHistoricalConsultation = updateDto.ActivateHistoricalConsultation;
                liveAnchorDailyTarget.SendOrderNum = updateDto.SendOrderNum;
                liveAnchorDailyTarget.NewVisitNum = updateDto.NewVisitNum;
                liveAnchorDailyTarget.SubsequentVisitNum = updateDto.SubsequentVisitNum;
                liveAnchorDailyTarget.OldCustomerVisitNum = updateDto.OldCustomerVisitNum;
                liveAnchorDailyTarget.VisitNum = updateDto.VisitNum;
                liveAnchorDailyTarget.NewDealNum = updateDto.NewDealNum;
                liveAnchorDailyTarget.SubsequentDealNum = updateDto.SubsequentDealNum;
                liveAnchorDailyTarget.OldCustomerDealNum = updateDto.OldCustomerDealNum;
                liveAnchorDailyTarget.DealNum = updateDto.DealNum;
                liveAnchorDailyTarget.CargoSettlementCommission = updateDto.CargoSettlementCommission;
                liveAnchorDailyTarget.NewPerformanceNum = updateDto.NewPerformanceNum;
                liveAnchorDailyTarget.SubsequentPerformanceNum = updateDto.SubsequentPerformanceNum;
                liveAnchorDailyTarget.OldCustomerPerformanceNum = updateDto.OldCustomerPerformanceNum;
                liveAnchorDailyTarget.NewCustomerPerformanceCountNum = updateDto.NewCustomerPerformanceCountNum;
                liveAnchorDailyTarget.PerformanceNum = updateDto.PerformanceNum;
                liveAnchorDailyTarget.MinivanRefund = updateDto.MinivanRefund;
                liveAnchorDailyTarget.MiniVanBadReviews = updateDto.MiniVanBadReviews;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                await dalLiveAnchorDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                //添加修改后的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = liveAnchorDailyTarget.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = liveAnchorDailyTarget.FlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeCluesNum = liveAnchorDailyTarget.CluesNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeAddFansNum = liveAnchorDailyTarget.AddFansNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeAddWechat = liveAnchorDailyTarget.AddWechatNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultation = liveAnchorDailyTarget.Consultation;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultation2 = liveAnchorDailyTarget.Consultation2;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = liveAnchorDailyTarget.ConsultationCardConsumed;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = liveAnchorDailyTarget.ConsultationCardConsumed2;
                lasteditLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = liveAnchorDailyTarget.ActivateHistoricalConsultation;
                lasteditLiveAnchorMonthlyTarget.CumulativeSendOrder = liveAnchorDailyTarget.SendOrderNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeVisit = liveAnchorDailyTarget.VisitNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeDealTarget = liveAnchorDailyTarget.DealNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = liveAnchorDailyTarget.CargoSettlementCommission;
                lasteditLiveAnchorMonthlyTarget.CumulativePerformance = liveAnchorDailyTarget.PerformanceNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeMinivanRefund = liveAnchorDailyTarget.MinivanRefund;
                lasteditLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = liveAnchorDailyTarget.MiniVanBadReviews;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().FirstOrDefaultAsync(e => e.Id == id);

                if (liveAnchorDailyTarget == null)
                    throw new Exception("主播日运营目标情况编号错误");
                //先扣除原有的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = -liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = -liveAnchorDailyTarget.ConsultationCardConsumed;
                editLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = -liveAnchorDailyTarget.ActivateHistoricalConsultation;
                editLiveAnchorMonthlyTarget.CumulativeAddWechat = -liveAnchorDailyTarget.AddWechatNum;
                editLiveAnchorMonthlyTarget.CumulativeConsultation = -liveAnchorDailyTarget.Consultation;
                editLiveAnchorMonthlyTarget.CumulativeConsultation2 = -liveAnchorDailyTarget.Consultation2;
                editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = -liveAnchorDailyTarget.ConsultationCardConsumed2;
                editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = -liveAnchorDailyTarget.MinivanRefund;
                editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = -liveAnchorDailyTarget.MiniVanBadReviews;
                editLiveAnchorMonthlyTarget.CumulativeSendOrder = -liveAnchorDailyTarget.SendOrderNum;
                editLiveAnchorMonthlyTarget.CumulativeVisit = -liveAnchorDailyTarget.VisitNum;
                editLiveAnchorMonthlyTarget.CumulativeDealTarget = -liveAnchorDailyTarget.DealNum;
                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = -liveAnchorDailyTarget.CargoSettlementCommission;
                editLiveAnchorMonthlyTarget.CumulativePerformance = -liveAnchorDailyTarget.PerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = -liveAnchorDailyTarget.MinivanRefund;
                editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = -liveAnchorDailyTarget.MiniVanBadReviews;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                await dalLiveAnchorDailyTarget.DeleteAsync(liveAnchorDailyTarget, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<List<LiveAnchorDailyAndMonthTargetDto>> GetByDailyAndMonthAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                endDate = endDate.AddDays(1);
                var liveAnchorDailyTarget = from d in dalLiveAnchorDailyTarget.GetAll()
                                            where d.RecordDate >= startDate && d.RecordDate < endDate
                                            select new LiveAnchorDailyAndMonthTargetDto
                                            {
                                                Id = d.Id,
                                                LiveanchorMonthlyTargetId = d.LiveanchorMonthlyTargetId,
                                                CreateDate = d.CreateDate,
                                                RecordDate = d.RecordDate,
                                                OperationEmployeeId = d.OperationEmployeeId,
                                                LivingTrackingEmployeeId = d.LivingTrackingEmployeeId,
                                                NetWorkConsultingEmployeeId = d.NetWorkConsultingEmployeeId,
                                                TodaySendNum = d.TodaySendNum,
                                                FlowInvestmentNum = d.FlowInvestmentNum,
                                                LivingRoomFlowInvestmentNum = d.LivingRoomFlowInvestmentNum,
                                                CluesNum = d.CluesNum,
                                                AddFansNum = d.AddFansNum,
                                                AddWechatNum = d.AddWechatNum,
                                                Consultation = d.Consultation,
                                                Consultation2 = d.Consultation2,
                                                ActivateHistoricalConsultation = d.ActivateHistoricalConsultation,
                                                ConsultationCardConsumed = d.ConsultationCardConsumed,
                                                ConsultationCardConsumed2 = d.ConsultationCardConsumed2,
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
                                                MiniVanBadReviews = d.MiniVanBadReviews,
                                                MinivanRefund = d.MinivanRefund,
                                                PerformanceNum = d.PerformanceNum,
                                            };
                var result = await liveAnchorDailyTarget.OrderByDescending(x => x.RecordDate).ToListAsync();
                foreach (var x in result)
                {
                    var liveanchorMonthlyTarget = await _liveAnchorMonthlyTargetService.GetByIdAsync(x.LiveanchorMonthlyTargetId);
                    var liveAnchor = await _liveanchorService.GetByIdAsync(liveanchorMonthlyTarget.LiveAnchorId);
                    x.LiveAnchor = liveAnchor.Name.ToString();
                    if (x.OperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.OperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.OperationEmployeeName = operationEmployee.Name.ToString();
                        }
                    }
                    if (x.LivingTrackingEmployeeId != 0)
                    {
                        var ivingTrackingEmployee = await _amiyaEmployeeService.GetByIdAsync(x.LivingTrackingEmployeeId);
                        if (ivingTrackingEmployee.Id != 0)
                        {
                            x.LivingTrackingEmployeeName = ivingTrackingEmployee.Name.ToString();
                        }
                    }
                    if (x.NetWorkConsultingEmployeeId != 0)
                    {
                        var netWorkConsultingEmployee = await _amiyaEmployeeService.GetByIdAsync(x.NetWorkConsultingEmployeeId);
                        if (netWorkConsultingEmployee.Id != 0)
                        {
                            x.NetWorkConsultingEmployeeName = netWorkConsultingEmployee.Name.ToString();
                        }
                    }
                    x.ReleaseTarget = liveanchorMonthlyTarget.ReleaseTarget;
                    x.CumulativeRelease = liveanchorMonthlyTarget.CumulativeRelease;
                    x.ReleaseCompleteRate = liveanchorMonthlyTarget.ReleaseCompleteRate.ToString("0.00") + "%";

                    x.FlowInvestmentTarget = liveanchorMonthlyTarget.FlowInvestmentTarget;
                    x.CumulativeFlowInvestment = liveanchorMonthlyTarget.CumulativeFlowInvestment;
                    x.FlowInvestmentCompleteRate = liveanchorMonthlyTarget.FlowInvestmentCompleteRate.ToString("0.00") + "%";

                    x.LivingRoomFlowInvestmentTarget = liveanchorMonthlyTarget.LivingRoomFlowInvestmentTarget;
                    x.LivingRoomCumulativeFlowInvestment = liveanchorMonthlyTarget.LivingRoomCumulativeFlowInvestment;
                    x.LivingRoomFlowInvestmentCompleteRate = liveanchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate.ToString("0.00") + "%";

                    x.CluesNumTarget = liveanchorMonthlyTarget.CluesTarget;
                    x.CumulativeCluesNum = liveanchorMonthlyTarget.CumulativeClues;
                    x.CluesCompleteRate = liveanchorMonthlyTarget.CluesCompleteRate.ToString("0.00") + "%";

                    x.AddFansTarget = liveanchorMonthlyTarget.AddFansTarget;
                    x.CumulativeAddFansNum = liveanchorMonthlyTarget.CumulativeAddFans;
                    x.AddFansCompleteRate = liveanchorMonthlyTarget.AddFansCompleteRate.ToString("0.00") + "%";

                    x.AddWechatTarget = liveanchorMonthlyTarget.AddWechatTarget;
                    x.CumulativeAddWechat = liveanchorMonthlyTarget.CumulativeAddWechat;
                    x.AddWechatCompleteRate = liveanchorMonthlyTarget.AddWechatCompleteRate.ToString("0.00") + "%";

                    x.ConsultationTarget = liveanchorMonthlyTarget.ConsultationTarget;
                    x.CumulativeConsultation = liveanchorMonthlyTarget.CumulativeConsultation;
                    x.ConsultationCompleteRate = liveanchorMonthlyTarget.ConsultationCompleteRate.ToString("0.00") + "%";

                    x.ConsultationTarget2 = liveanchorMonthlyTarget.ConsultationTarget2;
                    x.CumulativeConsultation2 = liveanchorMonthlyTarget.CumulativeConsultation2;
                    x.ConsultationCompleteRate2 = liveanchorMonthlyTarget.ConsultationCompleteRate2.ToString("0.00") + "%";


                    x.ConsultationCardConsumedTarget = liveanchorMonthlyTarget.ConsultationCardConsumedTarget;
                    x.CumulativeConsultationCardConsumed = liveanchorMonthlyTarget.CumulativeConsultationCardConsumed;
                    x.ConsultationCardConsumedCompleteRate = liveanchorMonthlyTarget.ConsultationCardConsumedCompleteRate.ToString("0.00") + "%";

                    x.ConsultationCardConsumedTarget2 = liveanchorMonthlyTarget.ConsultationCardConsumedTarget2;
                    x.CumulativeConsultationCardConsumed2 = liveanchorMonthlyTarget.CumulativeConsultationCardConsumed2;
                    x.ConsultationCardConsumedCompleteRate2 = liveanchorMonthlyTarget.ConsultationCardConsumedCompleteRate2.ToString("0.00") + "%";


                    x.ActivateHistoricalConsultationTarget = liveanchorMonthlyTarget.ActivateHistoricalConsultationTarget;
                    x.CumulativeActivateHistoricalConsultation = liveanchorMonthlyTarget.CumulativeActivateHistoricalConsultation;
                    x.ActivateHistoricalConsultationCompleteRate = liveanchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate.ToString("0.00") + "%";

                    x.SendOrderTarget = liveanchorMonthlyTarget.SendOrderTarget;
                    x.CumulativeSendOrder = liveanchorMonthlyTarget.CumulativeSendOrder;
                    x.SendOrderCompleteRate = liveanchorMonthlyTarget.SendOrderCompleteRate.ToString("0.00") + "%";

                    x.VisitTarget = liveanchorMonthlyTarget.VisitTarget;
                    x.CumulativeVisit = liveanchorMonthlyTarget.CumulativeVisit;
                    x.VisitCompleteRate = liveanchorMonthlyTarget.VisitCompleteRate.ToString("0.00") + "%";

                    x.DealTarget = liveanchorMonthlyTarget.DealTarget;
                    x.CumulativeDealTarget = liveanchorMonthlyTarget.CumulativeDealTarget;
                    x.DealRate = liveanchorMonthlyTarget.DealRate.ToString("0.00") + "%";

                    x.CargoSettlementCommissionTarget = liveanchorMonthlyTarget.CargoSettlementCommissionTarget;
                    x.CumulativeCargoSettlementCommission = liveanchorMonthlyTarget.CumulativeCargoSettlementCommission;
                    x.CargoSettlementCommissionCompleteRate = liveanchorMonthlyTarget.CargoSettlementCommissionCompleteRate.ToString("0.00") + "%";

                    x.PerformanceTarget = liveanchorMonthlyTarget.PerformanceTarget;
                    x.CumulativePerformance = liveanchorMonthlyTarget.CumulativePerformance;
                    x.PerformanceCompleteRate = liveanchorMonthlyTarget.PerformanceCompleteRate.ToString("0.00") + "%";


                    x.MiniVanBadReviewsTarget = liveanchorMonthlyTarget.MiniVanBadReviewsTarget;
                    x.CumulativeMiniVanBadReviews = liveanchorMonthlyTarget.CumulativeMiniVanBadReviews;
                    x.MiniVanBadReviewsCompleteRate = liveanchorMonthlyTarget.MiniVanBadReviewsCompleteRate.ToString("0.00") + "%";


                    x.MinivanRefundTarget = liveanchorMonthlyTarget.MinivanRefundTarget;
                    x.CumulativeMinivanRefund = liveanchorMonthlyTarget.CumulativeMinivanRefund;
                    x.MinivanRefundCompleteRate = liveanchorMonthlyTarget.MinivanRefundCompleteRate.ToString("0.00") + "%";
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 获取时间段内面诊卡下单数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetConsultingCardBuyDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in dalLiveAnchorDailyTarget.GetAll()
                         where d.RecordDate >= startrq && d.RecordDate < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.RecordDate.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = (x.Sum(z => z.Consultation) + x.Sum(z => z.Consultation2)) }).ToList();
        }

        /// <summary>
        /// 获取时间段内面诊卡消耗数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetConsultingCardUseDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in dalLiveAnchorDailyTarget.GetAll()
                         where d.RecordDate >= startrq && d.RecordDate < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.RecordDate.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.Sum(z => z.ConsultationCardConsumed) }).ToList();
        }
    }
}
