using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Modules.Goods.DbModel
{
   public class GoodsCategoryDbModel
    {
        [Column(IsIdentity = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SimpleCode { get; set; }
        public int? ShowDirectionType { get; set; }
        public bool Valid { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 类别图片
        /// </summary>
        public string CategoryImg { get; set; }

        public List<GoodsInfoDbModel> GoodsInfoList { get; set; }
    }
}
