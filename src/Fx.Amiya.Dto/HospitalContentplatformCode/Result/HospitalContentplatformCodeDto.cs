using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalContentplatformCode.Result
{
    public class HospitalContentplatformCodeDto : BaseDto
    {
        /// <summary>
        /// 三方平台Id
        /// </summary>
        public string ThirdPartContentplatformInfoId { get; set; }
        /// <summary>
        /// 三方平台名称
        /// </summary>
        public string ThirdPartContentplatformInfoName { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}
