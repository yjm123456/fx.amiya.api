using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.SupplierCategory.Output
{
    public class SupplierCategoryVo:BaseVo
    {
        /// <summary>
        /// 品类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }

    }
}
