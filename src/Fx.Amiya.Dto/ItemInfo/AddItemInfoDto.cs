﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.ItemInfo
{
   public class AddItemInfoDto
    {
        public string OtherAppItemId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 科室id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        public string ThumbPicUrl { get; set; }
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
        public string Remark { get; set; }
    }
}
