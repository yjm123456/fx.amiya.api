using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    public class UpdateHospitalConsultRemarkDto
    {
        public string Id { get; set; }
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
