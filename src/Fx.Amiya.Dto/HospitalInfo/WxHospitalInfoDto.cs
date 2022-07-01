using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalInfo
{
    public class WxHospitalInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        public string Phone { get; set; }
        public string ThumbPicUrl { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }

        /// <summary>
        /// 推荐排名
        /// </summary>
        public int? RecommendIndex { get; set; }

        public List<DocterDto> DocterList { get; set; }

        public List<HospitalTagNameDto> ScaleTagList { get; set; }
        public List<HospitalTagNameDto> FacilityTagList { get; set; }
        
    }
}
