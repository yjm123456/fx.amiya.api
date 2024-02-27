using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class AfterLivingBrokenItemDataDto
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 有效业绩折线图
        /// </summary>
        public decimal EffectivePerformance { get; set; }
        /// <summary>
        /// 潜在业绩折线图
        /// </summary>
        public decimal PotentialPerformance { get; set; }
        /// <summary>
        /// 新客有效业绩折线图
        /// </summary>
        public decimal NewCustomerEffectivePerformance { get; set; }
        /// <summary>
        /// 新客潜在业绩折线图
        /// </summary>
        public decimal NewCustomerPotentialPerformance { get; set; }
        /// <summary>
        /// 老客有效业绩折线图
        /// </summary>
        public decimal OldCustomerEffectivePerformance { get; set; }
        /// <summary>
        /// 老客潜在业绩折线图
        /// </summary>
        public decimal OldCustomerPotentialPerformance { get; set; }
    }
}
