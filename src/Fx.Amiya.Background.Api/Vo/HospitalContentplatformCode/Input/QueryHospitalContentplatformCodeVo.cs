using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalContentplatformCode.Input
{
    public class QueryHospitalContentplatformCodeVo : BaseQueryVo
    {
        /// <summary>
        /// 三方平台Id
        /// </summary>
        public string ThirdPartContentplatformInfoId { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }
    }
}
