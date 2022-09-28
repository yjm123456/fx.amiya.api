using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    /// <summary>
    /// 机构成交品项数据分析批注
    /// </summary>
    public class HospitalDealRemarkDto
    {
        public string Id { get; set; }
        public string IndicatorId { get; set; }
        public int HospitalId { get; set; }
        public string HospitalDealRemark { get; set; }
        public string AmiyaDealRemark { get; set; }
    }
}
