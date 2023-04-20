using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
   public class GoodsCategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ShowDirectionType { get; set; }
        public string SimpleCode { get; set; }
        public bool Valid { get; set; }
        public int UpdateBy { get; set; }
        /// <summary>
        /// 类别图片
        /// </summary>
        public string CategoryImg { get; set; }
        /// <summary>
        /// 归属小程序appid
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 是否是热门商品
        /// </summary>
        public bool IsHot { get; set; }
        /// <summary>
        /// 是否是品牌分类
        /// </summary>
        public bool IsBrand { get; set; }
    }
}
