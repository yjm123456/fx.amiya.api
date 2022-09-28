using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    public class UpdateHospitalDoctorRemarkVo
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
        /// 医院医生数据分析批注
        /// </summary>
        public string HospitalDoctorRemark { get; set; }
        /// <summary>
        /// 啊美雅医生数据分析批注
        /// </summary>
        public string AmiyaDoctorRemark { get; set; }
    }
}
