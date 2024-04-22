using Fx.Amiya.Dto.AmiyaOperationsBoardService;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AmiyaOperationsBoardServiceService : IAmiyaOperationsBoardService
    {
        private readonly ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService;
        private readonly ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ILiveAnchorService liveAnchorService;
        private readonly IShoppingCartRegistrationService shoppingCartRegistrationService;
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;
        private readonly IAmiyaEmployeeService amiyaEmployeeService;
        private readonly IEmployeePerformanceTargetService employeePerformanceTargetService;
        private readonly IContentPlatformOrderSendService contentPlatformOrderSendService;
        private readonly ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService;

        public AmiyaOperationsBoardServiceService(
            ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService,
            ILiveAnchorBaseInfoService liveAnchorBaseInfoService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            ILiveAnchorService liveAnchorService,
            IShoppingCartRegistrationService shoppingCartRegistrationService,
            IContentPlateFormOrderService contentPlateFormOrderService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IEmployeePerformanceTargetService employeePerformanceTargetService,
            IContentPlatformOrderSendService contentPlatformOrderSendService,
            ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService)
        {
            this.liveAnchorMonthlyTargetLivingService = liveAnchorMonthlyTargetLivingService;
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.liveAnchorService = liveAnchorService;
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.employeePerformanceTargetService = employeePerformanceTargetService;
            this.contentPlatformOrderSendService = contentPlatformOrderSendService;
            this.liveAnchorMonthlyTargetAfterLivingService = liveAnchorMonthlyTargetAfterLivingService;
        }

        #region  运营主看板
        /// <summary>
        /// 获取时间进度和总业绩
        /// </summary>
        /// <returns></returns>
        public async Task<OperationTotalAchievementDataDto> GetTotalAchievementAndDateScheduleAsync(QueryOperationDataDto query)
        {
            OperationTotalAchievementDataDto result = new OperationTotalAchievementDataDto();
            var dateSchedule = DateTimeExtension.GetDatetimeSchedule(query.endDate.Value).FirstOrDefault();
            result.DateSchedule = dateSchedule.Value;
            var orderDealInfo = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(query.startDate.Value, query.endDate.Value, new List<int>());
            //总业绩数据值
            result.TotalAchievement = orderDealInfo.Sum(x => x.Price);
            var order = await contentPlatFormOrderDealInfoService.GetSimplePerformanceDetailByDateAsync(query.startDate.Value, query.endDate.Value);

            var dateList = order.GroupBy(x => x.CreateDate.Day).Select(x => new OerationTotalAchievementBrokenLineListDto
            {
                Time = x.Key,
                TotalCustomerPerformance = x.Sum(e => e.Price),
                NewCustomerPerformance = x.Where(e => e.IsOldCustomer == false).Sum(e => e.Price),
                OldCustomerPerformance = x.Where(e => e.IsOldCustomer == true).Sum(e => e.Price),
            });
            List<OerationTotalAchievementBrokenLineListDto> GroupList = new List<OerationTotalAchievementBrokenLineListDto>();
            for (int i = 1; i < dateSchedule.Key + 1; i++)
            {
                OerationTotalAchievementBrokenLineListDto item = new OerationTotalAchievementBrokenLineListDto();
                item.Time = i;
                item.TotalCustomerPerformance = dateList.Where(e => e.Time == i).Select(e => e.TotalCustomerPerformance).SingleOrDefault();
                item.NewCustomerPerformance = dateList.Where(e => e.Time == i).Select(e => e.NewCustomerPerformance).SingleOrDefault();
                item.OldCustomerPerformance = dateList.Where(e => e.Time == i).Select(e => e.OldCustomerPerformance).SingleOrDefault();

                GroupList.Add(item);
            }
            result.TotalPerformanceBrokenLineList = GroupList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = DecimalExtension.ChangePriceToTenThousand(e.TotalCustomerPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            result.NewCustomerPerformanceBrokenLineList = GroupList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = DecimalExtension.ChangePriceToTenThousand(e.NewCustomerPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            result.OldCustomerPerformanceBrokenLineList = GroupList.Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = DecimalExtension.ChangePriceToTenThousand(e.OldCustomerPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            return result;
        }

        /// <summary>
        /// 获取获客情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<GetCustomerDataDto> GetCustomerDataAsync(QueryOperationDataDto query)
        {
            var shoppingCartRegistionDataResult = await shoppingCartRegistrationService.GetCustomerDataAsync(query.startDate, query.endDate);
            return shoppingCartRegistionDataResult;
        }

        /// <summary>
        /// 获取客户运营情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<GetCustomerAnalizeDataDto> GetCustomerAnalizeDataAsync(QueryOperationDataDto query)
        {
            GetCustomerAnalizeDataDto result = new GetCustomerAnalizeDataDto();
            List<int> LiveAnchorInfoDaoDao = new List<int>();
            var liveAnchorDaoDao = await liveAnchorService.GetValidListByLiveAnchorBaseIdAsync("f0a77257-c905-4719-95c4-ad2c4f33855c");
            LiveAnchorInfoDaoDao = liveAnchorDaoDao.Select(x => x.Id).ToList();
            var contentPlatFormOrderDataDaoDao = await contentPlateFormOrderService.GetOrderSendAndDealDataByMonthAsync(query.startDate.Value, query.endDate.Value, null, "", LiveAnchorInfoDaoDao);

            List<int> LiveAnchorInfoJiNa = new List<int>();
            var liveAnchorJina = await liveAnchorService.GetValidListByLiveAnchorBaseIdAsync("af69dcf5-f749-41ea-8b50-fe685facdd8b");
            LiveAnchorInfoJiNa = liveAnchorJina.Select(x => x.Id).ToList();
            var contentPlatFormOrderDataJiNa = await contentPlateFormOrderService.GetOrderSendAndDealDataByMonthAsync(query.startDate.Value, query.endDate.Value, null, "", LiveAnchorInfoJiNa);
            CustomerAnalizeByGroupDto SendGroupDto = new CustomerAnalizeByGroupDto();
            SendGroupDto.GroupDaoDao = contentPlatFormOrderDataDaoDao.SendOrderNum;
            SendGroupDto.GroupJiNa = contentPlatFormOrderDataJiNa.SendOrderNum;
            SendGroupDto.TotalNum = SendGroupDto.GroupDaoDao + SendGroupDto.GroupJiNa;
            result.SendNum = SendGroupDto;

            CustomerAnalizeByGroupDto VisitGroupDto = new CustomerAnalizeByGroupDto();
            VisitGroupDto.GroupDaoDao = contentPlatFormOrderDataDaoDao.VisitNum;
            VisitGroupDto.GroupJiNa = contentPlatFormOrderDataJiNa.VisitNum;
            VisitGroupDto.TotalNum = VisitGroupDto.GroupJiNa + VisitGroupDto.GroupDaoDao;
            result.VisitNum = VisitGroupDto;

            CustomerAnalizeByGroupDto DealGroupDto = new CustomerAnalizeByGroupDto();
            DealGroupDto.GroupDaoDao = contentPlatFormOrderDataDaoDao.DealNum;
            DealGroupDto.GroupJiNa = contentPlatFormOrderDataJiNa.DealNum;
            DealGroupDto.TotalNum = DealGroupDto.GroupJiNa + DealGroupDto.GroupDaoDao;
            result.DealNum = DealGroupDto;
            return result;
        }

        /// <summary>
        /// 获取客户指标转化数据
        /// </summary>
        /// <returns></returns>
        public async Task<GetCustomerIndexTransformationResultDto> GetCustomerIndexTransformationDataAsync(QueryOperationDataDto query)
        {
            GetCustomerIndexTransformationResultDto result = new GetCustomerIndexTransformationResultDto();
            //小黄车数据
            var baseShoppingCartRegistionData = await shoppingCartRegistrationService.GetNewBaseBusinessPerformanceByLiveAnchorNameAsync(query.startDate.Value, query.endDate.Value, null, "");

            //订单数据
            var baseOrderPerformance = await contentPlateFormOrderService.GetOrderSendAndDealDataByMonthAsync(query.startDate.Value, query.endDate.Value, null, "", new List<int>());

            result.AddCardNum = baseShoppingCartRegistionData.Count();
            result.RefundCardNum = baseShoppingCartRegistionData.Where(x => x.IsReturnBackPrice == true).Count();
            result.DistributeConsulationNum = baseShoppingCartRegistionData.Where(x => x.AssignEmpId.HasValue).Count();
            result.AddWechatNum = baseShoppingCartRegistionData.Where(x => x.IsAddWeChat == true).Count();
            result.SendOrderNum = baseOrderPerformance.SendOrderNum;
            result.VisitNum = baseOrderPerformance.VisitNum;
            result.DealNum = baseOrderPerformance.DealNum;

            return result;
        }

        /// <summary>
        /// 获取助理业绩分析数据
        /// </summary>
        /// <returns></returns>
        public async Task<GetEmployeePerformanceAnalizeDataDto> GetEmployeePerformanceAnalizeDataAsync(QueryOperationDataDto query)
        {
            GetEmployeePerformanceAnalizeDataDto result = new GetEmployeePerformanceAnalizeDataDto();

            List<int> amiyaEmployeeIds = new List<int>();
            //获取所有助理
            var employeeInfos = await amiyaEmployeeService.GetemployeeByPositionIdAsync(4);
            amiyaEmployeeIds = employeeInfos.Select(x => x.Id).ToList();

            #region 【助理业绩-5条】
            var dealInfo = await contentPlateFormOrderService.GetFourCustomerServicePerformanceByCustomerServiceIdAsync(query.startDate.Value, query.endDate.Value, amiyaEmployeeIds);
            List<GetEmployeePerformanceDataDto> employeeDataList = new List<GetEmployeePerformanceDataDto>();
            foreach (var x in dealInfo)
            {
                GetEmployeePerformanceDataDto getEmployeePerformanceDataDto = new GetEmployeePerformanceDataDto();
                getEmployeePerformanceDataDto.EmployeeName = x.CustomerServiceName;
                getEmployeePerformanceDataDto.Performance = x.TotalServicePrice;
                var employeeDataTarget = await employeePerformanceTargetService.GetByEmpIdAndYearMonthAsync(x.CustomerServiceId, query.endDate.Value.Year, query.endDate.Value.Month);
                if (employeeDataTarget != 0)
                {
                    getEmployeePerformanceDataDto.CompleteRate = Math.Round(x.TotalServicePrice / employeeDataTarget * 100, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    getEmployeePerformanceDataDto.CompleteRate = 0;
                }
                employeeDataList.Add(getEmployeePerformanceDataDto);
            }
            result.EmployeeDatas = employeeDataList;
            #endregion

            #region 【助理获客情况-10条】
            var shoppingCartRegistionData = await shoppingCartRegistrationService.GetNewBaseBusinessPerformanceByLiveAnchorNameAsync(query.startDate.Value, query.endDate.Value, null, "");

            result.EmployeeDistributeConsulationNumAndAddWechats = shoppingCartRegistionData.Where(x => x.AssignEmpId.HasValue).GroupBy(x => x.AssignEmpId).Select(x => new GetEmployeeDistributeConsulationNumAndAddWechatDto
            {
                EmployeeId = Convert.ToInt32(x.Key.ToString()),
                DistributeConsulationNum = x.Count(),
                AddWechatNum = x.Where(e => e.IsAddWeChat == true).Count(),
            }).Where(x => x.DistributeConsulationNum > 0).Take(10).ToList();
            foreach (var x in result.EmployeeDistributeConsulationNumAndAddWechats)
            {
                var empInfo = await amiyaEmployeeService.GetByIdAsync(x.EmployeeId);
                x.EmployeeName = empInfo.Name;
            }
            #endregion

            #region 【助理客户运营情况-10条】
            List<GetEmployeeCustomerAnalizeDto> getEmployeeCustomerAnalizeDtos = new List<GetEmployeeCustomerAnalizeDto>();
            foreach (var x in amiyaEmployeeIds)
            {
                GetEmployeeCustomerAnalizeDto getEmployeeCustomerAnalizeDto = new GetEmployeeCustomerAnalizeDto();
                var empInfo = await amiyaEmployeeService.GetByIdAsync(x);
                getEmployeeCustomerAnalizeDto.EmployeeName = empInfo.Name;
                getEmployeeCustomerAnalizeDto.SendOrderNum = await contentPlatformOrderSendService.GetTotalSendCountByEmployeeAsync(x, query.startDate.Value, query.endDate.Value);
                var contentPlatFormVisitAndDealNumData = await contentPlateFormOrderService.GetCustomerVisitAndIsDealByEmployeeIdAsync(query.startDate.Value, query.endDate.Value, x);
                getEmployeeCustomerAnalizeDto.VisitNum = contentPlatFormVisitAndDealNumData.VisitNum;
                getEmployeeCustomerAnalizeDto.DealNum = contentPlatFormVisitAndDealNumData.DealNum;
                getEmployeeCustomerAnalizeDtos.Add(getEmployeeCustomerAnalizeDto);
            }
            result.GetEmployeeCustomerAnalizes = getEmployeeCustomerAnalizeDtos.Where(x => x.SendOrderNum > 0).OrderByDescending(x => x.SendOrderNum).Take(10).ToList();
            #endregion

            #region 【业绩贡献占比-根据助理业绩获取条数输出】
            var orderDealInfo = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(query.startDate.Value, query.endDate.Value, new List<int>());
            //总业绩数据值
            var totalAchievement = orderDealInfo.Sum(x => x.Price);
            List<GetEmployeePerformanceRankingDto> getEmployeePerformanceRankingDtos = new List<GetEmployeePerformanceRankingDto>();
            foreach (var x in employeeDataList)
            {
                GetEmployeePerformanceRankingDto getEmployeePerformanceRankingDto = new GetEmployeePerformanceRankingDto();
                getEmployeePerformanceRankingDto.EmployeeName = x.EmployeeName;
                getEmployeePerformanceRankingDto.Performance = DecimalExtension.CalculateTargetComplete(x.Performance, totalAchievement).Value;
                getEmployeePerformanceRankingDtos.Add(getEmployeePerformanceRankingDto);
            }
            result.GetEmployeePerformanceRankings = getEmployeePerformanceRankingDtos.OrderByDescending(x => x.Performance).ToList();

            #endregion
            return result;
        }


        #endregion

        #region 公司看板
        /// <summary>
        /// 获取公司看板业绩情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<CompanyPerformanceDataDto>> GetCompanyPerformanceDataAsync(QueryAmiyaCompanyOperationsDataDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate.Value, query.EndDate.Value);
            var nameList = await liveAnchorBaseInfoService.GetValidAsync(true);
            query.LiveAnchorIds = nameList.Select(e => e.Id).ToList();
            var liveanchorIds = (await liveAnchorService.GetLiveAnchorListByBaseInfoIdListAsync(query.LiveAnchorIds)).Select(e => e.Id).ToList();
            var targetList = await liveAnchorMonthlyTargetAfterLivingService.GetPerformanceTargetByBaseLiveAnchorIdAsync(selectDate.StartDate.Year, selectDate.EndDate.Month, query.LiveAnchorIds);
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(query.StartDate.Value, query.EndDate.Value, liveanchorIds);
            var dataList = order.GroupBy(e => e.BaseLiveAnchorId).Select(e =>
            {
                var liveanchorName = nameList.Where(a => a.Id == e.Key).Select(e => e.LiveAnchorName).FirstOrDefault();
                var target = targetList.Where(t => t.BaseLiveAbchorId == e.Key).FirstOrDefault();
                CompanyPerformanceDataDto data = new CompanyPerformanceDataDto();
                data.GroupName = $"{liveanchorName}组";
                data.CurrentMonthNewCustomerPerformance = e.Where(e => e.IsOldCustomer == false).Sum(e => e.Price);
                data.NewCustomerPerformanceTarget = target?.NewCustomerPerformanceTarget ?? 0m;
                data.NewCustomerPerformanceTargetComplete = DecimalExtension.CalculateTargetComplete(data.CurrentMonthNewCustomerPerformance, data.NewCustomerPerformanceTarget ?? 0m);
                data.CurrentMonthOldCustomerPerformance = e.Where(e => e.IsOldCustomer == true).Sum(e => e.Price);
                data.OldCustomerTarget = target?.OldCustomerPerformanceTarget ?? 0m;
                data.OldCustomerTargetComplete = DecimalExtension.CalculateTargetComplete(data.CurrentMonthOldCustomerPerformance, data.OldCustomerTarget ?? 0m);
                data.TotalPerformance = e.Sum(e => e.Price);
                data.TotalPerformanceTarget = target?.TotalPerformanceTarget ?? 0m;
                data.TotalPerformanceTargetComplete = DecimalExtension.CalculateTargetComplete(data.TotalPerformance, data.TotalPerformanceTarget);
                return data;
            }).ToList();
            var total = new CompanyPerformanceDataDto();
            total.GroupName = "总计";
            total.CurrentMonthNewCustomerPerformance = dataList.Sum(e => e.CurrentMonthNewCustomerPerformance);
            total.NewCustomerPerformanceTarget = dataList.Sum(e => e.NewCustomerPerformanceTarget);
            total.NewCustomerPerformanceTargetComplete = DecimalExtension.CalculateTargetComplete(total.CurrentMonthNewCustomerPerformance, total.NewCustomerPerformanceTarget ?? 0m);
            total.CurrentMonthOldCustomerPerformance = dataList.Sum(e => e.CurrentMonthOldCustomerPerformance);
            total.OldCustomerTarget = dataList.Sum(e => e.OldCustomerTarget);
            total.OldCustomerTargetComplete = DecimalExtension.CalculateTargetComplete(total.CurrentMonthOldCustomerPerformance, total.OldCustomerTarget ?? 0m);
            total.TotalPerformance = dataList.Sum(e => e.TotalPerformance);
            total.TotalPerformanceTarget = dataList.Sum(e => e.TotalPerformanceTarget);
            total.TotalPerformanceTargetComplete = DecimalExtension.CalculateTargetComplete(total.TotalPerformance, total.TotalPerformanceTarget);
            dataList.Add(total);
            return dataList;
        }
        /// <summary>
        /// 获取公司看板获客情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<CompanyCustomerAcquisitionDataDto>> GetCompanyCustomerAcquisitionDataAsync(QueryAmiyaCompanyOperationsDataDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate.Value, query.EndDate.Value);
            var nameList = await liveAnchorBaseInfoService.GetValidAsync(true);
            query.LiveAnchorIds = nameList.Select(e => e.Id).ToList();
            var livingTarget = await liveAnchorMonthlyTargetLivingService.GetConsulationCardAddTargetByDateAsync(query.StartDate.Value.Year, query.StartDate.Value.Month, query.LiveAnchorIds);
            var dataList = new List<CompanyCustomerAcquisitionDataDto>();
            foreach (var liveanchor in nameList)
            {
                var assistantTarget = await employeePerformanceTargetService.GetEmployeeTargetByBaseLiveAnchorIdAsync(query.StartDate.Value.Year, query.StartDate.Value.Month, liveanchor.Id);
                var data = await shoppingCartRegistrationService.GetPerformanceByBaseLiveAnchorIdAsync(selectDate.StartDate, selectDate.EndDate, false, liveanchor.Id);
                var liveanchorName = nameList.Where(e => e.Id == liveanchor.Id).Select(e => e.LiveAnchorName).FirstOrDefault();
                CompanyCustomerAcquisitionDataDto dataItem = new CompanyCustomerAcquisitionDataDto();
                dataItem.GroupName = $"{liveanchorName}组-有效业绩";
                dataItem.OrderCard = data.Where(e => e.IsReturnBackPrice == false).Count();
                dataItem.OrderCardTarget = livingTarget?.Sum(e => e.ConsulationCardTarget) ?? 0;
                dataItem.OrderCardTargetComplete = DecimalExtension.CalculateTargetComplete(dataItem.OrderCard, dataItem.OrderCardTarget).Value;
                dataItem.RefundCard = data.Where(x => x.IsReturnBackPrice == true).Count();
                dataItem.OrderCardError = 0;
                dataItem.AllocationConsulationTarget = assistantTarget?.EffectiveConsulationCardTarget ?? 0;
                dataItem.AllocationConsulation = data.Count();
                dataItem.AllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(dataItem.AllocationConsulation, dataItem.AllocationConsulationTarget).Value;
                dataItem.AddWechat = data.Where(e => e.IsAddWeChat && e.IsReturnBackPrice == false).Count();
                dataItem.AddWechatTarget = assistantTarget?.EffectiveAddWechatTarget ?? 0;
                dataItem.AddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(dataItem.AddWechat, dataItem.AddWechatTarget).Value;
                dataItem.BaseLiveAnchorId = liveanchor.Id;
                dataItem.IsEffective = true;
                dataItem.LiveAnchorName = liveanchor.LiveAnchorName;
                dataList.Add(dataItem);
            }
            foreach (var liveanchor in nameList)
            {
                var assistantTarget = await employeePerformanceTargetService.GetEmployeeTargetByBaseLiveAnchorIdAsync(query.StartDate.Value.Year, query.StartDate.Value.Month, liveanchor.Id);
                var data = await shoppingCartRegistrationService.GetPerformanceByBaseLiveAnchorIdAsync(selectDate.StartDate, selectDate.EndDate, true, liveanchor.Id);
                var liveanchorName = nameList.Where(e => e.Id == liveanchor.Id).Select(e => e.LiveAnchorName).FirstOrDefault();
                CompanyCustomerAcquisitionDataDto dataItem = new CompanyCustomerAcquisitionDataDto();
                dataItem.GroupName = $"{liveanchorName}组-潜在业绩";
                dataItem.OrderCard = data.Count();
                dataItem.OrderCardTarget = livingTarget?.Sum(e => e.ConsulationCardTarget) ?? 0;
                dataItem.OrderCardTargetComplete = DecimalExtension.CalculateTargetComplete(dataItem.OrderCard, dataItem.OrderCardTarget).Value;
                dataItem.RefundCard = data.Where(x => x.IsReturnBackPrice == true).Count();
                dataItem.OrderCardError = 0;
                dataItem.AllocationConsulationTarget = assistantTarget?.EffectiveConsulationCardTarget ?? 0;
                dataItem.AllocationConsulation = data.Count();
                dataItem.AllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(dataItem.AllocationConsulation, dataItem.AllocationConsulationTarget).Value;
                dataItem.AddWechat = data.Where(e => e.IsAddWeChat && e.IsReturnBackPrice == false).Count();
                dataItem.AddWechatTarget = assistantTarget?.EffectiveAddWechatTarget ?? 0;
                dataItem.AddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(dataItem.AddWechat, dataItem.AddWechatTarget).Value;
                dataItem.BaseLiveAnchorId = liveanchor.Id;
                dataItem.IsEffective = false;
                dataItem.LiveAnchorName = liveanchor.LiveAnchorName;
                dataList.Add(dataItem);
            }
            var groupTotalData = dataList.GroupBy(e => e.LiveAnchorName).Select(e => new CompanyCustomerAcquisitionDataDto
            {
                GroupName = $"{e.Key}组",
                OrderCard = e.Sum(e => e.OrderCard),
                OrderCardTarget = e.Sum(e => e.OrderCardTarget),
                OrderCardTargetComplete = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.OrderCard), e.Sum(e => e.OrderCardTarget)).Value,
                RefundCard = e.Sum(e => e.RefundCard),
                OrderCardError = e.Sum(e => e.OrderCardError),
                AllocationConsulation = e.Sum(e => e.AllocationConsulation),
                AllocationConsulationTarget = e.Sum(e => e.AllocationConsulationTarget),
                AllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.AllocationConsulation), e.Sum(e => e.AllocationConsulationTarget)).Value,
                AddWechat = e.Sum(e => e.AddWechat),
                AddWechatTarget = e.Sum(e => e.AddWechatTarget),
                AddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.AddWechat), e.Sum(e => e.AddWechatTarget)).Value
            }).ToList();
            dataList.AddRange(groupTotalData);
            CompanyCustomerAcquisitionDataDto totalData = new CompanyCustomerAcquisitionDataDto();
            totalData.GroupName = "总计";
            totalData.OrderCard = groupTotalData.Sum(e => e.OrderCard);
            totalData.OrderCardTarget = groupTotalData.Sum(e => e.OrderCardTarget);
            totalData.OrderCardTargetComplete = DecimalExtension.CalculateTargetComplete(groupTotalData.Sum(e => e.OrderCard), groupTotalData.Sum(e => e.OrderCardTarget)).Value;
            totalData.RefundCard = groupTotalData.Sum(e => e.RefundCard);
            totalData.OrderCardError = groupTotalData.Sum(e => e.OrderCardError);
            totalData.AllocationConsulation = groupTotalData.Sum(e => e.AllocationConsulation);
            totalData.AllocationConsulationTarget = groupTotalData.Sum(e => e.AllocationConsulationTarget);
            totalData.AllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(groupTotalData.Sum(e => e.AllocationConsulation), groupTotalData.Sum(e => e.AllocationConsulationTarget)).Value;
            totalData.AddWechat = groupTotalData.Sum(e => e.AddWechat);
            totalData.AddWechatTarget = groupTotalData.Sum(e => e.AddWechatTarget);
            totalData.AddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(groupTotalData.Sum(e => e.AddWechat), groupTotalData.Sum(e => e.AddWechatTarget)).Value;
            dataList.Add(totalData);
            return dataList;
        }
        /// <summary>
        /// 获取公司看板运营情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<CompanyOperationsDataDto>> GetCompanyOperationsDataAsync(QueryAmiyaCompanyOperationsDataDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate.Value, query.EndDate.Value);
            var nameList = await liveAnchorBaseInfoService.GetValidAsync(true);
            query.LiveAnchorIds = nameList.Select(e => e.Id).ToList();
            var targetList = await liveAnchorMonthlyTargetAfterLivingService.GetPerformanceTargetByBaseLiveAnchorIdAsync(selectDate.StartDate.Year, selectDate.EndDate.Month, query.LiveAnchorIds);
            List<CompanyOperationsDataDto> dataList = new List<CompanyOperationsDataDto>();

            foreach (var liveanchorId in query.LiveAnchorIds)
            {
                var liveanchorName = nameList.Where(e => e.Id == liveanchorId).Select(e => e.LiveAnchorName).FirstOrDefault();
                var baseOrderPerformance = await contentPlateFormOrderService.GetOrderSendAndDealDataByMonthAndBaseLiveAnchorIdAsync(selectDate.StartDate, selectDate.EndDate, query.IsOldCustomer.Value, liveanchorId);
                var target = targetList.Where(e => e.BaseLiveAbchorId == liveanchorId).FirstOrDefault();
                CompanyOperationsDataDto operationsData = new CompanyOperationsDataDto();
                operationsData.GroupName = $"{liveanchorName}组";
                operationsData.SendOrderTarget = target?.SendOrderTarget ?? 0;
                operationsData.SendOrder = baseOrderPerformance.SendOrderNum;
                operationsData.SendOrderTargetComplete = DecimalExtension.CalculateTargetComplete(operationsData.SendOrder, operationsData.SendOrderTarget).Value;
                operationsData.ToHospitalTarget = query.IsOldCustomer.Value ? target?.OldCustomerVisitTarget ?? 0 : target?.OldCustomerVisitTarget ?? 0;
                operationsData.ToHospital = baseOrderPerformance.VisitNum;
                operationsData.ToHospitalTargetComplete = DecimalExtension.CalculateTargetComplete(operationsData.ToHospital, operationsData.ToHospitalTarget).Value;
                operationsData.Deal = baseOrderPerformance.DealNum;
                operationsData.DealTarget = query.IsOldCustomer.Value ? target?.OldCustomerDealTarget ?? 0m : target?.NewCustomerDealTarget ?? 0m;
                operationsData.DealTargetComplete = DecimalExtension.CalculateTargetComplete(operationsData.Deal, operationsData.DealTarget).Value;
                dataList.Add(operationsData);
            }
            CompanyOperationsDataDto total = new CompanyOperationsDataDto();
            total.GroupName = "总计";
            total.SendOrderTarget = dataList.Sum(e => e.SendOrderTarget);
            total.SendOrder = dataList.Sum(e => e.SendOrder);
            total.SendOrderTargetComplete = DecimalExtension.CalculateTargetComplete(total.SendOrder, total.SendOrderTarget).Value;
            total.ToHospitalTarget = dataList.Sum(e => e.ToHospitalTarget);
            total.ToHospital = dataList.Sum(e => e.ToHospital);
            total.ToHospitalTargetComplete = DecimalExtension.CalculateTargetComplete(total.ToHospital, total.ToHospitalTarget).Value;
            total.Deal = dataList.Sum(e => e.Deal);
            total.DealTarget = dataList.Sum(e => e.DealTarget);
            total.DealTargetComplete = DecimalExtension.CalculateTargetComplete(total.Deal, total.DealTarget).Value;
            dataList.Add(total);
            return dataList;
        }
        /// <summary>
        /// 获取公司看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<CompanyIndicatorConversionDataDto>> GetCompanyIndicatorConversionDataAsync(QueryAmiyaCompanyOperationsDataDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate.Value, query.EndDate.Value);
            var nameList = await liveAnchorBaseInfoService.GetValidAsync(true);
            query.LiveAnchorIds = nameList.Select(e => e.Id).ToList();
            List<CompanyIndicatorConversionDataDto> dataList = new List<CompanyIndicatorConversionDataDto>();
            List<ShoppingCartRegistrationIndicatorBaseDataDto> effectiveBaseData = new List<ShoppingCartRegistrationIndicatorBaseDataDto>();
            List<ShoppingCartRegistrationIndicatorBaseDataDto> potentialBaseData = new List<ShoppingCartRegistrationIndicatorBaseDataDto>();
            foreach (var liveanchorId in query.LiveAnchorIds)
            {
                var liveanchorName = nameList.Where(e => e.Id == liveanchorId).Select(e => e.LiveAnchorName).FirstOrDefault();
                CompanyIndicatorConversionDataDto data = new CompanyIndicatorConversionDataDto();
                var effectiveData = await shoppingCartRegistrationService.GetIndicatorConversionDataAsync(selectDate.StartDate, selectDate.EndDate, liveanchorId, true);
                effectiveBaseData.Add(effectiveData);
                data.GroupName = $"{liveanchorName}组-有效业绩";
                data.SevenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(effectiveData.SevenDaySendOrderCount,effectiveData.TotalCount).Value;
                data.FifteenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(effectiveData.FifteenToHospitalCount,effectiveData.TotalCount).Value;
                data.OldCustomerToHospitalRate = DecimalExtension.CalculateTargetComplete(effectiveData.OldCustomerToHospitalCount,effectiveData.OldCustomerCount).Value;
                data.RePurchaseRate = DecimalExtension.CalculateTargetComplete(effectiveData.OldCustomerRepurchase,effectiveData.OldCustomerCount).Value;
                data.AddWechatRate = DecimalExtension.CalculateTargetComplete(effectiveData.AddWechatCount, effectiveData.TotalCount).Value;
                data.SendOrderRate = DecimalExtension.CalculateTargetComplete(effectiveData.SendOrderCount,effectiveData.TotalCount).Value;
                data.ToHospitalRate = DecimalExtension.CalculateTargetComplete(effectiveData.ToHospitalCount,effectiveData.TotalCount).Value;
                data.NewCustomerDealRate = DecimalExtension.CalculateTargetComplete(effectiveData.NewCustomerDealCount,effectiveData.NewCustomerCount).Value;
                data.NewCustomerUnitPrice = DecimalExtension.Division(effectiveData.NewCustomerTotalPerformance, effectiveData.NewCustomerCount).Value;
                data.OldCustomerUnitPrice = DecimalExtension.Division(effectiveData.OldCustomerTotalPerformance, effectiveData.OldCustomerCount).Value;
                dataList.Add(data);
            }
            CompanyIndicatorConversionDataDto totalEffectiveData = new CompanyIndicatorConversionDataDto();
            totalEffectiveData.GroupName = "有效业绩";
            totalEffectiveData.SevenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(effectiveBaseData.Sum(e => e.SevenDaySendOrderCount),effectiveBaseData.Sum(e => e.TotalCount)).Value;
            totalEffectiveData.FifteenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(effectiveBaseData.Sum(e => e.FifteenToHospitalCount),effectiveBaseData.Sum(e => e.TotalCount)).Value;
            totalEffectiveData.OldCustomerToHospitalRate = DecimalExtension.CalculateTargetComplete(effectiveBaseData.Sum(e => e.OldCustomerToHospitalCount),effectiveBaseData.Sum(e => e.OldCustomerCount)).Value;
            totalEffectiveData.RePurchaseRate = DecimalExtension.CalculateTargetComplete(effectiveBaseData.Sum(e => e.OldCustomerRepurchase),effectiveBaseData.Sum(e => e.OldCustomerCount)).Value;
            totalEffectiveData.AddWechatRate = DecimalExtension.CalculateTargetComplete(effectiveBaseData.Sum(e => e.AddWechatCount),effectiveBaseData.Sum(e => e.TotalCount)).Value;
            totalEffectiveData.SendOrderRate = DecimalExtension.CalculateTargetComplete(effectiveBaseData.Sum(e => e.SendOrderCount), effectiveBaseData.Sum(e => e.TotalCount)).Value;
            totalEffectiveData.ToHospitalRate = DecimalExtension.CalculateTargetComplete(effectiveBaseData.Sum(e => e.ToHospitalCount),effectiveBaseData.Sum(e => e.TotalCount)).Value;
            totalEffectiveData.NewCustomerDealRate = DecimalExtension.CalculateTargetComplete(effectiveBaseData.Sum(e => e.NewCustomerDealCount),effectiveBaseData.Sum(e => e.NewCustomerCount)).Value;
            totalEffectiveData.NewCustomerUnitPrice = DecimalExtension.Division(effectiveBaseData.Sum(e => e.NewCustomerTotalPerformance), effectiveBaseData.Sum(e => e.NewCustomerCount)).Value;
            totalEffectiveData.OldCustomerUnitPrice = DecimalExtension.Division(effectiveBaseData.Sum(e => e.OldCustomerTotalPerformance), effectiveBaseData.Sum(e => e.OldCustomerCount)).Value;
            dataList.Add(totalEffectiveData);
            foreach (var liveanchorId in query.LiveAnchorIds)
            {
                var liveanchorName = nameList.Where(e => e.Id == liveanchorId).Select(e => e.LiveAnchorName).FirstOrDefault();
                CompanyIndicatorConversionDataDto data = new CompanyIndicatorConversionDataDto();
                var potentialData = await shoppingCartRegistrationService.GetIndicatorConversionDataAsync(selectDate.StartDate, selectDate.EndDate, liveanchorId, false);
                potentialBaseData.Add(potentialData);
                data.GroupName = $"{liveanchorName}组-潜在业绩";
                data.SevenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(potentialData.SevenDaySendOrderCount, potentialData.TotalCount).Value;
                data.FifteenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(potentialData.FifteenToHospitalCount, potentialData.TotalCount).Value;
                data.OldCustomerToHospitalRate = DecimalExtension.CalculateTargetComplete(potentialData.OldCustomerToHospitalCount, potentialData.OldCustomerCount).Value;
                data.RePurchaseRate = DecimalExtension.CalculateTargetComplete(potentialData.OldCustomerRepurchase, potentialData.OldCustomerCount).Value;
                data.AddWechatRate = DecimalExtension.CalculateTargetComplete(potentialData.AddWechatCount, potentialData.TotalCount).Value;
                data.SendOrderRate = DecimalExtension.CalculateTargetComplete(potentialData.SendOrderCount, potentialData.TotalCount).Value;
                data.ToHospitalRate = DecimalExtension.CalculateTargetComplete(potentialData.ToHospitalCount, potentialData.TotalCount).Value;
                data.NewCustomerDealRate = DecimalExtension.CalculateTargetComplete(potentialData.NewCustomerDealCount, potentialData.NewCustomerCount).Value;
                data.NewCustomerUnitPrice = DecimalExtension.Division(potentialData.NewCustomerTotalPerformance, potentialData.NewCustomerCount).Value;
                data.OldCustomerUnitPrice = DecimalExtension.Division(potentialData.OldCustomerTotalPerformance, potentialData.OldCustomerCount).Value;
                dataList.Add(data);
            }
            CompanyIndicatorConversionDataDto totalPotentialData = new CompanyIndicatorConversionDataDto();
            totalPotentialData.GroupName = "潜在业绩";
            totalPotentialData.SevenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(potentialBaseData.Sum(e => e.SevenDaySendOrderCount), potentialBaseData.Sum(e => e.TotalCount)).Value;
            totalPotentialData.FifteenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(potentialBaseData.Sum(e => e.FifteenToHospitalCount), potentialBaseData.Sum(e => e.TotalCount)).Value;
            totalPotentialData.OldCustomerToHospitalRate = DecimalExtension.CalculateTargetComplete(potentialBaseData.Sum(e => e.OldCustomerToHospitalCount), potentialBaseData.Sum(e => e.OldCustomerCount)).Value;
            totalPotentialData.RePurchaseRate = DecimalExtension.CalculateTargetComplete(potentialBaseData.Sum(e => e.OldCustomerRepurchase), potentialBaseData.Sum(e => e.OldCustomerCount)).Value;
            totalPotentialData.AddWechatRate = DecimalExtension.CalculateTargetComplete(potentialBaseData.Sum(e => e.AddWechatCount), potentialBaseData.Sum(e => e.TotalCount)).Value;
            totalPotentialData.SendOrderRate = DecimalExtension.CalculateTargetComplete(potentialBaseData.Sum(e => e.SendOrderCount), potentialBaseData.Sum(e => e.TotalCount)).Value;
            totalPotentialData.ToHospitalRate = DecimalExtension.CalculateTargetComplete(potentialBaseData.Sum(e => e.ToHospitalCount), potentialBaseData.Sum(e => e.TotalCount)).Value;
            totalPotentialData.NewCustomerDealRate = DecimalExtension.CalculateTargetComplete(potentialBaseData.Sum(e => e.NewCustomerDealCount), potentialBaseData.Sum(e => e.NewCustomerCount)).Value;
            totalPotentialData.NewCustomerUnitPrice = DecimalExtension.Division(potentialBaseData.Sum(e => e.NewCustomerTotalPerformance), potentialBaseData.Sum(e => e.NewCustomerCount)).Value;
            totalPotentialData.OldCustomerUnitPrice = DecimalExtension.Division(potentialBaseData.Sum(e => e.OldCustomerTotalPerformance), potentialBaseData.Sum(e => e.OldCustomerCount)).Value;
            dataList.Add(totalPotentialData);
            var totalList = effectiveBaseData.Concat(potentialBaseData);
            CompanyIndicatorConversionDataDto totalData = new CompanyIndicatorConversionDataDto();
            totalData.GroupName = "总计";
            totalData.SevenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(totalList.Sum(e => e.SevenDaySendOrderCount), totalList.Sum(e => e.TotalCount)).Value;
            totalData.FifteenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(totalList.Sum(e => e.FifteenToHospitalCount), totalList.Sum(e => e.TotalCount)).Value;
            totalData.OldCustomerToHospitalRate = DecimalExtension.CalculateTargetComplete(totalList.Sum(e => e.OldCustomerToHospitalCount), totalList.Sum(e => e.OldCustomerCount)).Value;
            totalData.RePurchaseRate = DecimalExtension.CalculateTargetComplete(totalList.Sum(e => e.OldCustomerRepurchase), totalList.Sum(e => e.OldCustomerCount)).Value;
            totalData.AddWechatRate = DecimalExtension.CalculateTargetComplete(totalList.Sum(e => e.AddWechatCount), totalList.Sum(e => e.TotalCount)).Value;
            totalData.SendOrderRate = DecimalExtension.CalculateTargetComplete(totalList.Sum(e => e.SendOrderCount), totalList.Sum(e => e.TotalCount)).Value;
            totalData.ToHospitalRate = DecimalExtension.CalculateTargetComplete(totalList.Sum(e => e.ToHospitalCount), totalList.Sum(e => e.TotalCount)).Value;
            totalData.NewCustomerDealRate = DecimalExtension.CalculateTargetComplete(totalList.Sum(e => e.NewCustomerDealCount), totalList.Sum(e => e.NewCustomerCount)).Value;
            totalData.NewCustomerUnitPrice = DecimalExtension.Division(totalList.Sum(e => e.NewCustomerTotalPerformance), totalList.Sum(e => e.NewCustomerCount)).Value;
            totalData.OldCustomerUnitPrice = DecimalExtension.Division(totalList.Sum(e => e.OldCustomerTotalPerformance), totalList.Sum(e => e.OldCustomerCount)).Value;
            dataList.Add(totalData);
            return dataList;
        }
        #endregion

        #region 助理看板
        /// <summary>
        /// 获取助理看板业绩情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AssistantPerformanceDataDto>> GetAssistantPerformanceDataAsync(QueryAmiyaAssistantOperationsDataDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate.Value, query.EndDate.Value);
            var assistantNameList = await amiyaEmployeeService.GetByLiveAnchorBaseIdListAsync(query.LiveAnchorIds);
            var assistantTarget = await employeePerformanceTargetService.GetEmployeeTargetByAssistantIdListAsync(query.StartDate.Value.Year, query.StartDate.Value.Month, assistantNameList.Select(e => e.Id).ToList());
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAndAssistantIdListAsync(selectDate.StartDate, selectDate.EndDate, assistantNameList.Select(e => e.Id).ToList());
            var resList = order.GroupBy(e => e.BelongEmployeeId).Select(e =>
             {
                 var target = assistantTarget.Where(a => a.EmployeeId == e.Key).FirstOrDefault();
                 var name = assistantNameList.Where(a => a.Id == e.Key).FirstOrDefault()?.Name ?? "其他";
                 AssistantPerformanceDataDto data = new AssistantPerformanceDataDto();
                 data.AssistantName = name;
                 data.NewCustomerPerformanceTarget = target?.NewCustomerPerformanceTarget ?? 0;
                 data.CurrentMonthNewCustomerPerformance = e.Where(e => e.IsOldCustomer == false).Sum(e => e.Price);
                 data.NewCustomerPerformanceTargetComplete = DecimalExtension.CalculateTargetComplete(data.CurrentMonthNewCustomerPerformance, data.NewCustomerPerformanceTarget).Value;
                 data.OldCustomerTarget = target?.OldCustomerPerformanceTarget ?? 0;
                 data.CurrentMonthOldCustomerPerformance = e.Where(e => e.IsOldCustomer == true).Sum(e => e.Price);
                 data.OldCustomerTargetComplete = DecimalExtension.CalculateTargetComplete(data.CurrentMonthOldCustomerPerformance, data.OldCustomerTarget).Value;
                 data.TotalPerformanceTarget = data.NewCustomerPerformanceTarget + data.OldCustomerTarget;
                 data.TotalPerformance = data.CurrentMonthNewCustomerPerformance + data.CurrentMonthOldCustomerPerformance;
                 data.TotalPerformanceTargetComplete = DecimalExtension.CalculateTargetComplete(data.TotalPerformance, data.TotalPerformanceTarget).Value;
                 return data;
             }).ToList();
            AssistantPerformanceDataDto data = new AssistantPerformanceDataDto();
            data.AssistantName = "其他";
            data.NewCustomerPerformanceTarget = 0;
            data.CurrentMonthNewCustomerPerformance = resList.Where(e => e.AssistantName == "其他").Sum(e => e.CurrentMonthNewCustomerPerformance);
            data.NewCustomerPerformanceTargetComplete = 0;
            data.OldCustomerTarget = 0;
            data.CurrentMonthOldCustomerPerformance = resList.Where(e => e.AssistantName == "其他").Sum(e => e.CurrentMonthOldCustomerPerformance);
            data.OldCustomerTargetComplete = 0;
            data.TotalPerformanceTarget = 0;
            data.TotalPerformance = data.CurrentMonthNewCustomerPerformance + data.CurrentMonthOldCustomerPerformance;
            data.TotalPerformanceTargetComplete = 0;
            resList.RemoveAll(e => e.AssistantName == "其他");
            resList.Add(data);
            AssistantPerformanceDataDto total = new AssistantPerformanceDataDto();
            total.AssistantName = "总计";
            total.NewCustomerPerformanceTarget = resList.Sum(e => e.NewCustomerPerformanceTarget);
            total.CurrentMonthNewCustomerPerformance = resList.Sum(e => e.CurrentMonthNewCustomerPerformance);
            total.NewCustomerPerformanceTargetComplete = DecimalExtension.CalculateTargetComplete(total.CurrentMonthNewCustomerPerformance, total.NewCustomerPerformanceTarget).Value;
            total.OldCustomerTarget = resList.Sum(e => e.NewCustomerPerformanceTarget);
            total.CurrentMonthOldCustomerPerformance = resList.Sum(e => e.CurrentMonthOldCustomerPerformance);
            total.OldCustomerTargetComplete = DecimalExtension.CalculateTargetComplete(total.CurrentMonthOldCustomerPerformance, total.OldCustomerTarget).Value;
            total.TotalPerformanceTarget = total.CurrentMonthOldCustomerPerformance + total.NewCustomerPerformanceTarget;
            total.TotalPerformance = data.CurrentMonthNewCustomerPerformance + data.CurrentMonthOldCustomerPerformance;
            total.TotalPerformanceTargetComplete = DecimalExtension.CalculateTargetComplete(total.TotalPerformance, total.TotalPerformanceTarget).Value;
            resList.Add(total);
            return resList;
        }
        /// <summary>
        /// 获取助理看板获客情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AssistantCustomerAcquisitionDataDto>> GetAssistantCustomerAcquisitionDataAsync(QueryAmiyaAssistantOperationsDataDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate.Value, query.EndDate.Value);
            var assistantNameList = await amiyaEmployeeService.GetByLiveAnchorBaseIdListAsync(query.LiveAnchorIds);
            var assistantTarget = await employeePerformanceTargetService.GetEmployeeTargetByAssistantIdListAsync(query.StartDate.Value.Year, query.StartDate.Value.Month, assistantNameList.Select(e => e.Id).ToList());
            var data = await shoppingCartRegistrationService.GetPerformanceByAssistantIdListAsync(selectDate.StartDate, selectDate.EndDate, assistantNameList.Select(e => e.Id).ToList());
            var resList = data.GroupBy(e => e.AssignEmpId).Select(e =>
            {
                var target = assistantTarget.Where(a => a.EmployeeId == e.Key).FirstOrDefault();
                var name = assistantNameList.Where(a => a.Id == e.Key).FirstOrDefault()?.Name ?? "其他";
                AssistantCustomerAcquisitionDataDto data = new AssistantCustomerAcquisitionDataDto();
                data.AssistantName = name;
                data.PotentialAllocationConsulation = e.Where(e => e.Price <= 0).Count();
                data.PotentialAllocationConsulationTarget = target?.PotentialConsulationCardTarget ?? 0;
                data.PotentialAllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(data.PotentialAllocationConsulation, data.PotentialAllocationConsulationTarget).Value;
                data.PotentialAddWechat = e.Where(e => e.Price <= 0).Count();
                data.PotentialAddWechatTarget = target?.PotentialAddWechatTarget ?? 0;
                data.PotentialAddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(data.PotentialAddWechat, data.PotentialAddWechatTarget).Value;
                data.EffectiveAllocationConsulation = e.Where(e => e.Price > 0).Count();
                data.EffectiveAllocationConsulationTarget = target?.EffectiveConsulationCardTarget ?? 0;
                data.EffectiveAllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(data.EffectiveAllocationConsulation, data.EffectiveAllocationConsulationTarget).Value;
                data.EffectiveAddWechat = e.Where(e => e.Price > 0).Count();
                data.EffectiveAddWechatTarget = target?.EffectiveAddWechatTarget ?? 0;
                data.EffectiveAddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(data.EffectiveAddWechat, data.EffectiveAddWechatTarget).Value;
                return data;
            }).ToList();
            AssistantCustomerAcquisitionDataDto other = new AssistantCustomerAcquisitionDataDto();
            other.AssistantName = "其他";
            other.PotentialAllocationConsulation = resList.Where(e => e.AssistantName == "其他").Sum(e => e.PotentialAllocationConsulation);
            other.PotentialAllocationConsulationTarget = resList.Where(e => e.AssistantName == "其他").Sum(e => e.PotentialAllocationConsulation);
            other.PotentialAllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(other.PotentialAllocationConsulation, other.PotentialAllocationConsulationTarget).Value;
            other.PotentialAddWechat = resList.Where(e => e.AssistantName == "其他").Sum(e => e.PotentialAddWechat);
            other.PotentialAddWechatTarget = resList.Where(e => e.AssistantName == "其他").Sum(e => e.PotentialAddWechatTarget);
            other.PotentialAddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(other.PotentialAddWechat, other.PotentialAddWechatTarget).Value;
            other.EffectiveAllocationConsulation = resList.Where(e => e.AssistantName == "其他").Sum(e => e.EffectiveAllocationConsulation);
            other.EffectiveAllocationConsulationTarget = resList.Where(e => e.AssistantName == "其他").Sum(e => e.EffectiveAllocationConsulationTarget);
            other.EffectiveAllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(other.EffectiveAllocationConsulation, other.EffectiveAllocationConsulationTarget).Value;
            other.EffectiveAddWechat = resList.Where(e => e.AssistantName == "其他").Sum(e => e.EffectiveAddWechat);
            other.EffectiveAddWechatTarget = resList.Where(e => e.AssistantName == "其他").Sum(e => e.EffectiveAddWechatTarget);
            other.EffectiveAddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(other.EffectiveAddWechat, other.EffectiveAddWechatTarget).Value;
            resList.RemoveAll(e => e.AssistantName == "其他");
            resList.Add(other);
            AssistantCustomerAcquisitionDataDto total = new AssistantCustomerAcquisitionDataDto();
            total.AssistantName = "总计";
            total.PotentialAllocationConsulation = resList.Sum(e => e.PotentialAllocationConsulation);
            total.PotentialAllocationConsulationTarget = resList.Sum(e => e.PotentialAllocationConsulation);
            total.PotentialAllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(total.PotentialAllocationConsulation, total.PotentialAllocationConsulationTarget).Value;
            total.PotentialAddWechat = resList.Sum(e => e.PotentialAddWechat);
            total.PotentialAddWechatTarget = resList.Sum(e => e.PotentialAddWechatTarget);
            total.PotentialAddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(total.PotentialAddWechat, total.PotentialAddWechatTarget).Value;
            total.EffectiveAllocationConsulation = resList.Sum(e => e.EffectiveAllocationConsulation);
            total.EffectiveAllocationConsulationTarget = resList.Sum(e => e.EffectiveAllocationConsulationTarget);
            total.EffectiveAllocationConsulationTargetComplete = DecimalExtension.CalculateTargetComplete(total.EffectiveAllocationConsulation, total.EffectiveAllocationConsulationTarget).Value;
            total.EffectiveAddWechat = resList.Sum(e => e.EffectiveAddWechat);
            total.EffectiveAddWechatTarget = resList.Sum(e => e.EffectiveAddWechatTarget);
            total.EffectiveAddWechatTargetComplete = DecimalExtension.CalculateTargetComplete(total.EffectiveAddWechat, total.EffectiveAddWechatTarget).Value;
            resList.Add(total);
            return resList;
        }
        /// <summary>
        /// 获取助理看板运营情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AssistantOperationsDataDto>> GetAssistantOperationsDataAsync(QueryAmiyaAssistantOperationsDataDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate.Value, query.EndDate.Value);
            var assistantNameList = await amiyaEmployeeService.GetByLiveAnchorBaseIdListAsync(query.LiveAnchorIds);
            var assistantTarget = await employeePerformanceTargetService.GetEmployeeTargetByAssistantIdListAsync(query.StartDate.Value.Year, query.StartDate.Value.Month, assistantNameList.Select(e => e.Id).ToList());
            var baseOrderPerformance = await contentPlateFormOrderService.GetOrderSendAndDealDataByMonthAndBaseLiveAnchorIdAsync(selectDate.StartDate, selectDate.EndDate, query.IsOldCustomer.Value, assistantNameList.Select(e => e.Id).ToList());
            var resList = baseOrderPerformance.Select(e =>
            {
                var target = assistantTarget.Where(a => a.EmployeeId == e.BelongEmpId).FirstOrDefault();
                var name = assistantNameList.Where(a => a.Id == e.BelongEmpId).FirstOrDefault()?.Name ?? "其他";
                AssistantOperationsDataDto data = new AssistantOperationsDataDto();
                data.AssistantName = name;
                data.SendOrder = e.SendOrderNum;
                data.SendOrderTarget = target?.SendOrderTarget ?? 0;
                data.SendOrderTargetComplete = DecimalExtension.CalculateTargetComplete(data.SendOrder, data.SendOrderTarget).Value;
                data.ToHospital = e.VisitNum;
                data.ToHospitalTarget = query.IsOldCustomer.Value ? target?.OldCustomerVisitTarget ?? 0 : target?.NewCustomerVisitTarget ?? 0;
                data.ToHospitalTargetComplete = DecimalExtension.CalculateTargetComplete(data.ToHospital, data.ToHospitalTarget).Value;
                data.Deal = e.DealNum;
                data.DealTarget = query.IsOldCustomer.Value ? target?.OldCustomerDealNumTarget ?? 0 : target?.NewCustomerDealNumTarget ?? 0;
                data.DealTargetComplete = DecimalExtension.CalculateTargetComplete(data.Deal, data.DealTarget).Value;
                return data;
            }).ToList();
            AssistantOperationsDataDto other = new AssistantOperationsDataDto();
            other.AssistantName = "其他";
            other.SendOrder = resList.Where(e => e.AssistantName == "其他").Sum(e => e.SendOrder);
            other.SendOrderTarget = resList.Where(e => e.AssistantName == "其他").Sum(e => e.SendOrderTarget);
            other.SendOrderTargetComplete = DecimalExtension.CalculateTargetComplete(other.SendOrder, other.SendOrderTarget).Value;
            other.ToHospital = resList.Where(e => e.AssistantName == "其他").Sum(e => e.ToHospital);
            other.ToHospitalTarget = resList.Where(e => e.AssistantName == "其他").Sum(e => e.ToHospitalTarget);
            other.ToHospitalTargetComplete = DecimalExtension.CalculateTargetComplete(other.ToHospital, other.ToHospitalTarget).Value;
            other.Deal = resList.Where(e => e.AssistantName == "其他").Sum(e => e.Deal);
            other.DealTarget = resList.Where(e => e.AssistantName == "其他").Sum(e => e.DealTarget);
            other.DealTargetComplete = DecimalExtension.CalculateTargetComplete(other.Deal, other.DealTarget).Value;
            resList.RemoveAll(e => e.AssistantName == "其他");
            resList.Add(other);
            AssistantOperationsDataDto total = new AssistantOperationsDataDto();
            total.AssistantName = "其他";
            total.SendOrder = resList.Sum(e => e.SendOrder);
            total.SendOrderTarget = resList.Sum(e => e.SendOrderTarget);
            total.SendOrderTargetComplete = DecimalExtension.CalculateTargetComplete(other.SendOrder, other.SendOrderTarget).Value;
            total.ToHospital = resList.Sum(e => e.ToHospital);
            total.ToHospitalTarget = resList.Sum(e => e.ToHospitalTarget);
            total.ToHospitalTargetComplete = DecimalExtension.CalculateTargetComplete(other.ToHospital, other.ToHospitalTarget).Value;
            total.Deal = resList.Sum(e => e.Deal);
            total.DealTarget = resList.Sum(e => e.DealTarget);
            total.DealTargetComplete = DecimalExtension.CalculateTargetComplete(other.Deal, other.DealTarget).Value;
            resList.Add(total);
            return resList;
        }
        /// <summary>
        /// 获取助理看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AssistantIndicatorConversionDataDto>> GetAssistantIndicatorConversionDataAsync(QueryAmiyaAssistantOperationsDataDto query)
        {
            var selectDate = DateTimeExtension.GetStartDateEndDate(query.StartDate.Value, query.EndDate.Value);
            var assistantNameList = await amiyaEmployeeService.GetByLiveAnchorBaseIdListAsync(query.LiveAnchorIds);
            var baseData = await shoppingCartRegistrationService.GetIndicatorConversionDataByAssistantIdsAsync(selectDate.StartDate, selectDate.EndDate, assistantNameList.Select(e => e.Id).ToList(), query.IsOldCustomer);
            var resList = baseData.GroupBy(e => e.EmpId).Select(e =>
             {

                 var name = assistantNameList.Where(a => a.Id == e.Key).FirstOrDefault()?.Name ?? "其他";
                 AssistantIndicatorConversionDataDto data = new AssistantIndicatorConversionDataDto();
                 data.AssistantName = name;
                 data.SevenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TotalCount), e.Sum(e => e.SevenDaySendOrderCount)).Value;
                 data.FifteenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TotalCount), e.Sum(e => e.FifteenToHospitalCount)).Value;
                 data.OldCustomerToHospitalRate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.OldCustomerCount), e.Sum(e => e.OldCustomerToHospitalCount)).Value;
                 data.RePurchaseRate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TotalCount), e.Sum(e => e.OldCustomerRepurchase)).Value;
                 data.AddWechatRate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TotalCount), e.Sum(e => e.AddWechatCount)).Value;
                 data.SendOrderRate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TotalCount), e.Sum(e => e.SendOrderCount)).Value;
                 data.ToHospitalRate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.TotalCount), e.Sum(e => e.ToHospitalCount)).Value;
                 data.NewCustomerDealRate = DecimalExtension.CalculateTargetComplete(e.Sum(e => e.NewCustomerCount), e.Sum(e => e.NewCustomerDealCount)).Value;
                 data.NewCustomerUnitPrice = DecimalExtension.Division(e.Sum(e => e.NewCustomerTotalPerformance), e.Sum(e => e.NewCustomerCount)).Value;
                 data.OldCustomerUnitPrice = DecimalExtension.Division(e.Sum(e => e.OldCustomerTotalPerformance), e.Sum(e => e.OldCustomerCount)).Value;
                 return data;
             }).ToList();
            var otherList= baseData.Where(e => !assistantNameList.Select(e => e.Id).Contains(e.EmpId));
            AssistantIndicatorConversionDataDto other = new AssistantIndicatorConversionDataDto();
            other.AssistantName = "其他";
            other.SevenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(otherList.Sum(e => e.TotalCount), otherList.Sum(e => e.SevenDaySendOrderCount)).Value;
            other.FifteenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(otherList.Sum(e => e.TotalCount), otherList.Sum(e => e.FifteenToHospitalCount)).Value;
            other.OldCustomerToHospitalRate = DecimalExtension.CalculateTargetComplete(otherList.Sum(e => e.OldCustomerCount), otherList.Sum(e => e.OldCustomerToHospitalCount)).Value;
            other.RePurchaseRate = DecimalExtension.CalculateTargetComplete(otherList.Sum(e => e.TotalCount), otherList.Sum(e => e.OldCustomerRepurchase)).Value;
            other.AddWechatRate = DecimalExtension.CalculateTargetComplete(otherList.Sum(e => e.TotalCount), otherList.Sum(e => e.AddWechatCount)).Value;
            other.SendOrderRate = DecimalExtension.CalculateTargetComplete(otherList.Sum(e => e.TotalCount), otherList.Sum(e => e.SendOrderCount)).Value;
            other.ToHospitalRate = DecimalExtension.CalculateTargetComplete(otherList.Sum(e => e.TotalCount), otherList.Sum(e => e.ToHospitalCount)).Value;
            other.NewCustomerDealRate = DecimalExtension.CalculateTargetComplete(otherList.Sum(e => e.NewCustomerCount), otherList.Sum(e => e.NewCustomerDealCount)).Value;
            other.NewCustomerUnitPrice = DecimalExtension.Division(otherList.Sum(e => e.NewCustomerTotalPerformance), otherList.Sum(e => e.NewCustomerCount)).Value;
            other.OldCustomerUnitPrice = DecimalExtension.Division(otherList.Sum(e => e.OldCustomerTotalPerformance), otherList.Sum(e => e.OldCustomerCount)).Value;
            resList.Add(other);
            AssistantIndicatorConversionDataDto total = new AssistantIndicatorConversionDataDto();
            total.AssistantName = "总计";
            total.SevenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(baseData.Sum(e => e.TotalCount), baseData.Sum(e => e.SevenDaySendOrderCount)).Value;
            total.FifteenDaySendOrderRate = DecimalExtension.CalculateTargetComplete(baseData.Sum(e => e.TotalCount), baseData.Sum(e => e.FifteenToHospitalCount)).Value;
            total.OldCustomerToHospitalRate = DecimalExtension.CalculateTargetComplete(baseData.Sum(e => e.OldCustomerCount), baseData.Sum(e => e.OldCustomerToHospitalCount)).Value;
            total.RePurchaseRate = DecimalExtension.CalculateTargetComplete(baseData.Sum(e => e.TotalCount), baseData.Sum(e => e.OldCustomerRepurchase)).Value;
            total.AddWechatRate = DecimalExtension.CalculateTargetComplete(baseData.Sum(e => e.TotalCount), baseData.Sum(e => e.AddWechatCount)).Value;
            total.SendOrderRate = DecimalExtension.CalculateTargetComplete(baseData.Sum(e => e.TotalCount), baseData.Sum(e => e.SendOrderCount)).Value;
            total.ToHospitalRate = DecimalExtension.CalculateTargetComplete(baseData.Sum(e => e.TotalCount), baseData.Sum(e => e.ToHospitalCount)).Value;
            total.NewCustomerDealRate = DecimalExtension.CalculateTargetComplete(baseData.Sum(e => e.NewCustomerCount), baseData.Sum(e => e.NewCustomerDealCount)).Value;
            total.NewCustomerUnitPrice = DecimalExtension.Division(baseData.Sum(e => e.NewCustomerTotalPerformance), baseData.Sum(e => e.NewCustomerCount)).Value;
            total.OldCustomerUnitPrice = DecimalExtension.Division(baseData.Sum(e => e.OldCustomerTotalPerformance), baseData.Sum(e => e.OldCustomerCount)).Value;
            resList.Add(total);
            return resList;
        }
        #endregion

    }
}
