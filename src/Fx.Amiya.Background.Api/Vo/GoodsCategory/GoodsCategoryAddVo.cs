using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsCategory
{
    public class GoodsCategoryAddVo
    {
        public string Name { get; set; }
        public string SimpleCode { get; set; }

        /// <summary>
        /// 展示方向
        /// </summary>
        public int ShowDirectionType { get; set; }
        /// <summary>
        /// 类别图片
        /// </summary>
        public string CategoryImg { get; set; }
        /// <summary>
        /// 归属小程序appid
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 是否是热卖分类
        /// </summary>
        public bool IsHot { get; set; }
        /// <summary>
        /// 是否是品牌分类
        /// </summary>
        public bool IsBrand { get; set; }
    }
}
