using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.Performance;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveAnchorMonthlyTargetService
    {
        Task<FxPageInfo<LiveAnchorMonthlyTargetDto>> GetListWithPageAsync(int Year, int Month, int? LiveAnchorId, int employeeId,int pageNum, int pageSize);
        Task AddAsync(AddLiveAnchorMonthlyTargetDto addDto);
        Task<List<LiveAnchorMonthlyTargetKeyAndValueDto>> GetIdAndNames(int year, int month);
        Task<LiveAnchorMonthlyTargetDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateLiveAnchorMonthlyTargetDto updateDto);
        Task EditAsync(UpdateLiveAnchorMonthlyTargetRateAndNumDto editDto);
        Task DeleteAsync(string id);

        /// <summary>
        /// 获取业绩相关数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        Task<LiveAnchorMonthTargetPerformanceDto> GetPerformance(int year,int month);

        /// <summary>
        /// 根据平台id按年月获取合作达人业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        Task<GroupPerformanceListDto> GetCooperationLiveAnchorPerformance(int year, int month, string contentPlatFormId);
        /// <summary>
        /// 根据主播基础id按年月获取数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorBaseId"></param>
        /// <returns></returns>
        Task<GroupPerformanceListDto> GetLiveAnchorBaseIdPerformance(int year, int month, string liveAnchorBaseId);

        /// <summary>
        /// 根据平台id获取折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="contentPlatFormId"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceBrokenLineAsync(int year, string contentPlatFormId);
        /// <summary>
        /// 根据主播id获取折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="ids">主播id集合id</param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceBrokenLineByLiveAnchorId(int year,int month,List<int> ids);
        /// <summary>
        /// 按月获取主播带货业绩
        /// </summary>
        /// <returns></returns>
        Task<List<PerformanceInfoByDateDto>> GetLiveAnchorCommercePerformance(int year, int month);

        /* /// <summary>
         /// 获取指定月份业绩总目标
         /// </summary>
         /// <param name="year"></param>
         /// <param name="month"></param>
         /// <returns></returns>
         Task<PerformanceDto> GetLiveAnchorMonthlyTargetTotalPerformance(int year,int month);
         /// <summary>
         /// 获取指定月份带货业绩总目标
         /// </summary>
         /// <returns></returns>
         Task<PerformanceDto> GetLiveAnchorMonthTargetTotalCommercePerformance(int year, int month);
         /// <summary>
         /// 获取指定月份已完成的带货业绩
         /// </summary>
         /// <param name="year"></param>
         /// <param name="month"></param>
         /// <returns></returns>
         Task<PerformanceDto> GetLiveAnchorMonthTargetAlreadyCompleteCommercePerformance(int year,int month);

         /// <summary>
         /// 获取老客业绩目标
         /// </summary>
         /// <param name="year"></param>
         /// <param name="month"></param>
         /// <returns></returns>
         Task<PerformanceDto> GetLiveAnchorMonthOldPerformanceTarget(int year, int month);
         /// <summary>
         /// 获取新客业绩指标
         /// </summary>
         /// <param name="year"></param>
         /// <param name="month"></param>
         /// <returns></returns>
         Task<PerformanceDto> GetLiveAnchorMonthNewPerformanceTarget(int year, int month);*/
    }
}
