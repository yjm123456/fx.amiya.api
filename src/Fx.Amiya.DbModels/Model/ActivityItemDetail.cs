using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class ActivityItemDetail
    {
        public int Id { get; set; }
        public int ActityId { get; set; }
        public int ItemId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal LivePrice { get; set; }
     

        public ActivityInfo ActivityInfo { get; set; }
        public ItemInfo ItemInfo { get; set; }
    }
}
