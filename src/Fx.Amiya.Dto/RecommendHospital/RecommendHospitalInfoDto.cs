using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.RecommendHospital
{
    public class RecommendHospitalInfoDto
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public int RecommendIndex { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool Valid { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateName { get; set; }
    }
}
