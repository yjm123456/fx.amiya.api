using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalOperationIndicatorSubmit
{
    /// <summary>
    /// 机构提报数据汇总
    /// </summary>
    public class HospitalOperationIndicatorCollectVo
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 指标名称
        /// </summary>
        public string IndicatorName { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 医院地址
        /// </summary>
        public string HospitalAddress { get; set; }
        /// <summary>
        /// 是否提报
        /// </summary>
        public bool IsSubmit { get; set; }
        /// <summary>
        /// 是否批注
        /// </summary>
        public bool IsRemark { get; set; }
    }
}
