using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatform
{
    public class UpdateContentPlatformDto
    {
        public string Id { get; set; }

        public string ContentPlatformName { get; set; }
        /// <summary>
        /// 内容平台英文名
        /// </summary>
        public string ContentPlatformEnglishName { get; set; }
        public bool Valid { get; set; }
    }
}
