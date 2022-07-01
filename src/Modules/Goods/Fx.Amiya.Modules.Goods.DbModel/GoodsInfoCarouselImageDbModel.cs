using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace Fx.Amiya.Modules.Goods.DbModel
{
    public class GoodsInfoCarouselImageDbModel
    {
        [Column(IsIdentity =true)]
        public long Id { get; set; }
        public string GoodsInfoId { get; set; }
        public string PicUrl { get; set; }
        public byte DisplayIndex { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public GoodsInfoDbModel GoodsInfo { get; set; }
    }
}
