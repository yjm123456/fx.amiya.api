using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    public class UpdateHospitalOnlineConsultRemarkDto
    {
        public string Id { get; set; }
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
