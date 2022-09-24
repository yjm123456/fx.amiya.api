using Fx.Amiya.Dto.HospitalPerformance;
using Fx.Amiya.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HospitalPerformanceService : IHospitalPerformanceService
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private IContentPlateFormOrderService contentPlateFormOrderService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ISendOrderInfoService sendOrderInfoService;
        public HospitalPerformanceService(IContentPlateFormOrderService contentPlateFormOrderService, IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService, ISendOrderInfoService sendOrderInfoService)
        {
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.sendOrderInfoService = sendOrderInfoService;
        }

        /// <summary>
        /// 获取全国机构日运营数据概况
        /// </summary>
        /// <returns></returns>
        public async Task<List<HospitalPerformanceDto>> GetHospitalDailyPerformanceAsync()
        {
            List<HospitalPerformanceDto> resultList = new List<HospitalPerformanceDto>();
            return resultList;
        }

        #region 累计运营数据


        #region 合作机构top10运营数据
        public async Task<HospitalAccumulatePerformanceDto> GetTopTenHospitalPerfromance()
        {
            HospitalAccumulatePerformanceDto performanceDto = new HospitalAccumulatePerformanceDto();
            #region 总业绩
            var totalPerformanceList =await contentPlatFormOrderDealInfoService.GetTopTenHospitalTotalPerformance();
            var totalPerformance =await contentPlatFormOrderDealInfoService.GetPerformance(null);

            HospitalPerformanceItem hospitalPerformanceItem = new HospitalPerformanceItem {
                TotalPerformmance = totalPerformance,
                PerformanceList = totalPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.TotalPerformnaceRatio = hospitalPerformanceItem;
            performanceDto.TotalPerformnaceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = totalPerformance - performanceDto.TotalPerformnaceRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion

            #region 新客业绩
            var newCustomerPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenNewCustomerPerformance();
            var newCustomerPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(false);

            HospitalPerformanceItem newCustomerPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = newCustomerPerformance,
                PerformanceList = newCustomerPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.NewCustomerPerformanceRatio = newCustomerPerformanceItem;
            performanceDto.NewCustomerPerformanceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = newCustomerPerformance - performanceDto.NewCustomerPerformanceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 老客业绩
            var oldCustomerPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenOldCustomerPerformance();
            var oldCustomerPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(true);


            HospitalPerformanceItem oldCustomerPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = oldCustomerPerformance,
                PerformanceList = oldCustomerPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.OldCustomerPerformanceRatio=oldCustomerPerformanceItem;
            performanceDto.OldCustomerPerformanceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = oldCustomerPerformance - performanceDto.OldCustomerPerformanceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 派单量
            var sendOrderPerformanceList = await sendOrderInfoService.GetTopTenHospitalSendOrderPerformance();
            var sendOrderPerformance = await sendOrderInfoService.GetTotalSendCount();


            HospitalPerformanceItem sendOrderPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = sendOrderPerformance,
                PerformanceList = sendOrderPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.SendOrderPerformanceRatio = sendOrderPerformanceItem;
            performanceDto.SendOrderPerformanceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = sendOrderPerformance - performanceDto.SendOrderPerformanceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 新客上门人数
            var newCustomerToHospitalPerformanceList= await contentPlatFormOrderDealInfoService.GetTopTenNewCustomerToHospitalPformance();
            var newCustomerToHospitalPerformance = await contentPlatFormOrderDealInfoService.GetNewCustomerToHospitalCount();


            HospitalPerformanceItem newCustomerToHospitalPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = newCustomerToHospitalPerformance,
                PerformanceList = newCustomerToHospitalPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.NewCustomerToHospitalPerformanceRatio=newCustomerToHospitalPerformanceItem;
            performanceDto.NewCustomerToHospitalPerformanceRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = newCustomerToHospitalPerformance - performanceDto.NewCustomerToHospitalPerformanceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 新客成交人数
            var newCustomerDealPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenNewCustomerDealPerformance();
            var newCustomerDealPerformance = await contentPlatFormOrderDealInfoService.GetNewCustomerDealCount();


            HospitalPerformanceItem newCustomerDealPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = newCustomerDealPerformance,
                PerformanceList = newCustomerDealPerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            performanceDto.NewCustomerDealCountRatio = newCustomerDealPerformanceItem;
            performanceDto.NewCustomerDealCountRatio.PerformanceList.Add(new HospitalPerformanceListItem { HospitalName = "其他", Performance = newCustomerDealPerformance - performanceDto.NewCustomerDealCountRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            return performanceDto;
        }


        #endregion

        #region 合作城市top10运营数据

        /// <summary>
        /// 获取合作城市top10运营数据占比
        /// </summary>
        /// <returns></returns>
        public async Task<CityAccumulatePerformanceDto> GetTopTenCityPerformance()
        {
            CityAccumulatePerformanceDto cityAccumulatePerformance = new CityAccumulatePerformanceDto();
            #region 总业绩

            var totalPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityTotalPerformance();
            var totalPerformance= await contentPlatFormOrderDealInfoService.GetPerformance(null);
            CityPerformanceItem totalPerformanceItem = new CityPerformanceItem {
                TotalPerformmance=totalPerformance,
                PerformanceList= totalPerformanceList.Select(c=>new CityPerformanceListItem { 
                    Performance=c.Performance,
                    CityName=c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.TotalPerformnaceRatio = totalPerformanceItem;
            cityAccumulatePerformance.TotalPerformnaceRatio.PerformanceList.Add(new CityPerformanceListItem {  CityName= "其他", Performance = totalPerformance - cityAccumulatePerformance.TotalPerformnaceRatio.PerformanceList.Sum(c => c.Performance) });
            #endregion

            #region 新客业绩

            var newCustomerPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityNewCustomerPerformance();
            var newCustomerPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(false);
            CityPerformanceItem newCustomerPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = newCustomerPerformance,
                PerformanceList = newCustomerPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.NewCustomerPerformanceRatio = newCustomerPerformanceItem;
            cityAccumulatePerformance.NewCustomerPerformanceRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = newCustomerPerformance - cityAccumulatePerformance.NewCustomerPerformanceRatio.PerformanceList.Sum(c => c.Performance) });


            #endregion

            #region 老客业绩

            var oldCustomerPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityOldCustomerPerformance();
            var oldCustomerPerformance = await contentPlatFormOrderDealInfoService.GetPerformance(true);
            CityPerformanceItem oldCustomerPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = oldCustomerPerformance,
                PerformanceList = oldCustomerPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.OldCustomerPerformanceRatio = oldCustomerPerformanceItem;
            cityAccumulatePerformance.OldCustomerPerformanceRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = oldCustomerPerformance - cityAccumulatePerformance.OldCustomerPerformanceRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion

            #region 派单占比

            var sendOrderPerformanceList = await sendOrderInfoService.GetTopTenCitySendOrderPerformance();
            var sendOrderPerformance = await sendOrderInfoService.GetTotalSendCount();
            CityPerformanceItem sendOrderPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = sendOrderPerformance,
                PerformanceList = sendOrderPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.SendOrderPerformanceRatio = sendOrderPerformanceItem;
            cityAccumulatePerformance.SendOrderPerformanceRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = sendOrderPerformance - cityAccumulatePerformance.SendOrderPerformanceRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion

            #region 新客上门人数占比

            var newCustomerToHospitalPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityNewCustomerToHospitalPformance();
            var newCustomerToHospitalPerformance = await contentPlatFormOrderDealInfoService.GetNewCustomerToHospitalCount();
            CityPerformanceItem newCustomerToHospitalPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = newCustomerToHospitalPerformance,
                PerformanceList = newCustomerToHospitalPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.NewCustomerToHospitalPerformanceRatio = newCustomerToHospitalPerformanceItem;
            cityAccumulatePerformance.NewCustomerToHospitalPerformanceRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = newCustomerToHospitalPerformance - cityAccumulatePerformance.NewCustomerToHospitalPerformanceRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion

            #region 新客成交人数

            var newCustomerDealPerformanceList = await contentPlatFormOrderDealInfoService.GetTopTenCityNewCustomerDealPerformance();
            var newCustomerDealPerformancePerformance = await contentPlatFormOrderDealInfoService.GetNewCustomerDealCount();
            CityPerformanceItem newCustomerDealPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = newCustomerDealPerformancePerformance,
                PerformanceList = newCustomerDealPerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };
            cityAccumulatePerformance.NewCustomerDealCountRatio = newCustomerDealPerformanceItem;
            cityAccumulatePerformance.NewCustomerDealCountRatio.PerformanceList.Add(new CityPerformanceListItem { CityName = "其他", Performance = newCustomerDealPerformancePerformance - cityAccumulatePerformance.NewCustomerDealCountRatio.PerformanceList.Sum(c => c.Performance) });

            #endregion
            return cityAccumulatePerformance;
        }
        #endregion


        #endregion

        #region【公共使用业务，包括折线图，业绩明细等】


        #endregion

        #region  【内部方法】


        #endregion
    }
}