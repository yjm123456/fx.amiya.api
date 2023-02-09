using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
    public class GoodsCategoryNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ShowDirectionType{ get; set; }
        /// <summary>
        /// 类别图片
        /// </summary>
        public string CategoryImg { get; set; }
    }
}
