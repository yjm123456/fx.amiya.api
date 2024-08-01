using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.ItemInfo
{
  public  class ItemInfoSimpleDto
    {
        public int Id { get; set; }
        public string OtherAppItemId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 科室id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string Parts { get; set; }
        public decimal SalePrice { get; set; }
        public decimal? LivePrice { get; set; }
        public bool IsLimitBuy { get; set; }
        public int? LimitBuyQuantity { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 讲解次数
        /// </summary>
        public int ExplainTimes { get; set; }
        /// <summary>
        /// 首次上架时间
        /// </summary>
        public DateTime? FirstTimeOnSell { get; set; }
        /// <summary>
        /// 是否是新品
        /// </summary>
        public bool IsNewGoods { get; set; }

    }
}
