using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LivingDailyTakeGoods.Input
{
    public class QueryLivingDailyTakeGoodsDto : BaseQueryDto
    {
        public bool? Valid { get; set; }

        public string BrandId { get; set; }
        public string CategoryId { get; set; }
        public string ItemDetailsId { get; set; }
    }
}
