using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    /// <summary>
    /// 添加医院运营数据分析批注
    /// </summary>
    public class UpdateHospitalOperationRemarkDto
    {
        /// <summary>
        /// 运营指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 医院运营数据分析批注
        /// </summary>
        public string HospitalOperationRemark { get; set; }
        /// <summary>
        /// 啊美雅运营数据分析批注
        /// </summary>
        public string AmiyaOperationRemark { get; set; }
    }
}
