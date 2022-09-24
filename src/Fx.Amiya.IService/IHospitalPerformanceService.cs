using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.HospitalPerformance;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalPerformanceService
    {
        /// <summary>
        /// 获取全国机构日运营数据概况
        /// </summary>
        /// <returns></returns>
        Task<List<HospitalPerformanceDto>> GetHospitalDailyPerformanceAsync();
        /// <summary>
        /// 获取全国机构top10运营数据占比
        /// </summary>
        /// <returns></returns>
        Task<HospitalAccumulatePerformanceDto> GetTopTenHospitalPerfromance();
        /// <summary>
        /// 获取合作城市top10运营数据占比
        /// </summary>
        /// <returns></returns>
        Task<CityAccumulatePerformanceDto> GetTopTenCityPerformance();

        #region【 其他相关业务接口（折线图，明细等）】

        #endregion
    }
}
