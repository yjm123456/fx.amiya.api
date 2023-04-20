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
        /// <summary>
        /// 归属appid(为空时表示在所有小程序都显示)
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsHot { get; set; }
        /// <summary>
        /// 是否是品牌分类
        /// </summary>
        public bool IsBrand { get; set; }
        public List<GoodsInfoDbModel> GoodsInfoList { get; set; }
    }
}
