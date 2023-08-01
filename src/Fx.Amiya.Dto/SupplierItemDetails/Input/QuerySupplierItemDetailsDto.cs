using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.SupplierItemDetails.Input
{
    public class QuerySupplierItemDetailsDto:BaseQueryDto
    {
        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }
        public bool? Valid { get; set; }
    }
}
