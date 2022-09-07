using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.GrowthPoints
{
    public class GrowthPointsVo
    {
        /// <summary>
        /// 当前成长值
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 升级所需的成长值
        /// </summary>
        public decimal UpgradeGrowthPoints{ get; set; }
        /// <summary>
        /// 下一级会员
        /// </summary>
        public string NextLeaveText { get; set; }
    }
}
