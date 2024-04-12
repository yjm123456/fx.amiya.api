using Fx.Amiya.Dto.AmiyaOperationsBoardService;
using Fx.Amiya.Dto.Performance;
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
    public class AmiyaOperationsBoardServiceService : IAmiyaOperationsBoardServiceService
    {
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ILiveAnchorService liveAnchorService;
        private readonly IShoppingCartRegistrationService shoppingCartRegistrationService;
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;
        private readonly IAmiyaEmployeeService amiyaEmployeeService;
        private readonly IEmployeePerformanceTargetService employeePerformanceTargetService;
        private readonly IContentPlatformOrderSendService contentPlatformOrderSendService;

        public AmiyaOperationsBoardServiceService(
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            ILiveAnchorService liveAnchorService,
            IContentPlateFormOrderService contentPlateFormOrderService,
            IEmployeePerformanceTargetService employeePerformanceTargetService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IContentPlatformOrderSendService contentPlatformOrderSendService,
            ShoppingCartRegistrationService shoppingCartRegistrationService)
        {
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.liveAnchorService = liveAnchorService;
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.employeePerformanceTargetService = employeePerformanceTargetService;
            this.contentPlatformOrderSendService = contentPlatformOrderSendService;
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

            #region 【助理业绩】
            var dealInfo = await contentPlateFormOrderService.GetFourCustomerServicePerformanceByCustomerServiceIdAsync(query.startDate.Value, query.endDate.Value, amiyaEmployeeIds);
            List<GetEmployeePerformanceDataDto> employeeDataList = new List<GetEmployeePerformanceDataDto>();
            foreach (var x in dealInfo)
            {
                GetEmployeePerformanceDataDto getEmployeePerformanceDataDto = new GetEmployeePerformanceDataDto();
                getEmployeePerformanceDataDto.EmployeeName = x.CustomerServiceName;
                getEmployeePerformanceDataDto.Performance = x.TotalServicePrice;
                var employeeDataTarget = await employeePerformanceTargetService.GetByEmpIdAndYearMonthAsync(x.CustomerServiceId, query.endDate.Value.Year, query.endDate.Value.Month);
                getEmployeePerformanceDataDto.CompleteRate = Math.Round(x.TotalServicePrice / employeeDataTarget * 100, 2, MidpointRounding.AwayFromZero);
                employeeDataList.Add(getEmployeePerformanceDataDto);
            }
            result.EmployeeDatas = employeeDataList;
            #endregion

            #region 【助理获客情况】
            var shoppingCartRegistionData = await shoppingCartRegistrationService.GetNewBaseBusinessPerformanceByLiveAnchorNameAsync(query.startDate.Value, query.endDate.Value, null, "");

            result.EmployeeDistributeConsulationNumAndAddWechats = shoppingCartRegistionData.Where(x => x.AssignEmpId.HasValue).GroupBy(x => x.AssignEmpId).Select(x => new GetEmployeeDistributeConsulationNumAndAddWechatDto
            {
                EmployeeId = Convert.ToInt32(x.Key.ToString()),
                DistributeConsulationNum = x.Count(),
                AddWechatNum = x.Where(e => e.IsAddWeChat == true).Count(),
            }).Take(10).ToList();
            foreach (var x in result.EmployeeDistributeConsulationNumAndAddWechats)
            {
                var empInfo = await amiyaEmployeeService.GetByIdAsync(x.EmployeeId);
                x.EmployeeName = empInfo.Name;
            }
            #endregion

            #region 【助理客户运营情况】
            List<GetEmployeeCustomerAnalizeDto> getEmployeeCustomerAnalizeDtos = new List<GetEmployeeCustomerAnalizeDto>();
            foreach (var x in amiyaEmployeeIds)
            {
                GetEmployeeCustomerAnalizeDto getEmployeeCustomerAnalizeDto = new GetEmployeeCustomerAnalizeDto();
                var empInfo = await amiyaEmployeeService.GetByIdAsync(x);
                getEmployeeCustomerAnalizeDto.EmployeeName = empInfo.Name;
                getEmployeeCustomerAnalizeDto.SendOrderNum = await contentPlatformOrderSendService.GetTotalSendCountByEmployeeAsync(x);
                var contentPlatFormVisitAndDealNumData = await contentPlateFormOrderService.GetCustomerVisitAndIsDealByEmployeeIdAsync(query.startDate.Value, query.endDate.Value, x);
                getEmployeeCustomerAnalizeDto.VisitNum = contentPlatFormVisitAndDealNumData.VisitNum;
                getEmployeeCustomerAnalizeDto.DealNum = contentPlatFormVisitAndDealNumData.DealNum;
                getEmployeeCustomerAnalizeDtos.Add(getEmployeeCustomerAnalizeDto);
            }
            result.GetEmployeeCustomerAnalizes = getEmployeeCustomerAnalizeDtos.OrderByDescending(x => x.SendOrderNum).Take(10).ToList();
            #endregion

            #region 【业绩贡献占比】
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
            List<CompanyPerformanceDataDto> result = new List<CompanyPerformanceDataDto>();
            return result;
        }
        /// <summary>
        /// 获取公司看板获客情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<CompanyCustomerAcquisitionDataDto>> GetCompanyCustomerAcquisitionDataAsync(QueryAmiyaCompanyOperationsDataDto query)
        {
            List<CompanyCustomerAcquisitionDataDto> result = new List<CompanyCustomerAcquisitionDataDto>();
            return result;
        }
        /// <summary>
        /// 获取公司看板运营情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<CompanyOperationsDataDto>> GetCompanyOperationsDataAsync(QueryAmiyaCompanyOperationsDataDto query)
        {
            List<CompanyOperationsDataDto> result = new List<CompanyOperationsDataDto>();
            return result;
        }
        /// <summary>
        /// 获取公司看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<CompanyIndicatorConversionDataDto>> GetCompanyIndicatorConversionDataAsync(QueryAmiyaCompanyOperationsDataDto query)
        {
            List<CompanyIndicatorConversionDataDto> result = new List<CompanyIndicatorConversionDataDto>();
            return result;
        }
        #endregion

        #region 助理看板
        /// <summary>
        /// 获取助理看板业绩情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AssistantPerformanceDataDto>> GetAssistantPerformanceDataAsync(QueryAmiyaAssistantOperationsDataDto query)
        {
            List<AssistantPerformanceDataDto> result = new List<AssistantPerformanceDataDto>();
            return result;
        }
        /// <summary>
        /// 获取助理看板获客情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AssistantCustomerAcquisitionDataDto>> GetAssistantCustomerAcquisitionDataAsync(QueryAmiyaAssistantOperationsDataDto query)
        {
            List<AssistantCustomerAcquisitionDataDto> result = new List<AssistantCustomerAcquisitionDataDto>();
            return result;
        }
        /// <summary>
        /// 获取助理看板运营情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AssistantOperationsDataDto>> GetAssistantOperationsDataAsync(QueryAmiyaAssistantOperationsDataDto query)
        {
            List<AssistantOperationsDataDto> result = new List<AssistantOperationsDataDto>();
            return result;
        }
        /// <summary>
        /// 获取助理看板指标转化情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<AssistantIndicatorConversionDataDto>> GetAssistantIndicatorConversionDataAsync(QueryAmiyaAssistantOperationsDataDto query)
        {
            List<AssistantIndicatorConversionDataDto> result = new List<AssistantIndicatorConversionDataDto>();
            return result;
        }
        #endregion

    }
}
