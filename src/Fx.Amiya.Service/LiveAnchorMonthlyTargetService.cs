using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class LiveAnchorMonthlyTargetService : ILiveAnchorMonthlyTargetService
    {
        private IDalLiveAnchorMonthlyTarget dalLiveAnchorMonthlyTarget;
        private ILiveAnchorService _liveanchorService;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IEmployeeBindLiveAnchorService employeeBindLiveAnchorService;

        public LiveAnchorMonthlyTargetService(IDalLiveAnchorMonthlyTarget dalLiveAnchorMonthlyTarget,
            ILiveAnchorService liveAnchorService,
            IEmployeeBindLiveAnchorService employeeBindLiveAnchorService,
            IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.dalLiveAnchorMonthlyTarget = dalLiveAnchorMonthlyTarget;
            _amiyaEmployeeService = amiyaEmployeeService;
            this.employeeBindLiveAnchorService = employeeBindLiveAnchorService;
            _liveanchorService = liveAnchorService;
        }



        public async Task<FxPageInfo<LiveAnchorMonthlyTargetDto>> GetListWithPageAsync(int Year, int Month, int? LiveAnchorId, int employeeId, int pageNum, int pageSize)
        {
            try
            {
                List<int> liveAnchorIds = new List<int>();
                if (LiveAnchorId.HasValue)
                {
                    liveAnchorIds.Add(LiveAnchorId.Value);
                }
                else
                {
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(employeeId);
                    if (empInfo.PositionId == 19)
                    {
                        var bindLiveAnchorInfo = await employeeBindLiveAnchorService.GetByEmpIdAsync(employeeId);
                        foreach (var x in bindLiveAnchorInfo)
                        {
                            liveAnchorIds.Add(x.LiveAnchorId);
                        }
                    }
                }
                var liveAnchorMonthlyTarget = from d in dalLiveAnchorMonthlyTarget.GetAll().Include(e => e.LiveAnchor)
                                              where (d.Year == Year)
                                              && (d.Month == Month)
                                              && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorId))
                                              select new LiveAnchorMonthlyTargetDto
                                              {
                                                  Id = d.Id,
                                                  Year = d.Year,
                                                  Month = d.Month,
                                                  MonthlyTargetName = d.MonthlyTargetName,
                                                  LiveAnchorId = d.LiveAnchorId,
                                                  LiveAnchorName = d.LiveAnchor.Name,

                                                  ZhihuReleaseTarget = d.ZhihuReleaseTarget,
                                                  CumulativeZhihuRelease = d.CumulativeZhihuRelease,
                                                  ZhihuReleaseCompleteRate = d.ZhihuReleaseCompleteRate,
                                                  ZhihuFlowinvestmentTarget = d.ZhihuFlowinvestmentTarget,
                                                  CumulativeZhihuFlowinvestment = d.CumulativeZhihuFlowinvestment,
                                                  ZhihuFlowinvestmentCompleteRate = d.ZhihuFlowinvestmentCompleteRate,
                                                 
                                                  VideoReleaseTarget = d.VideoReleaseTarget,
                                                  CumulativeVideoRelease = d.CumulativeVideoRelease,
                                                  VideoReleaseCompleteRate = d.VideoReleaseCompleteRate,
                                                  VideoFlowinvestmentTarget = d.VideoFlowinvestmentTarget,
                                                  CumulativeVideoFlowinvestment = d.CumulativeVideoFlowinvestment,
                                                  VideoFlowinvestmentCompleteRate = d.VideoFlowinvestmentCompleteRate,
                                                  
                                                  TikTokReleaseTarget = d.TikTokReleaseTarget,
                                                  CumulativeTikTokRelease = d.CumulativeTikTokRelease,
                                                  TikTokReleaseCompleteRate = d.TikTokReleaseCompleteRate,
                                                  TikTokFlowinvestmentTarget = d.TikTokFlowinvestmentTarget,
                                                  CumulativeTikTokFlowinvestment = d.CumulativeTikTokFlowinvestment,
                                                  TikTokFlowinvestmentCompleteRate = d.TikTokFlowinvestmentCompleteRate,
                                                 
                                                  XiaoHongShuReleaseTarget = d.XiaoHongShuReleaseTarget,
                                                  CumulativeXiaoHongShuRelease = d.CumulativeXiaoHongShuRelease,
                                                  XiaoHongShuReleaseCompleteRate = d.XiaoHongShuReleaseCompleteRate,
                                                  XiaoHongShuFlowinvestmentTarget = d.XiaoHongShuFlowinvestmentTarget,
                                                  CumulativeXiaoHongShuFlowinvestment = d.CumulativeXiaoHongShuFlowinvestment,
                                                  XiaoHongShuFlowinvestmentCompleteRate = d.XiaoHongShuFlowinvestmentCompleteRate,
                                                 
                                                  SinaWeiBoReleaseTarget = d.SinaWeiBoReleaseTarget,
                                                  CumulativeSinaWeiBoRelease = d.CumulativeSinaWeiBoRelease,
                                                  SinaWeiBoReleaseCompleteRate = d.SinaWeiBoReleaseCompleteRate,
                                                  SinaWeiBoFlowinvestmentTarget = d.SinaWeiBoFlowinvestmentTarget,
                                                  CumulativeSinaWeiBoFlowinvestment = d.CumulativeSinaWeiBoFlowinvestment,
                                                  SinaWeiBoFlowinvestmentCompleteRate = d.SinaWeiBoFlowinvestmentCompleteRate,
                                                  
                                                  ReleaseTarget = d.ReleaseTarget,
                                                  CumulativeRelease = d.CumulativeRelease,
                                                  ReleaseCompleteRate = d.ReleaseCompleteRate,
                                                  FlowInvestmentTarget = d.FlowInvestmentTarget,
                                                  CumulativeFlowInvestment = d.CumulativeFlowInvestment,
                                                  FlowInvestmentCompleteRate = d.FlowInvestmentCompleteRate,
                                                  LivingRoomCumulativeFlowInvestment = d.LivingRoomCumulativeFlowInvestment,
                                                  LivingRoomFlowInvestmentTarget = d.LivingRoomFlowInvestmentTarget,
                                                  LivingRoomFlowInvestmentCompleteRate = d.LivingRoomFlowInvestmentCompleteRate,
                                                  AddWechatTarget = d.AddWechatTarget,
                                                  CumulativeAddWechat = d.CumulativeAddWechat,
                                                  CluesTarget = d.CluesTarget,
                                                  CumulativeClues = d.CumulativeClues,
                                                  CluesCompleteRate = d.CluesCompleteRate,
                                                  AddFansTarget = d.AddFansTarget,
                                                  CumulativeAddFans = d.CumulativeAddFans,
                                                  AddFansCompleteRate = d.AddFansCompleteRate,
                                                  AddWechatCompleteRate = d.AddWechatCompleteRate,
                                                  ConsultationTarget = d.ConsultationTarget,
                                                  CumulativeConsultation = d.CumulativeConsultation,
                                                  ConsultationCompleteRate = d.ConsultationCompleteRate,
                                                  CumulativeConsultation2 = d.CumulativeConsultation2,
                                                  ConsultationTarget2 = d.ConsultationTarget2,
                                                  ConsultationCompleteRate2 = d.ConsultationCompleteRate2,
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
                                                  CargoSettlementCommissionTarget = d.CargoSettlementCommissionTarget,
                                                  CumulativeCargoSettlementCommission = d.CumulativeCargoSettlementCommission,
                                                  CargoSettlementCommissionCompleteRate = d.CargoSettlementCommissionCompleteRate,
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
                                              };

                FxPageInfo<LiveAnchorMonthlyTargetDto> liveAnchorMonthlyTargetPageInfo = new FxPageInfo<LiveAnchorMonthlyTargetDto>();
                liveAnchorMonthlyTargetPageInfo.TotalCount = await liveAnchorMonthlyTarget.CountAsync();
                liveAnchorMonthlyTargetPageInfo.List = await liveAnchorMonthlyTarget.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return liveAnchorMonthlyTargetPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddLiveAnchorMonthlyTargetDto addDto)
        {
            try
            {
                LiveAnchorMonthlyTarget liveAnchorMonthlyTarget = new LiveAnchorMonthlyTarget();
                liveAnchorMonthlyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorMonthlyTarget.Year = addDto.Year;
                liveAnchorMonthlyTarget.Month = addDto.Month;
                liveAnchorMonthlyTarget.MonthlyTargetName = addDto.MonthlyTargetName;
                liveAnchorMonthlyTarget.LiveAnchorId = addDto.LiveAnchorId;

                liveAnchorMonthlyTarget.ZhihuReleaseTarget = addDto.ZhihuReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeZhihuRelease = 0;
                liveAnchorMonthlyTarget.ZhihuReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.ZhihuFlowinvestmentTarget = addDto.ZhihuFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment = 0;
                liveAnchorMonthlyTarget.ZhihuFlowinvestmentCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.VideoReleaseTarget = addDto.VideoReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeVideoRelease = 0;
                liveAnchorMonthlyTarget.VideoReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.VideoFlowinvestmentTarget = addDto.VideoFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = 0;
                liveAnchorMonthlyTarget.VideoFlowinvestmentCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.TikTokReleaseTarget = addDto.TikTokReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeTikTokRelease = 0;
                liveAnchorMonthlyTarget.TikTokReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.TikTokFlowinvestmentTarget = addDto.TikTokFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = 0;
                liveAnchorMonthlyTarget.TikTokFlowinvestmentCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.XiaoHongShuReleaseTarget = addDto.XiaoHongShuReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = 0;
                liveAnchorMonthlyTarget.XiaoHongShuReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentTarget = addDto.XiaoHongShuFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = 0;
                liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentCompleteRate = 0.00M;



                liveAnchorMonthlyTarget.SinaWeiBoReleaseTarget = addDto.SinaWeiBoReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease = 0;
                liveAnchorMonthlyTarget.SinaWeiBoReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentTarget = addDto.SinaWeiBoFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment = 0;
                liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentCompleteRate = 0.00M;


                liveAnchorMonthlyTarget.ReleaseTarget = addDto.ReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeRelease = 0;
                liveAnchorMonthlyTarget.ReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.FlowInvestmentTarget = addDto.FlowInvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeFlowInvestment = 0;
                liveAnchorMonthlyTarget.FlowInvestmentCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget = addDto.LivingRoomFlowInvestmentTarget;
                liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = 0;
                liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.CluesTarget = addDto.CluesTarget;
                liveAnchorMonthlyTarget.CumulativeClues = 0;
                liveAnchorMonthlyTarget.CluesCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.AddFansTarget = addDto.AddFansTarget;
                liveAnchorMonthlyTarget.CumulativeAddFans = 0;
                liveAnchorMonthlyTarget.AddFansCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.AddWechatTarget = addDto.AddWechatTarget;
                liveAnchorMonthlyTarget.CumulativeAddWechat = 0;
                liveAnchorMonthlyTarget.AddWechatCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.ConsultationTarget = addDto.ConsultationTarget;
                liveAnchorMonthlyTarget.CumulativeConsultation = 0;
                liveAnchorMonthlyTarget.ConsultationCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.ConsultationTarget2 = addDto.ConsultationTarget2;
                liveAnchorMonthlyTarget.CumulativeConsultation2 = 0;
                liveAnchorMonthlyTarget.ConsultationCompleteRate2 = 0.00M;
                liveAnchorMonthlyTarget.ConsultationCardConsumedTarget = addDto.ConsultationCardConsumedTarget;
                liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = 0;
                liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.ConsultationCardConsumedTarget2 = addDto.ConsultationCardConsumedTarget2;
                liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = 0;
                liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate2 = 0.00M;
                liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget = addDto.ActivateHistoricalConsultationTarget;
                liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = 0;
                liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.SendOrderTarget = addDto.SendOrderTarget;
                liveAnchorMonthlyTarget.CumulativeSendOrder = 0;
                liveAnchorMonthlyTarget.SendOrderCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.NewCustomerVisitTarget = addDto.NewCustomerVisitTarget;
                liveAnchorMonthlyTarget.CumulativeNewCustomerVisit = 0;
                liveAnchorMonthlyTarget.NewCustomerVisitCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.OldCustomerVisitTarget = addDto.OldCustomerVisitTarget;
                liveAnchorMonthlyTarget.CumulativeOldCustomerVisit = 0;
                liveAnchorMonthlyTarget.OldCustomerVisitCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.VisitTarget = addDto.VisitTarget;
                liveAnchorMonthlyTarget.CumulativeVisit = 0;
                liveAnchorMonthlyTarget.VisitCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.NewCustomerDealTarget = addDto.NewCustomerDealTarget;
                liveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = 0;
                liveAnchorMonthlyTarget.NewCustomerDealRate = 0.00M;

                liveAnchorMonthlyTarget.OldCustomerDealTarget = addDto.OldCustomerDealTarget;
                liveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = 0;
                liveAnchorMonthlyTarget.OldCustomerDealRate = 0.00M;

                liveAnchorMonthlyTarget.DealTarget = addDto.DealTarget;
                liveAnchorMonthlyTarget.CumulativeDealTarget = 0;
                liveAnchorMonthlyTarget.DealRate = 0.00M;
                liveAnchorMonthlyTarget.CargoSettlementCommissionTarget = addDto.CargoSettlementCommissionTarget;
                liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = 0.00M;
                liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.PerformanceTarget = addDto.PerformanceTarget;
                liveAnchorMonthlyTarget.CumulativePerformance = 0.00M;
                liveAnchorMonthlyTarget.PerformanceCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.NewCustomerPerformanceTarget = addDto.NewCustomerPerformanceTarget;
                liveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = 0.00M;
                liveAnchorMonthlyTarget.NewCustomerPerformanceCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.OldCustomerPerformanceTarget = addDto.OldCustomerPerformanceTarget;
                liveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = 0.00M;
                liveAnchorMonthlyTarget.OldCustomerPerformanceCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.SubsequentPerformanceTarget = addDto.SubsequentPerformanceTarget;
                liveAnchorMonthlyTarget.CumulativeSubsequentPerformance = 0.00M;
                liveAnchorMonthlyTarget.SubsequentPerformanceCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.MinivanRefundTarget = addDto.MinivanRefundTarget;
                liveAnchorMonthlyTarget.CumulativeMinivanRefund = 0;
                liveAnchorMonthlyTarget.MinivanRefundCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.MiniVanBadReviewsTarget = addDto.MiniVanBadReviewsTarget;
                liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = 0;
                liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.CreateDate = DateTime.Now;

                await dalLiveAnchorMonthlyTarget.AddAsync(liveAnchorMonthlyTarget, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<LiveAnchorMonthlyTargetKeyAndValueDto>> GetIdAndNames(int year, int month)
        {
            try
            {
                var liveAnchorMonthlyTarget = from d in dalLiveAnchorMonthlyTarget.GetAll()
                                              where (d.Year == year && d.Month == month)
                                              select new LiveAnchorMonthlyTargetKeyAndValueDto
                                              {
                                                  Id = d.Id,
                                                  Name = d.MonthlyTargetName
                                              };
                return liveAnchorMonthlyTarget.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<LiveAnchorMonthlyTargetDto> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (liveAnchorMonthlyTarget == null)
                {
                    throw new Exception("主播月度运营目标情况编号错误！");
                }

                LiveAnchorMonthlyTargetDto liveAnchorMonthlyTargetDto = new LiveAnchorMonthlyTargetDto();
                liveAnchorMonthlyTargetDto.Id = liveAnchorMonthlyTarget.Id;
                liveAnchorMonthlyTargetDto.Year = liveAnchorMonthlyTarget.Year;
                liveAnchorMonthlyTargetDto.Month = liveAnchorMonthlyTarget.Month;
                liveAnchorMonthlyTargetDto.MonthlyTargetName = liveAnchorMonthlyTarget.MonthlyTargetName;
                liveAnchorMonthlyTargetDto.LiveAnchorId = liveAnchorMonthlyTarget.LiveAnchorId;

                liveAnchorMonthlyTargetDto.TikTokReleaseTarget = liveAnchorMonthlyTarget.TikTokReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeTikTokRelease = liveAnchorMonthlyTarget.CumulativeTikTokRelease;
                liveAnchorMonthlyTargetDto.TikTokReleaseCompleteRate = liveAnchorMonthlyTarget.TikTokReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.TikTokFlowinvestmentTarget = liveAnchorMonthlyTarget.TikTokFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeTikTokFlowinvestment = liveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment;
                liveAnchorMonthlyTargetDto.TikTokFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.TikTokFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.XiaoHongShuReleaseTarget = liveAnchorMonthlyTarget.XiaoHongShuReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeXiaoHongShuRelease = liveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease;
                liveAnchorMonthlyTargetDto.XiaoHongShuReleaseCompleteRate = liveAnchorMonthlyTarget.XiaoHongShuReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.XiaoHongShuFlowinvestmentTarget = liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeXiaoHongShuFlowinvestment = liveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment;
                liveAnchorMonthlyTargetDto.XiaoHongShuFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.SinaWeiBoReleaseTarget = liveAnchorMonthlyTarget.SinaWeiBoReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeSinaWeiBoRelease = liveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease;
                liveAnchorMonthlyTargetDto.SinaWeiBoReleaseCompleteRate = liveAnchorMonthlyTarget.SinaWeiBoReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.SinaWeiBoFlowinvestmentTarget = liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeSinaWeiBoFlowinvestment = liveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment;
                liveAnchorMonthlyTargetDto.SinaWeiBoFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.ZhihuReleaseTarget = liveAnchorMonthlyTarget.ZhihuReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeZhihuRelease = liveAnchorMonthlyTarget.CumulativeZhihuRelease;
                liveAnchorMonthlyTargetDto.ZhihuReleaseCompleteRate = liveAnchorMonthlyTarget.ZhihuReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.ZhihuFlowinvestmentTarget = liveAnchorMonthlyTarget.ZhihuFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeZhihuFlowinvestment = liveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment;
                liveAnchorMonthlyTargetDto.ZhihuFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.ZhihuFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.VideoReleaseTarget = liveAnchorMonthlyTarget.VideoReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeVideoRelease = liveAnchorMonthlyTarget.CumulativeVideoRelease;
                liveAnchorMonthlyTargetDto.VideoReleaseCompleteRate = liveAnchorMonthlyTarget.VideoReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.VideoFlowinvestmentTarget = liveAnchorMonthlyTarget.VideoFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeVideoFlowinvestment = liveAnchorMonthlyTarget.CumulativeVideoFlowinvestment;
                liveAnchorMonthlyTargetDto.VideoFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.VideoFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.ReleaseTarget = liveAnchorMonthlyTarget.ReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeRelease = liveAnchorMonthlyTarget.CumulativeRelease;
                liveAnchorMonthlyTargetDto.ReleaseCompleteRate = liveAnchorMonthlyTarget.ReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.FlowInvestmentTarget = liveAnchorMonthlyTarget.FlowInvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeFlowInvestment = liveAnchorMonthlyTarget.CumulativeFlowInvestment;
                liveAnchorMonthlyTargetDto.FlowInvestmentCompleteRate = liveAnchorMonthlyTarget.FlowInvestmentCompleteRate;
                liveAnchorMonthlyTargetDto.LivingRoomCumulativeFlowInvestment = liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment;
                liveAnchorMonthlyTargetDto.LivingRoomFlowInvestmentTarget = liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget;
                liveAnchorMonthlyTargetDto.LivingRoomFlowInvestmentCompleteRate = liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate;
                liveAnchorMonthlyTargetDto.CluesTarget = liveAnchorMonthlyTarget.CluesTarget;
                liveAnchorMonthlyTargetDto.CumulativeClues = liveAnchorMonthlyTarget.CumulativeClues;
                liveAnchorMonthlyTargetDto.CluesCompleteRate = liveAnchorMonthlyTarget.CluesCompleteRate;
                liveAnchorMonthlyTargetDto.AddFansTarget = liveAnchorMonthlyTarget.AddFansTarget;
                liveAnchorMonthlyTargetDto.CumulativeAddFans = liveAnchorMonthlyTarget.CumulativeAddFans;
                liveAnchorMonthlyTargetDto.AddFansCompleteRate = liveAnchorMonthlyTarget.AddFansCompleteRate;
                liveAnchorMonthlyTargetDto.AddWechatTarget = liveAnchorMonthlyTarget.AddWechatTarget;
                liveAnchorMonthlyTargetDto.CumulativeAddWechat = liveAnchorMonthlyTarget.CumulativeAddWechat;
                liveAnchorMonthlyTargetDto.AddWechatCompleteRate = liveAnchorMonthlyTarget.AddWechatCompleteRate;
                liveAnchorMonthlyTargetDto.ConsultationTarget = liveAnchorMonthlyTarget.ConsultationTarget;
                liveAnchorMonthlyTargetDto.ConsultationCompleteRate = liveAnchorMonthlyTarget.ConsultationCompleteRate;
                liveAnchorMonthlyTargetDto.CumulativeConsultation = liveAnchorMonthlyTarget.CumulativeConsultation;
                liveAnchorMonthlyTargetDto.ConsultationTarget2 = liveAnchorMonthlyTarget.ConsultationTarget2;
                liveAnchorMonthlyTargetDto.ConsultationCompleteRate2 = liveAnchorMonthlyTarget.ConsultationCompleteRate2;
                liveAnchorMonthlyTargetDto.CumulativeConsultation2 = liveAnchorMonthlyTarget.CumulativeConsultation2;
                liveAnchorMonthlyTargetDto.ConsultationCardConsumedTarget = liveAnchorMonthlyTarget.ConsultationCardConsumedTarget;
                liveAnchorMonthlyTargetDto.CumulativeConsultationCardConsumed = liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed;
                liveAnchorMonthlyTargetDto.ConsultationCardConsumedCompleteRate = liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate;
                liveAnchorMonthlyTargetDto.ConsultationCardConsumedTarget2 = liveAnchorMonthlyTarget.ConsultationCardConsumedTarget2;
                liveAnchorMonthlyTargetDto.CumulativeConsultationCardConsumed2 = liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2;
                liveAnchorMonthlyTargetDto.ConsultationCardConsumedCompleteRate2 = liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate2;
                liveAnchorMonthlyTargetDto.ActivateHistoricalConsultationTarget = liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget;
                liveAnchorMonthlyTargetDto.CumulativeActivateHistoricalConsultation = liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation;
                liveAnchorMonthlyTargetDto.ActivateHistoricalConsultationCompleteRate = liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate;
                liveAnchorMonthlyTargetDto.SendOrderTarget = liveAnchorMonthlyTarget.SendOrderTarget;
                liveAnchorMonthlyTargetDto.CumulativeSendOrder = liveAnchorMonthlyTarget.CumulativeSendOrder;
                liveAnchorMonthlyTargetDto.SendOrderCompleteRate = liveAnchorMonthlyTarget.SendOrderCompleteRate;

                liveAnchorMonthlyTargetDto.NewCustomerVisitTarget = liveAnchorMonthlyTarget.NewCustomerVisitTarget;
                liveAnchorMonthlyTargetDto.CumulativeNewCustomerVisit = liveAnchorMonthlyTarget.CumulativeNewCustomerVisit;
                liveAnchorMonthlyTargetDto.NewCustomerVisitCompleteRate = liveAnchorMonthlyTarget.NewCustomerVisitCompleteRate;

                liveAnchorMonthlyTargetDto.OldCustomerVisitTarget = liveAnchorMonthlyTarget.OldCustomerVisitTarget;
                liveAnchorMonthlyTargetDto.CumulativeOldCustomerVisit = liveAnchorMonthlyTarget.CumulativeOldCustomerVisit;
                liveAnchorMonthlyTargetDto.OldCustomerVisitCompleteRate = liveAnchorMonthlyTarget.OldCustomerVisitCompleteRate;

                liveAnchorMonthlyTargetDto.VisitTarget = liveAnchorMonthlyTarget.VisitTarget;
                liveAnchorMonthlyTargetDto.CumulativeVisit = liveAnchorMonthlyTarget.CumulativeVisit;
                liveAnchorMonthlyTargetDto.VisitCompleteRate = liveAnchorMonthlyTarget.VisitCompleteRate;

                liveAnchorMonthlyTargetDto.NewCustomerDealTarget = liveAnchorMonthlyTarget.NewCustomerDealTarget;
                liveAnchorMonthlyTargetDto.CumulativeNewCustomerDealTarget = liveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget;
                liveAnchorMonthlyTargetDto.NewCustomerDealRate = liveAnchorMonthlyTarget.NewCustomerDealRate;

                liveAnchorMonthlyTargetDto.OldCustomerDealTarget = liveAnchorMonthlyTarget.OldCustomerDealTarget;
                liveAnchorMonthlyTargetDto.CumulativeOldCustomerDealTarget = liveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget;
                liveAnchorMonthlyTargetDto.OldCustomerDealRate = liveAnchorMonthlyTarget.OldCustomerDealRate;

                liveAnchorMonthlyTargetDto.DealTarget = liveAnchorMonthlyTarget.DealTarget;
                liveAnchorMonthlyTargetDto.CumulativeDealTarget = liveAnchorMonthlyTarget.CumulativeDealTarget;
                liveAnchorMonthlyTargetDto.DealRate = liveAnchorMonthlyTarget.DealRate;

                liveAnchorMonthlyTargetDto.CargoSettlementCommissionTarget = liveAnchorMonthlyTarget.CargoSettlementCommissionTarget;
                liveAnchorMonthlyTargetDto.CumulativeCargoSettlementCommission = liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission;
                liveAnchorMonthlyTargetDto.CargoSettlementCommissionCompleteRate = liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate;


                liveAnchorMonthlyTargetDto.NewCustomerPerformanceTarget = liveAnchorMonthlyTarget.NewCustomerPerformanceTarget;
                liveAnchorMonthlyTargetDto.CumulativeNewCustomerPerformance = liveAnchorMonthlyTarget.CumulativeNewCustomerPerformance;
                liveAnchorMonthlyTargetDto.NewCustomerPerformanceCompleteRate = liveAnchorMonthlyTarget.NewCustomerPerformanceCompleteRate;

                liveAnchorMonthlyTargetDto.SubsequentPerformanceTarget = liveAnchorMonthlyTarget.SubsequentPerformanceTarget;
                liveAnchorMonthlyTargetDto.CumulativeSubsequentPerformance = liveAnchorMonthlyTarget.CumulativeSubsequentPerformance;
                liveAnchorMonthlyTargetDto.SubsequentPerformanceCompleteRate = liveAnchorMonthlyTarget.SubsequentPerformanceCompleteRate;

                liveAnchorMonthlyTargetDto.OldCustomerPerformanceTarget = liveAnchorMonthlyTarget.OldCustomerPerformanceTarget;
                liveAnchorMonthlyTargetDto.CumulativeOldCustomerPerformance = liveAnchorMonthlyTarget.CumulativeOldCustomerPerformance;
                liveAnchorMonthlyTargetDto.OldCustomerPerformanceCompleteRate = liveAnchorMonthlyTarget.OldCustomerPerformanceCompleteRate;

                liveAnchorMonthlyTargetDto.PerformanceTarget = liveAnchorMonthlyTarget.PerformanceTarget;
                liveAnchorMonthlyTargetDto.CumulativePerformance = liveAnchorMonthlyTarget.CumulativePerformance;
                liveAnchorMonthlyTargetDto.PerformanceCompleteRate = liveAnchorMonthlyTarget.PerformanceCompleteRate;
                liveAnchorMonthlyTargetDto.MinivanRefundTarget = liveAnchorMonthlyTarget.MinivanRefundTarget;
                liveAnchorMonthlyTargetDto.CumulativeMinivanRefund = liveAnchorMonthlyTarget.CumulativeMinivanRefund;
                liveAnchorMonthlyTargetDto.MinivanRefundCompleteRate = liveAnchorMonthlyTarget.MinivanRefundCompleteRate;
                liveAnchorMonthlyTargetDto.MiniVanBadReviewsTarget = liveAnchorMonthlyTarget.MiniVanBadReviewsTarget;
                liveAnchorMonthlyTargetDto.CumulativeMiniVanBadReviews = liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews;
                liveAnchorMonthlyTargetDto.MiniVanBadReviewsCompleteRate = liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate;
                liveAnchorMonthlyTargetDto.CreateDate = liveAnchorMonthlyTarget.CreateDate;
                var liveAnchor = await _liveanchorService.GetByIdAsync(liveAnchorMonthlyTargetDto.LiveAnchorId);
                liveAnchorMonthlyTargetDto.ContentPlatFormId = liveAnchor.ContentPlateFormId;
                return liveAnchorMonthlyTargetDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateLiveAnchorMonthlyTargetDto updateDto)
        {
            try
            {
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (liveAnchorMonthlyTarget == null)
                    throw new Exception("主播月度运营目标情况编号错误！");

                liveAnchorMonthlyTarget.Year = updateDto.Year;
                liveAnchorMonthlyTarget.Month = updateDto.Month;
                liveAnchorMonthlyTarget.MonthlyTargetName = updateDto.MonthlyTargetName;
                liveAnchorMonthlyTarget.LiveAnchorId = updateDto.LiveAnchorId;

                liveAnchorMonthlyTarget.TikTokReleaseTarget = updateDto.TikTokReleaseTarget;
                liveAnchorMonthlyTarget.ZhihuReleaseTarget = updateDto.ZhihuReleaseTarget;
                liveAnchorMonthlyTarget.XiaoHongShuReleaseTarget = updateDto.XiaoHongShuReleaseTarget;
                liveAnchorMonthlyTarget.SinaWeiBoReleaseTarget = updateDto.SinaWeiBoReleaseTarget;
                liveAnchorMonthlyTarget.VideoReleaseTarget = updateDto.VideoReleaseTarget;


                liveAnchorMonthlyTarget.TikTokFlowinvestmentTarget = updateDto.TikTokFlowinvestmentTarget;
                liveAnchorMonthlyTarget.ZhihuFlowinvestmentTarget = updateDto.ZhihuFlowinvestmentTarget;
                liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentTarget = updateDto.XiaoHongShuFlowinvestmentTarget;
                liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentTarget = updateDto.SinaWeiBoFlowinvestmentTarget;
                liveAnchorMonthlyTarget.VideoFlowinvestmentTarget = updateDto.VideoFlowinvestmentTarget;

                liveAnchorMonthlyTarget.ReleaseTarget = updateDto.ReleaseTarget;
                liveAnchorMonthlyTarget.FlowInvestmentTarget = updateDto.FlowInvestmentTarget;
                liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget = updateDto.LivingRoomFlowInvestmentTarget;
                liveAnchorMonthlyTarget.CluesTarget = updateDto.CluesTarget;
                liveAnchorMonthlyTarget.AddFansTarget = updateDto.AddFansTarget;
                liveAnchorMonthlyTarget.AddWechatTarget = updateDto.AddWechatTarget;
                liveAnchorMonthlyTarget.ConsultationTarget = updateDto.ConsultationTarget;
                liveAnchorMonthlyTarget.ConsultationCardConsumedTarget = updateDto.ConsultationCardConsumedTarget;
                liveAnchorMonthlyTarget.ConsultationTarget2 = updateDto.ConsultationTarget2;
                liveAnchorMonthlyTarget.ConsultationCardConsumedTarget2 = updateDto.ConsultationCardConsumedTarget2;
                liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget = updateDto.ActivateHistoricalConsultationTarget;
                liveAnchorMonthlyTarget.SendOrderTarget = updateDto.SendOrderTarget;
                liveAnchorMonthlyTarget.NewCustomerVisitTarget = updateDto.NewCustomerVisitTarget;
                liveAnchorMonthlyTarget.OldCustomerVisitTarget = updateDto.OldCustomerVisitTarget;
                liveAnchorMonthlyTarget.VisitTarget = updateDto.VisitTarget;
                liveAnchorMonthlyTarget.NewCustomerDealTarget = updateDto.NewCustomerDealTarget;
                liveAnchorMonthlyTarget.OldCustomerDealTarget = updateDto.OldCustomerDealTarget;
                liveAnchorMonthlyTarget.DealTarget = updateDto.DealTarget;
                liveAnchorMonthlyTarget.CargoSettlementCommissionTarget = updateDto.CargoSettlementCommissionTarget;
                liveAnchorMonthlyTarget.MinivanRefundTarget = updateDto.MinivanRefundTarget;
                liveAnchorMonthlyTarget.MiniVanBadReviewsTarget = updateDto.MiniVanBadReviewsTarget;
                liveAnchorMonthlyTarget.NewCustomerPerformanceTarget = updateDto.NewCustomerPerformanceTarget;
                liveAnchorMonthlyTarget.SubsequentPerformanceTarget = updateDto.SubsequentPerformanceTarget;
                liveAnchorMonthlyTarget.OldCustomerPerformanceTarget = updateDto.OldCustomerPerformanceTarget;
                liveAnchorMonthlyTarget.PerformanceTarget = updateDto.PerformanceTarget;
                await dalLiveAnchorMonthlyTarget.UpdateAsync(liveAnchorMonthlyTarget, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新每日数据时调用并且添加累计信息
        /// </summary>
        /// <param name="editDto"></param>
        /// <returns></returns>
        public async Task EditAsync(UpdateLiveAnchorMonthlyTargetRateAndNumDto editDto)
        {
            try
            {
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == editDto.Id);
                if (liveAnchorMonthlyTarget == null)
                    throw new Exception("主播月度运营目标情况编号错误！");

                #region #知乎发布
                liveAnchorMonthlyTarget.CumulativeZhihuRelease += editDto.CumulativeZhihuRelease;
                if (liveAnchorMonthlyTarget.CumulativeZhihuRelease <= 0)
                {
                    liveAnchorMonthlyTarget.ZhihuReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ZhihuReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeZhihuRelease) / Convert.ToDecimal(liveAnchorMonthlyTarget.ZhihuReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #知乎投流
                liveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment += editDto.CumulativeZhihuFlowinvestment;
                if (liveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTarget.ZhihuFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ZhihuFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTarget.ZhihuFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #视频号发布
                liveAnchorMonthlyTarget.CumulativeVideoRelease += editDto.CumulativeVideoRelease;
                if (liveAnchorMonthlyTarget.CumulativeVideoRelease <= 0)
                {
                    liveAnchorMonthlyTarget.VideoReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.VideoReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeVideoRelease) / Convert.ToDecimal(liveAnchorMonthlyTarget.VideoReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #视频号投流
                liveAnchorMonthlyTarget.CumulativeVideoFlowinvestment += editDto.CumulativeVideoFlowinvestment;
                if (liveAnchorMonthlyTarget.CumulativeVideoFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTarget.VideoFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.VideoFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeVideoFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTarget.VideoFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #抖音发布
                liveAnchorMonthlyTarget.CumulativeTikTokRelease += editDto.CumulativeTikTokRelease;
                if (liveAnchorMonthlyTarget.CumulativeTikTokRelease <= 0)
                {
                    liveAnchorMonthlyTarget.TikTokReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.TikTokReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeTikTokRelease) / Convert.ToDecimal(liveAnchorMonthlyTarget.TikTokReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #抖音投流
                liveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment += editDto.CumulativeTikTokFlowinvestment;
                if (liveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTarget.TikTokFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.TikTokFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTarget.TikTokFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #小红书发布
                liveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease += editDto.CumulativeXiaoHongShuRelease;
                if (liveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease <= 0)
                {
                    liveAnchorMonthlyTarget.XiaoHongShuReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.XiaoHongShuReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease) / Convert.ToDecimal(liveAnchorMonthlyTarget.XiaoHongShuReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #小红书投流
                liveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment += editDto.CumulativeXiaoHongShuFlowinvestment;
                if (liveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #微博发布
                liveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease += editDto.CumulativeSinaWeiBoRelease;
                if (liveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease <= 0)
                {
                    liveAnchorMonthlyTarget.SinaWeiBoReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.SinaWeiBoReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease) / Convert.ToDecimal(liveAnchorMonthlyTarget.SinaWeiBoReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #微博投流
                liveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment += editDto.CumulativeSinaWeiBoFlowinvestment;
                if (liveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #发布
                liveAnchorMonthlyTarget.CumulativeRelease += editDto.CumulativeRelease;
                if (liveAnchorMonthlyTarget.CumulativeRelease <= 0)
                {
                    liveAnchorMonthlyTarget.ReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeRelease) / Convert.ToDecimal(liveAnchorMonthlyTarget.ReleaseTarget)) * 100, 2);
                }
                #endregion

                #region #运营渠道投流
                liveAnchorMonthlyTarget.CumulativeFlowInvestment += editDto.CumulativeFlowInvestment;
                if (liveAnchorMonthlyTarget.CumulativeFlowInvestment <= 0)
                {
                    liveAnchorMonthlyTarget.FlowInvestmentCompleteRate = 0.00M;
                }
                else
                {

                    liveAnchorMonthlyTarget.FlowInvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeFlowInvestment) / Convert.ToDecimal(liveAnchorMonthlyTarget.FlowInvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #直播间投流
                liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment += editDto.LivingRoomCumulativeFlowInvestment;
                if (liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment <= 0)
                {
                    liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate = 0.00M;
                }
                else
                {

                    liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment) / Convert.ToDecimal(liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #线索量
                //liveAnchorMonthlyTarget.CumulativeClues += editDto.CumulativeCluesNum;
                //if (liveAnchorMonthlyTarget.CumulativeClues <= 0)
                //{
                //    liveAnchorMonthlyTarget.CluesCompleteRate = 0.00M;
                //}
                //else
                //{
                //    liveAnchorMonthlyTarget.CluesCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeClues) / Convert.ToDecimal(liveAnchorMonthlyTarget.CluesTarget)) * 100, 2);
                //}
                #endregion

                #region #涨粉量
                //liveAnchorMonthlyTarget.CumulativeAddFans += editDto.CumulativeAddFansNum;
                //if (liveAnchorMonthlyTarget.CumulativeAddFans <= 0)
                //{
                //    liveAnchorMonthlyTarget.AddFansCompleteRate = 0.00M;
                //}
                //else
                //{
                //    liveAnchorMonthlyTarget.AddFansCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeAddFans) / Convert.ToDecimal(liveAnchorMonthlyTarget.AddFansTarget)) * 100, 2);
                //}
                #endregion

                #region #加V量
                liveAnchorMonthlyTarget.CumulativeAddWechat += editDto.CumulativeAddWechat;
                if (liveAnchorMonthlyTarget.CumulativeAddWechat <= 0)
                {
                    liveAnchorMonthlyTarget.AddWechatCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.AddWechatCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeAddWechat) / Convert.ToDecimal(liveAnchorMonthlyTarget.AddWechatTarget)) * 100, 2);
                }
                #endregion

                #region #99面诊卡
                liveAnchorMonthlyTarget.CumulativeConsultation += editDto.CumulativeConsultation;
                if (liveAnchorMonthlyTarget.CumulativeConsultation <= 0)
                {
                    liveAnchorMonthlyTarget.ConsultationCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ConsultationCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeConsultation) / Convert.ToDecimal(liveAnchorMonthlyTarget.ConsultationTarget)) * 100, 2);
                }
                #endregion

                #region #99消耗卡
                liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed += editDto.CumulativeConsultationCardConsumed;
                if (liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed <= 0)
                {
                    liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed) / Convert.ToDecimal(liveAnchorMonthlyTarget.ConsultationCardConsumedTarget)) * 100, 2);
                }
                #endregion

                #region #199面诊卡
                liveAnchorMonthlyTarget.CumulativeConsultation2 += editDto.CumulativeConsultation2;
                if (liveAnchorMonthlyTarget.CumulativeConsultation2 <= 0)
                {
                    liveAnchorMonthlyTarget.ConsultationCompleteRate2 = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ConsultationCompleteRate2 = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeConsultation2) / Convert.ToDecimal(liveAnchorMonthlyTarget.ConsultationTarget2)) * 100, 2);
                }
                #endregion

                #region #199消耗卡
                liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 += editDto.CumulativeConsultationCardConsumed2;
                if (liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 <= 0)
                {
                    liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate2 = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate2 = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2) / Convert.ToDecimal(liveAnchorMonthlyTarget.ConsultationCardConsumedTarget2)) * 100, 2);
                }
                #endregion

                #region #激活历史面诊数量
                liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation += editDto.CumulativeActivateHistoricalConsultation;
                if (liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation <= 0)
                {
                    liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation) / Convert.ToDecimal(liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget)) * 100, 2);
                }
                #endregion

                #region #派单量
                liveAnchorMonthlyTarget.CumulativeSendOrder += editDto.CumulativeSendOrder;
                if (liveAnchorMonthlyTarget.CumulativeSendOrder <= 0)
                {
                    liveAnchorMonthlyTarget.SendOrderCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.SendOrderCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeSendOrder) / Convert.ToDecimal(liveAnchorMonthlyTarget.SendOrderTarget)) * 100, 2);
                }
                #endregion

                #region #新客上门数
                liveAnchorMonthlyTarget.CumulativeNewCustomerVisit += editDto.CumulativeNewCustomerVisit;
                if (liveAnchorMonthlyTarget.CumulativeNewCustomerVisit <= 0)
                {
                    liveAnchorMonthlyTarget.NewCustomerVisitCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.NewCustomerVisitCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeNewCustomerVisit) / Convert.ToDecimal(liveAnchorMonthlyTarget.NewCustomerVisitTarget)) * 100, 2);
                }
                #endregion

                #region #老客上门数
                liveAnchorMonthlyTarget.CumulativeOldCustomerVisit += editDto.CumulativeOldCustomerVisit;
                if (liveAnchorMonthlyTarget.CumulativeOldCustomerVisit <= 0)
                {
                    liveAnchorMonthlyTarget.OldCustomerVisitCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.OldCustomerVisitCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeOldCustomerVisit) / Convert.ToDecimal(liveAnchorMonthlyTarget.OldCustomerVisitTarget)) * 100, 2);
                }
                #endregion

                #region #上门数
                liveAnchorMonthlyTarget.CumulativeVisit += editDto.CumulativeVisit;
                if (liveAnchorMonthlyTarget.CumulativeVisit <= 0)
                {
                    liveAnchorMonthlyTarget.VisitCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.VisitCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeVisit) / Convert.ToDecimal(liveAnchorMonthlyTarget.VisitTarget)) * 100, 2);
                }
                #endregion

                #region #新诊成交数
                liveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget += editDto.CumulativeNewCustomerDealTarget;
                if (liveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget <= 0 || liveAnchorMonthlyTarget.CumulativeVisit <= 0)
                {
                    liveAnchorMonthlyTarget.NewCustomerDealRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.NewCustomerDealRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget) / Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeVisit)) * 100, 2);
                }
                #endregion

                #region #老客成交数
                liveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget += editDto.CumulativeOldCustomerDealTarget;
                if (liveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget <= 0 || liveAnchorMonthlyTarget.CumulativeVisit <= 0)
                {
                    liveAnchorMonthlyTarget.OldCustomerDealRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.OldCustomerDealRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget) / Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeVisit)) * 100, 2);
                }
                #endregion

                #region #成交数
                liveAnchorMonthlyTarget.CumulativeDealTarget += editDto.CumulativeDealTarget;
                if (liveAnchorMonthlyTarget.CumulativeDealTarget <= 0 || liveAnchorMonthlyTarget.CumulativeVisit <= 0)
                {
                    liveAnchorMonthlyTarget.DealRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.DealRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeDealTarget) / Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeVisit)) * 100, 2);
                }
                #endregion

                #region #带货佣金结算
                liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission += editDto.CumulativeCargoSettlementCommission;
                if (liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission <= 0)
                {
                    liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission) / Convert.ToDecimal(liveAnchorMonthlyTarget.CargoSettlementCommissionTarget)) * 100, 2);
                }
                #endregion

                #region #小黄车退单
                liveAnchorMonthlyTarget.CumulativeMinivanRefund += editDto.CumulativeMinivanRefund;
                if (liveAnchorMonthlyTarget.CumulativeMinivanRefund <= 0)
                {
                    liveAnchorMonthlyTarget.MinivanRefundCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.MinivanRefundCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeMinivanRefund) / Convert.ToDecimal(liveAnchorMonthlyTarget.MinivanRefundTarget)) * 100, 2);
                }
                #endregion

                #region #小黄车差评
                liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews += editDto.CumulativeMiniVanBadReviews;
                if (liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews <= 0)
                {
                    liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews) / Convert.ToDecimal(liveAnchorMonthlyTarget.MiniVanBadReviewsTarget)) * 100, 2);
                }
                #endregion

                #region #新诊业绩量
                liveAnchorMonthlyTarget.CumulativeNewCustomerPerformance += editDto.CumulativeNewCustomerPerformance;
                if (liveAnchorMonthlyTarget.CumulativeNewCustomerPerformance <= 0)
                {
                    liveAnchorMonthlyTarget.NewCustomerPerformanceCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.NewCustomerPerformanceCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeNewCustomerPerformance) / Convert.ToDecimal(liveAnchorMonthlyTarget.NewCustomerPerformanceTarget)) * 100, 2);
                }
                #endregion

                #region #复诊业绩量
                liveAnchorMonthlyTarget.CumulativeSubsequentPerformance += editDto.CumulativeSubsequentPerformance;
                if (liveAnchorMonthlyTarget.CumulativeSubsequentPerformance <= 0)
                {
                    liveAnchorMonthlyTarget.SubsequentPerformanceCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.SubsequentPerformanceCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeSubsequentPerformance) / Convert.ToDecimal(liveAnchorMonthlyTarget.SubsequentPerformanceTarget)) * 100, 2);
                }
                #endregion

                #region #老客业绩量
                liveAnchorMonthlyTarget.CumulativeOldCustomerPerformance += editDto.CumulativeOldCustomerPerformance;
                if (liveAnchorMonthlyTarget.CumulativeOldCustomerPerformance <= 0)
                {
                    liveAnchorMonthlyTarget.OldCustomerPerformanceCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.OldCustomerPerformanceCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeOldCustomerPerformance) / Convert.ToDecimal(liveAnchorMonthlyTarget.OldCustomerPerformanceTarget)) * 100, 2);
                }
                #endregion

                #region #业绩量
                liveAnchorMonthlyTarget.CumulativePerformance += editDto.CumulativePerformance;
                if (liveAnchorMonthlyTarget.CumulativePerformance <= 0)
                {
                    liveAnchorMonthlyTarget.PerformanceCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.PerformanceCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativePerformance) / Convert.ToDecimal(liveAnchorMonthlyTarget.PerformanceTarget)) * 100, 2);
                }
                #endregion

                await dalLiveAnchorMonthlyTarget.UpdateAsync(liveAnchorMonthlyTarget, true);
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
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (liveAnchorMonthlyTarget == null)
                    throw new Exception("主播月度运营目标情况编号错误");

                await dalLiveAnchorMonthlyTarget.DeleteAsync(liveAnchorMonthlyTarget, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<PerformanceInfoByDateDto>> GetLiveAnchorCommercePerformance(int year, int month, List<int> liveAnchorIds)
        {
            var list = dalLiveAnchorMonthlyTarget.GetAll()
                .Where(o => o.Year == year && o.Month >= 1 && o.Month <= month)
                .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.LiveAnchorId))
                .GroupBy(o => o.Month).OrderBy(o => o.Key).Select(o => new PerformanceInfoByDateDto
                {
                    Date = o.Key.ToString(),
                    PerfomancePrice = o.Sum(o => o.CumulativeCargoSettlementCommission)
                }).ToList();
            return list;
        }

        /// <summary>
        /// 带货业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorIds">各个平台的主播ID集合</param>
        /// <returns></returns>
        public async Task<LiveAnchorMonthTargetPerformanceDto> GetPerformance(int year, int month, List<int> liveAnchorIds)
        {
            var performance = dalLiveAnchorMonthlyTarget.GetAll().Where(t => t.Year == year && t.Month == month)
                .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.LiveAnchorId));
            LiveAnchorMonthTargetPerformanceDto performanceInfoDto = new LiveAnchorMonthTargetPerformanceDto
            {
                TotalPerformanceTarget = await performance.SumAsync(t => t.PerformanceTarget),
                CommercePerformanceTarget = await performance.SumAsync(t => t.CargoSettlementCommissionTarget),
                OldCustomerPerformanceTarget = await performance.SumAsync(t => t.OldCustomerPerformanceTarget),
                NewCustomerPerformanceTarget = await performance.SumAsync(t => t.NewCustomerPerformanceTarget),
                CommerceCompletePerformance = await performance.SumAsync(t => t.CumulativeCargoSettlementCommission),

            };
            return performanceInfoDto;
        }

        /// <summary>
        /// 根据平台id按年月获取数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        public async Task<GroupPerformanceListDto> GetCooperationLiveAnchorPerformance(int year, int month, string contentPlatFormId)
        {
            var performance = dalLiveAnchorMonthlyTarget.GetAll().Include(x => x.LiveAnchor).Where(t => t.Year == year && t.Month == month && t.LiveAnchor.ContentPlateFormId == contentPlatFormId);
            GroupPerformanceListDto performanceInfoDto = new GroupPerformanceListDto
            {
                GroupPerformance = await performance.SumAsync(t => t.CumulativePerformance),
                GroupTargetPerformance = await performance.SumAsync(t => t.PerformanceTarget),
            };
            return performanceInfoDto;
        }

        /// <summary>
        /// 根据主播基础id按年月获取数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        public async Task<GroupPerformanceListDto> GetLiveAnchorBaseIdPerformance(int year, int month, string liveAnchorBaseId)
        {
            var performance = dalLiveAnchorMonthlyTarget.GetAll().Include(x => x.LiveAnchor).Where(t => t.Year == year && t.Month == month && t.LiveAnchor.LiveAnchorBaseId == liveAnchorBaseId);
            GroupPerformanceListDto performanceInfoDto = new GroupPerformanceListDto
            {
                GroupPerformance = await performance.SumAsync(t => t.CumulativePerformance),
                GroupTargetPerformance = await performance.SumAsync(t => t.PerformanceTarget),
            };
            return performanceInfoDto;
        }

     

        /// <summary>
        /// 根据主播基础id按年月获取折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceByBaseIdBrokenLineAsync(int year, string liveAnchorBaseId)
        {
            var orderinfo = await dalLiveAnchorMonthlyTarget.GetAll().Include(x => x.LiveAnchor).Where(o => o.Year == year && o.LiveAnchor.LiveAnchorBaseId == liveAnchorBaseId).ToListAsync();

            return orderinfo.GroupBy(x => x.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Sum(z => z.CumulativePerformance) }).ToList();
        }


        /// <summary>
        /// 基础经营看板业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorIds">各个平台的主播ID集合</param>
        /// <returns></returns>
        public async Task<LiveAnchorBaseBusinessMonthTargetPerformanceDto> GetBasePerformanceTargetAsync(int year, int month, List<int> liveAnchorIds)
        {
            var performance = dalLiveAnchorMonthlyTarget.GetAll().Where(t => t.Year == year && t.Month == month)
                .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.LiveAnchorId));
            LiveAnchorBaseBusinessMonthTargetPerformanceDto performanceInfoDto = new LiveAnchorBaseBusinessMonthTargetPerformanceDto
            {
                AddWeChatTarget = await performance.SumAsync(t => t.AddWechatTarget),
                ConsulationCardTarget = await performance.SumAsync(t => t.ConsultationTarget + t.ConsultationTarget2),
                ConsulationCardConsumedTarget = await performance.SumAsync(t => t.ConsultationCardConsumedTarget + t.ConsultationCardConsumedTarget2),
                HistoryConsulationCardConsumedTarget = await performance.SumAsync(t => t.ActivateHistoricalConsultationTarget),
                ConsulationCardRefundTarget = await performance.SumAsync(t => t.MinivanRefundTarget),

            };
            return performanceInfoDto;
        }

        /// <summary>
        /// 派单成交看板业绩目标
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorIds">各个平台的主播ID集合</param>
        /// <returns></returns>
        public async Task<LiveAnchorBaseBusinessMonthTargetSendOrDealDto> GetSendOrDealTargetAsync(int year, int month, List<int> liveAnchorIds)
        {
            var performance = dalLiveAnchorMonthlyTarget.GetAll().Where(t => t.Year == year && t.Month == month)
                .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.LiveAnchorId));
            LiveAnchorBaseBusinessMonthTargetSendOrDealDto performanceInfoDto = new LiveAnchorBaseBusinessMonthTargetSendOrDealDto
            {
                SendOrderTarget = await performance.SumAsync(t => t.SendOrderTarget),
                TotalVisitTarget = await performance.SumAsync(t => t.VisitTarget),
                NewCustomerVisitTarget = await performance.SumAsync(t => t.NewCustomerVisitTarget),
                OldCustomerVisitTarget = await performance.SumAsync(t => t.OldCustomerVisitTarget),
                TotalDealTarget = await performance.SumAsync(t => t.DealTarget),
                NewCustomerDealTarget = await performance.SumAsync(t => t.NewCustomerDealTarget),
                OldCustomerDealTarget = await performance.SumAsync(t => t.OldCustomerDealTarget),

            };
            return performanceInfoDto;
        }

    }
}
