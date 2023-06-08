using Fx.Amiya.Dto.HospitalBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalBoardService
    {
        /// <summary>
        /// 获取订单看板数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="type">0累计,1当月</param>
        /// <returns></returns>
        Task<OrderDataDto> GetOrderBoardDataAsync(int year,int month,int hospitalId,int type);
        /// <summary>
        /// 获取运营看板数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<OperateDataDto> GetOperateDataAsync(int year, int month,int hospitalId,int type);
        /// <summary>
        /// 获取成交看板业绩数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<DealPerformanceBordDataDto> GetDealPerformanceDataAsync(int year, int month,int hospitalId);
        /// <summary>
        /// 获取成交看板科室数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<OperateDepartmentRankDto>> GetDealDepartmentRankDataAsync(int year, int month, int hospitalId,int type);
        /// <summary>
        /// 获取成交看板咨询数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<OperateConsultantRankDataDto>> GetDealConsultantRankDataAsync(int year, int month, int hospitalId,int type);
        /// <summary>
        /// 获取成交看板接诊数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<OperateConsultantRankDataDto>> GetDealSceneRankDataAsync(int year, int month, int hospitalId,int type);
        /// <summary>
        /// 获取机构排名数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<HospitalRankDto> GetHospitalRankDataAsync(int year, int month,int HospitalId,int type);
    }
}
