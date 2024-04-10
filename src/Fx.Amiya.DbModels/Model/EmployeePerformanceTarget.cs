using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class EmployeePerformanceTarget:BaseDbModel
    {
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
        /// <summary>
        /// 分诊目标
        /// </summary>
        public int ConsulationCardTarget { get; set; }
        /// <summary>
        /// 加v目标
        /// </summary>
        public int AddWechatTarget { get; set; }
        /// <summary>
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }
        /// <summary>
        /// 到院目标
        /// </summary>
        public int VisitTarget { get; set; }
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


        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
