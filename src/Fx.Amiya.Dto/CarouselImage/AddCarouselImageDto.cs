using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.CarouselImage
{
  public  class AddCarouselImageDto
    {
        public string PicUrl { get; set; }
        public  string LinkUrl { get; set; }
        /// <summary>
        /// 归属小程序appid
        /// </summary>
        public string AppId { get; set; }
    }
}
