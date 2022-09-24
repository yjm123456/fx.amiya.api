using Fx.Amiya.Background.Api.Vo.HospitalPerformance;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Fx.Amiya.Background.Api.Controllers
{

    /// <summary>
    /// 机构业绩接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class HospitalAchievementController : ControllerBase
    {
        private IHospitalPerformanceService hospitalPerformanceService;
        public HospitalAchievementController(IHospitalPerformanceService hospitalPerformanceService)
        {
            this.hospitalPerformanceService = hospitalPerformanceService;
        }


        #region 【全国机构运营总览】

        /// <summary>
        /// 全国机构运营当日数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getHospitalOperationDairyData")]
        public async Task<ResultData<List<HospitalOperatingDataVo>>> GetHospitalOperationDairyData()
        {
            List<HospitalOperatingDataVo> hospitalPerformanceVo = new List<HospitalOperatingDataVo>();
            var hospitalPerformanceDatas = await hospitalPerformanceService.GetHospitalDailyPerformanceAsync();
            //(todo;)
            return ResultData<List<HospitalOperatingDataVo>>.Success().AddData("performance", hospitalPerformanceVo);
        }
        /// <summary>
        /// 全国合作机构top10运营数据占比
        /// </summary>
        /// <returns></returns>
        [HttpGet("topTenHospitalPerformanceData")]
        public async Task<ResultData<TopTenHospitalPerformanceVo>> GetTopTenHospitalPerformanceData() {
            TopTenHospitalPerformanceVo topTenHospitalPerformance = new TopTenHospitalPerformanceVo();
            var performance = await hospitalPerformanceService.GetTopTenHospitalPerfromance();
            #region 总业绩


            HospitalPerformanceItem hospitalPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = performance.TotalPerformnaceRatio.TotalPerformmance,
                PerformanceList = performance.TotalPerformnaceRatio.PerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            topTenHospitalPerformance.TotalPerformnaceRatio = hospitalPerformanceItem;
            #endregion



            #region 新客业绩


            HospitalPerformanceItem newCustomerPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = performance.NewCustomerPerformanceRatio.TotalPerformmance,
                PerformanceList = performance.NewCustomerPerformanceRatio.PerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };

            topTenHospitalPerformance.NewCustomerPerformanceRatio=newCustomerPerformanceItem;

            #endregion



            #region 老客业绩

            HospitalPerformanceItem oldCustomerPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = performance.OldCustomerPerformanceRatio.TotalPerformmance,
                PerformanceList = performance.OldCustomerPerformanceRatio.PerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };

            topTenHospitalPerformance.OldCustomerPerformanceRatio = oldCustomerPerformanceItem;

            #endregion



            #region 派单占比

            HospitalPerformanceItem sendOrderPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance = performance.SendOrderPerformanceRatio.TotalPerformmance,
                PerformanceList = performance.SendOrderPerformanceRatio.PerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };

            topTenHospitalPerformance.SendOrderPerformanceRatio = sendOrderPerformanceItem;

            #endregion



            #region 新客上门


            HospitalPerformanceItem newCustomerToHospitalPerformanceItem = new HospitalPerformanceItem
            {
                TotalPerformmance =performance.NewCustomerToHospitalPerformanceRatio.TotalPerformmance,
                PerformanceList = performance.NewCustomerToHospitalPerformanceRatio.PerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };
            topTenHospitalPerformance.NewCustomerToHospitalPerformanceRatio = newCustomerToHospitalPerformanceItem;

            #endregion



            #region 新客成交

            HospitalPerformanceItem newCustomerDealCountItem = new HospitalPerformanceItem
            {
                TotalPerformmance = performance.NewCustomerDealCountRatio.TotalPerformmance,
                PerformanceList = performance.NewCustomerDealCountRatio.PerformanceList.Select(c => new HospitalPerformanceListItem
                {
                    Performance = c.Performance,
                    HospitalName = c.HospitalName
                }).ToList()
            };

            topTenHospitalPerformance.NewCustomerDealCountRatio = newCustomerDealCountItem;

            #endregion

            return ResultData<TopTenHospitalPerformanceVo>.Success().AddData("hospitalPerformanceData", topTenHospitalPerformance);

        }
        #endregion

        /// <summary>
        /// 全国城市top10运营数据占比
        /// </summary>
        /// <returns></returns>
        [HttpGet("topTenCityPerformanceData")]
        public async Task<ResultData<TopTenCityPerformanceVo>> GetTopTenCityPerformanceData() {

            TopTenCityPerformanceVo topTenCityPerformanceVo = new TopTenCityPerformanceVo();
            var performance = await hospitalPerformanceService.GetTopTenCityPerformance();
            #region 总业绩

            CityPerformanceItem totalPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = performance.TotalPerformnaceRatio.TotalPerformmance,
                PerformanceList = performance.TotalPerformnaceRatio.PerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };

            topTenCityPerformanceVo.TotalPerformnaceRatio = totalPerformanceItem;

            #endregion

            #region 新客业绩

            CityPerformanceItem newCustomerPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = performance.NewCustomerPerformanceRatio.TotalPerformmance,
                PerformanceList = performance.NewCustomerPerformanceRatio.PerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };

            topTenCityPerformanceVo.NewCustomerPerformanceRatio = newCustomerPerformanceItem;
;

            #endregion

            #region 老客业绩

            CityPerformanceItem oldCustomerPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = performance.OldCustomerPerformanceRatio.TotalPerformmance,
                PerformanceList = performance.OldCustomerPerformanceRatio.PerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };

            topTenCityPerformanceVo.OldCustomerPerformanceRatio = oldCustomerPerformanceItem;

            #endregion

            #region 派单量

            CityPerformanceItem sendOrderPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = performance.SendOrderPerformanceRatio.TotalPerformmance,
                PerformanceList = performance.SendOrderPerformanceRatio.PerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };

            topTenCityPerformanceVo.SendOrderPerformanceRatio = sendOrderPerformanceItem;

            #endregion

            #region 新客上门

            CityPerformanceItem newCustomerToHospitalPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = performance.NewCustomerToHospitalPerformanceRatio.TotalPerformmance,
                PerformanceList = performance.NewCustomerToHospitalPerformanceRatio.PerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };

            topTenCityPerformanceVo.NewCustomerToHospitalPerformanceRatio = newCustomerToHospitalPerformanceItem;

            #endregion

            #region 新客成交人数

            CityPerformanceItem newCustomerDealPerformanceItem = new CityPerformanceItem
            {
                TotalPerformmance = performance.NewCustomerDealCountRatio.TotalPerformmance,
                PerformanceList = performance.NewCustomerDealCountRatio.PerformanceList.Select(c => new CityPerformanceListItem
                {
                    Performance = c.Performance,
                    CityName = c.CityName
                }).ToList()
            };

            topTenCityPerformanceVo.NewCustomerDealCountRatio = newCustomerDealPerformanceItem;

            #endregion

            return ResultData<TopTenCityPerformanceVo>.Success().AddData("cityPerformanceData",topTenCityPerformanceVo);

        }


    }
}