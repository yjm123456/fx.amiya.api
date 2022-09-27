using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    public class AddHospitalConsultRemarkVo
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
        /// 医院咨询师数据分析批注
        /// </summary>
        public string HospitalConsultRemark { get; set; }
        /// <summary>
        /// 啊美雅咨询师数据分析批注
        /// </summary>
        public string AmiyaConsultRemark { get; set; }
    }
}
