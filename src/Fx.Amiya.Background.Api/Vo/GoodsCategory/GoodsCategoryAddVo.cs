using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsCategory
{
    public class GoodsCategoryAddVo
    {
        public string Name { get; set; }
        public string SimpleCode { get; set; }

        /// <summary>
        /// 展示方向
        /// </summary>
        public int ShowDirectionType { get; set; }
    }
}
