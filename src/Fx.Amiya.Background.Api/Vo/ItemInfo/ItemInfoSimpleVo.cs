using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ItemInfo
{
    public class ItemInfoSimpleVo
    {
        public int Id { get; set; }
        public string OtherAppItemId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string Parts { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 直播价
        /// </summary>
        public decimal? LivePrice { get; set; }

        /// <summary>
        /// 是否限购
        /// </summary>
        public bool IsLimitBuy { get; set; }

        /// <summary>
        /// 限购数量
        /// </summary>
        public int? LimitBuyQuantity { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
