using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerServiceCompensation.Result
{
    /// <summary>
    /// 助理薪资单输出类
    /// </summary>
    public class CustomerServiceCompensationVo : BaseVo
    {

        /// <summary>
        /// 创建人id
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreateByEmpName { get; set; }
        /// <summary>
        /// 账单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }
        /// <summary>
        /// 归属客服名称
        /// </summary>
        public string BelongEmpName { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal OtherPrice { get; set; }
        /// <summary>
        /// 费用备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 底薪
        /// </summary>
        public decimal Salary { get; set; }
        /// <summary>
        /// 提成点数
        /// </summary>
        //public decimal PerformancePercent { get; set; }
        /// <summary>
        /// 提成金额
        /// </summary>
        public decimal CustomerServicePerformance { get; set; }
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal ToHospitalRate { get; set; }
        /// <summary>
        /// 上门率奖励
        /// </summary>
        public decimal ToHospitalRateReword { get; set; }
        /// <summary>
        /// 复购率
        /// </summary>
        public decimal RepeatPurchasesRate { get; set; }
        /// <summary>
        /// 复购率奖励
        /// </summary>
        public decimal RepeatPurchasesRateReword { get; set; }
        /// <summary>
        /// 新客上门奖励
        /// </summary>
        public decimal NewCustomerToHospitalReword { get; set; }
        /// <summary>
        /// 老客上门奖励
        /// </summary>
        public decimal OldCustomerToHospitalReword { get; set; }
        /// <summary>
        /// 目标达成奖励
        /// </summary>
        public decimal TargetFinishReword { get; set; }
        /// <summary>
        /// 其他扣款
        /// </summary>
        public decimal OtherChargebacks { get; set; }
    }
}
