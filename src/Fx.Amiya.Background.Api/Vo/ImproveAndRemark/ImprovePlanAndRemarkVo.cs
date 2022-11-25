using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ImproveAndRemark
{
    public class ImprovePlanAndRemarkVo
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 运营指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 详细内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Sort { get; set; }
    }
}
