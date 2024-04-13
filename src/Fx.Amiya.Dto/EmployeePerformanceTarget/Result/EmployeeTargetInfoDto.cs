using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.EmployeePerformanceTarget.Result
{
    public class EmployeeTargetInfoDto
    {
        /// <summary>
        /// 有效分诊
        /// </summary>
        public int EffectiveConsulationCardTarget { get; set; }
        /// <summary>
        /// 潜在分诊
        /// </summary>
        public int PotentialConsulationCardTarget { get; set; }

        /// <summary>
        /// 有效加V
        /// </summary>
        public int EffectiveAddWechatTarget { get; set; }
        /// <summary>
        /// 潜在加V
        /// </summary>
        public int PotentialAddWechatTarget { get; set; }
    }
}
