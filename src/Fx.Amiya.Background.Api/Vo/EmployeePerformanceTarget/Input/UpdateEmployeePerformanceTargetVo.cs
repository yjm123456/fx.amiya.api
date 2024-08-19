using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.EmployeePerformanceTarget.Input
{
    public class UpdateEmployeePerformanceTargetVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 归属年份
        /// </summary>
        public int BelongYear { get; set; }
        /// <summary>
        /// 归属月份
        /// </summary>
        public int BelongMonth { get; set; }
        /// <summary>
        /// 助理id
        /// </summary>
        public int EmployeeId { get; set; }
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
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }
        /// <summary>
        /// 新客到院目标
        /// </summary>
        public int NewCustomerVisitTarget { get; set; }
        /// <summary>
        /// 老客到院目标
        /// </summary>
        public int OldCustomerVisitTarget { get; set; }
        /// <summary>
        /// 新客成交目标
        /// </summary>
        public int NewCustomerDealTarget { get; set; }
        /// <summary>
        /// 老客成交目标
        /// </summary>
        public int OldCustomerDealTarget { get; set; }
        /// <summary>
        /// 新客业绩目标
        /// </summary>
        public decimal NewCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal OldCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 总业绩目标
        /// </summary>
        public decimal PerformanceTarget { get; set; }
        /// <summary>
        /// 线索登记目标
        /// </summary>
        public int CluesRegisterTarget { get; set; }
    }
}
