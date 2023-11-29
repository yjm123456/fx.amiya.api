using Fx.Amiya.BusinessWeChat.Api.Vo.CooperateLiveAnchorAchievement.Input;
using Fx.Amiya.BusinessWeChat.Api.Vo.CooperateLiveAnchorAchievement.Result;
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

namespace Fx.Amiya.BusinessWeChat.Api.Controllers
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
                Performance = ChangePriceToTenThousand(e.Performance),
                NewCustomerPerformance = ChangePriceToTenThousand(e.NewCustomerPerformance),
                NewCustomerPerformanceRatio = e.NewCustomerPerformanceRatio,
                OldCustomerPerformance = ChangePriceToTenThousand(e.OldCustomerPerformance),
                OldCustomerPerformanceRatio = e.OldCustomerPerformanceRatio,
                //加载今日数据
                TodayPerformance = ChangePriceToTenThousand(e.TodayPerformance),
                TodayNewCustomerPerformance = ChangePriceToTenThousand(e.TodayNewCustomerPerformance),
                TodayNewCustomerPerformanceRatio = e.TodayNewCustomerPerformanceRatio,
                TodayOldCustomerPerformance = ChangePriceToTenThousand(e.TodayOldCustomerPerformance),
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
                TotalPerformance = ChangePriceToTenThousand(e.TotalPerformance),
                TodayTotalPerformance= ChangePriceToTenThousand(e.TodayTotalPerformance),
                PerformanceRatio = e.PerformanceRatio,
                TodayPerformanceRatio = e.TodayPerformanceRatio,
                NewCustomerPerformance = ChangePriceToTenThousand(e.NewCustomerPerformance),
                TodayNewCustomerPerformance = ChangePriceToTenThousand(e.TodayNewCustomerPerformance),
                NewCustomerPerformanceRatio = e.NewCustomerPerformanceRatio,
                TodayNewCustomerPerformanceRatio = e.TodayNewCustomerPerformanceRatio,
                OldCustomerPerformance = ChangePriceToTenThousand(e.OldCustomerPerformance),
                TodayOldCustomerPerformance = ChangePriceToTenThousand(e.TodayOldCustomerPerformance),
                OldCustomerPerformanceRatio = e.OldCustomerPerformanceRatio,
                TodayOldCustomerPerformanceRatio = e.TodayOldCustomerPerformanceRatio,
                Logo =e.Logo
            }).ToList();
            return ResultData<List<CooperateLiveAnchorHospitalAchievementVo>>.Success().AddData("data", res);
        }
        private decimal ChangePriceToTenThousand(decimal currentPrice)
        {
            if (currentPrice == 0m)
                return 0;
            var result = Math.Round((currentPrice / 10000), 2, MidpointRounding.AwayFromZero);
            return result;
        }
    }
}
