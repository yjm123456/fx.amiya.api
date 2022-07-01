using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.Domin
{
   public class GoodsInfoCarouselImage
    {
        public long Id { get; set; }
        public string GoodsInfoId { get; set; }
        public string PicUrl { get; set; }
        public byte DisplayIndex { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
