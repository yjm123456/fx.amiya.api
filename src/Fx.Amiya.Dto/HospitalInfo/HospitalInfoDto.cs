using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalInfo
{
   public class HospitalInfoDto
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

        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        public string BusinessHours { get; set; }
        public DateTime? DueTime { get; set; }

        /// <summary>
        /// 可用日期
        /// </summary>
        public string HasUsedTime { get; set; }
        public string ContractUrl { get; set; }
        public string BelongCompany { get; set; }
        /// <summary>
        /// 是否在小程序展示
        /// </summary>
        public bool IsShareInMiniProgram { get; set; }

    }
}
