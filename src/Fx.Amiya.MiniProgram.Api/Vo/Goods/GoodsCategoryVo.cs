using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Goods
{
    public class GoodsCategoryVo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 展示方向
        /// </summary>
        public int ShowDirectionType { get; set; }
    }
}
