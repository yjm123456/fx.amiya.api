using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    /// <summary>
    /// 运营管理总业绩与时间进度接口返回类
    /// </summary>
    public class OperationTotalAchievementDataVo
    {
        /// <summary>
        /// 时间进度
        /// </summary>
        public decimal DateSchedule { get; set; }

        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalAchievement { get; set; }
        /// <summary>
        /// 总业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> TotalPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> NewCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> OldCustomerPerformanceBrokenLineList { get; set; }

    }


}
