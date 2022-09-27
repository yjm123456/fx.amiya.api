using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    /// <summary>
    /// 机构医生运营数据分析
    /// </summary>
    public class HospitalDoctorRemarkVo
    {
        public string Id { get; set; }
        public string IndicatorId { get; set; }
        public int HospitalId { get; set; }
        public string HospitalDoctorRemark { get; set; }
        public string AmiyaDoctorRemark { get; set; }
    }
}
