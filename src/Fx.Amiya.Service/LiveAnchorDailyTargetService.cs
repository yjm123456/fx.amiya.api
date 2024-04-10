using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveAnchorDailyTarget;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.TakeGoods;
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
        private ILiveAnchorMonthlyTargetBeforeLivingService _liveAnchorMonthlyTargetService;
        private IDalBeforeLivingTikTokDailyTarget _beforeLivingTikTokDailyTraget;
        private ILiveAnchorMonthlyTargetLivingService _liveAnchorMonthlyTargetLivingService;
        private ILiveAnchorMonthlyTargetAfterLivingService _liveAnchorMonthlyTargetAfterLivingService;
        private IDalBeforeLivingXiaoHongShuDailyTarget _beforeLivingXiaoHongShuDailyTraget;
        private IDalBeforeLivingZhiHuDailyTarget _beforeLivingZhiHuDailyTraget;
        private IDalBeforeLivingVideoDailyTarget _beforeLivingVideoDailyTraget;
        private IDalAfterLivingDailyTarget _afterLivingDailyTarget;
        private IDalBeforeLivingSinaWeiBoDailyTarget _beforeLivingSinaWeiBoDailyTraget;
        private IDalLivingDailyTarget _livingDailyTarget;
        private IUnitOfWork unitOfWork;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IEmployeeBindLiveAnchorService employeeBindLiveAnchorService;

        public LiveAnchorDailyTargetService(IDalLiveAnchorDailyTarget dalLiveAnchorDailyTarget,
            IUnitOfWork unitOfWork,
            IEmployeeBindLiveAnchorService employeeBindLiveAnchorService,
            ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService,
            IDalBeforeLivingTikTokDailyTarget beforeLivingTikTokDailyTraget,
            ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService,
            IDalBeforeLivingXiaoHongShuDailyTarget beforeLivingXiaoHongShuDailyTraget,
            IDalBeforeLivingZhiHuDailyTarget beforeLivingZhiHuDailyTraget,
            IDalBeforeLivingVideoDailyTarget beforeLivingVideoDailyTraget,
            IDalBeforeLivingSinaWeiBoDailyTarget beforeLivingSinaWeiBoDailyTraget,
            IDalLivingDailyTarget livingDailyTarget,
            IDalAfterLivingDailyTarget afterLivingDailyTarget,
            ILiveAnchorMonthlyTargetBeforeLivingService liveAnchorMonthlyTargetService,
            IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.unitOfWork = unitOfWork;
            _liveAnchorMonthlyTargetLivingService = liveAnchorMonthlyTargetLivingService;
            this.dalLiveAnchorDailyTarget = dalLiveAnchorDailyTarget;
            _liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
            _liveAnchorMonthlyTargetAfterLivingService = liveAnchorMonthlyTargetAfterLivingService;
            _amiyaEmployeeService = amiyaEmployeeService;
            _beforeLivingTikTokDailyTraget = beforeLivingTikTokDailyTraget;
            _beforeLivingXiaoHongShuDailyTraget = beforeLivingXiaoHongShuDailyTraget;
            _beforeLivingSinaWeiBoDailyTraget = beforeLivingSinaWeiBoDailyTraget;
            _afterLivingDailyTarget = afterLivingDailyTarget;
            _beforeLivingVideoDailyTraget = beforeLivingVideoDailyTraget;
            _beforeLivingZhiHuDailyTraget = beforeLivingZhiHuDailyTraget;
            _livingDailyTarget = livingDailyTarget;
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
        public async Task<FxPageInfo<LiveAnchorDailyTargetDto>> GetListWithPageAsync(DateTime startDate, DateTime endDate, int? liveAnchorId, int pageNum, int pageSize, int employeeId)
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
                #region 【数据获取】
                var tikTokDailyInfo = from d in _beforeLivingTikTokDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                      where d.RecordDate >= startDate && d.RecordDate < endDate
                                      && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                      && d.Valid
                                      select new BeforeLivingDailyTargetDto
                                      {
                                          Id = d.Id,
                                          LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                          LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                          CreateDate = d.CreateDate,
                                          UpdateDate = d.UpdateDate,
                                          RecordDate = d.RecordDate,
                                          OperationEmpId = d.OperationEmpId,
                                          OperationEmpName = d.AmiyaEmployee.Name,
                                          FlowInvestmentNum = d.FlowInvestmentNum,
                                          SendNum = d.SendNum,
                                          TikTokShowcaseIncome = d.TikTokShowcaseIncome,
                                          TikTokClues = d.TikTokClues,
                                          TikTokIncreaseFans = d.TikTokIncreaseFans,
                                          TikTokIncreaseFansFees = d.TikTokIncreaseFansFees,                                          
                                          TikTokIncreaseFansFeesCost = d.TikTokIncreaseFans <= 0 ? d.TikTokIncreaseFansFees : Math.Round(d.TikTokIncreaseFansFees / Convert.ToDecimal(d.TikTokIncreaseFans), 2),
                                          TikTokShowCaseFee = d.TikTokShowCaseFee
                                      };
                var tikTokDailyInfoList = await tikTokDailyInfo.ToListAsync();

                var xiaohongshuDailyInfo = from d in _beforeLivingXiaoHongShuDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                           where d.RecordDate >= startDate && d.RecordDate < endDate
                                           && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                           && d.Valid
                                           select new BeforeLivingDailyTargetDto
                                           {
                                               Id = d.Id,
                                               LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                               LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                               CreateDate = d.CreateDate,
                                               UpdateDate = d.UpdateDate,
                                               RecordDate = d.RecordDate,
                                               OperationEmpId = d.OperationEmpId,
                                               OperationEmpName = d.AmiyaEmployee.Name,
                                               FlowInvestmentNum = d.FlowInvestmentNum,
                                               SendNum = d.SendNum,
                                               XiaoHongShuShowcaseIncome = d.XiaoHongShuShowcaseIncome,
                                               XiaoHongShuClues = d.XiaoHongShuClues,
                                               XiaoHongShuIncreaseFans = d.XiaoHongShuIncreaseFans,
                                               XiaoHongShuIncreaseFansFees = d.XiaoHongShuIncreaseFansFees,
                                               XiaoHongShuIncreaseFansFeesCost = d.XiaoHongShuIncreaseFans <= 0 ? d.XiaoHongShuIncreaseFansFees : Math.Round(d.XiaoHongShuIncreaseFansFees / Convert.ToDecimal(d.XiaoHongShuIncreaseFans), 2),
                                               XiaoHongShuShowCaseFee = d.XiaoHongShuShowCaseFee
                                           };
                var xiaohongshuDailyInfoList = await xiaohongshuDailyInfo.ToListAsync();

                var videoDailyInfo = from d in _beforeLivingVideoDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                     where d.RecordDate >= startDate && d.RecordDate < endDate
                                     && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                     && d.Valid
                                     select new BeforeLivingDailyTargetDto
                                     {
                                         Id = d.Id,
                                         LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                         LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                         CreateDate = d.CreateDate,
                                         UpdateDate = d.UpdateDate,
                                         RecordDate = d.RecordDate,
                                         OperationEmpId = d.OperationEmpId,
                                         OperationEmpName = d.AmiyaEmployee.Name,
                                         FlowInvestmentNum = d.FlowInvestmentNum,
                                         SendNum = d.SendNum,
                                         VideoShowcaseIncome = d.VideoShowcaseIncome,
                                         VideoClues = d.VideoClues,
                                         VideoIncreaseFans = d.VideoIncreaseFans,
                                         VideoIncreaseFansFees = d.VideoIncreaseFansFees,
                                         VideoIncreaseFansFeesCost = d.VideoIncreaseFans <= 0 ? d.VideoIncreaseFansFees : Math.Round(d.VideoIncreaseFansFees / Convert.ToDecimal(d.VideoIncreaseFans), 2),
                                         VideoShowCaseFee = d.VideoShowCaseFee
                                     };
                var videoDailyInfoList = await videoDailyInfo.ToListAsync();

                var zhihuDailyInfo = from d in _beforeLivingZhiHuDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                     where d.RecordDate >= startDate && d.RecordDate < endDate
                                     && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                     && d.Valid
                                     select new BeforeLivingDailyTargetDto
                                     {
                                         Id = d.Id,
                                         LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                         LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                         CreateDate = d.CreateDate,
                                         UpdateDate = d.UpdateDate,
                                         RecordDate = d.RecordDate,
                                         OperationEmpId = d.OperationEmpId,
                                         OperationEmpName = d.AmiyaEmployee.Name,
                                         FlowInvestmentNum = d.FlowInvestmentNum,
                                         SendNum = d.SendNum,
                                     };
                var zhihuDailyInfoList = await zhihuDailyInfo.ToListAsync();

                var sinaWeiBoDailyInfo = from d in _beforeLivingSinaWeiBoDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                         where d.RecordDate >= startDate && d.RecordDate < endDate
                                         && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                         && d.Valid
                                         select new BeforeLivingDailyTargetDto
                                         {
                                             Id = d.Id,
                                             LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                             LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                             CreateDate = d.CreateDate,
                                             UpdateDate = d.UpdateDate,
                                             RecordDate = d.RecordDate,
                                             OperationEmpId = d.OperationEmpId,
                                             OperationEmpName = d.AmiyaEmployee.Name,
                                             FlowInvestmentNum = d.FlowInvestmentNum,
                                             SendNum = d.SendNum,
                                         };
                var sinaWeiBoDailyInfoList = await sinaWeiBoDailyInfo.ToListAsync();

                var livingDailyInfo = from d in _livingDailyTarget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetLiving)
                                      where d.RecordDate >= startDate && d.RecordDate < endDate
                                      && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetLiving.LiveAnchorId))
                                      && d.Valid
                                      select new LivingDailyTargetDto
                                      {
                                          Id = d.Id,
                                          LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                          LiveAnchor = d.LiveAnchorMonthlyTargetLiving.LiveAnchor.Name,
                                          CreateDate = d.CreateDate,
                                          UpdateDate = d.UpdateDate,
                                          RecordDate = d.RecordDate,
                                          OperationEmpId = d.OperationEmpId,
                                          OperationEmpName = d.AmiyaEmployee.Name,
                                          LivingRoomFlowInvestmentNum = d.LivingRoomFlowInvestmentNum,
                                          CargoSettlementCommission = d.CargoSettlementCommission,
                                          Consultation = d.Consultation,
                                          Consultation2 = d.Consultation2,
                                      };

                var livingDailyInfoList = await livingDailyInfo.ToListAsync();

                var afterLivingDailyInfo = from d in _afterLivingDailyTarget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetAfterLiving)
                                           where d.RecordDate >= startDate && d.RecordDate < endDate
                                           && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetAfterLiving.LiveAnchorId))
                                           && d.Valid
                                           select new AfterLivingDailyTargetDto
                                           {
                                               Id = d.Id,
                                               LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                               LiveAnchor = d.LiveAnchorMonthlyTargetAfterLiving.LiveAnchor.Name,
                                               CreateDate = d.CreateDate,
                                               UpdateDate = d.UpdateDate,
                                               RecordDate = d.RecordDate,
                                               OperationEmpId = d.OperationEmpId,
                                               OperationEmpName = d.AmiyaEmployee.Name,
                                               AddWechatNum = d.AddWechatNum,
                                               ConsultationCardConsumed = d.ConsultationCardConsumed,
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
                                               NewPerformanceNum = d.NewPerformanceNum,
                                               SubsequentPerformanceNum = d.SubsequentPerformanceNum,
                                               NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                                               OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                                               PerformanceNum = d.PerformanceNum,
                                               MinivanRefund = d.MinivanRefund,
                                               MiniVanBadReviews = d.MiniVanBadReviews,
                                           };

                var afterLivingDailyInfoList = await afterLivingDailyInfo.ToListAsync();

                #endregion
                FxPageInfo<LiveAnchorDailyTargetDto> liveAnchorDailyTargetPageInfo = new FxPageInfo<LiveAnchorDailyTargetDto>();
                liveAnchorDailyTargetPageInfo.TotalCount = await tikTokDailyInfo.CountAsync();
                var diaryTargetInfo = await tikTokDailyInfo.OrderByDescending(x => x.RecordDate).ToListAsync();
                List<LiveAnchorDailyTargetDto> resultList = new List<LiveAnchorDailyTargetDto>();
                //筛选组合数据
                foreach (var x in diaryTargetInfo)
                {
                    //抖音
                    LiveAnchorDailyTargetDto liveAnchorDailyTargetDto = new LiveAnchorDailyTargetDto();
                    liveAnchorDailyTargetDto.RecordDate = x.RecordDate;
                    liveAnchorDailyTargetDto.LiveAnchor = x.LiveAnchor;
                    liveAnchorDailyTargetDto.TikTokOperationEmployeeName = x.OperationEmpName;
                    liveAnchorDailyTargetDto.TikTokSendNum = x.SendNum;
                    liveAnchorDailyTargetDto.TikTokFlowInvestmentNum = x.FlowInvestmentNum;
                    liveAnchorDailyTargetDto.UpdateDate = x.UpdateDate;
                    liveAnchorDailyTargetDto.TikTokShowcaseIncome = x.TikTokShowcaseIncome;
                    liveAnchorDailyTargetDto.TikTokIncreaseFans = x.TikTokIncreaseFans;
                    liveAnchorDailyTargetDto.TikTokIncreaseFansFees = x.TikTokIncreaseFansFees;
                    liveAnchorDailyTargetDto.TikTokIncreaseFansFeesCost = x.TikTokIncreaseFansFeesCost;
                    liveAnchorDailyTargetDto.TikTokClues = x.TikTokClues;
                    liveAnchorDailyTargetDto.TikTokShowcaseFee = x.TikTokShowCaseFee;
                    ///小红书
                    var xiaohongshuThisDayDataInfo = xiaohongshuDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (xiaohongshuThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.XiaoHongShuOperationEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.XiaoHongShuSendNum = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuFlowInvestmentNum = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuShowcaseIncome = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuIncreaseFans = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuIncreaseFansFees = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuIncreaseFansFeesCost = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuClues = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuShowcaseFee = 0;
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.XiaoHongShuOperationEmployeeName = xiaohongshuThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.XiaoHongShuSendNum = xiaohongshuThisDayDataInfo.SendNum;
                        liveAnchorDailyTargetDto.XiaoHongShuFlowInvestmentNum = xiaohongshuThisDayDataInfo.FlowInvestmentNum;
                        liveAnchorDailyTargetDto.XiaoHongShuShowcaseIncome = xiaohongshuThisDayDataInfo.XiaoHongShuShowcaseIncome;
                        liveAnchorDailyTargetDto.XiaoHongShuIncreaseFans = xiaohongshuThisDayDataInfo.XiaoHongShuIncreaseFans;
                        liveAnchorDailyTargetDto.XiaoHongShuIncreaseFansFees = xiaohongshuThisDayDataInfo.XiaoHongShuIncreaseFansFees;
                        liveAnchorDailyTargetDto.XiaoHongShuIncreaseFansFeesCost = xiaohongshuThisDayDataInfo.XiaoHongShuIncreaseFansFeesCost;
                        liveAnchorDailyTargetDto.XiaoHongShuClues = xiaohongshuThisDayDataInfo.XiaoHongShuClues;
                        liveAnchorDailyTargetDto.XiaoHongShuShowcaseFee = xiaohongshuThisDayDataInfo.TikTokShowCaseFee;
                    }
                    ///视频号
                    var videoThisDayDataInfo = videoDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (videoThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.VideoOperationEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.VideoSendNum = 0;
                        liveAnchorDailyTargetDto.VideoFlowInvestmentNum = 0;
                        liveAnchorDailyTargetDto.VideoShowcaseIncome = 0;
                        liveAnchorDailyTargetDto.VideoIncreaseFans = 0;
                        liveAnchorDailyTargetDto.VideoIncreaseFansFees = 0;
                        liveAnchorDailyTargetDto.VideoIncreaseFansFeesCost = 0;
                        liveAnchorDailyTargetDto.VideoClues = 0;
                        liveAnchorDailyTargetDto.VideoShowcaseFee = 0;
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.VideoOperationEmployeeName = videoThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.VideoSendNum = videoThisDayDataInfo.SendNum;
                        liveAnchorDailyTargetDto.VideoFlowInvestmentNum = videoThisDayDataInfo.FlowInvestmentNum;
                        liveAnchorDailyTargetDto.VideoShowcaseIncome = videoThisDayDataInfo.VideoShowcaseIncome;
                        liveAnchorDailyTargetDto.VideoIncreaseFans = videoThisDayDataInfo.VideoIncreaseFans;
                        liveAnchorDailyTargetDto.VideoIncreaseFansFees = videoThisDayDataInfo.VideoIncreaseFansFees;
                        liveAnchorDailyTargetDto.VideoIncreaseFansFeesCost = videoThisDayDataInfo.VideoIncreaseFansFeesCost;
                        liveAnchorDailyTargetDto.VideoClues = videoThisDayDataInfo.VideoClues;
                        liveAnchorDailyTargetDto.VideoShowcaseFee = videoThisDayDataInfo.TikTokShowCaseFee;
                    }

                    ///微博
                    var sinaWeiBoThisDayDataInfo = sinaWeiBoDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (sinaWeiBoThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.SinaWeiBoOperationEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.SinaWeiBoSendNum = 0;
                        liveAnchorDailyTargetDto.SinaWeiBoFlowInvestmentNum = 0;
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.SinaWeiBoOperationEmployeeName = sinaWeiBoThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.SinaWeiBoSendNum = sinaWeiBoThisDayDataInfo.SendNum;
                        liveAnchorDailyTargetDto.SinaWeiBoFlowInvestmentNum = sinaWeiBoThisDayDataInfo.FlowInvestmentNum;
                    }

                    ///知乎
                    var zhihuThisDayDataInfo = zhihuDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (zhihuThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.ZhihuOperationEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.ZhihuSendNum = 0;
                        liveAnchorDailyTargetDto.ZhihuFlowInvestmentNum = 0;
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.ZhihuOperationEmployeeName = zhihuThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.ZhihuSendNum = zhihuThisDayDataInfo.SendNum;
                        liveAnchorDailyTargetDto.ZhihuFlowInvestmentNum = zhihuThisDayDataInfo.FlowInvestmentNum;
                    }

                    ///直播中
                    var livingThisDayDataInfo = livingDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (livingThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.LivingTrackingEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.LivingRoomFlowInvestmentNum = 0.00M;
                        liveAnchorDailyTargetDto.CargoSettlementCommission = 0.00M;
                        liveAnchorDailyTargetDto.Consultation = 0;
                        liveAnchorDailyTargetDto.Consultation = 0;
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.LivingTrackingEmployeeName = livingThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.LivingRoomFlowInvestmentNum = livingThisDayDataInfo.LivingRoomFlowInvestmentNum;
                        liveAnchorDailyTargetDto.CargoSettlementCommission = livingThisDayDataInfo.CargoSettlementCommission;
                        liveAnchorDailyTargetDto.Consultation = livingThisDayDataInfo.Consultation;
                        liveAnchorDailyTargetDto.Consultation = livingThisDayDataInfo.Consultation;
                    }

                    ///直播后
                    var afterLivingThisDayDataInfo = afterLivingDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (afterLivingThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.NetWorkConsultingEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.AddWechatNum = 0;
                        liveAnchorDailyTargetDto.ConsultationCardConsumed = 0;
                        liveAnchorDailyTargetDto.ConsultationCardConsumed2 = 0;
                        liveAnchorDailyTargetDto.ActivateHistoricalConsultation = 0;
                        liveAnchorDailyTargetDto.SendOrderNum = 0;
                        liveAnchorDailyTargetDto.NewVisitNum = 0;
                        liveAnchorDailyTargetDto.SubsequentVisitNum = 0;
                        liveAnchorDailyTargetDto.OldCustomerVisitNum = 0;
                        liveAnchorDailyTargetDto.VisitNum = 0;
                        liveAnchorDailyTargetDto.NewDealNum = 0;
                        liveAnchorDailyTargetDto.SubsequentDealNum = 0;
                        liveAnchorDailyTargetDto.OldCustomerDealNum = 0;
                        liveAnchorDailyTargetDto.DealNum = 0;
                        liveAnchorDailyTargetDto.NewPerformanceNum = 0;
                        liveAnchorDailyTargetDto.SubsequentPerformanceNum = 0;
                        liveAnchorDailyTargetDto.NewCustomerPerformanceCountNum = 0;
                        liveAnchorDailyTargetDto.OldCustomerPerformanceNum = 0;
                        liveAnchorDailyTargetDto.PerformanceNum = 0;
                        liveAnchorDailyTargetDto.MinivanRefund = 0;
                        liveAnchorDailyTargetDto.MiniVanBadReviews = 0;
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.NetWorkConsultingEmployeeName = afterLivingThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.AddWechatNum = afterLivingThisDayDataInfo.AddWechatNum;
                        liveAnchorDailyTargetDto.ConsultationCardConsumed = afterLivingThisDayDataInfo.ConsultationCardConsumed;
                        liveAnchorDailyTargetDto.ConsultationCardConsumed2 = afterLivingThisDayDataInfo.ConsultationCardConsumed2;
                        liveAnchorDailyTargetDto.ActivateHistoricalConsultation = afterLivingThisDayDataInfo.ActivateHistoricalConsultation;
                        liveAnchorDailyTargetDto.SendOrderNum = afterLivingThisDayDataInfo.SendOrderNum;
                        liveAnchorDailyTargetDto.NewVisitNum = afterLivingThisDayDataInfo.NewVisitNum;
                        liveAnchorDailyTargetDto.SubsequentVisitNum = afterLivingThisDayDataInfo.SubsequentVisitNum;
                        liveAnchorDailyTargetDto.OldCustomerVisitNum = afterLivingThisDayDataInfo.OldCustomerVisitNum;
                        liveAnchorDailyTargetDto.VisitNum = afterLivingThisDayDataInfo.VisitNum;
                        liveAnchorDailyTargetDto.NewDealNum = afterLivingThisDayDataInfo.NewDealNum;
                        liveAnchorDailyTargetDto.SubsequentDealNum = afterLivingThisDayDataInfo.SubsequentDealNum;
                        liveAnchorDailyTargetDto.OldCustomerDealNum = afterLivingThisDayDataInfo.OldCustomerDealNum;
                        liveAnchorDailyTargetDto.DealNum = afterLivingThisDayDataInfo.DealNum;
                        liveAnchorDailyTargetDto.NewPerformanceNum = afterLivingThisDayDataInfo.NewPerformanceNum;
                        liveAnchorDailyTargetDto.SubsequentPerformanceNum = afterLivingThisDayDataInfo.SubsequentPerformanceNum;
                        liveAnchorDailyTargetDto.NewCustomerPerformanceCountNum = afterLivingThisDayDataInfo.NewCustomerPerformanceCountNum;
                        liveAnchorDailyTargetDto.OldCustomerPerformanceNum = afterLivingThisDayDataInfo.OldCustomerPerformanceNum;
                        liveAnchorDailyTargetDto.PerformanceNum = afterLivingThisDayDataInfo.PerformanceNum;
                        liveAnchorDailyTargetDto.MinivanRefund = afterLivingThisDayDataInfo.MinivanRefund;
                        liveAnchorDailyTargetDto.MiniVanBadReviews = afterLivingThisDayDataInfo.MiniVanBadReviews;


                    }


                    resultList.Add(liveAnchorDailyTargetDto);
                }

                resultList = resultList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();

                liveAnchorDailyTargetPageInfo.List = resultList;
                return liveAnchorDailyTargetPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }



        /// <summary>
        /// 获取直播前主播日运营报表数据
        /// </summary>
        /// <param name="day">日期</param>
        /// <param name="operationEmpId">运营人员id</param>
        /// <param name="netWorkConEmpId">网咨人员id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<BeforeLivingDailyTargetDto>> GetBeforeListWithPageAsync(DateTime startDate, DateTime endDate, int type, int? liveAnchorId, int pageNum, int pageSize, int employeeId)
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
                List<BeforeLivingDailyTargetDto> BeforeLivingDailyTargetDtoList = new List<BeforeLivingDailyTargetDto>();
                #region 【数据获取】
                if (type == 1)
                {
                    var tikTokDailyInfo = from d in _beforeLivingTikTokDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                          where d.RecordDate >= startDate && d.RecordDate < endDate
                                          && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                          && d.Valid
                                          select new BeforeLivingDailyTargetDto
                                          {
                                              Id = d.Id,
                                              LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                              LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                              CreateDate = d.CreateDate,
                                              UpdateDate = d.UpdateDate,
                                              RecordDate = d.RecordDate,
                                              OperationEmpId = d.OperationEmpId,
                                              OperationEmpName = d.AmiyaEmployee.Name,
                                              FlowInvestmentNum = d.FlowInvestmentNum,
                                              SendNum = d.SendNum,
                                              TikTokShowcaseIncome = d.TikTokShowcaseIncome,
                                              Clues = d.TikTokClues,
                                              IncreaseFans = d.TikTokIncreaseFans,
                                              IncreaseFansFees = d.TikTokIncreaseFansFees,
                                              ShowCaseFee = d.TikTokShowCaseFee,
                                              IncreaseFansFeesCost=d.TikTokIncreaseFans<=0?d.TikTokIncreaseFansFees:Math.Round(d.TikTokIncreaseFansFees/Convert.ToDecimal(d.TikTokIncreaseFans),2)
                                          };
                    BeforeLivingDailyTargetDtoList = await tikTokDailyInfo.OrderByDescending(x => x.RecordDate).ToListAsync();
                }
                if (type == 2)
                {
                    var zhihuDailyInfo = from d in _beforeLivingZhiHuDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                         where d.RecordDate >= startDate && d.RecordDate < endDate
                                         && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                         && d.Valid
                                         select new BeforeLivingDailyTargetDto
                                         {
                                             Id = d.Id,
                                             LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                             LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                             CreateDate = d.CreateDate,
                                             UpdateDate = d.UpdateDate,
                                             RecordDate = d.RecordDate,
                                             OperationEmpId = d.OperationEmpId,
                                             OperationEmpName = d.AmiyaEmployee.Name,
                                             FlowInvestmentNum = d.FlowInvestmentNum,
                                             SendNum = d.SendNum,
                                         };
                    BeforeLivingDailyTargetDtoList = await zhihuDailyInfo.OrderByDescending(x => x.RecordDate).ToListAsync();
                }

                if (type == 3)
                {
                    var sinaWeiBoDailyInfo = from d in _beforeLivingSinaWeiBoDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                             where d.RecordDate >= startDate && d.RecordDate < endDate
                                             && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                             && d.Valid
                                             select new BeforeLivingDailyTargetDto
                                             {
                                                 Id = d.Id,
                                                 LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                                 LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                                 CreateDate = d.CreateDate,
                                                 UpdateDate = d.UpdateDate,
                                                 RecordDate = d.RecordDate,
                                                 OperationEmpId = d.OperationEmpId,
                                                 OperationEmpName = d.AmiyaEmployee.Name,
                                                 FlowInvestmentNum = d.FlowInvestmentNum,
                                                 SendNum = d.SendNum,
                                             };
                    BeforeLivingDailyTargetDtoList = await sinaWeiBoDailyInfo.OrderByDescending(x => x.RecordDate).ToListAsync();
                }


                if (type == 4)
                {
                    var xiaohongshuDailyInfo = from d in _beforeLivingXiaoHongShuDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                               where d.RecordDate >= startDate && d.RecordDate < endDate
                                               && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                               && d.Valid
                                               select new BeforeLivingDailyTargetDto
                                               {
                                                   Id = d.Id,
                                                   LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                                   LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                                   CreateDate = d.CreateDate,
                                                   UpdateDate = d.UpdateDate,
                                                   RecordDate = d.RecordDate,
                                                   OperationEmpId = d.OperationEmpId,
                                                   OperationEmpName = d.AmiyaEmployee.Name,
                                                   FlowInvestmentNum = d.FlowInvestmentNum,
                                                   SendNum = d.SendNum,
                                                   TikTokShowcaseIncome = d.XiaoHongShuShowcaseIncome,
                                                   Clues = d.XiaoHongShuClues,
                                                   IncreaseFans = d.XiaoHongShuIncreaseFans,
                                                   IncreaseFansFees = d.XiaoHongShuIncreaseFansFees,
                                                   ShowCaseFee = d.XiaoHongShuShowCaseFee,
                                                   IncreaseFansFeesCost = d.XiaoHongShuIncreaseFans <= 0 ? d.XiaoHongShuIncreaseFansFees : Math.Round(d.XiaoHongShuIncreaseFansFees / Convert.ToDecimal(d.XiaoHongShuIncreaseFans), 2)
                                               };
                    BeforeLivingDailyTargetDtoList = await xiaohongshuDailyInfo.OrderByDescending(x => x.RecordDate).ToListAsync();
                }
                if (type == 5)
                {

                    var videoDailyInfo = from d in _beforeLivingVideoDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving)
                                         where d.RecordDate >= startDate && d.RecordDate < endDate
                                         && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId))
                                         && d.Valid
                                         select new BeforeLivingDailyTargetDto
                                         {
                                             Id = d.Id,
                                             LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                             LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                             CreateDate = d.CreateDate,
                                             UpdateDate = d.UpdateDate,
                                             RecordDate = d.RecordDate,
                                             OperationEmpId = d.OperationEmpId,
                                             OperationEmpName = d.AmiyaEmployee.Name,
                                             FlowInvestmentNum = d.FlowInvestmentNum,
                                             SendNum = d.SendNum,
                                             TikTokShowcaseIncome = d.VideoShowcaseIncome,
                                             Clues = d.VideoClues,
                                             IncreaseFans = d.VideoIncreaseFans,
                                             IncreaseFansFees = d.VideoIncreaseFansFees,
                                             ShowCaseFee = d.VideoShowCaseFee,
                                             IncreaseFansFeesCost = d.VideoIncreaseFans <= 0 ? d.VideoIncreaseFansFees : Math.Round(d.VideoIncreaseFansFees / Convert.ToDecimal(d.VideoIncreaseFans), 2)
                                         };
                    BeforeLivingDailyTargetDtoList = await videoDailyInfo.OrderByDescending(x => x.RecordDate).ToListAsync();
                }
                #endregion

                FxPageInfo<BeforeLivingDailyTargetDto> liveAnchorDailyTargetPageInfo = new FxPageInfo<BeforeLivingDailyTargetDto>();
                liveAnchorDailyTargetPageInfo.TotalCount = BeforeLivingDailyTargetDtoList.Count();
                liveAnchorDailyTargetPageInfo.List = BeforeLivingDailyTargetDtoList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                foreach (var x in liveAnchorDailyTargetPageInfo.List)
                {
                    var afterLivingInfo = await _afterLivingDailyTarget.GetAll().Where(z => z.Valid && z.RecordDate == x.RecordDate && z.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefaultAsync();
                    if (afterLivingInfo != null)
                    {
                        x.AddWechatNum = afterLivingInfo.AddWechatNum;
                        x.SendOrderNum = afterLivingInfo.SendOrderNum;
                        x.DealNum = afterLivingInfo.DealNum;
                        x.PerformanceNum = afterLivingInfo.PerformanceNum;
                    }
                }
                return liveAnchorDailyTargetPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        /// <summary>
        /// 获取直播中主播日运营报表数据
        /// </summary>
        /// <param name="day">日期</param>
        /// <param name="operationEmpId">运营人员id</param>
        /// <param name="netWorkConEmpId">网咨人员id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<LivingDailyTargetDto>> GetLivingListWithPageAsync(DateTime startDate, DateTime endDate, int? liveAnchorId, int pageNum, int pageSize, int employeeId)
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
                #region 【数据获取】
                var tikTokDailyInfo = from d in _livingDailyTarget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetLiving)
                                      where d.RecordDate >= startDate && d.RecordDate < endDate
                                      && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetLiving.LiveAnchorId))
                                      && d.Valid
                                      select new LivingDailyTargetDto
                                      {
                                          Id = d.Id,
                                          LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                          LiveAnchor = d.LiveAnchorMonthlyTargetLiving.LiveAnchor.Name,
                                          CreateDate = d.CreateDate,
                                          UpdateDate = d.UpdateDate,
                                          RecordDate = d.RecordDate,
                                          OperationEmpId = d.OperationEmpId,
                                          OperationEmpName = d.AmiyaEmployee.Name,
                                          LivingRoomFlowInvestmentNum = d.LivingRoomFlowInvestmentNum,
                                          Consultation = d.Consultation,
                                          Consultation2 = d.Consultation2,
                                          CargoSettlementCommission = d.CargoSettlementCommission,
                                          RefundCard = d.RefundCard,
                                          GMV = d.GMV,
                                          EliminateCardGMV = d.EliminateCardGMV,
                                          RefundGMV = d.RefundGMV,
                                          TikTokPlusNum = d.TikTokPlusNum,
                                          QianChuanNum = d.QianChuanNum,
                                          ShuiXinTuiNum = d.ShuiXinTuiNum,
                                          WeiXinDou = d.WeiXinDou
                                      };
                var result = await tikTokDailyInfo.OrderByDescending(x => x.RecordDate).ToListAsync();

                #endregion

                FxPageInfo<LivingDailyTargetDto> liveAnchorDailyTargetPageInfo = new FxPageInfo<LivingDailyTargetDto>();
                liveAnchorDailyTargetPageInfo.TotalCount = result.Count();
                liveAnchorDailyTargetPageInfo.List = result.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                return liveAnchorDailyTargetPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }


        /// <summary>
        /// 获取直播后主播日运营报表数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<AfterLivingDailyTargetDto>> GetAfterLivingListWithPageAsync(DateTime startDate, DateTime endDate, int? liveAnchorId, int pageNum, int pageSize, int employeeId)
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
                #region 【数据获取】
                var tikTokDailyInfo = from d in _afterLivingDailyTarget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetAfterLiving)
                                      where d.RecordDate >= startDate && d.RecordDate < endDate
                                      && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorMonthlyTargetAfterLiving.LiveAnchorId))
                                      && d.Valid
                                      select new AfterLivingDailyTargetDto
                                      {
                                          Id = d.Id,
                                          LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                          LiveAnchor = d.LiveAnchorMonthlyTargetAfterLiving.LiveAnchor.Name,
                                          CreateDate = d.CreateDate,
                                          UpdateDate = d.UpdateDate,
                                          RecordDate = d.RecordDate,
                                          OperationEmpId = d.OperationEmpId,
                                          OperationEmpName = d.AmiyaEmployee.Name,
                                          AddWechatNum = d.AddWechatNum,
                                          ConsultationCardConsumed = d.ConsultationCardConsumed,
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
                                          NewPerformanceNum = d.NewPerformanceNum,
                                          SubsequentPerformanceNum = d.SubsequentPerformanceNum,
                                          NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                                          OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                                          PerformanceNum = d.PerformanceNum,
                                          MinivanRefund = d.MinivanRefund,
                                          MiniVanBadReviews = d.MiniVanBadReviews,
                                          PotentialPerformance = d.PotentialPerformance,
                                          EffectivePerformance = d.EffectivePerformance,
                                          DistributeConsulation=d.DistributeConsulation
                                      };
                var result = await tikTokDailyInfo.OrderByDescending(x => x.RecordDate).ToListAsync();

                #endregion

                FxPageInfo<AfterLivingDailyTargetDto> liveAnchorDailyTargetPageInfo = new FxPageInfo<AfterLivingDailyTargetDto>();
                liveAnchorDailyTargetPageInfo.TotalCount = result.Count();
                liveAnchorDailyTargetPageInfo.List = result.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                return liveAnchorDailyTargetPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
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

        public async Task<LiveAnchorDailyTargetDto> GetByIdAndTypeAsync(string id, int type)
        {
            try
            {
                LiveAnchorDailyTargetDto liveAnchorDailyTargetDto = new LiveAnchorDailyTargetDto();
                if (type == 1)
                {

                    var liveAnchorDailyTarget = await _beforeLivingTikTokDailyTraget.GetAll().Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).SingleOrDefaultAsync(e => e.Id == id);
                    if (liveAnchorDailyTarget == null)
                    {
                        throw new Exception("直播前抖音日运营目标情况编号错误！");
                    }
                    liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                    liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                    liveAnchorDailyTargetDto.LiveAnchorId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId;
                    liveAnchorDailyTargetDto.TikTokOperationEmployeeId = liveAnchorDailyTarget.OperationEmpId;
                    liveAnchorDailyTargetDto.TikTokSendNum = liveAnchorDailyTarget.SendNum;
                    liveAnchorDailyTargetDto.TikTokFlowInvestmentNum = liveAnchorDailyTarget.FlowInvestmentNum;
                    liveAnchorDailyTargetDto.RecordDate = liveAnchorDailyTarget.RecordDate;
                    liveAnchorDailyTargetDto.TikTokShowcaseIncome = liveAnchorDailyTarget.TikTokShowcaseIncome;
                    liveAnchorDailyTargetDto.TikTokIncreaseFans = liveAnchorDailyTarget.TikTokIncreaseFans;
                    liveAnchorDailyTargetDto.TikTokIncreaseFansFees = liveAnchorDailyTarget.TikTokIncreaseFansFees;
                    if (liveAnchorDailyTarget.TikTokIncreaseFans <= 0)
                    {
                        liveAnchorDailyTargetDto.TikTokIncreaseFansFeesCost = liveAnchorDailyTarget.TikTokIncreaseFansFees;
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.TikTokIncreaseFansFeesCost = Math.Round(liveAnchorDailyTarget.TikTokIncreaseFansFees / Convert.ToDecimal(liveAnchorDailyTarget.TikTokIncreaseFans), 2);
                    }
                    //liveAnchorDailyTargetDto.TikTokIncreaseFansFeesCost = liveAnchorDailyTarget.TikTokIncreaseFansFeesCost;
                    liveAnchorDailyTargetDto.TikTokClues = liveAnchorDailyTarget.TikTokClues;
                    liveAnchorDailyTargetDto.TikTokShowcaseFee= liveAnchorDailyTarget.TikTokShowCaseFee;
                }
                if (type == 2)
                {

                    var liveAnchorDailyTarget = await _beforeLivingZhiHuDailyTraget.GetAll().Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).SingleOrDefaultAsync(e => e.Id == id);
                    if (liveAnchorDailyTarget == null)
                    {
                        throw new Exception("直播前知乎日运营目标情况编号错误！");
                    }
                    liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                    liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                    liveAnchorDailyTargetDto.LiveAnchorId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId;
                    liveAnchorDailyTargetDto.ZhihuOperationEmployeeId = liveAnchorDailyTarget.OperationEmpId;
                    liveAnchorDailyTargetDto.ZhihuSendNum = liveAnchorDailyTarget.SendNum;
                    liveAnchorDailyTargetDto.ZhihuFlowInvestmentNum = liveAnchorDailyTarget.FlowInvestmentNum;
                    liveAnchorDailyTargetDto.RecordDate = liveAnchorDailyTarget.RecordDate;
                }

                if (type == 3)
                {

                    var liveAnchorDailyTarget = await _beforeLivingSinaWeiBoDailyTraget.GetAll().Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).SingleOrDefaultAsync(e => e.Id == id);
                    if (liveAnchorDailyTarget == null)
                    {
                        throw new Exception("直播前微博日运营目标情况编号错误！");
                    }
                    liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                    liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                    liveAnchorDailyTargetDto.LiveAnchorId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId;
                    liveAnchorDailyTargetDto.SinaWeiBoOperationEmployeeId = liveAnchorDailyTarget.OperationEmpId;
                    liveAnchorDailyTargetDto.SinaWeiBoSendNum = liveAnchorDailyTarget.SendNum;
                    liveAnchorDailyTargetDto.SinaWeiBoFlowInvestmentNum = liveAnchorDailyTarget.FlowInvestmentNum;
                    liveAnchorDailyTargetDto.RecordDate = liveAnchorDailyTarget.RecordDate;
                }

                if (type == 4)
                {

                    var liveAnchorDailyTarget = await _beforeLivingXiaoHongShuDailyTraget.GetAll().Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).SingleOrDefaultAsync(e => e.Id == id);
                    if (liveAnchorDailyTarget == null)
                    {
                        throw new Exception("直播前小红书日运营目标情况编号错误！");
                    }
                    liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                    liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                    liveAnchorDailyTargetDto.LiveAnchorId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId;
                    liveAnchorDailyTargetDto.XiaoHongShuOperationEmployeeId = liveAnchorDailyTarget.OperationEmpId;
                    liveAnchorDailyTargetDto.XiaoHongShuSendNum = liveAnchorDailyTarget.SendNum;
                    liveAnchorDailyTargetDto.XiaoHongShuFlowInvestmentNum = liveAnchorDailyTarget.FlowInvestmentNum;
                    liveAnchorDailyTargetDto.RecordDate = liveAnchorDailyTarget.RecordDate;
                    liveAnchorDailyTargetDto.XiaoHongShuShowcaseIncome = liveAnchorDailyTarget.XiaoHongShuShowcaseIncome;
                    liveAnchorDailyTargetDto.XiaoHongShuIncreaseFans = liveAnchorDailyTarget.XiaoHongShuIncreaseFans;
                    liveAnchorDailyTargetDto.XiaoHongShuIncreaseFansFees = liveAnchorDailyTarget.XiaoHongShuIncreaseFansFees;
                    if (liveAnchorDailyTarget.XiaoHongShuIncreaseFans <= 0)
                    {
                        liveAnchorDailyTargetDto.XiaoHongShuIncreaseFansFeesCost = liveAnchorDailyTarget.XiaoHongShuIncreaseFansFees;
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.XiaoHongShuIncreaseFansFeesCost = Math.Round(liveAnchorDailyTarget.XiaoHongShuIncreaseFansFees / Convert.ToDecimal(liveAnchorDailyTarget.XiaoHongShuIncreaseFans), 2);
                    }
                    //liveAnchorDailyTargetDto.XiaoHongShuIncreaseFansFeesCost = liveAnchorDailyTarget.XiaoHongShuIncreaseFansFeesCost;
                    liveAnchorDailyTargetDto.XiaoHongShuClues = liveAnchorDailyTarget.XiaoHongShuClues;
                    liveAnchorDailyTargetDto.XiaoHongShuShowcaseFee = liveAnchorDailyTarget.XiaoHongShuShowCaseFee;
                }

                if (type == 5)
                {

                    var liveAnchorDailyTarget = await _beforeLivingVideoDailyTraget.GetAll().Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).SingleOrDefaultAsync(e => e.Id == id);
                    if (liveAnchorDailyTarget == null)
                    {
                        throw new Exception("直播前视频号日运营目标情况编号错误！");
                    }
                    liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                    liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                    liveAnchorDailyTargetDto.LiveAnchorId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchorId;
                    liveAnchorDailyTargetDto.VideoOperationEmployeeId = liveAnchorDailyTarget.OperationEmpId;
                    liveAnchorDailyTargetDto.VideoSendNum = liveAnchorDailyTarget.SendNum;
                    liveAnchorDailyTargetDto.VideoFlowInvestmentNum = liveAnchorDailyTarget.FlowInvestmentNum;
                    liveAnchorDailyTargetDto.RecordDate = liveAnchorDailyTarget.RecordDate;
                    liveAnchorDailyTargetDto.VideoShowcaseIncome = liveAnchorDailyTarget.VideoShowcaseIncome;
                    liveAnchorDailyTargetDto.VideoIncreaseFans = liveAnchorDailyTarget.VideoIncreaseFans;
                    liveAnchorDailyTargetDto.VideoIncreaseFansFees = liveAnchorDailyTarget.VideoIncreaseFansFees;
                    //liveAnchorDailyTargetDto.VideoIncreaseFansFeesCost = liveAnchorDailyTarget.VideoIncreaseFansFeesCost;
                    if (liveAnchorDailyTarget.VideoIncreaseFans <= 0)
                    {
                        liveAnchorDailyTargetDto.VideoIncreaseFansFeesCost = liveAnchorDailyTarget.VideoIncreaseFansFees;
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.VideoIncreaseFansFeesCost = Math.Round(liveAnchorDailyTarget.VideoIncreaseFansFees / Convert.ToDecimal(liveAnchorDailyTarget.VideoIncreaseFans), 2);
                    }
                    liveAnchorDailyTargetDto.VideoClues = liveAnchorDailyTarget.VideoClues;
                    liveAnchorDailyTargetDto.VideoShowcaseFee = liveAnchorDailyTarget.VideoShowCaseFee;
                }


                if (type == 6)
                {

                    var liveAnchorDailyTarget = await _livingDailyTarget.GetAll().Include(x => x.LiveAnchorMonthlyTargetLiving).SingleOrDefaultAsync(e => e.Id == id);
                    if (liveAnchorDailyTarget == null)
                    {
                        throw new Exception("直播中日运营目标情况编号错误！");
                    }
                    liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                    liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                    liveAnchorDailyTargetDto.LiveAnchorId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetLiving.LiveAnchorId;
                    liveAnchorDailyTargetDto.LivingTrackingEmployeeId = liveAnchorDailyTarget.OperationEmpId;
                    liveAnchorDailyTargetDto.LivingRoomFlowInvestmentNum = liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                    liveAnchorDailyTargetDto.TikTokPlusNum = liveAnchorDailyTarget.TikTokPlusNum;
                    liveAnchorDailyTargetDto.QianChuanNum = liveAnchorDailyTarget.QianChuanNum;
                    liveAnchorDailyTargetDto.ShuiXinTuiNum = liveAnchorDailyTarget.ShuiXinTuiNum;
                    liveAnchorDailyTargetDto.WeiXinDou = liveAnchorDailyTarget.WeiXinDou;
                    liveAnchorDailyTargetDto.Consultation = liveAnchorDailyTarget.Consultation;
                    liveAnchorDailyTargetDto.Consultation2 = liveAnchorDailyTarget.Consultation2;
                    liveAnchorDailyTargetDto.CargoSettlementCommission = liveAnchorDailyTarget.CargoSettlementCommission;
                    liveAnchorDailyTargetDto.RecordDate = liveAnchorDailyTarget.RecordDate;
                    liveAnchorDailyTargetDto.RefundCard = liveAnchorDailyTarget.RefundCard;
                    liveAnchorDailyTargetDto.GMV = liveAnchorDailyTarget.GMV;
                    liveAnchorDailyTargetDto.EliminateCardGMV = liveAnchorDailyTarget.EliminateCardGMV;
                    liveAnchorDailyTargetDto.RefundGMV = liveAnchorDailyTarget.RefundGMV;
                }

                if (type == 7)
                {

                    var liveAnchorDailyTarget = await _afterLivingDailyTarget.GetAll().Include(x => x.LiveAnchorMonthlyTargetAfterLiving).SingleOrDefaultAsync(e => e.Id == id);
                    if (liveAnchorDailyTarget == null)
                    {
                        throw new Exception("直播后日运营目标情况编号错误！");
                    }

                    liveAnchorDailyTargetDto.Id = liveAnchorDailyTarget.Id;
                    liveAnchorDailyTargetDto.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                    liveAnchorDailyTargetDto.LiveAnchorId = liveAnchorDailyTarget.LiveAnchorMonthlyTargetAfterLiving.LiveAnchorId;
                    liveAnchorDailyTargetDto.NetWorkConsultingEmployeeId = liveAnchorDailyTarget.OperationEmpId;
                    liveAnchorDailyTargetDto.RecordDate = liveAnchorDailyTarget.RecordDate;
                    liveAnchorDailyTargetDto.AddWechatNum = liveAnchorDailyTarget.AddWechatNum;
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
                    liveAnchorDailyTargetDto.NewPerformanceNum = liveAnchorDailyTarget.NewPerformanceNum;
                    liveAnchorDailyTargetDto.SubsequentPerformanceNum = liveAnchorDailyTarget.SubsequentPerformanceNum;
                    liveAnchorDailyTargetDto.OldCustomerPerformanceNum = liveAnchorDailyTarget.OldCustomerPerformanceNum;
                    liveAnchorDailyTargetDto.NewCustomerPerformanceCountNum = liveAnchorDailyTarget.NewCustomerPerformanceCountNum;
                    liveAnchorDailyTargetDto.PerformanceNum = liveAnchorDailyTarget.PerformanceNum;
                    liveAnchorDailyTargetDto.MinivanRefund = liveAnchorDailyTarget.MinivanRefund;
                    liveAnchorDailyTargetDto.MiniVanBadReviews = liveAnchorDailyTarget.MiniVanBadReviews;
                    liveAnchorDailyTargetDto.EffectivePerformance = liveAnchorDailyTarget.EffectivePerformance;
                    liveAnchorDailyTargetDto.PotentialPerformance = liveAnchorDailyTarget.PotentialPerformance;
                    liveAnchorDailyTargetDto.DistributeConsulation = liveAnchorDailyTarget.DistributeConsulation;
                }

                return liveAnchorDailyTargetDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
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

                throw new Exception(ex.Message.ToString());
            }
        }

        #region 【暂停使用】
        public async Task AddAsync(AddLiveAnchorDailyTargetDto addDto)
        {
            //    unitOfWork.BeginTransaction();
            //    try
            //    {

            //        LiveAnchorDailyTarget liveAnchorDailyTarget = new LiveAnchorDailyTarget();
            //        liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
            //        liveAnchorDailyTarget.LiveanchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
            //        liveAnchorDailyTarget.LivingTrackingEmployeeId = addDto.LivingTrackingEmployeeId;
            //        liveAnchorDailyTarget.TikTokOperationEmployeeId = addDto.OperationEmployeeId;
            //        liveAnchorDailyTarget.NetWorkConsultingEmployeeId = addDto.NetWorkConsultingEmployeeId.HasValue ? addDto.NetWorkConsultingEmployeeId.Value : 0;
            //        liveAnchorDailyTarget.SinaWeiBoSendNum = addDto.SinaWeiBoSendNum;
            //        liveAnchorDailyTarget.ZhihuSendNum = addDto.ZhihuSendNum;
            //        liveAnchorDailyTarget.XiaoHongShuSendNum = addDto.XiaoHongShuSendNum;
            //        liveAnchorDailyTarget.TodaySendNum = addDto.TodaySendNum;
            //        liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
            //        liveAnchorDailyTarget.LivingRoomFlowInvestmentNum = addDto.LivingRoomFlowInvestmentNum;
            //        liveAnchorDailyTarget.AddFansNum = addDto.AddFansNum;
            //        liveAnchorDailyTarget.CluesNum = addDto.CluesNum;
            //        liveAnchorDailyTarget.AddWechatNum = addDto.AddWechatNum;
            //        liveAnchorDailyTarget.Consultation = addDto.Consultation;
            //        liveAnchorDailyTarget.ConsultationCardConsumed = addDto.ConsultationCardConsumed;
            //        liveAnchorDailyTarget.Consultation2 = addDto.Consultation2;
            //        liveAnchorDailyTarget.ConsultationCardConsumed2 = addDto.ConsultationCardConsumed2;
            //        liveAnchorDailyTarget.Consultation2 = addDto.Consultation2;
            //        liveAnchorDailyTarget.ConsultationCardConsumed2 = addDto.ConsultationCardConsumed2;
            //        liveAnchorDailyTarget.ActivateHistoricalConsultation = addDto.ActivateHistoricalConsultation;
            //        liveAnchorDailyTarget.SendOrderNum = addDto.SendOrderNum.HasValue ? addDto.SendOrderNum.Value : 0;
            //        liveAnchorDailyTarget.NewVisitNum = addDto.NewVisitNum.HasValue ? addDto.NewVisitNum.Value : 0;
            //        liveAnchorDailyTarget.SubsequentVisitNum = addDto.SubsequentVisitNum.HasValue ? addDto.SubsequentVisitNum.Value : 0;
            //        liveAnchorDailyTarget.OldCustomerVisitNum = addDto.OldCustomerVisitNum.HasValue ? addDto.OldCustomerVisitNum.Value : 0;
            //        liveAnchorDailyTarget.VisitNum = addDto.VisitNum.HasValue ? addDto.VisitNum.Value : 0;
            //        liveAnchorDailyTarget.NewDealNum = addDto.NewDealNum.HasValue ? addDto.NewDealNum.Value : 0;
            //        liveAnchorDailyTarget.SubsequentDealNum = addDto.SubsequentDealNum.HasValue ? addDto.SubsequentDealNum.Value : 0;
            //        liveAnchorDailyTarget.OldCustomerDealNum = addDto.OldCustomerDealNum.HasValue ? addDto.OldCustomerDealNum.Value : 0;
            //        liveAnchorDailyTarget.DealNum = addDto.DealNum.HasValue ? addDto.DealNum.Value : 0;
            //        liveAnchorDailyTarget.CargoSettlementCommission = addDto.CargoSettlementCommission;
            //        liveAnchorDailyTarget.NewPerformanceNum = addDto.NewPerformanceNum.HasValue ? addDto.NewPerformanceNum.Value : 0;
            //        liveAnchorDailyTarget.SubsequentPerformanceNum = addDto.SubsequentPerformanceNum.HasValue ? addDto.SubsequentPerformanceNum.Value : 0;
            //        liveAnchorDailyTarget.NewCustomerPerformanceCountNum = addDto.NewCustomerPerformanceCountNum.HasValue ? addDto.NewCustomerPerformanceCountNum.Value : 0;
            //        liveAnchorDailyTarget.OldCustomerPerformanceNum = addDto.OldCustomerPerformanceNum.HasValue ? addDto.OldCustomerPerformanceNum.Value : 0;
            //        liveAnchorDailyTarget.PerformanceNum = addDto.PerformanceNum.HasValue ? addDto.PerformanceNum.Value : 0;
            //        liveAnchorDailyTarget.MinivanRefund = addDto.MinivanRefund;
            //        liveAnchorDailyTarget.MiniVanBadReviews = addDto.MiniVanBadReviews;
            //        liveAnchorDailyTarget.CreateDate = DateTime.Now;
            //        liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
            //        await dalLiveAnchorDailyTarget.AddAsync(liveAnchorDailyTarget, true);

            //        UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
            //        editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
            //        editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
            //        editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
            //        editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = addDto.LivingRoomFlowInvestmentNum;
            //        editLiveAnchorMonthlyTarget.CumulativeCluesNum = addDto.CluesNum;
            //        editLiveAnchorMonthlyTarget.CumulativeAddFansNum = addDto.AddFansNum;
            //        editLiveAnchorMonthlyTarget.CumulativeAddWechat = addDto.AddWechatNum;
            //        editLiveAnchorMonthlyTarget.CumulativeConsultation = addDto.Consultation;
            //        editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = addDto.ConsultationCardConsumed;
            //        editLiveAnchorMonthlyTarget.CumulativeConsultation2 = addDto.Consultation2;
            //        editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = addDto.ConsultationCardConsumed2;
            //        editLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = addDto.ActivateHistoricalConsultation;
            //        editLiveAnchorMonthlyTarget.CumulativeSendOrder = addDto.SendOrderNum.HasValue ? addDto.SendOrderNum.Value : 0;

            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit = addDto.NewVisitNum.HasValue ? addDto.NewVisitNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit += addDto.SubsequentVisitNum.HasValue ? addDto.SubsequentVisitNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativeOldCustomerVisit = addDto.OldCustomerVisitNum.HasValue ? addDto.OldCustomerVisitNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativeVisit = addDto.VisitNum.HasValue ? addDto.VisitNum.Value : 0;


            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = addDto.NewDealNum.HasValue ? addDto.NewDealNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget += addDto.SubsequentDealNum.HasValue ? addDto.SubsequentDealNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = addDto.OldCustomerDealNum.HasValue ? addDto.OldCustomerDealNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativeDealTarget = addDto.DealNum.HasValue ? addDto.DealNum.Value : 0;

            //        editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = addDto.CargoSettlementCommission;
            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = addDto.NewPerformanceNum.HasValue ? addDto.NewPerformanceNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativeSubsequentPerformance = addDto.SubsequentPerformanceNum.HasValue ? addDto.SubsequentPerformanceNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = addDto.OldCustomerPerformanceNum.HasValue ? addDto.OldCustomerPerformanceNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativePerformance = addDto.PerformanceNum.HasValue ? addDto.PerformanceNum.Value : 0;
            //        editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = addDto.MiniVanBadReviews;
            //        editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = addDto.MinivanRefund;
            //        await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
            //        unitOfWork.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        unitOfWork.RollBack();
            //        throw new Exception(ex.Message.ToString());
            //    }
        }
        public async Task UpdateAsync(UpdateLiveAnchorDailyTargetDto updateDto)
        {
            //    unitOfWork.BeginTransaction();
            //    try
            //    {
            //        var liveAnchorDailyTarget = await dalLiveAnchorDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            //        if (updateDto.Id != liveAnchorDailyTarget.Id)
            //        {
            //            unitOfWork.RollBack();
            //            throw new Exception("修改内容与当前数据编号不一致，请重新操作！");
            //        }
            //        if (liveAnchorDailyTarget == null)
            //        {
            //            unitOfWork.RollBack();
            //            throw new Exception("主播日运营目标情况编号错误！");
            //        }
            //        //先扣除原有的
            //        UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
            //        editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
            //        editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.TodaySendNum;
            //        editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
            //        editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = -liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
            //        editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
            //        editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
            //        editLiveAnchorMonthlyTarget.CumulativeAddWechat = -liveAnchorDailyTarget.AddWechatNum;
            //        editLiveAnchorMonthlyTarget.CumulativeConsultation = -liveAnchorDailyTarget.Consultation;
            //        editLiveAnchorMonthlyTarget.CumulativeConsultation2 = -liveAnchorDailyTarget.Consultation2;
            //        editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = -liveAnchorDailyTarget.ConsultationCardConsumed;
            //        editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = -liveAnchorDailyTarget.ConsultationCardConsumed2;
            //        editLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = -liveAnchorDailyTarget.ActivateHistoricalConsultation;
            //        editLiveAnchorMonthlyTarget.CumulativeSendOrder = -liveAnchorDailyTarget.SendOrderNum;

            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit = -liveAnchorDailyTarget.NewVisitNum;
            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit -= liveAnchorDailyTarget.SubsequentVisitNum;
            //        editLiveAnchorMonthlyTarget.CumulativeOldCustomerVisit = -liveAnchorDailyTarget.OldCustomerVisitNum;
            //        editLiveAnchorMonthlyTarget.CumulativeVisit = -liveAnchorDailyTarget.VisitNum;

            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = -liveAnchorDailyTarget.NewDealNum;
            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget -= liveAnchorDailyTarget.SubsequentDealNum;
            //        editLiveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = -liveAnchorDailyTarget.OldCustomerDealNum;
            //        editLiveAnchorMonthlyTarget.CumulativeDealTarget = -liveAnchorDailyTarget.DealNum;
            //        editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = -liveAnchorDailyTarget.CargoSettlementCommission;
            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = -liveAnchorDailyTarget.NewPerformanceNum;
            //        editLiveAnchorMonthlyTarget.CumulativeSubsequentPerformance = -liveAnchorDailyTarget.SubsequentPerformanceNum;
            //        editLiveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = -liveAnchorDailyTarget.OldCustomerPerformanceNum;
            //        editLiveAnchorMonthlyTarget.CumulativePerformance = -liveAnchorDailyTarget.PerformanceNum;
            //        editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = -liveAnchorDailyTarget.MinivanRefund;
            //        editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = -liveAnchorDailyTarget.MiniVanBadReviews;
            //        await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

            //        liveAnchorDailyTarget.LiveanchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
            //        liveAnchorDailyTarget.TikTokOperationEmployeeId = updateDto.OperationEmployeeId;
            //        liveAnchorDailyTarget.LivingTrackingEmployeeId = updateDto.LivingTrackingEmployeeId;
            //        liveAnchorDailyTarget.NetWorkConsultingEmployeeId = updateDto.NetWorkConsultingEmployeeId;
            //        liveAnchorDailyTarget.TodaySendNum = updateDto.TodaySendNum;
            //        liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
            //        liveAnchorDailyTarget.LivingRoomFlowInvestmentNum = updateDto.LivingRoomFlowInvestmentNum;
            //        liveAnchorDailyTarget.CluesNum = updateDto.CluesNum;
            //        liveAnchorDailyTarget.AddFansNum = updateDto.AddFansNum;
            //        liveAnchorDailyTarget.AddWechatNum = updateDto.AddWechatNum;
            //        liveAnchorDailyTarget.Consultation = updateDto.Consultation;
            //        liveAnchorDailyTarget.ConsultationCardConsumed = updateDto.ConsultationCardConsumed;
            //        liveAnchorDailyTarget.Consultation2 = updateDto.Consultation2;
            //        liveAnchorDailyTarget.ConsultationCardConsumed2 = updateDto.ConsultationCardConsumed2;
            //        liveAnchorDailyTarget.ActivateHistoricalConsultation = updateDto.ActivateHistoricalConsultation;
            //        liveAnchorDailyTarget.SendOrderNum = updateDto.SendOrderNum;
            //        liveAnchorDailyTarget.NewVisitNum = updateDto.NewVisitNum;
            //        liveAnchorDailyTarget.SubsequentVisitNum = updateDto.SubsequentVisitNum;
            //        liveAnchorDailyTarget.OldCustomerVisitNum = updateDto.OldCustomerVisitNum;
            //        liveAnchorDailyTarget.VisitNum = updateDto.VisitNum;
            //        liveAnchorDailyTarget.NewDealNum = updateDto.NewDealNum;
            //        liveAnchorDailyTarget.SubsequentDealNum = updateDto.SubsequentDealNum;
            //        liveAnchorDailyTarget.OldCustomerDealNum = updateDto.OldCustomerDealNum;
            //        liveAnchorDailyTarget.DealNum = updateDto.DealNum;
            //        liveAnchorDailyTarget.CargoSettlementCommission = updateDto.CargoSettlementCommission;
            //        liveAnchorDailyTarget.NewPerformanceNum = updateDto.NewPerformanceNum;
            //        liveAnchorDailyTarget.SubsequentPerformanceNum = updateDto.SubsequentPerformanceNum;
            //        liveAnchorDailyTarget.OldCustomerPerformanceNum = updateDto.OldCustomerPerformanceNum;
            //        liveAnchorDailyTarget.NewCustomerPerformanceCountNum = updateDto.NewCustomerPerformanceCountNum;
            //        liveAnchorDailyTarget.PerformanceNum = updateDto.PerformanceNum;
            //        liveAnchorDailyTarget.MinivanRefund = updateDto.MinivanRefund;
            //        liveAnchorDailyTarget.MiniVanBadReviews = updateDto.MiniVanBadReviews;
            //        liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
            //        await dalLiveAnchorDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

            //        //添加修改后的
            //        UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
            //        lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
            //        lasteditLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = updateDto.LivingRoomFlowInvestmentNum;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeCluesNum = updateDto.CluesNum;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeAddFansNum = updateDto.AddFansNum;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeAddWechat = updateDto.AddWechatNum;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeConsultation = updateDto.Consultation;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeConsultation2 = updateDto.Consultation2;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = updateDto.ConsultationCardConsumed;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = updateDto.ConsultationCardConsumed2;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = updateDto.ActivateHistoricalConsultation;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeSendOrder = updateDto.SendOrderNum;

            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit = updateDto.NewVisitNum;
            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit += updateDto.SubsequentVisitNum;
            //        editLiveAnchorMonthlyTarget.CumulativeOldCustomerVisit = updateDto.OldCustomerVisitNum;
            //        editLiveAnchorMonthlyTarget.CumulativeVisit = updateDto.VisitNum;


            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = updateDto.NewDealNum;
            //        editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget += updateDto.SubsequentDealNum;
            //        editLiveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = updateDto.OldCustomerDealNum;
            //        editLiveAnchorMonthlyTarget.CumulativeDealTarget = updateDto.DealNum;

            //        lasteditLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = updateDto.CargoSettlementCommission;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = updateDto.NewPerformanceNum;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeSubsequentPerformance = updateDto.SubsequentPerformanceNum;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = updateDto.OldCustomerPerformanceNum;
            //        lasteditLiveAnchorMonthlyTarget.CumulativePerformance = updateDto.PerformanceNum;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeMinivanRefund = updateDto.MinivanRefund;
            //        lasteditLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = updateDto.MiniVanBadReviews;
            //        await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
            //        unitOfWork.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        unitOfWork.RollBack();
            //        throw new Exception(ex.Message.ToString());
            //    }
        }

        #endregion

        #region 【直播前】

        #region[抖音]
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="monthlyTargetId"></param>
        /// <param name="recordDate"></param>
        /// <returns></returns>
        public async Task<LiveAnchorDailyTargetDto> GetBeforeLivingTikTokLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate)
        {
            var liveAnchorDiaryInfo = from d in _beforeLivingTikTokDailyTraget.GetAll()
                                      where (d.RecordDate == recordDate) && (d.LiveAnchorMonthlyTargetId == monthlyTargetId)
                                      select new LiveAnchorDailyTargetDto
                                      {
                                          Id = d.Id,
                                      };
            var selectResult = await liveAnchorDiaryInfo.FirstOrDefaultAsync();
            return selectResult;
        }
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

                BeforeLivingTikTokDailyTarget liveAnchorDailyTarget = new BeforeLivingTikTokDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = addDto.TikTokOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.TikTokFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = addDto.TikTokSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;

                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.Valid = true;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                liveAnchorDailyTarget.TikTokShowcaseIncome = addDto.TikTokShowcaseIncome;
                liveAnchorDailyTarget.TikTokClues = addDto.TikTokClues;
                liveAnchorDailyTarget.TikTokIncreaseFans = addDto.TikTokIncreaseFans;
                liveAnchorDailyTarget.TikTokIncreaseFansFees = addDto.TikTokIncreaseFansFees;
                
                liveAnchorDailyTarget.TikTokShowCaseFee = addDto.TikTokShowCaseFee;               
                await _beforeLivingTikTokDailyTraget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeTikTokRelease = addDto.TikTokSendNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = addDto.TikTokFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokShowcaseIncome = addDto.TikTokShowcaseIncome;
                editLiveAnchorMonthlyTarget.CumulativeTikTokClues = addDto.TikTokClues;
                editLiveAnchorMonthlyTarget.CumulativeTikTokIncreaseFans = addDto.TikTokIncreaseFans;
                editLiveAnchorMonthlyTarget.CumulativeTikTokIncreaseFansFees = addDto.TikTokIncreaseFansFees;
                editLiveAnchorMonthlyTarget.CumulativeTikTokShowCaseFee = addDto.TikTokShowCaseFee;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
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
                var liveAnchorDailyTarget = await _beforeLivingTikTokDailyTraget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
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
                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeTikTokRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokShowcaseIncome = -liveAnchorDailyTarget.TikTokShowcaseIncome;
                editLiveAnchorMonthlyTarget.CumulativeTikTokIncreaseFans = -liveAnchorDailyTarget.TikTokIncreaseFans;
                editLiveAnchorMonthlyTarget.CumulativeTikTokIncreaseFansFees = -liveAnchorDailyTarget.TikTokIncreaseFansFees;
                editLiveAnchorMonthlyTarget.CumulativeTikTokClues = -liveAnchorDailyTarget.TikTokClues;
                editLiveAnchorMonthlyTarget.CumulativeTikTokShowCaseFee = -liveAnchorDailyTarget.TikTokShowCaseFee;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = updateDto.TikTokOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.TikTokFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = updateDto.TikTokSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                liveAnchorDailyTarget.TikTokShowcaseIncome = updateDto.TikTokShowcaseIncome;
                liveAnchorDailyTarget.TikTokIncreaseFans = updateDto.TikTokIncreaseFans;
                liveAnchorDailyTarget.TikTokIncreaseFansFees = updateDto.TikTokIncreaseFansFees;
                liveAnchorDailyTarget.TikTokClues = updateDto.TikTokClues;
                liveAnchorDailyTarget.TikTokShowCaseFee = updateDto.TikTokShowCaseFee;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;

                await _beforeLivingTikTokDailyTraget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeTikTokRelease = updateDto.TikTokSendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = updateDto.TikTokFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeTikTokShowcaseIncome = updateDto.TikTokShowcaseIncome;
                lasteditLiveAnchorMonthlyTarget.CumulativeTikTokClues = updateDto.TikTokClues;
                lasteditLiveAnchorMonthlyTarget.CumulativeTikTokIncreaseFansFees = updateDto.TikTokIncreaseFansFees;
                lasteditLiveAnchorMonthlyTarget.CumulativeTikTokIncreaseFans = updateDto.TikTokIncreaseFans;
                lasteditLiveAnchorMonthlyTarget.CumulativeTikTokShowCaseFee = updateDto.TikTokShowCaseFee;

                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion

        #region[知乎]
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="monthlyTargetId"></param>
        /// <param name="recordDate"></param>
        /// <returns></returns>
        public async Task<LiveAnchorDailyTargetDto> GetBeforeLivingZhihuLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate)
        {
            var liveAnchorDiaryInfo = from d in _beforeLivingZhiHuDailyTraget.GetAll()
                                      where (d.RecordDate == recordDate) && (d.LiveAnchorMonthlyTargetId == monthlyTargetId)
                                      select new LiveAnchorDailyTargetDto
                                      {
                                          Id = d.Id,
                                      };
            var selectResult = await liveAnchorDiaryInfo.FirstOrDefaultAsync();
            return selectResult;
        }
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

                BeforeLivingZhiHuDailyTarget liveAnchorDailyTarget = new BeforeLivingZhiHuDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = addDto.ZhihuOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.ZhihuFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = addDto.ZhihuSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.Valid = true;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                await _beforeLivingZhiHuDailyTraget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeZhihuRelease = addDto.ZhihuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment = addDto.ZhihuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
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
                var liveAnchorDailyTarget = await _beforeLivingZhiHuDailyTraget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
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
                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeZhihuRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = updateDto.ZhihuOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.ZhihuFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = updateDto.ZhihuSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                await _beforeLivingZhiHuDailyTraget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
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
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion

        #region[小红书]
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="monthlyTargetId"></param>
        /// <param name="recordDate"></param>
        /// <returns></returns>
        public async Task<LiveAnchorDailyTargetDto> GetBeforeLivingXiaoHongShuLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate)
        {
            var liveAnchorDiaryInfo = from d in _beforeLivingXiaoHongShuDailyTraget.GetAll()
                                      where (d.RecordDate == recordDate) && (d.LiveAnchorMonthlyTargetId == monthlyTargetId)
                                      select new LiveAnchorDailyTargetDto
                                      {
                                          Id = d.Id,
                                      };
            var selectResult = await liveAnchorDiaryInfo.FirstOrDefaultAsync();
            return selectResult;
        }
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

                BeforeLivingXiaoHongShuDailyTarget liveAnchorDailyTarget = new BeforeLivingXiaoHongShuDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = addDto.XiaoHongShuOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.XiaoHongShuFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = addDto.XiaoHongShuSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.Valid = true;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                liveAnchorDailyTarget.XiaoHongShuShowcaseIncome = addDto.XiaoHongShuShowcaseIncome;
                liveAnchorDailyTarget.XiaoHongShuClues = addDto.XiaoHongShuClues;
                liveAnchorDailyTarget.XiaoHongShuIncreaseFans = addDto.XiaoHongShuIncreaseFans;
                liveAnchorDailyTarget.XiaoHongShuIncreaseFansFees = addDto.XiaoHongShuIncreaseFansFees;
                liveAnchorDailyTarget.XiaoHongShuShowCaseFee = addDto.XiaoHongShuShowCaseFee;
                
                await _beforeLivingXiaoHongShuDailyTraget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = addDto.XiaoHongShuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = addDto.XiaoHongShuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuShowcaseIncome = addDto.XiaoHongShuShowcaseIncome;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuClues = addDto.XiaoHongShuClues;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuIncreaseFans = addDto.XiaoHongShuIncreaseFans;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuIncreaseFansFees = addDto.XiaoHongShuIncreaseFansFees;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuShowCaseFee = addDto.XiaoHongShuShowCaseFee;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
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
                var liveAnchorDailyTarget = await _beforeLivingXiaoHongShuDailyTraget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
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
                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuShowcaseIncome = -liveAnchorDailyTarget.XiaoHongShuShowcaseIncome;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuIncreaseFans = -liveAnchorDailyTarget.XiaoHongShuIncreaseFans;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuIncreaseFansFees = -liveAnchorDailyTarget.XiaoHongShuIncreaseFansFees;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuClues = -liveAnchorDailyTarget.XiaoHongShuClues;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuShowCaseFee = -liveAnchorDailyTarget.XiaoHongShuShowCaseFee;

                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);


                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = updateDto.XiaoHongShuOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.XiaoHongShuFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = updateDto.XiaoHongShuSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.XiaoHongShuShowcaseIncome = updateDto.XiaoHongShuShowcaseIncome;
                liveAnchorDailyTarget.XiaoHongShuIncreaseFans = updateDto.XiaoHongShuIncreaseFans;
                liveAnchorDailyTarget.XiaoHongShuIncreaseFansFees = updateDto.XiaoHongShuIncreaseFansFees;
                liveAnchorDailyTarget.XiaoHongShuClues = updateDto.XiaoHongShuClues;
                liveAnchorDailyTarget.XiaoHongShuShowCaseFee = updateDto.XiaoHongShuShowCaseFee;
                await _beforeLivingXiaoHongShuDailyTraget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = updateDto.XiaoHongShuSendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = updateDto.XiaoHongShuFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeXiaoHongShuShowcaseIncome = updateDto.XiaoHongShuShowcaseIncome;
                lasteditLiveAnchorMonthlyTarget.CumulativeXiaoHongShuIncreaseFans = updateDto.XiaoHongShuIncreaseFans;
                lasteditLiveAnchorMonthlyTarget.CumulativeXiaoHongShuIncreaseFansFees = updateDto.XiaoHongShuIncreaseFansFees;
                lasteditLiveAnchorMonthlyTarget.CumulativeXiaoHongShuClues = updateDto.XiaoHongShuClues;
                lasteditLiveAnchorMonthlyTarget.CumulativeXiaoHongShuShowCaseFee = updateDto.XiaoHongShuShowCaseFee;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion

        #region[微博]
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="monthlyTargetId"></param>
        /// <param name="recordDate"></param>
        /// <returns></returns>
        public async Task<LiveAnchorDailyTargetDto> GetBeforeLivingSinaWeiBoLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate)
        {
            var liveAnchorDiaryInfo = from d in _beforeLivingSinaWeiBoDailyTraget.GetAll()
                                      where (d.RecordDate == recordDate) && (d.LiveAnchorMonthlyTargetId == monthlyTargetId)
                                      select new LiveAnchorDailyTargetDto
                                      {
                                          Id = d.Id,
                                      };
            var selectResult = await liveAnchorDiaryInfo.FirstOrDefaultAsync();
            return selectResult;
        }
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

                BeforeLivingSinaWeiBoDailyTarget liveAnchorDailyTarget = new BeforeLivingSinaWeiBoDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = addDto.SinaWeiBoOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.SinaWeiBoFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = addDto.SinaWeiBoSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.Valid = true;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                await _beforeLivingSinaWeiBoDailyTraget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
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
                throw new Exception(ex.Message.ToString());
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
                var liveAnchorDailyTarget = await _beforeLivingSinaWeiBoDailyTraget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
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
                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = updateDto.SinaWeiBoOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.SinaWeiBoFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = updateDto.SinaWeiBoSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                await _beforeLivingSinaWeiBoDailyTraget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
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
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion

        #region[视频号]
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="monthlyTargetId"></param>
        /// <param name="recordDate"></param>
        /// <returns></returns>
        public async Task<LiveAnchorDailyTargetDto> GetBeforeLivingVideoLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate)
        {
            var liveAnchorDiaryInfo = from d in _beforeLivingVideoDailyTraget.GetAll()
                                      where (d.RecordDate == recordDate) && (d.LiveAnchorMonthlyTargetId == monthlyTargetId)
                                      select new LiveAnchorDailyTargetDto
                                      {
                                          Id = d.Id,
                                      };
            var selectResult = await liveAnchorDiaryInfo.FirstOrDefaultAsync();
            return selectResult;
        }
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


                BeforeLivingVideoDailyTarget liveAnchorDailyTarget = new BeforeLivingVideoDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = addDto.VideoOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.VideoFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = addDto.VideoSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = addDto.FlowInvestmentNum;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.Valid = true;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                liveAnchorDailyTarget.VideoShowcaseIncome = addDto.VideoShowcaseIncome;
                liveAnchorDailyTarget.VideoClues = addDto.VideoClues;
                liveAnchorDailyTarget.VideoIncreaseFans = addDto.VideoIncreaseFans;
                liveAnchorDailyTarget.VideoIncreaseFansFees = addDto.VideoIncreaseFansFees;
                liveAnchorDailyTarget.VideoShowCaseFee = addDto.VideoShowCaseFee;
                
                await _beforeLivingVideoDailyTraget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeVideoRelease = addDto.VideoSendNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = addDto.VideoFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = addDto.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = addDto.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoShowcaseIncome = addDto.VideoShowcaseIncome;
                editLiveAnchorMonthlyTarget.CumulativeVideoClues = addDto.VideoClues;
                editLiveAnchorMonthlyTarget.CumulativeVideoIncreaseFans = addDto.VideoIncreaseFans;
                editLiveAnchorMonthlyTarget.CumulativeVideoIncreaseFansFees = addDto.VideoIncreaseFansFees;
                editLiveAnchorMonthlyTarget.CumulativeVideoShowCaseFee = addDto.VideoShowCaseFee;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = addDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = addDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
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
                var liveAnchorDailyTarget = await _beforeLivingVideoDailyTraget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
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
                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.CumulativeVideoRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.SendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoShowcaseIncome = -liveAnchorDailyTarget.VideoShowcaseIncome;
                editLiveAnchorMonthlyTarget.CumulativeVideoIncreaseFans = -liveAnchorDailyTarget.VideoIncreaseFans;
                editLiveAnchorMonthlyTarget.CumulativeVideoIncreaseFansFees = -liveAnchorDailyTarget.VideoIncreaseFansFees;
                editLiveAnchorMonthlyTarget.CumulativeVideoClues = -liveAnchorDailyTarget.VideoClues;
                editLiveAnchorMonthlyTarget.CumulativeVideoShowCaseFee = -liveAnchorDailyTarget.VideoShowCaseFee;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = updateDto.VideoOperationEmployeeId;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.VideoFlowInvestmentNum;
                liveAnchorDailyTarget.SendNum = updateDto.VideoSendNum;
                liveAnchorDailyTarget.FlowInvestmentNum = updateDto.FlowInvestmentNum;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.VideoShowcaseIncome = updateDto.VideoShowcaseIncome;
                liveAnchorDailyTarget.VideoIncreaseFans = updateDto.VideoIncreaseFans;
                liveAnchorDailyTarget.VideoIncreaseFansFees = updateDto.VideoIncreaseFansFees;
                liveAnchorDailyTarget.VideoClues = updateDto.VideoClues;
                liveAnchorDailyTarget.VideoShowCaseFee = updateDto.VideoShowCaseFee;
                await _beforeLivingVideoDailyTraget.UpdateAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.CumulativeVideoRelease = updateDto.VideoSendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = updateDto.VideoFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeRelease = updateDto.TodaySendNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeFlowInvestment = updateDto.FlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeVideoShowcaseIncome = updateDto.VideoShowcaseIncome;
                lasteditLiveAnchorMonthlyTarget.CumulativeVideoIncreaseFans = updateDto.VideoIncreaseFans;
                lasteditLiveAnchorMonthlyTarget.CumulativeVideoIncreaseFansFees = updateDto.VideoIncreaseFansFees;
                lasteditLiveAnchorMonthlyTarget.CumulativeVideoClues = updateDto.VideoClues;
                lasteditLiveAnchorMonthlyTarget.CumulativeVideoShowCaseFee = updateDto.VideoShowCaseFee;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = updateDto.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = updateDto.AddFansNum;
                await _liveAnchorMonthlyTargetService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion

        #endregion

        #region 【直播中】
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="monthlyTargetId"></param>
        /// <param name="recordDate"></param>
        /// <returns></returns>
        public async Task<LiveAnchorDailyTargetDto> GetLivingLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate)
        {
            var liveAnchorDiaryInfo = from d in _livingDailyTarget.GetAll()
                                      where (d.RecordDate == recordDate) && (d.LiveAnchorMonthlyTargetId == monthlyTargetId)
                                      select new LiveAnchorDailyTargetDto
                                      {
                                          Id = d.Id,
                                      };
            var selectResult = await liveAnchorDiaryInfo.FirstOrDefaultAsync();
            return selectResult;
        }
        public async Task LivingAddAsync(LivingAddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                LivingDailyTarget liveAnchorDailyTarget = new LivingDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = addDto.LivingTrackingEmployeeId;
                liveAnchorDailyTarget.LivingRoomFlowInvestmentNum = addDto.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTarget.Consultation = addDto.Consultation;
                liveAnchorDailyTarget.Consultation2 = addDto.Consultation2;
                liveAnchorDailyTarget.CargoSettlementCommission = addDto.CargoSettlementCommission;
                liveAnchorDailyTarget.RefundCard = addDto.RefundCard;
                liveAnchorDailyTarget.GMV = addDto.GMV;
                liveAnchorDailyTarget.EliminateCardGMV = addDto.EliminateCardGMV;
                liveAnchorDailyTarget.RefundGMV = addDto.RefundGMV;
                liveAnchorDailyTarget.CreateDate = DateTime.Now;
                liveAnchorDailyTarget.Valid = true;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.RecordDate = addDto.RecordDate;
                liveAnchorDailyTarget.TikTokPlusNum = addDto.TikTokPlusNum;
                liveAnchorDailyTarget.QianChuanNum = addDto.QianChuanNum;
                liveAnchorDailyTarget.ShuiXinTuiNum = addDto.ShuiXinTuiNum;
                liveAnchorDailyTarget.WeiXinDou = addDto.WeiXinDou;
                await _livingDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = addDto.LiveanchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = addDto.LivingRoomFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeConsultation = addDto.Consultation;
                editLiveAnchorMonthlyTarget.CumulativeConsultation2 = addDto.Consultation2;
                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = addDto.CargoSettlementCommission;
                editLiveAnchorMonthlyTarget.RefundCard = addDto.RefundCard;
                editLiveAnchorMonthlyTarget.GMV = addDto.GMV;
                editLiveAnchorMonthlyTarget.EliminateCardGMV = addDto.EliminateCardGMV;
                editLiveAnchorMonthlyTarget.RefundGMV = addDto.RefundGMV;
                await _liveAnchorMonthlyTargetLivingService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task LivingUpdateAsync(LivingUpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await _livingDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
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
                UpdateLiveAnchorMonthlyLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
                editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = -liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeConsultation = -liveAnchorDailyTarget.Consultation;
                editLiveAnchorMonthlyTarget.CumulativeConsultation2 = -liveAnchorDailyTarget.Consultation2;
                editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = -liveAnchorDailyTarget.CargoSettlementCommission;
                editLiveAnchorMonthlyTarget.RefundCard = -liveAnchorDailyTarget.RefundCard;
                editLiveAnchorMonthlyTarget.GMV = -liveAnchorDailyTarget.GMV;
                editLiveAnchorMonthlyTarget.EliminateCardGMV = -liveAnchorDailyTarget.EliminateCardGMV;
                editLiveAnchorMonthlyTarget.RefundGMV = -liveAnchorDailyTarget.RefundGMV;
                await _liveAnchorMonthlyTargetLivingService.EditAsync(editLiveAnchorMonthlyTarget);

                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = updateDto.LivingTrackingEmployeeId;
                liveAnchorDailyTarget.LivingRoomFlowInvestmentNum = updateDto.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTarget.Consultation = updateDto.Consultation;
                liveAnchorDailyTarget.Consultation2 = updateDto.Consultation2;
                liveAnchorDailyTarget.CargoSettlementCommission = updateDto.CargoSettlementCommission;
                liveAnchorDailyTarget.RecordDate = updateDto.RecordDate;
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.RefundCard = updateDto.RefundCard;
                liveAnchorDailyTarget.GMV = updateDto.GMV;
                liveAnchorDailyTarget.EliminateCardGMV = updateDto.EliminateCardGMV;
                liveAnchorDailyTarget.RefundGMV = updateDto.RefundGMV;
                liveAnchorDailyTarget.TikTokPlusNum = updateDto.TikTokPlusNum;
                liveAnchorDailyTarget.QianChuanNum = updateDto.QianChuanNum;
                liveAnchorDailyTarget.ShuiXinTuiNum = updateDto.ShuiXinTuiNum;
                liveAnchorDailyTarget.WeiXinDou = updateDto.WeiXinDou;
                await _livingDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                //添加修改后的
                UpdateLiveAnchorMonthlyLivingTargetRateAndNumDto lasteditLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyLivingTargetRateAndNumDto();
                lasteditLiveAnchorMonthlyTarget.Id = updateDto.LiveanchorMonthlyTargetId;
                lasteditLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = updateDto.LivingRoomFlowInvestmentNum;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultation = updateDto.Consultation;
                lasteditLiveAnchorMonthlyTarget.CumulativeConsultation2 = updateDto.Consultation2;
                lasteditLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = updateDto.CargoSettlementCommission;
                lasteditLiveAnchorMonthlyTarget.RefundCard = updateDto.RefundCard;
                lasteditLiveAnchorMonthlyTarget.GMV = updateDto.GMV;
                lasteditLiveAnchorMonthlyTarget.EliminateCardGMV = updateDto.EliminateCardGMV;
                lasteditLiveAnchorMonthlyTarget.RefundGMV = updateDto.RefundGMV;
                await _liveAnchorMonthlyTargetLivingService.EditAsync(lasteditLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }
        #endregion

        #region 【直播后】
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="monthlyTargetId"></param>
        /// <param name="recordDate"></param>
        /// <returns></returns>
        public async Task<LiveAnchorDailyTargetDto> GetAfterLivingLiveAnchorInfoByMonthlyTargetIdAndDate(string monthlyTargetId, DateTime recordDate)
        {
            var liveAnchorDiaryInfo = from d in _afterLivingDailyTarget.GetAll()
                                      where (d.RecordDate == recordDate) && (d.LiveAnchorMonthlyTargetId == monthlyTargetId)
                                      select new LiveAnchorDailyTargetDto
                                      {
                                          Id = d.Id,
                                      };
            var selectResult = await liveAnchorDiaryInfo.FirstOrDefaultAsync();
            return selectResult;
        }
        public async Task AfterLivingAddAsync(AfterLivingAddLiveAnchorDailyTargetDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {

                AfterLivingDailyTarget liveAnchorDailyTarget = new AfterLivingDailyTarget();
                liveAnchorDailyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = addDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = addDto.NetWorkConsultingEmployeeId;

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
                liveAnchorDailyTarget.UpdateDate = DateTime.Now;
                liveAnchorDailyTarget.Valid = true;
                liveAnchorDailyTarget.EffectivePerformance = addDto.EffectivePerformance;
                liveAnchorDailyTarget.PotentialPerformance = addDto.PotentialPerformance;
                liveAnchorDailyTarget.DistributeConsulation = addDto.DistributeConsulation;
                await _afterLivingDailyTarget.AddAsync(liveAnchorDailyTarget, true);

                UpdateLiveAnchorMonthlyAfterLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyAfterLivingTargetRateAndNumDto();
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
                editLiveAnchorMonthlyTarget.EffectivePerformance = addDto.EffectivePerformance;
                editLiveAnchorMonthlyTarget.PotentialPerformance = addDto.PotentialPerformance;
                editLiveAnchorMonthlyTarget.DistributeConsulation=addDto.DistributeConsulation;
                await _liveAnchorMonthlyTargetAfterLivingService.EditAsync(editLiveAnchorMonthlyTarget);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task AfterLivingUpdateAsync(AfterLivingUpdateLiveAnchorDailyTargetDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var liveAnchorDailyTarget = await _afterLivingDailyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
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
                UpdateLiveAnchorMonthlyAfterLivingTargetRateAndNumDto editLiveAnchorMonthlyTargetDel = new UpdateLiveAnchorMonthlyAfterLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTargetDel.Id = liveAnchorDailyTarget.LiveAnchorMonthlyTargetId;
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
                editLiveAnchorMonthlyTargetDel.EffectivePerformance = -liveAnchorDailyTarget.EffectivePerformance;
                editLiveAnchorMonthlyTargetDel.PotentialPerformance = -liveAnchorDailyTarget.PotentialPerformance;
                editLiveAnchorMonthlyTargetDel.DistributeConsulation = -liveAnchorDailyTarget.DistributeConsulation;
                await _liveAnchorMonthlyTargetAfterLivingService.EditAsync(editLiveAnchorMonthlyTargetDel);

                liveAnchorDailyTarget.LiveAnchorMonthlyTargetId = updateDto.LiveanchorMonthlyTargetId;
                liveAnchorDailyTarget.OperationEmpId = updateDto.NetWorkConsultingEmployeeId;
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
                liveAnchorDailyTarget.UpdateDate = updateDto.AfterLivingUpdateDate;
                liveAnchorDailyTarget.PotentialPerformance = updateDto.PotentialPerformance;
                liveAnchorDailyTarget.EffectivePerformance = updateDto.EffectivePerformance;
                liveAnchorDailyTarget.DistributeConsulation=updateDto.DistributeConsulation;
                await _afterLivingDailyTarget.UpdateAsync(liveAnchorDailyTarget, true);

                //添加修改后的
                UpdateLiveAnchorMonthlyAfterLivingTargetRateAndNumDto editLiveAnchorMonthlyTargetAdd = new UpdateLiveAnchorMonthlyAfterLivingTargetRateAndNumDto();
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

                editLiveAnchorMonthlyTargetAdd.EffectivePerformance = updateDto.EffectivePerformance;
                editLiveAnchorMonthlyTargetAdd.PotentialPerformance = updateDto.PotentialPerformance;
                editLiveAnchorMonthlyTargetAdd.DistributeConsulation = updateDto.DistributeConsulation;

                await _liveAnchorMonthlyTargetAfterLivingService.EditAsync(editLiveAnchorMonthlyTargetAdd);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
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
                UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editLiveAnchorMonthlyTarget = new UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto();
                editLiveAnchorMonthlyTarget.Id = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;

                editLiveAnchorMonthlyTarget.CumulativeZhihuRelease = -liveAnchorDailyTarget.ZhihuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease = -liveAnchorDailyTarget.SinaWeiBoSendNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokRelease = -liveAnchorDailyTarget.TikTokSendNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = -liveAnchorDailyTarget.XiaoHongShuSendNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoRelease = -liveAnchorDailyTarget.VideoSendNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokShowcaseIncome = -liveAnchorDailyTarget.TikTokShowcaseIncome;

                editLiveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment = -liveAnchorDailyTarget.ZhihuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment = -liveAnchorDailyTarget.SinaWeiBoFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = -liveAnchorDailyTarget.TikTokFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = -liveAnchorDailyTarget.XiaoHongShuFlowInvestmentNum;
                editLiveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = -liveAnchorDailyTarget.VideoFlowInvestmentNum;

                editLiveAnchorMonthlyTarget.CumulativeRelease = -liveAnchorDailyTarget.TodaySendNum;
                editLiveAnchorMonthlyTarget.CumulativeFlowInvestment = -liveAnchorDailyTarget.FlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = -liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                //editLiveAnchorMonthlyTarget.CumulativeCluesNum = -liveAnchorDailyTarget.CluesNum;
                //editLiveAnchorMonthlyTarget.CumulativeAddFansNum = -liveAnchorDailyTarget.AddFansNum;
                //editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = -liveAnchorDailyTarget.ConsultationCardConsumed;
                //editLiveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = -liveAnchorDailyTarget.ActivateHistoricalConsultation;
                //editLiveAnchorMonthlyTarget.CumulativeAddWechat = -liveAnchorDailyTarget.AddWechatNum;
                //editLiveAnchorMonthlyTarget.CumulativeConsultation = -liveAnchorDailyTarget.Consultation;
                //editLiveAnchorMonthlyTarget.CumulativeConsultation2 = -liveAnchorDailyTarget.Consultation2;
                //editLiveAnchorMonthlyTarget.CumulativeConsultationCardConsumed2 = -liveAnchorDailyTarget.ConsultationCardConsumed2;
                //editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = -liveAnchorDailyTarget.MinivanRefund;
                //editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = -liveAnchorDailyTarget.MiniVanBadReviews;
                //editLiveAnchorMonthlyTarget.CumulativeSendOrder = -liveAnchorDailyTarget.SendOrderNum;

                //editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit = -liveAnchorDailyTarget.NewVisitNum;
                //editLiveAnchorMonthlyTarget.CumulativeNewCustomerVisit -= liveAnchorDailyTarget.SubsequentVisitNum;
                //editLiveAnchorMonthlyTarget.CumulativeOldCustomerVisit = -liveAnchorDailyTarget.OldCustomerVisitNum;
                //editLiveAnchorMonthlyTarget.CumulativeVisit = -liveAnchorDailyTarget.VisitNum;

                //editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget = -liveAnchorDailyTarget.NewDealNum;
                //editLiveAnchorMonthlyTarget.CumulativeNewCustomerDealTarget -= liveAnchorDailyTarget.SubsequentDealNum;
                //editLiveAnchorMonthlyTarget.CumulativeOldCustomerDealTarget = -liveAnchorDailyTarget.OldCustomerDealNum;
                //editLiveAnchorMonthlyTarget.CumulativeDealTarget = -liveAnchorDailyTarget.DealNum;

                //editLiveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = -liveAnchorDailyTarget.CargoSettlementCommission;
                //editLiveAnchorMonthlyTarget.CumulativeNewCustomerPerformance = -liveAnchorDailyTarget.NewPerformanceNum;
                //editLiveAnchorMonthlyTarget.CumulativeSubsequentPerformance = -liveAnchorDailyTarget.SubsequentPerformanceNum;
                //editLiveAnchorMonthlyTarget.CumulativeOldCustomerPerformance = -liveAnchorDailyTarget.OldCustomerPerformanceNum;
                //editLiveAnchorMonthlyTarget.CumulativePerformance = -liveAnchorDailyTarget.PerformanceNum;
                //editLiveAnchorMonthlyTarget.CumulativeMinivanRefund = -liveAnchorDailyTarget.MinivanRefund;
                //editLiveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = -liveAnchorDailyTarget.MiniVanBadReviews;
                await _liveAnchorMonthlyTargetService.EditAsync(editLiveAnchorMonthlyTarget);

                await dalLiveAnchorDailyTarget.DeleteAsync(liveAnchorDailyTarget, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<List<LiveAnchorDailyAndMonthTargetDto>> GetByDailyAndMonthAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                endDate = endDate.AddDays(1);

                #region 【数据获取】
                var tikTokDailyInfo = from d in _beforeLivingTikTokDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).ThenInclude(x => x.LiveAnchor)
                                      where d.RecordDate >= startDate && d.RecordDate < endDate
                                      && d.Valid
                                      select new BeforeLivingDailyTargetDto
                                      {
                                          Id = d.Id,
                                          LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                          LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                          CreateDate = d.CreateDate,
                                          UpdateDate = d.UpdateDate,
                                          RecordDate = d.RecordDate,
                                          OperationEmpId = d.OperationEmpId,
                                          OperationEmpName = d.AmiyaEmployee.Name,
                                          FlowInvestmentNum = d.FlowInvestmentNum,
                                          FlowinvestmentTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentTarget,
                                          CumulativeFlowinvestment = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuFlowinvestment,
                                          FlowinvestmentCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentCompleteRate.ToString() + "%",
                                          TikTokShowcaseIncome = d.TikTokShowcaseIncome,
                                          TikTokShowcaseIncomeTarget = d.LiveAnchorMonthlyTargetBeforeLiving.TikTokShowcaseIncomeTarget,
                                          CumulativeTikTokShowcaseIncome = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokShowcaseIncome,
                                          TikTokShowcaseIncomeCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.TikTokShowcaseIncomeCompleteRate.ToString() + "%",

                                          OperationFlowinvestmentTarget = d.LiveAnchorMonthlyTargetBeforeLiving.FlowInvestmentTarget,
                                          CumulativeOperationFlowinvestment = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeFlowInvestment,
                                          OperationFlowinvestmentCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.FlowInvestmentCompleteRate.ToString() + "%",

                                          SendNum = d.SendNum,
                                          ReleaseTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseTarget,
                                          CumulativeRelease = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuRelease,
                                          ReleaseCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseCompleteRate.ToString() + "%",

                                          MonthlyAllSendTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ReleaseTarget,
                                          CumulativeMonthlyAllSendNum = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeRelease,
                                          MonthlyAllSendNumCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ReleaseCompleteRate.ToString() + "%",
                                      };
                var tikTokDailyInfoList = await tikTokDailyInfo.ToListAsync();

                var xiaohongshuDailyInfo = from d in _beforeLivingXiaoHongShuDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).ThenInclude(x => x.LiveAnchor)
                                           where d.RecordDate >= startDate && d.RecordDate < endDate
                                           && d.Valid
                                           select new BeforeLivingDailyTargetDto
                                           {
                                               Id = d.Id,
                                               LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                               LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                               CreateDate = d.CreateDate,
                                               UpdateDate = d.UpdateDate,
                                               RecordDate = d.RecordDate,
                                               OperationEmpId = d.OperationEmpId,
                                               OperationEmpName = d.AmiyaEmployee.Name,
                                               FlowInvestmentNum = d.FlowInvestmentNum,
                                               FlowinvestmentTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentTarget,
                                               CumulativeFlowinvestment = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuFlowinvestment,
                                               FlowinvestmentCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentCompleteRate.ToString() + "%",

                                               SendNum = d.SendNum,
                                               ReleaseTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseTarget,
                                               CumulativeRelease = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuRelease,
                                               ReleaseCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseCompleteRate.ToString() + "%",
                                           };
                var xiaohongshuDailyInfoList = await xiaohongshuDailyInfo.ToListAsync();

                var videoDailyInfo = from d in _beforeLivingVideoDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).ThenInclude(x => x.LiveAnchor)
                                     where d.RecordDate >= startDate && d.RecordDate < endDate
                                     && d.Valid
                                     select new BeforeLivingDailyTargetDto
                                     {
                                         Id = d.Id,
                                         LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                         LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                         CreateDate = d.CreateDate,
                                         UpdateDate = d.UpdateDate,
                                         RecordDate = d.RecordDate,
                                         OperationEmpId = d.OperationEmpId,
                                         OperationEmpName = d.AmiyaEmployee.Name,
                                         FlowInvestmentNum = d.FlowInvestmentNum,
                                         FlowinvestmentTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentTarget,
                                         CumulativeFlowinvestment = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuFlowinvestment,
                                         FlowinvestmentCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentCompleteRate.ToString() + "%",

                                         SendNum = d.SendNum,
                                         ReleaseTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseTarget,
                                         CumulativeRelease = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuRelease,
                                         ReleaseCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseCompleteRate.ToString() + "%",
                                     };
                var videoDailyInfoList = await videoDailyInfo.ToListAsync();

                var zhihuDailyInfo = from d in _beforeLivingZhiHuDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).ThenInclude(x => x.LiveAnchor)
                                     where d.RecordDate >= startDate && d.RecordDate < endDate
                                     && d.Valid
                                     select new BeforeLivingDailyTargetDto
                                     {
                                         Id = d.Id,
                                         LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                         LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                         CreateDate = d.CreateDate,
                                         UpdateDate = d.UpdateDate,
                                         RecordDate = d.RecordDate,
                                         OperationEmpId = d.OperationEmpId,
                                         OperationEmpName = d.AmiyaEmployee.Name,

                                         FlowInvestmentNum = d.FlowInvestmentNum,
                                         FlowinvestmentTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentTarget,
                                         CumulativeFlowinvestment = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuFlowinvestment,
                                         FlowinvestmentCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentCompleteRate.ToString() + "%",

                                         SendNum = d.SendNum,
                                         ReleaseTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseTarget,
                                         CumulativeRelease = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuRelease,
                                         ReleaseCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseCompleteRate.ToString() + "%",
                                     };
                var zhihuDailyInfoList = await zhihuDailyInfo.ToListAsync();

                var sinaWeiBoDailyInfo = from d in _beforeLivingSinaWeiBoDailyTraget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetBeforeLiving).ThenInclude(x => x.LiveAnchor)
                                         where d.RecordDate >= startDate && d.RecordDate < endDate
                                         && d.Valid
                                         select new BeforeLivingDailyTargetDto
                                         {
                                             Id = d.Id,
                                             LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                             LiveAnchor = d.LiveAnchorMonthlyTargetBeforeLiving.LiveAnchor.Name,
                                             CreateDate = d.CreateDate,
                                             UpdateDate = d.UpdateDate,
                                             RecordDate = d.RecordDate,
                                             OperationEmpId = d.OperationEmpId,
                                             OperationEmpName = d.AmiyaEmployee.Name,
                                             FlowInvestmentNum = d.FlowInvestmentNum,
                                             FlowinvestmentTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentTarget,
                                             CumulativeFlowinvestment = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuFlowinvestment,
                                             FlowinvestmentCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentCompleteRate.ToString() + "%",

                                             SendNum = d.SendNum,
                                             ReleaseTarget = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseTarget,
                                             CumulativeRelease = d.LiveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuRelease,
                                             ReleaseCompleteRate = d.LiveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseCompleteRate.ToString() + "%",
                                         };
                var sinaWeiBoDailyInfoList = await sinaWeiBoDailyInfo.ToListAsync();

                var livingDailyInfo = from d in _livingDailyTarget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetLiving).ThenInclude(x => x.LiveAnchor)
                                      where d.RecordDate >= startDate && d.RecordDate < endDate
                                      && d.Valid
                                      select new LivingDailyTargetDto
                                      {
                                          Id = d.Id,
                                          LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                          LiveAnchor = d.LiveAnchorMonthlyTargetLiving.LiveAnchor.Name,
                                          CreateDate = d.CreateDate,
                                          UpdateDate = d.UpdateDate,
                                          RecordDate = d.RecordDate,
                                          OperationEmpId = d.OperationEmpId,
                                          OperationEmpName = d.AmiyaEmployee.Name,
                                          LivingRoomFlowInvestmentNum = d.LivingRoomFlowInvestmentNum,
                                          LivingRoomFlowInvestmentTarget = d.LiveAnchorMonthlyTargetLiving.LivingRoomFlowInvestmentTarget,
                                          LivingRoomCumulativeFlowInvestment = d.LiveAnchorMonthlyTargetLiving.LivingRoomCumulativeFlowInvestment,
                                          LivingRoomFlowInvestmentCompleteRate = d.LiveAnchorMonthlyTargetLiving.LivingRoomFlowInvestmentCompleteRate.ToString() + "%",

                                          CargoSettlementCommission = d.CargoSettlementCommission,
                                          CargoSettlementCommissionTarget = d.LiveAnchorMonthlyTargetLiving.CargoSettlementCommissionTarget,
                                          CumulativeCargoSettlementCommission = d.LiveAnchorMonthlyTargetLiving.CumulativeCargoSettlementCommission,
                                          CargoSettlementCommissionCompleteRate = d.LiveAnchorMonthlyTargetLiving.CargoSettlementCommissionCompleteRate.ToString() + "%",
                                          Consultation = d.Consultation,
                                          ConsultationTarget = d.LiveAnchorMonthlyTargetLiving.ConsultationTarget,
                                          CumulativeConsultation = d.LiveAnchorMonthlyTargetLiving.CumulativeConsultation,
                                          ConsultationCompleteRate = d.LiveAnchorMonthlyTargetLiving.ConsultationCompleteRate.ToString() + "%",
                                          Consultation2 = d.Consultation2,
                                          ConsultationTarget2 = d.LiveAnchorMonthlyTargetLiving.ConsultationTarget2,
                                          CumulativeConsultation2 = d.LiveAnchorMonthlyTargetLiving.CumulativeConsultation2,
                                          ConsultationCompleteRate2 = d.LiveAnchorMonthlyTargetLiving.ConsultationCompleteRate2.ToString() + "%",
                                      };

                var livingDailyInfoList = await livingDailyInfo.ToListAsync();

                var afterLivingDailyInfo = from d in _afterLivingDailyTarget.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.LiveAnchorMonthlyTargetAfterLiving).ThenInclude(x => x.LiveAnchor)
                                           where d.RecordDate >= startDate && d.RecordDate < endDate
                                           && d.Valid
                                           select new AfterLivingDailyTargetDto
                                           {
                                               Id = d.Id,
                                               LiveAnchorMonthlyTargetId = d.LiveAnchorMonthlyTargetId,
                                               LiveAnchor = d.LiveAnchorMonthlyTargetAfterLiving.LiveAnchor.Name,
                                               CreateDate = d.CreateDate,
                                               UpdateDate = d.UpdateDate,
                                               RecordDate = d.RecordDate,
                                               OperationEmpId = d.OperationEmpId,
                                               OperationEmpName = d.AmiyaEmployee.Name,

                                               AddWechatNum = d.AddWechatNum,
                                               AddWechatTarget = d.LiveAnchorMonthlyTargetAfterLiving.AddWechatTarget,
                                               CumulativeAddWechat = d.LiveAnchorMonthlyTargetAfterLiving.CumulativeAddWechat,
                                               AddWechatCompleteRate = d.LiveAnchorMonthlyTargetAfterLiving.AddWechatCompleteRate.ToString() + "%",

                                               ConsultationCardConsumed = d.ConsultationCardConsumed,
                                               ConsultationCardConsumedTarget = d.LiveAnchorMonthlyTargetAfterLiving.ConsultationCardConsumedTarget,
                                               CumulativeConsultationCardConsumed = d.LiveAnchorMonthlyTargetAfterLiving.CumulativeConsultationCardConsumed,
                                               ConsultationCardConsumedCompleteRate = d.LiveAnchorMonthlyTargetAfterLiving.ConsultationCardConsumedCompleteRate.ToString() + "%",

                                               ConsultationCardConsumed2 = d.ConsultationCardConsumed2,
                                               ConsultationCardConsumedTarget2 = d.LiveAnchorMonthlyTargetAfterLiving.ConsultationCardConsumedTarget2,
                                               CumulativeConsultationCardConsumed2 = d.LiveAnchorMonthlyTargetAfterLiving.CumulativeConsultationCardConsumed2,
                                               ConsultationCardConsumedCompleteRate2 = d.LiveAnchorMonthlyTargetAfterLiving.ConsultationCardConsumedCompleteRate2.ToString() + "%",

                                               ActivateHistoricalConsultation = d.ActivateHistoricalConsultation,
                                               ActivateHistoricalConsultationTarget = d.LiveAnchorMonthlyTargetAfterLiving.ActivateHistoricalConsultationTarget,
                                               CumulativeActivateHistoricalConsultation = d.LiveAnchorMonthlyTargetAfterLiving.CumulativeActivateHistoricalConsultation,
                                               ActivateHistoricalConsultationCompleteRate = d.LiveAnchorMonthlyTargetAfterLiving.ActivateHistoricalConsultationCompleteRate.ToString() + "%",

                                               SendOrderNum = d.SendOrderNum,
                                               SendOrderTarget = d.LiveAnchorMonthlyTargetAfterLiving.SendOrderTarget,
                                               CumulativeSendOrder = d.LiveAnchorMonthlyTargetAfterLiving.CumulativeSendOrder,
                                               SendOrderCompleteRate = d.LiveAnchorMonthlyTargetAfterLiving.SendOrderCompleteRate.ToString() + "%",

                                               NewVisitNum = d.NewVisitNum,
                                               SubsequentVisitNum = d.SubsequentVisitNum,
                                               OldCustomerVisitNum = d.OldCustomerVisitNum,
                                               VisitNum = d.VisitNum,
                                               VisitTarget = d.LiveAnchorMonthlyTargetAfterLiving.VisitTarget,
                                               CumulativeVisit = d.LiveAnchorMonthlyTargetAfterLiving.CumulativeVisit,
                                               VisitCompleteRate = d.LiveAnchorMonthlyTargetAfterLiving.VisitCompleteRate.ToString() + "%",

                                               NewDealNum = d.NewDealNum,
                                               SubsequentDealNum = d.SubsequentDealNum,
                                               OldCustomerDealNum = d.OldCustomerDealNum,
                                               DealNum = d.DealNum,
                                               DealTarget = d.LiveAnchorMonthlyTargetAfterLiving.DealTarget,
                                               CumulativeDealTarget = d.LiveAnchorMonthlyTargetAfterLiving.CumulativeDealTarget,
                                               DealRate = d.LiveAnchorMonthlyTargetAfterLiving.DealRate.ToString() + "%",

                                               NewPerformanceNum = d.NewPerformanceNum,
                                               SubsequentPerformanceNum = d.SubsequentPerformanceNum,
                                               NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                                               OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                                               PerformanceNum = d.PerformanceNum,
                                               PerformanceTarget = d.LiveAnchorMonthlyTargetAfterLiving.PerformanceTarget,
                                               CumulativePerformance = d.LiveAnchorMonthlyTargetAfterLiving.CumulativePerformance,
                                               PerformanceCompleteRate = d.LiveAnchorMonthlyTargetAfterLiving.PerformanceCompleteRate.ToString() + "%",
                                               MinivanRefund = d.MinivanRefund,
                                               MinivanRefundTarget = d.LiveAnchorMonthlyTargetAfterLiving.MinivanRefundTarget,
                                               CumulativeMinivanRefund = d.LiveAnchorMonthlyTargetAfterLiving.CumulativeMinivanRefund,
                                               MinivanRefundCompleteRate = d.LiveAnchorMonthlyTargetAfterLiving.MinivanRefundCompleteRate.ToString() + "%",
                                               MiniVanBadReviews = d.MiniVanBadReviews,
                                               MiniVanBadReviewsTarget = d.LiveAnchorMonthlyTargetAfterLiving.MiniVanBadReviewsTarget,
                                               CumulativeMiniVanBadReviews = d.LiveAnchorMonthlyTargetAfterLiving.CumulativeMiniVanBadReviews,
                                               MiniVanBadReviewsCompleteRate = d.LiveAnchorMonthlyTargetAfterLiving.MiniVanBadReviewsCompleteRate.ToString() + "%",
                                           };

                var afterLivingDailyInfoList = await afterLivingDailyInfo.ToListAsync();

                #endregion


                var diaryTargetInfo = await tikTokDailyInfo.OrderByDescending(x => x.RecordDate).ToListAsync();
                List<LiveAnchorDailyAndMonthTargetDto> resultList = new List<LiveAnchorDailyAndMonthTargetDto>();
                //筛选组合数据
                foreach (var x in diaryTargetInfo)
                {
                    //抖音
                    LiveAnchorDailyAndMonthTargetDto liveAnchorDailyTargetDto = new LiveAnchorDailyAndMonthTargetDto();
                    liveAnchorDailyTargetDto.RecordDate = x.RecordDate;
                    liveAnchorDailyTargetDto.LiveAnchor = x.LiveAnchor;
                    liveAnchorDailyTargetDto.TikTokOperationEmployeeName = x.OperationEmpName;
                    liveAnchorDailyTargetDto.TikTokSendNum = x.SendNum;
                    liveAnchorDailyTargetDto.TikTokReleaseTarget = x.ReleaseTarget;
                    liveAnchorDailyTargetDto.TikTokCumulativeRelease = x.CumulativeRelease;
                    liveAnchorDailyTargetDto.TikTokReleaseCompleteRate = x.ReleaseCompleteRate;
                    liveAnchorDailyTargetDto.TikTokShowcaseIncome = x.TikTokShowcaseIncome;
                    liveAnchorDailyTargetDto.CumulativeTikTokShowcaseIncome = x.CumulativeTikTokShowcaseIncome;
                    liveAnchorDailyTargetDto.TikTokShowcaseIncomeCompleteRate = x.TikTokShowcaseIncomeCompleteRate;

                    liveAnchorDailyTargetDto.ReleaseTarget = x.MonthlyAllSendTarget;
                    liveAnchorDailyTargetDto.CumulativeRelease = x.CumulativeMonthlyAllSendNum;
                    liveAnchorDailyTargetDto.ReleaseCompleteRate = x.MonthlyAllSendNumCompleteRate;

                    liveAnchorDailyTargetDto.TikTokFlowInvestmentNum = x.FlowInvestmentNum;
                    liveAnchorDailyTargetDto.TikTokFlowinvestmentTarget = x.FlowinvestmentTarget;
                    liveAnchorDailyTargetDto.CumulativeTikTokFlowinvestment = x.CumulativeFlowinvestment;
                    liveAnchorDailyTargetDto.TikTokFlowinvestmentCompleteRate = x.FlowinvestmentCompleteRate;
                    liveAnchorDailyTargetDto.FlowInvestmentTarget = x.OperationFlowinvestmentTarget;
                    liveAnchorDailyTargetDto.CumulativeFlowInvestment = x.CumulativeOperationFlowinvestment;
                    liveAnchorDailyTargetDto.FlowInvestmentCompleteRate = x.OperationFlowinvestmentCompleteRate;
                    liveAnchorDailyTargetDto.TikTokUpdateDate = x.UpdateDate;

                    ///小红书
                    var xiaohongshuThisDayDataInfo = xiaohongshuDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (xiaohongshuThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.XiaoHongShuOperationEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.XiaoHongShuSendNum = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuReleaseTarget = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuCumulativeRelease = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuReleaseCompleteRate = "0%";
                        liveAnchorDailyTargetDto.XiaoHongShuFlowInvestmentNum = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuFlowinvestmentTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeXiaoHongShuFlowinvestment = 0;
                        liveAnchorDailyTargetDto.XiaoHongShuFlowinvestmentCompleteRate = "0%";
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.XiaoHongShuOperationEmployeeName = xiaohongshuThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.XiaoHongShuSendNum = xiaohongshuThisDayDataInfo.SendNum;
                        liveAnchorDailyTargetDto.XiaoHongShuReleaseTarget = xiaohongshuThisDayDataInfo.ReleaseTarget;
                        liveAnchorDailyTargetDto.XiaoHongShuCumulativeRelease = xiaohongshuThisDayDataInfo.CumulativeRelease;
                        liveAnchorDailyTargetDto.XiaoHongShuReleaseCompleteRate = xiaohongshuThisDayDataInfo.ReleaseCompleteRate;
                        liveAnchorDailyTargetDto.XiaoHongShuFlowInvestmentNum = xiaohongshuThisDayDataInfo.FlowInvestmentNum;
                        liveAnchorDailyTargetDto.XiaoHongShuFlowinvestmentTarget = xiaohongshuThisDayDataInfo.FlowinvestmentTarget;
                        liveAnchorDailyTargetDto.CumulativeXiaoHongShuFlowinvestment = xiaohongshuThisDayDataInfo.CumulativeFlowinvestment;
                        liveAnchorDailyTargetDto.XiaoHongShuFlowinvestmentCompleteRate = xiaohongshuThisDayDataInfo.FlowinvestmentCompleteRate;
                    }
                    ///视频号
                    var videoThisDayDataInfo = videoDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (videoThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.VideoOperationEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.VideoSendNum = 0;
                        liveAnchorDailyTargetDto.VideoReleaseTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeVideoRelease = 0;
                        liveAnchorDailyTargetDto.VideoReleaseCompleteRate = "0%";
                        liveAnchorDailyTargetDto.VideoFlowInvestmentNum = 0;
                        liveAnchorDailyTargetDto.VideoFlowinvestmentTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeVideoFlowinvestment = 0;
                        liveAnchorDailyTargetDto.VideoFlowinvestmentCompleteRate = "0%";
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.VideoOperationEmployeeName = videoThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.VideoSendNum = videoThisDayDataInfo.SendNum;
                        liveAnchorDailyTargetDto.VideoReleaseTarget = videoThisDayDataInfo.ReleaseTarget;
                        liveAnchorDailyTargetDto.CumulativeVideoRelease = videoThisDayDataInfo.CumulativeRelease;
                        liveAnchorDailyTargetDto.VideoReleaseCompleteRate = videoThisDayDataInfo.ReleaseCompleteRate;
                        liveAnchorDailyTargetDto.VideoFlowInvestmentNum = videoThisDayDataInfo.FlowInvestmentNum;
                        liveAnchorDailyTargetDto.VideoFlowinvestmentTarget = videoThisDayDataInfo.FlowinvestmentTarget;
                        liveAnchorDailyTargetDto.CumulativeVideoFlowinvestment = videoThisDayDataInfo.CumulativeFlowinvestment;
                        liveAnchorDailyTargetDto.VideoFlowinvestmentCompleteRate = videoThisDayDataInfo.FlowinvestmentCompleteRate;
                    }

                    ///微博
                    var sinaWeiBoThisDayDataInfo = sinaWeiBoDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (sinaWeiBoThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.SinaWeiBoOperationEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.SinaWeiBoSendNum = 0;
                        liveAnchorDailyTargetDto.SinaWeiBoReleaseTarget = 0;
                        liveAnchorDailyTargetDto.SinaWeiBoCumulativeRelease = 0;
                        liveAnchorDailyTargetDto.SinaWeiBoReleaseCompleteRate = "0%";
                        liveAnchorDailyTargetDto.SinaWeiBoFlowInvestmentNum = 0;
                        liveAnchorDailyTargetDto.SinaWeiBoFlowinvestmentTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeSinaWeiBoFlowinvestment = 0;
                        liveAnchorDailyTargetDto.SinaWeiBoFlowinvestmentCompleteRate = "0%";
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.SinaWeiBoOperationEmployeeName = sinaWeiBoThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.SinaWeiBoSendNum = sinaWeiBoThisDayDataInfo.SendNum;
                        liveAnchorDailyTargetDto.SinaWeiBoReleaseTarget = sinaWeiBoThisDayDataInfo.ReleaseTarget;
                        liveAnchorDailyTargetDto.SinaWeiBoCumulativeRelease = sinaWeiBoThisDayDataInfo.CumulativeRelease;
                        liveAnchorDailyTargetDto.SinaWeiBoReleaseCompleteRate = sinaWeiBoThisDayDataInfo.ReleaseCompleteRate;
                        liveAnchorDailyTargetDto.SinaWeiBoFlowInvestmentNum = sinaWeiBoThisDayDataInfo.FlowInvestmentNum;
                        liveAnchorDailyTargetDto.SinaWeiBoFlowinvestmentTarget = sinaWeiBoThisDayDataInfo.FlowinvestmentTarget;
                        liveAnchorDailyTargetDto.CumulativeSinaWeiBoFlowinvestment = sinaWeiBoThisDayDataInfo.CumulativeFlowinvestment;
                        liveAnchorDailyTargetDto.SinaWeiBoFlowinvestmentCompleteRate = sinaWeiBoThisDayDataInfo.FlowinvestmentCompleteRate;
                    }

                    ///知乎
                    var zhihuThisDayDataInfo = zhihuDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (zhihuThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.ZhihuOperationEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.ZhihuSendNum = 0;
                        liveAnchorDailyTargetDto.ZhihuReleaseTarget = 0;
                        liveAnchorDailyTargetDto.ZhihuCumulativeRelease = 0;
                        liveAnchorDailyTargetDto.ZhihuReleaseCompleteRate = "0%";
                        liveAnchorDailyTargetDto.ZhihuFlowInvestmentNum = 0;
                        liveAnchorDailyTargetDto.ZhihuFlowinvestmentTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeZhihuFlowinvestment = 0;
                        liveAnchorDailyTargetDto.ZhihuFlowinvestmentCompleteRate = "0%";
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.ZhihuOperationEmployeeName = zhihuThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.ZhihuSendNum = zhihuThisDayDataInfo.SendNum;
                        liveAnchorDailyTargetDto.ZhihuReleaseTarget = zhihuThisDayDataInfo.ReleaseTarget;
                        liveAnchorDailyTargetDto.ZhihuCumulativeRelease = zhihuThisDayDataInfo.CumulativeRelease;
                        liveAnchorDailyTargetDto.ZhihuReleaseCompleteRate = zhihuThisDayDataInfo.ReleaseCompleteRate;
                        liveAnchorDailyTargetDto.ZhihuFlowInvestmentNum = zhihuThisDayDataInfo.FlowInvestmentNum;
                        liveAnchorDailyTargetDto.ZhihuFlowinvestmentTarget = zhihuThisDayDataInfo.FlowinvestmentTarget;
                        liveAnchorDailyTargetDto.CumulativeZhihuFlowinvestment = zhihuThisDayDataInfo.CumulativeFlowinvestment;
                        liveAnchorDailyTargetDto.ZhihuFlowinvestmentCompleteRate = zhihuThisDayDataInfo.FlowinvestmentCompleteRate;
                    }

                    ///直播中
                    var livingThisDayDataInfo = livingDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (livingThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.LivingTrackingEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.LivingRoomFlowInvestmentNum = 0.00M;
                        liveAnchorDailyTargetDto.LivingRoomFlowInvestmentTarget = 0.00M;
                        liveAnchorDailyTargetDto.LivingRoomCumulativeFlowInvestment = 0.00M;
                        liveAnchorDailyTargetDto.LivingRoomFlowInvestmentCompleteRate = "0%";
                        liveAnchorDailyTargetDto.CargoSettlementCommission = 0.00M;
                        liveAnchorDailyTargetDto.CargoSettlementCommissionTarget = 0.00M;
                        liveAnchorDailyTargetDto.CumulativeCargoSettlementCommission = 0.00M;
                        liveAnchorDailyTargetDto.CargoSettlementCommissionCompleteRate = "0%";
                        liveAnchorDailyTargetDto.Consultation = 0;
                        liveAnchorDailyTargetDto.ConsultationTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeConsultation = 0;
                        liveAnchorDailyTargetDto.ConsultationCompleteRate = "0%";
                        liveAnchorDailyTargetDto.Consultation2 = 0;
                        liveAnchorDailyTargetDto.ConsultationTarget2 = 0;
                        liveAnchorDailyTargetDto.CumulativeConsultation2 = 0;
                        liveAnchorDailyTargetDto.ConsultationCompleteRate2 = "0%";
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.LivingTrackingEmployeeName = livingThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.LivingRoomFlowInvestmentNum = livingThisDayDataInfo.LivingRoomFlowInvestmentNum;
                        liveAnchorDailyTargetDto.LivingRoomFlowInvestmentTarget = livingThisDayDataInfo.LivingRoomFlowInvestmentTarget;
                        liveAnchorDailyTargetDto.LivingRoomCumulativeFlowInvestment = livingThisDayDataInfo.LivingRoomCumulativeFlowInvestment;
                        liveAnchorDailyTargetDto.LivingRoomFlowInvestmentCompleteRate = livingThisDayDataInfo.LivingRoomFlowInvestmentCompleteRate;
                        liveAnchorDailyTargetDto.CargoSettlementCommission = livingThisDayDataInfo.CargoSettlementCommission;
                        liveAnchorDailyTargetDto.CargoSettlementCommissionTarget = livingThisDayDataInfo.CargoSettlementCommissionTarget;
                        liveAnchorDailyTargetDto.CumulativeCargoSettlementCommission = livingThisDayDataInfo.CumulativeCargoSettlementCommission;
                        liveAnchorDailyTargetDto.CargoSettlementCommissionCompleteRate = livingThisDayDataInfo.CargoSettlementCommissionCompleteRate;
                        liveAnchorDailyTargetDto.Consultation = livingThisDayDataInfo.Consultation;
                        liveAnchorDailyTargetDto.ConsultationTarget = livingThisDayDataInfo.ConsultationTarget;
                        liveAnchorDailyTargetDto.CumulativeConsultation = livingThisDayDataInfo.CumulativeConsultation;
                        liveAnchorDailyTargetDto.ConsultationCompleteRate = livingThisDayDataInfo.ConsultationCompleteRate;
                        liveAnchorDailyTargetDto.Consultation2 = livingThisDayDataInfo.Consultation2;
                        liveAnchorDailyTargetDto.ConsultationTarget2 = livingThisDayDataInfo.ConsultationTarget2;
                        liveAnchorDailyTargetDto.CumulativeConsultation2 = livingThisDayDataInfo.CumulativeConsultation2;
                        liveAnchorDailyTargetDto.ConsultationCompleteRate2 = livingThisDayDataInfo.ConsultationCompleteRate2;
                        liveAnchorDailyTargetDto.LivingUpdateDate = livingThisDayDataInfo.UpdateDate;
                    }

                    ///直播后
                    var afterLivingThisDayDataInfo = afterLivingDailyInfoList.Where(k => k.RecordDate == x.RecordDate && k.LiveAnchorMonthlyTargetId == x.LiveAnchorMonthlyTargetId).FirstOrDefault();
                    if (afterLivingThisDayDataInfo == null)
                    {
                        liveAnchorDailyTargetDto.NetWorkConsultingEmployeeName = "未填写";
                        liveAnchorDailyTargetDto.AddWechatNum = 0;
                        liveAnchorDailyTargetDto.AddWechatTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeAddWechat = 0;
                        liveAnchorDailyTargetDto.AddWechatCompleteRate = "0%";

                        liveAnchorDailyTargetDto.ConsultationCardConsumed = 0;
                        liveAnchorDailyTargetDto.ConsultationCardConsumedTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeConsultationCardConsumed = 0;
                        liveAnchorDailyTargetDto.ConsultationCardConsumedCompleteRate = "0%";

                        liveAnchorDailyTargetDto.ConsultationCardConsumed2 = 0;
                        liveAnchorDailyTargetDto.ConsultationCardConsumedTarget2 = 0;
                        liveAnchorDailyTargetDto.CumulativeConsultationCardConsumed2 = 0;
                        liveAnchorDailyTargetDto.ConsultationCardConsumedCompleteRate2 = "0%";

                        liveAnchorDailyTargetDto.ActivateHistoricalConsultation = 0;
                        liveAnchorDailyTargetDto.ActivateHistoricalConsultationTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeActivateHistoricalConsultation = 0;
                        liveAnchorDailyTargetDto.ActivateHistoricalConsultationCompleteRate = "0%";

                        liveAnchorDailyTargetDto.SendOrderNum = 0;
                        liveAnchorDailyTargetDto.SendOrderTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeSendOrder = 0;
                        liveAnchorDailyTargetDto.SendOrderCompleteRate = "0%";

                        liveAnchorDailyTargetDto.NewVisitNum = 0;
                        liveAnchorDailyTargetDto.SubsequentVisitNum = 0;
                        liveAnchorDailyTargetDto.OldCustomerVisitNum = 0;
                        liveAnchorDailyTargetDto.VisitNum = 0;
                        liveAnchorDailyTargetDto.VisitTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeVisit = 0;
                        liveAnchorDailyTargetDto.VisitCompleteRate = "0%";

                        liveAnchorDailyTargetDto.NewDealNum = 0;
                        liveAnchorDailyTargetDto.SubsequentDealNum = 0;
                        liveAnchorDailyTargetDto.OldCustomerDealNum = 0;
                        liveAnchorDailyTargetDto.DealNum = 0;
                        liveAnchorDailyTargetDto.DealTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeDealTarget = 0;
                        liveAnchorDailyTargetDto.DealRate = "0%";

                        liveAnchorDailyTargetDto.NewPerformanceNum = 0;
                        liveAnchorDailyTargetDto.SubsequentPerformanceNum = 0;
                        liveAnchorDailyTargetDto.NewCustomerPerformanceCountNum = 0;
                        liveAnchorDailyTargetDto.OldCustomerPerformanceNum = 0;

                        liveAnchorDailyTargetDto.PerformanceNum = 0;
                        liveAnchorDailyTargetDto.PerformanceTarget = 0;
                        liveAnchorDailyTargetDto.CumulativePerformance = 0;
                        liveAnchorDailyTargetDto.PerformanceCompleteRate = "0%";

                        liveAnchorDailyTargetDto.MinivanRefund = 0;
                        liveAnchorDailyTargetDto.MinivanRefundTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeMinivanRefund = 0;
                        liveAnchorDailyTargetDto.MinivanRefundCompleteRate = "0%";

                        liveAnchorDailyTargetDto.MiniVanBadReviews = 0;
                        liveAnchorDailyTargetDto.MiniVanBadReviewsTarget = 0;
                        liveAnchorDailyTargetDto.CumulativeMiniVanBadReviews = 0;
                        liveAnchorDailyTargetDto.MiniVanBadReviewsCompleteRate = "0%";
                    }
                    else
                    {
                        liveAnchorDailyTargetDto.NetWorkConsultingEmployeeName = afterLivingThisDayDataInfo.OperationEmpName;
                        liveAnchorDailyTargetDto.AddWechatNum = afterLivingThisDayDataInfo.AddWechatNum;
                        liveAnchorDailyTargetDto.AddWechatTarget = afterLivingThisDayDataInfo.AddWechatTarget;
                        liveAnchorDailyTargetDto.CumulativeAddWechat = afterLivingThisDayDataInfo.CumulativeAddWechat;
                        liveAnchorDailyTargetDto.AddWechatCompleteRate = afterLivingThisDayDataInfo.AddWechatCompleteRate;

                        liveAnchorDailyTargetDto.ConsultationCardConsumed = afterLivingThisDayDataInfo.ConsultationCardConsumed;
                        liveAnchorDailyTargetDto.ConsultationCardConsumedTarget = afterLivingThisDayDataInfo.ConsultationCardConsumedTarget;
                        liveAnchorDailyTargetDto.CumulativeConsultationCardConsumed = afterLivingThisDayDataInfo.CumulativeConsultationCardConsumed;
                        liveAnchorDailyTargetDto.ConsultationCardConsumedCompleteRate = afterLivingThisDayDataInfo.ConsultationCardConsumedCompleteRate;

                        liveAnchorDailyTargetDto.ConsultationCardConsumed2 = afterLivingThisDayDataInfo.ConsultationCardConsumed2;
                        liveAnchorDailyTargetDto.ConsultationCardConsumedTarget2 = afterLivingThisDayDataInfo.ConsultationCardConsumedTarget2;
                        liveAnchorDailyTargetDto.CumulativeConsultationCardConsumed2 = afterLivingThisDayDataInfo.CumulativeConsultationCardConsumed2;
                        liveAnchorDailyTargetDto.ConsultationCardConsumedCompleteRate2 = afterLivingThisDayDataInfo.ConsultationCardConsumedCompleteRate2;

                        liveAnchorDailyTargetDto.ActivateHistoricalConsultation = afterLivingThisDayDataInfo.ActivateHistoricalConsultation;
                        liveAnchorDailyTargetDto.ActivateHistoricalConsultationTarget = afterLivingThisDayDataInfo.ActivateHistoricalConsultationTarget;
                        liveAnchorDailyTargetDto.CumulativeActivateHistoricalConsultation = afterLivingThisDayDataInfo.CumulativeActivateHistoricalConsultation;
                        liveAnchorDailyTargetDto.ActivateHistoricalConsultationCompleteRate = afterLivingThisDayDataInfo.ActivateHistoricalConsultationCompleteRate;

                        liveAnchorDailyTargetDto.SendOrderNum = afterLivingThisDayDataInfo.SendOrderNum;
                        liveAnchorDailyTargetDto.SendOrderTarget = afterLivingThisDayDataInfo.SendOrderTarget;
                        liveAnchorDailyTargetDto.CumulativeSendOrder = afterLivingThisDayDataInfo.CumulativeSendOrder;
                        liveAnchorDailyTargetDto.SendOrderCompleteRate = afterLivingThisDayDataInfo.SendOrderCompleteRate;

                        liveAnchorDailyTargetDto.NewVisitNum = afterLivingThisDayDataInfo.NewVisitNum;
                        liveAnchorDailyTargetDto.SubsequentVisitNum = afterLivingThisDayDataInfo.SubsequentVisitNum;
                        liveAnchorDailyTargetDto.OldCustomerVisitNum = afterLivingThisDayDataInfo.OldCustomerVisitNum;
                        liveAnchorDailyTargetDto.VisitNum = afterLivingThisDayDataInfo.VisitNum;
                        liveAnchorDailyTargetDto.VisitTarget = afterLivingThisDayDataInfo.VisitTarget;
                        liveAnchorDailyTargetDto.CumulativeVisit = afterLivingThisDayDataInfo.CumulativeVisit;
                        liveAnchorDailyTargetDto.VisitCompleteRate = afterLivingThisDayDataInfo.VisitCompleteRate;

                        liveAnchorDailyTargetDto.NewDealNum = afterLivingThisDayDataInfo.NewDealNum;
                        liveAnchorDailyTargetDto.SubsequentDealNum = afterLivingThisDayDataInfo.SubsequentDealNum;
                        liveAnchorDailyTargetDto.OldCustomerDealNum = afterLivingThisDayDataInfo.OldCustomerDealNum;
                        liveAnchorDailyTargetDto.DealNum = afterLivingThisDayDataInfo.DealNum;
                        liveAnchorDailyTargetDto.DealTarget = afterLivingThisDayDataInfo.DealTarget;
                        liveAnchorDailyTargetDto.CumulativeDealTarget = afterLivingThisDayDataInfo.CumulativeDealTarget;
                        liveAnchorDailyTargetDto.DealRate = afterLivingThisDayDataInfo.DealRate;

                        liveAnchorDailyTargetDto.NewPerformanceNum = afterLivingThisDayDataInfo.NewPerformanceNum;
                        liveAnchorDailyTargetDto.SubsequentPerformanceNum = afterLivingThisDayDataInfo.SubsequentPerformanceNum;
                        liveAnchorDailyTargetDto.NewCustomerPerformanceCountNum = afterLivingThisDayDataInfo.NewCustomerPerformanceCountNum;
                        liveAnchorDailyTargetDto.OldCustomerPerformanceNum = afterLivingThisDayDataInfo.OldCustomerPerformanceNum;
                        liveAnchorDailyTargetDto.PerformanceNum = afterLivingThisDayDataInfo.PerformanceNum;
                        liveAnchorDailyTargetDto.PerformanceTarget = afterLivingThisDayDataInfo.PerformanceTarget;
                        liveAnchorDailyTargetDto.CumulativePerformance = afterLivingThisDayDataInfo.CumulativePerformance;
                        liveAnchorDailyTargetDto.PerformanceCompleteRate = afterLivingThisDayDataInfo.PerformanceCompleteRate;
                        liveAnchorDailyTargetDto.MinivanRefund = afterLivingThisDayDataInfo.MinivanRefund;
                        liveAnchorDailyTargetDto.MinivanRefundTarget = afterLivingThisDayDataInfo.MinivanRefundTarget;
                        liveAnchorDailyTargetDto.CumulativeMinivanRefund = afterLivingThisDayDataInfo.CumulativeMinivanRefund;
                        liveAnchorDailyTargetDto.MinivanRefundCompleteRate = afterLivingThisDayDataInfo.MinivanRefundCompleteRate;
                        liveAnchorDailyTargetDto.MiniVanBadReviews = afterLivingThisDayDataInfo.MiniVanBadReviews;
                        liveAnchorDailyTargetDto.MiniVanBadReviewsTarget = afterLivingThisDayDataInfo.MiniVanBadReviewsTarget;
                        liveAnchorDailyTargetDto.CumulativeMiniVanBadReviews = afterLivingThisDayDataInfo.CumulativeMiniVanBadReviews;
                        liveAnchorDailyTargetDto.MiniVanBadReviewsCompleteRate = afterLivingThisDayDataInfo.MiniVanBadReviewsCompleteRate;
                        liveAnchorDailyTargetDto.AfterLivingUpdateDate = afterLivingThisDayDataInfo.UpdateDate;


                    }


                    resultList.Add(liveAnchorDailyTargetDto);
                }

                return resultList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
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
        /// <summary>
        /// 根据月目标集合查询直播间投流数据
        /// </summary>
        /// <param name="targetIds"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<List<GmvAndRefundGmvDto>> GetDailyDataByLiveAnchorIdsAsync(List<string> targetIds, int year, int month)
        {
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1);
            return _livingDailyTarget.GetAll().Where(e => targetIds.Contains(e.LiveAnchorMonthlyTargetId) && e.Valid == true && e.RecordDate >= startDate && e.RecordDate < endDate).Select(e => new GmvAndRefundGmvDto
            {
                GMV = e.GMV,
                RefundGMV = e.RefundGMV,
                LivingRoomCumulativeFlowInvestment = e.LivingRoomFlowInvestmentNum,
                Date = e.RecordDate
            }).ToList();
        }
        /// <summary>
        /// 根据时间和主播id集合获取下单gmv和退款gmv数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        public async Task<List<GmvAndRefundGmvDto>> GetGmvDataAsync(DateTime start, DateTime end, List<int> liveAnchorIds)
        {
            return _livingDailyTarget.GetAll()
                .Where(e => e.RecordDate >= start && e.RecordDate < end && liveAnchorIds.Contains(e.LiveAnchorMonthlyTargetLiving.LiveAnchorId) && e.Valid == true)
                .Select(e => new GmvAndRefundGmvDto
                {
                    GMV = e.GMV,
                    RefundGMV = e.RefundGMV,
                    TikTokPlusNum = e.TikTokPlusNum,
                    QianChuanNum = e.QianChuanNum,
                    WeiXinDou = e.WeiXinDou,
                    ShuiXinTuiNum = e.ShuiXinTuiNum,
                    LivingRoomCumulativeFlowInvestment = e.LivingRoomFlowInvestmentNum,

                }).ToList();
        }
    }
}
