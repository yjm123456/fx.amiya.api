using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 科室id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string AppType { get; set; }
        public string BrandId { get; set; }
        public string CategoryId { get; set; }
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
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public bool Valid { get; set; }
        public int? ItemDetailId { get; set; }
        public string OtherAppItemId { get; set; }
        public string Remark { get; set; }

        public AmiyaEmployee CreateEmployee { get; set; }
        public AmiyaEmployee UpdateEmployee { get; set; }

        public List<ActivityItemDetail> ActivityItemDetailList { get; set; }
        public List<HospitalPartakeItem> HospitalPartakeItemList { get; set; }
        public List<LivingDailyTakeGoods> LivingDailyTakeGoodsList { get; set; }
    }
}
