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
        /// <param name="year">年份</param>
        /// <returns></returns>
        Task<List<HospitalPerformanceDto>> GetHospitalDailyPerformanceAsync(int? year);



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


        decimal? CalculateTargetComplete(decimal completePerformance, decimal monthTarget);
        string CalculateAccounted(decimal dataA, decimal dataB);
        decimal? Division(decimal? a, int? b);
        #endregion
    }
}
