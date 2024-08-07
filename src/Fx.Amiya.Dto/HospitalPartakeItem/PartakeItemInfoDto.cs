using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalPartakeItem
{
   public class PartakeItemInfoDto
    {
        public int ItemId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string Parts { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? LivePrice { get; set; }
        /// <summary>
        /// 是否同意直播价
        /// </summary>
        public bool IsAgreeLivingPrice { get; set; }
        /// <summary>
        /// 医院提报价格
        /// </summary>
        public decimal HospitalPrice { get; set; }
        public bool IsLimitBuy { get; set; }
        public int? LimitBuyQuantity { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HosiptalName { get; set; }
    }
}
