using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace Fx.Amiya.Modules.Goods.DbModel
{
   public class GoodsDetailDbModel
    {
        [Column(IsIdentity =true)]
        public int Id { get; set; }
        public string GoodsDetailHtml { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }

        public List<GoodsInfoDbModel> GoodsInfoList { get; set; }
    }
}
