using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.ItemInfo
{
   public class UpdateItemInfoDto
    {
        public int Id { get; set; }
        public string OtherAppItemId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 科室id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        public string ThumbPicUrl { get; set; }
        /// <summary>
        /// 渠道
        /// </summary>
        public string AppType { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }
        /// <summary>
        /// 品类id
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// 品项id
        /// </summary>
        public string ItemDetailsId { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string Parts { get; set; }
        public decimal SalePrice { get; set; }
        public decimal? LivePrice { get; set; }
        public bool IsLimitBuy { get; set; }
        public int? LimitBuyQuantity { get; set; }
        public string Commitment { get; set; }
        public string Guarantee { get; set; }
        public string AppointmentNotice { get; set; }
        public bool Valid { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 讲解次数
        /// </summary>
        public int ExplainTimes { get; set; }
        /// <summary>
        /// 首次上架时间
        /// </summary>
        public DateTime? FirstTimeOnSell { get; set; }
    }
}
