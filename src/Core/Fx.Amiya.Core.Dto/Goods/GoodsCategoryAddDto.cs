using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
  public  record GoodsCategoryAddDto
    {
        public string Name { get; set; }
        public string SimpleCode { get; set; }

        public int ShowDirectionType { get; set; }
        public int CreateBy { get; set; }
        /// <summary>
        /// 类别图片
        /// </summary>
        public string CategoryImg { get; set; }
    }
}
