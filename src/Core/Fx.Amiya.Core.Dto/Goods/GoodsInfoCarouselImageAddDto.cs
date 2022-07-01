using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
   public record GoodsInfoCarouselImageAddDto
    {   
        /// <summary>
         /// 图片地址
         /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 轮播顺序
        /// </summary>
        public byte DisplayIndex { get; set; }
    }
}
