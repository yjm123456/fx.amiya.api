using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    public class HospitalInfoDetailVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        public string Phone { get; set; }

        public bool Valid { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }
        /// <summary>
        /// 营业时间
        /// </summary>
        public string BusinessHours { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime? DueTime { get; set; }
        /// <summary>
        /// 合同地址
        /// </summary>
        public string ContractUrl { get; set; }


        public List<int> ScaleTagList { get; set; }
        public List<int> FacilityTagList { get; set; }
    }
}
