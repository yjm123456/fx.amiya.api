using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalContentplatformCode.Input
{
    public class UpdateHospitalContentplatformCodeVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 三方平台Id
        /// </summary>
        public string ThirdPartContentplatformInfoId { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }
        public string Code { get; set; }
    }
}
