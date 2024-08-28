using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalContentplatformCode.Input
{
    public class UpdateHospitalContentplatformCodeDto : BaseDto
    {
        /// <summary>
        /// 三方平台Id
        /// </summary>
        public string ThirdPartContentplatformInfoId { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}
