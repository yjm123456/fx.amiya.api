using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ThirdPartContentplatformInfo.Input
{
    public class AddThirdPartContentplatformInfoVo
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
