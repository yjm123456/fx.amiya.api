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
        private IEmployeeBindLiveAnchorService employeeBindLiveAnchorService;

        public LiveAnchorDailyTargetService(IDalLiveAnchorDailyTarget dalLiveAnchorDailyTarget,
            ILiveAnchorService liveAnchorService,
            IUnitOfWork unitOfWork,
            IEmployeeBindLiveAnchorService employeeBindLiveAnchorService,
            ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService,
            IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.unitOfWork = unitOfWork;
            this.dalLiveAnchorDailyTarget = dalLiveAnchorDailyTarget;
            _liveanchorService = liveAnchorService;
            _liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
            _amiyaEmployeeService = amiyaEmployeeService;
            this.employeeBindLiveAnchorService = employeeBindLiveAnchorService;
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
        public async Task<FxPageInfo<LiveAnchorDailyTargetDto>> GetListWithPageAsync(DateTime startDate, DateTime endDate, int? operationEmpId, int? netWorkConEmpId, int? liveAnchorId, int pageNum, int pageSize, int employeeId)
        {
            try
            {
                List<int> liveAnchorIds = new List<int>();
                if (liveAnchorId.HasValue)
                {
                    liveAnchorIds.Add(liveAnchorId.Value);
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
                endDate = endDate.AddDays(1);

                var result = from d in dalLiveAnchorDailyTarget.GetAll().Include(e => e.LiveAnchorMonthlyTarget).ThenInclude(k => k.LiveAnchor)
                             where d.RecordDate >= startDate && d.RecordDate < endDate
                             && (operationEmpId.HasValue == false || d.TikTokOperationEmployeeId == operationEmpId)
                             && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTarget.LiveAnchorId))
                             && (netWorkConEmpId.HasValue == false || d.NetWorkConsultingEmployeeId == netWorkConEmpId)
                             select new LiveAnchorDailyTargetDto
                             {
                                 Id = d.Id,
                                 LiveanchorMonthlyTargetId = d.LiveanchorMonthlyTargetId,
                                 LiveAnchorId = d.LiveAnchorMonthlyTarget.LiveAnchorId,
                                 LiveAnchor = d.LiveAnchorMonthlyTarget.LiveAnchor.Name,
                                 CreateDate = d.CreateDate,
                                 RecordDate = d.RecordDate,
                                 LivingTrackingEmployeeId = d.LivingTrackingEmployeeId,
                                 NetWorkConsultingEmployeeId = d.NetWorkConsultingEmployeeId,

                                 TikTokOperationEmployeeId = d.TikTokOperationEmployeeId,
                                 TikTokSendNum = d.TikTokSendNum,
                                 TikTokFlowInvestmentNum = d.TikTokFlowInvestmentNum,

                                 SinaWeiBoOperationEmployeeId = d.SinaWeiBoOperationEmployeeId,
                                 SinaWeiBoSendNum = d.SinaWeiBoSendNum,
                                 SinaWeiBoFlowInvestmentNum = d.SinaWeiBoFlowInvestmentNum,

                                 XiaoHongShuOperationEmployeeId = d.XiaoHongShuOperationEmployeeId,
                                 XiaoHongShuSendNum = d.XiaoHongShuSendNum,
                                 XiaoHongShuFlowInvestmentNum = d.XiaoHongShuFlowInvestmentNum,

                                 ZhihuOperationEmployeeId = d.ZhihuOperationEmployeeId,
                                 ZhihuSendNum = d.ZhihuSendNum,
                                 ZhihuFlowInvestmentNum = d.ZhihuFlowInvestmentNum,

                                 VideoOperationEmployeeId = d.VideoOperationEmployeeId,
                                 VideoSendNum = d.VideoSendNum,
                                 VideoFlowInvestmentNum = d.VideoFlowInvestmentNum,

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
                                 TikTokUpdateDate=d.TikTokUpdateDate,
                                 LivingUpdateDate=d.LivingUpdateDate,
                                 AfterLivingUpdateDate=d.AfterLivingUpdateDate
                             };

                FxPageInfo<LiveAnchorDailyTargetDto> liveAnchorDailyTargetPageInfo = new FxPageInfo<LiveAnchorDailyTargetDto>();
                liveAnchorDailyTargetPageInfo.TotalCount = await result.CountAsync();
                var diaryTargetInfo = await result.OrderByDescending(x => x.CreateDate).ToListAsync();
                List<LiveAnchorDailyTargetDto> resultList = new List<LiveAnchorDailyTargetDto>();
                resultList = diaryTargetInfo.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                foreach (var x in resultList)
                {
                   
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

                    if (x.TikTokOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.TikTokOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.TikTokOperationEmployeeName = operationEmployee.Name;
                        }
                    }

                    if (x.VideoOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.VideoOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.VideoOperationEmployeeName = operationEmployee.Name;
                        }
                    }

                    if (x.ZhihuOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.ZhihuOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.ZhihuOperationEmployeeName = operationEmployee.Name;
                        }
                    }

                    if (x.XiaoHongShuOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.XiaoHongShuOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.XiaoHongShuOperationEmployeeName = operationEmployee.Name;
                        }
                    }


                    if (x.SinaWeiBoOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.SinaWeiBoOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.SinaWeiBoOperationEmployeeName = operationEmployee.Name;
                        }
                    }
                }
                liveAnchorDailyTargetPageInfo.List = resultList;
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
                                      where (d.RecordDate == recordDate) && (d.LiveanchorMonthlyTargetId == monthlyTargetId)
                                      select new LiveAnchorDailyTargetDto
                                      {
                                          Id = d.Id,
                                      };
            var selectResult = await liveAnchorDiaryInfo.FirstOrDefaultAsync();
            return selectResult;
        }

        public async Task<LiveAnchorDailyTargetDto> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().Include(x => x.LiveAnchorMonthlyTarget).SingleOrDefaultAsync(e => e.Id == id);
                if (liveAnchorDailyTarget == null)
                {
                    throw new Exception("主播日运营目标情况编号错误！");
                }

                LiveAnchorDailyTargetDto liveAnchorDailyTargetDto = new LiveAnchorDailyTargetDto();
                liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                liveAnchorDailyTargetDto.LiveAnchorId = liveAnchorDailyTarget.LiveAnchorMonthlyTarget.LiveAnchorId;
                liveAnchorDailyTargetDto.LivingTrackingEmployeeId = liveAnchorDailyTarget.LivingTrackingEmployeeId;
                liveAnchorDailyTargetDto.NetWorkConsultingEmployeeId = liveAnchorDailyTarget.NetWorkConsultingEmployeeId;

                liveAnchorDailyTargetDto.TikTokOperationEmployeeId = liveAnchorDailyTarget.TikTokOperationEmployeeId;
                liveAnchorDailyTargetDto.TikTokSendNum = liveAnchorDailyTarget.TikTokSendNum;
                liveAnchorDailyTargetDto.TikTokFlowInvestmentNum = liveAnchorDailyTarget.TikTokFlowInvestmentNum;

                liveAnchorDailyTargetDto.ZhihuOperationEmployeeId = liveAnchorDailyTarget.ZhihuOperationEmployeeId;
                liveAnchorDailyTargetDto.ZhihuSendNum = liveAnchorDailyTarget.ZhihuSendNum;
                liveAnchorDailyTargetDto.ZhihuFlowInvestmentNum = liveAnchorDailyTarget.ZhihuFlowInvestmentNum;

                liveAnchorDailyTargetDto.XiaoHongShuOperationEmployeeId = liveAnchorDailyTarget.XiaoHongShuOperationEmployeeId;
                liveAnchorDailyTargetDto.XiaoHongShuSendNum = liveAnchorDailyTarget.XiaoHongShuSendNum;
                liveAnchorDailyTargetDto.XiaoHongShuFlowInvestmentNum = liveAnchorDailyTarget.XiaoHongShuFlowInvestmentNum;

                liveAnchorDailyTargetDto.SinaWeiBoOperationEmployeeId = liveAnchorDailyTarget.SinaWeiBoOperationEmployeeId;
                liveAnchorDailyTargetDto.SinaWeiBoSendNum = liveAnchorDailyTarget.SinaWeiBoSendNum;
                liveAnchorDailyTargetDto.SinaWeiBoFlowInvestmentNum = liveAnchorDailyTarget.SinaWeiBoFlowInvestmentNum;

                liveAnchorDailyTargetDto.VideoOperationEmployeeId = liveAnchorDailyTarget.VideoOperationEmployeeId;
                liveAnchorDailyTargetDto.VideoSendNum = liveAnchorDailyTarget.VideoSendNum;
                liveAnchorDailyTargetDto.VideoFlowInvestmentNum = liveAnchorDailyTarget.VideoFlowInvestmentNum;


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

                return liveAnchorDailyTargetDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                liveAnchorDailyTarget.TikTokOperationEmployeeId = addDto.OperationEmployeeId;
                liveAnchorDailyTarget.NetWorkConsultingEmployeeId = addDto.NetWorkConsultingEmployeeId.HasValue ? addDto.NetWorkConsultingEmployeeId.Value : 0;
                liveAnchorDailyTarget.SinaWeiBoSendNum = addDto.SinaWeiBoSendNum;
                liveAnchorDailyTarget.ZhihuSendNum = addDto.ZhihuSendNum;
                liveAnchorDailyTarget.XiaoHongShuSendNum = addDto.XiaoHongShuSendNum;
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

                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit = addDto.NewVisitNum.HasValue ? addDto.NewVisitNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit += addDto.SubsequentVisitNum.HasValue ? addDto.SubsequentVisitNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerVisit = addDto.OldCustomerVisitNum.HasValue ? addDto.OldCustomerVisitNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeVisit = addDto.VisitNum.HasValue ? addDto.VisitNum.Value : 0;


                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = addDto.NewDealNum.HasValue ? addDto.NewDealNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget += addDto.SubsequentDealNum.HasValue ? addDto.SubsequentDealNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = addDto.OldCustomerDealNum.HasValue ? addDto.OldCustomerDealNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeDealTarget = addDto.DealNum.HasValue ? addDto.DealNum.Value : 0;

                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = addDto.CargoSettlementCommission;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = addDto.NewPerformanceNum.HasValue ? addDto.NewPerformanceNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeSubsequentPerformance = addDto.SubsequentPerformanceNum.HasValue ? addDto.SubsequentPerformanceNum.Value : 0;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = addDto.OldCustomerPerformanceNum.HasValue ? addDto.OldCustomerPerformanceNum.Value : 0;
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
        public async Task UpdateAsync(UpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (updateDto.Id != liveAnchorDailyTarget.Id)
                {
                    unitOfWork.RollBack();
                    throw new Exception("修改内容与当前数据编号不一致，请重新操作！");
                }
                if (liveAnchorDailyTarget == null)
                {
                    unitOfWork.RollBack();
                    throw new Exception("主播日运营目标情况编号错误！");
                }
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

                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit = -liveAnchorDailyTarget.NewVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit -= liveAnchorDailyTarget.SubsequentVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerVisit = -liveAnchorDailyTarget.OldCustomerVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeVisit = -liveAnchorDailyTarget.VisitNum;

                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = -liveAnchorDailyTarget.NewDealNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget -= liveAnchorDailyTarget.SubsequentDealNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = -liveAnchorDailyTarget.OldCustomerDealNum;
                editLiveAnchorMonthlyTarget.CumulativeDealTarget = -liveAnchorDailyTarget.DealNum;
                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = -liveAnchorDailyTarget.CargoSettlementCommission;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = -liveAnchorDailyTarget.NewPerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeSubsequentPerformance = -liveAnchorDailyTarget.SubsequentPerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = -liveAnchorDailyTarget.OldCustomerPerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativePerformance = -liveAnchorDailyTarget.PerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = -liveAnchorDailyTarget.MinivanRefund;
                editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = -liveAnchorDailyTarget.MiniVanBadReviews;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.TikTokOperationEmployeeId = updateDto.OperationEmployeeId;
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
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = updateDto.LivingRoomFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeCluesNum = updateDto.CluesNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeAddFansNum = updateDto.AddFansNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeAddWechat = updateDto.AddWechatNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultation = updateDto.Consultation;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultation2 = updateDto.Consultation2;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = updateDto.ConsultationCardConsumed;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = updateDto.ConsultationCardConsumed2;
                lasteditLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = updateDto.ActivateHistoricalConsultation;
                lasteditLiveAnchorMonthlyTarget.CumulativeSendOrder = updateDto.SendOrderNum;

                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit = updateDto.NewVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit += updateDto.SubsequentVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerVisit = updateDto.OldCustomerVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeVisit = updateDto.VisitNum;


                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = updateDto.NewDealNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget += updateDto.SubsequentDealNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = updateDto.OldCustomerDealNum;
                editLiveAnchorMonthlyTarget.CumulativeDealTarget = updateDto.DealNum;

                lasteditLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = updateDto.CargoSettlementCommission;
                lasteditLiveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = updateDto.NewPerformanceNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeSubsequentPerformance = updateDto.SubsequentPerformanceNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = updateDto.OldCustomerPerformanceNum;
                lasteditLiveAnchorMonthlyTarget.CumulativePerformance = updateDto.PerformanceNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeMinivanRefund = updateDto.MinivanRefund;
                lasteditLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = updateDto.MiniVanBadReviews;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        #region 【直播前】

        #region[抖音]
        /// <summary>
        /// 抖音添加数据
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingTikTokAddAsync(BeforeLivingTikTokAddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                LiveAnchorDailyTarget liveAnchorDailyTarget = new LiveAnchorDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.TikTokOperationEmployeeId = addDto.TikTokOperationEmployeeId;
                liveAnchorDailyTarget.TikTokFlowInvestmentNum = addDto.TikTokFlowInvestmentNum;
                liveAnchorDailyTarget.TikTokSendNum = addDto.TikTokSendNum;
                liveAnchorDailyTarget.TodaySendNum = addDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = addDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = addDto.CluesNum;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                await dalLiveAnchorDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeTikTokRelease = addDto.TikTokSendNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = addDto.TikTokFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = addDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = addDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 抖音修改数据
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingTikTokUpdateAsync(BeforeLivingTikTokUpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (updateDto.Id != liveAnchorDailyTarget.Id)
                {
                    unitOfWork.RollBack();
                    throw new Exception("修改内容与当前数据编号不一致，请重新操作！");
                }
                if (liveAnchorDailyTarget == null)
                {
                    unitOfWork.RollBack();
                    throw new Exception("主播日运营目标情况编号错误！");
                }
                //先扣除原有的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeTikTokRelease = -liveAnchorDailyTarget.TikTokSendNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = -liveAnchorDailyTarget.TikTokFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.TikTokOperationEmployeeId = updateDto.TikTokOperationEmployeeId;
                liveAnchorDailyTarget.TikTokFlowInvestmentNum = updateDto.TikTokFlowInvestmentNum;
                liveAnchorDailyTarget.TikTokSendNum = updateDto.TikTokSendNum;
                liveAnchorDailyTarget.TodaySendNum = updateDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = updateDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = updateDto.CluesNum;
               
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                liveAnchorDailyTarget.TikTokUpdateDate = DateTime.Now;
                await dalLiveAnchorDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeTikTokRelease = updateDto.TikTokSendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = updateDto.TikTokFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = updateDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = updateDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        #endregion

        #region[知乎]
        /// <summary>
        /// 知乎添加数据
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingZhihuAddAsync(BeforeLivingZhihuAddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                LiveAnchorDailyTarget liveAnchorDailyTarget = new LiveAnchorDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.ZhihuOperationEmployeeId = addDto.ZhihuOperationEmployeeId;
                liveAnchorDailyTarget.ZhihuFlowInvestmentNum = addDto.ZhihuFlowInvestmentNum;
                liveAnchorDailyTarget.ZhihuSendNum = addDto.ZhihuSendNum;
                liveAnchorDailyTarget.TodaySendNum = addDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = addDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = addDto.CluesNum;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                await dalLiveAnchorDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeZhihuRelease = addDto.ZhihuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment = addDto.ZhihuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = addDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = addDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 知乎修改数据
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingZhihuUpdateAsync(BeforeLivingZhihuUpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (updateDto.Id != liveAnchorDailyTarget.Id)
                {
                    unitOfWork.RollBack();
                    throw new Exception("修改内容与当前数据编号不一致，请重新操作！");
                }
                if (liveAnchorDailyTarget == null)
                {
                    unitOfWork.RollBack();
                    throw new Exception("主播日运营目标情况编号错误！");
                }
                //先扣除原有的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeZhihuRelease = -liveAnchorDailyTarget.ZhihuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment = -liveAnchorDailyTarget.ZhihuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.ZhihuOperationEmployeeId = updateDto.ZhihuOperationEmployeeId;
                liveAnchorDailyTarget.ZhihuFlowInvestmentNum = updateDto.ZhihuFlowInvestmentNum;
                liveAnchorDailyTarget.ZhihuSendNum = updateDto.ZhihuSendNum;
                liveAnchorDailyTarget.TodaySendNum = updateDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = updateDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = updateDto.CluesNum;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                await dalLiveAnchorDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeZhihuRelease = updateDto.ZhihuSendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment = updateDto.ZhihuFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = updateDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = updateDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        #endregion

        #region[小红书]
        /// <summary>
        /// 小红书添加数据
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingXiaoHongShuAddAsync(BeforeLivingXiaoHongShuAddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                LiveAnchorDailyTarget liveAnchorDailyTarget = new LiveAnchorDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.XiaoHongShuOperationEmployeeId = addDto.XiaoHongShuOperationEmployeeId;
                liveAnchorDailyTarget.XiaoHongShuFlowInvestmentNum = addDto.XiaoHongShuFlowInvestmentNum;
                liveAnchorDailyTarget.XiaoHongShuSendNum = addDto.XiaoHongShuSendNum;
                liveAnchorDailyTarget.TodaySendNum = addDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = addDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = addDto.CluesNum;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                await dalLiveAnchorDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = addDto.XiaoHongShuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = addDto.XiaoHongShuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = addDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = addDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 小红书修改数据
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingXiaoHongShuUpdateAsync(BeforeLivingXiaoHongShuUpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (updateDto.Id != liveAnchorDailyTarget.Id)
                {
                    unitOfWork.RollBack();
                    throw new Exception("修改内容与当前数据编号不一致，请重新操作！");
                }
                if (liveAnchorDailyTarget == null)
                {
                    unitOfWork.RollBack();
                    throw new Exception("主播日运营目标情况编号错误！");
                }
                //先扣除原有的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = -liveAnchorDailyTarget.XiaoHongShuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = -liveAnchorDailyTarget.XiaoHongShuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.XiaoHongShuOperationEmployeeId = updateDto.XiaoHongShuOperationEmployeeId;
                liveAnchorDailyTarget.XiaoHongShuFlowInvestmentNum = updateDto.XiaoHongShuFlowInvestmentNum;
                liveAnchorDailyTarget.XiaoHongShuSendNum = updateDto.XiaoHongShuSendNum;
                liveAnchorDailyTarget.TodaySendNum = updateDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = updateDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = updateDto.CluesNum;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                await dalLiveAnchorDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = updateDto.XiaoHongShuSendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = updateDto.XiaoHongShuFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = updateDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = updateDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        #endregion

        #region[微博]
        /// <summary>
        /// 微博添加数据
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingSinaWeiBoAddAsync(BeforeLivingSinaWeiBoAddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                LiveAnchorDailyTarget liveAnchorDailyTarget = new LiveAnchorDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.SinaWeiBoOperationEmployeeId = addDto.SinaWeiBoOperationEmployeeId;
                liveAnchorDailyTarget.SinaWeiBoFlowInvestmentNum = addDto.SinaWeiBoFlowInvestmentNum;
                liveAnchorDailyTarget.SinaWeiBoSendNum = addDto.SinaWeiBoSendNum;
                liveAnchorDailyTarget.TodaySendNum = addDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = addDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = addDto.CluesNum;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                await dalLiveAnchorDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease = addDto.SinaWeiBoSendNum;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment = addDto.SinaWeiBoFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = addDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = addDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 微博修改数据
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingSinaWeiBoUpdateAsync(BeforeLivingSinaWeiBoUpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (updateDto.Id != liveAnchorDailyTarget.Id)
                {
                    unitOfWork.RollBack();
                    throw new Exception("修改内容与当前数据编号不一致，请重新操作！");
                }
                if (liveAnchorDailyTarget == null)
                {
                    unitOfWork.RollBack();
                    throw new Exception("主播日运营目标情况编号错误！");
                }
                //先扣除原有的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease = -liveAnchorDailyTarget.SinaWeiBoSendNum;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment = -liveAnchorDailyTarget.SinaWeiBoFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.SinaWeiBoOperationEmployeeId = updateDto.SinaWeiBoOperationEmployeeId;
                liveAnchorDailyTarget.SinaWeiBoFlowInvestmentNum = updateDto.SinaWeiBoFlowInvestmentNum;
                liveAnchorDailyTarget.SinaWeiBoSendNum = updateDto.SinaWeiBoSendNum;
                liveAnchorDailyTarget.TodaySendNum = updateDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = updateDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = updateDto.CluesNum;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                await dalLiveAnchorDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease = updateDto.SinaWeiBoSendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment = updateDto.SinaWeiBoFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = updateDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = updateDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        #endregion

        #region[视频号]
        /// <summary>
        /// 视频号添加数据
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingVideoAddAsync(BeforeLivingVideoAddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                LiveAnchorDailyTarget liveAnchorDailyTarget = new LiveAnchorDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.VideoOperationEmployeeId = addDto.VideoOperationEmployeeId;
                liveAnchorDailyTarget.VideoFlowInvestmentNum = addDto.VideoFlowInvestmentNum;
                liveAnchorDailyTarget.VideoSendNum = addDto.VideoSendNum;
                liveAnchorDailyTarget.TodaySendNum = addDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = addDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = addDto.CluesNum;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                await dalLiveAnchorDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeVideoRelease = addDto.VideoSendNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = addDto.VideoFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = addDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = addDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 视频号修改数据
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task BeforeLivingVideoUpdateAsync(BeforeLivingVideoUpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (updateDto.Id != liveAnchorDailyTarget.Id)
                {
                    unitOfWork.RollBack();
                    throw new Exception("修改内容与当前数据编号不一致，请重新操作！");
                }
                if (liveAnchorDailyTarget == null)
                {
                    unitOfWork.RollBack();
                    throw new Exception("主播日运营目标情况编号错误！");
                }
                //先扣除原有的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeVideoRelease = -liveAnchorDailyTarget.VideoSendNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = -liveAnchorDailyTarget.VideoFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.VideoOperationEmployeeId = updateDto.VideoOperationEmployeeId;
                liveAnchorDailyTarget.VideoFlowInvestmentNum = updateDto.VideoFlowInvestmentNum;
                liveAnchorDailyTarget.VideoSendNum = updateDto.VideoSendNum;
                liveAnchorDailyTarget.TodaySendNum = updateDto.TodaySendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                //liveAnchorDailyTarget.AddFansNum = updateDto.AddFansNum;
                //liveAnchorDailyTarget.CluesNum = updateDto.CluesNum;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                await dalLiveAnchorDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeVideoRelease = updateDto.VideoSendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = updateDto.VideoFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = updateDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = updateDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        #endregion

        #endregion
        #region 【直播中】
        public async Task LivingAddAsync(LivingAddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                LiveAnchorDailyTarget liveAnchorDailyTarget = new LiveAnchorDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.LivingTrackingEmployeeId = addDto.LivingTrackingEmployeeId;
                liveAnchorDailyTarget.LivingRoomFlowInvestmentNum = addDto.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTarget.Consultation = addDto.Consultation;
                liveAnchorDailyTarget.Consultation2 = addDto.Consultation2;
                liveAnchorDailyTarget.CargoSettlementCommission = addDto.CargoSettlementCommission;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;               
                await dalLiveAnchorDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = addDto.LivingRoomFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeConsultation = addDto.Consultation;
                editLiveAnchorMonthlyTarget.CumulativeConsultation2 = addDto.Consultation2;
                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = addDto.CargoSettlementCommission;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task LivingUpdateAsync(LivingUpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (updateDto.Id != liveAnchorDailyTarget.Id)
                {
                    unitOfWork.RollBack();
                    throw new Exception("修改内容与当前数据编号不一致，请重新操作！");
                }
                if (liveAnchorDailyTarget == null)
                {
                    unitOfWork.RollBack();
                    throw new Exception("主播日运营目标情况编号错误！");
                }
                //先扣除原有的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = -liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeConsultation = -liveAnchorDailyTarget.Consultation;
                editLiveAnchorMonthlyTarget.CumulativeConsultation2 = -liveAnchorDailyTarget.Consultation2;
                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = -liveAnchorDailyTarget.CargoSettlementCommission;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.LivingTrackingEmployeeId = updateDto.LivingTrackingEmployeeId;
                liveAnchorDailyTarget.LivingRoomFlowInvestmentNum = updateDto.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTarget.Consultation = updateDto.Consultation;
                liveAnchorDailyTarget.Consultation2 = updateDto.Consultation2;
                liveAnchorDailyTarget.CargoSettlementCommission = updateDto.CargoSettlementCommission;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                liveAnchorDailyTarget.LivingUpdateDate = DateTime.Now;
                await dalLiveAnchorDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                //添加修改后的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = updateDto.LivingRoomFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultation = updateDto.Consultation;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultation2 = updateDto.Consultation2;
                lasteditLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = updateDto.CargoSettlementCommission;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        #endregion

        #region 【直播后】
        public async Task AfterLivingAddAsync(AfterLivingAddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                LiveAnchorDailyTarget liveAnchorDailyTarget = new LiveAnchorDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.NetWorkConsultingEmployeeId = addDto.NetWorkConsultingEmployeeId;

                liveAnchorDailyTarget.ConsultationCardConsumed = addDto.ConsultationCardConsumed;
                liveAnchorDailyTarget.ConsultationCardConsumed2 = addDto.ConsultationCardConsumed2;
                liveAnchorDailyTarget.ActivateHistoricalConsultation = addDto.ActivateHistoricalConsultation;
                liveAnchorDailyTarget.AddWechatNum = addDto.AddWechatNum;
                liveAnchorDailyTarget.SendOrderNum = addDto.SendOrderNum;
                liveAnchorDailyTarget.NewVisitNum = addDto.NewVisitNum;
                liveAnchorDailyTarget.SubsequentVisitNum = addDto.SubsequentVisitNum;
                liveAnchorDailyTarget.OldCustomerVisitNum = addDto.OldCustomerVisitNum;
                liveAnchorDailyTarget.VisitNum = addDto.VisitNum;
                liveAnchorDailyTarget.NewDealNum = addDto.NewDealNum;
                liveAnchorDailyTarget.SubsequentDealNum = addDto.SubsequentDealNum;
                liveAnchorDailyTarget.OldCustomerDealNum = addDto.OldCustomerDealNum;
                liveAnchorDailyTarget.DealNum = addDto.DealNum;
                liveAnchorDailyTarget.NewPerformanceNum = addDto.NewPerformanceNum;
                liveAnchorDailyTarget.SubsequentPerformanceNum = addDto.SubsequentPerformanceNum;
                liveAnchorDailyTarget.NewCustomerPerformanceCountNum = addDto.NewCustomerPerformanceCountNum;
                liveAnchorDailyTarget.OldCustomerPerformanceNum = addDto.OldCustomerPerformanceNum;
                liveAnchorDailyTarget.PerformanceNum = addDto.PerformanceNum;
                liveAnchorDailyTarget.MinivanRefund = addDto.MinivanRefund;
                liveAnchorDailyTarget.MiniVanBadReviews = addDto.MiniVanBadReviews;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                await dalLiveAnchorDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = addDto.ConsultationCardConsumed;
                editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = addDto.ConsultationCardConsumed2;
                editLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = addDto.ActivateHistoricalConsultation;
                editLiveAnchorMonthlyTarget.CumulativeAddWechat = addDto.AddWechatNum;
                editLiveAnchorMonthlyTarget.CumulativeSendOrder = addDto.SendOrderNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit = addDto.NewVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit += addDto.SubsequentVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerVisit = addDto.OldCustomerVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeVisit = addDto.VisitNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = addDto.NewDealNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget += addDto.SubsequentDealNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = addDto.OldCustomerDealNum;
                editLiveAnchorMonthlyTarget.CumulativeDealTarget = addDto.DealNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = addDto.NewPerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeSubsequentPerformance = addDto.SubsequentPerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = addDto.OldCustomerPerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativePerformance = addDto.PerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = addDto.MinivanRefund;
                editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = addDto.MiniVanBadReviews;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task AfterLivingUpdateAsync(AfterLivingUpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (updateDto.Id != liveAnchorDailyTarget.Id)
                {
                    unitOfWork.RollBack();
                    throw new Exception("修改内容与当前数据编号不一致，请重新操作！");
                }
                if (liveAnchorDailyTarget == null)
                {
                    unitOfWork.RollBack();
                    throw new Exception("主播日运营目标情况编号错误！");
                }
                //先扣除原有的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTargetDel = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTargetDel.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTargetDel.CumulativeConsultationCardConsumed = -liveAnchorDailyTarget.ConsultationCardConsumed;
                editLiveAnchorMonthlyTargetDel.CumulativeConsultationCardConsumed2 = -liveAnchorDailyTarget.ConsultationCardConsumed2;
                editLiveAnchorMonthlyTargetDel.CumulativeActivateHistoricalConsultation = -liveAnchorDailyTarget.ActivateHistoricalConsultation;
                editLiveAnchorMonthlyTargetDel.CumulativeAddWechat = -liveAnchorDailyTarget.AddWechatNum;
                editLiveAnchorMonthlyTargetDel.CumulativeSendOrder = -liveAnchorDailyTarget.SendOrderNum;
                editLiveAnchorMonthlyTargetDel.CumulativeNewCustomerVisit = -liveAnchorDailyTarget.NewVisitNum;
                editLiveAnchorMonthlyTargetDel.CumulativeNewCustomerVisit -= liveAnchorDailyTarget.SubsequentVisitNum;
                editLiveAnchorMonthlyTargetDel.CumulativeOldCustomerVisit = -liveAnchorDailyTarget.OldCustomerVisitNum;
                editLiveAnchorMonthlyTargetDel.CumulativeVisit = -liveAnchorDailyTarget.VisitNum;
                editLiveAnchorMonthlyTargetDel.CumulativeNewCustomerDealTarget = -liveAnchorDailyTarget.NewDealNum;
                editLiveAnchorMonthlyTargetDel.CumulativeNewCustomerDealTarget -= liveAnchorDailyTarget.SubsequentDealNum;
                editLiveAnchorMonthlyTargetDel.CumulativeOldCustomerDealTarget = -liveAnchorDailyTarget.OldCustomerDealNum;
                editLiveAnchorMonthlyTargetDel.CumulativeDealTarget = -liveAnchorDailyTarget.DealNum;
                editLiveAnchorMonthlyTargetDel.CumulativeNewCustomerPerformance = -liveAnchorDailyTarget.NewPerformanceNum;
                editLiveAnchorMonthlyTargetDel.CumulativeSubsequentPerformance = -liveAnchorDailyTarget.SubsequentPerformanceNum;
                editLiveAnchorMonthlyTargetDel.CumulativeOldCustomerPerformance = -liveAnchorDailyTarget.OldCustomerPerformanceNum;
                editLiveAnchorMonthlyTargetDel.CumulativePerformance = -liveAnchorDailyTarget.PerformanceNum;
                editLiveAnchorMonthlyTargetDel.CumulativeMinivanRefund = -liveAnchorDailyTarget.MinivanRefund;
                editLiveAnchorMonthlyTargetDel.CumulativeMiniVanBadReviews = -liveAnchorDailyTarget.MiniVanBadReviews;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTargetDel);

                liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.NetWorkConsultingEmployeeId = updateDto.NetWorkConsultingEmployeeId;
                liveAnchorDailyTarget.ConsultationCardConsumed = updateDto.ConsultationCardConsumed;
                liveAnchorDailyTarget.ConsultationCardConsumed2 = updateDto.ConsultationCardConsumed2;
                liveAnchorDailyTarget.ActivateHistoricalConsultation = updateDto.ActivateHistoricalConsultation;
                liveAnchorDailyTarget.AddWechatNum = updateDto.AddWechatNum;
                liveAnchorDailyTarget.SendOrderNum = updateDto.SendOrderNum;
                liveAnchorDailyTarget.NewVisitNum = updateDto.NewVisitNum;
                liveAnchorDailyTarget.SubsequentVisitNum = updateDto.SubsequentVisitNum;
                liveAnchorDailyTarget.OldCustomerVisitNum = updateDto.OldCustomerVisitNum;
                liveAnchorDailyTarget.VisitNum = updateDto.VisitNum;
                liveAnchorDailyTarget.NewDealNum = updateDto.NewDealNum;
                liveAnchorDailyTarget.SubsequentDealNum = updateDto.SubsequentDealNum;
                liveAnchorDailyTarget.OldCustomerDealNum = updateDto.OldCustomerDealNum;
                liveAnchorDailyTarget.DealNum = updateDto.DealNum;
                liveAnchorDailyTarget.NewPerformanceNum = updateDto.NewPerformanceNum;
                liveAnchorDailyTarget.SubsequentPerformanceNum = updateDto.SubsequentPerformanceNum;
                liveAnchorDailyTarget.OldCustomerPerformanceNum = updateDto.OldCustomerPerformanceNum;
                liveAnchorDailyTarget.NewCustomerPerformanceCountNum = updateDto.NewCustomerPerformanceCountNum;
                liveAnchorDailyTarget.PerformanceNum = updateDto.PerformanceNum;
                liveAnchorDailyTarget.MinivanRefund = updateDto.MinivanRefund;
                liveAnchorDailyTarget.MiniVanBadReviews = updateDto.MiniVanBadReviews;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                liveAnchorDailyTarget.AfterLivingUpdateDate = updateDto.AfterLivingUpdateDate;
                await dalLiveAnchorDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                //添加修改后的
                UpdateLiveAnchorMonthlyTargetRateAndNumDto editLiveAnchorMonthlyTargetAdd = new UpdateLiveAnchorMonthlyTargetRateAndNumDto();
                editLiveAnchorMonthlyTargetAdd.Id = updateDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTargetAdd.CumulativeConsultationCardConsumed = updateDto.ConsultationCardConsumed;
                editLiveAnchorMonthlyTargetAdd.CumulativeConsultationCardConsumed2 = updateDto.ConsultationCardConsumed2;
                editLiveAnchorMonthlyTargetAdd.CumulativeActivateHistoricalConsultation = updateDto.ActivateHistoricalConsultation;
                editLiveAnchorMonthlyTargetAdd.CumulativeAddWechat = updateDto.AddWechatNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeSendOrder = updateDto.SendOrderNum;

                editLiveAnchorMonthlyTargetAdd.CumulativeNewCustomerVisit = updateDto.NewVisitNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeNewCustomerVisit += updateDto.SubsequentVisitNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeOldCustomerVisit = updateDto.OldCustomerVisitNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeVisit = updateDto.VisitNum;


                editLiveAnchorMonthlyTargetAdd.CumulativeNewCustomerDealTarget = updateDto.NewDealNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeNewCustomerDealTarget += updateDto.SubsequentDealNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeOldCustomerDealTarget = updateDto.OldCustomerDealNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeDealTarget = updateDto.DealNum;

                editLiveAnchorMonthlyTargetAdd.CumulativeNewCustomerPerformance = updateDto.NewPerformanceNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeSubsequentPerformance = updateDto.SubsequentPerformanceNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeOldCustomerPerformance = updateDto.OldCustomerPerformanceNum;
                editLiveAnchorMonthlyTargetAdd.CumulativePerformance = updateDto.PerformanceNum;
                editLiveAnchorMonthlyTargetAdd.CumulativeMinivanRefund = updateDto.MinivanRefund;
                editLiveAnchorMonthlyTargetAdd.CumulativeMiniVanBadReviews = updateDto.MiniVanBadReviews;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTargetAdd);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        #endregion

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

                editLiveAnchorMonthlyTarget.CumulativeZhihuRelease = -liveAnchorDailyTarget.ZhihuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease = -liveAnchorDailyTarget.SinaWeiBoSendNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokRelease = -liveAnchorDailyTarget.TikTokSendNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = -liveAnchorDailyTarget.XiaoHongShuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoRelease = -liveAnchorDailyTarget.VideoSendNum;

                
                editLiveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment = -liveAnchorDailyTarget.ZhihuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment = -liveAnchorDailyTarget.SinaWeiBoFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = -liveAnchorDailyTarget.TikTokFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = -liveAnchorDailyTarget.XiaoHongShuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = -liveAnchorDailyTarget.VideoFlowInvestmentNum;

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

                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit = -liveAnchorDailyTarget.NewVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit -= liveAnchorDailyTarget.SubsequentVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerVisit = -liveAnchorDailyTarget.OldCustomerVisitNum;
                editLiveAnchorMonthlyTarget.CumulativeVisit = -liveAnchorDailyTarget.VisitNum;

                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = -liveAnchorDailyTarget.NewDealNum;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget -= liveAnchorDailyTarget.SubsequentDealNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = -liveAnchorDailyTarget.OldCustomerDealNum;
                editLiveAnchorMonthlyTarget.CumulativeDealTarget = -liveAnchorDailyTarget.DealNum;

                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = -liveAnchorDailyTarget.CargoSettlementCommission;
                editLiveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = -liveAnchorDailyTarget.NewPerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeSubsequentPerformance = -liveAnchorDailyTarget.SubsequentPerformanceNum;
                editLiveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = -liveAnchorDailyTarget.OldCustomerPerformanceNum;
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
                var liveAnchorDailyTarget = from d in dalLiveAnchorDailyTarget.GetAll().Include(e => e.LiveAnchorMonthlyTarget).ThenInclude(e => e.LiveAnchor)
                                            where d.RecordDate >= startDate && d.RecordDate < endDate
                                            select new LiveAnchorDailyAndMonthTargetDto
                                            {
                                                Id = d.Id,
                                                LiveanchorMonthlyTargetId = d.LiveanchorMonthlyTargetId,
                                                LiveAnchor = d.LiveAnchorMonthlyTarget.LiveAnchor.Name,
                                                CreateDate = d.CreateDate,
                                                RecordDate = d.RecordDate,
                                                LivingTrackingEmployeeId = d.LivingTrackingEmployeeId,
                                                NetWorkConsultingEmployeeId = d.NetWorkConsultingEmployeeId,

                                                TikTokOperationEmployeeId = d.TikTokOperationEmployeeId,
                                                TikTokSendNum = d.TikTokSendNum,
                                                TikTokReleaseTarget = d.LiveAnchorMonthlyTarget.TikTokReleaseTarget,
                                                TikTokCumulativeRelease = d.LiveAnchorMonthlyTarget.CumulativeTikTokRelease,
                                                TikTokReleaseCompleteRate = d.LiveAnchorMonthlyTarget.TikTokReleaseCompleteRate.ToString("0.00") + "%",
                                                TikTokFlowInvestmentNum = d.TikTokFlowInvestmentNum,
                                                TikTokFlowinvestmentTarget = d.LiveAnchorMonthlyTarget.TikTokFlowinvestmentTarget,
                                                CumulativeTikTokFlowinvestment = d.LiveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment,
                                                TikTokFlowinvestmentCompleteRate = d.LiveAnchorMonthlyTarget.TikTokFlowinvestmentCompleteRate.ToString("0.00") + "%",

                                                ZhihuOperationEmployeeId = d.ZhihuOperationEmployeeId,
                                                ZhihuSendNum = d.ZhihuSendNum,
                                                ZhihuReleaseTarget = d.LiveAnchorMonthlyTarget.ZhihuReleaseTarget,
                                                ZhihuCumulativeRelease = d.LiveAnchorMonthlyTarget.CumulativeZhihuRelease,
                                                ZhihuReleaseCompleteRate = d.LiveAnchorMonthlyTarget.ZhihuReleaseCompleteRate.ToString("0.00") + "%",
                                                ZhihuFlowInvestmentNum = d.ZhihuFlowInvestmentNum,
                                                ZhihuFlowinvestmentTarget = d.LiveAnchorMonthlyTarget.ZhihuFlowinvestmentTarget,
                                                CumulativeZhihuFlowinvestment = d.LiveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment,
                                                ZhihuFlowinvestmentCompleteRate = d.LiveAnchorMonthlyTarget.ZhihuFlowinvestmentCompleteRate.ToString("0.00") + "%",

                                                XiaoHongShuOperationEmployeeId = d.XiaoHongShuOperationEmployeeId,
                                                XiaoHongShuSendNum = d.XiaoHongShuSendNum,
                                                XiaoHongShuReleaseTarget = d.LiveAnchorMonthlyTarget.XiaoHongShuReleaseTarget,
                                                XiaoHongShuCumulativeRelease = d.LiveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease,
                                                XiaoHongShuReleaseCompleteRate = d.LiveAnchorMonthlyTarget.XiaoHongShuReleaseCompleteRate.ToString("0.00") + "%",
                                                XiaoHongShuFlowInvestmentNum = d.XiaoHongShuFlowInvestmentNum,
                                                XiaoHongShuFlowinvestmentTarget = d.LiveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentTarget,
                                                CumulativeXiaoHongShuFlowinvestment = d.LiveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment,
                                                XiaoHongShuFlowinvestmentCompleteRate = d.LiveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentCompleteRate.ToString("0.00") + "%",

                                                SinaWeiBoOperationEmployeeId = d.SinaWeiBoOperationEmployeeId,
                                                SinaWeiBoSendNum = d.SinaWeiBoSendNum,
                                                SinaWeiBoReleaseTarget = d.LiveAnchorMonthlyTarget.SinaWeiBoReleaseTarget,
                                                SinaWeiBoCumulativeRelease = d.LiveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease,
                                                SinaWeiBoReleaseCompleteRate = d.LiveAnchorMonthlyTarget.SinaWeiBoReleaseCompleteRate.ToString("0.00") + "%",
                                                SinaWeiBoFlowInvestmentNum = d.SinaWeiBoFlowInvestmentNum,
                                                SinaWeiBoFlowinvestmentTarget = d.LiveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentTarget,
                                                CumulativeSinaWeiBoFlowinvestment = d.LiveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment,
                                                SinaWeiBoFlowinvestmentCompleteRate = d.LiveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentCompleteRate.ToString("0.00") + "%",

                                                VideoOperationEmployeeId = d.VideoOperationEmployeeId,
                                                VideoSendNum = d.VideoSendNum,
                                                VideoReleaseTarget = d.LiveAnchorMonthlyTarget.VideoReleaseTarget,
                                                CumulativeVideoRelease = d.LiveAnchorMonthlyTarget.CumulativeVideoRelease,
                                                VideoReleaseCompleteRate = d.LiveAnchorMonthlyTarget.VideoReleaseCompleteRate.ToString("0.00") + "%",
                                                VideoFlowInvestmentNum = d.VideoFlowInvestmentNum,
                                                VideoFlowinvestmentTarget = d.LiveAnchorMonthlyTarget.VideoFlowinvestmentTarget,
                                                CumulativeVideoFlowinvestment = d.LiveAnchorMonthlyTarget.CumulativeVideoFlowinvestment,
                                                VideoFlowinvestmentCompleteRate = d.LiveAnchorMonthlyTarget.VideoFlowinvestmentCompleteRate.ToString("0.00") + "%",

                                                TodaySendNum = d.TodaySendNum,
                                                ReleaseTarget = d.LiveAnchorMonthlyTarget.ReleaseTarget,
                                                CumulativeRelease = d.LiveAnchorMonthlyTarget.CumulativeRelease,
                                                ReleaseCompleteRate = d.LiveAnchorMonthlyTarget.ReleaseCompleteRate.ToString("0.00") + "%",
                                                FlowInvestmentNum = d.FlowInvestmentNum,
                                                FlowInvestmentTarget = d.LiveAnchorMonthlyTarget.FlowInvestmentTarget,
                                                CumulativeFlowInvestment = d.LiveAnchorMonthlyTarget.CumulativeFlowInvestment,
                                                FlowInvestmentCompleteRate = d.LiveAnchorMonthlyTarget.FlowInvestmentCompleteRate.ToString("0.00") + "%",
                                                LivingRoomFlowInvestmentNum = d.LivingRoomFlowInvestmentNum,
                                                LivingRoomFlowInvestmentTarget = d.LiveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget,
                                                LivingRoomCumulativeFlowInvestment = d.LiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment,
                                                LivingRoomFlowInvestmentCompleteRate = d.LiveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate.ToString("0.00") + "%",
                                                CluesNum = d.CluesNum,
                                                CluesNumTarget = d.LiveAnchorMonthlyTarget.CluesTarget,
                                                CumulativeCluesNum = d.LiveAnchorMonthlyTarget.CumulativeClues,
                                                CluesCompleteRate = d.LiveAnchorMonthlyTarget.CluesCompleteRate.ToString("0.00") + "%",
                                                AddFansNum = d.AddFansNum,
                                                AddFansTarget = d.LiveAnchorMonthlyTarget.AddFansTarget,
                                                CumulativeAddFansNum = d.LiveAnchorMonthlyTarget.CumulativeAddFans,
                                                AddFansCompleteRate = d.LiveAnchorMonthlyTarget.AddFansCompleteRate.ToString("0.00") + "%",
                                                AddWechatNum = d.AddWechatNum,
                                                AddWechatTarget = d.LiveAnchorMonthlyTarget.AddWechatTarget,
                                                CumulativeAddWechat = d.LiveAnchorMonthlyTarget.CumulativeAddWechat,
                                                AddWechatCompleteRate = d.LiveAnchorMonthlyTarget.AddWechatCompleteRate.ToString("0.00") + "%",
                                                Consultation = d.Consultation,
                                                ConsultationTarget = d.LiveAnchorMonthlyTarget.ConsultationTarget,
                                                CumulativeConsultation = d.LiveAnchorMonthlyTarget.CumulativeConsultation,
                                                ConsultationCompleteRate = d.LiveAnchorMonthlyTarget.ConsultationCompleteRate.ToString("0.00") + "%",
                                                Consultation2 = d.Consultation2,
                                                ConsultationTarget2 = d.LiveAnchorMonthlyTarget.ConsultationTarget2,
                                                CumulativeConsultation2 = d.LiveAnchorMonthlyTarget.CumulativeConsultation2,
                                                ConsultationCompleteRate2 = d.LiveAnchorMonthlyTarget.ConsultationCompleteRate2.ToString("0.00") + "%",
                                                ActivateHistoricalConsultation = d.ActivateHistoricalConsultation,
                                                ActivateHistoricalConsultationTarget = d.LiveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget,
                                                CumulativeActivateHistoricalConsultation = d.LiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation,
                                                ActivateHistoricalConsultationCompleteRate = d.LiveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate.ToString("0.00") + "%",
                                                ConsultationCardConsumed = d.ConsultationCardConsumed,
                                                ConsultationCardConsumedTarget = d.LiveAnchorMonthlyTarget.ConsultationCardConsumedTarget,
                                                CumulativeConsultationCardConsumed = d.LiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed,
                                                ConsultationCardConsumedCompleteRate = d.LiveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate.ToString("0.00") + "%",
                                                ConsultationCardConsumed2 = d.ConsultationCardConsumed2,
                                                ConsultationCardConsumedTarget2 = d.LiveAnchorMonthlyTarget.ConsultationCardConsumedTarget2,
                                                CumulativeConsultationCardConsumed2 = d.LiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2,
                                                ConsultationCardConsumedCompleteRate2 = d.LiveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate2.ToString("0.00") + "%",
                                                SendOrderNum = d.SendOrderNum,
                                                SendOrderTarget = d.LiveAnchorMonthlyTarget.SendOrderTarget,
                                                CumulativeSendOrder = d.LiveAnchorMonthlyTarget.CumulativeSendOrder,
                                                SendOrderCompleteRate = d.LiveAnchorMonthlyTarget.SendOrderCompleteRate.ToString("0.00") + "%",
                                                NewVisitNum = d.NewVisitNum,
                                                SubsequentVisitNum = d.SubsequentVisitNum,
                                                OldCustomerVisitNum = d.OldCustomerVisitNum,
                                                VisitNum = d.VisitNum,
                                                VisitTarget = d.LiveAnchorMonthlyTarget.VisitTarget,
                                                CumulativeVisit = d.LiveAnchorMonthlyTarget.CumulativeVisit,
                                                VisitCompleteRate = d.LiveAnchorMonthlyTarget.VisitCompleteRate.ToString("0.00") + "%",
                                                NewDealNum = d.NewDealNum,
                                                SubsequentDealNum = d.SubsequentDealNum,
                                                OldCustomerDealNum = d.OldCustomerDealNum,
                                                DealNum = d.DealNum,
                                                DealTarget = d.LiveAnchorMonthlyTarget.DealTarget,
                                                CumulativeDealTarget = d.LiveAnchorMonthlyTarget.CumulativeDealTarget,
                                                DealRate = d.LiveAnchorMonthlyTarget.DealRate.ToString("0.00") + "%",
                                                CargoSettlementCommission = d.CargoSettlementCommission,
                                                CargoSettlementCommissionTarget = d.LiveAnchorMonthlyTarget.CargoSettlementCommissionTarget,
                                                CumulativeCargoSettlementCommission = d.LiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission,
                                                CargoSettlementCommissionCompleteRate = d.LiveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate.ToString("0.00") + "%",
                                                NewPerformanceNum = d.NewPerformanceNum,
                                                PerformanceTarget = d.LiveAnchorMonthlyTarget.PerformanceTarget,
                                                CumulativePerformance = d.LiveAnchorMonthlyTarget.CumulativePerformance,
                                                PerformanceCompleteRate = d.LiveAnchorMonthlyTarget.PerformanceCompleteRate.ToString("0.00") + "%",
                                                SubsequentPerformanceNum = d.SubsequentPerformanceNum,
                                                OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                                                NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                                                MiniVanBadReviews = d.MiniVanBadReviews,
                                                MiniVanBadReviewsTarget = d.LiveAnchorMonthlyTarget.MiniVanBadReviewsTarget,
                                                CumulativeMiniVanBadReviews = d.LiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews,
                                                MiniVanBadReviewsCompleteRate = d.LiveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate.ToString("0.00") + "%",
                                                MinivanRefund = d.MinivanRefund,
                                                MinivanRefundTarget = d.LiveAnchorMonthlyTarget.MinivanRefundTarget,
                                                CumulativeMinivanRefund = d.LiveAnchorMonthlyTarget.CumulativeMinivanRefund,
                                                MinivanRefundCompleteRate = d.LiveAnchorMonthlyTarget.MinivanRefundCompleteRate.ToString("0.00") + "%",
                                                PerformanceNum = d.PerformanceNum,
                                                TikTokUpdateDate = d.TikTokUpdateDate,
                                                LivingUpdateDate = d.LivingUpdateDate,
                                                AfterLivingUpdateDate = d.AfterLivingUpdateDate

                                            };
                var result = await liveAnchorDailyTarget.OrderByDescending(x => x.RecordDate).ToListAsync();
                foreach (var x in result)
                {
                    if (x.TikTokOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.TikTokOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.TikTokOperationEmployeeName = operationEmployee.Name.ToString();
                        }
                    }
                    if (x.VideoOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.VideoOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.VideoOperationEmployeeName = operationEmployee.Name.ToString();
                        }
                    }
                    if (x.XiaoHongShuOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.XiaoHongShuOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.XiaoHongShuOperationEmployeeName = operationEmployee.Name.ToString();
                        }
                    }
                    if (x.ZhihuOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.ZhihuOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.ZhihuOperationEmployeeName = operationEmployee.Name.ToString();
                        }
                    }
                    if (x.SinaWeiBoOperationEmployeeId != 0)
                    {
                        var operationEmployee = await _amiyaEmployeeService.GetByIdAsync(x.SinaWeiBoOperationEmployeeId);
                        if (operationEmployee.Id != 0)
                        {
                            x.SinaWeiBoOperationEmployeeName = operationEmployee.Name.ToString();
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
