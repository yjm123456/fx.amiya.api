using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalInfo
{
   public class HospitalInfoSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }

        /// <summary>
        /// 推荐排名
        /// </summary>
        public int? RecommendIndex { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        public string BusinessHours { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
    }
}
