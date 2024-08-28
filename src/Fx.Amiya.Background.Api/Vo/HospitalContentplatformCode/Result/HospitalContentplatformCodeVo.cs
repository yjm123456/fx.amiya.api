using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalContentplatformCode.Result
{
    public class HospitalContentplatformCodeVo : BaseVo
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
