using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ThirdPartContentplatformInfo.Input
{
    public class AddThirdPartContentplatformInfoDto
    {
        /// <summary>
        /// 三方平台名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// api地址
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
    }
}
