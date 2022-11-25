using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class ImprovePlanAndRemark:BaseDbModel
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
        /// 类型0运营优点,1运营不足,2提升计划,3运营需求
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 运营分析和提示计划
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Sort { get; set; }
    }
}
