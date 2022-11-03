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
        /// 根据时间获取全国机构运营数据概况
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        Task<List<HospitalPerformanceDto>> GetHospitalPerformanceByDateAsync(int? year, int? month, bool isCity);

        /// <summary>
        /// 获取选择月份全国机构运营数据概况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        Task<List<HospitalPerformanceDto>> GetHospitalPerformanceBymonthAsync(int? year, int? month, bool isCity);
        /// <summary>
        /// 根据医院id获取医院新客上月与前月业绩
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<HospitalNewCustomerAchievementDto> GetHospitalOperationDailyData(int hospitalId);



        #region【 其他相关业务接口（折线图，明细等）】
        /// <summary>
        /// 获取全年医院派单量折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHospitalSendOrderNum(int year, int hospitalId);
        /// <summary>
        /// 获取全年医院上门数折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHospitalVisitNum(int year, int hospitalId);
        /// <summary>
        /// 获取全年医院上门率折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<HospitalVisitRateDto>> GetHospitalVisitRateNum(int year, int hospitalId);
        /// <summary>
        /// 获取全年医院新客成交数折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHospitalNewCustomerDealNum(int year, int hospitalId);
        /// <summary>
        /// 获取全年医院新客成交率折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<HospitalDealRateDto>> GetHospitalNewCustomerDealRateNum(int year, int hospitalId);
        /// <summary>
        /// 获取全年医院新客业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHospitalNewCustomerPerformanceNum(int year, int hospitalId);
        /// <summary>
        /// 获取全年医院新客客单价折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<HospitalUnitPriceDto>> GetHospitalNewCustomerUnitPriceNum(int year, int hospitalId);
        /// <summary>
        /// 获取全年医院老客成交数折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHospitalOldCustomerDealNum(int year, int hospitalId);
        /// <summary>
        /// 获取全年医院老客业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHospitalOldCustomerPerformanceNum(int year, int hospitalId);
        /// <summary>
        /// 获取全年医院老客客单价折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<HospitalUnitPriceDto>> GetHospitalOldCustomerUnitPriceNum(int year, int hospitalId);

        /// <summary>
        /// 获取全年医院总业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHospitalTotalCustomerPerformanceNum(int year, int hospitalId);
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


        #endregion

        #region 【转换接口】
        /// <summary>
        /// 计算占比
        /// </summary>
        /// <param name="completePerformance"></param>
        /// <param name="monthTarget"></param>
        /// <returns></returns>
        decimal? CalculateTargetComplete(decimal completePerformance, decimal monthTarget);

        /// <summary>
        /// 两数相比
        /// </summary>
        /// <param name="dataA"></param>
        /// <param name="dataB"></param>
        /// <returns></returns>
        string CalculateAccounted(decimal dataA, decimal dataB);
        /// <summary>
        /// 两数相除
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        decimal? Division(decimal? a, int? b);
        #endregion
    }
}
