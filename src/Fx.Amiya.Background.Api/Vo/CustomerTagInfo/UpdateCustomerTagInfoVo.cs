using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerTagInfo
{
    public class UpdateCustomerTagInfoVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
        /// <summary>
        /// 标签类别
        /// </summary>
        public int TagCategory { get; set; }
    }
}
