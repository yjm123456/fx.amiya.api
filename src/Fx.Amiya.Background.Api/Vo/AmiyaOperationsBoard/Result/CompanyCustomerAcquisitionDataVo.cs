using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{

    public class CompanyCustomerAcquisitionDataVo
    {
        public string GroupName { get; set; }
        /// <summary>
        /// 下卡量
        /// </summary>
        public int OrderCard { get; set; }
        /// <summary>
        /// 下卡目标
        /// </summary>
        public int OrderCardTarget { get; set; }
        /// <summary>
        /// 下卡目标完成率
        /// </summary>
        public decimal OrderCardTargetComplete { get; set; }
        /// <summary>
        /// 退卡量
        /// </summary>
        public int RefundCard { get; set; }
        /// <summary>
        /// 下卡异常
        /// </summary>
        public int OrderCardError { get; set; }
        /// <summary>
        /// 分诊量
        /// </summary>
        public int AllocationConsulation { get; set; }
        /// <summary>
        /// 分诊目标
        /// </summary>
        public int AllocationConsulationTarget { get; set; }
        /// <summary>
        /// 分诊达成率
        /// </summary>
        public decimal AllocationConsulationTargetComplete { get; set; }
        /// <summary>
        /// 加微量
        /// </summary>
        public int AddWechat { get; set; }
        /// <summary>
        /// 加微目标
        /// </summary>
        public int AddWechatTarget { get; set; }
        /// <summary>
        /// 加微达成率
        /// </summary>

        public decimal AddWechatTargetComplete { get; set; }

    }
}
