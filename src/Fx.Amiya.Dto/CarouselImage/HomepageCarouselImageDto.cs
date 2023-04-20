using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.CarouselImage
{
   public  class HomepageCarouselImageDto
    {
        public int Id { get; set; }
        public string PicUrl { get; set; }
        public byte DisplayIndex { get; set; }
        public string LinkUrl { get; set; }
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 归属小程序appid
        /// </summary>
        public string AppId { get; set; }
        public string AppName { get; set; }
    }
}
