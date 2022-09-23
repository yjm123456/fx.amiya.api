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
        [HttpGet("getHospitalOperationDairyData")]
        public async Task<ResultData<List<HospitalOperatingDataVo>>> GetHospitalOperationDairyData()
        {
            List<HospitalOperatingDataVo> hospitalPerformanceVo = new List<HospitalOperatingDataVo>();
            var hospitalPerformanceDatas = await hospitalPerformanceService.GetHospitalDailyPerformanceAsync();
            //(todo;)
            return ResultData<List<HospitalOperatingDataVo>>.Success().AddData("performance", hospitalPerformanceVo);
        }
        #endregion

    }
}