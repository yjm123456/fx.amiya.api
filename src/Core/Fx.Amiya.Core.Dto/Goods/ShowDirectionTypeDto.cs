using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
    /// <summary>
    /// 商品分类展示方向
    /// </summary>
    public class ShowDirectionTypeDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public byte ShowDirectionType { get; set; }
        /// <summary>
        /// 方向说明
        /// </summary>
        public string ShowDirectionTypeText { get; set; }
    }
}
