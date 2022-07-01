using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsCategory
{
    /// <summary>
    /// 商品分类展示方向
    /// </summary>
    public class ShowDirectionTypeVo
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
