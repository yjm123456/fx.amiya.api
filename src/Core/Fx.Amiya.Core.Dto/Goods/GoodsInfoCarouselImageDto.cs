using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
    public record GoodsInfoCarouselImageDto
    {
        public long Id { get; set; }
        public string PicUrl { get; set; }
        public byte DisplayIndex { get; set; }
    }
}
