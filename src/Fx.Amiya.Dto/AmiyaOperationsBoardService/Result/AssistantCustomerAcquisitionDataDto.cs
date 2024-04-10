using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService
{
    public class AssistantCustomerAcquisitionDataDto
    {
        /// <summary>
        /// 助理名称
        /// </summary>
        public string AssistantName { get; set; }
        /// <summary>
        /// 潜在分诊量
        /// </summary>
        public int PotentialAllocationConsulation { get; set; }
        /// <summary>
        /// 潜在分诊目标
        /// </summary>
        public int PotentialAllocationConsulationTarget { get; set; }
        /// <summary>
        /// 潜在分诊达成率
        /// </summary>
        public decimal PotentialAllocationConsulationTargetComplete { get; set; }
        /// <summary>
        /// 潜在加微量
        /// </summary>
        public int PotentialAddWechat { get; set; }
        /// <summary>
        /// 潜在加微目标
        /// </summary>
        public int PotentialAddWechatTarget { get; set; }
        /// <summary>
        /// 潜在加微达成率
        /// </summary>
        public decimal PotentialAddWechatTargetComplete { get; set; }

        /// <summary>
        /// 有效分诊量
        /// </summary>
        public int EffectiveAllocationConsulation { get; set; }
        /// <summary>
        /// 有效分诊目标
        /// </summary>
        public int EffectiveAllocationConsulationTarget { get; set; }
        /// <summary>
        /// 有效分诊达成率
        /// </summary>
        public decimal EffectiveAllocationConsulationTargetComplete { get; set; }
        /// <summary>
        /// 有效加微量
        /// </summary>
        public int EffectiveAddWechat { get; set; }
        /// <summary>
        /// 有效加微目标
        /// </summary>
        public int EffectiveAddWechatTarget { get; set; }
        /// <summary>
        /// 有效加微达成率
        /// </summary>
        public decimal EffectiveAddWechatTargetComplete { get; set; }
    }
}
