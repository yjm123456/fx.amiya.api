using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MemberCard
{
    public class MemberCardUpgradeDto
    {
        /// <summary>
        /// 升级所需的成长值
        /// </summary>
        public decimal UpgardeNeedGrowthPoints { get; set; }
        /// <summary>
        /// 下一等级名称
        /// </summary>
        public string NextLeaveText { get; set; }
    }
}
