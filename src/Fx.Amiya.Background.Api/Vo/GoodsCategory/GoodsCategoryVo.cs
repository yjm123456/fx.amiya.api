using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsCategory
{
    public class GoodsCategoryVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SimpleCode { get; set; }
        /// <summary>
        /// 展示方向
        /// </summary>
        public int ShowDirectionType { get; set; }
        public string ShowDirectionTypeName { get; set; }
        public bool Valid { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
