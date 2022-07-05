using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.CarouselImage
{
    public class HomepageCarouselImageVo
    {
        public int Id { get; set; }
        public string PicUrl { get; set; }
        public string LinkUrl { get; set; }
        public byte DisplayIndex { get; set; }
    }
}
