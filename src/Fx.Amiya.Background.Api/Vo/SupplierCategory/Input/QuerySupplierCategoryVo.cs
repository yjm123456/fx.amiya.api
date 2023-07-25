using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.SupplierCategory.Input
{
    public class QuerySupplierCategoryVo : BaseQueryVo
    {
        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }
        public bool? Valid { get; set; }
    }
}
