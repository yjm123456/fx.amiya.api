using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Activity
{
    public class ActivityItemDetailVo
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }

        public int ItemId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string Parts { get; set; }
        public decimal SalePrice { get; set; }
        public decimal? LivePrice { get; set; }
        public bool IsLimitBuy { get; set; }
        public int? LimitBuyQuantity { get; set; }
        public string Remark { get; set; }

    }
}
