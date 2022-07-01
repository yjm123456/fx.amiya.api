using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class ActivityInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Valid { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public AmiyaEmployee CreateByAmiyaEmployee { get; set; }
        public AmiyaEmployee UpdateByAmiyaEmployee { get; set; }

        public List<ActivityItemDetail> ActivityItemDetailList { get; set; }
        public List<HospitalPartakeItem> HospitalPartakeItemList { get; set; }
    }
}
