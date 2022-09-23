using Fx.Amiya.Background.Api.Vo.HospitalPerformance;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [HttpGet("getHospitalOperationDailyData")]
        public async Task<ResultData<List<HospitalOperatingDataVo>>> GetHospitalOperationDairyData()
        {
            List<HospitalOperatingDataVo> hospitalPerformanceVo = new List<HospitalOperatingDataVo>();
            var hospitalPerformanceDatas = await hospitalPerformanceService.GetHospitalDailyPerformanceAsync();
            foreach (var x in hospitalPerformanceDatas)
            {
                HospitalOperatingDataVo hospitalOperatingDataVo = new HospitalOperatingDataVo();
                hospitalOperatingDataVo.HospitalName = x.HospitalName;
                hospitalOperatingDataVo.City = x.City;
                hospitalOperatingDataVo.SendNum = x.SendNum;
                hospitalOperatingDataVo.VisitNum = x.VisitNum;
                hospitalOperatingDataVo.VisitRate = x.VisitRate;
                hospitalOperatingDataVo.NewCustomerDealNum = x.NewCustomerDealNum;
                hospitalOperatingDataVo.NewCustomerDealRate = x.NewCustomerDealRate;
                hospitalOperatingDataVo.NewCustomerAchievement = x.NewCustomerAchievement;
                hospitalOperatingDataVo.NewCustomerUnitPrice = x.NewCustomerUnitPrice;
                hospitalOperatingDataVo.OldCustomerDealNum = x.OldCustomerDealNum;
                hospitalOperatingDataVo.OldCustomerAchievement = x.OldCustomerAchievement;
                hospitalOperatingDataVo.OldCustomerUnitPrice = x.OldCustomerUnitPrice;
                hospitalOperatingDataVo.TotalAchievement = x.TotalAchievement;
                hospitalOperatingDataVo.NewOrOldCustomerRate = x.NewOrOldCustomerRate;
            }
            return ResultData<List<HospitalOperatingDataVo>>.Success().AddData("performance", hospitalPerformanceVo);
        }

        /// <summary>
        /// 全国机构运营当年数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("getHospitalOperationYearData")]
        public async Task<ResultData<HospitalOperatingYearDataVo>> GetHospitalOperationDairyByYearData(int year)
        {
            HospitalOperatingYearDataVo hospitalPerformanceVo = new HospitalOperatingYearDataVo();
            var hospitalPerformanceDatas = await hospitalPerformanceService.GetHospitalDailyPerformanceAsync();
            //(todo;)
            return ResultData<HospitalOperatingYearDataVo>.Success().AddData("performance", hospitalPerformanceVo);
        }
        #endregion

    }
}