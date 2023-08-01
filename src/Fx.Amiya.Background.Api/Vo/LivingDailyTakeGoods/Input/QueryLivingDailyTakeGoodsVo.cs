using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LivingDailyTakeGoods.Input
{
    public class QueryLivingDailyTakeGoodsVo:BaseQueryVo
    {
        public int? CreateBy { get; set; }
        public bool? Valid { get; set; }

        public string BrandId { get; set; }
        public string CategoryId { get; set; }

        public string ItemDetailsId { get; set; }
    }
}
