using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TagInfo
{
    public class AddTagInfoVo
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标签类型0=规模，1=设施
        /// </summary>
        public byte Type { get; set; }
    }
}
