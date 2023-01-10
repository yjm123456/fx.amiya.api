using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerTagInfo
{
    public class CustomerTagInfoVo:BaseVo
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 标签类别名称
        /// </summary>
        public string TagCategoryName { get; set; }
        /// <summary>
        /// 标签类别
        /// </summary>
        public int? TagCategory { get; set; }
    }
}
