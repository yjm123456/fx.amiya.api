using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalImprovePlan
{
    public class AddHospitalImprovePlanVo
    {
        /// <summary>
        /// 指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 机构运营优点
        /// </summary>
        public string HospitalImprovePlan { get; set; }
        /// <summary>
        /// 啊美雅运营优点批注
        /// </summary>
        public string AmiyaImprovePlanRemark { get; set; }
        /// <summary>
        /// 机构运营不足
        /// </summary>
        public string HospitalShareSuccessCase { get; set; }
        /// <summary>
        /// 啊美雅对机构运营不足批注
        /// </summary>
        public string AmiyaShareSuccessCase { get; set; }
        /// <summary>
        /// 机构提升计划
        /// </summary>
        public string ImproveSuggestionToAmiya { get; set; }
        /// <summary>
        /// 啊美雅机构提升计划批注
        /// </summary>
        public string AmiyaImproveSuggestionRemark { get; set; }
        /// <summary>
        /// 机构运营需求
        /// </summary>
        public string ImproveDemandToAmiya { get; set; }
        /// <summary>
        /// 啊美雅对机构运营需求批注
        /// </summary>
        public string AmiyaImproveDemandRemark { get; set; }
    }
    
}
