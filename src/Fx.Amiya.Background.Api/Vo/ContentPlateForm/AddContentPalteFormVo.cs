using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateForm
{
    /// <summary>
    /// 内容平台数据
    /// </summary>
    public class AddContentPalteFormVo
    {
        /// <summary>
        /// 内容平台名字
        /// </summary>

        public string ContentPlatformName { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
    }
}
