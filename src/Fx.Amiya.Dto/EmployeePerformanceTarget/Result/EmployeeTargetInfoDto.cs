using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.EmployeePerformanceTarget.Result
{
    public class EmployeeTargetInfoDto
    {
        public int EmployeeId { get; set; }
        /// <summary>
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }
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
        /// <summary>
        /// 新客业绩目标
        /// </summary>
        public decimal NewCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal OldCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 老客成交目标
        /// </summary>
        public int OldCustomerDealNumTarget { get; set; }
        /// <summary>
        /// 新客成交目标
        /// </summary>
        public int NewCustomerDealNumTarget { get; set; }
        /// <summary>
        /// 新客到院目标
        /// </summary>
        public int NewCustomerVisitTarget { get; set; }
        /// <summary>
        /// 老客到院目标
        /// </summary>
        public int OldCustomerVisitTarget { get; set; }
    }
}
