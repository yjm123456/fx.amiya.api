using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalImprovePlan
{
    public class UpdateHospitalImprovePlanDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 机构提升措施与计划
        /// </summary>
        public string HospitalImprovePlan { get; set; }
        /// <summary>
        /// 啊美雅对机构提升措施与计划批注
        /// </summary>
        public string AmiyaImprovePlanRemark { get; set; }
        /// <summary>
        /// 机构分享成功案例
        /// </summary>
        public string HospitalShareSuccessCase { get; set; }
        /// <summary>
        /// 啊美雅对机构分享成功案例批注
        /// </summary>
        public string AmiyaShareSuccessCase { get; set; }
        /// <summary>
        /// 机构对啊美雅的提升建议
        /// </summary>
        public string ImproveSuggestionToAmiya { get; set; }
        /// <summary>
        /// 啊美雅批注机构提升建议
        /// </summary>
        public string AmiyaImproveSuggestionRemark { get; set; }
        /// <summary>
        /// 机构对啊美雅的提升需求
        /// </summary>
        public string ImproveDemandToAmiya { get; set; }
        /// <summary>
        /// 啊美雅批注机构提升需求
        /// </summary>
        public string AmiyaImproveDemandRemark { get; set; }
    }
}
