using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.ItemInfo
{
  public  class ItemInfoDto
    {
        public int Id { get; set; }
        public string OtherAppItemId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 科室id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepartmentName { get; set; }
        public string ThumbPicUrl { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string AppType { get; set; }
        public string AppTypeText { get; set; }
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
        /// <summary>
        /// 品项id
        /// </summary>
        public string ItemDetailsId { get; set; }
        /// <summary>
        /// 品项名称
        /// </summary>
        public string ItemDetailsName { get; set; }
        public string Parts { get; set; }
        public decimal SalePrice { get; set; }
        public decimal? LivePrice { get; set; }
        public bool IsLimitBuy { get; set; }
        public int? LimitBuyQuantity { get; set; }
        public string Commitment { get; set; }
        public string Guarantee { get; set; }
        public string AppointmentNotice { get; set; }

        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateName { get; set; }
        public bool Valid { get; set; }
        public string Remark { get; set; }



    }
}
