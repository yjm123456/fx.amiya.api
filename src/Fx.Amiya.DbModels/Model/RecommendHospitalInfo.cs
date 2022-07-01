using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class RecommendHospitalInfo
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int RecommendIndex { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Valid { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }

        public HospitalInfo HospitalInfo { get; set; }
        public AmiyaEmployee CreateByAmiyaEmployee { get; set; }
        public AmiyaEmployee UpdateByAmiyaEmployee { get; set; }

    }
}
