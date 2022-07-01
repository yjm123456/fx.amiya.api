using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.RecommendHospital
{
   public class UpdateRecommendHospitalInfoDto
    {
        public int Id { get; set; }
        public int RecommendIndex { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Valid { get; set; }
    }
}
