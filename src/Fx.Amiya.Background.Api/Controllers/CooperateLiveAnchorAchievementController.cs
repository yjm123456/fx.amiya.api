using Fx.Amiya.Background.Api.Vo.CooperateLiveAnchorAchievement.Input;
using Fx.Amiya.Background.Api.Vo.CooperateLiveAnchorAchievement.Result;
using Fx.Amiya.Dto.CooperateLiveAnchorAchievement;
using Fx.Amiya.Dto.CooperateLiveAnchorAchievement.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 合作达人业绩
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CooperateLiveAnchorAchievementController : ControllerBase
    {
        private readonly ICooperateLiveAnchorAchievementService _cooperateLiveAnchorAchievementService;

        public CooperateLiveAnchorAchievementController(ICooperateLiveAnchorAchievementService cooperateLiveAnchorAchievementService)
        {
            _cooperateLiveAnchorAchievementService = cooperateLiveAnchorAchievementService;
        }
        /// <summary>
        /// 获取合作达人业绩
        /// </summary>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        [HttpGet("cooperateLiveAnchorPerformanceData")]
        public async Task<ResultData<List<CooperateLiveAnchorAchievementVo>>> GetCooperateLiveAnchorAchievementAsync(DateTime checkDate)
        {
            var res = (await _cooperateLiveAnchorAchievementService.GetCooperateLiveAnchorAchievementAsync(checkDate)).Select(e => new CooperateLiveAnchorAchievementVo
            {
                LiveanchorName = e.LiveanchorName,
                Performance = e.Performance,
                NewCustomerPerformance = e.NewCustomerPerformance,
                NewCustomerPerformanceRatio = e.NewCustomerPerformanceRatio,
                OldCustomerPerformance = e.OldCustomerPerformance,
                OldCustomerPerformanceRatio = e.OldCustomerPerformanceRatio,

                //加载今日数据
                TodayPerformance = e.TodayPerformance,
                TodayNewCustomerPerformance = e.TodayNewCustomerPerformance,
                TodayNewCustomerPerformanceRatio = e.TodayNewCustomerPerformanceRatio,
                TodayOldCustomerPerformance = e.TodayOldCustomerPerformance,
                TodayOldCustomerPerformanceRatio = e.TodayOldCustomerPerformanceRatio
            }).ToList();
            return ResultData<List<CooperateLiveAnchorAchievementVo>>.Success().AddData("data", res);
        }


        /// <summary>
        /// 机构排名数据
        /// </summary>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        [HttpGet("cooperatehospitalRank")]
        public async Task<ResultData<List<CooperateLiveAnchorHospitalAchievementVo>>> GetCooperateHospitalAchievementAsync(DateTime checkDate)
        {

            var res = (await _cooperateLiveAnchorAchievementService.GetCooperateLiveAnchorHospitalAchieementsAsync(checkDate)).Select(e => new CooperateLiveAnchorHospitalAchievementVo
            {
                Rank = e.Rank,
                HospitalName = e.HospitalName,
                TotalPerformance = e.TotalPerformance,
                TodayTotalPerformance = e.TodayTotalPerformance,
                PerformanceRatio = e.PerformanceRatio,
                TodayPerformanceRatio = e.TodayPerformanceRatio,
                NewCustomerPerformance = e.NewCustomerPerformance,
                TodayNewCustomerPerformance = e.TodayNewCustomerPerformance,
                NewCustomerPerformanceRatio = e.NewCustomerPerformanceRatio,
                TodayNewCustomerPerformanceRatio = e.TodayNewCustomerPerformanceRatio,
                OldCustomerPerformance = e.OldCustomerPerformance,
                TodayOldCustomerPerformance = e.TodayOldCustomerPerformance,
                OldCustomerPerformanceRatio = e.OldCustomerPerformanceRatio,
                TodayOldCustomerPerformanceRatio = e.TodayOldCustomerPerformanceRatio,
                Logo = e.Logo
            }).ToList();
            return ResultData<List<CooperateLiveAnchorHospitalAchievementVo>>.Success().AddData("data", res);
        }


    }
}
