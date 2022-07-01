using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.RecommendHospital
{
   public class AddRecommendHospitalInfoDto
    {
        public int HospitalId { get; set; }
        public int RecommendIndex { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
