using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    public class AddHospitalOnlineConsultRemarkDto
    {
        /// <summary>
        /// 运营指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院网咨运营数据分析批注
        /// </summary>
        public string HospitalOnlineConsultRemark { get; set; }
        /// <summary>
        /// 啊美雅网咨运营数据分析批注
        /// </summary>
        public string AmiyaOnlineConsultRemark { get; set; }

    }
}
