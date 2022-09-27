using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    /// <summary>
    /// 机构网咨运营数据分析批注
    /// </summary>
    public class HospitalOnlineConsultRemarkVo
    {
        public string Id { get; set; }
        public string IndicatorId { get; set; }
        public int HospitalId { get; set; }
        public string HospitalOnlineConsultRemark { get; set; }
        public string AmiyaOnlineConsultRemark { get; set; }
    }
}
