using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.HospitalInfo
{
    public class WxHospitalInfoVo
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



        public List<DocterVo> DocterList { get; set; }

        public List<WxHospitalTagInfoVo> ScaleTagList { get; set; }
        public List<WxHospitalTagInfoVo> FacilityTagList { get; set; }
    }
}
