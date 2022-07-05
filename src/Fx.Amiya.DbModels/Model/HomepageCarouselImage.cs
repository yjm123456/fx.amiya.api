using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
  public  class HomepageCarouselImage
    {
        public int Id { get; set; }
        public string PicUrl { get; set; }
        public byte DisplayIndex { get; set; }
        public string LinkUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
