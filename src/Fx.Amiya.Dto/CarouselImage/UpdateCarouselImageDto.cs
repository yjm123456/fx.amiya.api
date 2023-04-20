using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.CarouselImage
{
   public class UpdateCarouselImageDto
    {
        public int Id { get; set; }
        public string PicUrl { get; set; }
        public string LinkUrl { get; set; }
        public byte DisplayIndex { get; set; }
        public string AppId { get; set; }
    }
}
