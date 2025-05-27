using Fx.Amiya.Dto;
using Fx.Amiya.Dto.AmiyaLivingOperationBoard;
using Fx.Amiya.Dto.AmiyaMingSuoOperationBoard.Input;
using Fx.Amiya.Dto.AmiyaMingSuoOperationBoard.Result;
using Fx.Amiya.Dto.AmiyaOperationsBoardService;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Input;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Result;
using Fx.Amiya.Dto.HospitalPerformance;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AmiyaMingSuoOperationBoardService : IAmiyaMingSuoOperationBoardService
    {
        private readonly ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ILiveAnchorMonthlyTargetBeforeLivingService liveAnchorMonthlyTargetBeforeLivingService;
        private readonly ILiveAnchorService liveAnchorService;
        private readonly IHospitalInfoService hospitalInfoService;
        private readonly IShoppingCartRegistrationService shoppingCartRegistrationService;
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;
        private readonly IAmiyaEmployeeService amiyaEmployeeService;
        private readonly IEmployeePerformanceTargetService employeePerformanceTargetService;
        private readonly IContentPlatformOrderSendService contentPlatformOrderSendService;
        private readonly IDalEmployeePerformanceTarget dalEmployeePerformanceTarget;
        private readonly IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo;
        private readonly IHealthValueService _healthValueService;
        private readonly IDalContentPlatformOrderSend _dalContentPlatformOrderSend;
        private readonly IDalShoppingCartRegistration _dalShoppingCartRegistration;
        private readonly IDalLiveAnchorMonthlyTargetAfterLiving dalLiveAnchorMonthlyTargetAfterLiving;
        private readonly ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService;

        public AmiyaMingSuoOperationBoardService(ILiveAnchorBaseInfoService liveAnchorBaseInfoService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService, ILiveAnchorService liveAnchorService, IHospitalInfoService hospitalInfoService, IShoppingCartRegistrationService shoppingCartRegistrationService, IContentPlateFormOrderService contentPlateFormOrderService, IAmiyaEmployeeService amiyaEmployeeService, IEmployeePerformanceTargetService employeePerformanceTargetService, IContentPlatformOrderSendService contentPlatformOrderSendService, IDalEmployeePerformanceTarget dalEmployeePerformanceTarget, IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo, IHealthValueService healthValueService, IDalContentPlatformOrderSend dalContentPlatformOrderSend, IDalShoppingCartRegistration dalShoppingCartRegistration, ILiveAnchorMonthlyTargetBeforeLivingService liveAnchorMonthlyTargetBeforeLivingService, ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService, IDalLiveAnchorMonthlyTargetAfterLiving dalLiveAnchorMonthlyTargetAfterLiving)
        {
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.liveAnchorService = liveAnchorService;
            this.hospitalInfoService = hospitalInfoService;
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.liveAnchorMonthlyTargetBeforeLivingService = liveAnchorMonthlyTargetBeforeLivingService;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.employeePerformanceTargetService = employeePerformanceTargetService;
            this.contentPlatformOrderSendService = contentPlatformOrderSendService;
            this.dalEmployeePerformanceTarget = dalEmployeePerformanceTarget;
            this.dalContentPlatFormOrderDealInfo = dalContentPlatFormOrderDealInfo;
            _healthValueService = healthValueService;
            _dalContentPlatformOrderSend = dalContentPlatformOrderSend;
            _dalShoppingCartRegistration = dalShoppingCartRegistration;
            this.liveAnchorMonthlyTargetAfterLivingService = liveAnchorMonthlyTargetAfterLivingService;
            this.dalLiveAnchorMonthlyTargetAfterLiving = dalLiveAnchorMonthlyTargetAfterLiving;
        }
        /// <summary>
        /// 获取总业绩
        /// </summary>
        /// <returns></returns>
        public async Task<OperationMingSuoAchievementDataDto> GetTotalAchievementAndDateScheduleAsync(QueryOperationDataDto query)
        {
            OperationMingSuoAchievementDataDto result = new OperationMingSuoAchievementDataDto();
            var dateSchedule = DateTimeExtension.GetDatetimeSchedule(query.endDate.Value).FirstOrDefault();
            var baseLiveanchorList = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.keyWord))
            {
                baseLiveanchorList = baseLiveanchorList.Where(x => x.Id == query.keyWord).ToList();
            }
            var baseIds = baseLiveanchorList.Select(e => e.Id).ToList();

            //获取各个平台的主播ID
            var LiveAnchorInfoList = await liveAnchorService.GetLiveAnchorListByBaseInfoIdListAsync(baseIds);
            var LiveAnchorInfo = LiveAnchorInfoList.Select(x => x.Id).ToList();
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.endDate.Value.Year, query.endDate.Value.Month == 0 ? 1 : query.endDate.Value.Month);

            //获取目标
            var target = await liveAnchorMonthlyTargetAfterLivingService.GetPerformanceTargetAsync(query.endDate.Value.Year, query.endDate.Value.Month, LiveAnchorInfo);
            #region【线索】


            var shoppingCartRegistionData = await shoppingCartRegistrationService.GetShoppingCartRegistionDataByRecordDateAndBaseIdsAsync(sequentialDate.StartDate, sequentialDate.EndDate, baseIds);

            var todayshoppingCartRegistionData = await shoppingCartRegistrationService.GetShoppingCartRegistionDataByRecordDateAndBaseIdsAsync(Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day), DateTime.Now, baseIds);

            var shoppingCartRegistionYearOnYear = await shoppingCartRegistrationService.GetShoppingCartRegistionDataByRecordDateAndBaseIdsAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, baseIds);

            var shoppingCartRegistionChain = await shoppingCartRegistrationService.GetShoppingCartRegistionDataByRecordDateAndBaseIdsAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, baseIds);

            var curClue = shoppingCartRegistionData.Count();
            var ClueYearOnYear = shoppingCartRegistionYearOnYear.Count();
            var ClueChainRatio = shoppingCartRegistionChain.Count();
            result.TodayTotalClues = todayshoppingCartRegistionData.Count();
            result.TotalCluesCompleteRate = DecimalExtension.CalculateTargetComplete(curClue, target.CluesTarget);
            result.TotalCluesYearOnYear = DecimalExtension.CalculateChain(curClue, ClueYearOnYear);
            result.TotalCluesChainRatio = DecimalExtension.CalculateChain(curClue, ClueChainRatio);

            if (query.startDate.Value.Year == query.endDate.Value.Year && query.startDate.Value.Month == query.endDate.Value.Month)
            {
                result.TotalClues = curClue;
            }
            else
            {
                //非本月数据总业绩取累计数据
                var sumShoppingCartRegistionData = await shoppingCartRegistrationService.GetShoppingCartRegistionDataByRecordDateAndBaseIdsAsync(query.startDate.Value, query.endDate.Value, baseIds);
                result.TotalClues = sumShoppingCartRegistionData.Count();
            }
            #endregion

            #region 总业绩
            //总业绩
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(sequentialDate.StartDate, sequentialDate.EndDate, LiveAnchorInfo);
            var todayOrder = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day), DateTime.Now, LiveAnchorInfo);
            var curTotalPerformance = order.Sum(o => o.Price);
            //同比业绩
            var orderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, LiveAnchorInfo);
            //环比业绩
            var orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, LiveAnchorInfo);
            result.TodayTotalPerformance = todayOrder.Sum(x => x.Price);
            result.TotalPerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(curTotalPerformance, target.TotalPerformanceTarget);
            result.TotalPerformanceChainRatio = DecimalExtension.CalculateChain(curTotalPerformance, orderChain.Sum(e => e.Price));
            result.TotalPerformanceYearOnYear = DecimalExtension.CalculateChain(curTotalPerformance, orderYearOnYear.Sum(e => e.Price));

            #endregion

            #region 新客业绩
            var curNewCustomer = order.Where(o => o.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderYearOnYear = orderYearOnYear.Where(x => x.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderChainRatio = orderChain.Where(x => x.IsOldCustomer == false).Sum(o => o.Price);
            result.TodayNewCustomerPerformance = todayOrder.Where(x => x.IsOldCustomer = false).Sum(x => x.Price);
            result.NewCustomerPerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(curNewCustomer, target.NewCustomerPerformanceTarget);
            result.NewCustomerPerformanceChainRatio = DecimalExtension.CalculateChain(curNewCustomer, newOrderChainRatio);
            result.NewCustomerPerformanceYearOnYear = DecimalExtension.CalculateChain(curNewCustomer, newOrderYearOnYear);
            #endregion
            #region 老客业绩
            var curOldCustomer = order.Where(o => o.IsOldCustomer == true).Sum(o => o.Price);
            var OldOrderYearOnYear = orderYearOnYear.Where(x => x.IsOldCustomer == true).Sum(o => o.Price);
            var OldOrderChainRatio = orderChain.Where(x => x.IsOldCustomer == true).Sum(o => o.Price);
            result.TodayNewCustomerPerformance = todayOrder.Where(x => x.IsOldCustomer = true).Sum(x => x.Price);
            result.OldCustomerPerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(curOldCustomer, target.OldCustomerPerformanceTarget);
            result.OldCustomerPerformanceChainRatio = DecimalExtension.CalculateChain(curOldCustomer, OldOrderChainRatio);
            result.OldCustomerPerformanceYearOnYear = DecimalExtension.CalculateChain(curOldCustomer, OldOrderYearOnYear);
            #endregion

            order = order.Where(x => LiveAnchorInfo.Contains(x.LiveAnchorId.Value)).ToList();
            //业绩折线图
            var dateList = order.GroupBy(x => x.CreateDate.Day).Select(x => new OerationTotalAchievementBrokenLineListDto
            {
                Time = x.Key,
                TotalCustomerPerformance = x.Sum(e => e.Price),

            });
            List<OerationTotalAchievementBrokenLineListDto> GroupList = new List<OerationTotalAchievementBrokenLineListDto>();
            for (int i = 1; i < dateSchedule.Key + 1; i++)
            {
                OerationTotalAchievementBrokenLineListDto item = new OerationTotalAchievementBrokenLineListDto();
                item.Time = i;
                item.TotalCustomerPerformance = dateList.Where(e => e.Time == i).Select(e => e.TotalCustomerPerformance).SingleOrDefault();

                GroupList.Add(item);
            }
            result.TotalPerformanceBrokenLineList = GroupList.Select(e => new PerformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = DecimalExtension.ChangePriceToTenThousand(e.TotalCustomerPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            //线索折线图
            var clueList = shoppingCartRegistionData.GroupBy(x => x.RecordDate.Day).Select(x => new OerationTotalAchievementBrokenLineListDto
            {
                Time = x.Key,
                TotalCustomerPerformance = x.Count(),
            });
            List<OerationTotalAchievementBrokenLineListDto> ClueGroupList = new List<OerationTotalAchievementBrokenLineListDto>();
            for (int i = 1; i < dateSchedule.Key + 1; i++)
            {
                OerationTotalAchievementBrokenLineListDto item = new OerationTotalAchievementBrokenLineListDto();
                item.Time = i;
                item.TotalCustomerPerformance = clueList.Where(e => e.Time == i).Select(e => e.TotalCustomerPerformance).SingleOrDefault();

                ClueGroupList.Add(item);
            }
            result.TotalCluesBrokenLineList = ClueGroupList.Select(e => new PerformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = e.TotalCustomerPerformance }).OrderBy(e => Convert.ToInt32(e.date)).ToList();


            if (query.startDate.Value.Year == query.endDate.Value.Year && query.startDate.Value.Month == query.endDate.Value.Month)
            {
                result.TotalPerformance = curTotalPerformance;
                result.NewCustomerPerformance = curNewCustomer;
                result.OldCustomerPerformance = curOldCustomer;
            }
            else
            {
                //非本月数据总业绩取累计数据
                var sumOrder = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(query.startDate.Value, query.endDate.Value, LiveAnchorInfo);
                result.TotalPerformance = sumOrder.Sum(x => x.Price);
                result.NewCustomerPerformance = sumOrder.Where(x => x.IsOldCustomer == false).Sum(s => s.Price);
                result.OldCustomerPerformance = sumOrder.Where(x => x.IsOldCustomer == true).Sum(s => s.Price);
            }
            return result;
        }

        /// <summary>
        /// 获取名索漏斗图数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<ResultMingSuoOperationDataDto> GetMingSuoFilterDataAsync(QueryMingSuoFilterDataDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate, query.EndDate);
            ResultMingSuoOperationDataDto filterData = new ResultMingSuoOperationDataDto();
            AssistantNewCustomerOperationDataDto NewCustomerDataDto = new AssistantNewCustomerOperationDataDto();
            NewCustomerDataDto.newCustomerOperationDataDetails = new List<AssistantNewCustomerOperationDataDetails>();

            AssistantOldCustomerOperationDataDto OldCustomerDataDto = new AssistantOldCustomerOperationDataDto();
            var healthValueList = await _healthValueService.GetValidListAsync();
            var baseLiveanchorList = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.LiveAnchorBaseId))
            {
                baseLiveanchorList = baseLiveanchorList.Where(x => x.Id == query.LiveAnchorBaseId).ToList();
            }
            var baseIds = baseLiveanchorList.Select(e => e.Id).ToList();

            //获取各个平台的主播ID
            var LiveAnchorInfo = await liveAnchorService.GetLiveAnchorListByBaseInfoIdListAsync(baseIds);
            #region【小黄车数据】
            var employeeInfo = await amiyaEmployeeService.GetByLiveAnchorBaseIdListAsync(baseIds);
            var empIdList = employeeInfo.Select(x => x.Id).ToList();
            //小黄车数据
            var baseBusinessPerformance = await shoppingCartRegistrationService.GetBeforeLiveShopCartRegisterPerformanceByAssistantIdListAndBaseIdListAsync(selectDate.StartDate, selectDate.EndDate, baseIds, new List<int>(), BelongChannel.LiveBefore);
            #endregion
            string z = "";
            foreach (var k in baseBusinessPerformance)
            {
                z += k.Id + ",";
            }

            #region 新客数据
            #region 【线索】
            //线索
            AssistantNewCustomerOperationDataDetails clues = new AssistantNewCustomerOperationDataDetails();
            clues.Key = "Clues";
            clues.Name = "线索量";
            clues.Value = baseBusinessPerformance.Count();
            NewCustomerDataDto.newCustomerOperationDataDetails.Add(clues);
            #endregion
            #region 【分诊】

            //分诊
            AssistantNewCustomerOperationDataDetails consulationdetails = new AssistantNewCustomerOperationDataDetails();
            consulationdetails.Key = "Consulation";
            consulationdetails.Name = "分诊量";
            consulationdetails.Value = baseBusinessPerformance.Where(x => x.AssignEmpId != 0 && x.AssignEmpId.HasValue && x.IsReturnBackPrice == false).Count();
            NewCustomerDataDto.newCustomerOperationDataDetails.Add(consulationdetails);

            //线索有效率
            NewCustomerDataDto.ClueEffectiveRate = DecimalExtension.CalculateTargetComplete(consulationdetails.Value, clues.Value);
            NewCustomerDataDto.AddWeChatRateHealthValueThisMonth = healthValueList.Where(e => e.Key == "ClueEffictiveRateHealthValueThisMonth").Select(e => e.Rate).FirstOrDefault();
            #endregion

            #region 【加v】
            AssistantNewCustomerOperationDataDetails addWechatdetails = new AssistantNewCustomerOperationDataDetails();
            //加v
            addWechatdetails.Key = "AddWeChat";
            addWechatdetails.Name = "加v量";
            addWechatdetails.Value = baseBusinessPerformance.Where(x => x.IsAddWeChat == true && x.AssignEmpId != 0 && x.AssignEmpId.HasValue && x.IsReturnBackPrice == false).Count();
            NewCustomerDataDto.newCustomerOperationDataDetails.Add(addWechatdetails);

            //加v率
            NewCustomerDataDto.AddWeChatRate = DecimalExtension.CalculateTargetComplete(addWechatdetails.Value, consulationdetails.Value);
            NewCustomerDataDto.AddWeChatRateHealthValueThisMonth = healthValueList.Where(e => e.Key == "AddWeChatHealthValueThisMonth").Select(e => e.Rate).FirstOrDefault();
            #endregion

            #region 获取部门基础数据
            bool isCurrent = true;
            if (query.History)
                isCurrent = false;
            var depeartPhoneList = baseBusinessPerformance.Select(e => e.Phone).ToList();
            var allOrderPerformance = await contentPlateFormOrderService.GetBeforeLiveDepartOrderSendAndDealDataByAssistantIdListAsync(selectDate.StartDate, selectDate.EndDate, empIdList, depeartPhoneList, isCurrent);

            #endregion

            #region 【派单】
            AssistantNewCustomerOperationDataDetails sendOrderdetails = new AssistantNewCustomerOperationDataDetails();
            //派单
            sendOrderdetails.Key = "SendOrder";
            sendOrderdetails.Name = "派单量";
            sendOrderdetails.Value = allOrderPerformance.SendOrderNum;
            NewCustomerDataDto.newCustomerOperationDataDetails.Add(sendOrderdetails);

            //派单率
            NewCustomerDataDto.SendOrderRate = DecimalExtension.CalculateTargetComplete(sendOrderdetails.Value, addWechatdetails.Value);
            NewCustomerDataDto.SendOrderRateHealthValueThisMonth = healthValueList.Where(e => e.Key == "SendOrderRateHealthValueThisMonth").Select(e => e.Rate).FirstOrDefault();
            #endregion

            #region 【上门】
            AssistantNewCustomerOperationDataDetails visitdetails = new AssistantNewCustomerOperationDataDetails();
            //上门
            visitdetails.Key = "ToHospital";
            visitdetails.Name = "上门量";
            visitdetails.Value = allOrderPerformance.VisitNum;
            NewCustomerDataDto.newCustomerOperationDataDetails.Add(visitdetails);

            //上门率
            NewCustomerDataDto.ToHospitalRate = DecimalExtension.CalculateTargetComplete(visitdetails.Value, sendOrderdetails.Value);
            NewCustomerDataDto.ToHospitalRateHealthValueThisMonth = healthValueList.Where(e => e.Key == "ToHospitalRateHealthValueThisMonth").Select(e => e.Rate).FirstOrDefault();
            #endregion

            #region 【成交】

            AssistantNewCustomerOperationDataDetails dealData = new AssistantNewCustomerOperationDataDetails();
            //成交
            dealData.Key = "Deal";
            dealData.Name = "成交量";
            dealData.Value = allOrderPerformance.DealNum;
            NewCustomerDataDto.newCustomerOperationDataDetails.Add(dealData);

            //成交率
            NewCustomerDataDto.DealRate = DecimalExtension.CalculateTargetComplete(dealData.Value, visitdetails.Value);
            NewCustomerDataDto.DealRateHealthValueThisMonth = healthValueList.Where(e => e.Key == "DealRateHealthValueThisMonth").Select(e => e.Rate).FirstOrDefault();

            #endregion
            filterData.NewCustomerData = NewCustomerDataDto;

            #endregion


            #region 老客数据
            var oldCustomerData = await contentPlateFormOrderService.GetOldCustomerBuyAgainByMonthAsync(selectDate.StartDate, null, "", LiveAnchorInfo.Select(x => x.Id).ToList());
            OldCustomerDataDto.TotalDealPeople = oldCustomerData.TotalDealCustomer;
            OldCustomerDataDto.SecondDealPeople = oldCustomerData.SecondDealCustomer;
            OldCustomerDataDto.ThirdDealPeople = oldCustomerData.ThirdDealCustomer;
            OldCustomerDataDto.FourthDealCustomer = oldCustomerData.FourthDealCustomer;
            OldCustomerDataDto.FifThOrMoreOrMoreDealCustomer = oldCustomerData.FifThOrMoreOrMoreDealCustomer;
            OldCustomerDataDto.SecondDealCycle = oldCustomerData.SecondDealCycle;
            OldCustomerDataDto.ThirdDealCycle = oldCustomerData.ThirdDealCycle;
            OldCustomerDataDto.FourthDealCycle = oldCustomerData.FourthDealCycle;
            OldCustomerDataDto.FifthDealCycle = oldCustomerData.FifthDealCycle;


            //OldCustomerDataDto.SecondTimeBuyRate = CalculateTargetComplete(Convert.ToDecimal(OldCustomerDataDto.SecondDealPeople), Convert.ToDecimal(OldCustomerDataDto.TotalDealPeople)).Value;
            OldCustomerDataDto.SecondTimeBuyRateProportion = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(OldCustomerDataDto.SecondDealPeople), Convert.ToDecimal(OldCustomerDataDto.TotalDealPeople)).Value; ;

            //OldCustomerDataDto.ThirdTimeBuyRate = CalculateTargetComplete(Convert.ToDecimal(OldCustomerDataDto.ThirdDealPeople), Convert.ToDecimal(OldCustomerDataDto.SecondDealPeople)).Value;
            OldCustomerDataDto.ThirdTimeBuyRateProportion = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(OldCustomerDataDto.ThirdDealPeople), Convert.ToDecimal(OldCustomerDataDto.TotalDealPeople)).Value;

            // OldCustomerDataDto.FourthTimeBuyRate = CalculateTargetComplete(Convert.ToDecimal(OldCustomerDataDto.FourthDealCustomer), Convert.ToDecimal(OldCustomerDataDto.ThirdDealPeople)).Value;
            OldCustomerDataDto.FourthTimeBuyRateProportion = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(OldCustomerDataDto.FourthDealCustomer), Convert.ToDecimal(OldCustomerDataDto.TotalDealPeople)).Value;

            //OldCustomerDataDto.FifthTimeOrMoreBuyRate = CalculateTargetComplete(Convert.ToDecimal(OldCustomerDataDto.FifThOrMoreOrMoreDealCustomer), Convert.ToDecimal(OldCustomerDataDto.FourthDealCustomer)).Value;
            OldCustomerDataDto.FifthTimeOrMoreBuyRateProportion = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(OldCustomerDataDto.FifThOrMoreOrMoreDealCustomer), Convert.ToDecimal(OldCustomerDataDto.TotalDealPeople)).Value;

            OldCustomerDataDto.BuyRate = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(OldCustomerDataDto.FifThOrMoreOrMoreDealCustomer + OldCustomerDataDto.FourthDealCustomer + OldCustomerDataDto.ThirdDealPeople + OldCustomerDataDto.SecondDealPeople), Convert.ToDecimal(OldCustomerDataDto.TotalDealPeople)).Value;

            filterData.OldCustomerData = OldCustomerDataDto;

            #endregion


            return filterData;
        }


        /// <summary>
        /// 获取医生转化周期柱状图
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        public async Task<MingSuoTransformCycleDataDto> GetLiveAnchorTransformCycleDataAsync(QueryOperationDataDto query)
        {
            MingSuoTransformCycleDataDto data = new MingSuoTransformCycleDataDto();
            var seqDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.endDate.Value.Year, query.endDate.Value.Month);
            var liveanchorIds = new List<string>();
            var nameList = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.keyWord))
            {
                nameList = nameList.Where(x => x.Id == query.keyWord).ToList();
            }

            liveanchorIds = nameList.Select(x => x.Id).ToList();
            #region 分诊派单
            var sendInfoList = await _dalContentPlatformOrderSend.GetAll().Include(x => x.ContentPlatformOrder).ThenInclude(x => x.LiveAnchor)
                .Where(e => e.IsMainHospital == true && e.SendDate >= seqDate.StartDate && e.SendDate < seqDate.EndDate)
                .Where(x => liveanchorIds.Count() == 0 || liveanchorIds.Contains(x.ContentPlatformOrder.LiveAnchor.LiveAnchorBaseId))
                .Select(e => new { Id = e.ContentPlatformOrder.Id, Phone = e.ContentPlatformOrder.Phone, LiveAnchorBaseId = (e.ContentPlatformOrder.LiveAnchor.LiveAnchorBaseId), SendDate = e.SendDate }).ToListAsync();
            var sendPhoneList = sendInfoList.Select(e => e.Phone).Distinct().ToList();
            var cartInfoList = _dalShoppingCartRegistration.GetAll().Where(e => e.IsReturnBackPrice == false && sendPhoneList.Contains(e.Phone))
                .Select(e => new
                {
                    Phone = e.Phone,
                    AddPrice = e.Price,
                    RecordDate = e.RecordDate
                }).ToList();
            var dataList = (from send in sendInfoList
                            join cart in cartInfoList
                            on send.Phone equals cart.Phone
                            select new
                            {
                                Id = send.Id,
                                LiveAnchorBaseId = send.LiveAnchorBaseId,
                                AddPrice = cart.AddPrice,
                                IntervalDays = (send.SendDate - cart.RecordDate).Days
                            }).ToList();
            dataList.RemoveAll(e => e.IntervalDays < 0);
            dataList = dataList.OrderBy(x => x.IntervalDays).ToList();
            //转化周期数据
            var res1 = dataList.GroupBy(e => e.LiveAnchorBaseId).Select(e =>
            {
                var endIndex = DecimalExtension.CalTakeCount(e.Count());
                var total = dataList.Sum(e => e.IntervalDays);
                var resData = e.OrderBy(e => e.IntervalDays).Skip(0).Take(endIndex);
                return new KeyValuePair<string, int>(
                nameList.Where(a => a.Id == e.Key).FirstOrDefault()?.LiveAnchorName ?? "其它",
                resData.Count() == 0 ? 0 : resData.Sum(e => e.IntervalDays) / (resData.Count())
             );
            }).OrderBy(e => e.Value).ToList();
            //当前主播转化周期
            var currentLiveAnchorListCount = dataList.Where(e => e.LiveAnchorBaseId == query.keyWord).Count();
            var currentLiveAnchorList = dataList.Where(e => e.LiveAnchorBaseId == query.keyWord).OrderBy(e => e.IntervalDays).Skip(0).Take((int)(currentLiveAnchorListCount * 0.8));

            var currentLiveAnchorListCountAllData = dataList.Count();
            var currentLiveAnchorListAllData = dataList.OrderBy(e => e.IntervalDays).Skip(0).Take((int)(currentLiveAnchorListCountAllData * 0.8));

            int currentEffectiveDays = 0;
            int currentEffectiveCount = 0;
            int currentPotionelDays = 0;
            int currentPotionelCount = 0;

            if (!string.IsNullOrEmpty(query.keyWord))
            {
                currentEffectiveDays = currentLiveAnchorList.Where(e => e.AddPrice > 0).Sum(e => e.IntervalDays);
                currentEffectiveCount = currentLiveAnchorList.Where(e => e.AddPrice > 0).Count();
                currentPotionelDays = currentLiveAnchorList.Where(e => e.AddPrice == 0).Sum(e => e.IntervalDays);
                currentPotionelCount = currentLiveAnchorList.Where(e => e.AddPrice == 0).Count();
            }
            else
            {
                currentEffectiveDays = currentLiveAnchorListAllData.Where(e => e.AddPrice > 0).Sum(e => e.IntervalDays);
                currentEffectiveCount = currentLiveAnchorListAllData.Where(e => e.AddPrice > 0).Count();
                currentPotionelDays = currentLiveAnchorListAllData.Where(e => e.AddPrice == 0).Sum(e => e.IntervalDays);
                currentPotionelCount = currentLiveAnchorListAllData.Where(e => e.AddPrice == 0).Count();
            }
            data.TotalSendCycle = DecimalExtension.CalAvg(currentEffectiveDays + currentPotionelDays, currentEffectiveCount + currentPotionelCount);
            data.ThisMonthSendCycle = DecimalExtension.CalAvg(currentEffectiveDays, currentEffectiveCount);
            data.HistorySendCycle = DecimalExtension.CalAvg(currentPotionelDays, currentPotionelCount);
            data.SendCycleData = res1.OrderByDescending(x => x.Value).ToList();

            #endregion

            #region 分诊上门

            var dealInfoList = await dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder).ThenInclude(x => x.LiveAnchor).Where(e => e.CreateDate >= seqDate.StartDate && e.CreateDate < seqDate.EndDate && e.IsOldCustomer == false && e.IsToHospital == true && e.ToHospitalDate.HasValue)
                    .Where(x => liveanchorIds.Count() == 0 || liveanchorIds.Contains(x.ContentPlatFormOrder.LiveAnchor.LiveAnchorBaseId))
                    .Select(e => new
                    {
                        LiveanchorBaseId = e.ContentPlatFormOrder.LiveAnchor.LiveAnchorBaseId,
                        Phone = e.ContentPlatFormOrder.Phone,
                        ToHospitalDate = e.ToHospitalDate
                    }).ToListAsync();
            var dealPhoneList = dealInfoList.Select(e => e.Phone).Distinct().ToList();
            var cartInfoList2 = _dalShoppingCartRegistration.GetAll().Where(e => e.IsReturnBackPrice == false && dealPhoneList.Contains(e.Phone))
           .Select(e => new
           {
               Phone = e.Phone,
               AddPrice = e.Price,
               RecordDate = e.RecordDate
           }).ToList();
            var dataList2 = (from deal in dealInfoList
                             join cart in cartInfoList2
                             on deal.Phone equals cart.Phone
                             select new
                             {
                                 LiveAnchorBaseId = deal.LiveanchorBaseId,
                                 AddPrice = cart.AddPrice,
                                 IntervalDays = (deal.ToHospitalDate.Value - cart.RecordDate).Days
                             }).ToList();
            dataList2.RemoveAll(e => e.IntervalDays < 0);
            //转化周期数据
            var res2 = dataList2.GroupBy(e => e.LiveAnchorBaseId).Select(e =>
            {
                var endIndex = DecimalExtension.CalTakeCount(e.Count(), 0.6m);
                var resData = e.OrderBy(e => e.IntervalDays).Skip(0).Take(endIndex);
                return new KeyValuePair<string, int>(
                nameList.Where(a => a.Id == e.Key).FirstOrDefault()?.LiveAnchorName ?? "其它",
                resData.Count() == 0 ? 0 : resData.Sum(e => e.IntervalDays) / resData.Count());
            }).OrderBy(e => e.Value).ToList();

            //当前主播转化周期
            var currentLiveAnchorListCount2 = dataList2.Where(e => e.LiveAnchorBaseId == query.keyWord).Count();
            var currentLiveAnchorList2 = dataList2.Where(e => e.LiveAnchorBaseId == query.keyWord).OrderBy(e => e.IntervalDays).Skip(0).Take((int)(currentLiveAnchorListCount2 * 0.6));

            var currentLiveAnchorListCount2AllData = dataList2.Count();
            var currentLiveAnchorList2AllData = dataList2.OrderBy(e => e.IntervalDays).Skip(0).Take((int)(currentLiveAnchorListCount2AllData * 0.6));

            int currentEffectiveDays2 = 0;
            int currentEffectiveCount2 = 0;
            int currentPotionelDays2 = 0;
            int currentPotionelCount2 = 0;

            if (!string.IsNullOrEmpty(query.keyWord))
            {
                currentEffectiveDays2 = currentLiveAnchorList2.Where(e => e.AddPrice > 0).Sum(e => e.IntervalDays);
                currentEffectiveCount2 = currentLiveAnchorList2.Where(e => e.AddPrice > 0).Count();
                currentPotionelDays2 = currentLiveAnchorList2.Where(e => e.AddPrice == 0).Sum(e => e.IntervalDays);
                currentPotionelCount2 = currentLiveAnchorList2.Where(e => e.AddPrice == 0).Count();
            }
            else
            {
                currentEffectiveDays2 = currentLiveAnchorList2AllData.Where(e => e.AddPrice > 0).Sum(e => e.IntervalDays);
                currentEffectiveCount2 = currentLiveAnchorList2AllData.Where(e => e.AddPrice > 0).Count();
                currentPotionelDays2 = currentLiveAnchorList2AllData.Where(e => e.AddPrice == 0).Sum(e => e.IntervalDays);
                currentPotionelCount2 = currentLiveAnchorList2AllData.Where(e => e.AddPrice == 0).Count();
            }
            data.TotalToHospitalCycle = DecimalExtension.CalAvg(currentEffectiveDays2 + currentPotionelDays2, currentEffectiveCount2 + currentPotionelCount2);
            data.ThisMonthSendCycle = DecimalExtension.CalAvg(currentEffectiveDays2, currentEffectiveCount2);
            data.ThisMonthToHospitalCycle = DecimalExtension.CalAvg(currentPotionelDays2, currentPotionelCount2);

            data.ToHospitalCycleData = res2.OrderByDescending(x => x.Value).ToList();


            #endregion



            return data;
        }

        /// <summary>
        /// 名索医生线索和业绩目标完成率
        /// </summary>
        /// <returns></returns>
        public async Task<MingSuoClueTargetDataDto> GetMingSuoClueAndPerformanceTargetDataAsync(QueryMingSuoCompleteDataDto query)
        {
            MingSuoClueTargetDataDto data = new MingSuoClueTargetDataDto();
            var baseLiveanchorList = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.BaseLiveAnchorId))
            {
                baseLiveanchorList = baseLiveanchorList.Where(x => x.Id == query.BaseLiveAnchorId).ToList();
            }
            var baseLiveanchorIdList = baseLiveanchorList.Select(e => e.Id).ToList();

            var seqDate = DateTimeExtension.GetStartDateEndDate(query.StartDate, query.EndDate);
            //var customerServiceIds = await amiyaEmployeeService.GetByLiveAnchorBaseIdListAsync(baseLiveanchorIdList);

            var target = await dalLiveAnchorMonthlyTargetAfterLiving.GetAll()
                .Where(e => baseLiveanchorIdList.Contains(e.LiveAnchor.LiveAnchorBaseId) && e.Month == query.EndDate.Month && e.Year == query.EndDate.Year)
                .Where(e => e.CluesTarget > 1)
                .Select(e => new { e.LiveAnchor.LiveAnchorBaseId, e.CluesTarget, e.PerformanceTarget })
                .GroupBy(e => e.LiveAnchorBaseId)
                .Select(e => new
                {
                    BaseLiveanchorId = e.Key,
                    ClueTarget = e.Sum(e => e.CluesTarget),
                    PerformanceTarget = e.Sum(e => e.PerformanceTarget)
                }).ToListAsync();
            //线索目标完成率
            var clueData = _dalShoppingCartRegistration.GetAll()
                .Where(e => e.IsReturnBackPrice == false && e.BelongChannel == (int)BelongChannel.LiveBefore)
                .Where(e => e.RecordDate >= seqDate.StartDate && e.RecordDate < seqDate.EndDate)
                .Where(e => baseLiveanchorIdList.Contains(e.BaseLiveAnchorId))
                .Select(e => new
                {
                    BaseLiveAnchorId = e.BaseLiveAnchorId,
                }).ToList();
            var clueTargetData = clueData.GroupBy(e => e.BaseLiveAnchorId).Select(e =>
            {
                var name = baseLiveanchorList.Where(x => x.Id == e.Key).FirstOrDefault()?.LiveAnchorName ?? "其他";
                var t = target.Where(x => x.BaseLiveanchorId == e.Key).FirstOrDefault()?.ClueTarget ?? 0;
                var targetComplete = DecimalExtension.CalculateTargetComplete(e.Count(), t).Value;
                return new KeyValuePair<string, decimal>(name, targetComplete);
            }).ToList();
            data.ClueTargetComplete = clueTargetData.OrderByDescending(x => x.Value).ToList();

            //业绩目标完成率
            data.PerformanceTargetComplete = new List<BaseKeyValueDto<string, decimal>>();
            foreach (var baseLiveAnchor in baseLiveanchorList)
            {
                var liveAnchorTarget = target.Where(e => e.BaseLiveanchorId == baseLiveAnchor.Id).FirstOrDefault()?.PerformanceTarget ?? 0;
                var liveAnchorIds = await liveAnchorService.GetAllLiveAnchorListByBaseInfoId(baseLiveAnchor.Id);
                var order = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceAsync(seqDate.StartDate, seqDate.EndDate, null, liveAnchorIds.Select(x => x.Id).ToList());
                BaseKeyValueDto<string, decimal> liveAnchorPerfomances = new BaseKeyValueDto<string, decimal>();
                liveAnchorPerfomances.Key = baseLiveAnchor.LiveAnchorName;
                liveAnchorPerfomances.Value = DecimalExtension.CalculateTargetComplete(order.Sum(x => x.Price), liveAnchorTarget).Value;
                data.PerformanceTargetComplete.Add(liveAnchorPerfomances);

            }
            data.PerformanceTargetComplete = data.PerformanceTargetComplete.OrderByDescending(x => x.Value).ToList();
            return data;
        }

        /// <summary>
        /// 获取助理目标完成率和业绩占比
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<AssiatantTargetCompleteAndPerformanceRateDto> GetAssiatantTargetCompleteAndPerformanceRateDataAsync(QueryMingSuoAssistantPerformanceDto query)
        {
            AssiatantTargetCompleteAndPerformanceRateDto result = new AssiatantTargetCompleteAndPerformanceRateDto();
            var selectDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(query.EndDate.Year, query.EndDate.Month);
            var baseLiveanchorList = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.LiveAnchorBaseId))
            {
                baseLiveanchorList = baseLiveanchorList.Where(x => x.Id == query.LiveAnchorBaseId).ToList();
            }
            var baseLiveanchorIdList = baseLiveanchorList.Select(e => e.Id).ToList();
            var assistantIdAndNameList = await amiyaEmployeeService.GetByLiveAnchorBaseIdListAsync(baseLiveanchorIdList);
            var assistantTarget = await dalEmployeePerformanceTarget.GetAll()
                .Where(e => e.Valid == true)
                .Where(e => e.BelongYear == selectDate.EndDate.Year && e.BelongMonth == selectDate.EndDate.Month)
                .Where(e => assistantIdAndNameList.Select(e => e.Id).Contains(e.EmployeeId))
                .Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    Target = e.NewCustomerPerformanceTarget + e.OldCustomerPerformanceTarget,
                }).ToListAsync();
            var currentContentOrderList = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAndAssistantIdListAsync(selectDate.StartDate, selectDate.EndDate, assistantIdAndNameList.Select(e => e.Id).ToList());
            var totalPerformance = currentContentOrderList.Sum(e => e.Price);
            foreach (var assistant in assistantIdAndNameList)
            {
                var sumPerformance = currentContentOrderList.Where(e => e.BelongEmployeeId == assistant.Id).Sum(e => e.Price);
                BaseKeyValueDto<string, decimal> targetItem = new BaseKeyValueDto<string, decimal>();
                var target = assistantTarget.Where(e => e.EmployeeId == assistant.Id).FirstOrDefault()?.Target ?? 0;
                targetItem.Key = assistant.Name;
                targetItem.Value = DecimalExtension.CalculateTargetComplete(sumPerformance, target).Value;
                result.TargetCompleteData.Add(targetItem);
                BaseKeyValueDto<string, decimal> rateItem = new BaseKeyValueDto<string, decimal>();
                rateItem.Key = assistant.Name;
                rateItem.Value = DecimalExtension.CalculateTargetComplete(sumPerformance, totalPerformance).Value;
                result.PerformanceRateData.Add(rateItem);
            }
            result.TargetCompleteData = result.TargetCompleteData.OrderByDescending(x => x.Value).ToList();
            result.PerformanceRateData = result.PerformanceRateData.OrderByDescending(x => x.Value).ToList();
            return result;
        }

        /// <summary>
        /// 名索IP获客占比
        /// </summary>
        /// <returns></returns>
        public async Task<MingSuoContentplatformClueDataDto> GetMingSuoContentplatformClueDataAsync(QueryMingSuoAssistantPerformanceDto query)
        {
            MingSuoContentplatformClueDataDto MingSuoData = new MingSuoContentplatformClueDataDto();
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate, query.EndDate);
            var baseLiveanchorList = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.LiveAnchorBaseId))
            {
                baseLiveanchorList = baseLiveanchorList.Where(x => x.Id == query.LiveAnchorBaseId).ToList();
            }
            var baseLiveAnchorIds = baseLiveanchorList.Select(x => x.Id).ToList();
            var baseData = await _dalShoppingCartRegistration.GetAll().Where(e => e.RecordDate >= selectDate.StartDate && e.RecordDate < selectDate.EndDate && e.BelongChannel == (int)BelongChannel.LiveBefore && e.IsReturnBackPrice == false)
                .Where(e => baseLiveAnchorIds.Contains(e.BaseLiveAnchorId))
                .Select(e => new
                {
                    id = e.Id,
                    ContentPlatformName = e.Contentplatform.ContentPlatformName,
                    ContentPlatformId = e.ContentPlatFormId,
                    LiveAnchorName = e.LiveAnchor.Name,
                }).ToListAsync();
            var totalCount = baseData.Count;
            MingSuoData.ContentPlatformTotalClue = totalCount;
            MingSuoData.ContentPlatformClueRate = baseData.GroupBy(e => e.LiveAnchorName).Select(e => new LivingContentplatformClueDataItemDto
            {
                Name = e.Key,
                Value = DecimalExtension.CalculateTargetComplete(e.Count(), totalCount).Value,
                Performance = e.Count()
            }).ToList();
            return MingSuoData;
        }
        /// <summary>
        /// 名索IP业绩占比
        /// </summary>
        /// <returns></returns>
        public async Task<MingSuoContentplatformPerformanceDataDto> GetMingSuoContentplatformPerformanceDataAsync(QueryMingSuoAssistantPerformanceDto query)
        {
            MingSuoContentplatformPerformanceDataDto MingSuoData = new MingSuoContentplatformPerformanceDataDto();
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate, query.EndDate);
            var baseLiveanchorList = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.LiveAnchorBaseId))
            {
                baseLiveanchorList = baseLiveanchorList.Where(x => x.Id == query.LiveAnchorBaseId).ToList();
            }
            var performanceList = dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder).ThenInclude(x => x.LiveAnchor)
                .Where(e => e.ContentPlatFormOrder.BelongChannel == (int)BelongChannel.LiveBefore)
                .Where(e => e.IsDeal == true && e.CreateDate >= selectDate.StartDate && e.CreateDate < selectDate.EndDate)
                .Where(e => baseLiveanchorList.Select(x => x.Id).ToList().Contains(e.ContentPlatFormOrder.LiveAnchor.LiveAnchorBaseId))
                   .Select(e => new
                   {
                       Id = e.Id,
                       conteid = e.ContentPlatFormOrderId,
                       LiveAnchorName = e.ContentPlatFormOrder.LiveAnchor.Name,
                       ContentPlateformId = e.ContentPlatFormOrder.ContentPlateformId,
                       ContentPlatformName = e.ContentPlatFormOrder.Contentplatform.ContentPlatformName,
                       Price = e.Price
                   }).ToList();
            var totalPerformance = performanceList.Sum(e => e.Price);
            MingSuoData.ContentPlatformTotalPerformance = ChangePriceToTenThousand(totalPerformance);
            MingSuoData.ContentPlatformPerformanceRate = performanceList.GroupBy(e => e.LiveAnchorName)
                .Select(e => new LivingContentplatformPerformanceDataItemDto
                {
                    Name = e.Key,
                    Value = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.Price), totalPerformance).Value,
                    Performance = ChangePriceToTenThousand(e.Sum(e => e.Price))
                }).ToList();
            return MingSuoData;
        }


        /// <summary>
        /// 获取名索年度业绩转化数据
        /// </summary>
        /// <returns></returns>
        public async Task<PerformanceYearDataListDto> GetTotalAchievementByYearAsync(QueryMingSuoPerfomanceYearDataDto query)
        {
            #region 实例化输出项
            PerformanceYearDataListDto result = new PerformanceYearDataListDto();
            result.TotalPerformanceData = new List<PerformanceYearDataDto>();
            result.DaoDaoPerformanceData = new List<PerformanceYearDataDto>();
            result.JiNaPerformanceData = new List<PerformanceYearDataDto>();
            #endregion

            #region 获取主播信息
            string text = "（总业绩）";
            int totalCount = 6;
            if (query.IsOldCustomer.HasValue)
            {
                if (query.IsOldCustomer == false)
                {
                    text = "（新客）";
                    totalCount = 5;
                }
                if (query.IsOldCustomer == true)
                {
                    text = "（老客）";
                    totalCount = 5;
                }
            }
            string totalPerformanceName = "美妍" + text;
            var liveAnchorBaseInfo = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.LiveAnchorBaseIdId))
            {
                var liveAnchorBaseInfoData = await liveAnchorBaseInfoService.GetByIdAsync(query.LiveAnchorBaseIdId);
                totalPerformanceName = liveAnchorBaseInfoData.LiveAnchorName + text;
                liveAnchorBaseInfo = new List<Dto.LiveAnchorBaseInfo.LiveAnchorBaseInfoDto>();
                liveAnchorBaseInfo.Add(liveAnchorBaseInfoData);
            }
            //获取主播信息(医生IP）
            List<int> LiveAnchorInfo = new List<int>();
            //获取对应主播IP账户信息
            var liveAnchorTotal = await liveAnchorService.GetLiveAnchorListByBaseInfoIdListAsync(liveAnchorBaseInfo.Select(x => x.Id).ToList());
            LiveAnchorInfo = liveAnchorTotal.Select(x => x.Id).ToList();
            #endregion

            #region 获取直播后年度目标
            var targetAfterLiving = await liveAnchorMonthlyTargetAfterLivingService.GetPerformanceByYearAsync(query.Year, LiveAnchorInfo, query.IsOldCustomer);
            #endregion

            #region 获取直播后本年度业绩
            var totalPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(Convert.ToDateTime(query.Year + "-01-01"), Convert.ToDateTime(query.Year + "-12-31"), LiveAnchorInfo, query.IsOldCustomer);
            #endregion

            #region 获取直播后上年度业绩
            var totalPerformanceLastYear = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(Convert.ToDateTime(query.Year - 1 + "-01-01"), Convert.ToDateTime(query.Year - 1 + "-12-31"), LiveAnchorInfo, query.IsOldCustomer);
            #endregion
            var thisMonth = DateTime.Now.Month;
            for (int y = 0; y <= totalCount; y++)
            {
                PerformanceYearDataDto totalPerformanceYearData = new PerformanceYearDataDto();
                totalPerformanceYearData.GroupName = totalPerformanceName;
                switch (y)
                {
                    case 0:
                        totalPerformanceYearData.SortName = query.Year + "年预算目标";
                        #region 整体
                        totalPerformanceYearData.JanuaryPerformance = targetAfterLiving.Where(x => x.Month == 1).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.FebruaryPerformance = targetAfterLiving.Where(x => x.Month == 2).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.MarchPerformance = targetAfterLiving.Where(x => x.Month == 3).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.AprilPerformance = targetAfterLiving.Where(x => x.Month == 4).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.MayPerformance = targetAfterLiving.Where(x => x.Month == 5).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.JunePerformance = targetAfterLiving.Where(x => x.Month == 6).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.JulyPerformance = targetAfterLiving.Where(x => x.Month == 7).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.AugustPerformance = targetAfterLiving.Where(x => x.Month == 8).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.SeptemberPerformance = targetAfterLiving.Where(x => x.Month == 9).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.OctoberPerformance = targetAfterLiving.Where(x => x.Month == 10).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.NovemberPerformance = targetAfterLiving.Where(x => x.Month == 11).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.DecemberPerformance = targetAfterLiving.Where(x => x.Month == 12).Sum(t => t.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.SumPerformance = targetAfterLiving.Sum(x => x.TotalPerformanceTarget).ToString();
                        totalPerformanceYearData.AveragePerformance = Math.Round(targetAfterLiving.Sum(x => x.TotalPerformanceTarget) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion

                        break;
                    case 1:

                        totalPerformanceYearData.SortName = query.Year + "年实际业绩";
                        #region 整体
                        var JanTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 1, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.JanuaryPerformance = JanTotalLossPerformance.Sum(x => x.Price).ToString();
                        var FebTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 2, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.FebruaryPerformance = FebTotalLossPerformance.Sum(x => x.Price).ToString();
                        var MarTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 3, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.MarchPerformance = MarTotalLossPerformance.Sum(x => x.Price).ToString();
                        var AprTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 4, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.AprilPerformance = AprTotalLossPerformance.Sum(x => x.Price).ToString();
                        var MayTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 5, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.MayPerformance = MayTotalLossPerformance.Sum(x => x.Price).ToString();
                        var JunTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 6, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.JunePerformance = JunTotalLossPerformance.Sum(x => x.Price).ToString();
                        var JulTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 7, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.JulyPerformance = JulTotalLossPerformance.Sum(x => x.Price).ToString();
                        var AugTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 8, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.AugustPerformance = AugTotalLossPerformance.Sum(x => x.Price).ToString();
                        var SepTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 9, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.SeptemberPerformance = SepTotalLossPerformance.Sum(x => x.Price).ToString();
                        var OctTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 10, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.OctoberPerformance = OctTotalLossPerformance.Sum(x => x.Price).ToString();
                        var NovTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 11, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.NovemberPerformance = NovTotalLossPerformance.Sum(x => x.Price).ToString();
                        var DecTotalLossPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year, 12, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.DecemberPerformance = DecTotalLossPerformance.Sum(x => x.Price).ToString();
                        totalPerformanceYearData.SumPerformance = totalPerformance.Sum(x => x.Price).ToString();
                        totalPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(totalPerformanceYearData.SumPerformance) / thisMonth, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion

                        break;
                    case 2:

                        totalPerformanceYearData.SortName = (query.Year - 1) + "年实际业绩";
                        #region 整体
                        var JanTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 1, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.JanuaryPerformance = JanTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var FebTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 2, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.FebruaryPerformance = FebTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var MarTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 3, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.MarchPerformance = MarTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var AprTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 4, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.AprilPerformance = AprTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var MayTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 5, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.MayPerformance = MayTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var JunTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 6, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.JunePerformance = JunTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var JulTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 7, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.JulyPerformance = JulTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var AugTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 8, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.AugustPerformance = AugTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var SepTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 9, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.SeptemberPerformance = SepTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var OctTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 10, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.OctoberPerformance = OctTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var NovTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 11, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.NovemberPerformance = NovTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        var DecTotalLossLastYearPerformance = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.Year - 1, 12, LiveAnchorInfo, query.IsOldCustomer);
                        totalPerformanceYearData.DecemberPerformance = DecTotalLossLastYearPerformance.Sum(x => x.Price).ToString();
                        totalPerformanceYearData.SumPerformance = totalPerformanceLastYear.Sum(x => x.Price).ToString();
                        totalPerformanceYearData.AveragePerformance = Math.Round(Convert.ToDecimal(totalPerformanceYearData.SumPerformance) / 12, 2, MidpointRounding.AwayFromZero).ToString();
                        #endregion

                        break;
                    case 3:

                        totalPerformanceYearData.SortName = "目标达成率";
                        #region 整体
                        var targetTotal = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年预算目标");
                        var completeTotal = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年实际业绩");
                        totalPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.JanuaryPerformance), Convert.ToDecimal(targetTotal.JanuaryPerformance)).ToString();
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.FebruaryPerformance), Convert.ToDecimal(targetTotal.FebruaryPerformance)).ToString();
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.MarchPerformance), Convert.ToDecimal(targetTotal.MarchPerformance)).ToString();
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.AprilPerformance), Convert.ToDecimal(targetTotal.AprilPerformance)).ToString();
                        totalPerformanceYearData.MayPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.MayPerformance), Convert.ToDecimal(targetTotal.MayPerformance)).ToString();
                        totalPerformanceYearData.JunePerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.JunePerformance), Convert.ToDecimal(targetTotal.JunePerformance)).ToString();
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.JulyPerformance), Convert.ToDecimal(targetTotal.JulyPerformance)).ToString();
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.AugustPerformance), Convert.ToDecimal(targetTotal.AugustPerformance)).ToString();
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.SeptemberPerformance), Convert.ToDecimal(targetTotal.SeptemberPerformance)).ToString();
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.OctoberPerformance), Convert.ToDecimal(targetTotal.OctoberPerformance)).ToString();
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.NovemberPerformance), Convert.ToDecimal(targetTotal.NovemberPerformance)).ToString();
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.DecemberPerformance), Convert.ToDecimal(targetTotal.DecemberPerformance)).ToString();
                        totalPerformanceYearData.SumPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completeTotal.SumPerformance), Convert.ToDecimal(targetTotal.SumPerformance)).ToString();
                        totalPerformanceYearData.AveragePerformance = "/";
                        #endregion


                        break;
                    case 4:
                        totalPerformanceYearData.SortName = "环比";
                        #region 整体
                        var completeTotalLastMonth = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == (query.Year - 1) + "年实际业绩");
                        var completeTotalThisMonth = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年实际业绩");
                        totalPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.JanuaryPerformance), Convert.ToDecimal(completeTotalLastMonth.DecemberPerformance)).ToString();
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.FebruaryPerformance), Convert.ToDecimal(completeTotalThisMonth.JanuaryPerformance)).ToString();
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.MarchPerformance), Convert.ToDecimal(completeTotalThisMonth.FebruaryPerformance)).ToString();
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.AprilPerformance), Convert.ToDecimal(completeTotalThisMonth.MarchPerformance)).ToString();
                        totalPerformanceYearData.MayPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.MayPerformance), Convert.ToDecimal(completeTotalThisMonth.AprilPerformance)).ToString();
                        totalPerformanceYearData.JunePerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.JunePerformance), Convert.ToDecimal(completeTotalThisMonth.MayPerformance)).ToString();
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.JulyPerformance), Convert.ToDecimal(completeTotalThisMonth.JunePerformance)).ToString();
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.AugustPerformance), Convert.ToDecimal(completeTotalThisMonth.JulyPerformance)).ToString();
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.SeptemberPerformance), Convert.ToDecimal(completeTotalThisMonth.AugustPerformance)).ToString();
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.OctoberPerformance), Convert.ToDecimal(completeTotalThisMonth.SeptemberPerformance)).ToString();
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.NovemberPerformance), Convert.ToDecimal(completeTotalThisMonth.OctoberPerformance)).ToString();
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisMonth.DecemberPerformance), Convert.ToDecimal(completeTotalThisMonth.NovemberPerformance)).ToString();
                        totalPerformanceYearData.SumPerformance = "/";
                        totalPerformanceYearData.AveragePerformance = "/";
                        #endregion


                        break;
                    case 5:
                        totalPerformanceYearData.SortName = "同比";
                        #region 整体
                        var completeTotalHistoryYear = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == (query.Year - 1) + "年实际业绩");
                        var completeTotalThisYear = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年实际业绩");
                        totalPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.JanuaryPerformance), Convert.ToDecimal(completeTotalHistoryYear.JanuaryPerformance)).ToString();
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.FebruaryPerformance), Convert.ToDecimal(completeTotalHistoryYear.FebruaryPerformance)).ToString();
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.MarchPerformance), Convert.ToDecimal(completeTotalHistoryYear.MarchPerformance)).ToString();
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.AprilPerformance), Convert.ToDecimal(completeTotalHistoryYear.AprilPerformance)).ToString();
                        totalPerformanceYearData.MayPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.MayPerformance), Convert.ToDecimal(completeTotalHistoryYear.MayPerformance)).ToString();
                        totalPerformanceYearData.JunePerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.JunePerformance), Convert.ToDecimal(completeTotalHistoryYear.JunePerformance)).ToString();
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.JulyPerformance), Convert.ToDecimal(completeTotalHistoryYear.JulyPerformance)).ToString();
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.AugustPerformance), Convert.ToDecimal(completeTotalHistoryYear.AugustPerformance)).ToString();
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.SeptemberPerformance), Convert.ToDecimal(completeTotalHistoryYear.SeptemberPerformance)).ToString();
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.OctoberPerformance), Convert.ToDecimal(completeTotalHistoryYear.OctoberPerformance)).ToString();
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.NovemberPerformance), Convert.ToDecimal(completeTotalHistoryYear.NovemberPerformance)).ToString();
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateChain(Convert.ToDecimal(completeTotalThisYear.DecemberPerformance), Convert.ToDecimal(completeTotalHistoryYear.DecemberPerformance)).ToString();
                        totalPerformanceYearData.SumPerformance = "/";
                        totalPerformanceYearData.AveragePerformance = "/";
                        #endregion


                        break;
                    case 6:
                        totalPerformanceYearData.SortName = query.Year + "年新/老客占比";

                        #region 整体
                        var totalNewCustomer = await contentPlatFormOrderDealInfoService.GetNewOrOldCustomerNumByDateAsync(Convert.ToDateTime(query.Year + "-01-01"), Convert.ToDateTime(query.Year + "-12-31"), false, LiveAnchorInfo);
                        var totalOldCustomer = await contentPlatFormOrderDealInfoService.GetNewOrOldCustomerNumByDateAsync(Convert.ToDateTime(query.Year + "-01-01"), Convert.ToDateTime(query.Year + "-12-31"), true, LiveAnchorInfo);
                        totalPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 1).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 1).Count());
                        totalPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 2).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 2).Count());
                        totalPerformanceYearData.MarchPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 3).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 3).Count());
                        totalPerformanceYearData.AprilPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 4).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 4).Count());
                        totalPerformanceYearData.MayPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 5).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 5).Count());
                        totalPerformanceYearData.JunePerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 6).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 6).Count());
                        totalPerformanceYearData.JulyPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 7).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 7).Count());
                        totalPerformanceYearData.AugustPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 8).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 8).Count());
                        totalPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 9).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 9).Count());
                        totalPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 10).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 10).Count());
                        totalPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 11).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 11).Count());
                        totalPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Where(x => x.CreateDate.Month == 12).Count(), totalOldCustomer.Where(x => x.CreateDate.Month == 12).Count());
                        totalPerformanceYearData.SumPerformance = DecimalExtension.CalculateAccounted(totalNewCustomer.Count(), totalOldCustomer.Count());
                        totalPerformanceYearData.AveragePerformance = "/";
                        #endregion


                        break;
                }

                result.TotalPerformanceData.Add(totalPerformanceYearData);
            }

            return result;
        }

        /// <summary>
        /// 获取名索医美（年度）线索趋势（运营看板转化）
        /// </summary>
        /// <returns></returns>
        public async Task<PerformanceYearDataListDto> GetTotalCluesByYearAsync(QueryMingSuoPerfomanceYearDataDto query)
        {
            #region 实例化输出项
            PerformanceYearDataListDto result = new PerformanceYearDataListDto();
            result.DaoDaoPerformanceData = new List<PerformanceYearDataDto>();
            result.JiNaPerformanceData = new List<PerformanceYearDataDto>();
            #endregion

            #region 获取主播信息
            string text = "（线索）";
            int totalCount = 4;

            string totalPerformanceName = "美妍" + text;
            var liveAnchorBaseInfo = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.LiveAnchorBaseIdId))
            {
                var liveAnchorBaseInfoData = await liveAnchorBaseInfoService.GetByIdAsync(query.LiveAnchorBaseIdId);
                totalPerformanceName = liveAnchorBaseInfoData.LiveAnchorName + text;
                liveAnchorBaseInfo = new List<Dto.LiveAnchorBaseInfo.LiveAnchorBaseInfoDto>();
                liveAnchorBaseInfo.Add(liveAnchorBaseInfoData);
            }
            List<int> LiveAnchorInfo = new List<int>();
            //获取对应主播IP账户信息
            var liveAnchorTotal = await liveAnchorService.GetLiveAnchorListByBaseInfoIdListAsync(liveAnchorBaseInfo.Select(x => x.Id).ToList());
            LiveAnchorInfo = liveAnchorTotal.Select(x => x.Id).ToList();
            #endregion
            #region 获取直播前/中/后年度线索目标
            List<AmiyaOperationBoardCluesChannelTargetDto> targetData = new List<AmiyaOperationBoardCluesChannelTargetDto>();
            if (query.BelongChannel == (int)BelongChannel.LiveBefore)
            {
                targetData = await liveAnchorMonthlyTargetBeforeLivingService.GetCluePerformanceTargetByYearAsync(query.Year, LiveAnchorInfo);
            }
            else if (query.BelongChannel == (int)BelongChannel.LiveAfter)
            {
                targetData = await liveAnchorMonthlyTargetAfterLivingService.GetPerformanceByYearAsync(query.Year, LiveAnchorInfo, null);
            }
            var targetBeforeLiving = targetData.Where(x => LiveAnchorInfo.Contains(x.LiveAnchorId)).ToList();

            #endregion

            #region 获取直播前本年度小黄车数据
            var totalClues = await shoppingCartRegistrationService.GetShoppingCartRegistrationDataByYearAsync(query.Year, query.BelongChannel, null);
            var mingSuoClues = totalClues.Where(x => LiveAnchorInfo.Contains(x.LiveAnchorId)).ToList();
            #endregion
            result.TotalPerformanceData = new List<PerformanceYearDataDto>();
            for (int x = 0; x <= totalCount; x++)
            {
                PerformanceYearDataDto mingSuoPerformanceYearData = new PerformanceYearDataDto();
                mingSuoPerformanceYearData.GroupName = totalPerformanceName;
                switch (x)
                {
                    case 0:
                        mingSuoPerformanceYearData.SortName = query.Year + "年线索目标";
                        #region 名索
                        mingSuoPerformanceYearData.JanuaryPerformance = targetBeforeLiving.Where(x => x.Month == 1).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.FebruaryPerformance = targetBeforeLiving.Where(x => x.Month == 2).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.MarchPerformance = targetBeforeLiving.Where(x => x.Month == 3).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.AprilPerformance = targetBeforeLiving.Where(x => x.Month == 4).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.MayPerformance = targetBeforeLiving.Where(x => x.Month == 5).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.JunePerformance = targetBeforeLiving.Where(x => x.Month == 6).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.JulyPerformance = targetBeforeLiving.Where(x => x.Month == 7).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.AugustPerformance = targetBeforeLiving.Where(x => x.Month == 8).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.SeptemberPerformance = targetBeforeLiving.Where(x => x.Month == 9).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.OctoberPerformance = targetBeforeLiving.Where(x => x.Month == 10).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.NovemberPerformance = targetBeforeLiving.Where(x => x.Month == 11).Sum(t => t.CluesTarget).ToString();
                        mingSuoPerformanceYearData.DecemberPerformance = targetBeforeLiving.Where(x => x.Month == 12).Sum(t => t.CluesTarget).ToString();

                        #endregion

                        break;
                    case 1:

                        mingSuoPerformanceYearData.SortName = query.Year + "年线索实际";
                        #region 名索
                        mingSuoPerformanceYearData.JanuaryPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 1).Count().ToString();
                        mingSuoPerformanceYearData.FebruaryPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 2).Count().ToString();
                        mingSuoPerformanceYearData.MarchPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 3).Count().ToString();
                        mingSuoPerformanceYearData.AprilPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 4).Count().ToString();
                        mingSuoPerformanceYearData.MayPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 5).Count().ToString();
                        mingSuoPerformanceYearData.JunePerformance = mingSuoClues.Where(x => x.RecordDate.Month == 6).Count().ToString();
                        mingSuoPerformanceYearData.JulyPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 7).Count().ToString();
                        mingSuoPerformanceYearData.AugustPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 8).Count().ToString();
                        mingSuoPerformanceYearData.SeptemberPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 9).Count().ToString();
                        mingSuoPerformanceYearData.OctoberPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 10).Count().ToString();
                        mingSuoPerformanceYearData.NovemberPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 11).Count().ToString();
                        mingSuoPerformanceYearData.DecemberPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 12).Count().ToString();
                        #endregion

                        break;
                    case 2:

                        mingSuoPerformanceYearData.SortName = query.Year + "年线索达成率";

                        #region 名索
                        var target = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年线索目标");
                        var complete = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年线索实际");
                        mingSuoPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.JanuaryPerformance), Convert.ToDecimal(target.JanuaryPerformance)).ToString();
                        mingSuoPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.FebruaryPerformance), Convert.ToDecimal(target.FebruaryPerformance)).ToString();
                        mingSuoPerformanceYearData.MarchPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.MarchPerformance), Convert.ToDecimal(target.MarchPerformance)).ToString();
                        mingSuoPerformanceYearData.AprilPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.AprilPerformance), Convert.ToDecimal(target.AprilPerformance)).ToString();
                        mingSuoPerformanceYearData.MayPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.MayPerformance), Convert.ToDecimal(target.MayPerformance)).ToString();
                        mingSuoPerformanceYearData.JunePerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.JunePerformance), Convert.ToDecimal(target.JunePerformance)).ToString();
                        mingSuoPerformanceYearData.JulyPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.JulyPerformance), Convert.ToDecimal(target.JulyPerformance)).ToString();
                        mingSuoPerformanceYearData.AugustPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.AugustPerformance), Convert.ToDecimal(target.AugustPerformance)).ToString();
                        mingSuoPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.SeptemberPerformance), Convert.ToDecimal(target.SeptemberPerformance)).ToString();
                        mingSuoPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.OctoberPerformance), Convert.ToDecimal(target.OctoberPerformance)).ToString();
                        mingSuoPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.NovemberPerformance), Convert.ToDecimal(target.NovemberPerformance)).ToString();
                        mingSuoPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(complete.DecemberPerformance), Convert.ToDecimal(target.DecemberPerformance)).ToString();
                        #endregion

                        break;
                    case 3:

                        mingSuoPerformanceYearData.SortName = query.Year + "年加v实际";
                        #region 名索
                        mingSuoPerformanceYearData.JanuaryPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 1 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.FebruaryPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 2 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.MarchPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 3 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.AprilPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 4 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.MayPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 5 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.JunePerformance = mingSuoClues.Where(x => x.RecordDate.Month == 6 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.JulyPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 7 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.AugustPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 8 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.SeptemberPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 9 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.OctoberPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 10 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.NovemberPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 11 && x.IsAddWeChat == true).Count().ToString();
                        mingSuoPerformanceYearData.DecemberPerformance = mingSuoClues.Where(x => x.RecordDate.Month == 12 && x.IsAddWeChat == true).Count().ToString();
                        #endregion

                        break;
                    case 4:
                        mingSuoPerformanceYearData.SortName = query.Year + "年加v率";

                        #region 名索
                        var clues = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年线索实际");
                        var completAddWechate = result.TotalPerformanceData.SingleOrDefault(x => x.SortName == query.Year + "年加v实际");
                        mingSuoPerformanceYearData.JanuaryPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.JanuaryPerformance), Convert.ToDecimal(clues.JanuaryPerformance)).ToString();
                        mingSuoPerformanceYearData.FebruaryPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.FebruaryPerformance), Convert.ToDecimal(clues.FebruaryPerformance)).ToString();
                        mingSuoPerformanceYearData.MarchPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.MarchPerformance), Convert.ToDecimal(clues.MarchPerformance)).ToString();
                        mingSuoPerformanceYearData.AprilPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.AprilPerformance), Convert.ToDecimal(clues.AprilPerformance)).ToString();
                        mingSuoPerformanceYearData.MayPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.MayPerformance), Convert.ToDecimal(clues.MayPerformance)).ToString();
                        mingSuoPerformanceYearData.JunePerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.JunePerformance), Convert.ToDecimal(clues.JunePerformance)).ToString();
                        mingSuoPerformanceYearData.JulyPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.JulyPerformance), Convert.ToDecimal(clues.JulyPerformance)).ToString();
                        mingSuoPerformanceYearData.AugustPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.AugustPerformance), Convert.ToDecimal(clues.AugustPerformance)).ToString();
                        mingSuoPerformanceYearData.SeptemberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.SeptemberPerformance), Convert.ToDecimal(clues.SeptemberPerformance)).ToString();
                        mingSuoPerformanceYearData.OctoberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.OctoberPerformance), Convert.ToDecimal(clues.OctoberPerformance)).ToString();
                        mingSuoPerformanceYearData.NovemberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.NovemberPerformance), Convert.ToDecimal(clues.NovemberPerformance)).ToString();
                        mingSuoPerformanceYearData.DecemberPerformance = DecimalExtension.CalculateTargetComplete(Convert.ToDecimal(completAddWechate.DecemberPerformance), Convert.ToDecimal(clues.DecemberPerformance)).ToString();
                        #endregion



                        break;
                }

                result.TotalPerformanceData.Add(mingSuoPerformanceYearData);
            }

            return result;
        }


        /// <summary>
        /// 根据时间获取全国机构运营数据概况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        public async Task<List<HospitalPerformanceDto>> GetHospitalPerformanceByDateAsync(QueryMingSuoHospitalTransformDataDto query)
        {

            List<HospitalPerformanceDto> resultList = new List<HospitalPerformanceDto>();
            QueryHospitalTransformDataDto queryData = new QueryHospitalTransformDataDto();
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate, query.EndDate);
            queryData.StartDate = selectDate.StartDate;
            queryData.EndDate = selectDate.EndDate;

            var liveAnchorBaseInfo = await liveAnchorBaseInfoService.GetMingSuoLiveAnchorAsync();
            if (!string.IsNullOrEmpty(query.LiveAnchorBaseId))
            {
                var liveAnchorBaseInfoData = await liveAnchorBaseInfoService.GetByIdAsync(query.LiveAnchorBaseId);
                liveAnchorBaseInfo = new List<Dto.LiveAnchorBaseInfo.LiveAnchorBaseInfoDto>();
                liveAnchorBaseInfo.Add(liveAnchorBaseInfoData);
            }
            queryData.LiveAnchorIds = liveAnchorBaseInfo.Select(x => x.Id).ToList();
            var contentPlatFormOrderSendList = await contentPlatformOrderSendService.GetTodayOrderSendDataAsync(queryData);
            foreach (var x in contentPlatFormOrderSendList)
            {

                var isExist = resultList.Where(z => z.HospitalId == x.SendHospitalId).Count();
                if (isExist > 0)
                {
                    continue;
                }
                HospitalPerformanceDto hospitalPerformanceDto = new HospitalPerformanceDto();
                hospitalPerformanceDto.HospitalId = x.SendHospitalId;
                hospitalPerformanceDto.HospitalName = x.SendHospital;
                hospitalPerformanceDto.City = x.City;
                List<int> hospitalIds = new List<int>();
                hospitalIds.Add(x.SendHospitalId);
                queryData.HospitalId = hospitalIds;
                hospitalPerformanceDto.SendNum = contentPlatFormOrderSendList.Where(z => hospitalIds.Contains(z.SendHospitalId)).Count();
                var contentPlatFormOrderDealInfoList = await contentPlatFormOrderDealInfoService.GetSendPerformanceByHospitalIdAndDateTimeAsync(queryData);
                hospitalPerformanceDto.VisitNum = contentPlatFormOrderDealInfoList.Count();
                hospitalPerformanceDto.VisitRate = DecimalExtension.CalculateTargetComplete(hospitalPerformanceDto.VisitNum, hospitalPerformanceDto.SendNum).Value;
                var dealInfoList = contentPlatFormOrderDealInfoList.Where(x => x.IsDeal == true && x.DealDate.HasValue == true);
                hospitalPerformanceDto.NewCustomerDealNum = dealInfoList.Where(x => x.IsOldCustomer == false).Count();
                hospitalPerformanceDto.NewCustomerDealRate = DecimalExtension.CalculateTargetComplete(hospitalPerformanceDto.NewCustomerDealNum, hospitalPerformanceDto.VisitNum).Value;
                hospitalPerformanceDto.NewCustomerAchievement = dealInfoList.Where(x => x.IsOldCustomer == false).Sum(x => x.Price);
                hospitalPerformanceDto.NewCustomerUnitPrice = DecimalExtension.Division(hospitalPerformanceDto.NewCustomerAchievement, hospitalPerformanceDto.NewCustomerDealNum).Value;
                hospitalPerformanceDto.OldCustomerDealNum = dealInfoList.Where(x => x.IsOldCustomer == true).Count();
                hospitalPerformanceDto.OldCustomerAchievement = dealInfoList.Where(x => x.IsOldCustomer == true).Sum(x => x.Price);
                hospitalPerformanceDto.OldCustomerUnitPrice = DecimalExtension.Division(hospitalPerformanceDto.OldCustomerAchievement, hospitalPerformanceDto.OldCustomerDealNum).Value;
                hospitalPerformanceDto.TotalAchievement = dealInfoList.Sum(x => x.Price);
                hospitalPerformanceDto.NewOrOldCustomerRate = DecimalExtension.CalculateAccounted(hospitalPerformanceDto.NewCustomerAchievement, hospitalPerformanceDto.OldCustomerAchievement);
                resultList.Add(hospitalPerformanceDto);
            }
            var res = resultList.OrderByDescending(e => e.SendNum).Skip(0).Take(10).ToList();
            var totalPerformance = resultList.Sum(e => e.TotalAchievement);
            foreach (var item in res)
            {
                item.Rate = DecimalExtension.CalculateTargetComplete(item.TotalAchievement, totalPerformance).Value;
            }
            return res;
        }

        #region 公共类

        /// <summary>
        /// 填充日期数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private List<PerformanceBrokenLineListInfoDto> FillDate(int year, int month, List<PerformanceBrokenLineListInfoDto> dataList)
        {
            List<PerformanceBrokenLineListInfoDto> list = new List<PerformanceBrokenLineListInfoDto>();

            var totalDays = DateTime.DaysInMonth(year, month);
            for (int i = 1; i < totalDays + 1; i++)
            {
                PerformanceBrokenLineListInfoDto item = new PerformanceBrokenLineListInfoDto();
                item.date = i.ToString();
                item.Performance = dataList.Where(e => e.date == item.date).Select(e => e.Performance).SingleOrDefault() ?? 0m;
                list.Add(item);
            }
            return list;
        }

        private decimal ChangePriceToTenThousand(decimal performance, int unit = 1)
        {
            if (performance == 0m)
                return 0;
            var result = Math.Round((performance / 10000), unit, MidpointRounding.AwayFromZero);
            return result;
        }
        #endregion
    }
}
