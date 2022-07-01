using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TagInfo
{
    public class UpdateTagInfoVo
    {
       /// <summary>
       /// 标签编号
       /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标签类型0=医院规模，1=医院设施
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
    }
}
