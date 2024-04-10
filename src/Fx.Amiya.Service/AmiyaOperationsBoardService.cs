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
        private readonly ILiveAnchorMonthlyTargetBeforeLivingService liveAnchorMonthlyTargetBeforeLivingService;
        private readonly ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService;
        private readonly IDalBeforeLivingTikTokDailyTarget dalBeforeLivingTikTokDailyTarget;
        private readonly IDalBeforeLivingVideoDailyTarget dalBeforeLivingVideoDailyTarget;
        private readonly IDalBeforeLivingXiaoHongShuDailyTarget dalBeforeLivingXiaoHongShuDailyTarget;
        private readonly IDalLivingDailyTarget dalLivingDailyTarget;
        private readonly ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService;
        private readonly ILiveAnchorService liveAnchorService;

        public AmiyaOperationsBoardServiceService(ILiveAnchorMonthlyTargetBeforeLivingService liveAnchorMonthlyTargetBeforeLivingService, IDalBeforeLivingTikTokDailyTarget dalBeforeLivingTikTokDailyTarget, IDalBeforeLivingVideoDailyTarget dalBeforeLivingVideoDailyTarget, IDalBeforeLivingXiaoHongShuDailyTarget dalBeforeLivingXiaoHongShuDailyTarget, ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService, IDalLivingDailyTarget dalLivingDailyTarget, ILiveAnchorBaseInfoService liveAnchorBaseInfoService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService, ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService, ILiveAnchorService liveAnchorService)
        {
            this.liveAnchorMonthlyTargetBeforeLivingService = liveAnchorMonthlyTargetBeforeLivingService;
            this.dalBeforeLivingTikTokDailyTarget = dalBeforeLivingTikTokDailyTarget;
            this.dalBeforeLivingVideoDailyTarget = dalBeforeLivingVideoDailyTarget;
            this.dalBeforeLivingXiaoHongShuDailyTarget = dalBeforeLivingXiaoHongShuDailyTarget;
            this.liveAnchorMonthlyTargetLivingService = liveAnchorMonthlyTargetLivingService;
            this.dalLivingDailyTarget = dalLivingDailyTarget;
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.liveAnchorMonthlyTargetAfterLivingService = liveAnchorMonthlyTargetAfterLivingService;
            this.liveAnchorService = liveAnchorService;
        }
        #region  运营主看板
        /// <summary>
        /// 获取时间进度和总业绩
        /// </summary>
        /// <returns></returns>
        public async Task<OperationTotalAchievementDataDto> GetTotalAchievementAndDateScheduleAsync(QueryOperationDataDto query)
        {
            OperationTotalAchievementDataDto result = new OperationTotalAchievementDataDto();
            return result;
        }

        /// <summary>
        /// 获取获客情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<GetCustomerDataDto> GetCustomerDataAsync(QueryOperationDataDto query)
        {
            GetCustomerDataDto result = new GetCustomerDataDto();
            return result;
        }

        /// <summary>
        /// 获取客户运营情况数据
        /// </summary>
        /// <returns></returns>
        public async Task<GetCustomerAnalizeDataDto> GetCustomerAnalizeDataAsync(QueryOperationDataDto query)
        {
            GetCustomerAnalizeDataDto result = new GetCustomerAnalizeDataDto();
            return result;
        }

        /// <summary>
        /// 获取客户指标转化数据
        /// </summary>
        /// <returns></returns>
        public async Task<GetCustomerIndexTransformationResultDto> GetCustomerIndexTransformationDataAsync(QueryOperationDataDto query)
        {
            GetCustomerIndexTransformationResultDto result = new GetCustomerIndexTransformationResultDto();
            return result;
        }

        /// <summary>
        /// 获取助理业绩分析数据
        /// </summary>
        /// <returns></returns>
        public async Task<GetEmployeePerformanceAnalizeDataDto> GetEmployeePerformanceAnalizeDataAsync(QueryOperationDataDto query)
        {
            GetEmployeePerformanceAnalizeDataDto result = new GetEmployeePerformanceAnalizeDataDto();

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
